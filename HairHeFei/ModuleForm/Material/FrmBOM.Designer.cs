namespace Material
{
    partial class FrmBOM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBOM));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMainClose = new System.Windows.Forms.Button();
            this.btnMainDel = new System.Windows.Forms.Button();
            this.btnMainEdit = new System.Windows.Forms.Button();
            this.btnMainAdd = new System.Windows.Forms.Button();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDetailClose = new System.Windows.Forms.Button();
            this.btnDetailDel = new System.Windows.Forms.Button();
            this.btnDetailEdit = new System.Windows.Forms.Button();
            this.btnDetailAdd = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creation_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Update_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Updated_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pro_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pro_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pro_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mater_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mater_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creation_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Update_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Update_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail_Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToResizeColumns = false;
            this.dgvMain.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvMain.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.ColumnHeadersHeight = 30;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Material_Code,
            this.Material_Name,
            this.Material_Type_Name,
            this.Creation_Date,
            this.Created_By,
            this.Last_Update_Date,
            this.Last_Updated_By,
            this.Memo});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvMain.RowTemplate.Height = 30;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(1904, 435);
            this.dgvMain.TabIndex = 49;
            this.dgvMain.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMain_DataBindingComplete);
            this.dgvMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvMain_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMainClose);
            this.panel1.Controls.Add(this.btnMainDel);
            this.panel1.Controls.Add(this.btnMainEdit);
            this.panel1.Controls.Add(this.btnMainAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 35);
            this.panel1.TabIndex = 50;
            // 
            // btnMainClose
            // 
            this.btnMainClose.BackColor = System.Drawing.Color.White;
            this.btnMainClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMainClose.BackgroundImage")));
            this.btnMainClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMainClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMainClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMainClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMainClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMainClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMainClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainClose.ImageIndex = 1;
            this.btnMainClose.ImageList = this.imageList;
            this.btnMainClose.Location = new System.Drawing.Point(240, 0);
            this.btnMainClose.Name = "btnMainClose";
            this.btnMainClose.Size = new System.Drawing.Size(80, 35);
            this.btnMainClose.TabIndex = 29;
            this.btnMainClose.Text = "关闭";
            this.btnMainClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainClose.UseVisualStyleBackColor = false;
            this.btnMainClose.Click += new System.EventHandler(this.btnMainClose_Click);
            // 
            // btnMainDel
            // 
            this.btnMainDel.BackColor = System.Drawing.Color.White;
            this.btnMainDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMainDel.BackgroundImage")));
            this.btnMainDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMainDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMainDel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMainDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMainDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMainDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMainDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainDel.ImageIndex = 8;
            this.btnMainDel.ImageList = this.imageList;
            this.btnMainDel.Location = new System.Drawing.Point(160, 0);
            this.btnMainDel.Name = "btnMainDel";
            this.btnMainDel.Size = new System.Drawing.Size(80, 35);
            this.btnMainDel.TabIndex = 28;
            this.btnMainDel.Text = "删除";
            this.btnMainDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainDel.UseVisualStyleBackColor = false;
            this.btnMainDel.Click += new System.EventHandler(this.btnMainDel_Click);
            // 
            // btnMainEdit
            // 
            this.btnMainEdit.BackColor = System.Drawing.Color.White;
            this.btnMainEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMainEdit.BackgroundImage")));
            this.btnMainEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMainEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMainEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMainEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMainEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMainEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMainEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainEdit.ImageIndex = 3;
            this.btnMainEdit.ImageList = this.imageList;
            this.btnMainEdit.Location = new System.Drawing.Point(80, 0);
            this.btnMainEdit.Name = "btnMainEdit";
            this.btnMainEdit.Size = new System.Drawing.Size(80, 35);
            this.btnMainEdit.TabIndex = 27;
            this.btnMainEdit.Text = "编辑";
            this.btnMainEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainEdit.UseVisualStyleBackColor = false;
            this.btnMainEdit.Click += new System.EventHandler(this.btnMainEdit_Click);
            // 
            // btnMainAdd
            // 
            this.btnMainAdd.BackColor = System.Drawing.Color.White;
            this.btnMainAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMainAdd.BackgroundImage")));
            this.btnMainAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMainAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMainAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMainAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMainAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMainAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMainAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMainAdd.ImageIndex = 7;
            this.btnMainAdd.ImageList = this.imageList;
            this.btnMainAdd.Location = new System.Drawing.Point(0, 0);
            this.btnMainAdd.Name = "btnMainAdd";
            this.btnMainAdd.Size = new System.Drawing.Size(80, 35);
            this.btnMainAdd.TabIndex = 24;
            this.btnMainAdd.Text = "同步";
            this.btnMainAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMainAdd.UseVisualStyleBackColor = false;
            this.btnMainAdd.Click += new System.EventHandler(this.btnMainAdd_Click);
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToResizeColumns = false;
            this.dgvDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetail.ColumnHeadersHeight = 30;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pro_ID,
            this.Pro_Code,
            this.Pro_Name,
            this.Mater_Code,
            this.Mater_Name,
            this.Material_Type,
            this.Qty,
            this.Creation_Time,
            this.Create_User,
            this.Last_Update_Time,
            this.Last_Update_User,
            this.Detail_Memo});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvDetail.Location = new System.Drawing.Point(0, 470);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvDetail.RowTemplate.Height = 30;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(1904, 435);
            this.dgvDetail.TabIndex = 51;
            this.dgvDetail.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetail_DataBindingComplete);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDetailClose);
            this.panel3.Controls.Add(this.btnDetailDel);
            this.panel3.Controls.Add(this.btnDetailEdit);
            this.panel3.Controls.Add(this.btnDetailAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 905);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1904, 35);
            this.panel3.TabIndex = 52;
            // 
            // btnDetailClose
            // 
            this.btnDetailClose.BackColor = System.Drawing.Color.White;
            this.btnDetailClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetailClose.BackgroundImage")));
            this.btnDetailClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetailClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetailClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDetailClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetailClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetailClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDetailClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailClose.ImageIndex = 1;
            this.btnDetailClose.ImageList = this.imageList;
            this.btnDetailClose.Location = new System.Drawing.Point(240, 0);
            this.btnDetailClose.Name = "btnDetailClose";
            this.btnDetailClose.Size = new System.Drawing.Size(80, 35);
            this.btnDetailClose.TabIndex = 29;
            this.btnDetailClose.Text = "关闭";
            this.btnDetailClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailClose.UseVisualStyleBackColor = false;
            this.btnDetailClose.Click += new System.EventHandler(this.btnDetailClose_Click);
            // 
            // btnDetailDel
            // 
            this.btnDetailDel.BackColor = System.Drawing.Color.White;
            this.btnDetailDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetailDel.BackgroundImage")));
            this.btnDetailDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetailDel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetailDel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDetailDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetailDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetailDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDetailDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailDel.ImageIndex = 8;
            this.btnDetailDel.ImageList = this.imageList;
            this.btnDetailDel.Location = new System.Drawing.Point(160, 0);
            this.btnDetailDel.Name = "btnDetailDel";
            this.btnDetailDel.Size = new System.Drawing.Size(80, 35);
            this.btnDetailDel.TabIndex = 28;
            this.btnDetailDel.Text = "删除";
            this.btnDetailDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailDel.UseVisualStyleBackColor = false;
            this.btnDetailDel.Click += new System.EventHandler(this.btnDetailDel_Click);
            // 
            // btnDetailEdit
            // 
            this.btnDetailEdit.BackColor = System.Drawing.Color.White;
            this.btnDetailEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetailEdit.BackgroundImage")));
            this.btnDetailEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetailEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetailEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDetailEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetailEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetailEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDetailEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailEdit.ImageIndex = 3;
            this.btnDetailEdit.ImageList = this.imageList;
            this.btnDetailEdit.Location = new System.Drawing.Point(80, 0);
            this.btnDetailEdit.Name = "btnDetailEdit";
            this.btnDetailEdit.Size = new System.Drawing.Size(80, 35);
            this.btnDetailEdit.TabIndex = 27;
            this.btnDetailEdit.Text = "编辑";
            this.btnDetailEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailEdit.UseVisualStyleBackColor = false;
            this.btnDetailEdit.Click += new System.EventHandler(this.btnDetailEdit_Click);
            // 
            // btnDetailAdd
            // 
            this.btnDetailAdd.BackColor = System.Drawing.Color.White;
            this.btnDetailAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetailAdd.BackgroundImage")));
            this.btnDetailAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetailAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetailAdd.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDetailAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnDetailAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnDetailAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetailAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDetailAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetailAdd.ImageIndex = 5;
            this.btnDetailAdd.ImageList = this.imageList;
            this.btnDetailAdd.Location = new System.Drawing.Point(0, 0);
            this.btnDetailAdd.Name = "btnDetailAdd";
            this.btnDetailAdd.Size = new System.Drawing.Size(80, 35);
            this.btnDetailAdd.TabIndex = 24;
            this.btnDetailAdd.Text = "增加";
            this.btnDetailAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetailAdd.UseVisualStyleBackColor = false;
            this.btnDetailAdd.Click += new System.EventHandler(this.btnDetailAdd_Click);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "产品编码";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Width = 120;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "产品名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Width = 200;
            // 
            // Material_Type_Name
            // 
            this.Material_Type_Name.DataPropertyName = "Material_Type_Name";
            this.Material_Type_Name.HeaderText = "物料类别";
            this.Material_Type_Name.Name = "Material_Type_Name";
            this.Material_Type_Name.ReadOnly = true;
            // 
            // Creation_Date
            // 
            this.Creation_Date.DataPropertyName = "Creation_Date";
            this.Creation_Date.HeaderText = "创建时间";
            this.Creation_Date.Name = "Creation_Date";
            this.Creation_Date.ReadOnly = true;
            this.Creation_Date.Visible = false;
            this.Creation_Date.Width = 200;
            // 
            // Created_By
            // 
            this.Created_By.DataPropertyName = "Created_By";
            this.Created_By.HeaderText = "创建人";
            this.Created_By.Name = "Created_By";
            this.Created_By.ReadOnly = true;
            this.Created_By.Visible = false;
            // 
            // Last_Update_Date
            // 
            this.Last_Update_Date.DataPropertyName = "Last_Update_Date";
            this.Last_Update_Date.HeaderText = "修改时间";
            this.Last_Update_Date.Name = "Last_Update_Date";
            this.Last_Update_Date.ReadOnly = true;
            this.Last_Update_Date.Width = 200;
            // 
            // Last_Updated_By
            // 
            this.Last_Updated_By.DataPropertyName = "Last_Updated_By";
            this.Last_Updated_By.HeaderText = "修改人";
            this.Last_Updated_By.Name = "Last_Updated_By";
            this.Last_Updated_By.ReadOnly = true;
            this.Last_Updated_By.Visible = false;
            // 
            // Memo
            // 
            this.Memo.DataPropertyName = "Memo";
            this.Memo.HeaderText = "备注";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            this.Memo.Width = 200;
            // 
            // Pro_ID
            // 
            this.Pro_ID.DataPropertyName = "ID";
            this.Pro_ID.HeaderText = "Pro_ID";
            this.Pro_ID.Name = "Pro_ID";
            this.Pro_ID.ReadOnly = true;
            this.Pro_ID.Visible = false;
            // 
            // Pro_Code
            // 
            this.Pro_Code.DataPropertyName = "Product_Code";
            this.Pro_Code.HeaderText = "产品编码";
            this.Pro_Code.Name = "Pro_Code";
            this.Pro_Code.ReadOnly = true;
            this.Pro_Code.Visible = false;
            this.Pro_Code.Width = 120;
            // 
            // Pro_Name
            // 
            this.Pro_Name.DataPropertyName = "Product_Name";
            this.Pro_Name.HeaderText = "产品名称";
            this.Pro_Name.Name = "Pro_Name";
            this.Pro_Name.ReadOnly = true;
            this.Pro_Name.Visible = false;
            this.Pro_Name.Width = 200;
            // 
            // Mater_Code
            // 
            this.Mater_Code.DataPropertyName = "Material_Code";
            this.Mater_Code.HeaderText = "物料编码";
            this.Mater_Code.Name = "Mater_Code";
            this.Mater_Code.ReadOnly = true;
            this.Mater_Code.Width = 120;
            // 
            // Mater_Name
            // 
            this.Mater_Name.DataPropertyName = "Material_Name";
            this.Mater_Name.HeaderText = "物料名称";
            this.Mater_Name.Name = "Mater_Name";
            this.Mater_Name.ReadOnly = true;
            this.Mater_Name.Width = 200;
            // 
            // Material_Type
            // 
            this.Material_Type.DataPropertyName = "Material_Type_Name";
            this.Material_Type.HeaderText = "物料类别";
            this.Material_Type.Name = "Material_Type";
            this.Material_Type.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.DataPropertyName = "Qty";
            this.Qty.HeaderText = "数量";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Creation_Time
            // 
            this.Creation_Time.DataPropertyName = "Creation_Date";
            this.Creation_Time.HeaderText = "创建时间";
            this.Creation_Time.Name = "Creation_Time";
            this.Creation_Time.ReadOnly = true;
            this.Creation_Time.Visible = false;
            this.Creation_Time.Width = 200;
            // 
            // Create_User
            // 
            this.Create_User.DataPropertyName = "Created_By";
            this.Create_User.HeaderText = "创建人";
            this.Create_User.Name = "Create_User";
            this.Create_User.ReadOnly = true;
            this.Create_User.Visible = false;
            // 
            // Last_Update_Time
            // 
            this.Last_Update_Time.DataPropertyName = "Last_Update_Date";
            this.Last_Update_Time.HeaderText = "修改时间";
            this.Last_Update_Time.Name = "Last_Update_Time";
            this.Last_Update_Time.ReadOnly = true;
            this.Last_Update_Time.Width = 200;
            // 
            // Last_Update_User
            // 
            this.Last_Update_User.DataPropertyName = "Last_Updated_By";
            this.Last_Update_User.HeaderText = "修改人";
            this.Last_Update_User.Name = "Last_Update_User";
            this.Last_Update_User.ReadOnly = true;
            this.Last_Update_User.Visible = false;
            // 
            // Detail_Memo
            // 
            this.Detail_Memo.DataPropertyName = "Memo";
            this.Detail_Memo.HeaderText = "备注";
            this.Detail_Memo.Name = "Detail_Memo";
            this.Detail_Memo.ReadOnly = true;
            this.Detail_Memo.Width = 200;
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
            this.imageList.Images.SetKeyName(6, "update.png");
            this.imageList.Images.SetKeyName(7, "Down.ico");
            this.imageList.Images.SetKeyName(8, "Delete.ico");
            this.imageList.Images.SetKeyName(9, "End.ico");
            // 
            // FrmBOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvMain);
            this.Name = "FrmBOM";
            this.Text = "BOM数据维护窗口";
            this.Load += new System.EventHandler(this.FrmBOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMainAdd;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDetailAdd;
        private System.Windows.Forms.Button btnMainClose;
        private System.Windows.Forms.Button btnMainDel;
        private System.Windows.Forms.Button btnMainEdit;
        private System.Windows.Forms.Button btnDetailClose;
        private System.Windows.Forms.Button btnDetailDel;
        private System.Windows.Forms.Button btnDetailEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Type_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creation_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Update_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Updated_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pro_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pro_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pro_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mater_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mater_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creation_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Update_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Update_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail_Memo;
        private System.Windows.Forms.ImageList imageList;
    }
}