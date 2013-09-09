using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RConControl.Forms {
    public partial class frmRconKick : Form {

        //*************************************************
        // Variables
        //*************************************************
        private Language mLangMan = Language.Instance;

        public delegate void StringBool(string str, bool b = false);
        public event StringBool ExceptionEvent;

        //*************************************************
        // Initialization
        //*************************************************
        public frmRconKick() {
            InitializeComponent();
            LoadLanguage();
        }

        private void RconKickPlayers_Load(object sender, EventArgs e) {
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
                ExceptionEvent(mLangMan.GetString("Rcon_WrongAnswer"), true);
                this.Close();
            }
        }

        //*************************************************
        // Event receivers
        //*************************************************
        private void checkBoxKcikWithMsg_CheckedChanged(object sender, EventArgs e) {
            textBoxMsg.Enabled = checkBoxKcikWithMsg.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            for (int i = 0; i < checkedListBoxPlayers.Items.Count; i++) {
                if(checkedListBoxPlayers.GetItemChecked(i)) {
                    SourceRconTools.Player player = (SourceRconTools.Player)checkedListBoxPlayers.Items[i];
                    if (checkBoxKcikWithMsg.Checked) SourceRconTools.KickPlayer(player, textBoxMsg.Text);
                    else SourceRconTools.KickPlayer(player);
                    
                }
            }     
            this.Close();
        }  
        
        //*************************************************
        // Methods
        //*************************************************
        private void LoadLanguage() {
            this.Text                = mLangMan.GetString("Kick_FormTitle");
            checkBoxKcikWithMsg.Text = mLangMan.GetString("Kick_KickMsg");
            btnOk.Text               = mLangMan.GetString("Button_OK");
            btnCancel.Text           = mLangMan.GetString("Button_Cancel");
        }
    }
}
