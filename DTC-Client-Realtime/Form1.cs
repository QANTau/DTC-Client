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

            LoadConnectionSettings();
            LoadConnectionSettingsHistorical();
        }

        #region Connection Management

        private void cmdConnDisconn_Click(object sender, EventArgs e)
        {
            bool isConnected = false;

            if (_client != null)
                if (_client.IsConnected)
                    isConnected = true;

            if (!isConnected)
            {
                // Setup DTC Client
                _client = new Client();
                _client.ConnectEvent += Client_ConnectEvent;
                _client.DisconnectEvent += Client_DisconnectEvent;
                _client.ErrorEvent += Client_ErrorEvent;
                _client.DiagnosticEvent += _client_DiagnosticEvent;
                _client.MessageReceiveEvent += _client_MessageReceiveEvent;
                _client.MessageSendEvent += _client_MessageSendEvent;
                
                // IP Address & Port
                var ipAddress = txtHost.Text.Trim();
                Int16.TryParse(txtPort.Text, out short port);
                var username = txtUsername.Text.Trim();
                var password = txtPassword.Text.Trim();

                // Connect
                _client.Connect(ipAddress, port, username, password);
            }
            else
            {
                _client.Disconnect();
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

        #region Symbol Definition

        private void cmdSymbolInfoRequest_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolInfo.Text.Trim().ToUpper();
            _client.RequestSymbolDefinition(_requestId, symbol);
            _requestId++;
        }

        #endregion

        #region Real Time Data

        private void cmdSubscribe_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolRT.Text.Trim().ToUpper();

            if (rbnMarketData.Checked)
            {
                if (!_realtimeSymbolsData.ContainsKey(symbol))
                {
                    _client.RequestMarketData(symbol, _requestId);
                    _realtimeSymbolsData.Add(symbol, _requestId);
                    _requestId++;
                }
            }
            else
            {
                if (!_realtimeSymbolsData.ContainsKey(symbol))
                {
                    _client.RequestMarketDepth(symbol, _requestId, 2);
                    _realtimeSymbolsData.Add(symbol, _requestId);
                    _requestId++;
                }

            }
        }

        private void cmdUnsubscribe_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolRT.Text.Trim().ToUpper();

            if (rbnMarketData.Checked)
            {
                if (_realtimeSymbolsData.ContainsKey(symbol))
                {
                    _client.RequestMarketData(symbol, _realtimeSymbolsData[symbol], Protocol.RequestAction.Unsubscribe);
                    _realtimeSymbolsData.Remove(symbol);
                }
            }
            else
            {
                if (_realtimeSymbolsData.ContainsKey(symbol))
                {
                    _client.RequestMarketDepth(symbol, _realtimeSymbolsData[symbol], 2, Protocol.RequestAction.Unsubscribe);
                    _realtimeSymbolsData.Remove(symbol);
                }
            }
        }

        private void cmdSnapshot_Click(object sender, EventArgs e)
        {
            if (_client == null)
                return;

            var symbol = txtSymbolRT.Text.Trim().ToUpper();

            if (rbnMarketData.Checked)
            {
                _client.RequestMarketData(symbol, _requestId, Protocol.RequestAction.Snapshot);
                _requestId++;
            }
            else
            {
                _client.RequestMarketDepth(symbol, _requestId, 2, Protocol.RequestAction.Snapshot);
                _requestId++;
            }
        }

        private string FindSymbolForRealtime(int requestId)
        {
            var result = "UNKNOWN";

            foreach (var item in _realtimeSymbolsData)
            {
                if (item.Value == requestId)
                {
                    result = item.Key;
                }
            }

            return result;
        }

        #endregion

        #region External Events

        private void Client_ConnectEvent(object sender, EventArgs e)
        {
            AppendActivityLog("Connected");

            SetConnDisconnStatus();
        }
        private void Client_DisconnectEvent(object sender, EventArgs e)
        {
            AppendActivityLog("Disconnected");

            SetConnDisconnStatus();
        }

        private void Client_ErrorEvent(object sender, Client.ErrorEventArgs e)
        {
            AppendErrorLog(e.Exception == null ? e.Msg : e.Exception.Message);
        }

        private void _client_DiagnosticEvent(object sender, Client.DiagnosticEventArgs e)
        {

            if (chkDiagnosticEvents.Checked)
            {
                AppendActivityLog(e.Msg);
            }
        }

        private void _client_MessageSendEvent(object sender, Client.MessageEventArgs e)
        {
            if (chkVerbose.Checked)
            {
                AppendSendLog(e.Size + " Bytes \t" + e.Type);
            }
            else
            {
                // Ignore Specific (Implemented) Msg Types 
                switch (e.Type)
                {
                    case Protocol.MessageType.Heartbeat:
                        break;
                    default:
                        AppendSendLog(e.Size + " Bytes \t" + e.Type);
                        break;
                }
            }
        }

        private void _client_MessageReceiveEvent(object sender, Client.MessageEventArgs e)
        {
            if (e.Msg == null)
            {
                AppendReceiveLog(e.Size + " Bytes \t" + e.Type + " (Not Implemented)");
            }
            else
            {
                if (chkVerbose.Checked)
                {
                    AppendReceiveLog(e.Size + " Bytes \t" + e.Type);
                }
                else
                {
                    // Ignore Specific (Implemented) Msg Types 
                    switch (e.Type)
                    {
                        case Protocol.MessageType.Heartbeat:
                            break;
                        case Protocol.MessageType.MarketDataUpdateTradeCompact:
                            break;
                        case Protocol.MessageType.MarketDataUpdateBidAskCompact:
                            break;
                        default:
                            AppendReceiveLog(e.Size + " Bytes \t" + e.Type);
                            break;
                    }
                }
            }

            // Security/Realtime/Historical Data Update
            switch (e.Type)
            {
                case Protocol.MessageType.LogonResponse:
                    {
                        var obj = (Messages.LogonResponse)e.Msg;
                        AppendMiscMessages(e.Type + Environment.NewLine + JsonConvert.SerializeObject(obj, Formatting.Indented));
                        break;
                    }
                case Protocol.MessageType.MarketDataSnapshot:
                    {
                        var obj = (Messages.MarketDataSnapshot)e.Msg;
                        AppendMiscMessages(e.Type + Environment.NewLine + JsonConvert.SerializeObject(obj, Formatting.Indented));
                        break;
                    }
                case Protocol.MessageType.MarketDataUpdateBidAskCompact:
                    {
                        var obj = (Messages.MarketDataUpdateBidAskCompact)e.Msg;
                        if (obj != null)
                        {
                            var symbol = FindSymbolForRealtime(obj.SymbolId);
                            AppendRealTime(symbol + " " + JsonConvert.SerializeObject(obj));
                        }

                        break;
                    }
                case Protocol.MessageType.SecurityDefinitionResponse:
                    {
                        var obj = (Messages.SecurityDefinitionResponse)e.Msg;
                        AppendMiscMessages(e.Type + Environment.NewLine + JsonConvert.SerializeObject(obj, Formatting.Indented));
                        break;
                    }
            }
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

        public void AppendMiscMessages(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMiscMessages), msg);
                return;
            }

            var dt = DateTime.Now.ToString("yyyyMMdd")
                + " "
                + DateTime.Now.ToString("HH:mm:ss")
                + " - ";

            txtMiscMessages.AppendText(dt + msg + Environment.NewLine + Environment.NewLine);

            txtMiscMessages.ScrollToCaret();
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

        #endregion

        #region On-Screen Log Management

        private void txtActivityLog_DoubleClick(object sender, EventArgs e)
        {
            txtActivityLog.Clear();
        }

        private void txtMiscMessages_DoubleClick(object sender, EventArgs e)
        {
            txtMiscMessages.Clear();
        }

        private void txtRealTime_DoubleClick(object sender, EventArgs e)
        {
            txtRealTime.Clear();
        }

        private void txtErrorLog_DoubleClick(object sender, EventArgs e)
        {
            txtErrorLog.Clear();
        }

        private void txtSendLog_DoubleClick(object sender, EventArgs e)
        {
            txtSendLog.Clear();
        }

        private void txtReceiveLog_DoubleClick(object sender, EventArgs e)
        {
            txtReceiveLog.Clear();
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

        private void LoadConnectionSettingsHistorical()
        {
            //  Loads settings from Registry (SOFTWARE\DTC-Client) if they exist
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(RegistryKey);
                if (key == null) return;
                txtHostHistorical.Text = key.GetValue("HostHistorical").ToString();
                txtPortHistorical.Text = key.GetValue("PortHistorical").ToString();
                txtUsernameHistorical.Text = key.GetValue("UsernameHistorical").ToString();
                txtPasswordHistorical.Text = key.GetValue("PasswordHistorical").ToString();
            }
            catch
            { }
        }

        #endregion

    }
}
