namespace Option
{
    partial class FrmSysSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSysSet));
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.edit_menu = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.add_menu = new System.Windows.Forms.Button();
            this.delete_menu = new System.Windows.Forms.Button();
            this.close_menu = new System.Windows.Forms.Button();
            this.dgv_menudata = new System.Windows.Forms.DataGridView();
            this.Menu_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu_Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu_Form = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu_Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_optiondata = new System.Windows.Forms.DataGridView();
            this.Option_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Option_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Option_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_AddOption = new System.Windows.Forms.Button();
            this.btn_EditOption = new System.Windows.Forms.Button();
            this.btn_CloseOption = new System.Windows.Forms.Button();
            this.btn_DeleteOption = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_menudata)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_optiondata)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(673, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "菜单管理";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 343);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.dgv_menudata);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(624, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(675, 343);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.edit_menu);
            this.panel5.Controls.Add(this.add_menu);
            this.panel5.Controls.Add(this.delete_menu);
            this.panel5.Controls.Add(this.close_menu);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 304);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(673, 37);
            this.panel5.TabIndex = 14;
            // 
            // edit_menu
            // 
            this.edit_menu.BackColor = System.Drawing.Color.White;
            this.edit_menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("edit_menu.BackgroundImage")));
            this.edit_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit_menu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.edit_menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.edit_menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.edit_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edit_menu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.edit_menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.edit_menu.ImageIndex = 9;
            this.edit_menu.ImageList = this.imageList1;
            this.edit_menu.Location = new System.Drawing.Point(86, 0);
            this.edit_menu.Name = "edit_menu";
            this.edit_menu.Size = new System.Drawing.Size(79, 35);
            this.edit_menu.TabIndex = 34;
            this.edit_menu.Text = "编辑";
            this.edit_menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.edit_menu.UseVisualStyleBackColor = false;
            this.edit_menu.Click += new System.EventHandler(this.edit_menu_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Chang.ico");
            this.imageList1.Images.SetKeyName(1, "Chart.ico");
            this.imageList1.Images.SetKeyName(2, "Check.ico");
            this.imageList1.Images.SetKeyName(3, "Clear.ico");
            this.imageList1.Images.SetKeyName(4, "Config.ico");
            this.imageList1.Images.SetKeyName(5, "Create.ico");
            this.imageList1.Images.SetKeyName(6, "Delete.ico");
            this.imageList1.Images.SetKeyName(7, "Down.ico");
            this.imageList1.Images.SetKeyName(8, "DownLoad.ico");
            this.imageList1.Images.SetKeyName(9, "Edit.ico");
            this.imageList1.Images.SetKeyName(10, "End.ico");
            this.imageList1.Images.SetKeyName(11, "Execute.ico");
            this.imageList1.Images.SetKeyName(12, "ok.ico");
            this.imageList1.Images.SetKeyName(13, "Stop.ico");
            this.imageList1.Images.SetKeyName(14, "Add1.ico");
            this.imageList1.Images.SetKeyName(15, "Add.ico");
            this.imageList1.Images.SetKeyName(16, "Cancel.ico");
            // 
            // add_menu
            // 
            this.add_menu.BackColor = System.Drawing.Color.White;
            this.add_menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("add_menu.BackgroundImage")));
            this.add_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.add_menu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.add_menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.add_menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.add_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_menu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add_menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.add_menu.ImageIndex = 15;
            this.add_menu.ImageList = this.imageList1;
            this.add_menu.Location = new System.Drawing.Point(7, 0);
            this.add_menu.Name = "add_menu";
            this.add_menu.Size = new System.Drawing.Size(79, 35);
            this.add_menu.TabIndex = 33;
            this.add_menu.Text = "添加";
            this.add_menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.add_menu.UseVisualStyleBackColor = false;
            this.add_menu.Click += new System.EventHandler(this.add_menu_Click_1);
            // 
            // delete_menu
            // 
            this.delete_menu.BackColor = System.Drawing.Color.White;
            this.delete_menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delete_menu.BackgroundImage")));
            this.delete_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.delete_menu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.delete_menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.delete_menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.delete_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete_menu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delete_menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delete_menu.ImageIndex = 6;
            this.delete_menu.ImageList = this.imageList1;
            this.delete_menu.Location = new System.Drawing.Point(165, 0);
            this.delete_menu.Name = "delete_menu";
            this.delete_menu.Size = new System.Drawing.Size(79, 35);
            this.delete_menu.TabIndex = 31;
            this.delete_menu.Text = "删除";
            this.delete_menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.delete_menu.UseVisualStyleBackColor = false;
            this.delete_menu.Click += new System.EventHandler(this.delete_menu_Click_1);
            // 
            // close_menu
            // 
            this.close_menu.BackColor = System.Drawing.Color.White;
            this.close_menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("close_menu.BackgroundImage")));
            this.close_menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.close_menu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.close_menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.close_menu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.close_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close_menu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close_menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.close_menu.ImageIndex = 16;
            this.close_menu.ImageList = this.imageList1;
            this.close_menu.Location = new System.Drawing.Point(244, 0);
            this.close_menu.Name = "close_menu";
            this.close_menu.Size = new System.Drawing.Size(79, 35);
            this.close_menu.TabIndex = 32;
            this.close_menu.Text = "关闭";
            this.close_menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.close_menu.UseVisualStyleBackColor = false;
            this.close_menu.Click += new System.EventHandler(this.close_menu_Click_1);
            // 
            // dgv_menudata
            // 
            this.dgv_menudata.AllowUserToAddRows = false;
            this.dgv_menudata.AllowUserToDeleteRows = false;
            this.dgv_menudata.AllowUserToResizeColumns = false;
            this.dgv_menudata.AllowUserToResizeRows = false;
            this.dgv_menudata.BackgroundColor = System.Drawing.Color.White;
            this.dgv_menudata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_menudata.ColumnHeadersHeight = 30;
            this.dgv_menudata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_menudata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Menu_Code,
            this.Menu_Name,
            this.Menu_Source,
            this.Menu_Form,
            this.Menu_Sort,
            this.Remark1});
            this.dgv_menudata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_menudata.Location = new System.Drawing.Point(0, 35);
            this.dgv_menudata.MultiSelect = false;
            this.dgv_menudata.Name = "dgv_menudata";
            this.dgv_menudata.RowHeadersWidth = 55;
            this.dgv_menudata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_menudata.RowTemplate.Height = 30;
            this.dgv_menudata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_menudata.Size = new System.Drawing.Size(673, 306);
            this.dgv_menudata.TabIndex = 22;
            this.dgv_menudata.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_menudata_RowStateChanged);
            // 
            // Menu_Code
            // 
            this.Menu_Code.DataPropertyName = "Menu_Code";
            this.Menu_Code.HeaderText = "菜单编码";
            this.Menu_Code.Name = "Menu_Code";
            this.Menu_Code.ReadOnly = true;
            this.Menu_Code.Width = 120;
            // 
            // Menu_Name
            // 
            this.Menu_Name.DataPropertyName = "Menu_Name";
            this.Menu_Name.HeaderText = "菜单名称";
            this.Menu_Name.Name = "Menu_Name";
            this.Menu_Name.ReadOnly = true;
            this.Menu_Name.Width = 120;
            // 
            // Menu_Source
            // 
            this.Menu_Source.DataPropertyName = "Menu_Source";
            this.Menu_Source.HeaderText = "菜单资源";
            this.Menu_Source.Name = "Menu_Source";
            this.Menu_Source.ReadOnly = true;
            this.Menu_Source.Width = 120;
            // 
            // Menu_Form
            // 
            this.Menu_Form.DataPropertyName = "Menu_Form";
            this.Menu_Form.HeaderText = "窗体名称";
            this.Menu_Form.Name = "Menu_Form";
            this.Menu_Form.ReadOnly = true;
            this.Menu_Form.Width = 120;
            // 
            // Menu_Sort
            // 
            this.Menu_Sort.DataPropertyName = "Menu_Sort";
            this.Menu_Sort.HeaderText = "序号";
            this.Menu_Sort.Name = "Menu_Sort";
            this.Menu_Sort.ReadOnly = true;
            this.Menu_Sort.Width = 80;
            // 
            // Remark1
            // 
            this.Remark1.DataPropertyName = "Remark";
            this.Remark1.HeaderText = "备注";
            this.Remark1.Name = "Remark1";
            this.Remark1.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgv_optiondata);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(624, 343);
            this.panel3.TabIndex = 0;
            // 
            // dgv_optiondata
            // 
            this.dgv_optiondata.AllowUserToAddRows = false;
            this.dgv_optiondata.AllowUserToDeleteRows = false;
            this.dgv_optiondata.AllowUserToResizeColumns = false;
            this.dgv_optiondata.AllowUserToResizeRows = false;
            this.dgv_optiondata.BackgroundColor = System.Drawing.Color.White;
            this.dgv_optiondata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_optiondata.ColumnHeadersHeight = 30;
            this.dgv_optiondata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_optiondata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Option_Code,
            this.Option_Name,
            this.Option_Value,
            this.Remark});
            this.dgv_optiondata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_optiondata.Location = new System.Drawing.Point(0, 35);
            this.dgv_optiondata.MultiSelect = false;
            this.dgv_optiondata.Name = "dgv_optiondata";
            this.dgv_optiondata.RowHeadersWidth = 55;
            this.dgv_optiondata.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_optiondata.RowTemplate.Height = 30;
            this.dgv_optiondata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_optiondata.Size = new System.Drawing.Size(622, 269);
            this.dgv_optiondata.TabIndex = 22;
            this.dgv_optiondata.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_optiondata_RowStateChanged);
            // 
            // Option_Code
            // 
            this.Option_Code.DataPropertyName = "Option_Code";
            this.Option_Code.HeaderText = "编号";
            this.Option_Code.Name = "Option_Code";
            this.Option_Code.ReadOnly = true;
            this.Option_Code.Width = 120;
            // 
            // Option_Name
            // 
            this.Option_Name.DataPropertyName = "Option_Name";
            this.Option_Name.HeaderText = "名称";
            this.Option_Name.Name = "Option_Name";
            this.Option_Name.ReadOnly = true;
            this.Option_Name.Width = 120;
            // 
            // Option_Value
            // 
            this.Option_Value.DataPropertyName = "Option_Value";
            this.Option_Value.HeaderText = "数值";
            this.Option_Value.Name = "Option_Value";
            this.Option_Value.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 160;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(622, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "选项管理";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_AddOption);
            this.panel1.Controls.Add(this.btn_EditOption);
            this.panel1.Controls.Add(this.btn_CloseOption);
            this.panel1.Controls.Add(this.btn_DeleteOption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 304);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 37);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btn_AddOption
            // 
            this.btn_AddOption.BackColor = System.Drawing.Color.White;
            this.btn_AddOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AddOption.BackgroundImage")));
            this.btn_AddOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_AddOption.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_AddOption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_AddOption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_AddOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddOption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_AddOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_AddOption.ImageIndex = 15;
            this.btn_AddOption.ImageList = this.imageList1;
            this.btn_AddOption.Location = new System.Drawing.Point(3, 0);
            this.btn_AddOption.Name = "btn_AddOption";
            this.btn_AddOption.Size = new System.Drawing.Size(79, 35);
            this.btn_AddOption.TabIndex = 29;
            this.btn_AddOption.Text = "添加";
            this.btn_AddOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_AddOption.UseVisualStyleBackColor = false;
            this.btn_AddOption.Click += new System.EventHandler(this.btn_AddOption_Click_1);
            // 
            // btn_EditOption
            // 
            this.btn_EditOption.BackColor = System.Drawing.Color.White;
            this.btn_EditOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_EditOption.BackgroundImage")));
            this.btn_EditOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_EditOption.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_EditOption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_EditOption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_EditOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditOption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_EditOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_EditOption.ImageIndex = 9;
            this.btn_EditOption.ImageList = this.imageList1;
            this.btn_EditOption.Location = new System.Drawing.Point(82, 0);
            this.btn_EditOption.Name = "btn_EditOption";
            this.btn_EditOption.Size = new System.Drawing.Size(79, 35);
            this.btn_EditOption.TabIndex = 29;
            this.btn_EditOption.Text = "编辑";
            this.btn_EditOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_EditOption.UseVisualStyleBackColor = false;
            this.btn_EditOption.Click += new System.EventHandler(this.btn_EditOption_Click_1);
            // 
            // btn_CloseOption
            // 
            this.btn_CloseOption.BackColor = System.Drawing.Color.White;
            this.btn_CloseOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_CloseOption.BackgroundImage")));
            this.btn_CloseOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CloseOption.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_CloseOption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_CloseOption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_CloseOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CloseOption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_CloseOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_CloseOption.ImageIndex = 16;
            this.btn_CloseOption.ImageList = this.imageList1;
            this.btn_CloseOption.Location = new System.Drawing.Point(240, 0);
            this.btn_CloseOption.Name = "btn_CloseOption";
            this.btn_CloseOption.Size = new System.Drawing.Size(79, 35);
            this.btn_CloseOption.TabIndex = 28;
            this.btn_CloseOption.Text = "关闭";
            this.btn_CloseOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_CloseOption.UseVisualStyleBackColor = false;
            this.btn_CloseOption.Click += new System.EventHandler(this.btn_CloseOption_Click_1);
            // 
            // btn_DeleteOption
            // 
            this.btn_DeleteOption.BackColor = System.Drawing.Color.White;
            this.btn_DeleteOption.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_DeleteOption.BackgroundImage")));
            this.btn_DeleteOption.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_DeleteOption.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_DeleteOption.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_DeleteOption.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_DeleteOption.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_DeleteOption.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_DeleteOption.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_DeleteOption.ImageIndex = 6;
            this.btn_DeleteOption.ImageList = this.imageList1;
            this.btn_DeleteOption.Location = new System.Drawing.Point(161, 0);
            this.btn_DeleteOption.Name = "btn_DeleteOption";
            this.btn_DeleteOption.Size = new System.Drawing.Size(79, 35);
            this.btn_DeleteOption.TabIndex = 27;
            this.btn_DeleteOption.Text = "删除";
            this.btn_DeleteOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_DeleteOption.UseVisualStyleBackColor = false;
            this.btn_DeleteOption.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // FrmSysSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1299, 343);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmSysSet";
            this.Text = "选项设置";
            this.Load += new System.EventHandler(this.FrmSysSet_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_menudata)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_optiondata)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgv_menudata;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgv_optiondata;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btn_DeleteOption;
        private System.Windows.Forms.Button btn_CloseOption;
        private System.Windows.Forms.Button btn_EditOption;
        private System.Windows.Forms.Button btn_AddOption;
        private System.Windows.Forms.Button edit_menu;
        private System.Windows.Forms.Button add_menu;
        private System.Windows.Forms.Button delete_menu;
        private System.Windows.Forms.Button close_menu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Form;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option_Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}