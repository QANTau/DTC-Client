using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;
using Newtonsoft.Json;

namespace QANT.DTC
{
    /// <summary>
    /// DTC Client
    /// </summary>
    public partial class Client
    {
        private readonly Socket _socket;
        private IPEndPoint _endPoint;
        private AsyncCallback _callback;
        private byte[] _buffer;

        private string _user;
        private string _password;

        private readonly Timer _heartbeatTimer;
        private int _heartbeatSendCount;
        private int _heartbeatReceiveCount;
        private int _heartbeatsMissed;

        private bool _encodingCompleted;
        private bool _loginComplete;

        private readonly bool _isHistorical;
        private bool _isReadyForHistorical;

        private readonly ConcurrentQueue<byte[]> _sendQueue;

        private readonly ConcurrentQueue<byte[]> _receiveQueue;

        private readonly ConcurrentQueue<byte[]> _historicalDataQueue;

        public Messages.LogonResponse LogonResponse { get; private set; }
        public Messages.Heartbeat LatestHeartbeatReceived { get; private set; }

        /// <summary>
        /// DTC Client
        /// </summary>
        public Client(bool isHistorical = false)
        {
            _isHistorical = isHistorical;

            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                DontFragment = true,
                ReceiveBufferSize = int.MaxValue
            };
            _encodingCompleted = false;

            _heartbeatTimer = new Timer
            {
                Interval = Protocol.HeartbeatInterval * 1000
            };
            _heartbeatTimer.Elapsed += _heartbeatTimer_Elapsed;

            _heartbeatSendCount = 0;
            _heartbeatReceiveCount = 0;

            _loginComplete = false;

            _sendQueue = new ConcurrentQueue<byte[]>();
            var sendWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = false
            };
            sendWorker.DoWork += _sendWorker_DoWork;
            sendWorker.RunWorkerAsync();

            _receiveQueue = new ConcurrentQueue<byte[]>();
            var receiveWorker = new BackgroundWorker
            {
                WorkerSupportsCancellation = false
            };
            receiveWorker.DoWork += _receiveWorker_DoWork;
            receiveWorker.RunWorkerAsync();

            _historicalDataQueue = new ConcurrentQueue<byte[]>();
        }

        /// <summary>
        /// Connection Status
        /// </summary>
        public bool IsConnected => _socket.Connected;

        #region Events

        /// <summary>
        /// On Connect
        /// </summary>
        public event EventHandler<EventArgs> OnConnect;

        protected void OnConnectEvent()
        {
            OnConnect?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// On Disconnect
        /// </summary>
        public event EventHandler<EventArgs> OnDisconnect;

        protected void OnDisconnectEvent()
        {
            OnDisconnect?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Error Reporting
        /// </summary>
        public event EventHandler<ErrorEventArgs> OnError;

        protected void OnErrorEvent(ErrorEventArgs args)
        {
            OnError?.Invoke(this, args);
        }

        /// <summary>
        /// Diagnostic Information
        /// </summary>
        public event EventHandler<EventArgs> OnReadyForHistoricalDataRequest;

        protected void OnReadyForHistoricalDataRequestEvent()
        {
            OnReadyForHistoricalDataRequest?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Diagnostic Information
        /// </summary>
        public event EventHandler<MessageEventArgs> OnInformation;

        protected void OnInformationEvent(string message)
        {
            OnInformation?.Invoke(this, new MessageEventArgs(message));
        }

        /// <summary>
        /// OnSymbolInformation
        /// </summary>
        public event EventHandler<SymbolLookupEventArgs> OnSymbolInformation;

        protected void OnSymbolInformationEvent(Messages.SecurityDefinitionResponse message)
        {
            OnSymbolInformation?.Invoke(this, new SymbolLookupEventArgs(message));
        }

        /// <summary>
        /// Message Send
        /// </summary>
        public event EventHandler<MessageEventArgs> OnMessageSend;

        protected void OnMessageSendEvent(string message)
        {
            OnMessageSend?.Invoke(this, new MessageEventArgs(message));
        }

        /// <summary>
        /// Raw Message Send
        /// </summary>
        public event EventHandler<RawMessageEventArgs> OnRawMessageSend;

        protected void OnRawMessageSendEvent(byte[] packet, Protocol.MessageType messageType)
        {
            OnRawMessageSend?.Invoke(this, new RawMessageEventArgs(packet, messageType));
        }

        /// <summary>
        /// Message Receive
        /// </summary>
        public event EventHandler<MessageEventArgs> OnMessageReceive;

        protected void OnMessageReceiveEvent(string message)
        {
            OnMessageReceive?.Invoke(this, new MessageEventArgs(message));
        }

        /// <summary>
        /// Raw Message Receive
        /// </summary>
        public event EventHandler<RawMessageEventArgs> OnRawMessageReceive;

        protected void OnRawMessageReceiveEvent(byte[] packet, Protocol.MessageType messageType)
        {
            OnRawMessageReceive?.Invoke(this, new RawMessageEventArgs(packet, messageType));
        }

        // TODO - OnRealtimeData

        // TODO - OnHistoricalData

        // TODO - OnTradeUpdate

        #endregion

        #region Connection Management

        /// <summary>
        /// Connect to DTC Server
        /// </summary>
        /// <param name="ipAddress">IP Address</param>
        /// <param name="port">Port</param>
        /// <param name="user">Username</param>
        /// <param name="password">Password</param>
        /// <param name="isHistorical">Historical Data Request</param>
        public void Connect(string ipAddress, int port, string user, string password, bool isHistorical = false)
        {
            OnInformationEvent($"Connecting to {ipAddress} on port {port}");

            _user = user;
            _password = password;

            _endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            _callback = OnReceive;

            _buffer = _isHistorical ? new byte[Protocol.HistoricalBufferSize] : new byte[Protocol.BufferSize];

            try
            {
                _socket.Connect(_endPoint);
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, _callback, null);
            }
            catch (Exception ex)
            {
                OnErrorEvent(new ErrorEventArgs(ex, null));
            }

            // Send Encoding Request
            OnInformationEvent("Sending Json Encoding Request");
            var request = new Messages.EncodingRequest();
            SendData(request.Binary());
        }

        /// <summary>
        /// Disconnect from DTC Server
        /// </summary>
        public void Disconnect()
        {
            _heartbeatTimer.Stop();
            OnInformationEvent("Processing Disconnection");
            if (_socket.Connected)
            {
                var request = new Messages.LogoffRequest("Client Disconnect Request");
                SendData(request);
            }
            OnDisconnectEvent();
            _socket.Disconnect(true);
        }

        /// <summary>
        /// DTC Server Logon
        /// </summary>
        private void Logon(bool isHistorical = false)
        {
            OnInformationEvent("Sending Logon Request");
            var request = new Messages.LogonRequest(_user, _password, isHistorical);
            SendData(request.Packet());
        }

        #endregion

        #region Symbol Requests

        public void RequestSymbolDefinition(int requestId, string symbol, string exchange = "")
        {
            var request = new Messages.SecurityDefinitionForSymbolRequest(requestId, symbol, exchange);
            SendData(request);
        }

        #endregion

        #region Market Data Requests

        public void RequestMarketData(string symbol, int symbolId, Protocol.RequestAction action = Protocol.RequestAction.Subscribe)
        {
            var request = new Messages.MarketDataRequest(symbolId, symbol, action);
            SendData(request);
        }

        #endregion

        #region Historical Data Requests

        public void RequestHistoricalData(string symbol, int requestId, Protocol.HistoricalDataInterval interval,
            DateTime startDate, DateTime endDate, string exchange = "")
        {
            var request = new Messages.HistoricalPriceDataRequest(
                requestId, symbol, exchange, interval, startDate, endDate);

            SendData(request);
        }

        public void ProcessHistoricalData()
        {
            var packets = new byte[0];

            while (_historicalDataQueue.Count > 0)
            {
                _historicalDataQueue.TryDequeue(out var packet);
                packets = Utils.Combine(packets, packet);
            }

            ReceiveData(packets);

        }

        #endregion

        #region Trading Requests

        #endregion

        #region Socket/Msg Handling

        /// <summary>
        /// Queue Outgoing Data
        /// </summary>
        /// <param name="packet"></param>
        private void SendData(byte[] packet)
        {
            _sendQueue.Enqueue(packet);
        }

        /// <summary>
        /// Queue Outgoing Data
        /// </summary>
        /// <param name="message"></param>
        private void SendData(object message)
        {
            SendData(Utils.AsBytes(JsonConvert.SerializeObject(message)));
        }

        /// <summary>
        /// Queue Incoming Data
        /// </summary>
        /// <param name="packet"></param>
        private void ReceiveData(byte[] packet)
        {
            if (!_socket.Connected) return;

            const byte nullChar = 0;

            var packets = Utils.SplitBytesByDelimiter(packet, nullChar);
            foreach (var item in packets)
                _receiveQueue.Enqueue(item);
        }

        /// <summary>
        /// Socket Receive Thread
        /// </summary>
        /// <param name="asyn"></param>
        private void OnReceive(IAsyncResult asyn)
        {
            // Sanity Checks
            int receivedBytes;
            try
            {
                receivedBytes = _socket.EndReceive(asyn);
            }
            catch (Exception ex)
            {
                OnErrorEvent(new ErrorEventArgs(ex, null));
                return;
            }

            // Response Handling
            var packet = new byte[receivedBytes];
            Buffer.BlockCopy(_buffer, 0, packet, 0, receivedBytes);

            if (!_encodingCompleted)                                        // Encoding Response (Binary)
            {
                if (packet.Length != 16)
                {
                    OnErrorEvent(new ErrorEventArgs(null, "Failure in Encoding Response"));
                    Disconnect();
                    return;
                }

                var response = new Messages.EncodingResponse(packet);
                if (response.Type == Protocol.MessageType.EncodingResponse)
                {
                    // Raise Events
                    OnConnectEvent();
                    OnMessageReceiveEvent("EncodingResponse");
                    OnInformationEvent("Json Encoding Request Complete");

                    // Initiate Logon
                    _encodingCompleted = true;
                    Logon();
                }
                else
                {
                    OnErrorEvent(new ErrorEventArgs(null, "Failure in Encoding Response"));
                    Disconnect();
                    return;
                }
            }
            else                                                            // Other Responses (Json)
            {
                // Enqueue Incoming Data
                ReceiveData(packet);
            }

            try
            {
                if (_isReadyForHistorical)
                    _callback = OnReceiveHistorical;
                else
                    _callback = OnReceive;

                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, _callback, null);
            }
            catch (Exception ex)
            {
                OnErrorEvent(new ErrorEventArgs(ex, null));
            }
        }


        /// <summary>
        /// Socket Receive Thread
        /// </summary>
        /// <param name="asyn"></param>
        private void OnReceiveHistorical(IAsyncResult asyn)
        {
            var receivedBytes = _socket.EndReceive(asyn);
            var packet = new byte[receivedBytes];
            Buffer.BlockCopy(_buffer, 0, packet, 0, receivedBytes);
            _historicalDataQueue.Enqueue(packet);
        }

        #endregion

        #region Heartbeat Management

        /// <summary>
        /// Heartbeart Timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _heartbeatTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        if (_isHistorical) return;                      // No Heartbeats for Historical Requests

        // Stop the Timer
        _heartbeatTimer.Stop();

        if (!_socket.Connected) return;

        // Send Heartbeat Msg
        var request = new Messages.Heartbeat();
        SendData(request);

        // Heartbeat Management
        _heartbeatSendCount++;

        if (_heartbeatsMissed > 0)
        {
            var errmsg = "WARNING - " + _heartbeatsMissed + " Heartbeats have been Missed";
            OnErrorEvent(new ErrorEventArgs(null, errmsg));
        }

        // Check for Heartbeat Errors
        _heartbeatsMissed += Math.Abs(_heartbeatSendCount - _heartbeatReceiveCount);
        if (_heartbeatsMissed > Protocol.HeartbeatLossMaximum)
        {
            var msg = $"Exceeded HEARTBEAT_LOSS_MAXIMUM {Protocol.HeartbeatLossMaximum}";
            OnErrorEvent(new ErrorEventArgs(null, msg));
            Disconnect();
        }

        // Restart the Timer
        _heartbeatTimer.Start();
    }

    #endregion

        #region Queue Management

        private void _sendWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                while (_sendQueue.Count > 0)
                {
                    // Dequeue
                    _sendQueue.TryDequeue(out var packet);

                    if (!_socket.Connected)
                        return;

                    // Send Data
                    try
                    {
                        _socket.SendBufferSize = packet.Length;
                        Thread.Sleep(100);                                  // Delay to Prevent Overloading
                        _socket.Send(packet);

                        // Send Notification
                        if (_encodingCompleted)
                        {
                            var messageType = Utils.GetMessageType(packet);
                            OnMessageSendEvent(messageType.ToString());
                            OnRawMessageSendEvent(packet, messageType);
                        }
                        else
                        {
                            OnMessageSendEvent("EncodingRequest");
                        }
                    }
                    catch (Exception ex)
                    {
                        OnErrorEvent(new ErrorEventArgs(ex, null));
                    }
                }
                Thread.Sleep(1);
            }
        }

        private void _receiveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                while (_receiveQueue.Count > 0)
                {
                    // Dequeue
                    _receiveQueue.TryDequeue(out var packet);

                    if (packet == null)
                        return;

                    // Message Processing
                    var message = Utils.GetString(packet);
                    var messageType = Utils.GetMessageType(packet);

                    OnMessageReceiveEvent(messageType.ToString());
                    OnRawMessageReceiveEvent(packet, messageType);

                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (messageType)
                    {
                        case Protocol.MessageType.GeneralLogMessage:
                            {
                                var response = JsonConvert.DeserializeObject<Messages.GeneralLogMessage>(message);
                                OnInformationEvent(response.MessageText);
                                break;
                            }
                        case Protocol.MessageType.Heartbeat:
                            {
                                LatestHeartbeatReceived = JsonConvert.DeserializeObject<Messages.Heartbeat>(message);

                                if (LatestHeartbeatReceived.NumDroppedMessages > 0)
                                    OnInformationEvent("DTC Server Reports " + LatestHeartbeatReceived.NumDroppedMessages + " Dropped Heartbeats");

                                _heartbeatReceiveCount++;
                                _heartbeatsMissed = 0;

                                break;
                            }
                        case Protocol.MessageType.LogonResponse:
                            {
                                if (!_loginComplete)
                                {
                                    LogonResponse = JsonConvert.DeserializeObject<Messages.LogonResponse>(message);

                                    // Flag Login as Complete
                                    _loginComplete = true;

                                    if (_isHistorical)
                                    {
                                        _isReadyForHistorical = true;
                                        _callback = OnReceiveHistorical;
                                        _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, _callback, null);
                                        OnReadyForHistoricalDataRequestEvent();
                                    }
                                    else
                                        _heartbeatTimer.Start();
                                }
                                break;
                            }
                        /*case Protocol.MessageType.HistoricalPriceDataRecordResponse:
                            {
                                // Process the Response
                                var response = new Messages.HistoricalPriceDataRecordResponse(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);
                                break;
                            }*/
                        /*case Protocol.MessageType.HistoricalPriceDataReject:
                            {
                                // Process the Response
                                var response = new Messages.HistoricalPriceDataReject(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);
                                break;
                            }*/
                        /*case Protocol.MessageType.HistoricalPriceDataResponseHeader:
                            {
                                // Process the Response
                                var response = new Messages.HistoricalPriceDataResponseHeader(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);
                                break;
                            }*/
                        case Protocol.MessageType.MarketDataSnapshot:                           // No Action (Handled by Raw Message Event)
                            {
                                break;
                            }
                        /*case Protocol.MessageType.MarketDataUpdateBidAskCompact:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateBidAskCompact(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);

                                break;
                            }*/
                        /*case Protocol.MessageType.MarketDataUpdateSessionHigh:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);
                                break;
                            }*/
                        /*case Protocol.MessageType.MarketDataUpdateSessionLow:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);
                                break;
                            }*/
                        /*case Protocol.MessageType.MarketDataUpdateSessionSettlement:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);
                                break;
                            }*/
                        /*case Protocol.MessageType.MarketDataUpdateSessionVolume:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);
                                break;
                            }*/
                        case Protocol.MessageType.SecurityDefinitionReject:
                            {

                                //var response = new Messages.SecurityDefinitionReject(header, payload);
                                // TODO OnMessageReceiveEvent(header, response);

                                break;
                            }
                        case Protocol.MessageType.SecurityDefinitionResponse:
                            {
                                var response = JsonConvert.DeserializeObject<Messages.SecurityDefinitionResponse>(message);
                                OnSymbolInformationEvent(response);
                                break;
                            }
                        default:
                            {
                                // Unsupported Message Type
                                OnErrorEvent(new ErrorEventArgs(null, "Message Type " + messageType.ToString() + "Not Supported"));
                                break;
                            }
                    }
                }
                Thread.Sleep(1);
            }
        }

        #endregion

    }
}
