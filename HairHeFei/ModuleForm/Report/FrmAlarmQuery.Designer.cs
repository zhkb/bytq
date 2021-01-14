namespace Report
{
    partial class FrmAlarmQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlarmQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dt_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dt_StartDate = new System.Windows.Forms.DateTimePicker();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.com_Equipment = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Export = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.dt_StartTime = new System.Windows.Forms.DateTimePicker();
            this.dgv_Alarm = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Alarm)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(371, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "起止时间";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dt_EndTime
            // 
            this.dt_EndTime.CustomFormat = "";
            this.dt_EndTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndTime.Location = new System.Drawing.Point(547, 3);
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
            this.dt_EndDate.Location = new System.Drawing.Point(398, 3);
            this.dt_EndDate.Name = "dt_EndDate";
            this.dt_EndDate.Size = new System.Drawing.Size(141, 29);
            this.dt_EndDate.TabIndex = 30;
            // 
            // dt_StartDate
            // 
            this.dt_StartDate.CustomFormat = "yyyy-MM-dd";
            this.dt_StartDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartDate.Location = new System.Drawing.Point(101, 3);
            this.dt_StartDate.Name = "dt_StartDate";
            this.dt_StartDate.Size = new System.Drawing.Size(141, 29);
            this.dt_StartDate.TabIndex = 28;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlTop.Controls.Add(this.com_Equipment);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.btn_Export);
            this.pnlTop.Controls.Add(this.btn_Print);
            this.pnlTop.Controls.Add(this.btn_Search);
            this.pnlTop.Controls.Add(this.btn_Close);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.dt_EndTime);
            this.pnlTop.Controls.Add(this.dt_EndDate);
            this.pnlTop.Controls.Add(this.dt_StartTime);
            this.pnlTop.Controls.Add(this.dt_StartDate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1362, 37);
            this.pnlTop.TabIndex = 6;
            // 
            // com_Equipment
            // 
            this.com_Equipment.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.com_Equipment.FormattingEnabled = true;
            this.com_Equipment.Location = new System.Drawing.Point(757, 4);
            this.com_Equipment.Name = "com_Equipment";
            this.com_Equipment.Size = new System.Drawing.Size(152, 29);
            this.com_Equipment.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(677, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 74;
            this.label3.Text = "设备名称";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_Export
            // 
            this.btn_Export.BackColor = System.Drawing.Color.White;
            this.btn_Export.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Export.BackgroundImage")));
            this.btn_Export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Export.Enabled = false;
            this.btn_Export.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Export.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Export.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Export.ImageIndex = 6;
            this.btn_Export.ImageList = this.imageList;
            this.btn_Export.Location = new System.Drawing.Point(1086, 1);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(80, 35);
            this.btn_Export.TabIndex = 73;
            this.btn_Export.Text = "导出";
            this.btn_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Export.UseVisualStyleBackColor = false;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
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
            this.imageList.Images.SetKeyName(6, "excel_64.ico");
            // 
            // btn_Print
            // 
            this.btn_Print.BackColor = System.Drawing.Color.White;
            this.btn_Print.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Print.BackgroundImage")));
            this.btn_Print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Print.Enabled = false;
            this.btn_Print.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Print.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Print.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.ImageIndex = 4;
            this.btn_Print.ImageList = this.imageList;
            this.btn_Print.Location = new System.Drawing.Point(1005, 1);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(80, 35);
            this.btn_Print.TabIndex = 38;
            this.btn_Print.Text = "打印";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
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
            this.btn_Search.Location = new System.Drawing.Point(924, 1);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(80, 35);
            this.btn_Search.TabIndex = 39;
            this.btn_Search.Text = "查询";
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
            this.btn_Close.Location = new System.Drawing.Point(1167, 1);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 35);
            this.btn_Close.TabIndex = 37;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // dt_StartTime
            // 
            this.dt_StartTime.CustomFormat = "HH:mm:ss";
            this.dt_StartTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartTime.Location = new System.Drawing.Point(248, 3);
            this.dt_StartTime.Name = "dt_StartTime";
            this.dt_StartTime.ShowUpDown = true;
            this.dt_StartTime.Size = new System.Drawing.Size(123, 29);
            this.dt_StartTime.TabIndex = 29;
            // 
            // dgv_Alarm
            // 
            this.dgv_Alarm.AllowUserToAddRows = false;
            this.dgv_Alarm.AllowUserToDeleteRows = false;
            this.dgv_Alarm.AllowUserToOrderColumns = true;
            this.dgv_Alarm.AllowUserToResizeColumns = false;
            this.dgv_Alarm.AllowUserToResizeRows = false;
            this.dgv_Alarm.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgv_Alarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Alarm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn21,
            this.Column1,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24});
            this.dgv_Alarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Alarm.Location = new System.Drawing.Point(0, 37);
            this.dgv_Alarm.Name = "dgv_Alarm";
            this.dgv_Alarm.RowHeadersVisible = false;
            this.dgv_Alarm.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Alarm.RowTemplate.Height = 30;
            this.dgv_Alarm.Size = new System.Drawing.Size(1362, 550);
            this.dgv_Alarm.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Create_Time";
            this.dataGridViewTextBoxColumn21.HeaderText = "报警时间";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 200;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Equipment_Code";
            this.Column1.HeaderText = "设备编号";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Equipment_Name";
            this.dataGridViewTextBoxColumn22.HeaderText = "设备名称";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 150;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "Alarm_Desc";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn23.HeaderText = "报警内容";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 600;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Clear_Time";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn24.HeaderText = "清除时间";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Width = 200;
            // 
            // FrmAlarmQuery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1362, 587);
            this.Controls.Add(this.dgv_Alarm);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmAlarmQuery";
            this.Text = "报警信息查询";
            this.Activated += new System.EventHandler(this.FrmAlarmQuery_Activated);
            this.Load += new System.EventHandler(this.FrmWarningQuery_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Alarm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_EndTime;
        private System.Windows.Forms.DateTimePicker dt_EndDate;
        private System.Windows.Forms.DateTimePicker dt_StartDate;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DateTimePicker dt_StartTime;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.ComboBox com_Equipment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_Alarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
    }
}