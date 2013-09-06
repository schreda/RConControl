using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager {
    public partial class frmRconKick : Form {

        //*****************************
        // Variables
        //*****************************
        private RconConnection rcon = RconConnection.Instance;
        private Language langMan = Language.Instance;

        //*****************************
        // Initialization
        //*****************************
        public frmRconKick() {
            InitializeComponent();
        }

        private void RconKickPlayers_Load(object sender, EventArgs e) {
            try {
                List<ServerPlayer> players = RconTools.GetAllPlayers(rcon);
                if (players.Count == 0) {
                    MessageBox.Show(langMan.GetString("Rcon_NoPlayers"), langMan.GetString("Text_Info"), MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
                foreach (ServerPlayer player in players) {
                    checkedListBoxPlayers.Items.Add(player);
                }
            } catch {
                MessageBox.Show(langMan.GetString("Rcon_WrongAnswer"), langMan.GetString("Text_Error"), MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                this.Close();
            }
        }

        //*****************************
        // Event receivers
        //*****************************
        private void checkBoxKcikWithMsg_CheckedChanged(object sender, EventArgs e) {
            textBoxMsg.Enabled = checkBoxKcikWithMsg.Checked;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            for (int i = 0; i < checkedListBoxPlayers.Items.Count; i++) {
                if(checkedListBoxPlayers.GetItemChecked(i)) {
                    ServerPlayer player = (ServerPlayer)checkedListBoxPlayers.Items[i];
                    if (checkBoxKcikWithMsg.Checked) RconTools.KickPlayer(rcon, player.id, textBoxMsg.Text);
                    else RconTools.KickPlayer(rcon, player.id);
                    
                }
            }        

            this.Close();
        }
    }
}
