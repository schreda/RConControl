﻿using RConControl.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RConControl.Forms {
    public partial class frmRconUI : Form {

        //*************************************************
        // Variables
        //*************************************************
        private SourceRconConnection rcon = SourceRconConnection.Instance;
        private Language mLangMan         = Language.Instance;
        private HotKeyClass HK            = new HotKeyClass();

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
            mLangMan.SwitchLangEvent += new Language.VoidHandler(LoadLanguage);
            rcon.OnlineStateEvent    += new SourceRconConnection.VoidHandler(UpdateUIControls);
            rcon.ErrorEvent          += new SourceRconConnection.StringHandler(RconError);

            // configure hotkey
            HK.OwnerForm = this;
            HK.HotKeyPressed += new HotKeyClass.HotKeyPressedEventHandler(HK_HotKeyPressed);
            
            // Upgrade settings
            if (Properties.Settings.Default.UpdateUserSettings) {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateUserSettings = false;
                Properties.Settings.Default.Save();
            }

            // start to tray
            if (Settings.Default.StartMinimized) HideWindow();

            AssignHotKeys();
            Tools.CheckForConfigs();
            if (Settings.Default.Autoconnect) rcon.Connect();
        }

        private void HK_HotKeyPressed(string ID) {
            if (rcon.GetState() == SourceRconConnection.State.Connected) {
                if (ID == GlobalConstants.HOTKEYID_LOADCFG) {
                    SourceRconTools.LoadConfigFile(Settings.Default.HKey_LoadCFG_Config);
                } else if (ID == GlobalConstants.HOTKEYID_RESTART) {
                    Restart3_ExceptionHandled();
                }
            }
        }

        private void AssignHotKeys() {
            foreach (SettingsProperty property in Settings.Default.Properties) {
                if (property.PropertyType == typeof(HotKeyObject)) {
                    HotKeyObject hotKey = (HotKeyObject)Settings.Default[property.Name];
                    if (hotKey != null && hotKey.HotKey != Keys.None && !String.IsNullOrEmpty(hotKey.HotKeyID)) {
                        HK.AddHotKey(hotKey);
                    }
                }
            }
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

        // Notify Conext Connect
        private void contextNotifyConnectItem_Click(object sender, EventArgs e) {
            rcon.Connect();
        }

        // Notify Conext Open
        private void contextNotifyOpen_Click(object sender, EventArgs e) {
            RestoreWindow();
        }

        // Notify Conext Close
        private void contextNotifyClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        // Menu Save Config
        private void menuItemSaveConfig_Click(object sender, EventArgs e) {
            SaveFileDialog saveXML = new SaveFileDialog();
            saveXML.Filter = "XML|*.xml";
            saveXML.Title = "Save XML File";
            saveXML.ShowDialog();
            if (saveXML.FileName != "") {
                Tools.WriteXML(saveXML.FileName);
            }
        }

        // Menu Load Config
        private void menuItemOpenConfig_Click(object sender, EventArgs e) {
            OpenFileDialog openXML = new OpenFileDialog();
            openXML.Filter = "XML|*.xml";
            openXML.Title = "Save XML File";
            openXML.ShowDialog();
            if (openXML.FileName != "") {
                Tools.ReadXML(openXML.FileName);
            }
        }

        // Menu Exit
        private void menuItemExit_Click(object sender, EventArgs e) {
            this.Close();
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

        // Menu About
        private void menuItemAbout_Click(object sender, EventArgs e) {
            frmAbout formAbout = new frmAbout();
            formAbout.ShowDialog();
        }

        // Button Kick Players
        private void btnKick_Click(object sender, EventArgs e) {
            frmRconKick formKickPlayers     = new frmRconKick();
            formKickPlayers.ExceptionEvent += new frmRconKick.StringHandler(UpdateStatusHint);
            formKickPlayers.ShowDialog();
        }

        // Button Ban Players
        private void btnBan_Click(object sender, EventArgs e) {
            frmRconBan formBanPlayers      = new frmRconBan();
            formBanPlayers.ExceptionEvent += new frmRconBan.StringHandler(UpdateStatusHint);
            formBanPlayers.ShowDialog();
        }

        // Button Change map
        private void btnMapchange_Click(object sender, EventArgs e) {
            frmRconChangeMap formChangeMap = new frmRconChangeMap();
            formChangeMap.ExceptionEvent += new frmRconChangeMap.StringHandler(UpdateStatusHint);
            if (formChangeMap.ShowDialog() == DialogResult.OK) {
                SourceRconTools.ChangeMap(formChangeMap.ReturnValue);
            }
        }

        // Button Load Config
        private void btnConfig_Click(object sender, EventArgs e) {
            frmRconLoadConfig formLoadConfig = new frmRconLoadConfig();
            formLoadConfig.ExceptionEvent += new frmRconLoadConfig.StringHandler(UpdateStatusHint);
            if (formLoadConfig.ShowDialog() == DialogResult.OK) {
                SourceRconTools.LoadConfigFile(formLoadConfig.ReturnValue);
            }
        }

        // Button Restart 3x
        private void btnRestart3_Click(object sender, EventArgs e) {
            Restart3_ExceptionHandled();
        }

        // Form Closing
        private void frmRconUI_FormClosing(object sender, FormClosingEventArgs e) {
            //notifyIcon.Visible = false;
        }

        // Form Closed
        private void RconUI_FormClosed(object sender, FormClosedEventArgs e) {
            Settings.Default.Save();
        }

        //*************************************************
        // Private helper methods
        //*************************************************
        private void HideWindow() {
            this.Hide();
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            this.notifyIcon.Visible = true;
        }

        private void RestoreWindow() {
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;
        }

        private void RconError(string str) {
            Invoke(new MethodInvoker(delegate {
                UpdateStatusError(str);
            }));
        }

        private void Restart3_ExceptionHandled() {
            try {
                SourceRconTools.Restart3();
            } catch (Exception ex) {
                ErrorLogger.Log(ex);
                UpdateStatusError(mLangMan.GetString("Rcon_WrongAnswer"));
            }
        }

        private void UpdateStatusHint(string strError) {
            UpdateStatusError(strError, true);
        }

        // Update Statusbar Error Message
        private void UpdateStatusError(string strError, bool hintOnly = false) {
            statusIconStatus.Image          = Resources.red;
            statusLabelStatusRcon.ForeColor = Color.Red;
            statusLabelStatusRcon.Text      = String.Format(mLangMan.GetString("Error_Statusbar"), strError);
            if (hintOnly) {
                Thread threadResetError       = new Thread(delegate() { ResetStatusError(); });
                threadResetError.IsBackground = true;
                threadResetError.Start();
            } else {
                contextNotifyConnect.Visible      = true;
                contextNotifyConnectSeparator.Visible = true;
                notifyIcon.Icon                       = Resources.IconConnectionError;
            }
        }

        // Reset Statusbar error message
        private void ResetStatusError() {
            Thread.Sleep(GlobalConstants.ERROR_RESET_TIME);
            UpdateUIControls();
        }

        // Update UI controls
        private void UpdateUIControls() {
            if (this.InvokeRequired) {
                MethodInvoker del = delegate { UpdateUIControls(); };
                this.Invoke(del);
                return;
            }

            statusLabelStatusRcon.ForeColor = Color.Black;
            menuConnection.Enabled = true;

            if (rcon.GetState() == SourceRconConnection.State.Disconnected) {
                contextNotifyConnect.Visible          = true;
                contextNotifyConnectSeparator.Visible = true;
            } else {
                contextNotifyConnect.Visible          = false;
                contextNotifyConnectSeparator.Visible = false;
            }

            if (rcon.GetState() == SourceRconConnection.State.Connected) {
                groupPlayerCommands.Enabled = true;
                groupServerCommands.Enabled = true;

                notifyIcon.Icon            = Resources.IconConnected;
                statusIconStatus.Image     = Resources.green;
                statusLabelStatusRcon.Text = String.Format(mLangMan.GetString("StatusRconLbl_Connected"), rcon.connectedIP, rcon.connectedPort);
            } else {

                groupPlayerCommands.Enabled = false;
                groupServerCommands.Enabled = false;

                if (String.IsNullOrEmpty(Settings.Default.RconIP)) {
                    menuConnection.Enabled     = false;
                    notifyIcon.Icon            = Resources.IconDisconnected;
                    statusIconStatus.Image     = null;
                    statusLabelStatusRcon.Text = mLangMan.GetString("StatusRconLbl_NotConfigured");
                } else if (rcon.GetState() == SourceRconConnection.State.Connecting) {
                    notifyIcon.Icon            = Resources.IconConnecting;
                    statusIconStatus.Image     = Resources.orange;
                    statusLabelStatusRcon.Text = mLangMan.GetString("StatusRconLbl_Connecting");
                } else if (rcon.GetState() == SourceRconConnection.State.Disconnected) {
                    notifyIcon.Icon            = Resources.IconDisconnected;
                    statusIconStatus.Image     = Resources.red;
                    statusLabelStatusRcon.Text = mLangMan.GetString("StatusRconLbl_Disconnected");
                }
            }
        }

        private void LoadLanguage() {
            this.Text                 = mLangMan.GetString("Main_FormTitle");
            menuFile.Text             = mLangMan.GetString("Main_MenuFile");
            menuItemOpenConfig.Text   = mLangMan.GetString("Main_MenuFile_OpenConfig");
            menuItemSaveConfig.Text   = mLangMan.GetString("Main_MenuFile_SaveConfig");
            menuItemExit.Text         = mLangMan.GetString("Main_MenuFile_Exit");
            menuConnection.Text       = mLangMan.GetString("Main_MenuConnection");
            menuItemConnect.Text      = mLangMan.GetString("Main_MenuConnection_Connect");
            menuItemDisconnect.Text   = mLangMan.GetString("Main_MenuConnection_Disconnect");
            menuOptions.Text          = mLangMan.GetString("Main_MenuOptions");
            menuItemHotkeys.Text      = mLangMan.GetString("Main_MenuOptions_Hotkeys");
            menuItemSettings.Text     = mLangMan.GetString("Main_MenuOptions_Settings");
            menuItemAbout.Text        = mLangMan.GetString("Main_MenuAbout");
            contextNotifyOpen.Text    = mLangMan.GetString("NotifyIcon_Open");
            contextNotifyConnect.Text = mLangMan.GetString("NotifyIcon_Connect");
            contextNotifyExit.Text    = mLangMan.GetString("NotifyIcon_Exit");
            btnRestart3.Text          = mLangMan.GetString("Main_Button_Restart3");
            btnKick.Text              = mLangMan.GetString("Main_Button_KickPlayers");
            btnBan.Text               = mLangMan.GetString("Main_Button_BanPlayers");
            btnChangeMap.Text         = mLangMan.GetString("Main_Button_ChangeMap");
            btnLoadCfg.Text           = mLangMan.GetString("Main_Button_LoadCfg");
            groupPlayerCommands.Text  = mLangMan.GetString("Main_Group_PlayerCommands");
            groupServerCommands.Text  = mLangMan.GetString("Main_Group_ServerCommands");

            UpdateUIControls();
        }
    }
}
