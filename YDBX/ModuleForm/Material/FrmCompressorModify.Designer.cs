namespace Material
{
    partial class FrmCompressorModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompressorModify));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Titile = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbx_Compressor_Name = new System.Windows.Forms.ComboBox();
            this.txt_Compressor_Code = new System.Windows.Forms.TextBox();
            this.txt_ProductName = new System.Windows.Forms.TextBox();
            this.lbl_Compressor_Name = new System.Windows.Forms.Label();
            this.lbl_Compressor_Code = new System.Windows.Forms.Label();
            this.lbl_Product_Name = new System.Windows.Forms.Label();
            this.txt_ProductCode = new System.Windows.Forms.TextBox();
            this.lbl_Product_Code = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbl_Titile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 72);
            this.panel1.TabIndex = 45;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Titile
            // 
            this.lbl_Titile.AutoSize = true;
            this.lbl_Titile.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Titile.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_Titile.Location = new System.Drawing.Point(121, 9);
            this.lbl_Titile.Name = "lbl_Titile";
            this.lbl_Titile.Size = new System.Drawing.Size(459, 54);
            this.lbl_Titile.TabIndex = 0;
            this.lbl_Titile.Text = "产品-压缩机关系维护\r\nProduct -compressor relationship maintenance";
            this.lbl_Titile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 279);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 50);
            this.panel2.TabIndex = 46;
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
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageIndex = 4;
            this.btn_Ok.ImageList = this.imageList2;
            this.btn_Ok.Location = new System.Drawing.Point(431, 0);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 50);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确认\r\nOK";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Add.ico");
            this.imageList2.Images.SetKeyName(1, "Delete.ico");
            this.imageList2.Images.SetKeyName(2, "Edit.ico");
            this.imageList2.Images.SetKeyName(3, "Exit.ico");
            this.imageList2.Images.SetKeyName(4, "ok.ico");
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
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.ImageIndex = 3;
            this.btn_Cancel.ImageList = this.imageList2;
            this.btn_Cancel.Location = new System.Drawing.Point(511, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 50);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消\r\nCancel";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbx_Compressor_Name);
            this.panel3.Controls.Add(this.txt_Compressor_Code);
            this.panel3.Controls.Add(this.txt_ProductName);
            this.panel3.Controls.Add(this.lbl_Compressor_Name);
            this.panel3.Controls.Add(this.lbl_Compressor_Code);
            this.panel3.Controls.Add(this.lbl_Product_Name);
            this.panel3.Controls.Add(this.txt_ProductCode);
            this.panel3.Controls.Add(this.lbl_Product_Code);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 207);
            this.panel3.TabIndex = 47;
            // 
            // cbx_Compressor_Name
            // 
            this.cbx_Compressor_Name.BackColor = System.Drawing.Color.White;
            this.cbx_Compressor_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_Compressor_Name.FormattingEnabled = true;
            this.cbx_Compressor_Name.Location = new System.Drawing.Point(260, 111);
            this.cbx_Compressor_Name.Name = "cbx_Compressor_Name";
            this.cbx_Compressor_Name.Size = new System.Drawing.Size(320, 29);
            this.cbx_Compressor_Name.TabIndex = 64;
            this.cbx_Compressor_Name.SelectedValueChanged += new System.EventHandler(this.cbx_Compressor_Name_SelectedValueChanged);
            // 
            // txt_Compressor_Code
            // 
            this.txt_Compressor_Code.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Compressor_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Compressor_Code.Location = new System.Drawing.Point(260, 155);
            this.txt_Compressor_Code.Name = "txt_Compressor_Code";
            this.txt_Compressor_Code.Size = new System.Drawing.Size(320, 29);
            this.txt_Compressor_Code.TabIndex = 63;
            // 
            // txt_ProductName
            // 
            this.txt_ProductName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ProductName.Enabled = false;
            this.txt_ProductName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProductName.Location = new System.Drawing.Point(260, 67);
            this.txt_ProductName.Name = "txt_ProductName";
            this.txt_ProductName.Size = new System.Drawing.Size(319, 29);
            this.txt_ProductName.TabIndex = 61;
            // 
            // lbl_Compressor_Name
            // 
            this.lbl_Compressor_Name.AutoSize = true;
            this.lbl_Compressor_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Compressor_Name.Location = new System.Drawing.Point(19, 158);
            this.lbl_Compressor_Name.Name = "lbl_Compressor_Name";
            this.lbl_Compressor_Name.Size = new System.Drawing.Size(231, 21);
            this.lbl_Compressor_Name.TabIndex = 60;
            this.lbl_Compressor_Name.Text = "压缩机编号 Compressor Code";
            // 
            // lbl_Compressor_Code
            // 
            this.lbl_Compressor_Code.AutoSize = true;
            this.lbl_Compressor_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Compressor_Code.Location = new System.Drawing.Point(18, 114);
            this.lbl_Compressor_Code.Name = "lbl_Compressor_Code";
            this.lbl_Compressor_Code.Size = new System.Drawing.Size(240, 21);
            this.lbl_Compressor_Code.TabIndex = 59;
            this.lbl_Compressor_Code.Text = "压缩机型号 Compressor Model";
            // 
            // lbl_Product_Name
            // 
            this.lbl_Product_Name.AutoSize = true;
            this.lbl_Product_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Product_Name.Location = new System.Drawing.Point(43, 75);
            this.lbl_Product_Name.Name = "lbl_Product_Name";
            this.lbl_Product_Name.Size = new System.Drawing.Size(208, 21);
            this.lbl_Product_Name.TabIndex = 58;
            this.lbl_Product_Name.Text = "冰 箱 名 称 Product Model";
            // 
            // txt_ProductCode
            // 
            this.txt_ProductCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ProductCode.Enabled = false;
            this.txt_ProductCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProductCode.Location = new System.Drawing.Point(260, 23);
            this.txt_ProductCode.Name = "txt_ProductCode";
            this.txt_ProductCode.Size = new System.Drawing.Size(319, 29);
            this.txt_ProductCode.TabIndex = 57;
            // 
            // lbl_Product_Code
            // 
            this.lbl_Product_Code.AutoSize = true;
            this.lbl_Product_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Product_Code.Location = new System.Drawing.Point(52, 26);
            this.lbl_Product_Code.Name = "lbl_Product_Code";
            this.lbl_Product_Code.Size = new System.Drawing.Size(199, 21);
            this.lbl_Product_Code.TabIndex = 53;
            this.lbl_Product_Code.Text = "产 品 编 号 Product Code";
            // 
            // FrmCompressorModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 329);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompressorModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCompressorModify";
            this.Load += new System.EventHandler(this.FrmCompressorModify_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Titile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_Product_Code;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.TextBox txt_Compressor_Code;
        private System.Windows.Forms.TextBox txt_ProductName;
        private System.Windows.Forms.Label lbl_Compressor_Name;
        private System.Windows.Forms.Label lbl_Compressor_Code;
        private System.Windows.Forms.Label lbl_Product_Name;
        private System.Windows.Forms.TextBox txt_ProductCode;
        private System.Windows.Forms.ComboBox cbx_Compressor_Name;
    }
}