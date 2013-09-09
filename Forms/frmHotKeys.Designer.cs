namespace RConControl.Forms {
    partial class frmHotKeys {
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
            this.lblHkeyLoadCfg = new System.Windows.Forms.Label();
            this.lblLoadCfg = new System.Windows.Forms.Label();
            this.btnHkeyLoadCfg = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRestart = new System.Windows.Forms.Label();
            this.btnHkeyRestart = new System.Windows.Forms.Button();
            this.lblHkeyRestart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHkeyLoadCfg
            // 
            this.lblHkeyLoadCfg.AutoSize = true;
            this.lblHkeyLoadCfg.Location = new System.Drawing.Point(84, 17);
            this.lblHkeyLoadCfg.Name = "lblHkeyLoadCfg";
            this.lblHkeyLoadCfg.Size = new System.Drawing.Size(30, 13);
            this.lblHkeyLoadCfg.TabIndex = 7;
            this.lblHkeyLoadCfg.Text = "hkey";
            // 
            // lblLoadCfg
            // 
            this.lblLoadCfg.AutoSize = true;
            this.lblLoadCfg.Location = new System.Drawing.Point(12, 17);
            this.lblLoadCfg.Name = "lblLoadCfg";
            this.lblLoadCfg.Size = new System.Drawing.Size(66, 13);
            this.lblLoadCfg.TabIndex = 6;
            this.lblLoadCfg.Text = "Load config:";
            // 
            // btnHkeyLoadCfg
            // 
            this.btnHkeyLoadCfg.Location = new System.Drawing.Point(240, 12);
            this.btnHkeyLoadCfg.Name = "btnHkeyLoadCfg";
            this.btnHkeyLoadCfg.Size = new System.Drawing.Size(50, 23);
            this.btnHkeyLoadCfg.TabIndex = 1;
            this.btnHkeyLoadCfg.Text = "Set";
            this.btnHkeyLoadCfg.UseVisualStyleBackColor = true;
            this.btnHkeyLoadCfg.Click += new System.EventHandler(this.btnHkeySetLoadCfg_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(12, 75);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(104, 13);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = "Press ESC to cancel";
            this.lblInfo.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(134, 70);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(215, 70);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblRestart
            // 
            this.lblRestart.AutoSize = true;
            this.lblRestart.Location = new System.Drawing.Point(12, 46);
            this.lblRestart.Name = "lblRestart";
            this.lblRestart.Size = new System.Drawing.Size(58, 13);
            this.lblRestart.TabIndex = 5;
            this.lblRestart.Text = "3x Restart:";
            // 
            // btnHkeyRestart
            // 
            this.btnHkeyRestart.Location = new System.Drawing.Point(240, 41);
            this.btnHkeyRestart.Name = "btnHkeyRestart";
            this.btnHkeyRestart.Size = new System.Drawing.Size(50, 23);
            this.btnHkeyRestart.TabIndex = 2;
            this.btnHkeyRestart.Text = "Set";
            this.btnHkeyRestart.UseVisualStyleBackColor = true;
            this.btnHkeyRestart.Click += new System.EventHandler(this.btnHkeyRestart_Click);
            // 
            // lblHkeyRestart
            // 
            this.lblHkeyRestart.AutoSize = true;
            this.lblHkeyRestart.Location = new System.Drawing.Point(84, 46);
            this.lblHkeyRestart.Name = "lblHkeyRestart";
            this.lblHkeyRestart.Size = new System.Drawing.Size(30, 13);
            this.lblHkeyRestart.TabIndex = 8;
            this.lblHkeyRestart.Text = "hkey";
            // 
            // frmHotKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 104);
            this.Controls.Add(this.lblHkeyRestart);
            this.Controls.Add(this.btnHkeyRestart);
            this.Controls.Add(this.lblRestart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnHkeyLoadCfg);
            this.Controls.Add(this.lblLoadCfg);
            this.Controls.Add(this.lblHkeyLoadCfg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmHotKeys";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotKeys";
            this.Load += new System.EventHandler(this.frmHotKeys_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHotKeys_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHkeyLoadCfg;
        private System.Windows.Forms.Label lblLoadCfg;
        private System.Windows.Forms.Button btnHkeyLoadCfg;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRestart;
        private System.Windows.Forms.Button btnHkeyRestart;
        private System.Windows.Forms.Label lblHkeyRestart;
    }
}