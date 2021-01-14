namespace Sys.SysBusiness
{
    partial class FrmLocalPwd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLocalPwd));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_LocalPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCyan;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.txt_LocalPwd);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 40);
            this.panel3.TabIndex = 48;
            // 
            // txt_LocalPwd
            // 
            this.txt_LocalPwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_LocalPwd.Font = new System.Drawing.Font("宋体", 24F);
            this.txt_LocalPwd.Location = new System.Drawing.Point(110, 0);
            this.txt_LocalPwd.Multiline = true;
            this.txt_LocalPwd.Name = "txt_LocalPwd";
            this.txt_LocalPwd.PasswordChar = '*';
            this.txt_LocalPwd.Size = new System.Drawing.Size(368, 38);
            this.txt_LocalPwd.TabIndex = 51;
            this.txt_LocalPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 38);
            this.label5.TabIndex = 48;
            this.label5.Text = "本地密码";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Find.ico");
            this.imageList.Images.SetKeyName(1, "Clear.ico");
            this.imageList.Images.SetKeyName(2, "Cancel.ico");
            this.imageList.Images.SetKeyName(3, "ok.ico");
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.White;
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OK.ImageIndex = 3;
            this.btn_OK.ImageList = this.imageList;
            this.btn_OK.Location = new System.Drawing.Point(319, 97);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(80, 35);
            this.btn_OK.TabIndex = 50;
            this.btn_OK.Text = "确定";
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.BackColor = System.Drawing.Color.White;
            this.btn_Cancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancle.BackgroundImage")));
            this.btn_Cancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancle.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancle.ImageIndex = 2;
            this.btn_Cancle.ImageList = this.imageList;
            this.btn_Cancle.Location = new System.Drawing.Point(399, 97);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(80, 35);
            this.btn_Cancle.TabIndex = 49;
            this.btn_Cancle.Text = "取消";
            this.btn_Cancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // FrmLocalPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 139);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancle);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocalPwd";
            this.Text = "操作确认";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_LocalPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancle;
    }
}