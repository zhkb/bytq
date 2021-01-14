namespace Material
{
    partial class FrmMaterial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterial));
            this.panel3 = new System.Windows.Forms.Panel();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Add = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCommon = new System.Windows.Forms.DataGridView();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.Material_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modify_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Updated_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.btn_Close);
            this.panel3.Controls.Add(this.btn_Del);
            this.panel3.Controls.Add(this.btn_Edit);
            this.panel3.Controls.Add(this.btn_Add);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 679);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1350, 50);
            this.panel3.TabIndex = 12;
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
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.White;
            this.btn_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Add.BackgroundImage")));
            this.btn_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.ImageIndex = 0;
            this.btn_Add.ImageList = this.imageList2;
            this.btn_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 50);
            this.btn_Add.TabIndex = 19;
            this.btn_Add.Text = "增加\r\nAdd";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCommon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1350, 679);
            this.panel2.TabIndex = 13;
            // 
            // dgvCommon
            // 
            this.dgvCommon.AllowUserToAddRows = false;
            this.dgvCommon.AllowUserToResizeColumns = false;
            this.dgvCommon.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCommon.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCommon.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCommon.ColumnHeadersHeight = 50;
            this.dgvCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Material_ID,
            this.Material_Type_Name,
            this.Material_Code,
            this.Material_Name,
            this.Material_Spec,
            this.Material_Unit,
            this.Remark,
            this.Material_Image,
            this.Create_Time,
            this.Created_By,
            this.Modify_Time,
            this.Last_Updated_By});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommon.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommon.Location = new System.Drawing.Point(0, 0);
            this.dgvCommon.MultiSelect = false;
            this.dgvCommon.Name = "dgvCommon";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommon.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCommon.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCommon.RowTemplate.Height = 35;
            this.dgvCommon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommon.Size = new System.Drawing.Size(1350, 679);
            this.dgvCommon.TabIndex = 10;
            this.dgvCommon.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_RowStateChanged);
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.White;
            this.btn_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Edit.BackgroundImage")));
            this.btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Edit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Edit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit.ImageIndex = 2;
            this.btn_Edit.ImageList = this.imageList2;
            this.btn_Edit.Location = new System.Drawing.Point(80, 0);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(80, 50);
            this.btn_Edit.TabIndex = 23;
            this.btn_Edit.Text = "编辑\r\nEdit";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.BackColor = System.Drawing.Color.White;
            this.btn_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Del.BackgroundImage")));
            this.btn_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Del.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Del.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Del.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Del.ForeColor = System.Drawing.Color.White;
            this.btn_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Del.ImageIndex = 1;
            this.btn_Del.ImageList = this.imageList2;
            this.btn_Del.Location = new System.Drawing.Point(160, 0);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(80, 50);
            this.btn_Del.TabIndex = 24;
            this.btn_Del.Text = "删除\r\nDelete";
            this.btn_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Del.UseVisualStyleBackColor = false;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.BackgroundImage")));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 4;
            this.btn_Close.ImageList = this.imageList2;
            this.btn_Close.Location = new System.Drawing.Point(240, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 50);
            this.btn_Close.TabIndex = 25;
            this.btn_Close.Text = "关闭\r\nClose";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // Material_ID
            // 
            this.Material_ID.DataPropertyName = "Material_ID";
            this.Material_ID.HeaderText = "Material_ID";
            this.Material_ID.Name = "Material_ID";
            this.Material_ID.ReadOnly = true;
            this.Material_ID.Visible = false;
            // 
            // Material_Type_Name
            // 
            this.Material_Type_Name.DataPropertyName = "Material_Type_Name";
            this.Material_Type_Name.HeaderText = "物料类别 Type";
            this.Material_Type_Name.Name = "Material_Type_Name";
            this.Material_Type_Name.ReadOnly = true;
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "物料编码       Material code";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Width = 150;
            // 
            // Material_Name
            // 
            this.Material_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "物料名称                                  Material Name";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            // 
            // Material_Spec
            // 
            this.Material_Spec.DataPropertyName = "Material_Spec";
            this.Material_Spec.HeaderText = "规格        Specification";
            this.Material_Spec.Name = "Material_Spec";
            this.Material_Spec.ReadOnly = true;
            this.Material_Spec.Width = 150;
            // 
            // Material_Unit
            // 
            this.Material_Unit.DataPropertyName = "Material_Unit";
            this.Material_Unit.HeaderText = "单位    Unit";
            this.Material_Unit.Name = "Material_Unit";
            this.Material_Unit.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "物料描述                                Material description";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // Material_Image
            // 
            this.Material_Image.DataPropertyName = "Material_Image";
            this.Material_Image.HeaderText = "图片";
            this.Material_Image.Name = "Material_Image";
            this.Material_Image.Visible = false;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            this.Create_Time.Visible = false;
            this.Create_Time.Width = 200;
            // 
            // Created_By
            // 
            this.Created_By.DataPropertyName = "Created_By";
            this.Created_By.HeaderText = "创建人";
            this.Created_By.Name = "Created_By";
            this.Created_By.ReadOnly = true;
            this.Created_By.Visible = false;
            // 
            // Modify_Time
            // 
            this.Modify_Time.DataPropertyName = "Modify_Time";
            this.Modify_Time.HeaderText = "修改时间               Modify time";
            this.Modify_Time.Name = "Modify_Time";
            this.Modify_Time.ReadOnly = true;
            this.Modify_Time.Width = 200;
            // 
            // Last_Updated_By
            // 
            this.Last_Updated_By.DataPropertyName = "Last_Updated_By";
            this.Last_Updated_By.HeaderText = "修改人   Modify By";
            this.Last_Updated_By.Name = "Last_Updated_By";
            this.Last_Updated_By.ReadOnly = true;
            // 
            // FrmMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "FrmMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "物料数据维护窗口";
            this.Activated += new System.EventHandler(this.FrmMaterial_Activated);
            this.Load += new System.EventHandler(this.FrmMaterial_Load);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCommon;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Del;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Type_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modify_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Updated_By;
    }
}

