using System.ComponentModel;
using System.Windows.Forms;

namespace QANT.DTC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdConnDisconn = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdSnapshot = new System.Windows.Forms.Button();
            this.cmdUnsubscribe = new System.Windows.Forms.Button();
            this.cmdSubscribe = new System.Windows.Forms.Button();
            this.txtSymbolRT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageActivity = new System.Windows.Forms.TabPage();
            this.txtActivityLog = new System.Windows.Forms.TextBox();
            this.tabPageErrors = new System.Windows.Forms.TabPage();
            this.txtErrorLog = new System.Windows.Forms.TextBox();
            this.tabPageRealtimeData = new System.Windows.Forms.TabPage();
            this.txtRealTime = new System.Windows.Forms.TextBox();
            this.tabPageSendMessageLog = new System.Windows.Forms.TabPage();
            this.txtSendLog = new System.Windows.Forms.TextBox();
            this.tabPageReceiveMessageLog = new System.Windows.Forms.TabPage();
            this.txtReceiveLog = new System.Windows.Forms.TextBox();
            this.tabPageRawSendMessageLow = new System.Windows.Forms.TabPage();
            this.txtSendLogRaw = new System.Windows.Forms.TextBox();
            this.tabPageRawReceiveMessageLow = new System.Windows.Forms.TabPage();
            this.txtReceiveLogRaw = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdSymbolInfoRequest = new System.Windows.Forms.Button();
            this.txtSymbolInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkFilterRealtime = new System.Windows.Forms.CheckBox();
            this.chkFilterHeartbeats = new System.Windows.Forms.CheckBox();
            this.chkDisplayRaw = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPasswordHistorical = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsernameHistorical = new System.Windows.Forms.TextBox();
            this.txtPortHistorical = new System.Windows.Forms.TextBox();
            this.txtHostHistorical = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabPageHistoricalData = new System.Windows.Forms.TabPage();
            this.tabPageTrading = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbInterval = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdRequestHistoricalData = new System.Windows.Forms.Button();
            this.txtHistoricalSymbol = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageActivity.SuspendLayout();
            this.tabPageErrors.SuspendLayout();
            this.tabPageRealtimeData.SuspendLayout();
            this.tabPageSendMessageLog.SuspendLayout();
            this.tabPageReceiveMessageLog.SuspendLayout();
            this.tabPageRawSendMessageLow.SuspendLayout();
            this.tabPageRawReceiveMessageLow.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPageHistoricalData.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmdConnDisconn);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 149);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(167, 89);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // cmdConnDisconn
            // 
            this.cmdConnDisconn.Location = new System.Drawing.Point(8, 115);
            this.cmdConnDisconn.Name = "cmdConnDisconn";
            this.cmdConnDisconn.Size = new System.Drawing.Size(259, 23);
            this.cmdConnDisconn.TabIndex = 6;
            this.cmdConnDisconn.Text = "Connect";
            this.cmdConnDisconn.UseVisualStyleBackColor = true;
            this.cmdConnDisconn.Click += new System.EventHandler(this.CmdConnDisconn_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(167, 65);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(167, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "11099";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(167, 17);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "127.0.0.1";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(8, 68);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdSnapshot);
            this.groupBox2.Controls.Add(this.cmdUnsubscribe);
            this.groupBox2.Controls.Add(this.cmdSubscribe);
            this.groupBox2.Controls.Add(this.txtSymbolRT);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 76);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Realtime Market Data Request";
            // 
            // cmdSnapshot
            // 
            this.cmdSnapshot.Location = new System.Drawing.Point(189, 45);
            this.cmdSnapshot.Name = "cmdSnapshot";
            this.cmdSnapshot.Size = new System.Drawing.Size(78, 23);
            this.cmdSnapshot.TabIndex = 5;
            this.cmdSnapshot.Text = "Snapshot";
            this.cmdSnapshot.UseVisualStyleBackColor = true;
            this.cmdSnapshot.Click += new System.EventHandler(this.CmdSnapshot_Click);
            // 
            // cmdUnsubscribe
            // 
            this.cmdUnsubscribe.Location = new System.Drawing.Point(100, 45);
            this.cmdUnsubscribe.Name = "cmdUnsubscribe";
            this.cmdUnsubscribe.Size = new System.Drawing.Size(78, 23);
            this.cmdUnsubscribe.TabIndex = 4;
            this.cmdUnsubscribe.Text = "Unsubscribe";
            this.cmdUnsubscribe.UseVisualStyleBackColor = true;
            this.cmdUnsubscribe.Click += new System.EventHandler(this.CmdUnsubscribe_Click);
            // 
            // cmdSubscribe
            // 
            this.cmdSubscribe.Location = new System.Drawing.Point(11, 45);
            this.cmdSubscribe.Name = "cmdSubscribe";
            this.cmdSubscribe.Size = new System.Drawing.Size(78, 23);
            this.cmdSubscribe.TabIndex = 3;
            this.cmdSubscribe.Text = "Subscribe";
            this.cmdSubscribe.UseVisualStyleBackColor = true;
            this.cmdSubscribe.Click += new System.EventHandler(this.CmdSubscribe_Click);
            // 
            // txtSymbolRT
            // 
            this.txtSymbolRT.Location = new System.Drawing.Point(167, 19);
            this.txtSymbolRT.Name = "txtSymbolRT";
            this.txtSymbolRT.Size = new System.Drawing.Size(100, 20);
            this.txtSymbolRT.TabIndex = 0;
            this.txtSymbolRT.Text = "AUDUSD";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Symbol";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageActivity);
            this.tabControl1.Controls.Add(this.tabPageErrors);
            this.tabControl1.Controls.Add(this.tabPageRealtimeData);
            this.tabControl1.Controls.Add(this.tabPageSendMessageLog);
            this.tabControl1.Controls.Add(this.tabPageReceiveMessageLog);
            this.tabControl1.Controls.Add(this.tabPageRawSendMessageLow);
            this.tabControl1.Controls.Add(this.tabPageRawReceiveMessageLow);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(287, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(875, 723);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPageActivity
            // 
            this.tabPageActivity.Controls.Add(this.txtActivityLog);
            this.tabPageActivity.Location = new System.Drawing.Point(4, 22);
            this.tabPageActivity.Name = "tabPageActivity";
            this.tabPageActivity.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageActivity.Size = new System.Drawing.Size(867, 697);
            this.tabPageActivity.TabIndex = 1;
            this.tabPageActivity.Text = "Activity Log";
            this.tabPageActivity.UseVisualStyleBackColor = true;
            // 
            // txtActivityLog
            // 
            this.txtActivityLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtActivityLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtActivityLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtActivityLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivityLog.Location = new System.Drawing.Point(3, 3);
            this.txtActivityLog.Multiline = true;
            this.txtActivityLog.Name = "txtActivityLog";
            this.txtActivityLog.ReadOnly = true;
            this.txtActivityLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActivityLog.Size = new System.Drawing.Size(861, 691);
            this.txtActivityLog.TabIndex = 15;
            this.txtActivityLog.WordWrap = false;
            // 
            // tabPageErrors
            // 
            this.tabPageErrors.Controls.Add(this.txtErrorLog);
            this.tabPageErrors.Location = new System.Drawing.Point(4, 22);
            this.tabPageErrors.Name = "tabPageErrors";
            this.tabPageErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageErrors.Size = new System.Drawing.Size(867, 697);
            this.tabPageErrors.TabIndex = 0;
            this.tabPageErrors.Text = "Error Log";
            this.tabPageErrors.UseVisualStyleBackColor = true;
            // 
            // txtErrorLog
            // 
            this.txtErrorLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtErrorLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtErrorLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrorLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorLog.Location = new System.Drawing.Point(3, 3);
            this.txtErrorLog.Multiline = true;
            this.txtErrorLog.Name = "txtErrorLog";
            this.txtErrorLog.ReadOnly = true;
            this.txtErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorLog.Size = new System.Drawing.Size(861, 691);
            this.txtErrorLog.TabIndex = 14;
            this.txtErrorLog.WordWrap = false;
            // 
            // tabPageRealtimeData
            // 
            this.tabPageRealtimeData.Controls.Add(this.txtRealTime);
            this.tabPageRealtimeData.Location = new System.Drawing.Point(4, 22);
            this.tabPageRealtimeData.Name = "tabPageRealtimeData";
            this.tabPageRealtimeData.Size = new System.Drawing.Size(867, 697);
            this.tabPageRealtimeData.TabIndex = 2;
            this.tabPageRealtimeData.Text = "Realtime Data";
            this.tabPageRealtimeData.UseVisualStyleBackColor = true;
            // 
            // txtRealTime
            // 
            this.txtRealTime.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtRealTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRealTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRealTime.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRealTime.Location = new System.Drawing.Point(0, 0);
            this.txtRealTime.Multiline = true;
            this.txtRealTime.Name = "txtRealTime";
            this.txtRealTime.ReadOnly = true;
            this.txtRealTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRealTime.Size = new System.Drawing.Size(867, 697);
            this.txtRealTime.TabIndex = 16;
            this.txtRealTime.WordWrap = false;
            // 
            // tabPageSendMessageLog
            // 
            this.tabPageSendMessageLog.Controls.Add(this.txtSendLog);
            this.tabPageSendMessageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageSendMessageLog.Name = "tabPageSendMessageLog";
            this.tabPageSendMessageLog.Size = new System.Drawing.Size(867, 697);
            this.tabPageSendMessageLog.TabIndex = 5;
            this.tabPageSendMessageLog.Text = "Messages Sent";
            this.tabPageSendMessageLog.UseVisualStyleBackColor = true;
            // 
            // txtSendLog
            // 
            this.txtSendLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSendLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSendLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSendLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendLog.Location = new System.Drawing.Point(0, 0);
            this.txtSendLog.Multiline = true;
            this.txtSendLog.Name = "txtSendLog";
            this.txtSendLog.ReadOnly = true;
            this.txtSendLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendLog.Size = new System.Drawing.Size(867, 697);
            this.txtSendLog.TabIndex = 16;
            this.txtSendLog.WordWrap = false;
            // 
            // tabPageReceiveMessageLog
            // 
            this.tabPageReceiveMessageLog.Controls.Add(this.txtReceiveLog);
            this.tabPageReceiveMessageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageReceiveMessageLog.Name = "tabPageReceiveMessageLog";
            this.tabPageReceiveMessageLog.Size = new System.Drawing.Size(867, 697);
            this.tabPageReceiveMessageLog.TabIndex = 6;
            this.tabPageReceiveMessageLog.Text = "Messages Received";
            this.tabPageReceiveMessageLog.UseVisualStyleBackColor = true;
            // 
            // txtReceiveLog
            // 
            this.txtReceiveLog.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtReceiveLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReceiveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiveLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveLog.Location = new System.Drawing.Point(0, 0);
            this.txtReceiveLog.Multiline = true;
            this.txtReceiveLog.Name = "txtReceiveLog";
            this.txtReceiveLog.ReadOnly = true;
            this.txtReceiveLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiveLog.Size = new System.Drawing.Size(867, 697);
            this.txtReceiveLog.TabIndex = 16;
            this.txtReceiveLog.WordWrap = false;
            // 
            // tabPageRawSendMessageLow
            // 
            this.tabPageRawSendMessageLow.Controls.Add(this.txtSendLogRaw);
            this.tabPageRawSendMessageLow.Location = new System.Drawing.Point(4, 22);
            this.tabPageRawSendMessageLow.Name = "tabPageRawSendMessageLow";
            this.tabPageRawSendMessageLow.Size = new System.Drawing.Size(867, 697);
            this.tabPageRawSendMessageLow.TabIndex = 7;
            this.tabPageRawSendMessageLow.Text = "Messages Sent (Raw)";
            this.tabPageRawSendMessageLow.UseVisualStyleBackColor = true;
            // 
            // txtSendLogRaw
            // 
            this.txtSendLogRaw.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtSendLogRaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSendLogRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSendLogRaw.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendLogRaw.Location = new System.Drawing.Point(0, 0);
            this.txtSendLogRaw.Multiline = true;
            this.txtSendLogRaw.Name = "txtSendLogRaw";
            this.txtSendLogRaw.ReadOnly = true;
            this.txtSendLogRaw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSendLogRaw.Size = new System.Drawing.Size(867, 697);
            this.txtSendLogRaw.TabIndex = 17;
            this.txtSendLogRaw.WordWrap = false;
            // 
            // tabPageRawReceiveMessageLow
            // 
            this.tabPageRawReceiveMessageLow.Controls.Add(this.txtReceiveLogRaw);
            this.tabPageRawReceiveMessageLow.Location = new System.Drawing.Point(4, 22);
            this.tabPageRawReceiveMessageLow.Name = "tabPageRawReceiveMessageLow";
            this.tabPageRawReceiveMessageLow.Size = new System.Drawing.Size(867, 697);
            this.tabPageRawReceiveMessageLow.TabIndex = 8;
            this.tabPageRawReceiveMessageLow.Text = "Messages Received (Raw)";
            this.tabPageRawReceiveMessageLow.UseVisualStyleBackColor = true;
            // 
            // txtReceiveLogRaw
            // 
            this.txtReceiveLogRaw.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtReceiveLogRaw.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReceiveLogRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiveLogRaw.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveLogRaw.Location = new System.Drawing.Point(0, 0);
            this.txtReceiveLogRaw.Multiline = true;
            this.txtReceiveLogRaw.Name = "txtReceiveLogRaw";
            this.txtReceiveLogRaw.ReadOnly = true;
            this.txtReceiveLogRaw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiveLogRaw.Size = new System.Drawing.Size(867, 697);
            this.txtReceiveLogRaw.TabIndex = 17;
            this.txtReceiveLogRaw.WordWrap = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmdSymbolInfoRequest);
            this.groupBox4.Controls.Add(this.txtSymbolInfo);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(3, 170);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(273, 76);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Security Definition Request";
            // 
            // cmdSymbolInfoRequest
            // 
            this.cmdSymbolInfoRequest.Location = new System.Drawing.Point(11, 45);
            this.cmdSymbolInfoRequest.Name = "cmdSymbolInfoRequest";
            this.cmdSymbolInfoRequest.Size = new System.Drawing.Size(256, 23);
            this.cmdSymbolInfoRequest.TabIndex = 1;
            this.cmdSymbolInfoRequest.Text = "Request Symbol Information";
            this.cmdSymbolInfoRequest.UseVisualStyleBackColor = true;
            this.cmdSymbolInfoRequest.Click += new System.EventHandler(this.CmdSymbolInfoRequest_Click);
            // 
            // txtSymbolInfo
            // 
            this.txtSymbolInfo.Location = new System.Drawing.Point(167, 19);
            this.txtSymbolInfo.Name = "txtSymbolInfo";
            this.txtSymbolInfo.Size = new System.Drawing.Size(100, 20);
            this.txtSymbolInfo.TabIndex = 0;
            this.txtSymbolInfo.Text = "AUDUSD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Symbol";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPageSettings);
            this.tabControl2.Controls.Add(this.tabPageData);
            this.tabControl2.Controls.Add(this.tabPageTrading);
            this.tabControl2.Controls.Add(this.tabPageHistoricalData);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(287, 638);
            this.tabControl2.TabIndex = 4;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.groupBox5);
            this.tabPageSettings.Controls.Add(this.groupBox1);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(279, 612);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Connection";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkFilterRealtime);
            this.groupBox5.Controls.Add(this.chkFilterHeartbeats);
            this.groupBox5.Controls.Add(this.chkDisplayRaw);
            this.groupBox5.Location = new System.Drawing.Point(3, 161);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(273, 91);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Options";
            // 
            // chkFilterRealtime
            // 
            this.chkFilterRealtime.AutoSize = true;
            this.chkFilterRealtime.Location = new System.Drawing.Point(8, 65);
            this.chkFilterRealtime.Name = "chkFilterRealtime";
            this.chkFilterRealtime.Size = new System.Drawing.Size(224, 17);
            this.chkFilterRealtime.TabIndex = 8;
            this.chkFilterRealtime.Text = "Exclude Realtime Data from Message Log";
            this.chkFilterRealtime.UseVisualStyleBackColor = true;
            // 
            // chkFilterHeartbeats
            // 
            this.chkFilterHeartbeats.AutoSize = true;
            this.chkFilterHeartbeats.Location = new System.Drawing.Point(8, 42);
            this.chkFilterHeartbeats.Name = "chkFilterHeartbeats";
            this.chkFilterHeartbeats.Size = new System.Drawing.Size(209, 17);
            this.chkFilterHeartbeats.TabIndex = 7;
            this.chkFilterHeartbeats.Text = "Exclude Heartbeats from Message Log";
            this.chkFilterHeartbeats.UseVisualStyleBackColor = true;
            // 
            // chkDisplayRaw
            // 
            this.chkDisplayRaw.AutoSize = true;
            this.chkDisplayRaw.Checked = true;
            this.chkDisplayRaw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplayRaw.Location = new System.Drawing.Point(8, 19);
            this.chkDisplayRaw.Name = "chkDisplayRaw";
            this.chkDisplayRaw.Size = new System.Drawing.Size(233, 17);
            this.chkDisplayRaw.TabIndex = 6;
            this.chkDisplayRaw.Text = "Display Raw Sent/Reveived Message Data";
            this.chkDisplayRaw.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.txtHistoricalSymbol);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.cmdRequestHistoricalData);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.dtpEndDate);
            this.groupBox3.Controls.Add(this.dtpStartDate);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.cmbInterval);
            this.groupBox3.Controls.Add(this.txtPasswordHistorical);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtUsernameHistorical);
            this.groupBox3.Controls.Add(this.txtPortHistorical);
            this.groupBox3.Controls.Add(this.txtHostHistorical);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 280);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Historical Data";
            // 
            // txtPasswordHistorical
            // 
            this.txtPasswordHistorical.Location = new System.Drawing.Point(167, 91);
            this.txtPasswordHistorical.Name = "txtPasswordHistorical";
            this.txtPasswordHistorical.PasswordChar = '*';
            this.txtPasswordHistorical.Size = new System.Drawing.Size(100, 20);
            this.txtPasswordHistorical.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Password";
            // 
            // txtUsernameHistorical
            // 
            this.txtUsernameHistorical.Location = new System.Drawing.Point(167, 67);
            this.txtUsernameHistorical.Name = "txtUsernameHistorical";
            this.txtUsernameHistorical.Size = new System.Drawing.Size(100, 20);
            this.txtUsernameHistorical.TabIndex = 2;
            // 
            // txtPortHistorical
            // 
            this.txtPortHistorical.Location = new System.Drawing.Point(167, 43);
            this.txtPortHistorical.Name = "txtPortHistorical";
            this.txtPortHistorical.Size = new System.Drawing.Size(100, 20);
            this.txtPortHistorical.TabIndex = 1;
            this.txtPortHistorical.Text = "11098";
            // 
            // txtHostHistorical
            // 
            this.txtHostHistorical.Location = new System.Drawing.Point(167, 19);
            this.txtHostHistorical.Name = "txtHostHistorical";
            this.txtHostHistorical.Size = new System.Drawing.Size(100, 20);
            this.txtHostHistorical.TabIndex = 0;
            this.txtHostHistorical.Text = "127.0.0.1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Username";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Port";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "IP Address";
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.groupBox6);
            this.tabPageData.Controls.Add(this.groupBox2);
            this.tabPageData.Controls.Add(this.groupBox4);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(279, 612);
            this.tabPageData.TabIndex = 1;
            this.tabPageData.Text = "Data & Symbols";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(287, 723);
            this.splitContainer1.SplitterDistance = 81;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabPageHistoricalData
            // 
            this.tabPageHistoricalData.Controls.Add(this.groupBox3);
            this.tabPageHistoricalData.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistoricalData.Name = "tabPageHistoricalData";
            this.tabPageHistoricalData.Size = new System.Drawing.Size(279, 612);
            this.tabPageHistoricalData.TabIndex = 2;
            this.tabPageHistoricalData.Text = "Historical Data";
            this.tabPageHistoricalData.UseVisualStyleBackColor = true;
            // 
            // tabPageTrading
            // 
            this.tabPageTrading.Location = new System.Drawing.Point(4, 22);
            this.tabPageTrading.Name = "tabPageTrading";
            this.tabPageTrading.Size = new System.Drawing.Size(279, 612);
            this.tabPageTrading.TabIndex = 3;
            this.tabPageTrading.Text = "Trading";
            this.tabPageTrading.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Location = new System.Drawing.Point(3, 88);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 76);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Realtime Market Depth Request";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(189, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Snapshot";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(100, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Unsubscribe";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(11, 45);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Subscribe";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(167, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "AUDUSD";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Symbol";
            // 
            // cmbInterval
            // 
            this.cmbInterval.FormattingEnabled = true;
            this.cmbInterval.Location = new System.Drawing.Point(130, 139);
            this.cmbInterval.Name = "cmbInterval";
            this.cmbInterval.Size = new System.Drawing.Size(137, 21);
            this.cmbInterval.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Interval";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(167, 164);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 6;
            this.dtpStartDate.Value = new System.DateTime(2018, 6, 1, 0, 0, 0, 0);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(167, 188);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(100, 20);
            this.dtpEndDate.TabIndex = 7;
            this.dtpEndDate.Value = new System.DateTime(2018, 6, 30, 0, 0, 0, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 20;
            this.label12.Text = "Start Date";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "End Date";
            // 
            // cmdRequestHistoricalData
            // 
            this.cmdRequestHistoricalData.Location = new System.Drawing.Point(8, 214);
            this.cmdRequestHistoricalData.Name = "cmdRequestHistoricalData";
            this.cmdRequestHistoricalData.Size = new System.Drawing.Size(259, 23);
            this.cmdRequestHistoricalData.TabIndex = 8;
            this.cmdRequestHistoricalData.Text = "Request Data";
            this.cmdRequestHistoricalData.UseVisualStyleBackColor = true;
            // 
            // txtHistoricalSymbol
            // 
            this.txtHistoricalSymbol.Location = new System.Drawing.Point(167, 115);
            this.txtHistoricalSymbol.Name = "txtHistoricalSymbol";
            this.txtHistoricalSymbol.Size = new System.Drawing.Size(100, 20);
            this.txtHistoricalSymbol.TabIndex = 4;
            this.txtHistoricalSymbol.Text = "AUDUSD";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 118);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Symbol";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(259, 23);
            this.button4.TabIndex = 24;
            this.button4.Text = "Break !!";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 723);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1020, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DTC DataClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageActivity.ResumeLayout(false);
            this.tabPageActivity.PerformLayout();
            this.tabPageErrors.ResumeLayout(false);
            this.tabPageErrors.PerformLayout();
            this.tabPageRealtimeData.ResumeLayout(false);
            this.tabPageRealtimeData.PerformLayout();
            this.tabPageSendMessageLog.ResumeLayout(false);
            this.tabPageSendMessageLog.PerformLayout();
            this.tabPageReceiveMessageLog.ResumeLayout(false);
            this.tabPageReceiveMessageLog.PerformLayout();
            this.tabPageRawSendMessageLow.ResumeLayout(false);
            this.tabPageRawSendMessageLow.PerformLayout();
            this.tabPageRawReceiveMessageLow.ResumeLayout(false);
            this.tabPageRawReceiveMessageLow.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageData.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPageHistoricalData.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private GroupBox groupBox1;
        private Button cmdConnDisconn;
        private TextBox txtUsername;
        private TextBox txtPort;
        private TextBox txtHost;
        private Label lblUsername;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private TabControl tabControl1;
        private TabPage tabPageErrors;
        private TextBox txtErrorLog;
        private TabPage tabPageActivity;
        private TabPage tabPageRealtimeData;
        private TextBox txtActivityLog;
        private GroupBox groupBox4;
        private Button cmdSymbolInfoRequest;
        private TextBox txtSymbolInfo;
        private Label label3;
        private TextBox txtRealTime;
        private TabPage tabPageSendMessageLog;
        private TextBox txtSendLog;
        private TabPage tabPageReceiveMessageLog;
        private TextBox txtReceiveLog;
        private Button cmdSnapshot;
        private Button cmdUnsubscribe;
        private Button cmdSubscribe;
        private TextBox txtSymbolRT;
        private Label label4;
        private TextBox txtPassword;
        private Label label5;
        private TabControl tabControl2;
        private TabPage tabPageSettings;
        private TabPage tabPageData;
        private SplitContainer splitContainer1;
        private GroupBox groupBox5;
        private GroupBox groupBox3;
        private TextBox txtPasswordHistorical;
        private Label label6;
        private TextBox txtUsernameHistorical;
        private TextBox txtPortHistorical;
        private TextBox txtHostHistorical;
        private Label label7;
        private Label label8;
        private Label label9;
        private CheckBox chkFilterHeartbeats;
        private CheckBox chkDisplayRaw;
        private TabPage tabPageRawSendMessageLow;
        private TextBox txtSendLogRaw;
        private TabPage tabPageRawReceiveMessageLow;
        private TextBox txtReceiveLogRaw;
        private CheckBox chkFilterRealtime;
        private TabPage tabPageHistoricalData;
        private TabPage tabPageTrading;
        private GroupBox groupBox6;
        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Label label10;
        private Button cmdRequestHistoricalData;
        private Label label13;
        private Label label12;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpStartDate;
        private Label label11;
        private ComboBox cmbInterval;
        private TextBox txtHistoricalSymbol;
        private Label label14;
        private Button button4;
    }
}

