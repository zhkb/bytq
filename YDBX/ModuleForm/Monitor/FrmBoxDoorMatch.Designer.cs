namespace Monitor
{
    partial class FrmBoxDoorMatch
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lbl_Message = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.lbl_DoorName = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.lbl_DoorCode = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.lbl_BoxName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_BoxCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_BoxBarCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Product = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCommon = new System.Windows.Forms.DataGridView();
            this.rowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Box_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Door_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_time1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_Scan = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 729);
            this.panel1.TabIndex = 0;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.lbl_Message);
            this.panel12.Controls.Add(this.label15);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 450);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(684, 200);
            this.panel12.TabIndex = 9;
            // 
            // lbl_Message
            // 
            this.lbl_Message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Message.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbl_Message.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Message.Location = new System.Drawing.Point(216, 0);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(468, 200);
            this.lbl_Message.TabIndex = 1;
            this.lbl_Message.Text = "Message";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(216, 200);
            this.label15.TabIndex = 0;
            this.label15.Text = "提示信息\r\nMessage tips";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.lbl_DoorName);
            this.panel11.Controls.Add(this.label13);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 384);
            this.panel11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(684, 66);
            this.panel11.TabIndex = 8;
            // 
            // lbl_DoorName
            // 
            this.lbl_DoorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_DoorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_DoorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DoorName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbl_DoorName.ForeColor = System.Drawing.Color.Gold;
            this.lbl_DoorName.Location = new System.Drawing.Point(216, 0);
            this.lbl_DoorName.Name = "lbl_DoorName";
            this.lbl_DoorName.Size = new System.Drawing.Size(468, 66);
            this.lbl_DoorName.TabIndex = 1;
            this.lbl_DoorName.Text = "lbl_DoorName";
            this.lbl_DoorName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(216, 66);
            this.label13.TabIndex = 0;
            this.label13.Text = "门体名称\r\nDoor Name";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.lbl_DoorCode);
            this.panel10.Controls.Add(this.label11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 321);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(684, 63);
            this.panel10.TabIndex = 7;
            // 
            // lbl_DoorCode
            // 
            this.lbl_DoorCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_DoorCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_DoorCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_DoorCode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbl_DoorCode.ForeColor = System.Drawing.Color.Gold;
            this.lbl_DoorCode.Location = new System.Drawing.Point(216, 0);
            this.lbl_DoorCode.Name = "lbl_DoorCode";
            this.lbl_DoorCode.Size = new System.Drawing.Size(468, 63);
            this.lbl_DoorCode.TabIndex = 1;
            this.lbl_DoorCode.Text = "lbl_DoorCode";
            this.lbl_DoorCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(216, 63);
            this.label11.TabIndex = 0;
            this.label11.Text = "门体编码\r\nDoor Code";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label7);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 257);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(684, 64);
            this.panel8.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label7.ForeColor = System.Drawing.Color.Aquamarine;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(684, 64);
            this.label7.TabIndex = 0;
            this.label7.Text = "门体信息\r\nDoor Information";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.lbl_BoxName);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 192);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(684, 65);
            this.panel7.TabIndex = 4;
            // 
            // lbl_BoxName
            // 
            this.lbl_BoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_BoxName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_BoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BoxName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbl_BoxName.ForeColor = System.Drawing.Color.Gold;
            this.lbl_BoxName.Location = new System.Drawing.Point(216, 0);
            this.lbl_BoxName.Name = "lbl_BoxName";
            this.lbl_BoxName.Size = new System.Drawing.Size(468, 65);
            this.lbl_BoxName.TabIndex = 1;
            this.lbl_BoxName.Text = "lbl_BoxName";
            this.lbl_BoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 65);
            this.label6.TabIndex = 0;
            this.label6.Text = "箱体名称\r\nBox Name";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lbl_BoxCode);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 127);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(684, 65);
            this.panel6.TabIndex = 3;
            // 
            // lbl_BoxCode
            // 
            this.lbl_BoxCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_BoxCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_BoxCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BoxCode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbl_BoxCode.ForeColor = System.Drawing.Color.Gold;
            this.lbl_BoxCode.Location = new System.Drawing.Point(216, 0);
            this.lbl_BoxCode.Name = "lbl_BoxCode";
            this.lbl_BoxCode.Size = new System.Drawing.Size(468, 65);
            this.lbl_BoxCode.TabIndex = 1;
            this.lbl_BoxCode.Text = "lbl_BoxCode";
            this.lbl_BoxCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 65);
            this.label2.TabIndex = 0;
            this.label2.Text = "箱体编码\r\nBox Code";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbl_BoxBarCode);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 63);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(684, 64);
            this.panel5.TabIndex = 2;
            // 
            // lbl_BoxBarCode
            // 
            this.lbl_BoxBarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_BoxBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_BoxBarCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BoxBarCode.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.lbl_BoxBarCode.ForeColor = System.Drawing.Color.Gold;
            this.lbl_BoxBarCode.Location = new System.Drawing.Point(216, 0);
            this.lbl_BoxBarCode.Name = "lbl_BoxBarCode";
            this.lbl_BoxBarCode.Size = new System.Drawing.Size(468, 64);
            this.lbl_BoxBarCode.TabIndex = 1;
            this.lbl_BoxBarCode.Text = "lbl_BoxBarCode";
            this.lbl_BoxBarCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "箱体条码\r\nBox BarCode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_Product);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 63);
            this.panel3.TabIndex = 1;
            // 
            // lbl_Product
            // 
            this.lbl_Product.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lbl_Product.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Product.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Product.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_Product.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_Product.Location = new System.Drawing.Point(0, 0);
            this.lbl_Product.Name = "lbl_Product";
            this.lbl_Product.Size = new System.Drawing.Size(684, 63);
            this.lbl_Product.TabIndex = 0;
            this.lbl_Product.Text = "箱体信息\r\nBox Information";
            this.lbl_Product.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel2.Controls.Add(this.dgvCommon);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(684, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(677, 729);
            this.panel2.TabIndex = 1;
            // 
            // dgvCommon
            // 
            this.dgvCommon.AllowUserToAddRows = false;
            this.dgvCommon.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.dgvCommon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCommon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommon.ColumnHeadersHeight = 60;
            this.dgvCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowNum,
            this.Box_BarCode,
            this.Door_Code,
            this.Create_time1});
            this.dgvCommon.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCommon.EnableHeadersVisualStyles = false;
            this.dgvCommon.GridColor = System.Drawing.Color.White;
            this.dgvCommon.Location = new System.Drawing.Point(0, 64);
            this.dgvCommon.Name = "dgvCommon";
            this.dgvCommon.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommon.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCommon.RowHeadersVisible = false;
            this.dgvCommon.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvCommon.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCommon.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.dgvCommon.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.dgvCommon.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgvCommon.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.dgvCommon.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgvCommon.RowTemplate.Height = 52;
            this.dgvCommon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCommon.Size = new System.Drawing.Size(677, 647);
            this.dgvCommon.TabIndex = 3;
            this.dgvCommon.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvCommon_RowStateChanged_1);
            // 
            // rowNum
            // 
            this.rowNum.DataPropertyName = "rowNum";
            this.rowNum.HeaderText = "   No.";
            this.rowNum.Name = "rowNum";
            this.rowNum.Width = 90;
            // 
            // Box_BarCode
            // 
            this.Box_BarCode.DataPropertyName = "Box_BarCode";
            this.Box_BarCode.HeaderText = "           箱体条码             BoxBarCode";
            this.Box_BarCode.Name = "Box_BarCode";
            this.Box_BarCode.Width = 240;
            // 
            // Door_Code
            // 
            this.Door_Code.DataPropertyName = "Door_Code";
            this.Door_Code.HeaderText = "           门体编码             DoorCode";
            this.Door_Code.Name = "Door_Code";
            this.Door_Code.Width = 230;
            // 
            // Create_time1
            // 
            this.Create_time1.DataPropertyName = "Create_time1";
            this.Create_time1.HeaderText = " 扫码时间  ScanTime";
            this.Create_time1.Name = "Create_time1";
            this.Create_time1.Width = 113;
            // 
            // panel4
            // 
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.panel4.Controls.Add(this.lbl_Scan);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(677, 64);
            this.panel4.TabIndex = 4;
            // 
            // lbl_Scan
            // 
            this.lbl_Scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lbl_Scan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Scan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Scan.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbl_Scan.ForeColor = System.Drawing.Color.Aquamarine;
            this.lbl_Scan.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_Scan.Location = new System.Drawing.Point(0, 0);
            this.lbl_Scan.Name = "lbl_Scan";
            this.lbl_Scan.Size = new System.Drawing.Size(677, 64);
            this.lbl_Scan.TabIndex = 0;
            this.lbl_Scan.Text = "箱体扫描记录\r\nBox Scan Record";
            this.lbl_Scan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmBoxDoorMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmBoxDoorMatch";
            this.Text = "FrmBoxDoorMatch";
            this.Load += new System.EventHandler(this.FrmBoxDoorMatch_Load);
            this.panel1.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lbl_Message;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label lbl_DoorName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label lbl_DoorCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbl_BoxName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbl_BoxCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_BoxBarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_Product;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_Scan;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgvCommon;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Box_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Door_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_time1;
    }
}