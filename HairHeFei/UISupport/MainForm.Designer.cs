namespace UI_Support
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox gbEnrollment;
            System.Windows.Forms.GroupBox gbEventHandlerStatus;
            System.Windows.Forms.Label lblMaxFingers;
            System.Windows.Forms.Label lblMask;
            System.Windows.Forms.GroupBox gbVerification;
            System.Windows.Forms.GroupBox gbReturnValues;
            System.Windows.Forms.Label lblFalseAcceptRate;
            System.Windows.Forms.Label lblname;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MaxFingers = new System.Windows.Forms.NumericUpDown();
            this.Mask = new System.Windows.Forms.NumericUpDown();
            this.IsFailure = new System.Windows.Forms.RadioButton();
            this.IsSuccess = new System.Windows.Forms.RadioButton();
            this.FalseAcceptRate = new System.Windows.Forms.TextBox();
            this.IsFeatureSetMatched = new System.Windows.Forms.CheckBox();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txt_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.VerifyButton = new System.Windows.Forms.Button();
            this.EnrollButton = new System.Windows.Forms.Button();
            gbEnrollment = new System.Windows.Forms.GroupBox();
            gbEventHandlerStatus = new System.Windows.Forms.GroupBox();
            lblMaxFingers = new System.Windows.Forms.Label();
            lblMask = new System.Windows.Forms.Label();
            gbVerification = new System.Windows.Forms.GroupBox();
            gbReturnValues = new System.Windows.Forms.GroupBox();
            lblFalseAcceptRate = new System.Windows.Forms.Label();
            lblname = new System.Windows.Forms.Label();
            gbEnrollment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxFingers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mask)).BeginInit();
            gbEventHandlerStatus.SuspendLayout();
            gbVerification.SuspendLayout();
            gbReturnValues.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbEnrollment
            // 
            gbEnrollment.Controls.Add(this.MaxFingers);
            gbEnrollment.Controls.Add(this.Mask);
            gbEnrollment.Controls.Add(this.EnrollButton);
            gbEnrollment.Controls.Add(gbEventHandlerStatus);
            gbEnrollment.Controls.Add(lblMaxFingers);
            gbEnrollment.Controls.Add(lblMask);
            gbEnrollment.Location = new System.Drawing.Point(21, 99);
            gbEnrollment.Name = "gbEnrollment";
            gbEnrollment.Size = new System.Drawing.Size(266, 220);
            gbEnrollment.TabIndex = 0;
            gbEnrollment.TabStop = false;
            gbEnrollment.Text = "注册指纹";
            // 
            // MaxFingers
            // 
            this.MaxFingers.Location = new System.Drawing.Point(160, 48);
            this.MaxFingers.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxFingers.Name = "MaxFingers";
            this.MaxFingers.Size = new System.Drawing.Size(94, 21);
            this.MaxFingers.TabIndex = 3;
            this.ToolTip.SetToolTip(this.MaxFingers, "Enter a number from 1 to 10");
            this.MaxFingers.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Mask
            // 
            this.Mask.Location = new System.Drawing.Point(160, 25);
            this.Mask.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.Mask.Name = "Mask";
            this.Mask.Size = new System.Drawing.Size(94, 21);
            this.Mask.TabIndex = 1;
            this.ToolTip.SetToolTip(this.Mask, "Enter a number from 0 to 1023");
            // 
            // gbEventHandlerStatus
            // 
            gbEventHandlerStatus.Controls.Add(this.IsFailure);
            gbEventHandlerStatus.Controls.Add(this.IsSuccess);
            gbEventHandlerStatus.Location = new System.Drawing.Point(9, 108);
            gbEventHandlerStatus.Name = "gbEventHandlerStatus";
            gbEventHandlerStatus.Size = new System.Drawing.Size(251, 55);
            gbEventHandlerStatus.TabIndex = 4;
            gbEventHandlerStatus.TabStop = false;
            gbEventHandlerStatus.Text = "处理状态";
            // 
            // IsFailure
            // 
            this.IsFailure.AutoSize = true;
            this.IsFailure.Location = new System.Drawing.Point(151, 27);
            this.IsFailure.Name = "IsFailure";
            this.IsFailure.Size = new System.Drawing.Size(47, 16);
            this.IsFailure.TabIndex = 1;
            this.IsFailure.TabStop = true;
            this.IsFailure.Text = "失败";
            this.ToolTip.SetToolTip(this.IsFailure, "Force an enrollment failure");
            this.IsFailure.UseVisualStyleBackColor = true;
            // 
            // IsSuccess
            // 
            this.IsSuccess.AutoSize = true;
            this.IsSuccess.Location = new System.Drawing.Point(26, 27);
            this.IsSuccess.Name = "IsSuccess";
            this.IsSuccess.Size = new System.Drawing.Size(47, 16);
            this.IsSuccess.TabIndex = 0;
            this.IsSuccess.TabStop = true;
            this.IsSuccess.Text = "成功";
            this.ToolTip.SetToolTip(this.IsSuccess, "Allow a successful enrollment");
            this.IsSuccess.UseVisualStyleBackColor = true;
            // 
            // lblMaxFingers
            // 
            lblMaxFingers.Location = new System.Drawing.Point(6, 49);
            lblMaxFingers.Name = "lblMaxFingers";
            lblMaxFingers.Size = new System.Drawing.Size(148, 18);
            lblMaxFingers.TabIndex = 2;
            lblMaxFingers.Text = "最大录入指纹数量";
            lblMaxFingers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMask
            // 
            lblMask.Location = new System.Drawing.Point(6, 25);
            lblMask.Name = "lblMask";
            lblMask.Size = new System.Drawing.Size(148, 18);
            lblMask.TabIndex = 0;
            lblMask.Text = "指纹标识码";
            lblMask.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbVerification
            // 
            gbVerification.Controls.Add(this.VerifyButton);
            gbVerification.Controls.Add(gbReturnValues);
            gbVerification.Location = new System.Drawing.Point(293, 99);
            gbVerification.Name = "gbVerification";
            gbVerification.Size = new System.Drawing.Size(272, 220);
            gbVerification.TabIndex = 1;
            gbVerification.TabStop = false;
            gbVerification.Text = "验证";
            // 
            // gbReturnValues
            // 
            gbReturnValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gbReturnValues.Controls.Add(this.FalseAcceptRate);
            gbReturnValues.Controls.Add(lblFalseAcceptRate);
            gbReturnValues.Controls.Add(this.IsFeatureSetMatched);
            gbReturnValues.Location = new System.Drawing.Point(9, 37);
            gbReturnValues.Name = "gbReturnValues";
            gbReturnValues.Size = new System.Drawing.Size(257, 126);
            gbReturnValues.TabIndex = 0;
            gbReturnValues.TabStop = false;
            gbReturnValues.Text = "返回值";
            // 
            // FalseAcceptRate
            // 
            this.FalseAcceptRate.Location = new System.Drawing.Point(132, 57);
            this.FalseAcceptRate.Name = "FalseAcceptRate";
            this.FalseAcceptRate.ReadOnly = true;
            this.FalseAcceptRate.Size = new System.Drawing.Size(113, 21);
            this.FalseAcceptRate.TabIndex = 2;
            this.ToolTip.SetToolTip(this.FalseAcceptRate, "Displays the false accept rate (FAR)");
            // 
            // lblFalseAcceptRate
            // 
            lblFalseAcceptRate.Location = new System.Drawing.Point(6, 57);
            lblFalseAcceptRate.Name = "lblFalseAcceptRate";
            lblFalseAcceptRate.Size = new System.Drawing.Size(120, 18);
            lblFalseAcceptRate.TabIndex = 1;
            lblFalseAcceptRate.Text = "错误接受率";
            lblFalseAcceptRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IsFeatureSetMatched
            // 
            this.IsFeatureSetMatched.AutoCheck = false;
            this.IsFeatureSetMatched.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.IsFeatureSetMatched.Location = new System.Drawing.Point(6, 30);
            this.IsFeatureSetMatched.Name = "IsFeatureSetMatched";
            this.IsFeatureSetMatched.Size = new System.Drawing.Size(139, 22);
            this.IsFeatureSetMatched.TabIndex = 0;
            this.IsFeatureSetMatched.Text = "特征值是否匹配";
            this.ToolTip.SetToolTip(this.IsFeatureSetMatched, "Displays a match result");
            this.IsFeatureSetMatched.UseVisualStyleBackColor = true;
            // 
            // lblname
            // 
            lblname.Location = new System.Drawing.Point(28, 65);
            lblname.Name = "lblname";
            lblname.Size = new System.Drawing.Size(58, 18);
            lblname.TabIndex = 5;
            lblname.Text = "姓名：";
            lblname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(77, 65);
            this.txt_name.Name = "txt_name";
            this.txt_name.ReadOnly = true;
            this.txt_name.Size = new System.Drawing.Size(124, 21);
            this.txt_name.TabIndex = 7;
            this.ToolTip.SetToolTip(this.txt_name, "Displays the false accept rate (FAR)");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(187, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "用户信息管理";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 51);
            this.panel2.TabIndex = 46;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.QuitButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 332);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(583, 37);
            this.panel1.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(221, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "用户指纹管理";
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.White;
            this.QuitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("QuitButton.BackgroundImage")));
            this.QuitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QuitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.QuitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.QuitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.QuitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.QuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuitButton.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuitButton.Image = global::UI_Support.Properties.Resources.exit_24px;
            this.QuitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QuitButton.Location = new System.Drawing.Point(501, 0);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(80, 35);
            this.QuitButton.TabIndex = 27;
            this.QuitButton.Text = "退出";
            this.QuitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.QuitButton.UseVisualStyleBackColor = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 51);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // VerifyButton
            // 
            this.VerifyButton.BackgroundImage = global::UI_Support.Properties.Resources.button;
            this.VerifyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VerifyButton.Location = new System.Drawing.Point(98, 176);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(80, 30);
            this.VerifyButton.TabIndex = 1;
            this.VerifyButton.Text = "验证指纹";
            this.ToolTip.SetToolTip(this.VerifyButton, "Start fingerprint verification");
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
            // 
            // EnrollButton
            // 
            this.EnrollButton.BackgroundImage = global::UI_Support.Properties.Resources.button;
            this.EnrollButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.EnrollButton.Location = new System.Drawing.Point(74, 176);
            this.EnrollButton.Name = "EnrollButton";
            this.EnrollButton.Size = new System.Drawing.Size(80, 30);
            this.EnrollButton.TabIndex = 5;
            this.EnrollButton.Text = "注册指纹";
            this.ToolTip.SetToolTip(this.EnrollButton, "Start fingerprint enrollment");
            this.EnrollButton.UseVisualStyleBackColor = true;
            this.EnrollButton.Click += new System.EventHandler(this.EnrollButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 369);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(lblname);
            this.Controls.Add(gbVerification);
            this.Controls.Add(gbEnrollment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指纹管理";
            gbEnrollment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaxFingers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mask)).EndInit();
            gbEventHandlerStatus.ResumeLayout(false);
            gbEventHandlerStatus.PerformLayout();
            gbVerification.ResumeLayout(false);
            gbReturnValues.ResumeLayout(false);
            gbReturnValues.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button EnrollButton;
        private System.Windows.Forms.RadioButton IsFailure;
        private System.Windows.Forms.RadioButton IsSuccess;
        private System.Windows.Forms.TextBox FalseAcceptRate;
        private System.Windows.Forms.CheckBox IsFeatureSetMatched;
		private System.Windows.Forms.Button VerifyButton;
		private System.Windows.Forms.NumericUpDown MaxFingers;
		private System.Windows.Forms.NumericUpDown Mask;
		private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Label label1;
    }
}

