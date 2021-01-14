namespace Login
{
    partial class FrmPassWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPassWord));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_UserCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_NewPassWord2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NewPassWord1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_OK);
            this.panel1.Controls.Add(this.btn_Cancle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 219);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 40);
            this.panel1.TabIndex = 28;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_OK.FlatAppearance.BorderSize = 0;
            this.btn_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.ForeColor = System.Drawing.Color.Black;
            this.btn_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OK.ImageIndex = 0;
            this.btn_OK.ImageList = this.imageList;
            this.btn_OK.Location = new System.Drawing.Point(132, 1);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(85, 35);
            this.btn_OK.TabIndex = 13;
            this.btn_OK.Text = "确定";
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.ico");
            this.imageList.Images.SetKeyName(1, "Cancel.ico");
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancle.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancle.BackgroundImage")));
            this.btn_Cancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancle.FlatAppearance.BorderSize = 0;
            this.btn_Cancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancle.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancle.ImageIndex = 1;
            this.btn_Cancle.ImageList = this.imageList;
            this.btn_Cancle.Location = new System.Drawing.Point(219, 1);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(85, 35);
            this.btn_Cancle.TabIndex = 14;
            this.btn_Cancle.Text = "取消";
            this.btn_Cancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_UserCode);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txt_NewPassWord2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_NewPassWord1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txt_PassWord);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 164);
            this.panel2.TabIndex = 31;
            // 
            // txt_UserCode
            // 
            this.txt_UserCode.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserCode.Location = new System.Drawing.Point(112, 11);
            this.txt_UserCode.Name = "txt_UserCode";
            this.txt_UserCode.ReadOnly = true;
            this.txt_UserCode.Size = new System.Drawing.Size(183, 29);
            this.txt_UserCode.TabIndex = 51;
            this.txt_UserCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(12, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 22);
            this.label4.TabIndex = 50;
            this.label4.Text = "登录用户";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_NewPassWord2
            // 
            this.txt_NewPassWord2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NewPassWord2.Location = new System.Drawing.Point(112, 126);
            this.txt_NewPassWord2.Name = "txt_NewPassWord2";
            this.txt_NewPassWord2.PasswordChar = '*';
            this.txt_NewPassWord2.Size = new System.Drawing.Size(183, 29);
            this.txt_NewPassWord2.TabIndex = 49;
            this.txt_NewPassWord2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 48;
            this.label2.Text = "确认密码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_NewPassWord1
            // 
            this.txt_NewPassWord1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_NewPassWord1.Location = new System.Drawing.Point(112, 89);
            this.txt_NewPassWord1.Name = "txt_NewPassWord1";
            this.txt_NewPassWord1.PasswordChar = '*';
            this.txt_NewPassWord1.Size = new System.Drawing.Size(183, 29);
            this.txt_NewPassWord1.TabIndex = 47;
            this.txt_NewPassWord1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(12, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 22);
            this.label1.TabIndex = 46;
            this.label1.Text = "新密码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PassWord.Location = new System.Drawing.Point(112, 50);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.PasswordChar = '*';
            this.txt_PassWord.Size = new System.Drawing.Size(183, 29);
            this.txt_PassWord.TabIndex = 45;
            this.txt_PassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "旧密码";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPassWord
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(308, 259);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPassWord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择用户";
            this.Load += new System.EventHandler(this.FrmSelectUser_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_UserCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_NewPassWord2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_NewPassWord1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.Label label3;
    }
}