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
            this.cmdConnDisconn = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.lblUsername);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 151);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // cmdConnDisconn
            // 
            this.cmdConnDisconn.Location = new System.Drawing.Point(8, 117);
            this.cmdConnDisconn.Name = "cmdConnDisconn";
            this.cmdConnDisconn.Size = new System.Drawing.Size(259, 23);
            this.cmdConnDisconn.TabIndex = 6;
            this.cmdConnDisconn.Text = "Connect";
            this.cmdConnDisconn.UseVisualStyleBackColor = true;
            this.cmdConnDisconn.Click += new System.EventHandler(this.CmdConnDisconn_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(167, 42);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
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
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(167, 92);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(167, 67);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(8, 70);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Username";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdSnapshot);
            this.groupBox2.Controls.Add(this.cmdUnsubscribe);
            this.groupBox2.Controls.Add(this.cmdSubscribe);
            this.groupBox2.Controls.Add(this.txtSymbolRT);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 265);
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
            this.groupBox4.Location = new System.Drawing.Point(3, 347);
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
            this.tabPageSettings.Controls.Add(this.groupBox4);
            this.tabPageSettings.Controls.Add(this.groupBox1);
            this.tabPageSettings.Controls.Add(this.groupBox2);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(279, 612);
            this.tabPageSettings.TabIndex = 0;
            this.tabPageSettings.Text = "Realtime Data";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkFilterRealtime);
            this.groupBox5.Controls.Add(this.chkFilterHeartbeats);
            this.groupBox5.Controls.Add(this.chkDisplayRaw);
            this.groupBox5.Location = new System.Drawing.Point(3, 163);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(273, 96);
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private SplitContainer splitContainer1;
        private GroupBox groupBox5;
        private CheckBox chkFilterHeartbeats;
        private CheckBox chkDisplayRaw;
        private TabPage tabPageRawSendMessageLow;
        private TextBox txtSendLogRaw;
        private TabPage tabPageRawReceiveMessageLow;
        private TextBox txtReceiveLogRaw;
        private CheckBox chkFilterRealtime;
    }
}

