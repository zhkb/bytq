namespace BarReport
{
    partial class FrmBarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBarCode));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Create = new System.Windows.Forms.Button();
            this.btn_CancelAll = new System.Windows.Forms.Button();
            this.txt_PrintCount = new System.Windows.Forms.TextBox();
            this.lbl_GroupQty = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk_NoPrint = new System.Windows.Forms.CheckBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txt_SearchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BarGrid = new System.Windows.Forms.DataGridView();
            this.ItemCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Order_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prinr_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Master_Type_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detial_Type_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print_StateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Act_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order_Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Record_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarGrid)).BeginInit();
            this.SuspendLayout();
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
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btn_Add);
            this.panel3.Controls.Add(this.btn_Create);
            this.panel3.Controls.Add(this.btn_CancelAll);
            this.panel3.Controls.Add(this.txt_PrintCount);
            this.panel3.Controls.Add(this.lbl_GroupQty);
            this.panel3.Controls.Add(this.btn_Print);
            this.panel3.Controls.Add(this.btn_SelectAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 409);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1259, 37);
            this.panel3.TabIndex = 10;
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.BackColor = System.Drawing.Color.White;
            this.btn_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.BackgroundImage")));
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.Enabled = false;
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.ImageIndex = 8;
            this.btn_Add.ImageList = this.imageList;
            this.btn_Add.Location = new System.Drawing.Point(1177, 0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 35);
            this.btn_Add.TabIndex = 46;
            this.btn_Add.Text = "追加";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Create
            // 
            this.btn_Create.BackColor = System.Drawing.Color.White;
            this.btn_Create.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Create.BackgroundImage")));
            this.btn_Create.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Create.Enabled = false;
            this.btn_Create.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Create.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Create.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Create.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Create.ImageIndex = 9;
            this.btn_Create.ImageList = this.imageList;
            this.btn_Create.Location = new System.Drawing.Point(242, 1);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(80, 35);
            this.btn_Create.TabIndex = 45;
            this.btn_Create.Text = "生成";
            this.btn_Create.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Create.UseVisualStyleBackColor = false;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // btn_CancelAll
            // 
            this.btn_CancelAll.BackColor = System.Drawing.Color.White;
            this.btn_CancelAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CancelAll.BackgroundImage")));
            this.btn_CancelAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CancelAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_CancelAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_CancelAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_CancelAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CancelAll.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CancelAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CancelAll.ImageIndex = 3;
            this.btn_CancelAll.ImageList = this.imageList;
            this.btn_CancelAll.Location = new System.Drawing.Point(82, 0);
            this.btn_CancelAll.Name = "btn_CancelAll";
            this.btn_CancelAll.Size = new System.Drawing.Size(80, 35);
            this.btn_CancelAll.TabIndex = 44;
            this.btn_CancelAll.Text = "取消";
            this.btn_CancelAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CancelAll.UseVisualStyleBackColor = false;
            this.btn_CancelAll.Click += new System.EventHandler(this.btn_CancelAll_Click_1);
            // 
            // txt_PrintCount
            // 
            this.txt_PrintCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PrintCount.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_PrintCount.Location = new System.Drawing.Point(1110, 3);
            this.txt_PrintCount.Name = "txt_PrintCount";
            this.txt_PrintCount.Size = new System.Drawing.Size(66, 29);
            this.txt_PrintCount.TabIndex = 42;
            this.txt_PrintCount.Text = "1";
            this.txt_PrintCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_PrintCount_KeyPress);
            // 
            // lbl_GroupQty
            // 
            this.lbl_GroupQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_GroupQty.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lbl_GroupQty.Font = new System.Drawing.Font("宋体", 14F);
            this.lbl_GroupQty.Location = new System.Drawing.Point(1012, 3);
            this.lbl_GroupQty.Name = "lbl_GroupQty";
            this.lbl_GroupQty.Size = new System.Drawing.Size(95, 30);
            this.lbl_GroupQty.TabIndex = 43;
            this.lbl_GroupQty.Text = "数量";
            this.lbl_GroupQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_Print.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Print.ImageIndex = 7;
            this.btn_Print.ImageList = this.imageList;
            this.btn_Print.Location = new System.Drawing.Point(162, 0);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(80, 35);
            this.btn_Print.TabIndex = 40;
            this.btn_Print.Text = "打印";
            this.btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.btn_Print_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.BackColor = System.Drawing.Color.White;
            this.btn_SelectAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_SelectAll.BackgroundImage")));
            this.btn_SelectAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SelectAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_SelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_SelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SelectAll.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SelectAll.ImageIndex = 4;
            this.btn_SelectAll.ImageList = this.imageList;
            this.btn_SelectAll.Location = new System.Drawing.Point(2, 0);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(80, 35);
            this.btn_SelectAll.TabIndex = 33;
            this.btn_SelectAll.Text = "全选";
            this.btn_SelectAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SelectAll.UseVisualStyleBackColor = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chk_NoPrint);
            this.panel2.Controls.Add(this.radioButton5);
            this.panel2.Controls.Add(this.radioButton4);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.btn_Clear);
            this.panel2.Controls.Add(this.btn_Select);
            this.panel2.Controls.Add(this.txt_SearchText);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1259, 37);
            this.panel2.TabIndex = 42;
            // 
            // chk_NoPrint
            // 
            this.chk_NoPrint.AutoSize = true;
            this.chk_NoPrint.Location = new System.Drawing.Point(774, 7);
            this.chk_NoPrint.Name = "chk_NoPrint";
            this.chk_NoPrint.Size = new System.Drawing.Size(85, 23);
            this.chk_NoPrint.TabIndex = 21;
            this.chk_NoPrint.Text = "未打印";
            this.chk_NoPrint.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton5.Location = new System.Drawing.Point(351, 6);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(65, 23);
            this.radioButton5.TabIndex = 20;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "全部";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton4.Location = new System.Drawing.Point(683, 7);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(65, 23);
            this.radioButton4.TabIndex = 19;
            this.radioButton4.Text = "成品";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(597, 7);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(65, 23);
            this.radioButton3.TabIndex = 18;
            this.radioButton3.Text = "箱体";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton2.Location = new System.Drawing.Point(511, 7);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(65, 23);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.Text = "箱壳";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(425, 7);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(65, 23);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.Text = "内胆";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.White;
            this.btn_Clear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Clear.BackgroundImage")));
            this.btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Clear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clear.ImageIndex = 5;
            this.btn_Clear.ImageList = this.imageList;
            this.btn_Clear.Location = new System.Drawing.Point(947, 0);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(80, 35);
            this.btn_Clear.TabIndex = 15;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.Color.White;
            this.btn_Select.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Select.BackgroundImage")));
            this.btn_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Select.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Select.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Select.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Select.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Select.ImageIndex = 0;
            this.btn_Select.ImageList = this.imageList;
            this.btn_Select.Location = new System.Drawing.Point(867, 0);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(80, 35);
            this.btn_Select.TabIndex = 14;
            this.btn_Select.Text = "查询";
            this.btn_Select.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // txt_SearchText
            // 
            this.txt_SearchText.Font = new System.Drawing.Font("宋体", 14F);
            this.txt_SearchText.Location = new System.Drawing.Point(100, 3);
            this.txt_SearchText.Name = "txt_SearchText";
            this.txt_SearchText.Size = new System.Drawing.Size(241, 29);
            this.txt_SearchText.TabIndex = 0;
            this.txt_SearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchText_KeyPress);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 30);
            this.label1.TabIndex = 13;
            this.label1.Text = "查询条件";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BarGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 14F);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 372);
            this.panel1.TabIndex = 43;
            // 
            // BarGrid
            // 
            this.BarGrid.AllowUserToAddRows = false;
            this.BarGrid.AllowUserToResizeColumns = false;
            this.BarGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BarGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.BarGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BarGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.BarGrid.ColumnHeadersHeight = 30;
            this.BarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.BarGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemCheck,
            this.Order_Data,
            this.Prinr_State,
            this.Plan_No,
            this.Master_Type_Code,
            this.Detial_Type_Code,
            this.Order_No,
            this.Material_Code,
            this.Material_Name,
            this.Print_StateName,
            this.Plan_Qty,
            this.Create_Qty,
            this.Act_Qty,
            this.Create_BarCode,
            this.Order_Material,
            this.Record_No,
            this.Print_State});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.BarGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.BarGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BarGrid.EnableHeadersVisualStyles = false;
            this.BarGrid.Location = new System.Drawing.Point(0, 0);
            this.BarGrid.MultiSelect = false;
            this.BarGrid.Name = "BarGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BarGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.BarGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.BarGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.BarGrid.RowTemplate.Height = 30;
            this.BarGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BarGrid.Size = new System.Drawing.Size(1259, 372);
            this.BarGrid.TabIndex = 10;
            this.BarGrid.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.BarGrid_RowStateChanged);
            // 
            // ItemCheck
            // 
            this.ItemCheck.HeaderText = "选择";
            this.ItemCheck.Name = "ItemCheck";
            this.ItemCheck.Width = 60;
            // 
            // Order_Data
            // 
            this.Order_Data.DataPropertyName = "Order_Data";
            this.Order_Data.HeaderText = "订单日期";
            this.Order_Data.Name = "Order_Data";
            this.Order_Data.ReadOnly = true;
            this.Order_Data.Width = 120;
            // 
            // Prinr_State
            // 
            this.Prinr_State.DataPropertyName = "Prinr_State";
            this.Prinr_State.HeaderText = "Prinr_State";
            this.Prinr_State.Name = "Prinr_State";
            this.Prinr_State.Visible = false;
            // 
            // Plan_No
            // 
            this.Plan_No.DataPropertyName = "Plan_No";
            this.Plan_No.HeaderText = "Plan_No";
            this.Plan_No.Name = "Plan_No";
            this.Plan_No.ReadOnly = true;
            this.Plan_No.Visible = false;
            // 
            // Master_Type_Code
            // 
            this.Master_Type_Code.DataPropertyName = "Master_Type_Code";
            this.Master_Type_Code.HeaderText = "Master_Type_Code";
            this.Master_Type_Code.Name = "Master_Type_Code";
            this.Master_Type_Code.ReadOnly = true;
            this.Master_Type_Code.Visible = false;
            // 
            // Detial_Type_Code
            // 
            this.Detial_Type_Code.DataPropertyName = "Detial_Type_Code";
            this.Detial_Type_Code.HeaderText = "Detial_Type_Code";
            this.Detial_Type_Code.Name = "Detial_Type_Code";
            this.Detial_Type_Code.ReadOnly = true;
            this.Detial_Type_Code.Visible = false;
            // 
            // Order_No
            // 
            this.Order_No.DataPropertyName = "Order_No";
            this.Order_No.HeaderText = "订单编号";
            this.Order_No.Name = "Order_No";
            this.Order_No.ReadOnly = true;
            this.Order_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Order_No.Width = 150;
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "物料编号";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Material_Code.Width = 120;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "物料名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Material_Name.Width = 450;
            // 
            // Print_StateName
            // 
            this.Print_StateName.DataPropertyName = "Print_StateName";
            this.Print_StateName.HeaderText = "打印状态";
            this.Print_StateName.Name = "Print_StateName";
            this.Print_StateName.ReadOnly = true;
            this.Print_StateName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Plan_Qty
            // 
            this.Plan_Qty.DataPropertyName = "Plan_Qty";
            this.Plan_Qty.HeaderText = "需求量";
            this.Plan_Qty.Name = "Plan_Qty";
            this.Plan_Qty.ReadOnly = true;
            this.Plan_Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Plan_Qty.Width = 80;
            // 
            // Create_Qty
            // 
            this.Create_Qty.DataPropertyName = "Create_Qty";
            this.Create_Qty.HeaderText = "生成量";
            this.Create_Qty.Name = "Create_Qty";
            this.Create_Qty.ReadOnly = true;
            this.Create_Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Create_Qty.Width = 80;
            // 
            // Act_Qty
            // 
            this.Act_Qty.DataPropertyName = "Act_Qty";
            this.Act_Qty.HeaderText = "实际量";
            this.Act_Qty.Name = "Act_Qty";
            this.Act_Qty.ReadOnly = true;
            this.Act_Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Act_Qty.Width = 80;
            // 
            // Create_BarCode
            // 
            this.Create_BarCode.DataPropertyName = "Create_BarCode";
            this.Create_BarCode.HeaderText = "条码状态";
            this.Create_BarCode.Name = "Create_BarCode";
            this.Create_BarCode.ReadOnly = true;
            this.Create_BarCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Order_Material
            // 
            this.Order_Material.DataPropertyName = "Order_Material";
            this.Order_Material.HeaderText = "Order_Material";
            this.Order_Material.Name = "Order_Material";
            this.Order_Material.ReadOnly = true;
            this.Order_Material.Visible = false;
            // 
            // Record_No
            // 
            this.Record_No.DataPropertyName = "Record_No";
            this.Record_No.HeaderText = "Record_No";
            this.Record_No.Name = "Record_No";
            this.Record_No.ReadOnly = true;
            this.Record_No.Visible = false;
            // 
            // Print_State
            // 
            this.Print_State.DataPropertyName = "Print_State";
            this.Print_State.HeaderText = "Print_State";
            this.Print_State.Name = "Print_State";
            this.Print_State.ReadOnly = true;
            this.Print_State.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 446);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBarCode";
            this.Text = "条码打印";
            this.Load += new System.EventHandler(this.FrmUpSelect_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BarGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.TextBox txt_SearchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView BarGrid;
        private System.Windows.Forms.TextBox txt_PrintCount;
        private System.Windows.Forms.Label lbl_GroupQty;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Button btn_CancelAll;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Button btn_Create;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.CheckBox chk_NoPrint;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ItemCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prinr_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Master_Type_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detial_Type_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Print_StateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Act_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order_Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Record_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Print_State;
        private System.Windows.Forms.Button button1;
    }
}