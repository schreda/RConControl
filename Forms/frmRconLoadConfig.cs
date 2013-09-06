using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RCONManager {
    public partial class frmRconLoadConfig : Form {

        public ConfigFile ReturnValue { get; set; } 

        public frmRconLoadConfig() {
            InitializeComponent();
        }

        private void RconLoadConfigUI_Load(object sender, EventArgs e) {
            comboBoxConfigs.DataSource = Tools.GetAllConfigFiles();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            ReturnValue = (ConfigFile)comboBoxConfigs.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
