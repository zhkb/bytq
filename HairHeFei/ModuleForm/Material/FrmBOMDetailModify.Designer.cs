namespace Material
{
    partial class FrmBOMDetailModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBOMDetailModify));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbbMaterialName = new System.Windows.Forms.ComboBox();
            this.txt_ProductName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_ProductCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaterialCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(117, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "BOM从表数据维护";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 55);
            this.panel1.TabIndex = 78;
            // 
            // cbbMaterialName
            // 
            this.cbbMaterialName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaterialName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbMaterialName.FormattingEnabled = true;
            this.cbbMaterialName.Location = new System.Drawing.Point(97, 169);
            this.cbbMaterialName.Name = "cbbMaterialName";
            this.cbbMaterialName.Size = new System.Drawing.Size(248, 29);
            this.cbbMaterialName.TabIndex = 113;
            this.cbbMaterialName.SelectedValueChanged += new System.EventHandler(this.cbbMaterialName_SelectedValueChanged);
            // 
            // txt_ProductName
            // 
            this.txt_ProductName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ProductName.Enabled = false;
            this.txt_ProductName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProductName.Location = new System.Drawing.Point(97, 96);
            this.txt_ProductName.Name = "txt_ProductName";
            this.txt_ProductName.Size = new System.Drawing.Size(248, 29);
            this.txt_ProductName.TabIndex = 109;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(5, 101);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 21);
            this.label16.TabIndex = 111;
            this.label16.Text = "产品名称";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(5, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 21);
            this.label15.TabIndex = 110;
            this.label15.Text = "产品编码";
            // 
            // txt_ProductCode
            // 
            this.txt_ProductCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_ProductCode.Enabled = false;
            this.txt_ProductCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProductCode.Location = new System.Drawing.Point(97, 61);
            this.txt_ProductCode.Name = "txt_ProductCode";
            this.txt_ProductCode.Size = new System.Drawing.Size(248, 29);
            this.txt_ProductCode.TabIndex = 108;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 114;
            this.label2.Text = "物料编码";
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_MaterialCode.Enabled = false;
            this.txt_MaterialCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialCode.Location = new System.Drawing.Point(97, 132);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Size = new System.Drawing.Size(248, 29);
            this.txt_MaterialCode.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(5, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 117;
            this.label3.Text = "物料名称";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(37, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 21);
            this.label4.TabIndex = 118;
            this.label4.Text = "数量";
            // 
            // txt_Qty
            // 
            this.txt_Qty.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Qty.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Qty.Location = new System.Drawing.Point(97, 208);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.Size = new System.Drawing.Size(248, 29);
            this.txt_Qty.TabIndex = 119;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 283);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 40);
            this.panel2.TabIndex = 120;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.ImageIndex = 1;
            this.btn_Cancel.ImageList = this.imageList;
            this.btn_Cancel.Location = new System.Drawing.Point(274, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 35);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.White;
            this.btn_Ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Ok.BackgroundImage")));
            this.btn_Ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageIndex = 0;
            this.btn_Ok.ImageList = this.imageList;
            this.btn_Ok.Location = new System.Drawing.Point(192, 2);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 35);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "确认";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // FrmBOMDetailModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 323);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_Qty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_MaterialCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbMaterialName);
            this.Controls.Add(this.txt_ProductName);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_ProductCode);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBOMDetailModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BOM从表数据维护窗口";
            this.Load += new System.EventHandler(this.FrmBOMDetailModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbbMaterialName;
        private System.Windows.Forms.TextBox txt_ProductName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_ProductCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaterialCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
    }
}