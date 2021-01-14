namespace FoamingMaterial
{
    partial class FrmFoaming
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFoaming));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txt_SearchText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FoamingGrid = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.MaterialGrid = new System.Windows.Forms.DataGridView();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_AllDel = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.Foaming_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Foaming_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FoamingGrid)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialGrid)).BeginInit();
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
            this.imageList.Images.SetKeyName(10, "Save.ico");
            this.imageList.Images.SetKeyName(11, "Delete.ico");
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_Clear);
            this.panel2.Controls.Add(this.btn_Select);
            this.panel2.Controls.Add(this.txt_SearchText);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1327, 37);
            this.panel2.TabIndex = 43;
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
            this.btn_Clear.Location = new System.Drawing.Point(427, 0);
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
            this.btn_Select.Location = new System.Drawing.Point(347, 0);
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
            this.panel1.Controls.Add(this.FoamingGrid);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.MaterialGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1327, 580);
            this.panel1.TabIndex = 46;
            // 
            // FoamingGrid
            // 
            this.FoamingGrid.AllowUserToAddRows = false;
            this.FoamingGrid.AllowUserToResizeColumns = false;
            this.FoamingGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FoamingGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.FoamingGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FoamingGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.FoamingGrid.ColumnHeadersHeight = 30;
            this.FoamingGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.FoamingGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Foaming_Code,
            this.Foaming_Name,
            this.Plan_Qty,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FoamingGrid.DefaultCellStyle = dataGridViewCellStyle13;
            this.FoamingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FoamingGrid.EnableHeadersVisualStyles = false;
            this.FoamingGrid.Location = new System.Drawing.Point(639, 0);
            this.FoamingGrid.MultiSelect = false;
            this.FoamingGrid.Name = "FoamingGrid";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FoamingGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.FoamingGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.FoamingGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.FoamingGrid.RowTemplate.Height = 30;
            this.FoamingGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.FoamingGrid.Size = new System.Drawing.Size(688, 580);
            this.FoamingGrid.TabIndex = 55;
            this.FoamingGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FoamingGrid_CellDoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_Save);
            this.panel4.Controls.Add(this.btn_AllDel);
            this.panel4.Controls.Add(this.btn_Del);
            this.panel4.Controls.Add(this.btn_OK);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(548, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(91, 580);
            this.panel4.TabIndex = 53;
            // 
            // btn_Del
            // 
            this.btn_Del.BackColor = System.Drawing.Color.White;
            this.btn_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Del.BackgroundImage")));
            this.btn_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Del.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Del.ImageIndex = 11;
            this.btn_Del.ImageList = this.imageList;
            this.btn_Del.Location = new System.Drawing.Point(5, 107);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(80, 35);
            this.btn_Del.TabIndex = 16;
            this.btn_Del.Text = "删除";
            this.btn_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Del.UseVisualStyleBackColor = false;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackColor = System.Drawing.Color.White;
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OK.ImageIndex = 4;
            this.btn_OK.ImageList = this.imageList;
            this.btn_OK.Location = new System.Drawing.Point(5, 45);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(80, 35);
            this.btn_OK.TabIndex = 15;
            this.btn_OK.Text = "选择";
            this.btn_OK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // MaterialGrid
            // 
            this.MaterialGrid.AllowUserToAddRows = false;
            this.MaterialGrid.AllowUserToResizeColumns = false;
            this.MaterialGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaterialGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.MaterialGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MaterialGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.MaterialGrid.ColumnHeadersHeight = 30;
            this.MaterialGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MaterialGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Material_Code,
            this.Material_Name});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MaterialGrid.DefaultCellStyle = dataGridViewCellStyle18;
            this.MaterialGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.MaterialGrid.EnableHeadersVisualStyles = false;
            this.MaterialGrid.Location = new System.Drawing.Point(0, 0);
            this.MaterialGrid.MultiSelect = false;
            this.MaterialGrid.Name = "MaterialGrid";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MaterialGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.MaterialGrid.RowHeadersVisible = false;
            this.MaterialGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            this.MaterialGrid.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.MaterialGrid.RowTemplate.Height = 30;
            this.MaterialGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MaterialGrid.Size = new System.Drawing.Size(548, 580);
            this.MaterialGrid.TabIndex = 46;
            this.MaterialGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MaterialGrid_CellDoubleClick);
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
            this.Material_Name.Width = 400;
            // 
            // btn_AllDel
            // 
            this.btn_AllDel.BackColor = System.Drawing.Color.White;
            this.btn_AllDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AllDel.BackgroundImage")));
            this.btn_AllDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AllDel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AllDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_AllDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_AllDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AllDel.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_AllDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AllDel.ImageIndex = 11;
            this.btn_AllDel.ImageList = this.imageList;
            this.btn_AllDel.Location = new System.Drawing.Point(5, 163);
            this.btn_AllDel.Name = "btn_AllDel";
            this.btn_AllDel.Size = new System.Drawing.Size(80, 35);
            this.btn_AllDel.TabIndex = 17;
            this.btn_AllDel.Text = "全删";
            this.btn_AllDel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_AllDel.UseVisualStyleBackColor = false;
            this.btn_AllDel.Click += new System.EventHandler(this.btn_AllDel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.White;
            this.btn_Save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Save.BackgroundImage")));
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.ImageIndex = 10;
            this.btn_Save.ImageList = this.imageList;
            this.btn_Save.Location = new System.Drawing.Point(5, 218);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(80, 35);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.Text = "保存";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Foaming_Code
            // 
            this.Foaming_Code.DataPropertyName = "Material_Code";
            this.Foaming_Code.HeaderText = "物料编号";
            this.Foaming_Code.Name = "Foaming_Code";
            this.Foaming_Code.ReadOnly = true;
            this.Foaming_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Foaming_Code.Width = 120;
            // 
            // Foaming_Name
            // 
            this.Foaming_Name.DataPropertyName = "Material_Name";
            this.Foaming_Name.HeaderText = "物料名称";
            this.Foaming_Name.Name = "Foaming_Name";
            this.Foaming_Name.ReadOnly = true;
            this.Foaming_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Foaming_Name.Width = 400;
            // 
            // Plan_Qty
            // 
            this.Plan_Qty.DataPropertyName = "Plan_Qty";
            this.Plan_Qty.HeaderText = "计划数量";
            this.Plan_Qty.Name = "Plan_Qty";
            this.Plan_Qty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Display_Flag";
            this.dataGridViewTextBoxColumn4.HeaderText = "显示";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // FrmFoaming
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 617);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmFoaming";
            this.Text = "发泡计划维护";
            this.Load += new System.EventHandler(this.FrmFoaming_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FoamingGrid)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MaterialGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.TextBox txt_SearchText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView MaterialGrid;
        private System.Windows.Forms.DataGridView FoamingGrid;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.Button btn_AllDel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.DataGridViewTextBoxColumn Foaming_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Foaming_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}

