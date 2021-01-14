namespace Authority
{
    partial class FrmAuthority
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuthority));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_User = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_BatchSave = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.pnl_Bottom = new System.Windows.Forms.Panel();
            this.pnl_Module = new System.Windows.Forms.Panel();
            this.dgv_Module = new System.Windows.Forms.DataGridView();
            this.Menu_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Module_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Menu_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Use_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Add_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Edit_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Delete_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Save_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Export_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Import_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_User = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pnl_User.SuspendLayout();
            this.pnl_Bottom.SuspendLayout();
            this.pnl_Module.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Module)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(613, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 593);
            this.panel2.TabIndex = 25;
            // 
            // pnl_User
            // 
            this.pnl_User.Controls.Add(this.dgv_User);
            this.pnl_User.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_User.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_User.Location = new System.Drawing.Point(0, 0);
            this.pnl_User.Name = "pnl_User";
            this.pnl_User.Size = new System.Drawing.Size(613, 593);
            this.pnl_User.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 593);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1344, 1);
            this.panel3.TabIndex = 23;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Edit.BackgroundImage")));
            this.btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Edit.Enabled = false;
            this.btn_Edit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit.ImageIndex = 3;
            this.btn_Edit.Location = new System.Drawing.Point(1036, 3);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(80, 40);
            this.btn_Edit.TabIndex = 14;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.Visible = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_BatchSave
            // 
            this.btn_BatchSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BatchSave.BackgroundImage")));
            this.btn_BatchSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BatchSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_BatchSave.ForeColor = System.Drawing.Color.Transparent;
            this.btn_BatchSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_BatchSave.ImageIndex = 5;
            this.btn_BatchSave.ImageList = this.imageList;
            this.btn_BatchSave.Location = new System.Drawing.Point(2, 2);
            this.btn_BatchSave.Name = "btn_BatchSave";
            this.btn_BatchSave.Size = new System.Drawing.Size(80, 40);
            this.btn_BatchSave.TabIndex = 10;
            this.btn_BatchSave.Text = "保存";
            this.btn_BatchSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_BatchSave.UseVisualStyleBackColor = true;
            this.btn_BatchSave.Click += new System.EventHandler(this.btn_BatchSave_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.BackgroundImage")));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Close.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 4;
            this.btn_Close.ImageList = this.imageList;
            this.btn_Close.Location = new System.Drawing.Point(83, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 40);
            this.btn_Close.TabIndex = 11;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pnl_Bottom
            // 
            this.pnl_Bottom.Controls.Add(this.btn_Edit);
            this.pnl_Bottom.Controls.Add(this.btn_BatchSave);
            this.pnl_Bottom.Controls.Add(this.btn_Close);
            this.pnl_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Bottom.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_Bottom.Location = new System.Drawing.Point(0, 594);
            this.pnl_Bottom.Name = "pnl_Bottom";
            this.pnl_Bottom.Size = new System.Drawing.Size(1344, 45);
            this.pnl_Bottom.TabIndex = 22;
            // 
            // pnl_Module
            // 
            this.pnl_Module.Controls.Add(this.dgv_Module);
            this.pnl_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Module.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_Module.Location = new System.Drawing.Point(614, 0);
            this.pnl_Module.Name = "pnl_Module";
            this.pnl_Module.Size = new System.Drawing.Size(730, 593);
            this.pnl_Module.TabIndex = 26;
            // 
            // dgv_Module
            // 
            this.dgv_Module.AllowUserToAddRows = false;
            this.dgv_Module.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_Module.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Module.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Module.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Module.ColumnHeadersHeight = 35;
            this.dgv_Module.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Module.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Menu_Name,
            this.Module_Code,
            this.Module_Name,
            this.Menu_Code,
            this.Use_Flag,
            this.Add_Flag,
            this.Edit_Flag,
            this.Delete_Flag,
            this.Save_Flag,
            this.Export_Flag,
            this.Import_Flag,
            this.ID});
            this.dgv_Module.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Module.GridColor = System.Drawing.SystemColors.Control;
            this.dgv_Module.Location = new System.Drawing.Point(0, 0);
            this.dgv_Module.MultiSelect = false;
            this.dgv_Module.Name = "dgv_Module";
            this.dgv_Module.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_Module.RowTemplate.Height = 35;
            this.dgv_Module.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Module.Size = new System.Drawing.Size(730, 593);
            this.dgv_Module.TabIndex = 18;
            this.dgv_Module.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_User_RowStateChanged);
            // 
            // Menu_Name
            // 
            this.Menu_Name.DataPropertyName = "Menu_Name";
            this.Menu_Name.FillWeight = 70F;
            this.Menu_Name.HeaderText = "菜单名称";
            this.Menu_Name.MaxInputLength = 200;
            this.Menu_Name.Name = "Menu_Name";
            this.Menu_Name.ReadOnly = true;
            this.Menu_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Menu_Name.Width = 200;
            // 
            // Module_Code
            // 
            this.Module_Code.DataPropertyName = "Module_Code";
            this.Module_Code.HeaderText = "Module_Code";
            this.Module_Code.Name = "Module_Code";
            this.Module_Code.ReadOnly = true;
            this.Module_Code.Visible = false;
            // 
            // Module_Name
            // 
            this.Module_Name.DataPropertyName = "Module_Name";
            this.Module_Name.HeaderText = "模块名称";
            this.Module_Name.Name = "Module_Name";
            this.Module_Name.ReadOnly = true;
            // 
            // Menu_Code
            // 
            this.Menu_Code.DataPropertyName = "Menu_Code";
            this.Menu_Code.HeaderText = "Menu_Code";
            this.Menu_Code.Name = "Menu_Code";
            this.Menu_Code.ReadOnly = true;
            this.Menu_Code.Visible = false;
            // 
            // Use_Flag
            // 
            this.Use_Flag.DataPropertyName = "Use_Flag";
            this.Use_Flag.FalseValue = "0";
            this.Use_Flag.HeaderText = "使用";
            this.Use_Flag.Name = "Use_Flag";
            this.Use_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Use_Flag.TrueValue = "1";
            this.Use_Flag.Width = 60;
            // 
            // Add_Flag
            // 
            this.Add_Flag.DataPropertyName = "Add_Flag";
            this.Add_Flag.FalseValue = "0";
            this.Add_Flag.HeaderText = "新增";
            this.Add_Flag.Name = "Add_Flag";
            this.Add_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add_Flag.TrueValue = "1";
            this.Add_Flag.Width = 60;
            // 
            // Edit_Flag
            // 
            this.Edit_Flag.DataPropertyName = "Edit_Flag";
            this.Edit_Flag.FalseValue = "0";
            this.Edit_Flag.FillWeight = 80F;
            this.Edit_Flag.HeaderText = "编辑";
            this.Edit_Flag.Name = "Edit_Flag";
            this.Edit_Flag.TrueValue = "1";
            this.Edit_Flag.Width = 60;
            // 
            // Delete_Flag
            // 
            this.Delete_Flag.DataPropertyName = "Delete_Flag";
            this.Delete_Flag.FalseValue = "0";
            this.Delete_Flag.HeaderText = "删除";
            this.Delete_Flag.Name = "Delete_Flag";
            this.Delete_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete_Flag.TrueValue = "1";
            this.Delete_Flag.Width = 60;
            // 
            // Save_Flag
            // 
            this.Save_Flag.DataPropertyName = "Save_Flag";
            this.Save_Flag.FalseValue = "0";
            this.Save_Flag.HeaderText = "保存";
            this.Save_Flag.Name = "Save_Flag";
            this.Save_Flag.TrueValue = "1";
            this.Save_Flag.Width = 60;
            // 
            // Export_Flag
            // 
            this.Export_Flag.DataPropertyName = "Export_Flag";
            this.Export_Flag.FalseValue = "0";
            this.Export_Flag.HeaderText = "导出";
            this.Export_Flag.Name = "Export_Flag";
            this.Export_Flag.TrueValue = "1";
            this.Export_Flag.Width = 60;
            // 
            // Import_Flag
            // 
            this.Import_Flag.DataPropertyName = "Import_Flag";
            this.Import_Flag.FalseValue = "0";
            this.Import_Flag.HeaderText = "导入";
            this.Import_Flag.Name = "Import_Flag";
            this.Import_Flag.TrueValue = "1";
            this.Import_Flag.Width = 60;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // dgv_User
            // 
            this.dgv_User.AllowUserToAddRows = false;
            this.dgv_User.AllowUserToResizeColumns = false;
            this.dgv_User.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_User.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_User.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_User.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_User.ColumnHeadersHeight = 35;
            this.dgv_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.User_Code,
            this.User_Name,
            this.Remark});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_User.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_User.Location = new System.Drawing.Point(0, 0);
            this.dgv_User.MultiSelect = false;
            this.dgv_User.Name = "dgv_User";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_User.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_User.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_User.RowTemplate.Height = 35;
            this.dgv_User.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_User.Size = new System.Drawing.Size(613, 593);
            this.dgv_User.TabIndex = 11;
            this.dgv_User.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_User_CellClick);
            this.dgv_User.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_User_RowStateChanged);
            // 
            // User_ID
            // 
            this.User_ID.DataPropertyName = "User_ID";
            this.User_ID.HeaderText = "User_ID";
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            this.User_ID.Visible = false;
            // 
            // User_Code
            // 
            this.User_Code.DataPropertyName = "User_Code";
            this.User_Code.HeaderText = "用户编码";
            this.User_Code.Name = "User_Code";
            this.User_Code.ReadOnly = true;
            this.User_Code.Width = 150;
            // 
            // User_Name
            // 
            this.User_Name.DataPropertyName = "User_Name";
            this.User_Name.HeaderText = "用户名";
            this.User_Name.Name = "User_Name";
            this.User_Name.ReadOnly = true;
            this.User_Name.Width = 150;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 200;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Add.ico");
            this.imageList.Images.SetKeyName(1, "Delete.ico");
            this.imageList.Images.SetKeyName(2, "Edit.ico");
            this.imageList.Images.SetKeyName(3, "Exit.ico");
            this.imageList.Images.SetKeyName(4, "Cancel.ico");
            this.imageList.Images.SetKeyName(5, "Save.ico");
            // 
            // FrmAuthority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 639);
            this.Controls.Add(this.pnl_Module);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnl_User);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnl_Bottom);
            this.Name = "FrmAuthority";
            this.Text = "权限设置";
            this.Load += new System.EventHandler(this.FrmAuthority_Load);
            this.pnl_User.ResumeLayout(false);
            this.pnl_Bottom.ResumeLayout(false);
            this.pnl_Module.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Module)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnl_User;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_BatchSave;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Panel pnl_Bottom;
        private System.Windows.Forms.Panel pnl_Module;
        private System.Windows.Forms.DataGridView dgv_Module;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu_Code;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Use_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Add_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Edit_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Delete_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Save_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Export_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Import_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridView dgv_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.ImageList imageList;
    }
}