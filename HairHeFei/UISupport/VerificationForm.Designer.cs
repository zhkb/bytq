namespace UI_Support
{
    partial class VerificationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button CloseButton;
            System.Windows.Forms.Label lblPrompt;
            this.VerificationControl = new DPFP.Gui.Verification.VerificationControl();
            CloseButton = new System.Windows.Forms.Button();
            lblPrompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            CloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            CloseButton.Location = new System.Drawing.Point(220, 69);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(75, 21);
            CloseButton.TabIndex = 2;
            CloseButton.Text = "关闭";
            CloseButton.UseVisualStyleBackColor = true;
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            lblPrompt.Location = new System.Drawing.Point(67, 12);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new System.Drawing.Size(228, 40);
            lblPrompt.TabIndex = 3;
            lblPrompt.Text = "为了验证你的身份，用注册过的手指触摸指纹阅读器";
            // 
            // VerificationControl
            // 
            this.VerificationControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.VerificationControl.Location = new System.Drawing.Point(13, 12);
            this.VerificationControl.Name = "VerificationControl";
            this.VerificationControl.ReaderSerialNumber = "00000000-0000-0000-0000-000000000000";
            this.VerificationControl.Size = new System.Drawing.Size(48, 43);
            this.VerificationControl.TabIndex = 4;
            this.VerificationControl.OnComplete += new DPFP.Gui.Verification.VerificationControl._OnComplete(this.OnComplete);
            // 
            // VerificationForm
            // 
            this.AcceptButton = CloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = CloseButton;
            this.ClientSize = new System.Drawing.Size(307, 102);
            this.Controls.Add(this.VerificationControl);
            this.Controls.Add(lblPrompt);
            this.Controls.Add(CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "身份验证";
            this.ResumeLayout(false);

        }

        #endregion

		private DPFP.Gui.Verification.VerificationControl VerificationControl;

	}
}