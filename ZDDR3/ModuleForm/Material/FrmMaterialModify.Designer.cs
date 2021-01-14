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
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Ok = new System.Windows.Forms.Button();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbMID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbMaterialType = new System.Windows.Forms.ComboBox();
            this.txtP_Waterproof = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtP_Internal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtP_Frequency = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtP_Capacity = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtP_Voltage = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtP_3D = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtP_Water = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtP_Temperature = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPic_Path = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
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
            this.pictureBox1.Size = new System.Drawing.Size(187, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(191, 11);
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
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.ImageIndex = 1;
            this.btn_Cancel.ImageList = this.imageList;
            this.btn_Cancel.Location = new System.Drawing.Point(368, 1);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 35);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
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
            this.btn_Ok.Location = new System.Drawing.Point(286, 1);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(80, 35);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "确认";
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.UseVisualStyleBackColor = false;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // tbDesc
            // 
            this.tbDesc.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbDesc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDesc.Location = new System.Drawing.Point(103, 172);
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(248, 29);
            this.tbDesc.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(11, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 21);
            this.label8.TabIndex = 50;
            this.label8.Text = "物料描述";
            // 
            // tbMName
            // 
            this.tbMName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbMName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMName.Location = new System.Drawing.Point(103, 101);
            this.tbMName.Name = "tbMName";
            this.tbMName.Size = new System.Drawing.Size(248, 29);
            this.tbMName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(11, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 48;
            this.label3.Text = "物料名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(11, 72);
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
            this.panel2.Location = new System.Drawing.Point(0, 317);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 37);
            this.panel2.TabIndex = 45;
            // 
            // tbMID
            // 
            this.tbMID.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbMID.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbMID.Location = new System.Drawing.Point(103, 66);
            this.tbMID.Name = "tbMID";
            this.tbMID.Size = new System.Drawing.Size(248, 29);
            this.tbMID.TabIndex = 0;
            this.tbMID.TextChanged += new System.EventHandler(this.tbMID_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 55);
            this.panel1.TabIndex = 44;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(11, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 52;
            this.label5.Text = "物料类型";
            // 
            // cbbMaterialType
            // 
            this.cbbMaterialType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaterialType.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbbMaterialType.FormattingEnabled = true;
            this.cbbMaterialType.Location = new System.Drawing.Point(103, 136);
            this.cbbMaterialType.Name = "cbbMaterialType";
            this.cbbMaterialType.Size = new System.Drawing.Size(248, 29);
            this.cbbMaterialType.TabIndex = 55;
            // 
            // txtP_Waterproof
            // 
            this.txtP_Waterproof.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_Waterproof.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_Waterproof.Location = new System.Drawing.Point(103, 207);
            this.txtP_Waterproof.Name = "txtP_Waterproof";
            this.txtP_Waterproof.Size = new System.Drawing.Size(248, 29);
            this.txtP_Waterproof.TabIndex = 56;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(11, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 57;
            this.label4.Text = "防水等级";
            // 
            // txtP_Internal
            // 
            this.txtP_Internal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_Internal.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_Internal.Location = new System.Drawing.Point(103, 242);
            this.txtP_Internal.Name = "txtP_Internal";
            this.txtP_Internal.Size = new System.Drawing.Size(248, 29);
            this.txtP_Internal.TabIndex = 58;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(11, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 21);
            this.label6.TabIndex = 59;
            this.label6.Text = "额定内压";
            // 
            // txtP_Frequency
            // 
            this.txtP_Frequency.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_Frequency.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_Frequency.Location = new System.Drawing.Point(484, 134);
            this.txtP_Frequency.Name = "txtP_Frequency";
            this.txtP_Frequency.Size = new System.Drawing.Size(248, 29);
            this.txtP_Frequency.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(378, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 21);
            this.label7.TabIndex = 65;
            this.label7.Text = "额定频率";
            // 
            // txtP_Capacity
            // 
            this.txtP_Capacity.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_Capacity.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_Capacity.Location = new System.Drawing.Point(484, 99);
            this.txtP_Capacity.Name = "txtP_Capacity";
            this.txtP_Capacity.Size = new System.Drawing.Size(248, 29);
            this.txtP_Capacity.TabIndex = 62;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(378, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 63;
            this.label9.Text = "额定容量";
            // 
            // txtP_Voltage
            // 
            this.txtP_Voltage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_Voltage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_Voltage.Location = new System.Drawing.Point(484, 64);
            this.txtP_Voltage.Name = "txtP_Voltage";
            this.txtP_Voltage.Size = new System.Drawing.Size(248, 29);
            this.txtP_Voltage.TabIndex = 60;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(378, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 61;
            this.label10.Text = "额定电压";
            // 
            // txtP_3D
            // 
            this.txtP_3D.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_3D.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_3D.Location = new System.Drawing.Point(484, 239);
            this.txtP_3D.Name = "txtP_3D";
            this.txtP_3D.Size = new System.Drawing.Size(248, 29);
            this.txtP_3D.TabIndex = 70;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(378, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 21);
            this.label11.TabIndex = 71;
            this.label11.Text = "3D模式功率";
            // 
            // txtP_Water
            // 
            this.txtP_Water.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_Water.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_Water.Location = new System.Drawing.Point(484, 204);
            this.txtP_Water.Name = "txtP_Water";
            this.txtP_Water.Size = new System.Drawing.Size(248, 29);
            this.txtP_Water.TabIndex = 68;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(378, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 21);
            this.label12.TabIndex = 69;
            this.label12.Text = "储水模式功率";
            // 
            // txtP_Temperature
            // 
            this.txtP_Temperature.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtP_Temperature.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtP_Temperature.Location = new System.Drawing.Point(484, 169);
            this.txtP_Temperature.Name = "txtP_Temperature";
            this.txtP_Temperature.Size = new System.Drawing.Size(248, 29);
            this.txtP_Temperature.TabIndex = 66;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(378, 171);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 21);
            this.label13.TabIndex = 67;
            this.label13.Text = "最高温度";
            // 
            // txtPic_Path
            // 
            this.txtPic_Path.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPic_Path.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPic_Path.Location = new System.Drawing.Point(103, 277);
            this.txtPic_Path.Name = "txtPic_Path";
            this.txtPic_Path.Size = new System.Drawing.Size(629, 29);
            this.txtPic_Path.TabIndex = 72;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(11, 279);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 21);
            this.label14.TabIndex = 73;
            this.label14.Text = "图片路径";
            // 
            // FrmMaterialModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 354);
            this.ControlBox = false;
            this.Controls.Add(this.txtPic_Path);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtP_3D);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtP_Water);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtP_Temperature);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtP_Frequency);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtP_Capacity);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtP_Voltage);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtP_Internal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtP_Waterproof);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbMaterialType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbMID);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbMID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbMaterialType;
        private System.Windows.Forms.TextBox txtP_Waterproof;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtP_Internal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtP_Frequency;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtP_Capacity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtP_Voltage;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtP_3D;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtP_Water;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtP_Temperature;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPic_Path;
        private System.Windows.Forms.Label label14;
    }
}