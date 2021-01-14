namespace Login
{
    partial class FrmSelectUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectUser));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MasterGrid = new System.Windows.Forms.DataGridView();
            this.User_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operator_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tech_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plan_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Admin_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MasterGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_OK);
            this.panel1.Controls.Add(this.btn_Cancle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 69);
            this.panel1.TabIndex = 28;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_OK.FlatAppearance.BorderSize = 0;
            this.btn_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_OK.ForeColor = System.Drawing.Color.Black;
            this.btn_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_OK.ImageList = this.imageList;
            this.btn_OK.Location = new System.Drawing.Point(228, 5);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(85, 60);
            this.btn_OK.TabIndex = 13;
            this.btn_OK.Text = "确定\r\nOK\r\n";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.ico");
            this.imageList.Images.SetKeyName(1, "Cancel.ico");
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancle.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancle.BackgroundImage")));
            this.btn_Cancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancle.FlatAppearance.BorderSize = 0;
            this.btn_Cancle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancle.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancle.ImageList = this.imageList;
            this.btn_Cancle.Location = new System.Drawing.Point(318, 5);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(85, 60);
            this.btn_Cancle.TabIndex = 14;
            this.btn_Cancle.Text = "取消\r\nCancel";
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.MasterGrid);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(408, 272);
            this.panel2.TabIndex = 31;
            // 
            // MasterGrid
            // 
            this.MasterGrid.AllowUserToAddRows = false;
            this.MasterGrid.AllowUserToDeleteRows = false;
            this.MasterGrid.AllowUserToResizeColumns = false;
            this.MasterGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MasterGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.MasterGrid.BackgroundColor = System.Drawing.Color.White;
            this.MasterGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MasterGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.MasterGrid.ColumnHeadersHeight = 50;
            this.MasterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.MasterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_Code,
            this.User_ID,
            this.User_Name,
            this.Operator_Flag,
            this.Tech_Flag,
            this.Plan_Flag,
            this.Check_Flag,
            this.Admin_Flag});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MasterGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.MasterGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MasterGrid.Location = new System.Drawing.Point(0, 0);
            this.MasterGrid.Margin = new System.Windows.Forms.Padding(5);
            this.MasterGrid.Name = "MasterGrid";
            this.MasterGrid.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MasterGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.MasterGrid.RowHeadersWidth = 50;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MasterGrid.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.MasterGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MasterGrid.RowTemplate.Height = 30;
            this.MasterGrid.Size = new System.Drawing.Size(408, 272);
            this.MasterGrid.TabIndex = 23;
            this.MasterGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MasterGrid_CellDoubleClick);
            this.MasterGrid.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.MasterGrid_RowStateChanged);
            // 
            // User_Code
            // 
            this.User_Code.DataPropertyName = "User_Code";
            this.User_Code.HeaderText = "  用户编号 User Code";
            this.User_Code.Name = "User_Code";
            this.User_Code.ReadOnly = true;
            this.User_Code.Width = 110;
            // 
            // User_ID
            // 
            this.User_ID.DataPropertyName = "User_ID";
            this.User_ID.HeaderText = "User_ID";
            this.User_ID.Name = "User_ID";
            this.User_ID.ReadOnly = true;
            this.User_ID.Visible = false;
            // 
            // User_Name
            // 
            this.User_Name.DataPropertyName = "User_Name";
            this.User_Name.HeaderText = "  用户名称   User Name";
            this.User_Name.Name = "User_Name";
            this.User_Name.ReadOnly = true;
            this.User_Name.Width = 150;
            // 
            // Operator_Flag
            // 
            this.Operator_Flag.DataPropertyName = "Operator_Flag";
            this.Operator_Flag.HeaderText = "操作员权限";
            this.Operator_Flag.Name = "Operator_Flag";
            this.Operator_Flag.ReadOnly = true;
            this.Operator_Flag.Visible = false;
            // 
            // Tech_Flag
            // 
            this.Tech_Flag.DataPropertyName = "Tech_Flag";
            this.Tech_Flag.HeaderText = "工艺员权限";
            this.Tech_Flag.Name = "Tech_Flag";
            this.Tech_Flag.ReadOnly = true;
            this.Tech_Flag.Visible = false;
            // 
            // Plan_Flag
            // 
            this.Plan_Flag.DataPropertyName = "Plan_Flag";
            this.Plan_Flag.HeaderText = "计划员权限";
            this.Plan_Flag.Name = "Plan_Flag";
            this.Plan_Flag.ReadOnly = true;
            this.Plan_Flag.Visible = false;
            // 
            // Check_Flag
            // 
            this.Check_Flag.DataPropertyName = "Check_Flag";
            this.Check_Flag.HeaderText = "质检员权限";
            this.Check_Flag.Name = "Check_Flag";
            this.Check_Flag.ReadOnly = true;
            this.Check_Flag.Visible = false;
            // 
            // Admin_Flag
            // 
            this.Admin_Flag.DataPropertyName = "Admin_Flag";
            this.Admin_Flag.HeaderText = "管理员权限";
            this.Admin_Flag.Name = "Admin_Flag";
            this.Admin_Flag.ReadOnly = true;
            this.Admin_Flag.Visible = false;
            // 
            // FrmSelectUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(408, 396);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "请选择用户 Please select users";
            this.Load += new System.EventHandler(this.FrmSelectUser_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MasterGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView MasterGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operator_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tech_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plan_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Check_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Admin_Flag;
    }
}