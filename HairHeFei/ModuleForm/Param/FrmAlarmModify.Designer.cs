namespace Param
{
    partial class FrmAlarmModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlarmModify));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.com_Equipment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_AlarmRemark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_AlarmDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPID = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 37);
            this.panel2.TabIndex = 73;
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.White;
            this.btn_Ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Ok.BackgroundImage")));
            this.btn_Ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Ok.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageIndex = 0;
            this.btn_Ok.ImageList = this.imageList;
            this.btn_Ok.Location = new System.Drawing.Point(257, 0);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 37);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确认";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.ico");
            this.imageList.Images.SetKeyName(1, "Cancel.ico");
            this.imageList.Images.SetKeyName(2, "User.ico");
            this.imageList.Images.SetKeyName(3, "Password.ico");
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.ImageIndex = 1;
            this.btn_Cancel.ImageList = this.imageList;
            this.btn_Cancel.Location = new System.Drawing.Point(337, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 37);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // com_Equipment
            // 
            this.com_Equipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Equipment.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_Equipment.FormattingEnabled = true;
            this.com_Equipment.Location = new System.Drawing.Point(136, 117);
            this.com_Equipment.Name = "com_Equipment";
            this.com_Equipment.Size = new System.Drawing.Size(248, 29);
            this.com_Equipment.TabIndex = 82;
            this.com_Equipment.DropDown += new System.EventHandler(this.com_Equipment_DropDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(36, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 81;
            this.label1.Text = "报警设备";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(417, 55);
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            // 
            // txt_AlarmRemark
            // 
            this.txt_AlarmRemark.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_AlarmRemark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_AlarmRemark.Location = new System.Drawing.Point(136, 193);
            this.txt_AlarmRemark.MaxLength = 200;
            this.txt_AlarmRemark.Name = "txt_AlarmRemark";
            this.txt_AlarmRemark.Size = new System.Drawing.Size(248, 29);
            this.txt_AlarmRemark.TabIndex = 76;
            this.txt_AlarmRemark.TextChanged += new System.EventHandler(this.txt_AlarmRemark_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(38, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 79;
            this.label8.Text = "报警描述";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txt_AlarmDesc
            // 
            this.txt_AlarmDesc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_AlarmDesc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_AlarmDesc.Location = new System.Drawing.Point(136, 155);
            this.txt_AlarmDesc.Name = "txt_AlarmDesc";
            this.txt_AlarmDesc.Size = new System.Drawing.Size(248, 29);
            this.txt_AlarmDesc.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(38, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 78;
            this.label3.Text = "报警信息";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(38, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 77;
            this.label2.Text = "报警编号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbPID
            // 
            this.tbPID.BackColor = System.Drawing.Color.Silver;
            this.tbPID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbPID.Location = new System.Drawing.Point(136, 79);
            this.tbPID.Name = "tbPID";
            this.tbPID.ReadOnly = true;
            this.tbPID.Size = new System.Drawing.Size(248, 29);
            this.tbPID.TabIndex = 74;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(164, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(88, 25);
            this.lblTitle.TabIndex = 83;
            this.lblTitle.Text = "报警维护";
            // 
            // FrmAlarmModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 275);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.com_Equipment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txt_AlarmRemark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_AlarmDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPID);
            this.Controls.Add(this.panel2);
            this.Name = "FrmAlarmModify";
            this.Text = "报警参数维护";
            this.Load += new System.EventHandler(this.FrmParamModify_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ComboBox com_Equipment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_AlarmRemark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_AlarmDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPID;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lblTitle;
    }
}