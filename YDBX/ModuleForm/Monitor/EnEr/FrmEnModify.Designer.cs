namespace Monitor
{
    partial class FrmEnModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnModify));
            this.txt_Theory_Qty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Energy_Name = new System.Windows.Forms.ComboBox();
            this.txt_Act_Qty = new System.Windows.Forms.TextBox();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.lbl_Compressor_Name = new System.Windows.Forms.Label();
            this.lbl_Compressor_Code = new System.Windows.Forms.Label();
            this.lbl_Product_Name = new System.Windows.Forms.Label();
            this.txt_BinNo = new System.Windows.Forms.TextBox();
            this.lbl_Product_Code = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.Energy_Label_Image = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Energy_Label_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Theory_Qty
            // 
            this.txt_Theory_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.txt_Theory_Qty.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Theory_Qty.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txt_Theory_Qty.Location = new System.Drawing.Point(117, 241);
            this.txt_Theory_Qty.Name = "txt_Theory_Qty";
            this.txt_Theory_Qty.Size = new System.Drawing.Size(239, 29);
            this.txt_Theory_Qty.TabIndex = 84;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(7, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 83;
            this.label1.Text = "  Theroy Qty";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbx_Energy_Name
            // 
            this.cbx_Energy_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.cbx_Energy_Name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Energy_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_Energy_Name.ForeColor = System.Drawing.Color.Gold;
            this.cbx_Energy_Name.FormattingEnabled = true;
            this.cbx_Energy_Name.Location = new System.Drawing.Point(117, 80);
            this.cbx_Energy_Name.Name = "cbx_Energy_Name";
            this.cbx_Energy_Name.Size = new System.Drawing.Size(240, 29);
            this.cbx_Energy_Name.TabIndex = 82;
            this.cbx_Energy_Name.SelectedValueChanged += new System.EventHandler(this.cbx_Energy_Name_SelectedValueChanged);
            // 
            // txt_Act_Qty
            // 
            this.txt_Act_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.txt_Act_Qty.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Act_Qty.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_Act_Qty.Location = new System.Drawing.Point(117, 187);
            this.txt_Act_Qty.Name = "txt_Act_Qty";
            this.txt_Act_Qty.Size = new System.Drawing.Size(240, 29);
            this.txt_Act_Qty.TabIndex = 81;
            // 
            // txt_Code
            // 
            this.txt_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.txt_Code.Enabled = false;
            this.txt_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Code.ForeColor = System.Drawing.SystemColors.Window;
            this.txt_Code.Location = new System.Drawing.Point(117, 135);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(240, 29);
            this.txt_Code.TabIndex = 80;
            // 
            // lbl_Compressor_Name
            // 
            this.lbl_Compressor_Name.AutoSize = true;
            this.lbl_Compressor_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Compressor_Name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Compressor_Name.Location = new System.Drawing.Point(8, 190);
            this.lbl_Compressor_Name.Name = "lbl_Compressor_Name";
            this.lbl_Compressor_Name.Size = new System.Drawing.Size(100, 21);
            this.lbl_Compressor_Name.TabIndex = 79;
            this.lbl_Compressor_Name.Text = "  Actual Qty";
            this.lbl_Compressor_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Compressor_Code
            // 
            this.lbl_Compressor_Code.AutoSize = true;
            this.lbl_Compressor_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Compressor_Code.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Compressor_Code.Location = new System.Drawing.Point(5, 138);
            this.lbl_Compressor_Code.Name = "lbl_Compressor_Code";
            this.lbl_Compressor_Code.Size = new System.Drawing.Size(107, 21);
            this.lbl_Compressor_Code.TabIndex = 78;
            this.lbl_Compressor_Code.Text = "Energy Code";
            this.lbl_Compressor_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Product_Name
            // 
            this.lbl_Product_Name.AutoSize = true;
            this.lbl_Product_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Product_Name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Product_Name.Location = new System.Drawing.Point(4, 85);
            this.lbl_Product_Name.Name = "lbl_Product_Name";
            this.lbl_Product_Name.Size = new System.Drawing.Size(113, 21);
            this.lbl_Product_Name.TabIndex = 77;
            this.lbl_Product_Name.Text = "Energy Name";
            this.lbl_Product_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_BinNo
            // 
            this.txt_BinNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.txt_BinNo.Enabled = false;
            this.txt_BinNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_BinNo.ForeColor = System.Drawing.Color.Gold;
            this.txt_BinNo.Location = new System.Drawing.Point(119, 27);
            this.txt_BinNo.Name = "txt_BinNo";
            this.txt_BinNo.Size = new System.Drawing.Size(239, 29);
            this.txt_BinNo.TabIndex = 76;
            // 
            // lbl_Product_Code
            // 
            this.lbl_Product_Code.AutoSize = true;
            this.lbl_Product_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Product_Code.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Product_Code.Location = new System.Drawing.Point(26, 30);
            this.lbl_Product_Code.Name = "lbl_Product_Code";
            this.lbl_Product_Code.Size = new System.Drawing.Size(62, 21);
            this.lbl_Product_Code.TabIndex = 75;
            this.lbl_Product_Code.Text = "Bin No";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 300);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 40);
            this.panel2.TabIndex = 86;
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
            this.btn_Ok.Location = new System.Drawing.Point(402, 0);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 40);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "OK";
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
            this.btn_Cancel.Location = new System.Drawing.Point(482, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 40);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Close";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // Energy_Label_Image
            // 
            this.Energy_Label_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Energy_Label_Image.Location = new System.Drawing.Point(360, 27);
            this.Energy_Label_Image.Name = "Energy_Label_Image";
            this.Energy_Label_Image.Size = new System.Drawing.Size(198, 255);
            this.Energy_Label_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Energy_Label_Image.TabIndex = 85;
            this.Energy_Label_Image.TabStop = false;
            // 
            // FrmEnModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(562, 340);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Energy_Label_Image);
            this.Controls.Add(this.txt_Theory_Qty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_Energy_Name);
            this.Controls.Add(this.txt_Act_Qty);
            this.Controls.Add(this.txt_Code);
            this.Controls.Add(this.lbl_Compressor_Name);
            this.Controls.Add(this.lbl_Compressor_Code);
            this.Controls.Add(this.lbl_Product_Name);
            this.Controls.Add(this.txt_BinNo);
            this.Controls.Add(this.lbl_Product_Code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bin-EnergyLabel ";
            this.Load += new System.EventHandler(this.FrmEnModify_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Energy_Label_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Theory_Qty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Energy_Name;
        private System.Windows.Forms.TextBox txt_Act_Qty;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.Label lbl_Compressor_Name;
        private System.Windows.Forms.Label lbl_Compressor_Code;
        private System.Windows.Forms.Label lbl_Product_Name;
        private System.Windows.Forms.TextBox txt_BinNo;
        private System.Windows.Forms.Label lbl_Product_Code;
        private System.Windows.Forms.PictureBox Energy_Label_Image;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.ImageList imageList2;
    }
}