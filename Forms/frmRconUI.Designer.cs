namespace RCONManager {
    partial class frmRconUI {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRconUI));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextNotifyOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.contextNotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnChangeMap = new System.Windows.Forms.Button();
            this.btnLoadCfg = new System.Windows.Forms.Button();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusIconStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelStatusRcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupPlayerCommands = new System.Windows.Forms.GroupBox();
            this.btnBan = new System.Windows.Forms.Button();
            this.btnKick = new System.Windows.Forms.Button();
            this.groupServerCommands = new System.Windows.Forms.GroupBox();
            this.btnRestart3 = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpenConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHotkeys = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripNotify.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.groupPlayerCommands.SuspendLayout();
            this.groupServerCommands.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStripNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStripNotify
            // 
            this.contextMenuStripNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contextNotifyOpen,
            this.contextNotifyExit});
            this.contextMenuStripNotify.Name = "contextMenuStripNotify";
            this.contextMenuStripNotify.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStripNotify.ShowImageMargin = false;
            this.contextMenuStripNotify.Size = new System.Drawing.Size(96, 48);
            // 
            // contextNotifyOpen
            // 
            this.contextNotifyOpen.Name = "contextNotifyOpen";
            this.contextNotifyOpen.Size = new System.Drawing.Size(95, 22);
            this.contextNotifyOpen.Text = "Öffnen";
            this.contextNotifyOpen.Click += new System.EventHandler(this.contextNotifyOpen_Click);
            // 
            // contextNotifyExit
            // 
            this.contextNotifyExit.Name = "contextNotifyExit";
            this.contextNotifyExit.Size = new System.Drawing.Size(95, 22);
            this.contextNotifyExit.Text = "Beenden";
            this.contextNotifyExit.Click += new System.EventHandler(this.contextNotifyClose_Click);
            // 
            // btnChangeMap
            // 
            this.btnChangeMap.Location = new System.Drawing.Point(6, 48);
            this.btnChangeMap.Name = "btnChangeMap";
            this.btnChangeMap.Size = new System.Drawing.Size(75, 23);
            this.btnChangeMap.TabIndex = 1;
            this.btnChangeMap.Text = "Change map";
            this.btnChangeMap.UseVisualStyleBackColor = true;
            this.btnChangeMap.Click += new System.EventHandler(this.btnMapchange_Click);
            // 
            // btnLoadCfg
            // 
            this.btnLoadCfg.Location = new System.Drawing.Point(6, 19);
            this.btnLoadCfg.Name = "btnLoadCfg";
            this.btnLoadCfg.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCfg.TabIndex = 2;
            this.btnLoadCfg.Text = "Load config";
            this.btnLoadCfg.UseVisualStyleBackColor = true;
            this.btnLoadCfg.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusIconStatus,
            this.statusLabelStatusRcon});
            this.statusStripMain.Location = new System.Drawing.Point(0, 116);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(302, 22);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 3;
            this.statusStripMain.Text = "statusStrip";
            // 
            // statusIconStatus
            // 
            this.statusIconStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.statusIconStatus.Name = "statusIconStatus";
            this.statusIconStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // statusLabelStatusRcon
            // 
            this.statusLabelStatusRcon.Name = "statusLabelStatusRcon";
            this.statusLabelStatusRcon.Size = new System.Drawing.Size(0, 17);
            // 
            // groupPlayerCommands
            // 
            this.groupPlayerCommands.Controls.Add(this.btnBan);
            this.groupPlayerCommands.Controls.Add(this.btnKick);
            this.groupPlayerCommands.Location = new System.Drawing.Point(12, 27);
            this.groupPlayerCommands.Name = "groupPlayerCommands";
            this.groupPlayerCommands.Size = new System.Drawing.Size(106, 78);
            this.groupPlayerCommands.TabIndex = 4;
            this.groupPlayerCommands.TabStop = false;
            this.groupPlayerCommands.Text = "Player commands";
            // 
            // btnBan
            // 
            this.btnBan.Location = new System.Drawing.Point(6, 48);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(94, 23);
            this.btnBan.TabIndex = 6;
            this.btnBan.Text = "Ban Players";
            this.btnBan.UseVisualStyleBackColor = true;
            // 
            // btnKick
            // 
            this.btnKick.Location = new System.Drawing.Point(6, 19);
            this.btnKick.Name = "btnKick";
            this.btnKick.Size = new System.Drawing.Size(94, 23);
            this.btnKick.TabIndex = 5;
            this.btnKick.Text = "Kick Players";
            this.btnKick.UseVisualStyleBackColor = true;
            this.btnKick.Click += new System.EventHandler(this.btnKick_Click);
            // 
            // groupServerCommands
            // 
            this.groupServerCommands.Controls.Add(this.btnRestart3);
            this.groupServerCommands.Controls.Add(this.btnLoadCfg);
            this.groupServerCommands.Controls.Add(this.btnChangeMap);
            this.groupServerCommands.Location = new System.Drawing.Point(124, 27);
            this.groupServerCommands.Name = "groupServerCommands";
            this.groupServerCommands.Size = new System.Drawing.Size(168, 78);
            this.groupServerCommands.TabIndex = 5;
            this.groupServerCommands.TabStop = false;
            this.groupServerCommands.Text = "Server Commands";
            // 
            // btnRestart3
            // 
            this.btnRestart3.Location = new System.Drawing.Point(87, 19);
            this.btnRestart3.Name = "btnRestart3";
            this.btnRestart3.Size = new System.Drawing.Size(75, 23);
            this.btnRestart3.TabIndex = 6;
            this.btnRestart3.Text = "3x Restart";
            this.btnRestart3.UseVisualStyleBackColor = true;
            this.btnRestart3.Click += new System.EventHandler(this.btnRestart3_Click);
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.Control;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuConnection,
            this.menuOptions,
            this.menuItemAbout});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripMain.Size = new System.Drawing.Size(302, 24);
            this.menuStripMain.TabIndex = 6;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpenConfig,
            this.menuItemSaveConfig,
            this.menuFileSeparator1,
            this.menuItemExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Padding = new System.Windows.Forms.Padding(0);
            this.menuFile.Size = new System.Drawing.Size(38, 20);
            this.menuFile.Text = "Datei";
            this.menuFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuItemOpenConfig
            // 
            this.menuItemOpenConfig.Image = global::RCONManager.Properties.Resources.import;
            this.menuItemOpenConfig.Name = "menuItemOpenConfig";
            this.menuItemOpenConfig.Size = new System.Drawing.Size(164, 22);
            this.menuItemOpenConfig.Text = "Config öffnen";
            // 
            // menuItemSaveConfig
            // 
            this.menuItemSaveConfig.Image = global::RCONManager.Properties.Resources.export;
            this.menuItemSaveConfig.Name = "menuItemSaveConfig";
            this.menuItemSaveConfig.Size = new System.Drawing.Size(164, 22);
            this.menuItemSaveConfig.Text = "Config speichern";
            // 
            // menuFileSeparator1
            // 
            this.menuFileSeparator1.Name = "menuFileSeparator1";
            this.menuFileSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Image = global::RCONManager.Properties.Resources.exit;
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(164, 22);
            this.menuItemExit.Text = "Beenden";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuConnection
            // 
            this.menuConnection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemConnect,
            this.menuItemDisconnect});
            this.menuConnection.Name = "menuConnection";
            this.menuConnection.Padding = new System.Windows.Forms.Padding(0);
            this.menuConnection.Size = new System.Drawing.Size(73, 20);
            this.menuConnection.Text = "Verbindung";
            // 
            // menuItemConnect
            // 
            this.menuItemConnect.Image = global::RCONManager.Properties.Resources.connect;
            this.menuItemConnect.Name = "menuItemConnect";
            this.menuItemConnect.Size = new System.Drawing.Size(128, 22);
            this.menuItemConnect.Text = "Verbinden";
            this.menuItemConnect.Click += new System.EventHandler(this.menuItemConnect_Click);
            // 
            // menuItemDisconnect
            // 
            this.menuItemDisconnect.Image = global::RCONManager.Properties.Resources.disconnect;
            this.menuItemDisconnect.Name = "menuItemDisconnect";
            this.menuItemDisconnect.Size = new System.Drawing.Size(128, 22);
            this.menuItemDisconnect.Text = "Trennen";
            this.menuItemDisconnect.Click += new System.EventHandler(this.menuItemDisconnect_Click);
            // 
            // menuOptions
            // 
            this.menuOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHotkeys,
            this.menuItemSettings});
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Padding = new System.Windows.Forms.Padding(0);
            this.menuOptions.Size = new System.Drawing.Size(61, 20);
            this.menuOptions.Text = "Optionen";
            // 
            // menuItemHotkeys
            // 
            this.menuItemHotkeys.Image = global::RCONManager.Properties.Resources.keyboard;
            this.menuItemHotkeys.Name = "menuItemHotkeys";
            this.menuItemHotkeys.Size = new System.Drawing.Size(145, 22);
            this.menuItemHotkeys.Text = "Hotkeys";
            this.menuItemHotkeys.Click += new System.EventHandler(this.menuItemHotkeys_Click);
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Image = global::RCONManager.Properties.Resources.settings;
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(145, 22);
            this.menuItemSettings.Text = "Einstellungen";
            this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Padding = new System.Windows.Forms.Padding(0);
            this.menuItemAbout.Size = new System.Drawing.Size(36, 20);
            this.menuItemAbout.Text = "Über";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // frmRconUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 138);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.groupServerCommands);
            this.Controls.Add(this.groupPlayerCommands);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmRconUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClitCommando Rcon UI";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RconUI_FormClosed);
            this.Load += new System.EventHandler(this.RconUI_Load);
            this.Resize += new System.EventHandler(this.RconUI_Resize);
            this.contextMenuStripNotify.ResumeLayout(false);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.groupPlayerCommands.ResumeLayout(false);
            this.groupServerCommands.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btnChangeMap;
        private System.Windows.Forms.Button btnLoadCfg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotify;
        private System.Windows.Forms.ToolStripMenuItem contextNotifyOpen;
        private System.Windows.Forms.ToolStripMenuItem contextNotifyExit;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusIconStatus;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelStatusRcon;
        private System.Windows.Forms.GroupBox groupPlayerCommands;
        private System.Windows.Forms.Button btnBan;
        private System.Windows.Forms.Button btnKick;
        private System.Windows.Forms.GroupBox groupServerCommands;
        private System.Windows.Forms.Button btnRestart3;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemOpenConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveConfig;
        private System.Windows.Forms.ToolStripSeparator menuFileSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem menuConnection;
        private System.Windows.Forms.ToolStripMenuItem menuItemConnect;
        private System.Windows.Forms.ToolStripMenuItem menuItemDisconnect;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemHotkeys;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

