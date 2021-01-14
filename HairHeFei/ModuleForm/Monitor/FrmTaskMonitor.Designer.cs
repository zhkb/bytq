namespace Monitor
{
    partial class FrmTaskMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_SystemTitle = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dgv_Out_Task = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chart_OutTask = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dgv_In_Task = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chart_InTask = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RFID_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bar_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Out_Task)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_OutTask)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_In_Task)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_InTask)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbl_SystemTitle);
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.lbl_Time);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1920, 82);
            this.panel4.TabIndex = 39;
            // 
            // lbl_SystemTitle
            // 
            this.lbl_SystemTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_SystemTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SystemTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_SystemTitle.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbl_SystemTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_SystemTitle.Location = new System.Drawing.Point(200, 0);
            this.lbl_SystemTitle.Name = "lbl_SystemTitle";
            this.lbl_SystemTitle.Size = new System.Drawing.Size(1521, 80);
            this.lbl_SystemTitle.TabIndex = 41;
            this.lbl_SystemTitle.Text = "合肥冰箱门壳输送系统";
            this.lbl_SystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel11.Controls.Add(this.pictureBox1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(200, 80);
            this.panel11.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.pictureBox1.Image = global::Monitor.Properties.Resources.HAIRLOGO_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(24, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lbl_Time
            // 
            this.lbl_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Time.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Location = new System.Drawing.Point(1721, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(197, 80);
            this.lbl_Time.TabIndex = 1;
            this.lbl_Time.Text = "2017-08-17 16:48:21";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 998);
            this.panel1.TabIndex = 40;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(991, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 998);
            this.panel2.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel10.Controls.Add(this.dgv_Out_Task);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 479);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(929, 519);
            this.panel10.TabIndex = 4;
            // 
            // dgv_Out_Task
            // 
            this.dgv_Out_Task.AllowUserToAddRows = false;
            this.dgv_Out_Task.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Out_Task.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Out_Task.ColumnHeadersHeight = 45;
            this.dgv_Out_Task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Out_Task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgv_Out_Task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Out_Task.EnableHeadersVisualStyles = false;
            this.dgv_Out_Task.Location = new System.Drawing.Point(0, 0);
            this.dgv_Out_Task.Name = "dgv_Out_Task";
            this.dgv_Out_Task.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Out_Task.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Out_Task.RowHeadersWidth = 70;
            this.dgv_Out_Task.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dgv_Out_Task.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Out_Task.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Out_Task.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Out_Task.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_Out_Task.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Out_Task.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_Out_Task.RowTemplate.Height = 45;
            this.dgv_Out_Task.RowTemplate.ReadOnly = true;
            this.dgv_Out_Task.Size = new System.Drawing.Size(927, 517);
            this.dgv_Out_Task.TabIndex = 3;
            this.dgv_Out_Task.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Out_Task_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "RFID_BarCode";
            this.dataGridViewTextBoxColumn1.HeaderText = "吊笼编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Material_Code";
            this.dataGridViewTextBoxColumn2.HeaderText = "产品编号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Bar_Code";
            this.dataGridViewTextBoxColumn3.HeaderText = "产品条码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 170;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Material_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "产品型号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Create_Time";
            this.dataGridViewTextBoxColumn5.HeaderText = "时间";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label2);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 419);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(929, 60);
            this.panel8.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(929, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = "出库任务";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.chart_OutTask);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(929, 419);
            this.panel6.TabIndex = 2;
            // 
            // chart_OutTask
            // 
            this.chart_OutTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            chartArea1.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea1.AxisX.Crossing = -1.7976931348623157E+308D;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gold;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Gold;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gold;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gold;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.Minimum = 1D;
            chartArea1.AxisX2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gold;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Gold;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gold;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Gold;
            chartArea1.BackColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chart_OutTask.ChartAreas.Add(chartArea1);
            this.chart_OutTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_OutTask.Location = new System.Drawing.Point(0, 0);
            this.chart_OutTask.Name = "chart_OutTask";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "EmptyPointValue=Zero";
            series1.EmptyPointStyle.IsValueShownAsLabel = true;
            series1.EmptyPointStyle.LabelForeColor = System.Drawing.Color.White;
            series1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Name = "Series1";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chart_OutTask.Series.Add(series1);
            this.chart_OutTask.Size = new System.Drawing.Size(927, 417);
            this.chart_OutTask.TabIndex = 1;
            this.chart_OutTask.Text = "chart2";
            title1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            title1.ForeColor = System.Drawing.Color.Aqua;
            title1.Name = "Title1";
            title1.Text = "出库任务小时统计";
            this.chart_OutTask.Titles.Add(title1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(991, 998);
            this.panel3.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.dgv_In_Task);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 479);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(991, 519);
            this.panel9.TabIndex = 3;
            // 
            // dgv_In_Task
            // 
            this.dgv_In_Task.AllowUserToAddRows = false;
            this.dgv_In_Task.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_In_Task.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_In_Task.ColumnHeadersHeight = 45;
            this.dgv_In_Task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_In_Task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RFID_BarCode,
            this.Material_Code,
            this.Bar_Code,
            this.Material_Name,
            this.Create_Time});
            this.dgv_In_Task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_In_Task.EnableHeadersVisualStyles = false;
            this.dgv_In_Task.Location = new System.Drawing.Point(0, 0);
            this.dgv_In_Task.Name = "dgv_In_Task";
            this.dgv_In_Task.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_In_Task.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_In_Task.RowHeadersWidth = 70;
            this.dgv_In_Task.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dgv_In_Task.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_In_Task.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_In_Task.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_In_Task.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_In_Task.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_In_Task.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_In_Task.RowTemplate.Height = 45;
            this.dgv_In_Task.RowTemplate.ReadOnly = true;
            this.dgv_In_Task.Size = new System.Drawing.Size(989, 517);
            this.dgv_In_Task.TabIndex = 3;
            this.dgv_In_Task.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_In_Task_DataBindingComplete);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 419);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(991, 60);
            this.panel7.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(991, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "入库任务";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.chart_InTask);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(991, 419);
            this.panel5.TabIndex = 1;
            // 
            // chart_InTask
            // 
            this.chart_InTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            chartArea2.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.Triangle;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Gold;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisX.ScaleBreakStyle.BreakLineStyle = System.Windows.Forms.DataVisualization.Charting.BreakLineStyle.None;
            chartArea2.AxisX.ScaleBreakStyle.Enabled = true;
            chartArea2.AxisX.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea2.AxisX.ScaleBreakStyle.Spacing = 1D;
            chartArea2.AxisX.ScaleBreakStyle.StartFromZero = System.Windows.Forms.DataVisualization.Charting.StartFromZero.Yes;
            chartArea2.AxisX.ScaleView.MinSize = 0D;
            chartArea2.AxisX.ScaleView.MinSizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.ScaleView.SizeType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX2.MajorGrid.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisX2.MajorTickMark.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisX2.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea2.AxisX2.Minimum = 1D;
            chartArea2.AxisX2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX2.ScaleBreakStyle.MaxNumberOfBreaks = 1;
            chartArea2.AxisX2.ScaleBreakStyle.Spacing = 1D;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Gold;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisY.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea2.AxisY.MinorTickMark.Enabled = true;
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisY2.MajorGrid.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Gold;
            chartArea2.AxisY2.MajorTickMark.TickMarkStyle = System.Windows.Forms.DataVisualization.Charting.TickMarkStyle.InsideArea;
            chartArea2.AxisY2.MinorGrid.Enabled = true;
            chartArea2.AxisY2.MinorTickMark.Enabled = true;
            chartArea2.BackColor = System.Drawing.Color.Gray;
            chartArea2.Name = "ChartArea1";
            this.chart_InTask.ChartAreas.Add(chartArea2);
            this.chart_InTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_InTask.Location = new System.Drawing.Point(0, 0);
            this.chart_InTask.Name = "chart_InTask";
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "EmptyPointValue=Zero";
            series2.EmptyPointStyle.IsValueShownAsLabel = true;
            series2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Name = "Series1";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chart_InTask.Series.Add(series2);
            this.chart_InTask.Size = new System.Drawing.Size(989, 417);
            this.chart_InTask.TabIndex = 0;
            this.chart_InTask.Text = "chart1";
            title2.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            title2.ForeColor = System.Drawing.Color.Aqua;
            title2.Name = "Title1";
            title2.Text = "入库任务小时统计";
            this.chart_InTask.Titles.Add(title2);
            // 
            // RFID_BarCode
            // 
            this.RFID_BarCode.DataPropertyName = "RFID_BarCode";
            this.RFID_BarCode.HeaderText = "吊笼编号";
            this.RFID_BarCode.Name = "RFID_BarCode";
            this.RFID_BarCode.ReadOnly = true;
            this.RFID_BarCode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RFID_BarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RFID_BarCode.Width = 120;
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "产品编号";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Material_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Material_Code.Visible = false;
            // 
            // Bar_Code
            // 
            this.Bar_Code.DataPropertyName = "Bar_Code";
            this.Bar_Code.HeaderText = "产品条码";
            this.Bar_Code.Name = "Bar_Code";
            this.Bar_Code.ReadOnly = true;
            this.Bar_Code.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bar_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bar_Code.Width = 170;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "产品型号";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Material_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Material_Name.Width = 200;
            // 
            // Create_Time
            // 
            this.Create_Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            this.Create_Time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Create_Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmTaskMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTaskMonitor";
            this.Text = "FrmTaskMonitor";
            this.Load += new System.EventHandler(this.FrmTaskMonitor_Load);
            this.panel4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Out_Task)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_OutTask)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_In_Task)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_InTask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_SystemTitle;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridView dgv_Out_Task;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_OutTask;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DataGridView dgv_In_Task;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_InTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFID_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bar_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
    }
}