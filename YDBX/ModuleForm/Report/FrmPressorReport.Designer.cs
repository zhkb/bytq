namespace Report
{
    partial class FrmPressorReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPressorReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dt_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dt_StartTime = new System.Windows.Forms.DateTimePicker();
            this.dt_StartDate = new System.Windows.Forms.DateTimePicker();
            this.dgvCompressor = new System.Windows.Forms.DataGridView();
            this.Product_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compressor_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compressor_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Match_flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompressor)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlTop.Controls.Add(this.comboBox1);
            this.pnlTop.Controls.Add(this.label4);
            this.pnlTop.Controls.Add(this.btn_Print);
            this.pnlTop.Controls.Add(this.btn_Search);
            this.pnlTop.Controls.Add(this.btn_Close);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.tbKey);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.dt_EndTime);
            this.pnlTop.Controls.Add(this.dt_EndDate);
            this.pnlTop.Controls.Add(this.dt_StartTime);
            this.pnlTop.Controls.Add(this.dt_StartDate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1350, 70);
            this.pnlTop.TabIndex = 7;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "All Line",
            "Line A",
            "Line B"});
            this.comboBox1.Location = new System.Drawing.Point(917, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 29);
            this.comboBox1.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(788, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 30);
            this.label4.TabIndex = 40;
            this.label4.Text = "产线  Line";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.Color.White;
            this.btn_Print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Print.BackgroundImage")));
            this.btn_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Print.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.ImageIndex = 4;
            this.btn_Print.ImageList = this.imageList;
            this.btn_Print.Location = new System.Drawing.Point(1188, 9);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(80, 52);
            this.btn_Print.TabIndex = 38;
            this.btn_Print.Text = "打印\r\nPrint";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.ico");
            this.imageList.Images.SetKeyName(1, "Cancel.ico");
            this.imageList.Images.SetKeyName(2, "User.ico");
            this.imageList.Images.SetKeyName(3, "Password.ico");
            this.imageList.Images.SetKeyName(4, "Print.ico");
            this.imageList.Images.SetKeyName(5, "Find.ico");
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.White;
            this.btn_Search.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Search.BackgroundImage")));
            this.btn_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.ImageIndex = 5;
            this.btn_Search.ImageList = this.imageList;
            this.btn_Search.Location = new System.Drawing.Point(1107, 9);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(80, 52);
            this.btn_Search.TabIndex = 39;
            this.btn_Search.Text = "查询\r\nSelect";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.BackgroundImage")));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList;
            this.btn_Close.Location = new System.Drawing.Point(1268, 9);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 52);
            this.btn_Close.TabIndex = 37;
            this.btn_Close.Text = "关闭\r\nClose";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(788, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 30);
            this.label3.TabIndex = 35;
            this.label3.Text = "关键词Keyword";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbKey.Location = new System.Drawing.Point(917, 5);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(187, 29);
            this.tbKey.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(488, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "起止时间\r\nStarting and ending time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dt_EndTime
            // 
            this.dt_EndTime.CustomFormat = "";
            this.dt_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndTime.Location = new System.Drawing.Point(663, 16);
            this.dt_EndTime.Name = "dt_EndTime";
            this.dt_EndTime.ShowUpDown = true;
            this.dt_EndTime.Size = new System.Drawing.Size(121, 29);
            this.dt_EndTime.TabIndex = 31;
            // 
            // dt_EndDate
            // 
            this.dt_EndDate.CustomFormat = "yyyy-MM-dd";
            this.dt_EndDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndDate.Location = new System.Drawing.Point(519, 16);
            this.dt_EndDate.Name = "dt_EndDate";
            this.dt_EndDate.Size = new System.Drawing.Size(141, 29);
            this.dt_EndDate.TabIndex = 30;
            // 
            // dt_StartTime
            // 
            this.dt_StartTime.CustomFormat = "";
            this.dt_StartTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartTime.Location = new System.Drawing.Point(359, 16);
            this.dt_StartTime.Name = "dt_StartTime";
            this.dt_StartTime.ShowUpDown = true;
            this.dt_StartTime.Size = new System.Drawing.Size(123, 29);
            this.dt_StartTime.TabIndex = 29;
            // 
            // dt_StartDate
            // 
            this.dt_StartDate.CustomFormat = "yyyy-MM-dd";
            this.dt_StartDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartDate.Location = new System.Drawing.Point(216, 16);
            this.dt_StartDate.Name = "dt_StartDate";
            this.dt_StartDate.Size = new System.Drawing.Size(141, 29);
            this.dt_StartDate.TabIndex = 28;
            // 
            // dgvCompressor
            // 
            this.dgvCompressor.AllowUserToAddRows = false;
            this.dgvCompressor.AllowUserToDeleteRows = false;
            this.dgvCompressor.AllowUserToResizeColumns = false;
            this.dgvCompressor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCompressor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompressor.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompressor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompressor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompressor.ColumnHeadersHeight = 50;
            this.dgvCompressor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCompressor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_BarCode,
            this.Product_Name,
            this.Compressor_BarCode,
            this.Compressor_Name,
            this.Create_Time,
            this.Match_flag});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompressor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCompressor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompressor.Location = new System.Drawing.Point(0, 70);
            this.dgvCompressor.Name = "dgvCompressor";
            this.dgvCompressor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompressor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCompressor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCompressor.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCompressor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCompressor.RowTemplate.Height = 30;
            this.dgvCompressor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompressor.Size = new System.Drawing.Size(1350, 659);
            this.dgvCompressor.TabIndex = 8;
            this.dgvCompressor.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCompressor_DataBindingComplete);
            // 
            // Product_BarCode
            // 
            this.Product_BarCode.DataPropertyName = "Product_BarCode";
            this.Product_BarCode.HeaderText = "产品条码                                   Product barcode";
            this.Product_BarCode.Name = "Product_BarCode";
            this.Product_BarCode.ReadOnly = true;
            this.Product_BarCode.Width = 300;
            // 
            // Product_Name
            // 
            this.Product_Name.DataPropertyName = "Product_Name";
            this.Product_Name.HeaderText = "产品型号   Product model";
            this.Product_Name.Name = "Product_Name";
            this.Product_Name.ReadOnly = true;
            this.Product_Name.Width = 150;
            // 
            // Compressor_BarCode
            // 
            this.Compressor_BarCode.DataPropertyName = "Compressor_Barcode";
            this.Compressor_BarCode.HeaderText = "压缩机条码                               Compressor barcode";
            this.Compressor_BarCode.Name = "Compressor_BarCode";
            this.Compressor_BarCode.ReadOnly = true;
            this.Compressor_BarCode.Width = 300;
            // 
            // Compressor_Name
            // 
            this.Compressor_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Compressor_Name.DataPropertyName = "Compressor_Name";
            this.Compressor_Name.HeaderText = "压缩机型号                  Compressor model";
            this.Compressor_Name.Name = "Compressor_Name";
            this.Compressor_Name.ReadOnly = true;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "扫描时间                Scan time";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            this.Create_Time.Width = 200;
            // 
            // Match_flag
            // 
            this.Match_flag.DataPropertyName = "Match_flag";
            this.Match_flag.HeaderText = "匹配结果 Result";
            this.Match_flag.Name = "Match_flag";
            this.Match_flag.ReadOnly = true;
            // 
            // FrmPressorReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.dgvCompressor);
            this.Controls.Add(this.pnlTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmPressorReport";
            this.Text = "压缩机信息查询";
            this.Activated += new System.EventHandler(this.FrmPressorReport_Activated);
            this.Load += new System.EventHandler(this.FrmCompressorQuery_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompressor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_EndTime;
        private System.Windows.Forms.DateTimePicker dt_EndDate;
        private System.Windows.Forms.DateTimePicker dt_StartTime;
        private System.Windows.Forms.DateTimePicker dt_StartDate;
        private System.Windows.Forms.DataGridView dgvCompressor;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compressor_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compressor_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Match_flag;
    }
}