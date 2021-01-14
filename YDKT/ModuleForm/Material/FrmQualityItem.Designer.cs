namespace Material
{
    partial class FrmQualityItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQualityItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCommonMaster = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCommonDetail = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Detail_Del = new System.Windows.Forms.Button();
            this.btn_Detail_Add = new System.Windows.Forms.Button();
            this.btn_Detail_Edit = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Item_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Item_Name_EN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Item_Detail_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Item_Detail_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Item_Detail_Name_EN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommonMaster)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommonDetail)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCommonMaster);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(978, 1041);
            this.panel2.TabIndex = 14;
            // 
            // dgvCommonMaster
            // 
            this.dgvCommonMaster.AllowUserToAddRows = false;
            this.dgvCommonMaster.AllowUserToResizeColumns = false;
            this.dgvCommonMaster.AllowUserToResizeRows = false;
            this.dgvCommonMaster.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommonMaster.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommonMaster.ColumnHeadersHeight = 35;
            this.dgvCommonMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommonMaster.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Check_Item_Code,
            this.Check_Item_Name,
            this.Check_Item_Name_EN});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommonMaster.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCommonMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommonMaster.Location = new System.Drawing.Point(0, 40);
            this.dgvCommonMaster.MultiSelect = false;
            this.dgvCommonMaster.Name = "dgvCommonMaster";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommonMaster.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommonMaster.RowHeadersWidth = 70;
            this.dgvCommonMaster.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCommonMaster.RowTemplate.Height = 35;
            this.dgvCommonMaster.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommonMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommonMaster.Size = new System.Drawing.Size(978, 956);
            this.dgvCommonMaster.TabIndex = 16;
            this.dgvCommonMaster.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCommonMaster_DataBindingComplete);
            this.dgvCommonMaster.SelectionChanged += new System.EventHandler(this.dgvCommonMaster_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(978, 40);
            this.panel5.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(978, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "质检项信息维护列表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.btn_Del);
            this.panel3.Controls.Add(this.btn_Add);
            this.panel3.Controls.Add(this.btn_Edit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 996);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(978, 45);
            this.panel3.TabIndex = 14;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Add.ico");
            this.imageList2.Images.SetKeyName(1, "Delete.ico");
            this.imageList2.Images.SetKeyName(2, "Edit.ico");
            this.imageList2.Images.SetKeyName(3, "Exit.ico");
            this.imageList2.Images.SetKeyName(4, "Cancel.ico");
            this.imageList2.Images.SetKeyName(5, "search.png");
            // 
            // btn_Del
            // 
            this.btn_Del.BackColor = System.Drawing.Color.White;
            this.btn_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Del.BackgroundImage")));
            this.btn_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Del.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Del.ForeColor = System.Drawing.Color.White;
            this.btn_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Del.ImageIndex = 1;
            this.btn_Del.ImageList = this.imageList2;
            this.btn_Del.Location = new System.Drawing.Point(164, 2);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(80, 40);
            this.btn_Del.TabIndex = 21;
            this.btn_Del.Text = "删除";
            this.btn_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Del.UseVisualStyleBackColor = false;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.White;
            this.btn_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.BackgroundImage")));
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.ImageIndex = 0;
            this.btn_Add.ImageList = this.imageList2;
            this.btn_Add.Location = new System.Drawing.Point(2, 2);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 40);
            this.btn_Add.TabIndex = 20;
            this.btn_Add.Text = "增加";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.White;
            this.btn_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Edit.BackgroundImage")));
            this.btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Edit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Edit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit.ImageIndex = 2;
            this.btn_Edit.ImageList = this.imageList2;
            this.btn_Edit.Location = new System.Drawing.Point(83, 2);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(80, 40);
            this.btn_Edit.TabIndex = 19;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCommonDetail);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(978, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 1041);
            this.panel1.TabIndex = 15;
            // 
            // dgvCommonDetail
            // 
            this.dgvCommonDetail.AllowUserToAddRows = false;
            this.dgvCommonDetail.AllowUserToResizeColumns = false;
            this.dgvCommonDetail.AllowUserToResizeRows = false;
            this.dgvCommonDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommonDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCommonDetail.ColumnHeadersHeight = 35;
            this.dgvCommonDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommonDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Detail_ID,
            this.Check_Item_Detail_Code,
            this.Check_Item_Detail_Name,
            this.Check_Item_Detail_Name_EN});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommonDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCommonDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommonDetail.Location = new System.Drawing.Point(0, 40);
            this.dgvCommonDetail.MultiSelect = false;
            this.dgvCommonDetail.Name = "dgvCommonDetail";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommonDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCommonDetail.RowHeadersWidth = 70;
            this.dgvCommonDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCommonDetail.RowTemplate.Height = 35;
            this.dgvCommonDetail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommonDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommonDetail.Size = new System.Drawing.Size(926, 956);
            this.dgvCommonDetail.TabIndex = 17;
            this.dgvCommonDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCommonDetail_DataBindingComplete);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(926, 40);
            this.panel6.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(926, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "质检缺陷信息维护列表";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.Controls.Add(this.btn_Close);
            this.panel4.Controls.Add(this.btn_Detail_Del);
            this.panel4.Controls.Add(this.btn_Detail_Add);
            this.panel4.Controls.Add(this.btn_Detail_Edit);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 996);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(926, 45);
            this.panel4.TabIndex = 15;
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
            this.btn_Close.ImageIndex = 4;
            this.btn_Close.ImageList = this.imageList2;
            this.btn_Close.Location = new System.Drawing.Point(843, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 40);
            this.btn_Close.TabIndex = 22;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Detail_Del
            // 
            this.btn_Detail_Del.BackColor = System.Drawing.Color.White;
            this.btn_Detail_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Detail_Del.BackgroundImage")));
            this.btn_Detail_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Detail_Del.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Detail_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Del.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Detail_Del.ForeColor = System.Drawing.Color.White;
            this.btn_Detail_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Detail_Del.ImageIndex = 1;
            this.btn_Detail_Del.ImageList = this.imageList2;
            this.btn_Detail_Del.Location = new System.Drawing.Point(164, 2);
            this.btn_Detail_Del.Name = "btn_Detail_Del";
            this.btn_Detail_Del.Size = new System.Drawing.Size(80, 40);
            this.btn_Detail_Del.TabIndex = 21;
            this.btn_Detail_Del.Text = "删除";
            this.btn_Detail_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detail_Del.UseVisualStyleBackColor = false;
            this.btn_Detail_Del.Click += new System.EventHandler(this.btn_Detail_Del_Click);
            // 
            // btn_Detail_Add
            // 
            this.btn_Detail_Add.BackColor = System.Drawing.Color.White;
            this.btn_Detail_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Detail_Add.BackgroundImage")));
            this.btn_Detail_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Detail_Add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Detail_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Detail_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Detail_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Detail_Add.ImageIndex = 0;
            this.btn_Detail_Add.ImageList = this.imageList2;
            this.btn_Detail_Add.Location = new System.Drawing.Point(2, 2);
            this.btn_Detail_Add.Name = "btn_Detail_Add";
            this.btn_Detail_Add.Size = new System.Drawing.Size(80, 40);
            this.btn_Detail_Add.TabIndex = 20;
            this.btn_Detail_Add.Text = "增加";
            this.btn_Detail_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detail_Add.UseVisualStyleBackColor = false;
            this.btn_Detail_Add.Click += new System.EventHandler(this.btn_Detail_Add_Click);
            // 
            // btn_Detail_Edit
            // 
            this.btn_Detail_Edit.BackColor = System.Drawing.Color.White;
            this.btn_Detail_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Detail_Edit.BackgroundImage")));
            this.btn_Detail_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Detail_Edit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Detail_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Edit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Detail_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Detail_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Detail_Edit.ImageIndex = 2;
            this.btn_Detail_Edit.ImageList = this.imageList2;
            this.btn_Detail_Edit.Location = new System.Drawing.Point(83, 2);
            this.btn_Detail_Edit.Name = "btn_Detail_Edit";
            this.btn_Detail_Edit.Size = new System.Drawing.Size(80, 40);
            this.btn_Detail_Edit.TabIndex = 19;
            this.btn_Detail_Edit.Text = "编辑";
            this.btn_Detail_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detail_Edit.UseVisualStyleBackColor = false;
            this.btn_Detail_Edit.Click += new System.EventHandler(this.btn_Detail_Edit_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Visible = false;
            // 
            // Check_Item_Code
            // 
            this.Check_Item_Code.DataPropertyName = "Check_Item_Code";
            this.Check_Item_Code.HeaderText = "质检项编码";
            this.Check_Item_Code.Name = "Check_Item_Code";
            this.Check_Item_Code.ReadOnly = true;
            this.Check_Item_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Check_Item_Code.Width = 200;
            // 
            // Check_Item_Name
            // 
            this.Check_Item_Name.DataPropertyName = "Check_Item_Name";
            this.Check_Item_Name.HeaderText = "质检项中文名称";
            this.Check_Item_Name.Name = "Check_Item_Name";
            this.Check_Item_Name.ReadOnly = true;
            this.Check_Item_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Check_Item_Name.Width = 300;
            // 
            // Check_Item_Name_EN
            // 
            this.Check_Item_Name_EN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Check_Item_Name_EN.DataPropertyName = "Check_Item_Name_EN";
            this.Check_Item_Name_EN.HeaderText = "质检项英文名称";
            this.Check_Item_Name_EN.Name = "Check_Item_Name_EN";
            this.Check_Item_Name_EN.ReadOnly = true;
            this.Check_Item_Name_EN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Detail_ID
            // 
            this.Detail_ID.DataPropertyName = "ID";
            this.Detail_ID.HeaderText = "ID";
            this.Detail_ID.Name = "Detail_ID";
            this.Detail_ID.ReadOnly = true;
            this.Detail_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Detail_ID.Visible = false;
            // 
            // Check_Item_Detail_Code
            // 
            this.Check_Item_Detail_Code.DataPropertyName = "Check_Item_Detail_Code";
            this.Check_Item_Detail_Code.HeaderText = "质检缺陷编号";
            this.Check_Item_Detail_Code.Name = "Check_Item_Detail_Code";
            this.Check_Item_Detail_Code.ReadOnly = true;
            this.Check_Item_Detail_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Check_Item_Detail_Code.Width = 200;
            // 
            // Check_Item_Detail_Name
            // 
            this.Check_Item_Detail_Name.DataPropertyName = "Check_Item_Detail_Name";
            this.Check_Item_Detail_Name.HeaderText = "质检缺陷中文名称";
            this.Check_Item_Detail_Name.Name = "Check_Item_Detail_Name";
            this.Check_Item_Detail_Name.ReadOnly = true;
            this.Check_Item_Detail_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Check_Item_Detail_Name.Width = 300;
            // 
            // Check_Item_Detail_Name_EN
            // 
            this.Check_Item_Detail_Name_EN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Check_Item_Detail_Name_EN.DataPropertyName = "Check_Item_Detail_Name_EN";
            this.Check_Item_Detail_Name_EN.HeaderText = "质检缺陷英文名称";
            this.Check_Item_Detail_Name_EN.Name = "Check_Item_Detail_Name_EN";
            this.Check_Item_Detail_Name_EN.ReadOnly = true;
            this.Check_Item_Detail_Name_EN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmQualityItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmQualityItem";
            this.Text = "FrmQualityItem";
            this.Load += new System.EventHandler(this.FrmQualityItem_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommonMaster)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommonDetail)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Detail_Del;
        private System.Windows.Forms.Button btn_Detail_Add;
        private System.Windows.Forms.Button btn_Detail_Edit;
        private System.Windows.Forms.DataGridView dgvCommonMaster;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCommonDetail;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Item_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Item_Name_EN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Item_Detail_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Item_Detail_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Item_Detail_Name_EN;
    }
}