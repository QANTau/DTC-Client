using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace QANT.DTC
{
    public partial class Form1 : Form
    {
        private const string RegistryKey = "SOFTWARE\\DTC-Client";

        private Client _client;
        private int _requestId = 1;

        private readonly Dictionary<string, int> _realtimeSymbolsData;

        public Form1()
        {
            InitializeComponent();

            _realtimeSymbolsData = new Dictionary<string, int>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadConnectionSettings();
        }

        #region Connection Management

        private void CmdConnDisconn_Click(object sender, EventArgs e)
        {
            var isConnected = false;

            if (_client != null)
                if (_client.IsConnected)
                    isConnected = true;

            if (!isConnected)
            {
                // Setup DTC DataClient
                _client = new Client();
                _client.OnConnect += ClientOnConnect;
                _client.OnDisconnect += ClientOnDisconnect;

                _client.OnError += ClientOnError;
                _client.OnInformation += ClientOnInformation;

                _client.OnMarketDataBidAsk += ClientOnMarketBidAsk;

                _client.OnMessageSend += ClientOnMessageSend;
                _client.OnMessageReceive += ClientOnMessageReceive;
                _client.OnRawMessageSend += ClientOnRawMessageSend;
                _client.OnRawMessageReceive += ClientOnRawMessageReceive;

                // IP Address & Port
                var ipAddress = txtHost.Text.Trim();
                short.TryParse(txtPort.Text, out var port);
                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text.Trim();

                // Connect
                _client.Connect(ipAddress, port, username, password);
            }
            else
            {
                _client.Disconnect();
                SetConnDisconnStatus();
            }
        }

        public void SetConnDisconnStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SetConnDisconnStatus));
                return;
            }

            cmdConnDisconn.Text = _client.IsConnected ? @"Disconnect" : @"Connect";
        }

        #endregion

        #region Securities/Symbols

        private void CmdSymbolInfoRequest_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolInfo.Text.Trim().ToUpper();

            AppendActivityLog("Requesting Information for " + symbol + " (Request ID " + _requestId + ")");

            _client.RequestSymbolDefinition(_requestId, symbol);
            _requestId++;
        }

        #endregion

        #region Real Time Data

        private void CmdSubscribe_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolRT.Text.Trim().ToUpper();

            if (_realtimeSymbolsData.ContainsKey(symbol)) return;

            AppendActivityLog("Subscribing to " + symbol + " (Request ID " + _requestId + ")");

            _client.RequestMarketData(symbol, _requestId);
            _realtimeSymbolsData.Add(symbol, _requestId);
            _requestId++;
        }

        private void CmdUnsubscribe_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolRT.Text.Trim().ToUpper();

            if (!_realtimeSymbolsData.ContainsKey(symbol)) return;

            AppendActivityLog("Unsubscribing from " + symbol);

            _client.RequestMarketData(symbol, _realtimeSymbolsData[symbol], Protocol.RequestAction.Unsubscribe);
            _realtimeSymbolsData.Remove(symbol);
        }

        private void CmdSnapshot_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolRT.Text.Trim().ToUpper();

            AppendActivityLog("Requesting Snapshot for " + symbol + " (Request ID " + _requestId + ")");

            _client.RequestMarketData(symbol, _requestId, Protocol.RequestAction.Snapshot);
            _requestId++;
        }

        #endregion

        #region Callbacks

        private void ClientOnConnect(object sender, EventArgs e)
        {
            AppendActivityLog("Connected");

            SetConnDisconnStatus();
        }

        private void ClientOnDisconnect(object sender, EventArgs e)
        {
            AppendActivityLog("Disconnected");
        }

        private void ClientOnInformation(object sender, MessageEventArgs e)
        {
            AppendActivityLog(e.Message);
        }

        private void ClientOnError(object sender, ErrorEventArgs e)
        {
            AppendErrorLog(e.Exception == null ? e.Message : e.Exception.Message);
        }

        private void ClientOnMarketBidAsk(object sender, Messages.MarketDataUpdateBidAsk e)
        {
            AppendRealTime(JsonConvert.SerializeObject(e));
        }

        private bool MessageFilter(string message)
        {
            if (chkFilterHeartbeats.Checked && message == "Heartbeat")
                return false;

            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (chkFilterRealtime.Checked && 
                (message == "MarketDataUpdateBidAsk" ||
                 message == "MarketDataUpdateBidAskCompact" ||
                 message == "MarketDataUpdateTrade" ||
                 message == "MarketDataUpdateTradeCompact"))
                return false;

            return true;
        }

        private void ClientOnMessageSend(object sender, MessageEventArgs e)
        {
            if (MessageFilter(e.Message))
                AppendSendLog(e.Message);
        }

        private void ClientOnRawMessageSend(object sender, RawMessageEventArgs e)
        {
            if (!chkDisplayRaw.Checked) return;

            if (!MessageFilter(e.MessageType.ToString())) return;

            var packet = new byte[e.Packet.Length - 1];
            Buffer.BlockCopy(e.Packet, 0, packet, 0, e.Packet.Length - 1);
            AppendSendLogRaw(e.MessageType + " - " + Utils.GetString(packet));
        }

        private void ClientOnMessageReceive(object sender, MessageEventArgs e)
        {
            if (MessageFilter(e.Message))
                AppendReceiveLog(e.Message);
        }

        private void ClientOnRawMessageReceive(object sender, RawMessageEventArgs e)
        {
            if (!chkDisplayRaw.Checked) return;

            if (!MessageFilter(e.MessageType.ToString())) return;

            var packet = new byte[e.Packet.Length - 1];
            Buffer.BlockCopy(e.Packet, 0, packet, 0, e.Packet.Length - 1);
            AppendReceiveLogRaw(e.MessageType + " - " + Utils.GetString(packet));
        }

        #endregion

        #region On-Screen Log Appenders

        public void AppendActivityLog(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendActivityLog), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                + " "
                + DateTime.Now.ToString("HH:mm:ss")
                + " - ";

            txtActivityLog.AppendText(dt + msg + Environment.NewLine);

            txtActivityLog.ScrollToCaret();
        }

        public void AppendRealTime(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendRealTime), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                + " "
                + DateTime.Now.ToString("HH:mm:ss")
                + " - ";

            txtRealTime.AppendText(dt + msg + Environment.NewLine);

            txtRealTime.ScrollToCaret();
        }

        public void AppendErrorLog(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendErrorLog), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                + " "
                + DateTime.Now.ToString("HH:mm:ss")
                + " - ";

            txtErrorLog.AppendText(dt + msg + Environment.NewLine);

            txtErrorLog.ScrollToCaret();
        }

        public void AppendSendLog(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendSendLog), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                + " "
                + DateTime.Now.ToString("HH:mm:ss")
                + " - ";

            txtSendLog.AppendText(dt + msg + Environment.NewLine);

            txtSendLog.ScrollToCaret();
        }

        public void AppendSendLogRaw(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendSendLogRaw), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                     + " "
                     + DateTime.Now.ToString("HH:mm:ss")
                     + " - ";

            txtSendLogRaw.AppendText(dt + msg + Environment.NewLine);

            txtSendLogRaw.ScrollToCaret();
        }

        public void AppendReceiveLog(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendReceiveLog), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                + " "
                + DateTime.Now.ToString("HH:mm:ss")
                + " - ";

            txtReceiveLog.AppendText(dt + msg + Environment.NewLine);

            txtReceiveLog.ScrollToCaret();
        }

        public void AppendReceiveLogRaw(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendReceiveLogRaw), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                     + " "
                     + DateTime.Now.ToString("HH:mm:ss")
                     + " - ";

            txtReceiveLogRaw.AppendText(dt + msg + Environment.NewLine);

            txtReceiveLogRaw.ScrollToCaret();
        }

        #endregion

        #region Load Registry Settings

        private void LoadConnectionSettings()
        {
            //  Loads settings from Registry (SOFTWARE\DTC-Client) if they exist
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(RegistryKey);
                if (key == null) return;
                txtHost.Text = key.GetValue("Host").ToString();
                txtPort.Text = key.GetValue("Port").ToString();
                txtUsername.Text = key.GetValue("Username").ToString();
                txtPassword.Text = key.GetValue("Password").ToString();
            }
            catch
            { }
        }

        #endregion

    }
}
