using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace RCONManager.Forms {
    public partial class frmAbout : Form {
        
        //*************************************************
        // Variables
        //*************************************************
        private Language mLangMan = Language.Instance;

        //*************************************************
        // Initialization
        //*************************************************
        public frmAbout() {
            InitializeComponent();
            LoadLanguage();
        }

        private void frmAbout_Load(object sender, EventArgs e) {
            DateTime buildDate = new DateTime(2000,1,1).AddDays(Assembly.GetExecutingAssembly().GetName().Version.Build);
            lblVersion.Text =  Assembly.GetEntryAssembly().GetName().Version.ToString();
            lblBuildDate.Text = buildDate.ToShortDateString();
        }
        
        //*************************************************
        // Methods
        //*************************************************
        private void LoadLanguage() {
            this.Text     = mLangMan.GetString("About_FormTitle");
            btnClose.Text = mLangMan.GetString("Button_Close");
        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void lblHttp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("http://schreda.com");  
        }
    }
}
