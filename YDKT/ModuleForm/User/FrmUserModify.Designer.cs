namespace User
{
    partial class FrmUserModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserModify));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Possword = new System.Windows.Forms.Label();
            this.txt_ucname = new System.Windows.Forms.TextBox();
            this.txt_uloginname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_InitialPwd = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.txt_upassword = new System.Windows.Forms.TextBox();
            this.txt_ConfirmPwd = new System.Windows.Forms.TextBox();
            this.lbl_ConfirmPwd = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbDept = new System.Windows.Forms.ComboBox();
            this.txt_utelno = new System.Windows.Forms.TextBox();
            this.txt_umail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_uremark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pic_ResultFace = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ResultFace)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "登录名";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "姓名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Possword
            // 
            this.lbl_Possword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Possword.Location = new System.Drawing.Point(12, 155);
            this.lbl_Possword.Name = "lbl_Possword";
            this.lbl_Possword.Size = new System.Drawing.Size(85, 29);
            this.lbl_Possword.TabIndex = 7;
            this.lbl_Possword.Text = "密码";
            this.lbl_Possword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_ucname
            // 
            this.txt_ucname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ucname.Location = new System.Drawing.Point(103, 114);
            this.txt_ucname.Name = "txt_ucname";
            this.txt_ucname.Size = new System.Drawing.Size(229, 29);
            this.txt_ucname.TabIndex = 1;
            // 
            // txt_uloginname
            // 
            this.txt_uloginname.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_uloginname.Location = new System.Drawing.Point(103, 74);
            this.txt_uloginname.Name = "txt_uloginname";
            this.txt_uloginname.Size = new System.Drawing.Size(229, 29);
            this.txt_uloginname.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_InitialPwd);
            this.panel1.Controls.Add(this.btn_Ok);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 45);
            this.panel1.TabIndex = 50;
            // 
            // btn_InitialPwd
            // 
            this.btn_InitialPwd.BackColor = System.Drawing.Color.White;
            this.btn_InitialPwd.BackgroundImage = global::User.Properties.Resources.button1;
            this.btn_InitialPwd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_InitialPwd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_InitialPwd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_InitialPwd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_InitialPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_InitialPwd.ForeColor = System.Drawing.Color.Transparent;
            this.btn_InitialPwd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_InitialPwd.ImageIndex = 7;
            this.btn_InitialPwd.ImageList = this.imageList;
            this.btn_InitialPwd.Location = new System.Drawing.Point(337, 2);
            this.btn_InitialPwd.Name = "btn_InitialPwd";
            this.btn_InitialPwd.Size = new System.Drawing.Size(80, 40);
            this.btn_InitialPwd.TabIndex = 8;
            this.btn_InitialPwd.Text = "重置";
            this.btn_InitialPwd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_InitialPwd.UseVisualStyleBackColor = false;
            this.btn_InitialPwd.Click += new System.EventHandler(this.btn_InitialPwd_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Save.ico");
            this.imageList.Images.SetKeyName(1, "Find.ico");
            this.imageList.Images.SetKeyName(2, "Add.ico");
            this.imageList.Images.SetKeyName(3, "Delete.ico");
            this.imageList.Images.SetKeyName(4, "Password1.ico");
            this.imageList.Images.SetKeyName(5, "ok.ico");
            this.imageList.Images.SetKeyName(6, "Cancel.ico");
            this.imageList.Images.SetKeyName(7, "undo.ico");
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.White;
            this.btn_Ok.BackgroundImage = global::User.Properties.Resources.button1;
            this.btn_Ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageIndex = 5;
            this.btn_Ok.ImageList = this.imageList;
            this.btn_Ok.Location = new System.Drawing.Point(417, 2);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 40);
            this.btn_Ok.TabIndex = 9;
            this.btn_Ok.Text = "确认";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.BackgroundImage = global::User.Properties.Resources.button1;
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.ImageIndex = 6;
            this.btn_Cancel.ImageList = this.imageList;
            this.btn_Cancel.Location = new System.Drawing.Point(497, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 40);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "关闭";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // txt_upassword
            // 
            this.txt_upassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_upassword.Location = new System.Drawing.Point(103, 154);
            this.txt_upassword.Name = "txt_upassword";
            this.txt_upassword.PasswordChar = '*';
            this.txt_upassword.Size = new System.Drawing.Size(229, 29);
            this.txt_upassword.TabIndex = 2;
            // 
            // txt_ConfirmPwd
            // 
            this.txt_ConfirmPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ConfirmPwd.Location = new System.Drawing.Point(103, 194);
            this.txt_ConfirmPwd.Name = "txt_ConfirmPwd";
            this.txt_ConfirmPwd.PasswordChar = '*';
            this.txt_ConfirmPwd.Size = new System.Drawing.Size(229, 29);
            this.txt_ConfirmPwd.TabIndex = 3;
            // 
            // lbl_ConfirmPwd
            // 
            this.lbl_ConfirmPwd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ConfirmPwd.Location = new System.Drawing.Point(12, 196);
            this.lbl_ConfirmPwd.Name = "lbl_ConfirmPwd";
            this.lbl_ConfirmPwd.Size = new System.Drawing.Size(85, 29);
            this.lbl_ConfirmPwd.TabIndex = 10;
            this.lbl_ConfirmPwd.Text = "确认密码";
            this.lbl_ConfirmPwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(580, 51);
            this.panel2.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(253, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户信息管理";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 55);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 29);
            this.label4.TabIndex = 46;
            this.label4.Text = "部门";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbbDept
            // 
            this.cbbDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDept.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbDept.FormattingEnabled = true;
            this.cbbDept.Location = new System.Drawing.Point(103, 234);
            this.cbbDept.Name = "cbbDept";
            this.cbbDept.Size = new System.Drawing.Size(229, 29);
            this.cbbDept.TabIndex = 4;
            // 
            // txt_utelno
            // 
            this.txt_utelno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_utelno.Location = new System.Drawing.Point(103, 274);
            this.txt_utelno.Name = "txt_utelno";
            this.txt_utelno.Size = new System.Drawing.Size(229, 29);
            this.txt_utelno.TabIndex = 5;
            // 
            // txt_umail
            // 
            this.txt_umail.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_umail.Location = new System.Drawing.Point(103, 314);
            this.txt_umail.Name = "txt_umail";
            this.txt_umail.Size = new System.Drawing.Size(229, 29);
            this.txt_umail.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 29);
            this.label5.TabIndex = 59;
            this.label5.Text = "电话";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 29);
            this.label6.TabIndex = 60;
            this.label6.Text = "邮箱";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_uremark
            // 
            this.txt_uremark.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_uremark.Location = new System.Drawing.Point(103, 354);
            this.txt_uremark.Name = "txt_uremark";
            this.txt_uremark.Size = new System.Drawing.Size(229, 29);
            this.txt_uremark.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 29);
            this.label7.TabIndex = 62;
            this.label7.Text = "备注";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pic_ResultFace
            // 
            this.pic_ResultFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_ResultFace.Location = new System.Drawing.Point(372, 114);
            this.pic_ResultFace.Name = "pic_ResultFace";
            this.pic_ResultFace.Size = new System.Drawing.Size(201, 229);
            this.pic_ResultFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ResultFace.TabIndex = 63;
            this.pic_ResultFace.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(368, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 29);
            this.label8.TabIndex = 64;
            this.label8.Text = "用户图像";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImage = global::User.Properties.Resources.button1;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageIndex = 4;
            this.button2.ImageList = this.imageList;
            this.button2.Location = new System.Drawing.Point(373, 354);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 40);
            this.button2.TabIndex = 66;
            this.button2.Text = "照片";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FrmUserModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 441);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pic_ResultFace);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_uremark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_umail);
            this.Controls.Add(this.txt_utelno);
            this.Controls.Add(this.cbbDept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_ConfirmPwd);
            this.Controls.Add(this.lbl_ConfirmPwd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_uloginname);
            this.Controls.Add(this.txt_upassword);
            this.Controls.Add(this.txt_ucname);
            this.Controls.Add(this.lbl_Possword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户编辑";
            this.Load += new System.EventHandler(this.FrmUserModify_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ResultFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Possword;
        private System.Windows.Forms.TextBox txt_ucname;
        private System.Windows.Forms.TextBox txt_uloginname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_upassword;
        private System.Windows.Forms.TextBox txt_ConfirmPwd;
        private System.Windows.Forms.Label lbl_ConfirmPwd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_InitialPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbDept;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TextBox txt_utelno;
        private System.Windows.Forms.TextBox txt_umail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_uremark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.PictureBox pic_ResultFace;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button2;
    }
}