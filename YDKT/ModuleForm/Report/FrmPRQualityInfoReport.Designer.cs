namespace Report
{
    partial class FrmPRQualityInfoReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPRQualityInfoReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_print = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dt_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dt_StartTime = new System.Windows.Forms.DateTimePicker();
            this.dt_StartDate = new System.Windows.Forms.DateTimePicker();
            this.btn_Select = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgv_weightinfo = new System.Windows.Forms.DataGridView();
            this.Product_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scan_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_weightinfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btn_print);
            this.panel7.Controls.Add(this.label3);
            this.panel7.Controls.Add(this.txt_Key);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Controls.Add(this.label1);
            this.panel7.Controls.Add(this.dt_EndTime);
            this.panel7.Controls.Add(this.dt_EndDate);
            this.panel7.Controls.Add(this.dt_StartTime);
            this.panel7.Controls.Add(this.dt_StartDate);
            this.panel7.Controls.Add(this.btn_Select);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1924, 66);
            this.panel7.TabIndex = 48;
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.White;
            this.btn_print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_print.BackgroundImage")));
            this.btn_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_print.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_print.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_print.ImageIndex = 7;
            this.btn_print.ImageList = this.imageList1;
            this.btn_print.Location = new System.Drawing.Point(1491, -2);
            this.btn_print.Margin = new System.Windows.Forms.Padding(4);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(120, 60);
            this.btn_print.TabIndex = 74;
            this.btn_print.Text = "打印";
            this.btn_print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(988, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 72;
            this.label3.Text = "关键词";
            // 
            // txt_Key
            // 
            this.txt_Key.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Key.Location = new System.Drawing.Point(1083, 9);
            this.txt_Key.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Key.Name = "txt_Key";
            this.txt_Key.Size = new System.Drawing.Size(234, 39);
            this.txt_Key.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(536, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 31);
            this.label2.TabIndex = 70;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 65;
            this.label1.Text = "起止时间";
            // 
            // dt_EndTime
            // 
            this.dt_EndTime.CustomFormat = "";
            this.dt_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndTime.Location = new System.Drawing.Point(798, 8);
            this.dt_EndTime.Margin = new System.Windows.Forms.Padding(4);
            this.dt_EndTime.Name = "dt_EndTime";
            this.dt_EndTime.ShowUpDown = true;
            this.dt_EndTime.Size = new System.Drawing.Size(180, 39);
            this.dt_EndTime.TabIndex = 69;
            // 
            // dt_EndDate
            // 
            this.dt_EndDate.CustomFormat = "yyyy-MM-dd";
            this.dt_EndDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndDate.Location = new System.Drawing.Point(579, 8);
            this.dt_EndDate.Margin = new System.Windows.Forms.Padding(4);
            this.dt_EndDate.Name = "dt_EndDate";
            this.dt_EndDate.Size = new System.Drawing.Size(210, 39);
            this.dt_EndDate.TabIndex = 68;
            // 
            // dt_StartTime
            // 
            this.dt_StartTime.CustomFormat = "";
            this.dt_StartTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartTime.Location = new System.Drawing.Point(354, 8);
            this.dt_StartTime.Margin = new System.Windows.Forms.Padding(4);
            this.dt_StartTime.Name = "dt_StartTime";
            this.dt_StartTime.ShowUpDown = true;
            this.dt_StartTime.Size = new System.Drawing.Size(182, 39);
            this.dt_StartTime.TabIndex = 67;
            // 
            // dt_StartDate
            // 
            this.dt_StartDate.CustomFormat = "yyyy-MM-dd";
            this.dt_StartDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartDate.Location = new System.Drawing.Point(134, 8);
            this.dt_StartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dt_StartDate.Name = "dt_StartDate";
            this.dt_StartDate.Size = new System.Drawing.Size(210, 39);
            this.dt_StartDate.TabIndex = 66;
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.Color.White;
            this.btn_Select.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Select.BackgroundImage")));
            this.btn_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Select.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Select.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Select.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Select.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Select.ImageIndex = 8;
            this.btn_Select.ImageList = this.imageList;
            this.btn_Select.Location = new System.Drawing.Point(1362, 0);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(120, 60);
            this.btn_Select.TabIndex = 64;
            this.btn_Select.Text = "查询";
            this.btn_Select.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_Close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 984);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1924, 66);
            this.panel3.TabIndex = 50;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.BackgroundImage")));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList;
            this.btn_Close.Location = new System.Drawing.Point(6, 4);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(120, 60);
            this.btn_Close.TabIndex = 65;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.ico");
            this.imageList.Images.SetKeyName(1, "Cancel.ico");
            this.imageList.Images.SetKeyName(2, "User.ico");
            this.imageList.Images.SetKeyName(3, "edit.ico");
            this.imageList.Images.SetKeyName(4, "Add1.ico");
            this.imageList.Images.SetKeyName(5, "Add.ico");
            this.imageList.Images.SetKeyName(6, "Delete.ico");
            this.imageList.Images.SetKeyName(7, "Clear.ico");
            this.imageList.Images.SetKeyName(8, "Find.ico");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Find.ico");
            this.imageList1.Images.SetKeyName(1, "Down.ico");
            this.imageList1.Images.SetKeyName(2, "Up.ico");
            this.imageList1.Images.SetKeyName(3, "Cancel.ico");
            this.imageList1.Images.SetKeyName(4, "Check.ico");
            this.imageList1.Images.SetKeyName(5, "Clear.ico");
            this.imageList1.Images.SetKeyName(6, "ok.ico");
            this.imageList1.Images.SetKeyName(7, "Print.ico");
            this.imageList1.Images.SetKeyName(8, "Add1.ico");
            this.imageList1.Images.SetKeyName(9, "Create.ico");
            this.imageList1.Images.SetKeyName(10, "Config.ico");
            // 
            // dgv_weightinfo
            // 
            this.dgv_weightinfo.AllowUserToAddRows = false;
            this.dgv_weightinfo.AllowUserToDeleteRows = false;
            this.dgv_weightinfo.AllowUserToResizeColumns = false;
            this.dgv_weightinfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_weightinfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_weightinfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_weightinfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_weightinfo.ColumnHeadersHeight = 30;
            this.dgv_weightinfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_weightinfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_BarCode,
            this.Process_Name,
            this.Material_Code,
            this.Material_Name,
            this.Scan_Time,
            this.Check_Result});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_weightinfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_weightinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_weightinfo.Location = new System.Drawing.Point(0, 66);
            this.dgv_weightinfo.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_weightinfo.Name = "dgv_weightinfo";
            this.dgv_weightinfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_weightinfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_weightinfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_weightinfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_weightinfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_weightinfo.RowTemplate.Height = 30;
            this.dgv_weightinfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_weightinfo.Size = new System.Drawing.Size(1924, 918);
            this.dgv_weightinfo.TabIndex = 51;
            // 
            // Product_BarCode
            // 
            this.Product_BarCode.DataPropertyName = "Product_BarCode";
            this.Product_BarCode.HeaderText = "产品条码";
            this.Product_BarCode.Name = "Product_BarCode";
            this.Product_BarCode.ReadOnly = true;
            this.Product_BarCode.Width = 150;
            // 
            // Process_Name
            // 
            this.Process_Name.DataPropertyName = "Process_Name";
            this.Process_Name.HeaderText = "工位编号";
            this.Process_Name.Name = "Process_Name";
            this.Process_Name.ReadOnly = true;
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "物料编码";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Width = 150;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "物料名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Width = 150;
            // 
            // Scan_Time
            // 
            this.Scan_Time.DataPropertyName = "Scan_Time";
            this.Scan_Time.HeaderText = "扫描时间";
            this.Scan_Time.Name = "Scan_Time";
            this.Scan_Time.ReadOnly = true;
            this.Scan_Time.Width = 200;
            // 
            // Check_Result
            // 
            this.Check_Result.DataPropertyName = "Check_Result";
            this.Check_Result.HeaderText = "安检结果";
            this.Check_Result.Name = "Check_Result";
            this.Check_Result.ReadOnly = true;
            this.Check_Result.Width = 200;
            // 
            // FrmPRQualityInfoReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.dgv_weightinfo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel7);
            this.Name = "FrmPRQualityInfoReport";
            this.Text = "信息统计";
            this.Load += new System.EventHandler(this.FrmPRQualityInfoReport_Load);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_weightinfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_EndTime;
        private System.Windows.Forms.DateTimePicker dt_EndDate;
        private System.Windows.Forms.DateTimePicker dt_StartTime;
        private System.Windows.Forms.DateTimePicker dt_StartDate;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dgv_weightinfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Scan_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Result;
    }
}