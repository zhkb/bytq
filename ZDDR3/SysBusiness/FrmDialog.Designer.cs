namespace Sys.SysBusiness
{
    partial class FrmDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnl_Info = new System.Windows.Forms.Panel();
            this.lbl_Info = new System.Windows.Forms.Label();
            this.pic_Message = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_ask = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.pnl_ok = new System.Windows.Forms.Panel();
            this.btn_TipsOk = new System.Windows.Forms.Button();
            this.pnl_yn = new System.Windows.Forms.Panel();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnl_Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Message)).BeginInit();
            this.pnl_ask.SuspendLayout();
            this.pnl_ok.SuspendLayout();
            this.pnl_yn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnl_Info);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 100);
            this.panel1.TabIndex = 0;
            // 
            // pnl_Info
            // 
            this.pnl_Info.Controls.Add(this.lbl_Info);
            this.pnl_Info.Controls.Add(this.pic_Message);
            this.pnl_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Info.Location = new System.Drawing.Point(0, 2);
            this.pnl_Info.Name = "pnl_Info";
            this.pnl_Info.Size = new System.Drawing.Size(445, 98);
            this.pnl_Info.TabIndex = 2;
            // 
            // lbl_Info
            // 
            this.lbl_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Info.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Info.Location = new System.Drawing.Point(70, 0);
            this.lbl_Info.MinimumSize = new System.Drawing.Size(313, 94);
            this.lbl_Info.Name = "lbl_Info";
            this.lbl_Info.Size = new System.Drawing.Size(375, 98);
            this.lbl_Info.TabIndex = 1;
            this.lbl_Info.Text = "确定退出系统？如退出则不能正常接收生产数据。";
            this.lbl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pic_Message
            // 
            this.pic_Message.BackgroundImage = global::Sys.SysBusiness.Properties.Resources.qustion;
            this.pic_Message.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pic_Message.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic_Message.Location = new System.Drawing.Point(0, 0);
            this.pic_Message.Name = "pic_Message";
            this.pic_Message.Size = new System.Drawing.Size(70, 98);
            this.pic_Message.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Message.TabIndex = 0;
            this.pic_Message.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(445, 2);
            this.label2.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(445, 2);
            this.label4.TabIndex = 13;
            // 
            // pnl_ask
            // 
            this.pnl_ask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ask.Controls.Add(this.btn_Ok);
            this.pnl_ask.Controls.Add(this.btn_Cancle);
            this.pnl_ask.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_ask.Location = new System.Drawing.Point(0, 102);
            this.pnl_ask.Name = "pnl_ask";
            this.pnl_ask.Size = new System.Drawing.Size(445, 40);
            this.pnl_ask.TabIndex = 14;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Ok.BackgroundImage")));
            this.btn_Ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Black;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageIndex = 0;
            this.btn_Ok.ImageList = this.imageList;
            this.btn_Ok.Location = new System.Drawing.Point(289, 1);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 35);
            this.btn_Ok.TabIndex = 11;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Option_Click);
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
            this.btn_Cancle.Location = new System.Drawing.Point(366, 1);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 35);
            this.btn_Cancle.TabIndex = 12;
            this.btn_Cancle.Text = "取消";
            this.btn_Cancle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnl_ok
            // 
            this.pnl_ok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_ok.Controls.Add(this.btn_TipsOk);
            this.pnl_ok.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_ok.Location = new System.Drawing.Point(0, 142);
            this.pnl_ok.Name = "pnl_ok";
            this.pnl_ok.Size = new System.Drawing.Size(445, 40);
            this.pnl_ok.TabIndex = 15;
            // 
            // btn_TipsOk
            // 
            this.btn_TipsOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_TipsOk.BackColor = System.Drawing.Color.Transparent;
            this.btn_TipsOk.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_TipsOk.BackgroundImage")));
            this.btn_TipsOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_TipsOk.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_TipsOk.FlatAppearance.BorderSize = 0;
            this.btn_TipsOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_TipsOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_TipsOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TipsOk.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_TipsOk.ForeColor = System.Drawing.Color.Black;
            this.btn_TipsOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TipsOk.ImageIndex = 0;
            this.btn_TipsOk.ImageList = this.imageList;
            this.btn_TipsOk.Location = new System.Drawing.Point(361, 1);
            this.btn_TipsOk.Name = "btn_TipsOk";
            this.btn_TipsOk.Size = new System.Drawing.Size(80, 35);
            this.btn_TipsOk.TabIndex = 11;
            this.btn_TipsOk.Text = "确定";
            this.btn_TipsOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TipsOk.UseVisualStyleBackColor = false;
            this.btn_TipsOk.Click += new System.EventHandler(this.btn_TipsOk_Click);
            // 
            // pnl_yn
            // 
            this.pnl_yn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_yn.Controls.Add(this.btn_Yes);
            this.pnl_yn.Controls.Add(this.btn_No);
            this.pnl_yn.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_yn.Location = new System.Drawing.Point(0, 182);
            this.pnl_yn.Name = "pnl_yn";
            this.pnl_yn.Size = new System.Drawing.Size(445, 40);
            this.pnl_yn.TabIndex = 16;
            // 
            // btn_Yes
            // 
            this.btn_Yes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Yes.BackColor = System.Drawing.Color.Transparent;
            this.btn_Yes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Yes.BackgroundImage")));
            this.btn_Yes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Yes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Yes.FlatAppearance.BorderSize = 0;
            this.btn_Yes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Yes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Yes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Yes.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Yes.ForeColor = System.Drawing.Color.Black;
            this.btn_Yes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Yes.ImageIndex = 0;
            this.btn_Yes.ImageList = this.imageList;
            this.btn_Yes.Location = new System.Drawing.Point(279, 1);
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.Size = new System.Drawing.Size(80, 35);
            this.btn_Yes.TabIndex = 11;
            this.btn_Yes.Text = "   是";
            this.btn_Yes.UseVisualStyleBackColor = false;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_No.BackColor = System.Drawing.Color.Transparent;
            this.btn_No.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_No.BackgroundImage")));
            this.btn_No.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_No.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_No.FlatAppearance.BorderSize = 0;
            this.btn_No.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_No.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_No.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_No.ForeColor = System.Drawing.Color.Black;
            this.btn_No.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_No.ImageIndex = 1;
            this.btn_No.ImageList = this.imageList;
            this.btn_No.Location = new System.Drawing.Point(361, 1);
            this.btn_No.Name = "btn_No";
            this.btn_No.Size = new System.Drawing.Size(80, 35);
            this.btn_No.TabIndex = 12;
            this.btn_No.Text = "  否";
            this.btn_No.UseVisualStyleBackColor = false;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // FrmDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 224);
            this.ControlBox = false;
            this.Controls.Add(this.pnl_yn);
            this.Controls.Add(this.pnl_ok);
            this.Controls.Add(this.pnl_ask);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提示信息";
            this.Load += new System.EventHandler(this.FrmDialog_Load);
            this.panel1.ResumeLayout(false);
            this.pnl_Info.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Message)).EndInit();
            this.pnl_ask.ResumeLayout(false);
            this.pnl_ok.ResumeLayout(false);
            this.pnl_yn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_Info;
        private System.Windows.Forms.PictureBox pic_Message;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Label lbl_Info;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_ask;
        private System.Windows.Forms.Panel pnl_ok;
        private System.Windows.Forms.Button btn_TipsOk;
        private System.Windows.Forms.Panel pnl_yn;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.ImageList imageList;
    }
}