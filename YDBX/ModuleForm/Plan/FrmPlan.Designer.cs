namespace Plan
{
    partial class FrmPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPlan));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_Recipe = new System.Windows.Forms.DataGridView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dgv_Material = new System.Windows.Forms.DataGridView();
            this.Material_Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Type_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tolerance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipe_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipe_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipe_TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipe_Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total_Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Actual_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Recipe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Material)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Controls.Add(this.btn_Del);
            this.panel2.Controls.Add(this.btn_Add);
            this.panel2.Controls.Add(this.btn_Edit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 671);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1334, 45);
            this.panel2.TabIndex = 47;
            this.panel2.Visible = false;
            // 
            // dgv_Recipe
            // 
            this.dgv_Recipe.AllowUserToAddRows = false;
            this.dgv_Recipe.AllowUserToResizeColumns = false;
            this.dgv_Recipe.AllowUserToResizeRows = false;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Recipe.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Recipe.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Recipe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_Recipe.ColumnHeadersHeight = 35;
            this.dgv_Recipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Recipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Plan_No,
            this.Plan_Date,
            this.Recipe_Code,
            this.Recipe_Name,
            this.Recipe_TypeName,
            this.Recipe_Version,
            this.Total_Weight,
            this.Plan_Status,
            this.Plan_Qty,
            this.Actual_Qty,
            this.Start_Time,
            this.Create_Time,
            this.Create_UserName,
            this.Update_Time,
            this.Update_UserName});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Recipe.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_Recipe.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgv_Recipe.Location = new System.Drawing.Point(0, 0);
            this.dgv_Recipe.MultiSelect = false;
            this.dgv_Recipe.Name = "dgv_Recipe";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Recipe.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_Recipe.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_Recipe.RowTemplate.Height = 35;
            this.dgv_Recipe.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Recipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Recipe.Size = new System.Drawing.Size(1334, 281);
            this.dgv_Recipe.TabIndex = 48;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 281);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1334, 5);
            this.splitter1.TabIndex = 50;
            this.splitter1.TabStop = false;
            // 
            // dgv_Material
            // 
            this.dgv_Material.AllowUserToAddRows = false;
            this.dgv_Material.AllowUserToResizeColumns = false;
            this.dgv_Material.AllowUserToResizeRows = false;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Material.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_Material.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Material.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_Material.ColumnHeadersHeight = 35;
            this.dgv_Material.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Material.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Material_Type_Name,
            this.Material_Type_Code,
            this.Material_Code,
            this.Material_Name,
            this.Material_Spec,
            this.Weight,
            this.Tolerance});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Material.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgv_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Material.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Material.Location = new System.Drawing.Point(0, 286);
            this.dgv_Material.MultiSelect = false;
            this.dgv_Material.Name = "dgv_Material";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Material.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_Material.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dgv_Material.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Material.RowTemplate.Height = 35;
            this.dgv_Material.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Material.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Material.Size = new System.Drawing.Size(1334, 385);
            this.dgv_Material.TabIndex = 51;
            // 
            // Material_Type_Name
            // 
            this.Material_Type_Name.DataPropertyName = "Material_Type_Name";
            this.Material_Type_Name.HeaderText = "物料类别";
            this.Material_Type_Name.Name = "Material_Type_Name";
            this.Material_Type_Name.ReadOnly = true;
            // 
            // Material_Type_Code
            // 
            this.Material_Type_Code.DataPropertyName = "Material_Type_Code";
            this.Material_Type_Code.HeaderText = "Material_Type_Code";
            this.Material_Type_Code.Name = "Material_Type_Code";
            this.Material_Type_Code.ReadOnly = true;
            this.Material_Type_Code.Visible = false;
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "物料编码";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Material_Code.Width = 150;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "物料名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Width = 200;
            // 
            // Material_Spec
            // 
            this.Material_Spec.DataPropertyName = "Material_Spec";
            this.Material_Spec.HeaderText = "规格";
            this.Material_Spec.Name = "Material_Spec";
            this.Material_Spec.ReadOnly = true;
            this.Material_Spec.Width = 150;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            dataGridViewCellStyle17.Format = "N3";
            dataGridViewCellStyle17.NullValue = "0";
            this.Weight.DefaultCellStyle = dataGridViewCellStyle17;
            this.Weight.HeaderText = "重量(Kg)";
            this.Weight.Name = "Weight";
            // 
            // Tolerance
            // 
            this.Tolerance.DataPropertyName = "Tolerance";
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = "0";
            this.Tolerance.DefaultCellStyle = dataGridViewCellStyle18;
            this.Tolerance.HeaderText = "误差(Kg)";
            this.Tolerance.Name = "Tolerance";
            // 
            // Plan_No
            // 
            this.Plan_No.DataPropertyName = "Plan_No";
            this.Plan_No.HeaderText = "计划编号";
            this.Plan_No.Name = "Plan_No";
            this.Plan_No.ReadOnly = true;
            this.Plan_No.Width = 200;
            // 
            // Plan_Date
            // 
            this.Plan_Date.DataPropertyName = "Plan_Date";
            this.Plan_Date.HeaderText = "计划日期";
            this.Plan_Date.Name = "Plan_Date";
            this.Plan_Date.ReadOnly = true;
            this.Plan_Date.Width = 150;
            // 
            // Recipe_Code
            // 
            this.Recipe_Code.DataPropertyName = "Recipe_Code";
            this.Recipe_Code.HeaderText = "配方编号";
            this.Recipe_Code.Name = "Recipe_Code";
            this.Recipe_Code.ReadOnly = true;
            this.Recipe_Code.Width = 150;
            // 
            // Recipe_Name
            // 
            this.Recipe_Name.DataPropertyName = "Recipe_Name";
            this.Recipe_Name.HeaderText = "配方名称";
            this.Recipe_Name.Name = "Recipe_Name";
            this.Recipe_Name.ReadOnly = true;
            this.Recipe_Name.Width = 200;
            // 
            // Recipe_TypeName
            // 
            this.Recipe_TypeName.DataPropertyName = "Recipe_TypeName";
            this.Recipe_TypeName.HeaderText = "配方类型";
            this.Recipe_TypeName.Name = "Recipe_TypeName";
            this.Recipe_TypeName.ReadOnly = true;
            // 
            // Recipe_Version
            // 
            this.Recipe_Version.DataPropertyName = "Recipe_Version";
            this.Recipe_Version.HeaderText = "配方版本";
            this.Recipe_Version.Name = "Recipe_Version";
            this.Recipe_Version.ReadOnly = true;
            // 
            // Total_Weight
            // 
            this.Total_Weight.DataPropertyName = "Total_Weight";
            this.Total_Weight.HeaderText = "配方总重";
            this.Total_Weight.Name = "Total_Weight";
            this.Total_Weight.ReadOnly = true;
            this.Total_Weight.Visible = false;
            // 
            // Plan_Status
            // 
            this.Plan_Status.DataPropertyName = "Plan_Status";
            this.Plan_Status.HeaderText = "计划状态";
            this.Plan_Status.Name = "Plan_Status";
            this.Plan_Status.ReadOnly = true;
            // 
            // Plan_Qty
            // 
            this.Plan_Qty.DataPropertyName = "Plan_Qty";
            this.Plan_Qty.HeaderText = "计划数量";
            this.Plan_Qty.Name = "Plan_Qty";
            this.Plan_Qty.ReadOnly = true;
            // 
            // Actual_Qty
            // 
            this.Actual_Qty.DataPropertyName = "Actual_Qty";
            this.Actual_Qty.HeaderText = "完成数量";
            this.Actual_Qty.Name = "Actual_Qty";
            this.Actual_Qty.ReadOnly = true;
            // 
            // Start_Time
            // 
            this.Start_Time.DataPropertyName = "Start_Time";
            this.Start_Time.HeaderText = "开始时间";
            this.Start_Time.Name = "Start_Time";
            this.Start_Time.ReadOnly = true;
            this.Start_Time.Width = 200;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            this.Create_Time.Width = 200;
            // 
            // Create_UserName
            // 
            this.Create_UserName.DataPropertyName = "Create_UserName";
            this.Create_UserName.HeaderText = "创建人";
            this.Create_UserName.Name = "Create_UserName";
            this.Create_UserName.ReadOnly = true;
            // 
            // Update_Time
            // 
            this.Update_Time.DataPropertyName = "Update_Time";
            this.Update_Time.HeaderText = "Update_Time";
            this.Update_Time.Name = "Update_Time";
            this.Update_Time.ReadOnly = true;
            this.Update_Time.Visible = false;
            // 
            // Update_UserName
            // 
            this.Update_UserName.DataPropertyName = "Update_UserName";
            this.Update_UserName.HeaderText = "Update_UserName";
            this.Update_UserName.Name = "Update_UserName";
            this.Update_UserName.ReadOnly = true;
            this.Update_UserName.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Add.ico");
            this.imageList1.Images.SetKeyName(1, "Delete.ico");
            this.imageList1.Images.SetKeyName(2, "Edit.ico");
            this.imageList1.Images.SetKeyName(3, "Exit.ico");
            this.imageList1.Images.SetKeyName(4, "Cancel.ico");
            this.imageList1.Images.SetKeyName(5, "Save.ico");
            this.imageList1.Images.SetKeyName(6, "Check.ico");
            this.imageList1.Images.SetKeyName(7, "Add1.ico");
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.White;
            this.btn_Save.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Save.BackgroundImage")));
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.ImageIndex = 5;
            this.btn_Save.ImageList = this.imageList1;
            this.btn_Save.Location = new System.Drawing.Point(163, 3);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(80, 40);
            this.btn_Save.TabIndex = 32;
            this.btn_Save.Text = "保存";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.UseVisualStyleBackColor = false;
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
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(323, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 40);
            this.btn_Close.TabIndex = 31;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
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
            this.btn_Del.ImageList = this.imageList1;
            this.btn_Del.Location = new System.Drawing.Point(243, 3);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(80, 40);
            this.btn_Del.TabIndex = 30;
            this.btn_Del.Text = "删除";
            this.btn_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Del.UseVisualStyleBackColor = false;
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
            this.btn_Add.ImageList = this.imageList1;
            this.btn_Add.Location = new System.Drawing.Point(3, 3);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 40);
            this.btn_Add.TabIndex = 29;
            this.btn_Add.Text = "增加";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = false;
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
            this.btn_Edit.ImageList = this.imageList1;
            this.btn_Edit.Location = new System.Drawing.Point(83, 3);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(80, 40);
            this.btn_Edit.TabIndex = 28;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.UseVisualStyleBackColor = false;
            // 
            // FrmPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 716);
            this.Controls.Add(this.dgv_Material);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dgv_Recipe);
            this.Controls.Add(this.panel2);
            this.Name = "FrmPlan";
            this.Text = "计划管理";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Recipe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Material)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_Recipe;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dgv_Material;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Type_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Type_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tolerance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipe_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipe_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipe_TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipe_Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total_Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Actual_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_UserName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Edit;
    }
}