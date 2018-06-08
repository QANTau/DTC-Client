using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

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

        private bool _loginComplete;

        private readonly ConcurrentQueue<Message> _sendQueue;

        private readonly ConcurrentQueue<byte[]> _receiveQueue;

        /// <summary>
        /// DTC Client
        /// </summary>
        public Client()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            {
                DontFragment = true,
                ReceiveBufferSize = Int32.MaxValue
            };

            _heartbeatTimer = new Timer
            {
                Interval = Protocol.HeartbeatInterval * 1000
            };
            _heartbeatTimer.Elapsed += _heartbeatTimer_Elapsed;

            _heartbeatSendCount = 0;
            _heartbeatReceiveCount = 0;

            _loginComplete = false;

            _sendQueue = new ConcurrentQueue<Message>();
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
        public event EventHandler<EventArgs> ConnectEvent;

        protected void OnConnectEvent()
        {
            ConnectEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// On Disconnect
        /// </summary>
        public event EventHandler<EventArgs> DisconnectEvent;

        protected void OnDisconnectEvent()
        {
            DisconnectEvent?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Msg Send
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageSendEvent;

        protected void OnMessageSendEvent(Messages.Header header, object message)
        {
            MessageSendEvent?.Invoke(this, new MessageEventArgs(header, message));
        }

        /// <summary>
        /// Msg Receive
        /// </summary>
        public event EventHandler<MessageEventArgs> MessageReceiveEvent;

        protected void OnMessageReceiveEvent(Messages.Header header, object message)
        {
            MessageReceiveEvent?.Invoke(this, new MessageEventArgs(header, message));
        }

        /// <summary>
        /// Error Reporting
        /// </summary>
        public event EventHandler<ErrorEventArgs> ErrorEvent;

        protected void OnErrorEvent(ErrorEventArgs args)
        {
            ErrorEvent?.Invoke(this, args);
        }

        /// <summary>
        /// Diagnostic Information
        /// </summary>
        public event EventHandler<DiagnosticEventArgs> DiagnosticEvent;

        protected void OnDiagnosticEvent(DiagnosticEventArgs args)
        {
            DiagnosticEvent?.Invoke(this, args);
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
        /// <param name="isHistorical">Historical Data Request</param>
        public void Connect(string ipAddress, int port, string user, string password, bool isHistorical = false)
        {
            OnDiagnosticEvent(new DiagnosticEventArgs($"Connecting to {ipAddress} on port {port}"));

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
            var request = new Messages.EncodingRequest();
            SendData(request.Binary());
        }

        /// <summary>
        /// Disconnect from DTC Server
        /// </summary>
        public void Disconnect()
        {
            _heartbeatTimer.Stop();
            if (_socket.Connected)
                Logoff("Client Disconnect Request");

            OnDisconnectEvent();
        }

        /// <summary>
        /// DTC Server Logon
        /// </summary>
        private void Logon()
        {
            var request = new Messages.LogonRequest(_user, _password);
            SendData(request.Binary());
        }

        /// <summary>
        /// DTC Server Logoff
        /// </summary>
        /// <param name="reason"></param>
        private void Logoff(string reason)
        {
            var request = new Messages.LogoffRequest(reason);
            SendData(request.Binary());
            _socket.Disconnect(true);
        }

        #endregion

        #region Symbol Requests

        public void RequestSymbolSearch(int requestId, string searchText,
            Protocol.SecurityType securityType,
            Protocol.SearchType searchType,
            string exchange = "")
        {
            var request = new Messages.SymbolSearchRequest(requestId, searchText, securityType, searchType, exchange);
            SendData(request.Binary());
        }

        public void RequestSymbolDefinition(int requestId, string symbol, string exchange = "")
        {
            var request = new Messages.SecurityDefinitionForSymbolRequest(requestId, symbol, exchange);
            SendData(request.Binary());
        }

        #endregion

        #region Market Data Requests

        public void RequestMarketData(string symbol, int symbolId, Protocol.RequestAction action = Protocol.RequestAction.Subscribe)
        {
            var request = new Messages.MarketDataRequest(symbolId, symbol, action);
            SendData(request.Binary());
        }

        public void RequestMarketDepth(string symbol, int symbolId, int numLevels, Protocol.RequestAction action = Protocol.RequestAction.Subscribe)
        {
            var request = new Messages.MarketDepthRequest(symbolId, symbol, numLevels, action);
            SendData(request.Binary());
        }

        #endregion

        #region Socket/Msg Handling

        /// <summary>
        /// Queue Outgoing Data
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="header"></param>
        private void SendData(byte[] packet, Messages.Header header)
        {
            _sendQueue.Enqueue(new Message(header, packet, null));
        }

        /// <summary>
        /// Queue Outgoing Data
        /// </summary>
        /// <param name="packet"></param>
        private void SendData(byte[] packet)
        {
            var rawHeader = new byte[4];
            Buffer.BlockCopy(packet, 0, rawHeader, 0, 4);
            var header = new Messages.Header(rawHeader);

            SendData(packet, header);
        }

        /// <summary>
        /// Queue Incoming Data
        /// </summary>
        /// <param name="packet"></param>
        private void ReceiveData(byte[] packet)
        {
            bool isComplete = false;

            while (!isComplete)
            {
                // Process Incoming Packet
                var rawHeader = new byte[4];
                Buffer.BlockCopy(packet, 0, rawHeader, 0, 4);
                var header = new Messages.Header();
                header.SetHeader(rawHeader);

                if (packet.Length == header.Size)
                {
                    // Single Msg in Packet
                    _receiveQueue.Enqueue(packet);
                    isComplete = true;
                }
                else
                {
                    // Validate Header Size = Packet Size 
                    if (header.Size > packet.Length)
                    {
                        isComplete = true;

                        var errmsg =
                            header.Type +
                            "RECEIVE\t Header Size (" +
                            header.Size +
                            ") NOT_EQUAL_TO Packet Size (" +
                            packet.Length +
                            ")";

                        OnErrorEvent(new ErrorEventArgs(null, errmsg));
                    }
                    else
                    {
                        // Process the First Msg
                        var toQueue = new byte[header.Size];
                        Buffer.BlockCopy(packet, 0, toQueue, 0, header.Size);
                        _receiveQueue.Enqueue(toQueue);

                        // Remove the First Msg
                        var remainingBytes = packet.Length - header.Size;
                        var remainingData = new byte[remainingBytes];
                        Buffer.BlockCopy(packet, 0, remainingData, 0, remainingBytes);
                        packet = remainingData;
                    }
                }
            }
        }

        /// <summary>
        /// Socket Receive Thread
        /// </summary>
        /// <param name="asyn"></param>
        private void OnReceive(IAsyncResult asyn)
        {
            // Sanity Checks
            int receivedBytes = 0;
            try
            {
                receivedBytes = _socket.EndReceive(asyn);
            }
            catch (Exception ex)
            {
                OnErrorEvent(new ErrorEventArgs(ex, null));
            }

            // Enqueue Incoming Data
            if (receivedBytes > 4)
            {
                var packet = new byte[receivedBytes];
                Buffer.BlockCopy(_buffer, 0, packet, 0, receivedBytes);
                ReceiveData(packet);

                // Check that the socket is still connected and BeginReceive
                if (!_socket.Connected)
                    return;

                try
                {
                    _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, _callback, null);
                }
                catch (Exception ex)
                {
                    OnErrorEvent(new ErrorEventArgs(ex, null));
                }
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

            // Send Heartbeat Msg
            if (_socket.Connected)
            {
                var request = new Messages.Heartbeat();
                SendData(request.Binary());

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
                    Logoff(msg);
                }

                // Restart the Timer
                _heartbeatTimer.Start();
            }
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
                    _sendQueue.TryDequeue(out Message message);

                    if (!_socket.Connected)
                        return;

                    // Send Data
                    try
                    {
                        if (message.Header.Size != message.Packet.Length)       // Header Size MUST_EQUAL Packet Size
                        {
                            var errmsg =
                                message.Header.Type +
                                "SEND\t Header Size (" +
                                message.Header.Size +
                                ") NOT_EQUAL_TO Packet Size (" +
                                message.Packet.Length +
                                ")";
                            OnErrorEvent(new ErrorEventArgs(null, errmsg));
                        }
                        else                                                    // Send Packet
                        {
                            _socket.SendBufferSize = message.Header.Size;
                            Thread.Sleep(100);                                  // Delay to Prevent Overloading
                            _socket.Send(message.Packet);
                            Thread.Sleep(100);                                  // Delay to Prevent Overloading
                            OnMessageSendEvent(message.Header, message.Content);
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
                    _receiveQueue.TryDequeue(out byte[] message);

                    if (message == null)
                        return;

                    // Identify the Msg
                    var rawHeader = new byte[4];
                    Buffer.BlockCopy(message, 0, rawHeader, 0, 4);
                    var header = new Messages.Header();
                    header.SetHeader(rawHeader);

                    // Msg Payload
                    var payload = new byte[header.Size - 4];
                    Buffer.BlockCopy(message, 4, payload, 0, header.Size - 4);

                    switch (header.Type)
                    {
                        case Protocol.MessageType.EncodingResponse:
                            {
                                // Raise Connection Event
                                OnConnectEvent();

                                // Process the Response
                                var response = new Messages.EncodingResponse(header, payload);
                                OnMessageReceiveEvent(header, response);

                                // Initiate Logon
                                Logon();

                                break;
                            }
                        case Protocol.MessageType.GeneralLogMessage:
                            {
                                // Process the Response
                                var response = new Messages.GeneralLogMessage(header, payload);
                                OnDiagnosticEvent(new DiagnosticEventArgs(response.MessageText));
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.Heartbeat:
                            {
                                // Process the Response
                                var response = new Messages.Heartbeat(header, payload);
                                OnMessageReceiveEvent(header, response);

                                _heartbeatReceiveCount++;
                                _heartbeatsMissed = 0;

                                break;
                            }
                        case Protocol.MessageType.LogonResponse:
                            {
                                if (!_loginComplete)
                                {
                                    // Process the Response
                                    var response = new Messages.LogonResponse(header, payload);
                                    OnMessageReceiveEvent(header, response);

                                    // Flag Login as Complete
                                    _loginComplete = true;
                                }
                                break;
                            }
                        case Protocol.MessageType.HistoricalPriceDataRecordResponse:
                            {
                                // Process the Response
                                var response = new Messages.HistoricalPriceDataRecordResponse(header, payload);
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.HistoricalPriceDataReject:
                            {
                                // Process the Response
                                var response = new Messages.HistoricalPriceDataReject(header, payload);
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.HistoricalPriceDataResponseHeader:
                            {
                                // Process the Response
                                var response = new Messages.HistoricalPriceDataResponseHeader(header, payload);
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.MarketDataSnapshot:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataSnapshot(header, payload);
                                OnMessageReceiveEvent(header, response);

                                break;
                            }
                        case Protocol.MessageType.MarketDataUpdateBidAskCompact:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateBidAskCompact(header, payload);
                                OnMessageReceiveEvent(header, response);

                                break;
                            }
                        case Protocol.MessageType.MarketDataUpdateSessionHigh:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.MarketDataUpdateSessionLow:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.MarketDataUpdateSessionSettlement:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.MarketDataUpdateSessionVolume:
                            {
                                // Process the Response
                                var response = new Messages.MarketDataUpdateSessionX(header, payload);
                                OnMessageReceiveEvent(header, response);
                                break;
                            }
                        case Protocol.MessageType.SecurityDefinitionReject:
                            {
                                var response = new Messages.SecurityDefinitionReject(header, payload);
                                OnMessageReceiveEvent(header, response);

                                break;
                            }
                        case Protocol.MessageType.SecurityDefinitionResponse:
                            {
                                var response = new Messages.SecurityDefinitionResponse(header, payload);
                                OnMessageReceiveEvent(header, response);

                                break;
                            }
                        default:
                            {
                                // Unknown Response
                                OnMessageReceiveEvent(header, null);

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
