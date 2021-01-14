namespace User
{
    partial class FrmUserAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.UserGrid = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Tech_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Check_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Plan_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Admin_Flag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.User_PassWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Close);
            this.panel2.Controls.Add(this.btn_Delete);
            this.panel2.Controls.Add(this.btn_Edit);
            this.panel2.Controls.Add(this.btn_Add);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 391);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(951, 37);
            this.panel2.TabIndex = 5;
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
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList;
            this.btn_Close.Location = new System.Drawing.Point(240, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 37);
            this.btn_Close.TabIndex = 28;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Save.ico");
            this.imageList.Images.SetKeyName(1, "Cancel.ico");
            this.imageList.Images.SetKeyName(2, "Find.ico");
            this.imageList.Images.SetKeyName(3, "Add.ico");
            this.imageList.Images.SetKeyName(4, "Delete.ico");
            this.imageList.Images.SetKeyName(5, "Password1.ico");
            this.imageList.Images.SetKeyName(6, "Edit.ico");
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.White;
            this.btn_Delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Delete.BackgroundImage")));
            this.btn_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Delete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Delete.ImageIndex = 4;
            this.btn_Delete.ImageList = this.imageList;
            this.btn_Delete.Location = new System.Drawing.Point(160, 0);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(80, 37);
            this.btn_Delete.TabIndex = 24;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
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
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit.ImageIndex = 6;
            this.btn_Edit.ImageList = this.imageList;
            this.btn_Edit.Location = new System.Drawing.Point(80, 0);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(80, 37);
            this.btn_Edit.TabIndex = 23;
            this.btn_Edit.Text = "编辑";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
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
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Add.ImageIndex = 3;
            this.btn_Add.ImageList = this.imageList;
            this.btn_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(80, 37);
            this.btn_Add.TabIndex = 22;
            this.btn_Add.Text = "新增";
            this.btn_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UserGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 391);
            this.panel1.TabIndex = 6;
            // 
            // UserGrid
            // 
            this.UserGrid.AllowUserToAddRows = false;
            this.UserGrid.AllowUserToResizeColumns = false;
            this.UserGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.UserGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.UserGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.UserGrid.ColumnHeadersHeight = 30;
            this.UserGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.UserGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.User_Code,
            this.User_Name,
            this.Operator_Flag,
            this.Tech_Flag,
            this.Check_Flag,
            this.Plan_Flag,
            this.Admin_Flag,
            this.User_PassWord});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UserGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.UserGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserGrid.Location = new System.Drawing.Point(0, 0);
            this.UserGrid.MultiSelect = false;
            this.UserGrid.Name = "UserGrid";
            this.UserGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.UserGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.UserGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.UserGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.UserGrid.RowTemplate.Height = 30;
            this.UserGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UserGrid.Size = new System.Drawing.Size(951, 391);
            this.UserGrid.TabIndex = 4;
            this.UserGrid.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.UserGrid_RowStateChanged);
            // 
            // User_ID
            // 
            this.User_ID.DataPropertyName = "User_ID";
            this.User_ID.HeaderText = "用户ID";
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            this.User_ID.Width = 120;
            // 
            // User_Code
            // 
            this.User_Code.DataPropertyName = "User_Code";
            this.User_Code.HeaderText = "用户编号";
            this.User_Code.Name = "User_Code";
            this.User_Code.ReadOnly = true;
            this.User_Code.Width = 250;
            // 
            // User_Name
            // 
            this.User_Name.DataPropertyName = "User_Name";
            this.User_Name.HeaderText = "用户名称";
            this.User_Name.Name = "User_Name";
            this.User_Name.ReadOnly = true;
            this.User_Name.Width = 150;
            // 
            // Operator_Flag
            // 
            this.Operator_Flag.DataPropertyName = "Operator_Flag";
            this.Operator_Flag.HeaderText = "操作员";
            this.Operator_Flag.Name = "Operator_Flag";
            this.Operator_Flag.ReadOnly = true;
            this.Operator_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Operator_Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Operator_Flag.Width = 80;
            // 
            // Tech_Flag
            // 
            this.Tech_Flag.DataPropertyName = "Tech_Flag";
            this.Tech_Flag.HeaderText = "工艺员";
            this.Tech_Flag.Name = "Tech_Flag";
            this.Tech_Flag.ReadOnly = true;
            this.Tech_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Tech_Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Tech_Flag.Width = 80;
            // 
            // Check_Flag
            // 
            this.Check_Flag.DataPropertyName = "Check_Flag";
            this.Check_Flag.HeaderText = "质检员";
            this.Check_Flag.Name = "Check_Flag";
            this.Check_Flag.ReadOnly = true;
            this.Check_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Check_Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Check_Flag.Width = 80;
            // 
            // Plan_Flag
            // 
            this.Plan_Flag.DataPropertyName = "Plan_Flag";
            this.Plan_Flag.HeaderText = "计划员";
            this.Plan_Flag.Name = "Plan_Flag";
            this.Plan_Flag.ReadOnly = true;
            this.Plan_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Plan_Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Plan_Flag.Width = 80;
            // 
            // Admin_Flag
            // 
            this.Admin_Flag.DataPropertyName = "Admin_Flag";
            this.Admin_Flag.HeaderText = "管理员";
            this.Admin_Flag.Name = "Admin_Flag";
            this.Admin_Flag.ReadOnly = true;
            this.Admin_Flag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Admin_Flag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Admin_Flag.Width = 80;
            // 
            // User_PassWord
            // 
            this.User_PassWord.DataPropertyName = "User_PassWord";
            this.User_PassWord.HeaderText = "密码";
            this.User_PassWord.Name = "User_PassWord";
            this.User_PassWord.ReadOnly = true;
            this.User_PassWord.Visible = false;
            // 
            // FrmUserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 428);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmUserAdmin";
            this.Text = "用户管理";
            this.Activated += new System.EventHandler(this.FrmUserAdmin_Activated);
            this.Load += new System.EventHandler(this.FrmUserAdmin_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UserGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView UserGrid;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Operator_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tech_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Plan_Flag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Admin_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_PassWord;
    }
}