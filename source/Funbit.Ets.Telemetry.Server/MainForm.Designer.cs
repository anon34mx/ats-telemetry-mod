namespace Funbit.Ets.Telemetry.Server
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ipAddressLabel = new System.Windows.Forms.Label();
            this.interfacesDropDown = new System.Windows.Forms.ComboBox();
            this.networkInterfaceTitleLabel = new System.Windows.Forms.Label();
            this.serverIpTitleLabel = new System.Windows.Forms.Label();
            this.appUrlLabel = new System.Windows.Forms.LinkLabel();
            this.appUrlTitleLabel = new System.Windows.Forms.Label();
            this.apiUrlLabel = new System.Windows.Forms.LinkLabel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.apiEndpointUrlTitleLabel = new System.Windows.Forms.Label();
            this.statusTitleLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.broadcastTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.check_saveToDb = new System.Windows.Forms.CheckBox();
            this.lbl_db_status = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DriverId = new System.Windows.Forms.TextBox();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.com_status = new System.Windows.Forms.Label();
            this.txt_serialOutput = new System.Windows.Forms.TextBox();
            this.btn_openSerial = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_serialPorts = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipTitle = "ETS2 Telemetry Server is running...";
            this.trayIcon.ContextMenuStrip = this.contextMenuStrip;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "ETS2 Telemetry Server is running...";
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // statusUpdateTimer
            // 
            this.statusUpdateTimer.Interval = 1000;
            this.statusUpdateTimer.Tick += new System.EventHandler(this.statusUpdateTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.ipAddressLabel);
            this.groupBox1.Controls.Add(this.interfacesDropDown);
            this.groupBox1.Controls.Add(this.networkInterfaceTitleLabel);
            this.groupBox1.Controls.Add(this.serverIpTitleLabel);
            this.groupBox1.Controls.Add(this.appUrlLabel);
            this.groupBox1.Controls.Add(this.appUrlTitleLabel);
            this.groupBox1.Controls.Add(this.apiUrlLabel);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Controls.Add(this.apiEndpointUrlTitleLabel);
            this.groupBox1.Controls.Add(this.statusTitleLabel);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 272);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server status";
            // 
            // ipAddressLabel
            // 
            this.ipAddressLabel.AutoSize = true;
            this.ipAddressLabel.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipAddressLabel.ForeColor = System.Drawing.Color.Purple;
            this.ipAddressLabel.Location = new System.Drawing.Point(139, 131);
            this.ipAddressLabel.Name = "ipAddressLabel";
            this.ipAddressLabel.Size = new System.Drawing.Size(95, 17);
            this.ipAddressLabel.TabIndex = 21;
            this.ipAddressLabel.Text = "111.222.333.444";
            this.toolTip.SetToolTip(this.ipAddressLabel, "Use this IP address for mobile application (Android)");
            // 
            // interfacesDropDown
            // 
            this.interfacesDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interfacesDropDown.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interfacesDropDown.FormattingEnabled = true;
            this.interfacesDropDown.Location = new System.Drawing.Point(144, 91);
            this.interfacesDropDown.Name = "interfacesDropDown";
            this.interfacesDropDown.Size = new System.Drawing.Size(369, 25);
            this.interfacesDropDown.TabIndex = 20;
            this.interfacesDropDown.TabStop = false;
            this.interfacesDropDown.SelectedIndexChanged += new System.EventHandler(this.interfaceDropDown_SelectedIndexChanged);
            // 
            // networkInterfaceTitleLabel
            // 
            this.networkInterfaceTitleLabel.AutoSize = true;
            this.networkInterfaceTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.networkInterfaceTitleLabel.Location = new System.Drawing.Point(18, 94);
            this.networkInterfaceTitleLabel.Name = "networkInterfaceTitleLabel";
            this.networkInterfaceTitleLabel.Size = new System.Drawing.Size(120, 17);
            this.networkInterfaceTitleLabel.TabIndex = 19;
            this.networkInterfaceTitleLabel.Text = "Network Interfaces:";
            // 
            // serverIpTitleLabel
            // 
            this.serverIpTitleLabel.AutoSize = true;
            this.serverIpTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverIpTitleLabel.Location = new System.Drawing.Point(76, 131);
            this.serverIpTitleLabel.Name = "serverIpTitleLabel";
            this.serverIpTitleLabel.Size = new System.Drawing.Size(62, 17);
            this.serverIpTitleLabel.TabIndex = 17;
            this.serverIpTitleLabel.Text = "Server IP:";
            // 
            // appUrlLabel
            // 
            this.appUrlLabel.AutoSize = true;
            this.appUrlLabel.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appUrlLabel.Location = new System.Drawing.Point(140, 163);
            this.appUrlLabel.Name = "appUrlLabel";
            this.appUrlLabel.Size = new System.Drawing.Size(72, 17);
            this.appUrlLabel.TabIndex = 16;
            this.appUrlLabel.TabStop = true;
            this.appUrlLabel.Text = "appUrlLabel";
            this.toolTip.SetToolTip(this.appUrlLabel, "Use this URL to view HTML5 mobile dashboard in desktop or mobile browsers (click " +
        "to open)");
            this.appUrlLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.appUrlLabel_LinkClicked);
            // 
            // appUrlTitleLabel
            // 
            this.appUrlTitleLabel.AutoSize = true;
            this.appUrlTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appUrlTitleLabel.Location = new System.Drawing.Point(31, 163);
            this.appUrlTitleLabel.Name = "appUrlTitleLabel";
            this.appUrlTitleLabel.Size = new System.Drawing.Size(107, 17);
            this.appUrlTitleLabel.TabIndex = 15;
            this.appUrlTitleLabel.Text = "HTML5 App URL:";
            // 
            // apiUrlLabel
            // 
            this.apiUrlLabel.AutoSize = true;
            this.apiUrlLabel.Font = new System.Drawing.Font("Segoe UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiUrlLabel.Location = new System.Drawing.Point(139, 194);
            this.apiUrlLabel.Name = "apiUrlLabel";
            this.apiUrlLabel.Size = new System.Drawing.Size(68, 17);
            this.apiUrlLabel.TabIndex = 14;
            this.apiUrlLabel.TabStop = true;
            this.apiUrlLabel.Text = "apiUrlLabel";
            this.toolTip.SetToolTip(this.apiUrlLabel, "Use this URL to develop your own applications based on the REST API (click to ope" +
        "n)");
            this.apiUrlLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.apiUrlLabel_LinkClicked);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.statusLabel.Location = new System.Drawing.Point(141, 41);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(69, 17);
            this.statusLabel.TabIndex = 13;
            this.statusLabel.Text = "Checking...";
            // 
            // apiEndpointUrlTitleLabel
            // 
            this.apiEndpointUrlTitleLabel.AutoSize = true;
            this.apiEndpointUrlTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apiEndpointUrlTitleLabel.Location = new System.Drawing.Point(21, 194);
            this.apiEndpointUrlTitleLabel.Name = "apiEndpointUrlTitleLabel";
            this.apiEndpointUrlTitleLabel.Size = new System.Drawing.Size(116, 17);
            this.apiEndpointUrlTitleLabel.TabIndex = 12;
            this.apiEndpointUrlTitleLabel.Text = "Telemetry API URL:";
            // 
            // statusTitleLabel
            // 
            this.statusTitleLabel.AutoSize = true;
            this.statusTitleLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTitleLabel.Location = new System.Drawing.Point(92, 41);
            this.statusTitleLabel.Name = "statusTitleLabel";
            this.statusTitleLabel.Size = new System.Drawing.Size(46, 17);
            this.statusTitleLabel.TabIndex = 11;
            this.statusTitleLabel.Text = "Status:";
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 250;
            this.toolTip.AutoPopDelay = 6000;
            this.toolTip.InitialDelay = 250;
            this.toolTip.ReshowDelay = 50;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // broadcastTimer
            // 
            this.broadcastTimer.Interval = 1000;
            this.broadcastTimer.Tick += new System.EventHandler(this.broadcastTimer_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenu,
            this.helpToolStripMenu,
            this.dBSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(548, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverToolStripMenu
            // 
            this.serverToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uninstallToolStripMenuItem});
            this.serverToolStripMenu.Name = "serverToolStripMenu";
            this.serverToolStripMenu.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenu.Text = "Server";
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // helpToolStripMenu
            // 
            this.helpToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.donateToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenu.Name = "helpToolStripMenu";
            this.helpToolStripMenu.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenu.Text = "Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Visible = false;
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // dBSettingsToolStripMenuItem
            // 
            this.dBSettingsToolStripMenuItem.Name = "dBSettingsToolStripMenuItem";
            this.dBSettingsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.dBSettingsToolStripMenuItem.Text = "DB settings";
            this.dBSettingsToolStripMenuItem.Click += new System.EventHandler(this.dBSettingsToolStripMenuItem_Click);
            // 
            // check_saveToDb
            // 
            this.check_saveToDb.AutoSize = true;
            this.check_saveToDb.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.check_saveToDb.Checked = true;
            this.check_saveToDb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_saveToDb.Location = new System.Drawing.Point(78, 26);
            this.check_saveToDb.Name = "check_saveToDb";
            this.check_saveToDb.Size = new System.Drawing.Size(81, 17);
            this.check_saveToDb.TabIndex = 23;
            this.check_saveToDb.Text = "Save to DB";
            this.check_saveToDb.UseVisualStyleBackColor = true;
            // 
            // lbl_db_status
            // 
            this.lbl_db_status.AutoSize = true;
            this.lbl_db_status.ForeColor = System.Drawing.Color.Red;
            this.lbl_db_status.Location = new System.Drawing.Point(322, 30);
            this.lbl_db_status.Name = "lbl_db_status";
            this.lbl_db_status.Size = new System.Drawing.Size(71, 13);
            this.lbl_db_status.TabIndex = 22;
            this.lbl_db_status.Text = "DB_STATUS";
            this.lbl_db_status.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Driver ID:";
            // 
            // txt_DriverId
            // 
            this.txt_DriverId.Cursor = System.Windows.Forms.Cursors.Default;
            this.txt_DriverId.Location = new System.Drawing.Point(144, 52);
            this.txt_DriverId.Name = "txt_DriverId";
            this.txt_DriverId.Size = new System.Drawing.Size(185, 20);
            this.txt_DriverId.TabIndex = 0;
            this.txt_DriverId.TextChanged += new System.EventHandler(this.txt_DriverId_TextChanged);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Funbit.Ets.Telemetry.Server.Properties.Resources.CloseIcon;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.check_saveToDb);
            this.groupBox3.Controls.Add(this.lbl_db_status);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txt_DriverId);
            this.groupBox3.Location = new System.Drawing.Point(12, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(524, 86);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save to DB";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.com_status);
            this.groupBox2.Controls.Add(this.txt_serialOutput);
            this.groupBox2.Controls.Add(this.btn_openSerial);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmb_serialPorts);
            this.groupBox2.Location = new System.Drawing.Point(12, 358);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial to keyboard";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(325, 68);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(98, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output";
            // 
            // com_status
            // 
            this.com_status.AutoSize = true;
            this.com_status.Location = new System.Drawing.Point(352, 22);
            this.com_status.Name = "com_status";
            this.com_status.Size = new System.Drawing.Size(35, 13);
            this.com_status.TabIndex = 4;
            this.com_status.Text = "label3";
            // 
            // txt_serialOutput
            // 
            this.txt_serialOutput.Location = new System.Drawing.Point(144, 42);
            this.txt_serialOutput.Name = "txt_serialOutput";
            this.txt_serialOutput.Size = new System.Drawing.Size(369, 20);
            this.txt_serialOutput.TabIndex = 3;
            // 
            // btn_openSerial
            // 
            this.btn_openSerial.Location = new System.Drawing.Point(271, 17);
            this.btn_openSerial.Name = "btn_openSerial";
            this.btn_openSerial.Size = new System.Drawing.Size(75, 23);
            this.btn_openSerial.TabIndex = 2;
            this.btn_openSerial.Text = "Open";
            this.btn_openSerial.UseVisualStyleBackColor = true;
            this.btn_openSerial.Click += new System.EventHandler(this.btn_openSerial_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Serial Port";
            // 
            // cmb_serialPorts
            // 
            this.cmb_serialPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_serialPorts.FormattingEnabled = true;
            this.cmb_serialPorts.Location = new System.Drawing.Point(144, 19);
            this.cmb_serialPorts.Name = "cmb_serialPorts";
            this.cmb_serialPorts.Size = new System.Drawing.Size(121, 21);
            this.cmb_serialPorts.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(226, 461);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(51, 24);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Start";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(325, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 33);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 33);
            this.button2.TabIndex = 23;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 497);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ETS2/ATS Telemetry Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.Timer statusUpdateTimer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label serverIpTitleLabel;
        private System.Windows.Forms.LinkLabel appUrlLabel;
        private System.Windows.Forms.Label appUrlTitleLabel;
        private System.Windows.Forms.LinkLabel apiUrlLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label apiEndpointUrlTitleLabel;
        private System.Windows.Forms.Label statusTitleLabel;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.ComboBox interfacesDropDown;
        private System.Windows.Forms.Label networkInterfaceTitleLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer broadcastTimer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lbl_db_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DriverId;
        private System.Windows.Forms.CheckBox check_saveToDb;
        private System.Windows.Forms.ToolStripMenuItem dBSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_serialPorts;
        private System.Windows.Forms.Button btn_openSerial;
        private System.Windows.Forms.TextBox txt_serialOutput;
        private System.Windows.Forms.Label com_status;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

