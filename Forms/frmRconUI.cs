using RCONManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RCONManager {
    public partial class frmRconUI : Form {

        //*****************************
        // Variables
        //*****************************
        private RconConnection rcon = RconConnection.Instance;
        private Language langMan = Language.Instance;
        private HotKeyClass HK = new HotKeyClass();

        //*****************************
        // Initialization
        //*****************************
        public frmRconUI() {
            InitializeComponent();

        }

        private void RconUI_Load(object sender, EventArgs e) {
            this.Text = Application.ProductName;
            notifyIcon.Text = Application.ProductName;
            
            // assign events
            langMan.SwitchLangEvent += new Language.VoidHandler(SwitchLanguage);
            rcon.OnlineStateEvent += new RconConnection.VoidHandler(UpdateUIControls);
            rcon.ErrorEvent += new RconConnection.StringHandler(RconError);

            // configure hotkey
            HK.OwnerForm = this;
            HK.HotKeyPressed += new HotKeyClass.HotKeyPressedEventHandler(HK_HotKeyPressed);

            // start to tray
            if (Settings.Default.StartMinimized) {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }

            SwitchLanguage();
            AssignHotKeys();
            rcon.Connect();
        }

        private void HK_HotKeyPressed(string ID) {
            if (ID == "LoadCFG") {
                MessageBox.Show(Settings.Default.Hkey_LoadCfg_Config.name);
            }
        }

        private void AssignHotKeys() {
            if (Settings.Default.Hkey_LoadCfg.key != Keys.None) {
                HK.AddHotKey(Settings.Default.Hkey_LoadCfg.key, Settings.Default.Hkey_LoadCfg.modKey, "LoadCFG");
            }
            if (Settings.Default.Hkey_Restart.key != Keys.None) {
                HK.AddHotKey(Settings.Default.Hkey_Restart.key, Settings.Default.Hkey_Restart.modKey, "Restart");
            }
        }


        

        //*****************************
        // Methods
        //*****************************
        private void HideWindow() {
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon.Visible = true;
        }

        private void RestoreWindow() {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;
        }

        private void RconError(string str) {
            Invoke(new MethodInvoker(delegate {
                UpdateStatusError(str);
            }));
        }

        private void UpdateStatusError(string strError) {
            statusLabelStatusRcon.ForeColor = Color.Red;
            statusLabelStatusRcon.Text = langMan.GetString("Text_Error") + ": " + strError;
        }

        private void UpdateUIControls() {
            if (this.InvokeRequired) {
                MethodInvoker del = delegate { UpdateUIControls(); };
                this.Invoke(del);
                return;
            }

            statusLabelStatusRcon.ForeColor = Color.Black;

            if (rcon.GetState() == RconConnection.OnlineState.Connected) {
                groupPlayerCommands.Enabled = true;
                groupServerCommands.Enabled = true;

                notifyIcon.Icon = Resources.IconConnected;
                statusIconStatus.Image = Resources.green;
                statusLabelStatusRcon.Text = langMan.GetString("StatusRconLbl_Connected") + " " + rcon.connectedIP;
            } else {
                groupPlayerCommands.Enabled = false;
                groupServerCommands.Enabled = false;

                if (String.IsNullOrEmpty(Settings.Default.RconIP)) {
                    notifyIcon.Icon = Resources.IconDisconnected;
                    statusIconStatus.Image = null;
                    statusLabelStatusRcon.Text = langMan.GetString("StatusRconLbl_NotConfigured");
                } else if (rcon.GetState() == RconConnection.OnlineState.Connecting) {
                    notifyIcon.Icon = Resources.IconConnecting;
                    statusIconStatus.Image = Resources.orange;
                    statusLabelStatusRcon.Text = langMan.GetString("StatusRconLbl_Connecting");
                } else if (rcon.GetState() == RconConnection.OnlineState.Disconnected) {
                    notifyIcon.Icon = Resources.IconDisconnected;
                    statusIconStatus.Image = Resources.red;
                    statusLabelStatusRcon.Text = langMan.GetString("StatusRconLbl_Disconnected");
                }
            }
        }

        private void SwitchLanguage() {

            menuFile.Text           = langMan.GetString("MenuFile");
            menuItemOpenConfig.Text = langMan.GetString("MenuFileOpenConfig");
            menuItemSaveConfig.Text = langMan.GetString("MenuFileSaveConfig");
            menuItemExit.Text       = langMan.GetString("Text_Exit");
            menuOptions.Text        = langMan.GetString("menuOptions");
            menuItemHotkeys.Text    = langMan.GetString("menuOptionsHotkeys");
            menuItemSettings.Text   = langMan.GetString("menuOptionsSettings");
            menuItemAbout.Text      = langMan.GetString("menuAbout");

            contextNotifyOpen.Text = langMan.GetString("Text_Open");
            contextNotifyExit.Text = langMan.GetString("Text_Exit");

            UpdateUIControls();
        }

        //*****************************
        // Event receivers
        //*****************************
        private void RconUI_Resize(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                HideWindow();
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e) {
            RestoreWindow();
        }

        private void contextNotifyClose_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void contextNotifyOpen_Click(object sender, EventArgs e) {
            RestoreWindow();
        }

        private void RconUI_FormClosed(object sender, FormClosedEventArgs e) {
            Settings.Default.Save();
        }

        private void menuItemSettings_Click(object sender, EventArgs e) {
            frmSettings formSettings = new frmSettings();
            formSettings.ShowDialog();
        }

        private void menuItemHotkeys_Click(object sender, EventArgs e) {
            HK.RemoveAllHotKeys();
            frmHotKeys formHotKeys = new frmHotKeys();
            formHotKeys.ShowDialog();
            AssignHotKeys();
        }

        private void menuItemExit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void menuItemConnect_Click(object sender, EventArgs e) {
            rcon.Connect();
        }

        private void menuItemDisconnect_Click(object sender, EventArgs e) {
            rcon.Disconnect();
        }

        private void btnMapchange_Click(object sender, EventArgs e) {

        }

        private void btnConfig_Click(object sender, EventArgs e) {
            frmRconLoadConfig formLoadConfig = new frmRconLoadConfig();
            if (formLoadConfig.ShowDialog() == DialogResult.OK) {
                RconTools.LoadConfigFile(rcon, formLoadConfig.ReturnValue);
            }
        }

        private void btnKick_Click(object sender, EventArgs e) {
            frmRconKick formKickPlayers = new frmRconKick() { Owner = this };
            formKickPlayers.Show();
        }


    }
}
