namespace Monitor
{
    partial class FrmQuality
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.dgv_BackProductList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_EnergyExam = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_MsgInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txt_ProductResult = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel21 = new System.Windows.Forms.Panel();
            this.lbl_CheckTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txt_MaterialCode = new System.Windows.Forms.Label();
            this.lbl_ProductCode = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txt_MaterialName = new System.Windows.Forms.Label();
            this.lbl_ProductModel = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txt_BarCode = new System.Windows.Forms.Label();
            this.lbl_ScanBarCode = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_Product = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cht_ProductHour = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BackProductList)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel21.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_ProductHour)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 539);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(954, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 539);
            this.panel2.TabIndex = 3;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.dgv_BackProductList);
            this.panel11.Controls.Add(this.lbl_EnergyExam);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(950, 539);
            this.panel11.TabIndex = 25;
            // 
            // dgv_BackProductList
            // 
            this.dgv_BackProductList.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgv_BackProductList.AllowDrop = true;
            this.dgv_BackProductList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_BackProductList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_BackProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_BackProductList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.dgv_BackProductList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_BackProductList.CausesValidation = false;
            this.dgv_BackProductList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_BackProductList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 20F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_BackProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_BackProductList.ColumnHeadersHeight = 70;
            this.dgv_BackProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_BackProductList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 20F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_BackProductList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_BackProductList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_BackProductList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgv_BackProductList.EnableHeadersVisualStyles = false;
            this.dgv_BackProductList.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgv_BackProductList.Location = new System.Drawing.Point(0, 90);
            this.dgv_BackProductList.Margin = new System.Windows.Forms.Padding(1);
            this.dgv_BackProductList.MultiSelect = false;
            this.dgv_BackProductList.Name = "dgv_BackProductList";
            this.dgv_BackProductList.ReadOnly = true;
            this.dgv_BackProductList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 20F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BackProductList.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_BackProductList.RowHeadersVisible = false;
            this.dgv_BackProductList.RowHeadersWidth = 70;
            this.dgv_BackProductList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 20F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_BackProductList.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_BackProductList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_BackProductList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.dgv_BackProductList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.dgv_BackProductList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_BackProductList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(1);
            this.dgv_BackProductList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.dgv_BackProductList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_BackProductList.RowTemplate.Height = 70;
            this.dgv_BackProductList.RowTemplate.ReadOnly = true;
            this.dgv_BackProductList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_BackProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_BackProductList.Size = new System.Drawing.Size(950, 449);
            this.dgv_BackProductList.TabIndex = 13;
            this.dgv_BackProductList.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Product_BarCode";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.FillWeight = 14.83185F;
            this.dataGridViewTextBoxColumn1.HeaderText = "条码编号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 380;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Material_Name";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.FillWeight = 284.7716F;
            this.dataGridViewTextBoxColumn2.HeaderText = "产品型号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 350;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Scan_Time";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.FillWeight = 0.3965735F;
            this.dataGridViewTextBoxColumn3.HeaderText = "扫描时间";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 155;
            // 
            // lbl_EnergyExam
            // 
            this.lbl_EnergyExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_EnergyExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_EnergyExam.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_EnergyExam.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbl_EnergyExam.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_EnergyExam.Location = new System.Drawing.Point(0, 0);
            this.lbl_EnergyExam.Name = "lbl_EnergyExam";
            this.lbl_EnergyExam.Size = new System.Drawing.Size(950, 90);
            this.lbl_EnergyExam.TabIndex = 6;
            this.lbl_EnergyExam.Text = "返修扫描记录";
            this.lbl_EnergyExam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(954, 539);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txt_MsgInfo);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 449);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(954, 90);
            this.panel5.TabIndex = 24;
            // 
            // txt_MsgInfo
            // 
            this.txt_MsgInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.txt_MsgInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MsgInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MsgInfo.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MsgInfo.ForeColor = System.Drawing.Color.Gold;
            this.txt_MsgInfo.Location = new System.Drawing.Point(169, 0);
            this.txt_MsgInfo.Name = "txt_MsgInfo";
            this.txt_MsgInfo.Size = new System.Drawing.Size(785, 90);
            this.txt_MsgInfo.TabIndex = 28;
            this.txt_MsgInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 90);
            this.label2.TabIndex = 27;
            this.label2.Text = "提示信息:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.txt_ProductResult);
            this.panel10.Controls.Add(this.panel19);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 90);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(954, 361);
            this.panel10.TabIndex = 23;
            // 
            // txt_ProductResult
            // 
            this.txt_ProductResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.txt_ProductResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ProductResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ProductResult.Font = new System.Drawing.Font("宋体", 140F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ProductResult.ForeColor = System.Drawing.Color.Lime;
            this.txt_ProductResult.Location = new System.Drawing.Point(680, 0);
            this.txt_ProductResult.Name = "txt_ProductResult";
            this.txt_ProductResult.Size = new System.Drawing.Size(274, 361);
            this.txt_ProductResult.TabIndex = 22;
            this.txt_ProductResult.Text = "OK";
            this.txt_ProductResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.panel21);
            this.panel19.Controls.Add(this.panel9);
            this.panel19.Controls.Add(this.panel8);
            this.panel19.Controls.Add(this.panel7);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(0, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(680, 361);
            this.panel19.TabIndex = 20;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.lbl_CheckTime);
            this.panel21.Controls.Add(this.label5);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 270);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(680, 90);
            this.panel21.TabIndex = 22;
            // 
            // lbl_CheckTime
            // 
            this.lbl_CheckTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_CheckTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_CheckTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_CheckTime.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CheckTime.ForeColor = System.Drawing.Color.Gold;
            this.lbl_CheckTime.Location = new System.Drawing.Point(169, 0);
            this.lbl_CheckTime.Name = "lbl_CheckTime";
            this.lbl_CheckTime.Size = new System.Drawing.Size(511, 90);
            this.lbl_CheckTime.TabIndex = 16;
            this.lbl_CheckTime.Text = "2019-10-26 13:25:58";
            this.lbl_CheckTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.label5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 90);
            this.label5.TabIndex = 4;
            this.label5.Text = "扫描时间:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txt_MaterialCode);
            this.panel9.Controls.Add(this.lbl_ProductCode);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 180);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(680, 90);
            this.panel9.TabIndex = 21;
            // 
            // txt_MaterialCode
            // 
            this.txt_MaterialCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.txt_MaterialCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MaterialCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MaterialCode.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialCode.ForeColor = System.Drawing.Color.Gold;
            this.txt_MaterialCode.Location = new System.Drawing.Point(169, 0);
            this.txt_MaterialCode.Name = "txt_MaterialCode";
            this.txt_MaterialCode.Size = new System.Drawing.Size(511, 90);
            this.txt_MaterialCode.TabIndex = 16;
            this.txt_MaterialCode.Text = "DSADNJOGFNO002";
            this.txt_MaterialCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ProductCode
            // 
            this.lbl_ProductCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_ProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ProductCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_ProductCode.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_ProductCode.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_ProductCode.Location = new System.Drawing.Point(0, 0);
            this.lbl_ProductCode.Name = "lbl_ProductCode";
            this.lbl_ProductCode.Size = new System.Drawing.Size(169, 90);
            this.lbl_ProductCode.TabIndex = 4;
            this.lbl_ProductCode.Text = "产品编码:";
            this.lbl_ProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txt_MaterialName);
            this.panel8.Controls.Add(this.lbl_ProductModel);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 90);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(680, 90);
            this.panel8.TabIndex = 20;
            // 
            // txt_MaterialName
            // 
            this.txt_MaterialName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.txt_MaterialName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_MaterialName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_MaterialName.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_MaterialName.ForeColor = System.Drawing.Color.Gold;
            this.txt_MaterialName.Location = new System.Drawing.Point(169, 0);
            this.txt_MaterialName.Name = "txt_MaterialName";
            this.txt_MaterialName.Size = new System.Drawing.Size(511, 90);
            this.txt_MaterialName.TabIndex = 15;
            this.txt_MaterialName.Text = "海尔电热水器A型B23";
            this.txt_MaterialName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ProductModel
            // 
            this.lbl_ProductModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_ProductModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ProductModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_ProductModel.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_ProductModel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_ProductModel.Location = new System.Drawing.Point(0, 0);
            this.lbl_ProductModel.Name = "lbl_ProductModel";
            this.lbl_ProductModel.Size = new System.Drawing.Size(169, 90);
            this.lbl_ProductModel.TabIndex = 2;
            this.lbl_ProductModel.Text = "产品型号:";
            this.lbl_ProductModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txt_BarCode);
            this.panel7.Controls.Add(this.lbl_ScanBarCode);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(680, 90);
            this.panel7.TabIndex = 19;
            // 
            // txt_BarCode
            // 
            this.txt_BarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.txt_BarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_BarCode.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_BarCode.ForeColor = System.Drawing.Color.Gold;
            this.txt_BarCode.Location = new System.Drawing.Point(169, 0);
            this.txt_BarCode.Name = "txt_BarCode";
            this.txt_BarCode.Size = new System.Drawing.Size(511, 90);
            this.txt_BarCode.TabIndex = 14;
            this.txt_BarCode.Text = "GA0C6DE1D0030K5M0010";
            this.txt_BarCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ScanBarCode
            // 
            this.lbl_ScanBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_ScanBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ScanBarCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_ScanBarCode.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_ScanBarCode.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lbl_ScanBarCode.Location = new System.Drawing.Point(0, 0);
            this.lbl_ScanBarCode.Name = "lbl_ScanBarCode";
            this.lbl_ScanBarCode.Size = new System.Drawing.Size(169, 90);
            this.lbl_ScanBarCode.TabIndex = 2;
            this.lbl_ScanBarCode.Text = "扫描条码:";
            this.lbl_ScanBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbl_Product);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(954, 90);
            this.panel4.TabIndex = 3;
            // 
            // lbl_Product
            // 
            this.lbl_Product.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_Product.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Product.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbl_Product.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_Product.Location = new System.Drawing.Point(0, 0);
            this.lbl_Product.Name = "lbl_Product";
            this.lbl_Product.Size = new System.Drawing.Size(954, 90);
            this.lbl_Product.TabIndex = 0;
            this.lbl_Product.Text = "返修扫描 Rework Scan";
            this.lbl_Product.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cht_ProductHour);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 539);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1904, 502);
            this.panel6.TabIndex = 3;
            // 
            // cht_ProductHour
            // 
            this.cht_ProductHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.cht_ProductHour.BorderlineColor = System.Drawing.Color.Gray;
            this.cht_ProductHour.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Interval = 2D;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Yellow;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 12;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Yellow;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkOrange;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            chartArea1.Name = "ChartArea1";
            this.cht_ProductHour.ChartAreas.Add(chartArea1);
            this.cht_ProductHour.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cht_ProductHour.Location = new System.Drawing.Point(0, 0);
            this.cht_ProductHour.Name = "cht_ProductHour";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.DodgerBlue;
            series1.CustomProperties = "DrawingStyle=Cylinder";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Label = "#VAL";
            series1.LabelForeColor = System.Drawing.Color.Yellow;
            series1.MarkerColor = System.Drawing.Color.Lime;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            this.cht_ProductHour.Series.Add(series1);
            this.cht_ProductHour.Size = new System.Drawing.Size(1904, 502);
            this.cht_ProductHour.TabIndex = 31;
            this.cht_ProductHour.Text = "cht_ProductHour";
            title1.Font = new System.Drawing.Font("微软雅黑", 20F);
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "当日合格小时产量统计 QualiFiled Hourly output of the day";
            this.cht_ProductHour.Titles.Add(title1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmQuality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQuality";
            this.Load += new System.EventHandler(this.FrmQuality_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_BackProductList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.panel21.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_ProductHour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.DataGridView dgv_BackProductList;
        private System.Windows.Forms.Label lbl_EnergyExam;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label txt_ProductResult;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label lbl_CheckTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label txt_MaterialCode;
        private System.Windows.Forms.Label lbl_ProductCode;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label txt_MaterialName;
        private System.Windows.Forms.Label lbl_ProductModel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label txt_BarCode;
        private System.Windows.Forms.Label lbl_ScanBarCode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_Product;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label txt_MsgInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_ProductHour;
        private System.Windows.Forms.Timer timer1;
    }
}