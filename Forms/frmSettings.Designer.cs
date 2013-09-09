namespace RCONManager {
    partial class frmSettings {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBoxAutorun = new System.Windows.Forms.CheckBox();
            this.checkBoxStartMin = new System.Windows.Forms.CheckBox();
            this.groupGeneral = new System.Windows.Forms.GroupBox();
            this.checkBoxAutoconnect = new System.Windows.Forms.CheckBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.groupServer = new System.Windows.Forms.GroupBox();
            this.textBoxRconPw = new System.Windows.Forms.TextBox();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.textBoxServerIp = new System.Windows.Forms.TextBox();
            this.lblPw = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIp = new System.Windows.Forms.Label();
            this.groupMisc = new System.Windows.Forms.GroupBox();
            this.checkBoxZblock = new System.Windows.Forms.CheckBox();
            this.groupGeneral.SuspendLayout();
            this.groupServer.SuspendLayout();
            this.groupMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(56, 285);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkBoxAutorun
            // 
            this.checkBoxAutorun.AutoSize = true;
            this.checkBoxAutorun.Location = new System.Drawing.Point(6, 19);
            this.checkBoxAutorun.Name = "checkBoxAutorun";
            this.checkBoxAutorun.Size = new System.Drawing.Size(63, 17);
            this.checkBoxAutorun.TabIndex = 0;
            this.checkBoxAutorun.Text = "Autorun";
            this.checkBoxAutorun.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartMin
            // 
            this.checkBoxStartMin.AutoSize = true;
            this.checkBoxStartMin.Location = new System.Drawing.Point(6, 42);
            this.checkBoxStartMin.Name = "checkBoxStartMin";
            this.checkBoxStartMin.Size = new System.Drawing.Size(79, 17);
            this.checkBoxStartMin.TabIndex = 1;
            this.checkBoxStartMin.Text = "Start in tray";
            this.checkBoxStartMin.UseVisualStyleBackColor = true;
            // 
            // groupGeneral
            // 
            this.groupGeneral.Controls.Add(this.checkBoxAutoconnect);
            this.groupGeneral.Controls.Add(this.comboBoxLanguage);
            this.groupGeneral.Controls.Add(this.lblLanguage);
            this.groupGeneral.Controls.Add(this.checkBoxAutorun);
            this.groupGeneral.Controls.Add(this.checkBoxStartMin);
            this.groupGeneral.Location = new System.Drawing.Point(12, 12);
            this.groupGeneral.Name = "groupGeneral";
            this.groupGeneral.Size = new System.Drawing.Size(200, 116);
            this.groupGeneral.TabIndex = 1;
            this.groupGeneral.TabStop = false;
            this.groupGeneral.Text = "General settings";
            // 
            // checkBoxAutoconnect
            // 
            this.checkBoxAutoconnect.AutoSize = true;
            this.checkBoxAutoconnect.Location = new System.Drawing.Point(6, 65);
            this.checkBoxAutoconnect.Name = "checkBoxAutoconnect";
            this.checkBoxAutoconnect.Size = new System.Drawing.Size(104, 17);
            this.checkBoxAutoconnect.TabIndex = 2;
            this.checkBoxAutoconnect.Text = "Connect on start";
            this.checkBoxAutoconnect.UseVisualStyleBackColor = true;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(73, 88);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguage.TabIndex = 3;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(6, 91);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 4;
            this.lblLanguage.Text = "Language:";
            // 
            // groupServer
            // 
            this.groupServer.Controls.Add(this.textBoxRconPw);
            this.groupServer.Controls.Add(this.textBoxServerPort);
            this.groupServer.Controls.Add(this.textBoxServerIp);
            this.groupServer.Controls.Add(this.lblPw);
            this.groupServer.Controls.Add(this.lblPort);
            this.groupServer.Controls.Add(this.lblIp);
            this.groupServer.Location = new System.Drawing.Point(12, 134);
            this.groupServer.Name = "groupServer";
            this.groupServer.Size = new System.Drawing.Size(200, 98);
            this.groupServer.TabIndex = 2;
            this.groupServer.TabStop = false;
            this.groupServer.Text = "Server settings";
            // 
            // textBoxRconPw
            // 
            this.textBoxRconPw.Location = new System.Drawing.Point(93, 71);
            this.textBoxRconPw.Name = "textBoxRconPw";
            this.textBoxRconPw.Size = new System.Drawing.Size(100, 20);
            this.textBoxRconPw.TabIndex = 2;
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.Location = new System.Drawing.Point(93, 45);
            this.textBoxServerPort.MaxLength = 5;
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(100, 20);
            this.textBoxServerPort.TabIndex = 1;
            // 
            // textBoxServerIp
            // 
            this.textBoxServerIp.Location = new System.Drawing.Point(93, 19);
            this.textBoxServerIp.MaxLength = 15;
            this.textBoxServerIp.Name = "textBoxServerIp";
            this.textBoxServerIp.Size = new System.Drawing.Size(100, 20);
            this.textBoxServerIp.TabIndex = 0;
            // 
            // lblPw
            // 
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new System.Drawing.Point(6, 74);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new System.Drawing.Size(84, 13);
            this.lblPw.TabIndex = 5;
            this.lblPw.Text = "Rcon password:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 48);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(63, 13);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Server Port:";
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(6, 22);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(54, 13);
            this.lblIp.TabIndex = 3;
            this.lblIp.Text = "Server IP:";
            // 
            // groupMisc
            // 
            this.groupMisc.Controls.Add(this.checkBoxZblock);
            this.groupMisc.Location = new System.Drawing.Point(12, 238);
            this.groupMisc.Name = "groupMisc";
            this.groupMisc.Size = new System.Drawing.Size(200, 41);
            this.groupMisc.TabIndex = 3;
            this.groupMisc.TabStop = false;
            this.groupMisc.Text = "Misc settings";
            // 
            // checkBoxZblock
            // 
            this.checkBoxZblock.AutoSize = true;
            this.checkBoxZblock.Location = new System.Drawing.Point(6, 19);
            this.checkBoxZblock.Name = "checkBoxZblock";
            this.checkBoxZblock.Size = new System.Drawing.Size(143, 17);
            this.checkBoxZblock.TabIndex = 0;
            this.checkBoxZblock.Text = "Automatically use zBlock";
            this.checkBoxZblock.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 317);
            this.Controls.Add(this.groupMisc);
            this.Controls.Add(this.groupServer);
            this.Controls.Add(this.groupGeneral);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.groupGeneral.ResumeLayout(false);
            this.groupGeneral.PerformLayout();
            this.groupServer.ResumeLayout(false);
            this.groupServer.PerformLayout();
            this.groupMisc.ResumeLayout(false);
            this.groupMisc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBoxAutorun;
        private System.Windows.Forms.CheckBox checkBoxStartMin;
        private System.Windows.Forms.GroupBox groupGeneral;
        private System.Windows.Forms.GroupBox groupServer;
        private System.Windows.Forms.TextBox textBoxServerIp;
        private System.Windows.Forms.Label lblPw;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.TextBox textBoxRconPw;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.GroupBox groupMisc;
        private System.Windows.Forms.CheckBox checkBoxZblock;
        private System.Windows.Forms.CheckBox checkBoxAutoconnect;
    }
}