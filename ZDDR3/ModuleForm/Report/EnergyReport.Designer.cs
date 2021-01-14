namespace Report
{
    partial class EnergyReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnergyReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.dt_EndTime2 = new System.Windows.Forms.DateTimePicker();
            this.dt_EndTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dt_StartTime2 = new System.Windows.Forms.DateTimePicker();
            this.dt_StartTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgv_Common = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scan_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Level = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Export = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Common)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 38);
            this.panel1.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Find.ico");
            this.imageList.Images.SetKeyName(1, "Down.ico");
            this.imageList.Images.SetKeyName(2, "Up.ico");
            this.imageList.Images.SetKeyName(3, "Cancel.ico");
            this.imageList.Images.SetKeyName(4, "Check.ico");
            this.imageList.Images.SetKeyName(5, "Clear.ico");
            this.imageList.Images.SetKeyName(6, "ok.ico");
            this.imageList.Images.SetKeyName(7, "Print.ico");
            this.imageList.Images.SetKeyName(8, "Add1.ico");
            this.imageList.Images.SetKeyName(9, "Create.ico");
            this.imageList.Images.SetKeyName(10, "Config.ico");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Search);
            this.panel3.Controls.Add(this.btn_Export);
            this.panel3.Controls.Add(this.btn_Print);
            this.panel3.Controls.Add(this.btn_Close);
            this.panel3.Controls.Add(this.dt_EndTime2);
            this.panel3.Controls.Add(this.dt_EndTime);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dt_StartTime2);
            this.panel3.Controls.Add(this.dt_StartTime);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txt_Name);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1904, 38);
            this.panel3.TabIndex = 0;
            // 
            // dt_EndTime2
            // 
            this.dt_EndTime2.AllowDrop = true;
            this.dt_EndTime2.CustomFormat = "HH:mm:ss";
            this.dt_EndTime2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndTime2.Location = new System.Drawing.Point(1038, 5);
            this.dt_EndTime2.Margin = new System.Windows.Forms.Padding(0);
            this.dt_EndTime2.Name = "dt_EndTime2";
            this.dt_EndTime2.ShowUpDown = true;
            this.dt_EndTime2.Size = new System.Drawing.Size(123, 29);
            this.dt_EndTime2.TabIndex = 34;
            this.dt_EndTime2.Value = new System.DateTime(2019, 10, 11, 19, 38, 0, 0);
            // 
            // dt_EndTime
            // 
            this.dt_EndTime.CustomFormat = "yyyy-MM-dd";
            this.dt_EndTime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndTime.Location = new System.Drawing.Point(895, 5);
            this.dt_EndTime.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.dt_EndTime.Name = "dt_EndTime";
            this.dt_EndTime.Size = new System.Drawing.Size(140, 29);
            this.dt_EndTime.TabIndex = 33;
            this.dt_EndTime.Value = new System.DateTime(2019, 10, 11, 9, 45, 0, 0);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(797, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 30);
            this.label3.TabIndex = 32;
            this.label3.Text = "结束时间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dt_StartTime2
            // 
            this.dt_StartTime2.AllowDrop = true;
            this.dt_StartTime2.CalendarFont = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartTime2.CustomFormat = "HH:mm:ss";
            this.dt_StartTime2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dt_StartTime2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartTime2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartTime2.Location = new System.Drawing.Point(619, 5);
            this.dt_StartTime2.Margin = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.dt_StartTime2.Name = "dt_StartTime2";
            this.dt_StartTime2.ShowUpDown = true;
            this.dt_StartTime2.Size = new System.Drawing.Size(145, 29);
            this.dt_StartTime2.TabIndex = 31;
            this.dt_StartTime2.Value = new System.DateTime(2019, 10, 11, 19, 38, 0, 0);
            // 
            // dt_StartTime
            // 
            this.dt_StartTime.AllowDrop = true;
            this.dt_StartTime.CustomFormat = "yyyy-MM-dd";
            this.dt_StartTime.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartTime.Location = new System.Drawing.Point(477, 5);
            this.dt_StartTime.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.dt_StartTime.Name = "dt_StartTime";
            this.dt_StartTime.Size = new System.Drawing.Size(139, 29);
            this.dt_StartTime.TabIndex = 30;
            this.dt_StartTime.Value = new System.DateTime(2019, 10, 11, 9, 38, 0, 0);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(376, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 30);
            this.label2.TabIndex = 29;
            this.label2.Text = "开始时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_Name.Location = new System.Drawing.Point(102, 5);
            this.txt_Name.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(241, 29);
            this.txt_Name.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 30);
            this.label1.TabIndex = 27;
            this.label1.Text = "产品型号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.dgv_Common);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 38);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1904, 1003);
            this.panel7.TabIndex = 1;
            // 
            // dgv_Common
            // 
            this.dgv_Common.AllowUserToAddRows = false;
            this.dgv_Common.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Common.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Common.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_Common.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Common.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Product_BarCode,
            this.Material_Code,
            this.Material_Name,
            this.Scan_Time,
            this.Material_Level});
            this.dgv_Common.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Common.Location = new System.Drawing.Point(0, 0);
            this.dgv_Common.Name = "dgv_Common";
            this.dgv_Common.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Common.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Common.RowHeadersVisible = false;
            this.dgv_Common.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Common.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_Common.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Common.RowTemplate.Height = 23;
            this.dgv_Common.Size = new System.Drawing.Size(1902, 1001);
            this.dgv_Common.TabIndex = 0;
            this.dgv_Common.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Common_RowPostPaint);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 83;
            // 
            // Product_BarCode
            // 
            this.Product_BarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_BarCode.DataPropertyName = "Product_BarCode";
            this.Product_BarCode.HeaderText = "产品条码";
            this.Product_BarCode.Name = "Product_BarCode";
            this.Product_BarCode.ReadOnly = true;
            // 
            // Material_Code
            // 
            this.Material_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "产品编码";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Width = 400;
            // 
            // Material_Name
            // 
            this.Material_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "产品型号";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Width = 400;
            // 
            // Scan_Time
            // 
            this.Scan_Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Scan_Time.DataPropertyName = "Scan_Time";
            this.Scan_Time.HeaderText = "扫描时间";
            this.Scan_Time.Name = "Scan_Time";
            this.Scan_Time.ReadOnly = true;
            this.Scan_Time.Width = 300;
            // 
            // Material_Level
            // 
            this.Material_Level.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Material_Level.DataPropertyName = "Material_Level";
            this.Material_Level.HeaderText = "能耗等级";
            this.Material_Level.Name = "Material_Level";
            this.Material_Level.ReadOnly = true;
            this.Material_Level.Width = 200;
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImage = global::Report.Properties.Resources.button2;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageKey = "Cancel.ico";
            this.btn_Close.ImageList = this.imageList;
            this.btn_Close.Location = new System.Drawing.Point(1805, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(99, 38);
            this.btn_Close.TabIndex = 35;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Print
            // 
            this.btn_Print.BackgroundImage = global::Report.Properties.Resources.button2;
            this.btn_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Print.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Print.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.ImageKey = "Print.ico";
            this.btn_Print.ImageList = this.imageList;
            this.btn_Print.Location = new System.Drawing.Point(1706, 0);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(99, 38);
            this.btn_Print.TabIndex = 36;
            this.btn_Print.Text = "打印";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = true;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_Export
            // 
            this.btn_Export.BackgroundImage = global::Report.Properties.Resources.button2;
            this.btn_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Export.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.ImageKey = "Create.ico";
            this.btn_Export.ImageList = this.imageList;
            this.btn_Export.Location = new System.Drawing.Point(1607, 0);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(99, 38);
            this.btn_Export.TabIndex = 37;
            this.btn_Export.Text = "导出";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.BackgroundImage = global::Report.Properties.Resources.button2;
            this.btn_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Search.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btn_Search.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Search.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Search.ImageKey = "Find.ico";
            this.btn_Search.ImageList = this.imageList;
            this.btn_Search.Location = new System.Drawing.Point(1508, 0);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(99, 38);
            this.btn_Search.TabIndex = 38;
            this.btn_Search.Text = "查询";
            this.btn_Search.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // EnergyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Name = "EnergyReport";
            this.Text = "EnergyReport";
            this.Load += new System.EventHandler(this.EnergyReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Common)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgv_Common;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scan_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Level;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.DateTimePicker dt_EndTime2;
        private System.Windows.Forms.DateTimePicker dt_EndTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dt_StartTime2;
        private System.Windows.Forms.DateTimePicker dt_StartTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Close;
    }
}