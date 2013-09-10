namespace RConControl.Forms {
    partial class frmRconKick {
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
            this.checkedListBoxPlayers = new System.Windows.Forms.CheckedListBox();
            this.checkBoxKcikWithMsg = new System.Windows.Forms.CheckBox();
            this.textBoxMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(57, 224);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(137, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxPlayers
            // 
            this.checkedListBoxPlayers.FormattingEnabled = true;
            this.checkedListBoxPlayers.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxPlayers.Name = "checkedListBoxPlayers";
            this.checkedListBoxPlayers.Size = new System.Drawing.Size(201, 154);
            this.checkedListBoxPlayers.TabIndex = 0;
            // 
            // checkBoxKcikWithMsg
            // 
            this.checkBoxKcikWithMsg.AutoSize = true;
            this.checkBoxKcikWithMsg.Location = new System.Drawing.Point(12, 172);
            this.checkBoxKcikWithMsg.Name = "checkBoxKcikWithMsg";
            this.checkBoxKcikWithMsg.Size = new System.Drawing.Size(114, 17);
            this.checkBoxKcikWithMsg.TabIndex = 1;
            this.checkBoxKcikWithMsg.Text = "Kick with message";
            this.checkBoxKcikWithMsg.UseVisualStyleBackColor = true;
            this.checkBoxKcikWithMsg.CheckedChanged += new System.EventHandler(this.checkBoxKcikWithMsg_CheckedChanged);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.Enabled = false;
            this.textBoxMsg.Location = new System.Drawing.Point(12, 195);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(201, 20);
            this.textBoxMsg.TabIndex = 2;
            // 
            // frmRconKick
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(224, 257);
            this.Controls.Add(this.textBoxMsg);
            this.Controls.Add(this.checkBoxKcikWithMsg);
            this.Controls.Add(this.checkedListBoxPlayers);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmRconKick";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kick Players";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRconKick_FormClosing);
            this.Load += new System.EventHandler(this.RconKickPlayers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckedListBox checkedListBoxPlayers;
        private System.Windows.Forms.CheckBox checkBoxKcikWithMsg;
        private System.Windows.Forms.TextBox textBoxMsg;
    }
}