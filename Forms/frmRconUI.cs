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

        //*************************************************
        // Variables
        //*************************************************
        private RconConnection rcon = RconConnection.Instance;
        private Language langMan = Language.Instance;
        private HotKeyClass HK = new HotKeyClass();

        //*************************************************
        // Initialization
        //*************************************************
        public frmRconUI() {
            InitializeComponent();
            LoadLanguage();
        }

        private void RconUI_Load(object sender, EventArgs e) {
            this.Text = Application.ProductName;
            notifyIcon.Text = Application.ProductName;
            
            // assign events
            langMan.SwitchLangEvent += new Language.VoidHandler(LoadLanguage);
            rcon.OnlineStateEvent   += new RconConnection.VoidHandler(UpdateUIControls);
            rcon.ErrorEvent         += new RconConnection.StringHandler(RconError);

            // configure hotkey
            HK.OwnerForm = this;
            HK.HotKeyPressed += new HotKeyClass.HotKeyPressedEventHandler(HK_HotKeyPressed);

            // start to tray
            if (Settings.Default.StartMinimized) {
                this.WindowState   = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                notifyIcon.Visible = true;
            }

            AssignHotKeys();
            if (Settings.Default.Autoconnect) rcon.Connect();
        }

        private void HK_HotKeyPressed(string ID) {
            if (rcon.GetState() == RconConnection.State.Connected) {
                if (ID == "LoadCFG") {
                    RconTools.LoadConfigFile(rcon, Settings.Default.Hkey_LoadCfg_Config);
                } else if (ID == "Restart") {
                    Restart3WithException();
                }
            }
        }

        private void AssignHotKeys() {
            if (Settings.Default.Hkey_LoadCfg != null && Settings.Default.Hkey_LoadCfg.key != Keys.None) {
                HK.AddHotKey(Settings.Default.Hkey_LoadCfg.key, Settings.Default.Hkey_LoadCfg.modKey, "LoadCFG");
            }
            if (Settings.Default.Hkey_Restart != null && Settings.Default.Hkey_Restart.key != Keys.None) {
                HK.AddHotKey(Settings.Default.Hkey_Restart.key, Settings.Default.Hkey_Restart.modKey, "Restart");
            }
        }

        //*************************************************
        // Methods
        //*************************************************
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

        private void Restart3WithException() {
            try {
                RconTools.Restart3(rcon);
            } catch {
                UpdateStatusError(langMan.GetString("Rcon_WrongAnswer"));
            }
        }

        private void UpdateStatusError(string strError, bool reset = false) {
            statusIconStatus.Image          = Resources.red;
            statusLabelStatusRcon.ForeColor = Color.Red;
            statusLabelStatusRcon.Text      = String.Format(langMan.GetString("Error_Statusbar"), strError);
            if (reset) {
                Thread threadResetError = new Thread(delegate() { ResetStatusError(); });
                threadResetError.Start();
            }
        }

        private void ResetStatusError() {
            Thread.Sleep(GlobalConstants.ERROR_RESET_TIME);
            UpdateUIControls();
        }

        private void UpdateUIControls() {
            if (this.InvokeRequired) {
                MethodInvoker del = delegate { UpdateUIControls(); };
                this.Invoke(del);
                return;
            }

            statusLabelStatusRcon.ForeColor = Color.Black;

            if (rcon.GetState() == RconConnection.State.Connected) {
                groupPlayerCommands.Enabled = true;
                groupServerCommands.Enabled = true;

                notifyIcon.Icon = Resources.IconConnected;
                statusIconStatus.Image = Resources.green;
                statusLabelStatusRcon.Text = String.Format(langMan.GetString("StatusRconLbl_Connected"), rcon.connectedIP);
            } else {

                groupPlayerCommands.Enabled = false;
                groupServerCommands.Enabled = false;

                if (String.IsNullOrEmpty(Settings.Default.RconIP)) {

                    notifyIcon.Icon            = Resources.IconDisconnected;
                    statusIconStatus.Image     = null;
                    statusLabelStatusRcon.Text = langMan.GetString("StatusRconLbl_NotConfigured");

                } else if (rcon.GetState() == RconConnection.State.Connecting) {

                    notifyIcon.Icon            = Resources.IconConnecting;
                    statusIconStatus.Image     = Resources.orange;
                    statusLabelStatusRcon.Text = langMan.GetString("StatusRconLbl_Connecting");

                } else if (rcon.GetState() == RconConnection.State.Disconnected) {

                    notifyIcon.Icon            = Resources.IconDisconnected;
                    statusIconStatus.Image     = Resources.red;
                    statusLabelStatusRcon.Text = langMan.GetString("StatusRconLbl_Disconnected");
                }
            }
        }

        private void LoadLanguage() {
            this.Text                = langMan.GetString("Main_FormTitle");

            menuFile.Text            = langMan.GetString("Main_MenuFile");
            menuItemOpenConfig.Text  = langMan.GetString("Main_MenuFile_OpenConfig");
            menuItemSaveConfig.Text  = langMan.GetString("Main_MenuFile_SaveConfig");
            menuItemExit.Text        = langMan.GetString("Main_MenuFile_Exit");
            menuOptions.Text         = langMan.GetString("Main_MenuOptions");
            menuItemHotkeys.Text     = langMan.GetString("Main_MenuOptions_Hotkeys");
            menuItemSettings.Text    = langMan.GetString("Main_MenuOptions_Settings");
            menuItemAbout.Text       = langMan.GetString("Main_MenuAbout");

            contextNotifyOpen.Text   = langMan.GetString("Text_Open");
            contextNotifyExit.Text   = langMan.GetString("Text_Exit");

            btnRestart3.Text  = langMan.GetString("Main_Button_Restart3");
            btnKick.Text      = langMan.GetString("Main_Button_KickPlayers");
            btnBan.Text       = langMan.GetString("Main_Button_BanPlayers");
            btnChangeMap.Text = langMan.GetString("Main_Button_ChangeMap");
            btnLoadCfg.Text   = langMan.GetString("Main_Button_LoadCfg");

            groupPlayerCommands.Text = langMan.GetString("Main_Group_PlayerCommands");
            groupServerCommands.Text = langMan.GetString("Main_Group_ServerCommands");

            UpdateUIControls();
        }

        //*************************************************
        // Event receivers
        //*************************************************
        
        // Form resized or minimized/maximized
        private void RconUI_Resize(object sender, EventArgs e) {
            if (WindowState == FormWindowState.Minimized) {
                HideWindow();
            }
        }

        // Notify icon
        private void notifyIcon_DoubleClick(object sender, EventArgs e) {
            RestoreWindow();
        }

        // Notify Conext Open
        private void contextNotifyOpen_Click(object sender, EventArgs e) {
            RestoreWindow();
        }

        // Notify Conext Close
        private void contextNotifyClose_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        // Menu Exit
        private void menuItemExit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        // Menu Connect
        private void menuItemConnect_Click(object sender, EventArgs e) {
            rcon.Connect();
        }

        // Menu Disconnect
        private void menuItemDisconnect_Click(object sender, EventArgs e) {
            rcon.Disconnect();
        }

        // Menu Hotkeys
        private void menuItemHotkeys_Click(object sender, EventArgs e) {
            HK.RemoveAllHotKeys();
            frmHotKeys formHotKeys = new frmHotKeys();
            formHotKeys.ShowDialog();
            AssignHotKeys();
        }

        // Menu Settings
        private void menuItemSettings_Click(object sender, EventArgs e) {
            frmSettings formSettings = new frmSettings();
            formSettings.ShowDialog();
        }

        // Button Kick Players
        private void btnKick_Click(object sender, EventArgs e) {
            frmRconKick formKickPlayers     = new frmRconKick() { Owner = this };
            formKickPlayers.ExceptionEvent += new frmRconKick.StringBool(UpdateStatusError);
            formKickPlayers.Show();
        }

        // Button Change map
        private void btnMapchange_Click(object sender, EventArgs e) {
            frmRconChangeMap formChangeMap = new frmRconChangeMap();
            formChangeMap.ExceptionEvent  += new frmRconChangeMap.StringBool(UpdateStatusError);
            if (formChangeMap.ShowDialog() == DialogResult.OK) {
                RconTools.ChangeMap(rcon, formChangeMap.ReturnValue);
            }
        }

        // Button Load Config
        private void btnConfig_Click(object sender, EventArgs e) {
            frmRconLoadConfig formLoadConfig = new frmRconLoadConfig();
            if (formLoadConfig.ShowDialog() == DialogResult.OK) {
                RconTools.LoadConfigFile(rcon, formLoadConfig.ReturnValue);
            }
        }

        // Button Restart 3x
        private void btnRestart3_Click(object sender, EventArgs e) {
            Restart3WithException();
        }

        // Form Closed
        private void RconUI_FormClosed(object sender, FormClosedEventArgs e) {
            Settings.Default.Save();
            Environment.Exit(0); // if there is a thread running
        }
    }
}
