namespace Monitor
{
    partial class FrmDoorMaterialMonitor
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_ScanTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_MaterialName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_MaterialCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_BasketCode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chx_BD = new System.Windows.Forms.CheckBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txt_Qty = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lbl_Msg = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_select_material = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dgv_Task = new System.Windows.Forms.DataGridView();
            this.RFID_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bar_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btn_Check = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btn_ReTask = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Task)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_ScanTime);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_MaterialName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbl_MaterialCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_BasketCode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 70);
            this.panel1.TabIndex = 0;
            // 
            // lbl_ScanTime
            // 
            this.lbl_ScanTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_ScanTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ScanTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ScanTime.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ScanTime.ForeColor = System.Drawing.Color.Gold;
            this.lbl_ScanTime.Location = new System.Drawing.Point(1580, 0);
            this.lbl_ScanTime.Name = "lbl_ScanTime";
            this.lbl_ScanTime.Size = new System.Drawing.Size(324, 70);
            this.lbl_ScanTime.TabIndex = 20;
            this.lbl_ScanTime.Text = "2020-04-09 16:48:21";
            this.lbl_ScanTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1410, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 70);
            this.label2.TabIndex = 19;
            this.label2.Text = "扫描时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_MaterialName
            // 
            this.lbl_MaterialName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_MaterialName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MaterialName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_MaterialName.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MaterialName.ForeColor = System.Drawing.Color.Gold;
            this.lbl_MaterialName.Location = new System.Drawing.Point(1070, 0);
            this.lbl_MaterialName.Name = "lbl_MaterialName";
            this.lbl_MaterialName.Size = new System.Drawing.Size(340, 70);
            this.lbl_MaterialName.TabIndex = 18;
            this.lbl_MaterialName.Text = "1054-BCD-725H ";
            this.lbl_MaterialName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(900, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 70);
            this.label4.TabIndex = 17;
            this.label4.Text = "物料型号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_MaterialCode
            // 
            this.lbl_MaterialCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_MaterialCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_MaterialCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_MaterialCode.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MaterialCode.ForeColor = System.Drawing.Color.Gold;
            this.lbl_MaterialCode.Location = new System.Drawing.Point(620, 0);
            this.lbl_MaterialCode.Name = "lbl_MaterialCode";
            this.lbl_MaterialCode.Size = new System.Drawing.Size(280, 70);
            this.lbl_MaterialCode.TabIndex = 14;
            this.lbl_MaterialCode.Text = "R00001";
            this.lbl_MaterialCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(450, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 70);
            this.label1.TabIndex = 13;
            this.label1.Text = "物料编号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_BasketCode
            // 
            this.lbl_BasketCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_BasketCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_BasketCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_BasketCode.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_BasketCode.ForeColor = System.Drawing.Color.Gold;
            this.lbl_BasketCode.Location = new System.Drawing.Point(170, 0);
            this.lbl_BasketCode.Name = "lbl_BasketCode";
            this.lbl_BasketCode.Size = new System.Drawing.Size(280, 70);
            this.lbl_BasketCode.TabIndex = 12;
            this.lbl_BasketCode.Text = "B1000115";
            this.lbl_BasketCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 70);
            this.label6.TabIndex = 11;
            this.label6.Text = "工装板编号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btn_OK);
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Controls.Add(this.lbl_Msg);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1904, 70);
            this.panel2.TabIndex = 1;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel11.Controls.Add(this.panel6);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(1331, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(293, 70);
            this.panel11.TabIndex = 22;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.chx_BD);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(141, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(152, 70);
            this.panel6.TabIndex = 2;
            // 
            // chx_BD
            // 
            this.chx_BD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chx_BD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chx_BD.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chx_BD.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.chx_BD.Location = new System.Drawing.Point(0, 0);
            this.chx_BD.Name = "chx_BD";
            this.chx_BD.Size = new System.Drawing.Size(150, 68);
            this.chx_BD.TabIndex = 0;
            this.chx_BD.Text = "自动绑定";
            this.chx_BD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chx_BD.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chx_BD.UseCompatibleTextRendering = true;
            this.chx_BD.UseVisualStyleBackColor = true;
            this.chx_BD.CheckedChanged += new System.EventHandler(this.chx_BD_CheckedChanged);
            // 
            // panel12
            // 
            this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel12.Controls.Add(this.txt_Qty);
            this.panel12.Controls.Add(this.panel5);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(141, 70);
            this.panel12.TabIndex = 0;
            // 
            // txt_Qty
            // 
            this.txt_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Qty.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Qty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Qty.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Qty.ForeColor = System.Drawing.Color.Gold;
            this.txt_Qty.Location = new System.Drawing.Point(0, 15);
            this.txt_Qty.Name = "txt_Qty";
            this.txt_Qty.ReadOnly = true;
            this.txt_Qty.Size = new System.Drawing.Size(139, 39);
            this.txt_Qty.TabIndex = 6;
            this.txt_Qty.Text = "1";
            this.txt_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(139, 15);
            this.panel5.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1182, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 70);
            this.label7.TabIndex = 21;
            this.label7.Text = "数量";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_OK
            // 
            this.btn_OK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_OK.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_OK.Location = new System.Drawing.Point(1624, 0);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(140, 70);
            this.btn_OK.TabIndex = 19;
            this.btn_OK.Text = "绑定";
            this.btn_OK.UseCompatibleTextRendering = true;
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Close.BackColor = System.Drawing.Color.Firebrick;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Close.Location = new System.Drawing.Point(1764, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(140, 70);
            this.btn_Close.TabIndex = 18;
            this.btn_Close.Text = "取消";
            this.btn_Close.UseCompatibleTextRendering = true;
            this.btn_Close.UseVisualStyleBackColor = false;
            // 
            // lbl_Msg
            // 
            this.lbl_Msg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_Msg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Msg.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Msg.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Msg.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Msg.Location = new System.Drawing.Point(170, 0);
            this.lbl_Msg.Name = "lbl_Msg";
            this.lbl_Msg.Size = new System.Drawing.Size(1012, 70);
            this.lbl_Msg.TabIndex = 12;
            this.lbl_Msg.Text = "请扫描吊笼条码";
            this.lbl_Msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 70);
            this.label9.TabIndex = 11;
            this.label9.Text = "提示信息";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Controls.Add(this.panel3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 140);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1098, 901);
            this.panel7.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.AutoScrollMinSize = new System.Drawing.Size(0, 1);
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 70);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1098, 831);
            this.panel4.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_select_material);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1098, 70);
            this.panel3.TabIndex = 3;
            // 
            // btn_select_material
            // 
            this.btn_select_material.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_select_material.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_select_material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_select_material.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_select_material.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_select_material.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_select_material.Location = new System.Drawing.Point(948, 0);
            this.btn_select_material.Name = "btn_select_material";
            this.btn_select_material.Size = new System.Drawing.Size(150, 70);
            this.btn_select_material.TabIndex = 20;
            this.btn_select_material.Text = "选择";
            this.btn_select_material.UseCompatibleTextRendering = true;
            this.btn_select_material.UseVisualStyleBackColor = false;
            this.btn_select_material.Click += new System.EventHandler(this.btn_select_material_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(948, 70);
            this.label3.TabIndex = 12;
            this.label3.Text = "物料条码信息列表";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(1098, 140);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(806, 901);
            this.panel8.TabIndex = 5;
            // 
            // panel10
            // 
            this.panel10.AutoScroll = true;
            this.panel10.AutoScrollMinSize = new System.Drawing.Size(0, 1);
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel10.Controls.Add(this.dgv_Task);
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 70);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(806, 831);
            this.panel10.TabIndex = 5;
            // 
            // dgv_Task
            // 
            this.dgv_Task.AllowUserToAddRows = false;
            this.dgv_Task.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Task.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Task.ColumnHeadersHeight = 45;
            this.dgv_Task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Task.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RFID_BarCode,
            this.Material_Code,
            this.Bar_Code,
            this.Material_Name,
            this.Create_Time});
            this.dgv_Task.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Task.EnableHeadersVisualStyles = false;
            this.dgv_Task.GridColor = System.Drawing.Color.White;
            this.dgv_Task.Location = new System.Drawing.Point(0, 0);
            this.dgv_Task.Name = "dgv_Task";
            this.dgv_Task.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Task.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Task.RowHeadersWidth = 70;
            this.dgv_Task.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dgv_Task.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Task.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Task.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Task.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_Task.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Task.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_Task.RowTemplate.Height = 45;
            this.dgv_Task.RowTemplate.ReadOnly = true;
            this.dgv_Task.Size = new System.Drawing.Size(806, 761);
            this.dgv_Task.TabIndex = 2;
            this.dgv_Task.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Task_DataBindingComplete);
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
            // panel13
            // 
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.btn_Check);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 761);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(806, 70);
            this.panel13.TabIndex = 1;
            // 
            // btn_Check
            // 
            this.btn_Check.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Check.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_Check.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Check.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Check.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Check.Location = new System.Drawing.Point(664, 0);
            this.btn_Check.Name = "btn_Check";
            this.btn_Check.Size = new System.Drawing.Size(140, 68);
            this.btn_Check.TabIndex = 22;
            this.btn_Check.Text = "查看";
            this.btn_Check.UseCompatibleTextRendering = true;
            this.btn_Check.UseVisualStyleBackColor = false;
            this.btn_Check.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btn_ReTask);
            this.panel9.Controls.Add(this.label8);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(806, 70);
            this.panel9.TabIndex = 4;
            // 
            // btn_ReTask
            // 
            this.btn_ReTask.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ReTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_ReTask.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_ReTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReTask.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ReTask.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_ReTask.Location = new System.Drawing.Point(666, 0);
            this.btn_ReTask.Name = "btn_ReTask";
            this.btn_ReTask.Size = new System.Drawing.Size(140, 70);
            this.btn_ReTask.TabIndex = 21;
            this.btn_ReTask.Text = "刷新";
            this.btn_ReTask.UseCompatibleTextRendering = true;
            this.btn_ReTask.UseVisualStyleBackColor = false;
            this.btn_ReTask.Click += new System.EventHandler(this.btn_ReTask_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(806, 70);
            this.label8.TabIndex = 12;
            this.label8.Text = "任务列表";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmDoorMaterialMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDoorMaterialMonitor";
            this.Text = "FrmDoorMaterialMonitor";
            this.Load += new System.EventHandler(this.FrmDoorMaterialMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Task)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_MaterialCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_BasketCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Msg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_ScanTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_MaterialName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chx_BD;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txt_Qty;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_select_material;
        private System.Windows.Forms.Button btn_ReTask;
        private System.Windows.Forms.DataGridView dgv_Task;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btn_Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFID_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bar_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
    }
}