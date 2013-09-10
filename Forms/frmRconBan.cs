using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RConControl.Forms {
    public partial class frmRconBan : Form {

        //*************************************************
        // Variables
        //*************************************************
        private Language mLangMan = Language.Instance;

        public delegate void StringHandler(string str);
        public event StringHandler ExceptionEvent;

        //*************************************************
        // Initialization
        //*************************************************
        public frmRconBan() {
            InitializeComponent();
            LoadLanguage();
            radioButtonBanIP.CheckedChanged   += new EventHandler(radioButtons_CheckedChanged);
            radioButtonBanID.CheckedChanged   += new EventHandler(radioButtons_CheckedChanged);
            radioButtonBanBoth.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

        }

        private void frmRconBan_Load(object sender, EventArgs e) {
            try {
                List<SourceRconTools.Player> players = SourceRconTools.GetAllPlayers();
                if (players.Count == 0) {
                    MessageBox.Show(this, mLangMan.GetString("Rcon_NoPlayers"), mLangMan.GetString("Text_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                foreach (SourceRconTools.Player player in players) {
                    checkedListBoxPlayers.Items.Add(player);
                }
            } catch (Exception ex) {
                ErrorLogger.Log(ex);
                ExceptionEvent(mLangMan.GetString("Rcon_WrongAnswer"));
                this.Close();
            }
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void checkBoxBanPermanent_CheckedChanged(object sender, EventArgs e) {
            textBoxBanTime.Enabled = !checkBoxBanPermanent.Checked;
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e) {
            if (radioButtonBanIP.Checked) {
                checkBoxKick.Enabled = false;
            } else {
                checkBoxKick.Enabled = true;
            }
        }

        private void frmRconBan_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.DialogResult == DialogResult.OK) {
                if (!checkBoxBanPermanent.Checked && !Regex.IsMatch(textBoxBanTime.Text, @"\d+")) {
                    MessageBox.Show(this, mLangMan.GetString("Ban_WrongTime"), mLangMan.GetString("Text_Hint"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    e.Cancel = true;
                } else {
                    int time;
                    if (checkBoxBanPermanent.Checked) { time = 0; } else { time = Convert.ToInt32(textBoxBanTime.Text); }

                    for (int i = 0; i < checkedListBoxPlayers.Items.Count; i++) {
                        if (checkedListBoxPlayers.GetItemChecked(i)) {
                            SourceRconTools.Player player = (SourceRconTools.Player)checkedListBoxPlayers.Items[i];
                            if (radioButtonBanID.Checked) {
                                SourceRconTools.BanPlayer(player, 0, time, checkBoxKick.Checked);
                            } else if (radioButtonBanIP.Checked) {
                                SourceRconTools.BanPlayer(player, 1, time, checkBoxKick.Checked);
                            } else if (radioButtonBanBoth.Checked) {
                                SourceRconTools.BanPlayer(player, 2, time, checkBoxKick.Checked);
                            }
                        }
                    }
                }
            }
        }

        //*************************************************
        // Methods
        //*************************************************
        private void LoadLanguage() {
            this.Text                 = mLangMan.GetString("Kick_FormTitle");
            groupBoxBanBy.Text        = mLangMan.GetString("Ban_BanBy");
            groupBoxBanTime.Text      = mLangMan.GetString("Ban_BanTime");
            radioButtonBanID.Text     = mLangMan.GetString("Ban_BanID");
            radioButtonBanIP.Text     = mLangMan.GetString("Ban_BanIP");
            radioButtonBanBoth.Text   = mLangMan.GetString("Ban_BanBoth");
            checkBoxBanPermanent.Text = mLangMan.GetString("Ban_Permanent");
            checkBoxKick.Text         = mLangMan.GetString("Ban_Kick");
            btnOk.Text                = mLangMan.GetString("Button_OK");
            btnCancel.Text            = mLangMan.GetString("Button_Cancel");
        }
    }
}
