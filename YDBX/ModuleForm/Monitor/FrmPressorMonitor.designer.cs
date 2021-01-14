namespace Monitor
{
    partial class FrmPressorMonitor
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 2D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 3D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.lbl_Completion_Rate = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.lbl_Actual_Qty = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txt_Scheduled_Qty = new System.Windows.Forms.TextBox();
            this.lbl_Scheduled_Qty = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.lbl_MessageInfo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.lbl_CompressorInfo = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lbl_Com_BarCode = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.lbl_ProductInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lbl_Pro_BarCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cht_ProductHour = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_ProductHour)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1350, 639);
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1093, 639);
            this.panel6.TabIndex = 5;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.panel17);
            this.panel8.Controls.Add(this.panel16);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(1093, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(257, 639);
            this.panel8.TabIndex = 4;
            // 
            // panel17
            // 
            this.panel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel17.Controls.Add(this.lbl_Completion_Rate);
            this.panel17.Controls.Add(this.label20);
            this.panel17.Location = new System.Drawing.Point(6, 428);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(236, 200);
            this.panel17.TabIndex = 13;
            // 
            // lbl_Completion_Rate
            // 
            this.lbl_Completion_Rate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Completion_Rate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Completion_Rate.Font = new System.Drawing.Font("微软雅黑", 40F);
            this.lbl_Completion_Rate.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Completion_Rate.Location = new System.Drawing.Point(0, 80);
            this.lbl_Completion_Rate.Name = "lbl_Completion_Rate";
            this.lbl_Completion_Rate.Size = new System.Drawing.Size(236, 120);
            this.lbl_Completion_Rate.TabIndex = 14;
            this.lbl_Completion_Rate.Text = "60%";
            this.lbl_Completion_Rate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label20.Dock = System.Windows.Forms.DockStyle.Top;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(236, 80);
            this.label20.TabIndex = 8;
            this.label20.Text = "完成率\r\nCompletion rate";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.Controls.Add(this.lbl_Actual_Qty);
            this.panel16.Controls.Add(this.label18);
            this.panel16.Location = new System.Drawing.Point(6, 217);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(236, 200);
            this.panel16.TabIndex = 12;
            // 
            // lbl_Actual_Qty
            // 
            this.lbl_Actual_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Actual_Qty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Actual_Qty.Font = new System.Drawing.Font("微软雅黑", 40F);
            this.lbl_Actual_Qty.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Actual_Qty.Location = new System.Drawing.Point(0, 80);
            this.lbl_Actual_Qty.Name = "lbl_Actual_Qty";
            this.lbl_Actual_Qty.Size = new System.Drawing.Size(236, 120);
            this.lbl_Actual_Qty.TabIndex = 14;
            this.lbl_Actual_Qty.Text = "800";
            this.lbl_Actual_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(236, 80);
            this.label18.TabIndex = 8;
            this.label18.Text = "实际产量\r\nActual qty";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel10.Controls.Add(this.txt_Scheduled_Qty);
            this.panel10.Controls.Add(this.lbl_Scheduled_Qty);
            this.panel10.Controls.Add(this.label16);
            this.panel10.Location = new System.Drawing.Point(7, 7);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(236, 200);
            this.panel10.TabIndex = 4;
            // 
            // txt_Scheduled_Qty
            // 
            this.txt_Scheduled_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.txt_Scheduled_Qty.Font = new System.Drawing.Font("微软雅黑", 40F);
            this.txt_Scheduled_Qty.ForeColor = System.Drawing.Color.Gold;
            this.txt_Scheduled_Qty.Location = new System.Drawing.Point(3, 106);
            this.txt_Scheduled_Qty.Name = "txt_Scheduled_Qty";
            this.txt_Scheduled_Qty.Size = new System.Drawing.Size(230, 78);
            this.txt_Scheduled_Qty.TabIndex = 16;
            this.txt_Scheduled_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_Scheduled_Qty.Visible = false;
            this.txt_Scheduled_Qty.DoubleClick += new System.EventHandler(this.txt_Scheduled_Qty_DoubleClick);
            // 
            // lbl_Scheduled_Qty
            // 
            this.lbl_Scheduled_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Scheduled_Qty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Scheduled_Qty.Font = new System.Drawing.Font("微软雅黑", 40F);
            this.lbl_Scheduled_Qty.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Scheduled_Qty.Location = new System.Drawing.Point(0, 80);
            this.lbl_Scheduled_Qty.Name = "lbl_Scheduled_Qty";
            this.lbl_Scheduled_Qty.Size = new System.Drawing.Size(236, 120);
            this.lbl_Scheduled_Qty.TabIndex = 15;
            this.lbl_Scheduled_Qty.Text = "1500";
            this.lbl_Scheduled_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Scheduled_Qty.DoubleClick += new System.EventHandler(this.lbl_Scheduled_Qty_DoubleClick);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(0, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(236, 80);
            this.label16.TabIndex = 8;
            this.label16.Text = "计划产量\r\nScheduled qty";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1350, 729);
            this.panel2.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel12);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1093, 639);
            this.panel4.TabIndex = 34;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.panel15);
            this.panel12.Controls.Add(this.panel18);
            this.panel12.Controls.Add(this.panel9);
            this.panel12.Controls.Add(this.label22);
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 309);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1093, 330);
            this.panel12.TabIndex = 33;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.lbl_MessageInfo);
            this.panel15.Controls.Add(this.label10);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 265);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1093, 65);
            this.panel15.TabIndex = 18;
            // 
            // lbl_MessageInfo
            // 
            this.lbl_MessageInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_MessageInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MessageInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_MessageInfo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MessageInfo.ForeColor = System.Drawing.Color.Gold;
            this.lbl_MessageInfo.Location = new System.Drawing.Point(261, 0);
            this.lbl_MessageInfo.Name = "lbl_MessageInfo";
            this.lbl_MessageInfo.Size = new System.Drawing.Size(832, 65);
            this.lbl_MessageInfo.TabIndex = 11;
            this.lbl_MessageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 65);
            this.label10.TabIndex = 10;
            this.label10.Text = "提示信息\r\nMessage tips";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.lbl_CompressorInfo);
            this.panel18.Controls.Add(this.label26);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 200);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(1093, 65);
            this.panel18.TabIndex = 17;
            // 
            // lbl_CompressorInfo
            // 
            this.lbl_CompressorInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_CompressorInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_CompressorInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_CompressorInfo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_CompressorInfo.ForeColor = System.Drawing.Color.Gold;
            this.lbl_CompressorInfo.Location = new System.Drawing.Point(261, 0);
            this.lbl_CompressorInfo.Name = "lbl_CompressorInfo";
            this.lbl_CompressorInfo.Size = new System.Drawing.Size(832, 65);
            this.lbl_CompressorInfo.TabIndex = 11;
            this.lbl_CompressorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label26.Dock = System.Windows.Forms.DockStyle.Left;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(0, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(261, 65);
            this.label26.TabIndex = 10;
            this.label26.Text = "压缩机型号\r\nCompressor model";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.lbl_Com_BarCode);
            this.panel9.Controls.Add(this.label24);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 135);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1093, 65);
            this.panel9.TabIndex = 16;
            // 
            // lbl_Com_BarCode
            // 
            this.lbl_Com_BarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Com_BarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Com_BarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Com_BarCode.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Com_BarCode.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Com_BarCode.Location = new System.Drawing.Point(261, 0);
            this.lbl_Com_BarCode.Name = "lbl_Com_BarCode";
            this.lbl_Com_BarCode.Size = new System.Drawing.Size(832, 65);
            this.lbl_Com_BarCode.TabIndex = 10;
            this.lbl_Com_BarCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(0, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(261, 65);
            this.label24.TabIndex = 9;
            this.label24.Text = "压缩机条码\r\nCompressor barcode";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Dock = System.Windows.Forms.DockStyle.Top;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(0, 130);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(1093, 5);
            this.label22.TabIndex = 15;
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.lbl_ProductInfo);
            this.panel14.Controls.Add(this.label7);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(0, 65);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(1093, 65);
            this.panel14.TabIndex = 14;
            // 
            // lbl_ProductInfo
            // 
            this.lbl_ProductInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_ProductInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ProductInfo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ProductInfo.ForeColor = System.Drawing.Color.Gold;
            this.lbl_ProductInfo.Location = new System.Drawing.Point(261, 0);
            this.lbl_ProductInfo.Name = "lbl_ProductInfo";
            this.lbl_ProductInfo.Size = new System.Drawing.Size(832, 65);
            this.lbl_ProductInfo.TabIndex = 11;
            this.lbl_ProductInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 65);
            this.label7.TabIndex = 10;
            this.label7.Text = "产品型号\r\nProduct model";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.lbl_Pro_BarCode);
            this.panel13.Controls.Add(this.label6);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1093, 65);
            this.panel13.TabIndex = 13;
            // 
            // lbl_Pro_BarCode
            // 
            this.lbl_Pro_BarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Pro_BarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Pro_BarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Pro_BarCode.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Pro_BarCode.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Pro_BarCode.Location = new System.Drawing.Point(261, 0);
            this.lbl_Pro_BarCode.Name = "lbl_Pro_BarCode";
            this.lbl_Pro_BarCode.Size = new System.Drawing.Size(832, 65);
            this.lbl_Pro_BarCode.TabIndex = 10;
            this.lbl_Pro_BarCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 65);
            this.label6.TabIndex = 9;
            this.label6.Text = "扫描条码\r\nProduct barcode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cht_ProductHour);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1093, 309);
            this.panel3.TabIndex = 35;
            // 
            // cht_ProductHour
            // 
            this.cht_ProductHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cht_ProductHour.BorderlineColor = System.Drawing.Color.Gray;
            this.cht_ProductHour.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Interval = 2D;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 12;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Cyan;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY2.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.CursorX.LineColor = System.Drawing.SystemColors.Window;
            chartArea1.CursorY.LineColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.cht_ProductHour.ChartAreas.Add(chartArea1);
            this.cht_ProductHour.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.Transparent;
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.Transparent;
            legend1.ItemColumnSpacing = 20;
            legend1.LegendItemOrder = System.Windows.Forms.DataVisualization.Charting.LegendItemOrder.SameAsSeriesOrder;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.MaximumAutoSize = 20F;
            legend1.Name = "Legend1";
            legend1.TitleForeColor = System.Drawing.Color.White;
            legend1.TitleSeparatorColor = System.Drawing.Color.White;
            this.cht_ProductHour.Legends.Add(legend1);
            this.cht_ProductHour.Location = new System.Drawing.Point(0, 0);
            this.cht_ProductHour.Name = "cht_ProductHour";
            this.cht_ProductHour.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.LimeGreen;
            series1.CustomProperties = "DrawingStyle=Cylinder";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Label = "#VAL";
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.LabelForeColor = System.Drawing.Color.LimeGreen;
            series1.Legend = "Legend1";
            series1.LegendText = "生产数量\\nProduction Qty";
            series1.Name = "ToQty";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Red;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            series2.Label = "#VAL";
            series2.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series2.LabelForeColor = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.LegendText = "不匹配数量\\nNO Match Qty";
            series2.Name = "NoQty";
            dataPoint4.IsVisibleInLegend = true;
            series2.Points.Add(dataPoint3);
            series2.Points.Add(dataPoint4);
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.cht_ProductHour.Series.Add(series1);
            this.cht_ProductHour.Series.Add(series2);
            this.cht_ProductHour.Size = new System.Drawing.Size(1093, 309);
            this.cht_ProductHour.TabIndex = 34;
            this.cht_ProductHour.Text = "cht_ProductHour";
            title1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            title1.ForeColor = System.Drawing.Color.White;
            title1.Name = "Title1";
            title1.Text = "当日小时产量统计 Hourly output of the day";
            this.cht_ProductHour.Titles.Add(title1);
            // 
            // FrmPressorMonitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmPressorMonitor";
            this.Text = "FrmProductMonitor";
            this.Load += new System.EventHandler(this.FrmPressorMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_ProductHour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label lbl_Completion_Rate;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label lbl_Actual_Qty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_Scheduled_Qty;
        private System.Windows.Forms.Label lbl_Scheduled_Qty;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_ProductHour;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label lbl_MessageInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label lbl_CompressorInfo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lbl_Com_BarCode;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label lbl_ProductInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lbl_Pro_BarCode;
        private System.Windows.Forms.Label label6;
    }
}