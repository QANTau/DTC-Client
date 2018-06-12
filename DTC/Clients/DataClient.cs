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
    /// DTC Data Client
    /// </summary>
    public class DataClient
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

        private readonly ConcurrentQueue<byte[]> _sendQueue;

        private readonly ConcurrentQueue<byte[]> _receiveQueue;

        public Messages.LogonResponse LogonResponse { get; private set; }
        public Messages.Heartbeat LatestHeartbeatReceived { get; private set; }

        /// <summary>
        /// DTC DataClient
        /// </summary>
        public DataClient()
        {
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
        /// On Information
        /// </summary>
        public event EventHandler<MessageEventArgs> OnInformation;

        protected void OnInformationEvent(string message)
        {
            OnInformation?.Invoke(this, new MessageEventArgs(message));
        }

        /// <summary>
        /// On Symbol Information
        /// </summary>
        public event EventHandler<SymbolLookupEventArgs> OnSymbolInformation;

        protected void OnSymbolInformationEvent(Messages.SecurityDefinitionResponse message)
        {
            OnSymbolInformation?.Invoke(this, new SymbolLookupEventArgs(message));
        }

        /// <summary>
        /// On Message Send
        /// </summary>
        public event EventHandler<MessageEventArgs> OnMessageSend;

        protected void OnMessageSendEvent(string message)
        {
            OnMessageSend?.Invoke(this, new MessageEventArgs(message));
        }

        /// <summary>
        /// On Raw Message Send
        /// </summary>
        public event EventHandler<RawMessageEventArgs> OnRawMessageSend;

        protected void OnRawMessageSendEvent(byte[] packet, Protocol.MessageType messageType)
        {
            OnRawMessageSend?.Invoke(this, new RawMessageEventArgs(packet, messageType));
        }

        /// <summary>
        /// On Message Receive
        /// </summary>
        public event EventHandler<MessageEventArgs> OnMessageReceive;

        protected void OnMessageReceiveEvent(string message)
        {
            OnMessageReceive?.Invoke(this, new MessageEventArgs(message));
        }

        /// <summary>
        /// On Raw Message Receive
        /// </summary>
        public event EventHandler<RawMessageEventArgs> OnRawMessageReceive;

        protected void OnRawMessageReceiveEvent(byte[] packet, Protocol.MessageType messageType)
        {
            OnRawMessageReceive?.Invoke(this, new RawMessageEventArgs(packet, messageType));
        }

        /// <summary>
        /// On Market Data Update (Bid/Ask)
        /// </summary>
        public event EventHandler<Messages.MarketDataUpdateBidAsk> OnMarketDataBidAsk;

        protected void OnMarketDataBidAskEvent(Messages.MarketDataUpdateBidAsk message)
        {
            OnMarketDataBidAsk?.Invoke(this, message);
        }


        #endregion

        #region Connection Management

        /// <summary>
        /// Connect to DTC Server
        /// </summary>
        /// <param name="ipAddress">IP Address</param>
        /// <param name="port">Port</param>
        /// <param name="user">Username</param>
        /// <param name="password">Password</param>
        public void Connect(string ipAddress, int port, string user, string password)
        {
            OnInformationEvent($"Connecting to {ipAddress} on port {port}");

            _user = user;
            _password = password;

            _endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

            _callback = OnReceive;

            _buffer = new byte[Protocol.BufferSize];

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
                var request = new Messages.LogoffRequest("DataClient Disconnect Request");
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

        public void RequestMarketData(string symbol, int symbolId,
            Protocol.RequestAction action = Protocol.RequestAction.Subscribe)
        {
            var request = new Messages.MarketDataRequest(symbolId, symbol, action);
            SendData(request);
        }

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
            if (!_socket.Connected || packet.Length == 0) return;

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

            if (!_encodingCompleted) // Encoding Response (Binary)
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
            else // Other Responses (Json)
            {
                // Enqueue Incoming Data
                ReceiveData(packet);
            }

            try
            {
                _callback = OnReceive;
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, _callback, null);
            }
            catch (Exception ex)
            {
                OnErrorEvent(new ErrorEventArgs(ex, null));
            }
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
                        Thread.Sleep(100); // Delay to Prevent Overloading
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
                                OnInformationEvent("DTC Server Reports " +
                                                   LatestHeartbeatReceived.NumDroppedMessages +
                                                   " Dropped Heartbeats");

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
                                _heartbeatTimer.Start();
                            }
                            break;
                        }
                        case Protocol.MessageType.MarketDataSnapshot: 
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateBidAsk:
                        {
                            var response = JsonConvert.DeserializeObject<Messages.MarketDataUpdateBidAsk>(message);
                            OnMarketDataBidAskEvent(response);

                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateBidAskCompact:
                        {
                            var response = JsonConvert.DeserializeObject<Messages.MarketDataUpdateBidAskCompact>(message);
                            OnMarketDataBidAskEvent(new Messages.MarketDataUpdateBidAsk(response));

                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionHigh:
                            {
                                /* No Action - Output Handled by Raw Message Event */
                                break;
                            }
                        case Protocol.MessageType.MarketDataUpdateSessionHighInt:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateLastTradeSnapshot:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionLow:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionLowInt:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionNumTrades:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionOpen:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionOpenInt:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionSettlement:
                            {
                                /* No Action - Output Handled by Raw Message Event */
                                break;
                            }
                        case Protocol.MessageType.MarketDataUpdateSessionSettlementInt:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.MarketDataUpdateSessionVolume:
                        {
                            /* No Action - Output Handled by Raw Message Event */
                            break;
                        }
                        case Protocol.MessageType.SecurityDefinitionReject:
                        {
                            var response = JsonConvert.DeserializeObject<Messages.SecurityDefinitionReject>(message);
                            var error = "Security Definition Request " + response.RequestID +
                                        " was rejected with message '" + response.RejectText + "'";
                            OnErrorEvent(new ErrorEventArgs(null, error));
                            break;
                        }
                        case Protocol.MessageType.SecurityDefinitionResponse:
                        {
                            var response =
                                JsonConvert.DeserializeObject<Messages.SecurityDefinitionResponse>(message);
                            OnSymbolInformationEvent(response);
                            break;
                        }
                        default:
                        {
                            // Unsupported Message Type
                            OnErrorEvent(new ErrorEventArgs(null,
                                "Message Type " + messageType.ToString() + " Not Supported"));
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
