namespace Material
{
    partial class FrmMaterialModify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialModify));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Ok = new System.Windows.Forms.Button();
            this.tbMName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbMID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Sort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.com_Line = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "物料数据维护";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.ImageIndex = 3;
            this.btn_Cancel.ImageList = this.imageList2;
            this.btn_Cancel.Location = new System.Drawing.Point(364, 5);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 40);
            this.btn_Cancel.TabIndex = 8;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
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
            this.imageList2.Images.SetKeyName(5, "5_b_32px.png");
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.White;
            this.btn_Ok.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Ok.BackgroundImage")));
            this.btn_Ok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Ok.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Ok.ImageIndex = 4;
            this.btn_Ok.ImageList = this.imageList2;
            this.btn_Ok.Location = new System.Drawing.Point(278, 5);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 40);
            this.btn_Ok.TabIndex = 7;
            this.btn_Ok.Text = "确认";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // tbMName
            // 
            this.tbMName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbMName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMName.Location = new System.Drawing.Point(172, 139);
            this.tbMName.Name = "tbMName";
            this.tbMName.Size = new System.Drawing.Size(248, 29);
            this.tbMName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(74, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 48;
            this.label3.Text = "物料名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(74, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "物料编码";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 45);
            this.panel2.TabIndex = 99;
            // 
            // tbMID
            // 
            this.tbMID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbMID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMID.Location = new System.Drawing.Point(172, 86);
            this.tbMID.Name = "tbMID";
            this.tbMID.Size = new System.Drawing.Size(248, 29);
            this.tbMID.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 55);
            this.panel1.TabIndex = 44;
            // 
            // txt_Sort
            // 
            this.txt_Sort.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt_Sort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Sort.Location = new System.Drawing.Point(172, 195);
            this.txt_Sort.Name = "txt_Sort";
            this.txt_Sort.Size = new System.Drawing.Size(248, 29);
            this.txt_Sort.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(74, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "物料代号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(74, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 100;
            this.label5.Text = "物料类型";
            // 
            // com_Line
            // 
            this.com_Line.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_Line.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_Line.FormattingEnabled = true;
            this.com_Line.Location = new System.Drawing.Point(172, 245);
            this.com_Line.Name = "com_Line";
            this.com_Line.Size = new System.Drawing.Size(248, 29);
            this.com_Line.TabIndex = 101;
            // 
            // FrmMaterialModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 338);
            this.ControlBox = false;
            this.Controls.Add(this.com_Line);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Sort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbMID);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMaterialModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物料数据维护";
            this.Load += new System.EventHandler(this.FrmMaterialModify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.TextBox tbMName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbMID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Sort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox com_Line;
    }
}