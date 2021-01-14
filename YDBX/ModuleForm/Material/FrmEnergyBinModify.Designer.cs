namespace Material
{
    partial class FrmEnergyBinModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnergyBinModify));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Titile = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.cbx_Energy_Name = new System.Windows.Forms.ComboBox();
            this.txt_Act_Qty = new System.Windows.Forms.TextBox();
            this.txt_ProductCode = new System.Windows.Forms.TextBox();
            this.lbl_Compressor_Name = new System.Windows.Forms.Label();
            this.lbl_Compressor_Code = new System.Windows.Forms.Label();
            this.lbl_Product_Name = new System.Windows.Forms.Label();
            this.txt_BinNo = new System.Windows.Forms.TextBox();
            this.lbl_Product_Code = new System.Windows.Forms.Label();
            this.txt_Theory_Qty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Energy_Label_Image = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Energy_Label_Image)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(642, 63);
            this.panel1.TabIndex = 47;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Titile
            // 
            this.lbl_Titile.AutoSize = true;
            this.lbl_Titile.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Titile.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_Titile.Location = new System.Drawing.Point(118, 5);
            this.lbl_Titile.Name = "lbl_Titile";
            this.lbl_Titile.Size = new System.Drawing.Size(525, 54);
            this.lbl_Titile.TabIndex = 0;
            this.lbl_Titile.Text = "网格-能效贴关系维护\r\nBin - energy efficiency paste relationship maintenance";
            this.lbl_Titile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 408);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(642, 50);
            this.panel2.TabIndex = 48;
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
            this.btn_Ok.Location = new System.Drawing.Point(482, 0);
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
            this.btn_Cancel.Location = new System.Drawing.Point(562, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 50);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消\r\nCancel";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // cbx_Energy_Name
            // 
            this.cbx_Energy_Name.BackColor = System.Drawing.Color.White;
            this.cbx_Energy_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Energy_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_Energy_Name.FormattingEnabled = true;
            this.cbx_Energy_Name.Location = new System.Drawing.Point(172, 160);
            this.cbx_Energy_Name.Name = "cbx_Energy_Name";
            this.cbx_Energy_Name.Size = new System.Drawing.Size(213, 29);
            this.cbx_Energy_Name.TabIndex = 72;
            this.cbx_Energy_Name.SelectedValueChanged += new System.EventHandler(this.cbx_Energy_Name_SelectedValueChanged);
            // 
            // txt_Act_Qty
            // 
            this.txt_Act_Qty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Act_Qty.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Act_Qty.Location = new System.Drawing.Point(172, 292);
            this.txt_Act_Qty.Name = "txt_Act_Qty";
            this.txt_Act_Qty.Size = new System.Drawing.Size(213, 29);
            this.txt_Act_Qty.TabIndex = 71;
            // 
            // txt_ProductCode
            // 
            this.txt_ProductCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ProductCode.Enabled = false;
            this.txt_ProductCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProductCode.Location = new System.Drawing.Point(172, 226);
            this.txt_ProductCode.Name = "txt_ProductCode";
            this.txt_ProductCode.Size = new System.Drawing.Size(213, 29);
            this.txt_ProductCode.TabIndex = 70;
            // 
            // lbl_Compressor_Name
            // 
            this.lbl_Compressor_Name.AutoSize = true;
            this.lbl_Compressor_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Compressor_Name.Location = new System.Drawing.Point(50, 284);
            this.lbl_Compressor_Name.Name = "lbl_Compressor_Name";
            this.lbl_Compressor_Name.Size = new System.Drawing.Size(90, 42);
            this.lbl_Compressor_Name.TabIndex = 69;
            this.lbl_Compressor_Name.Text = "实 际 数 量\r\nActual Qty";
            this.lbl_Compressor_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Compressor_Code
            // 
            this.lbl_Compressor_Code.AutoSize = true;
            this.lbl_Compressor_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Compressor_Code.Location = new System.Drawing.Point(26, 216);
            this.lbl_Compressor_Code.Name = "lbl_Compressor_Code";
            this.lbl_Compressor_Code.Size = new System.Drawing.Size(145, 42);
            this.lbl_Compressor_Code.TabIndex = 68;
            this.lbl_Compressor_Code.Text = "能效贴编号\r\nEnergy label code";
            this.lbl_Compressor_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Product_Name
            // 
            this.lbl_Product_Name.AutoSize = true;
            this.lbl_Product_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Product_Name.Location = new System.Drawing.Point(13, 152);
            this.lbl_Product_Name.Name = "lbl_Product_Name";
            this.lbl_Product_Name.Size = new System.Drawing.Size(157, 42);
            this.lbl_Product_Name.TabIndex = 67;
            this.lbl_Product_Name.Text = "能效贴型号\r\nEnergy label Model\r\n";
            this.lbl_Product_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_BinNo
            // 
            this.txt_BinNo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_BinNo.Enabled = false;
            this.txt_BinNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_BinNo.Location = new System.Drawing.Point(172, 94);
            this.txt_BinNo.Name = "txt_BinNo";
            this.txt_BinNo.Size = new System.Drawing.Size(213, 29);
            this.txt_BinNo.TabIndex = 66;
            // 
            // lbl_Product_Code
            // 
            this.lbl_Product_Code.AutoSize = true;
            this.lbl_Product_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Product_Code.Location = new System.Drawing.Point(50, 86);
            this.lbl_Product_Code.Name = "lbl_Product_Code";
            this.lbl_Product_Code.Size = new System.Drawing.Size(89, 42);
            this.lbl_Product_Code.TabIndex = 65;
            this.lbl_Product_Code.Text = "网 格 编 号\r\nBin No.";
            this.lbl_Product_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Theory_Qty
            // 
            this.txt_Theory_Qty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Theory_Qty.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Theory_Qty.Location = new System.Drawing.Point(172, 358);
            this.txt_Theory_Qty.Name = "txt_Theory_Qty";
            this.txt_Theory_Qty.Size = new System.Drawing.Size(213, 29);
            this.txt_Theory_Qty.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(26, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 42);
            this.label1.TabIndex = 73;
            this.label1.Text = "理 论 数 量\r\nTheoretical Qty";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.Energy_Label_Image);
            this.panel3.Location = new System.Drawing.Point(396, 88);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 306);
            this.panel3.TabIndex = 77;
            // 
            // Energy_Label_Image
            // 
            this.Energy_Label_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Energy_Label_Image.Location = new System.Drawing.Point(0, 0);
            this.Energy_Label_Image.Name = "Energy_Label_Image";
            this.Energy_Label_Image.Size = new System.Drawing.Size(236, 306);
            this.Energy_Label_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Energy_Label_Image.TabIndex = 0;
            this.Energy_Label_Image.TabStop = false;
            // 
            // FrmEnergyBinModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 458);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txt_Theory_Qty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_Energy_Name);
            this.Controls.Add(this.txt_Act_Qty);
            this.Controls.Add(this.txt_ProductCode);
            this.Controls.Add(this.lbl_Compressor_Name);
            this.Controls.Add(this.lbl_Compressor_Code);
            this.Controls.Add(this.lbl_Product_Name);
            this.Controls.Add(this.txt_BinNo);
            this.Controls.Add(this.lbl_Product_Code);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEnergyBinModify";
            this.Text = "FrmEnergyBinModify";
            this.Load += new System.EventHandler(this.FrmEnergyBinModify_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Energy_Label_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Titile;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ComboBox cbx_Energy_Name;
        private System.Windows.Forms.TextBox txt_Act_Qty;
        private System.Windows.Forms.TextBox txt_ProductCode;
        private System.Windows.Forms.Label lbl_Compressor_Name;
        private System.Windows.Forms.Label lbl_Compressor_Code;
        private System.Windows.Forms.Label lbl_Product_Name;
        private System.Windows.Forms.TextBox txt_BinNo;
        private System.Windows.Forms.Label lbl_Product_Code;
        private System.Windows.Forms.TextBox txt_Theory_Qty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox Energy_Label_Image;
    }
}