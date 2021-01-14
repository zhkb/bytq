namespace Report
{
    partial class FrmWarningQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWarningQuery));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_EndTime = new System.Windows.Forms.DateTimePicker();
            this.dt_EndDate = new System.Windows.Forms.DateTimePicker();
            this.dt_StartDate = new System.Windows.Forms.DateTimePicker();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.dt_StartTime = new System.Windows.Forms.DateTimePicker();
            this.dgvWarning = new System.Windows.Forms.DataGridView();
            this.machineid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.machinename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rectime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(710, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 35;
            this.label3.Text = "关键词";
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbKey.Location = new System.Drawing.Point(790, 24);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(157, 30);
            this.tbKey.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(384, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 33;
            this.label2.Text = "～";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnQuery.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnQuery.Image = ((System.Drawing.Image)(resources.GetObject("btnQuery.Image")));
            this.btnQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuery.Location = new System.Drawing.Point(984, 19);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(101, 39);
            this.btnQuery.TabIndex = 32;
            this.btnQuery.Text = "查询";
            this.btnQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuery.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "起止时间";
            // 
            // dt_EndTime
            // 
            this.dt_EndTime.CustomFormat = "";
            this.dt_EndTime.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndTime.Location = new System.Drawing.Point(562, 23);
            this.dt_EndTime.Name = "dt_EndTime";
            this.dt_EndTime.ShowUpDown = true;
            this.dt_EndTime.Size = new System.Drawing.Size(121, 31);
            this.dt_EndTime.TabIndex = 31;
            // 
            // dt_EndDate
            // 
            this.dt_EndDate.CustomFormat = "yyyy-MM-dd";
            this.dt_EndDate.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_EndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_EndDate.Location = new System.Drawing.Point(413, 23);
            this.dt_EndDate.Name = "dt_EndDate";
            this.dt_EndDate.Size = new System.Drawing.Size(141, 31);
            this.dt_EndDate.TabIndex = 30;
            // 
            // dt_StartDate
            // 
            this.dt_StartDate.CustomFormat = "yyyy-MM-dd";
            this.dt_StartDate.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartDate.Location = new System.Drawing.Point(116, 23);
            this.dt_StartDate.Name = "dt_StartDate";
            this.dt_StartDate.Size = new System.Drawing.Size(141, 31);
            this.dt_StartDate.TabIndex = 28;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlTop.Controls.Add(this.btnPrint);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.tbKey);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.dt_EndTime);
            this.pnlTop.Controls.Add(this.dt_EndDate);
            this.pnlTop.Controls.Add(this.dt_StartTime);
            this.pnlTop.Controls.Add(this.dt_StartDate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1235, 74);
            this.pnlTop.TabIndex = 6;
            // 
            // dt_StartTime
            // 
            this.dt_StartTime.CustomFormat = "";
            this.dt_StartTime.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dt_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_StartTime.Location = new System.Drawing.Point(263, 23);
            this.dt_StartTime.Name = "dt_StartTime";
            this.dt_StartTime.ShowUpDown = true;
            this.dt_StartTime.Size = new System.Drawing.Size(123, 31);
            this.dt_StartTime.TabIndex = 29;
            // 
            // dgvWarning
            // 
            this.dgvWarning.AllowUserToAddRows = false;
            this.dgvWarning.AllowUserToDeleteRows = false;
            this.dgvWarning.AllowUserToResizeColumns = false;
            this.dgvWarning.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvWarning.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvWarning.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dgvWarning.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWarning.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvWarning.ColumnHeadersHeight = 30;
            this.dgvWarning.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWarning.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.machineid,
            this.machinename,
            this.descr,
            this.rectime});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWarning.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarning.Location = new System.Drawing.Point(0, 74);
            this.dgvWarning.Name = "dgvWarning";
            this.dgvWarning.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWarning.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvWarning.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvWarning.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvWarning.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvWarning.RowTemplate.Height = 30;
            this.dgvWarning.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarning.Size = new System.Drawing.Size(1235, 513);
            this.dgvWarning.TabIndex = 7;
            this.dgvWarning.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_RowStateChanged);
            // 
            // machineid
            // 
            this.machineid.DataPropertyName = "machineid";
            this.machineid.HeaderText = "机台编号";
            this.machineid.Name = "machineid";
            this.machineid.ReadOnly = true;
            this.machineid.Width = 150;
            // 
            // machinename
            // 
            this.machinename.DataPropertyName = "machinename";
            this.machinename.HeaderText = "机台名称";
            this.machinename.Name = "machinename";
            this.machinename.ReadOnly = true;
            this.machinename.Width = 300;
            // 
            // descr
            // 
            this.descr.DataPropertyName = "descr";
            this.descr.HeaderText = "内容";
            this.descr.Name = "descr";
            this.descr.ReadOnly = true;
            this.descr.Width = 500;
            // 
            // rectime
            // 
            this.rectime.DataPropertyName = "rectime";
            this.rectime.HeaderText = "记录时间";
            this.rectime.Name = "rectime";
            this.rectime.ReadOnly = true;
            this.rectime.Width = 300;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(1122, 19);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(101, 39);
            this.btnPrint.TabIndex = 36;
            this.btnPrint.Text = "打印";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmWarningQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 587);
            this.Controls.Add(this.dgvWarning);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmWarningQuery";
            this.Text = "FrmWarningQuery";
            this.Load += new System.EventHandler(this.FrmWarningQuery_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt_EndTime;
        private System.Windows.Forms.DateTimePicker dt_EndDate;
        private System.Windows.Forms.DateTimePicker dt_StartDate;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DateTimePicker dt_StartTime;
        private System.Windows.Forms.DataGridView dgvWarning;
        private System.Windows.Forms.DataGridViewTextBoxColumn machineid;
        private System.Windows.Forms.DataGridViewTextBoxColumn machinename;
        private System.Windows.Forms.DataGridViewTextBoxColumn descr;
        private System.Windows.Forms.DataGridViewTextBoxColumn rectime;
        private System.Windows.Forms.Button btnPrint;
    }
}