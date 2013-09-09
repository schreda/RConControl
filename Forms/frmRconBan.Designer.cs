namespace RCONManager.Forms {
    partial class frmRconBan {
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
            this.checkedListBoxPlayers = new System.Windows.Forms.CheckedListBox();
            this.radioButtonBanIP = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.textBoxBanTime = new System.Windows.Forms.TextBox();
            this.radioButtonBanID = new System.Windows.Forms.RadioButton();
            this.radioButtonBanBoth = new System.Windows.Forms.RadioButton();
            this.groupBoxBanBy = new System.Windows.Forms.GroupBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBoxBanTime = new System.Windows.Forms.GroupBox();
            this.checkBoxBanPermanent = new System.Windows.Forms.CheckBox();
            this.checkBoxKick = new System.Windows.Forms.CheckBox();
            this.groupBoxBanBy.SuspendLayout();
            this.groupBoxBanTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxPlayers
            // 
            this.checkedListBoxPlayers.FormattingEnabled = true;
            this.checkedListBoxPlayers.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxPlayers.Name = "checkedListBoxPlayers";
            this.checkedListBoxPlayers.Size = new System.Drawing.Size(192, 154);
            this.checkedListBoxPlayers.TabIndex = 0;
            // 
            // radioButtonBanIP
            // 
            this.radioButtonBanIP.AutoSize = true;
            this.radioButtonBanIP.Location = new System.Drawing.Point(6, 41);
            this.radioButtonBanIP.Name = "radioButtonBanIP";
            this.radioButtonBanIP.Size = new System.Drawing.Size(57, 17);
            this.radioButtonBanIP.TabIndex = 1;
            this.radioButtonBanIP.Text = "Ban IP";
            this.radioButtonBanIP.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(126, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(45, 269);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // textBoxBanTime
            // 
            this.textBoxBanTime.Enabled = false;
            this.textBoxBanTime.Location = new System.Drawing.Point(8, 19);
            this.textBoxBanTime.Name = "textBoxBanTime";
            this.textBoxBanTime.Size = new System.Drawing.Size(43, 20);
            this.textBoxBanTime.TabIndex = 0;
            this.textBoxBanTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioButtonBanID
            // 
            this.radioButtonBanID.AutoSize = true;
            this.radioButtonBanID.Checked = true;
            this.radioButtonBanID.Location = new System.Drawing.Point(6, 18);
            this.radioButtonBanID.Name = "radioButtonBanID";
            this.radioButtonBanID.Size = new System.Drawing.Size(58, 17);
            this.radioButtonBanID.TabIndex = 0;
            this.radioButtonBanID.TabStop = true;
            this.radioButtonBanID.Text = "Ban ID";
            this.radioButtonBanID.UseVisualStyleBackColor = true;
            // 
            // radioButtonBanBoth
            // 
            this.radioButtonBanBoth.AutoSize = true;
            this.radioButtonBanBoth.Location = new System.Drawing.Point(6, 64);
            this.radioButtonBanBoth.Name = "radioButtonBanBoth";
            this.radioButtonBanBoth.Size = new System.Drawing.Size(68, 17);
            this.radioButtonBanBoth.TabIndex = 2;
            this.radioButtonBanBoth.Text = "Ban both";
            this.radioButtonBanBoth.UseVisualStyleBackColor = true;
            // 
            // groupBoxBanBy
            // 
            this.groupBoxBanBy.Controls.Add(this.radioButtonBanID);
            this.groupBoxBanBy.Controls.Add(this.radioButtonBanBoth);
            this.groupBoxBanBy.Controls.Add(this.radioButtonBanIP);
            this.groupBoxBanBy.Location = new System.Drawing.Point(12, 172);
            this.groupBoxBanBy.Name = "groupBoxBanBy";
            this.groupBoxBanBy.Size = new System.Drawing.Size(98, 91);
            this.groupBoxBanBy.TabIndex = 1;
            this.groupBoxBanBy.TabStop = false;
            this.groupBoxBanBy.Text = "Ban by";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(57, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(23, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "min";
            // 
            // groupBoxBanTime
            // 
            this.groupBoxBanTime.Controls.Add(this.checkBoxBanPermanent);
            this.groupBoxBanTime.Controls.Add(this.textBoxBanTime);
            this.groupBoxBanTime.Controls.Add(this.lblTime);
            this.groupBoxBanTime.Location = new System.Drawing.Point(116, 172);
            this.groupBoxBanTime.Name = "groupBoxBanTime";
            this.groupBoxBanTime.Size = new System.Drawing.Size(88, 68);
            this.groupBoxBanTime.TabIndex = 2;
            this.groupBoxBanTime.TabStop = false;
            this.groupBoxBanTime.Text = "Ban time";
            // 
            // checkBoxBanPermanent
            // 
            this.checkBoxBanPermanent.AutoSize = true;
            this.checkBoxBanPermanent.Checked = true;
            this.checkBoxBanPermanent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBanPermanent.Location = new System.Drawing.Point(8, 45);
            this.checkBoxBanPermanent.Name = "checkBoxBanPermanent";
            this.checkBoxBanPermanent.Size = new System.Drawing.Size(77, 17);
            this.checkBoxBanPermanent.TabIndex = 1;
            this.checkBoxBanPermanent.Text = "Permanent";
            this.checkBoxBanPermanent.UseVisualStyleBackColor = true;
            this.checkBoxBanPermanent.CheckedChanged += new System.EventHandler(this.checkBoxBanPermanent_CheckedChanged);
            // 
            // checkBoxKick
            // 
            this.checkBoxKick.AutoSize = true;
            this.checkBoxKick.Location = new System.Drawing.Point(116, 246);
            this.checkBoxKick.Name = "checkBoxKick";
            this.checkBoxKick.Size = new System.Drawing.Size(83, 17);
            this.checkBoxKick.TabIndex = 3;
            this.checkBoxKick.Text = "Kick players";
            this.checkBoxKick.UseVisualStyleBackColor = true;
            // 
            // frmRconBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 302);
            this.Controls.Add(this.checkBoxKick);
            this.Controls.Add(this.groupBoxBanTime);
            this.Controls.Add(this.groupBoxBanBy);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.checkedListBoxPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRconBan";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ban players";
            this.Load += new System.EventHandler(this.frmRconBan_Load);
            this.groupBoxBanBy.ResumeLayout(false);
            this.groupBoxBanBy.PerformLayout();
            this.groupBoxBanTime.ResumeLayout(false);
            this.groupBoxBanTime.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxPlayers;
        private System.Windows.Forms.RadioButton radioButtonBanIP;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox textBoxBanTime;
        private System.Windows.Forms.RadioButton radioButtonBanID;
        private System.Windows.Forms.RadioButton radioButtonBanBoth;
        private System.Windows.Forms.GroupBox groupBoxBanBy;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox groupBoxBanTime;
        private System.Windows.Forms.CheckBox checkBoxBanPermanent;
        private System.Windows.Forms.CheckBox checkBoxKick;
    }
}