namespace Login
{
    partial class FrmLESUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLESUser));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_Line = new System.Windows.Forms.Label();
            this.lbl_Factory = new System.Windows.Forms.Label();
            this.lbl_Company = new System.Windows.Forms.Label();
            this.com_Shift = new System.Windows.Forms.ComboBox();
            this.com_Class = new System.Windows.Forms.ComboBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Reg = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(559, 447);
            this.panel1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lbl_Line);
            this.panel4.Controls.Add(this.lbl_Factory);
            this.panel4.Controls.Add(this.lbl_Company);
            this.panel4.Controls.Add(this.com_Shift);
            this.panel4.Controls.Add(this.com_Class);
            this.panel4.Controls.Add(this.btn_Reg);
            this.panel4.Controls.Add(this.btn_Ok);
            this.panel4.Controls.Add(this.btn_Cancel);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txt_PassWord);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txt_UserName);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(557, 445);
            this.panel4.TabIndex = 41;
            // 
            // lbl_Line
            // 
            this.lbl_Line.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Line.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Line.Location = new System.Drawing.Point(195, 174);
            this.lbl_Line.Name = "lbl_Line";
            this.lbl_Line.Size = new System.Drawing.Size(220, 29);
            this.lbl_Line.TabIndex = 71;
            this.lbl_Line.Text = "公司";
            this.lbl_Line.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Factory
            // 
            this.lbl_Factory.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Factory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Factory.Location = new System.Drawing.Point(195, 131);
            this.lbl_Factory.Name = "lbl_Factory";
            this.lbl_Factory.Size = new System.Drawing.Size(220, 29);
            this.lbl_Factory.TabIndex = 70;
            this.lbl_Factory.Text = "公司";
            this.lbl_Factory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Company
            // 
            this.lbl_Company.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Company.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Company.Location = new System.Drawing.Point(195, 88);
            this.lbl_Company.Name = "lbl_Company";
            this.lbl_Company.Size = new System.Drawing.Size(220, 29);
            this.lbl_Company.TabIndex = 69;
            this.lbl_Company.Text = "公司";
            this.lbl_Company.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // com_Shift
            // 
            this.com_Shift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Shift.FormattingEnabled = true;
            this.com_Shift.Items.AddRange(new object[] {
            "甲组",
            "乙组",
            "丙组",
            "丁组"});
            this.com_Shift.Location = new System.Drawing.Point(195, 346);
            this.com_Shift.Name = "com_Shift";
            this.com_Shift.Size = new System.Drawing.Size(220, 29);
            this.com_Shift.TabIndex = 65;
            // 
            // com_Class
            // 
            this.com_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Class.FormattingEnabled = true;
            this.com_Class.Items.AddRange(new object[] {
            "早班",
            "中班",
            "晚班"});
            this.com_Class.Location = new System.Drawing.Point(195, 303);
            this.com_Class.Name = "com_Class";
            this.com_Class.Size = new System.Drawing.Size(220, 29);
            this.com_Class.TabIndex = 64;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Add.ico");
            this.imageList2.Images.SetKeyName(1, "Delete.ico");
            this.imageList2.Images.SetKeyName(2, "Edit.ico");
            this.imageList2.Images.SetKeyName(3, "Exit.ico");
            this.imageList2.Images.SetKeyName(4, "Cancel.ico");
            this.imageList2.Images.SetKeyName(5, "ok.ico");
            this.imageList2.Images.SetKeyName(6, "Reg.ico");
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(130, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 29);
            this.label4.TabIndex = 56;
            this.label4.Text = "工厂:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(130, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 29);
            this.label6.TabIndex = 55;
            this.label6.Text = "产线:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(130, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 29);
            this.label7.TabIndex = 54;
            this.label7.Text = "公司:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PassWord.Location = new System.Drawing.Point(195, 260);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.PasswordChar = '*';
            this.txt_PassWord.Size = new System.Drawing.Size(220, 29);
            this.txt_PassWord.TabIndex = 53;
            this.txt_PassWord.Text = "123";
            this.txt_PassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(130, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 29);
            this.label3.TabIndex = 52;
            this.label3.Text = "密码:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(130, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 29);
            this.label2.TabIndex = 51;
            this.label2.Text = "班组";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserName.Location = new System.Drawing.Point(195, 217);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(220, 29);
            this.txt_UserName.TabIndex = 43;
            this.txt_UserName.Text = "admin";
            this.txt_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(130, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 29);
            this.label5.TabIndex = 50;
            this.label5.Text = "班次";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(130, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 29);
            this.label1.TabIndex = 49;
            this.label1.Text = "用户:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 82);
            this.panel2.TabIndex = 73;
            // 
            // btn_Reg
            // 
            this.btn_Reg.BackColor = System.Drawing.Color.White;
            this.btn_Reg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Reg.BackgroundImage")));
            this.btn_Reg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Reg.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Reg.FlatAppearance.BorderSize = 0;
            this.btn_Reg.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Reg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Reg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Reg.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Reg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reg.ImageIndex = 6;
            this.btn_Reg.ImageList = this.imageList2;
            this.btn_Reg.Location = new System.Drawing.Point(372, 385);
            this.btn_Reg.Name = "btn_Reg";
            this.btn_Reg.Size = new System.Drawing.Size(80, 40);
            this.btn_Reg.TabIndex = 3;
            this.btn_Reg.Text = "注册";
            this.btn_Reg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Reg.UseVisualStyleBackColor = false;
            this.btn_Reg.Click += new System.EventHandler(this.btn_Reg_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Ok.BackgroundImage")));
            this.btn_Ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageIndex = 5;
            this.btn_Ok.ImageList = this.imageList2;
            this.btn_Ok.Location = new System.Drawing.Point(194, 385);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 40);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.BorderSize = 0;
            this.btn_Cancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.ImageIndex = 3;
            this.btn_Cancel.ImageList = this.imageList2;
            this.btn_Cancel.Location = new System.Drawing.Point(283, 385);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 40);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "退出";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::Login.Properties.Resources.pic;
            this.pictureBox2.Location = new System.Drawing.Point(0, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(557, 363);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Login.Properties.Resources.Haier;
            this.pictureBox1.Location = new System.Drawing.Point(193, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLESUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(559, 447);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLESUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Activated += new System.EventHandler(this.FrmLESUser_Activated);
            this.Load += new System.EventHandler(this.FrmLESUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Reg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox com_Shift;
        private System.Windows.Forms.ComboBox com_Class;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label lbl_Company;
        private System.Windows.Forms.Label lbl_Line;
        private System.Windows.Forms.Label lbl_Factory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}