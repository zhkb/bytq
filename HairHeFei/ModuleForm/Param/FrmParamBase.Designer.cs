namespace Param
{
    partial class FrmParamBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParamBase));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.dgvCodeDetail = new System.Windows.Forms.DataGridView();
            this.Parameter_Detail_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parameter_Detail_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parameter_Detail_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detail_Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DetailButtonPanel = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Detail_Del = new System.Windows.Forms.Button();
            this.btn_Detail_Edit = new System.Windows.Forms.Button();
            this.btn_Deatil_Add = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.dgvCodeHead = new System.Windows.Forms.DataGridView();
            this.Parameter_Master_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parameter_Master_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parameter_Master_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creation_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Update_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit_User_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeadButtonPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Head_Del = new System.Windows.Forms.Button();
            this.btn_Head_Edit = new System.Windows.Forms.Button();
            this.btn_Head_Add = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.DetailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeDetail)).BeginInit();
            this.DetailButtonPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeHead)).BeginInit();
            this.HeadButtonPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.imageList.Images.SetKeyName(6, "Delete.ico");
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.DetailPanel);
            this.MainPanel.Controls.Add(this.TopPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1350, 661);
            this.MainPanel.TabIndex = 0;
            // 
            // DetailPanel
            // 
            this.DetailPanel.Controls.Add(this.dgvCodeDetail);
            this.DetailPanel.Controls.Add(this.DetailButtonPanel);
            this.DetailPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailPanel.Location = new System.Drawing.Point(0, 408);
            this.DetailPanel.Name = "DetailPanel";
            this.DetailPanel.Size = new System.Drawing.Size(1350, 253);
            this.DetailPanel.TabIndex = 1;
            // 
            // dgvCodeDetail
            // 
            this.dgvCodeDetail.AllowUserToAddRows = false;
            this.dgvCodeDetail.AllowUserToResizeColumns = false;
            this.dgvCodeDetail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCodeDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCodeDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvCodeDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodeDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCodeDetail.ColumnHeadersHeight = 40;
            this.dgvCodeDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCodeDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter_Detail_ID,
            this.Parameter_Detail_Code,
            this.Parameter_Detail_Name,
            this.Detail_Remark,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCodeDetail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCodeDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodeDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvCodeDetail.MultiSelect = false;
            this.dgvCodeDetail.Name = "dgvCodeDetail";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodeDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCodeDetail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCodeDetail.RowTemplate.Height = 40;
            this.dgvCodeDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodeDetail.Size = new System.Drawing.Size(1350, 208);
            this.dgvCodeDetail.TabIndex = 29;
            this.dgvCodeDetail.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvDetail_RowStateChanged);
            // 
            // Parameter_Detail_ID
            // 
            this.Parameter_Detail_ID.DataPropertyName = "Parameter_Detail_ID";
            this.Parameter_Detail_ID.HeaderText = "Parameter_Detail_ID";
            this.Parameter_Detail_ID.Name = "Parameter_Detail_ID";
            this.Parameter_Detail_ID.ReadOnly = true;
            this.Parameter_Detail_ID.Visible = false;
            // 
            // Parameter_Detail_Code
            // 
            this.Parameter_Detail_Code.DataPropertyName = "Parameter_Detail_Code";
            this.Parameter_Detail_Code.HeaderText = "参数内容编码";
            this.Parameter_Detail_Code.Name = "Parameter_Detail_Code";
            this.Parameter_Detail_Code.ReadOnly = true;
            this.Parameter_Detail_Code.Width = 150;
            // 
            // Parameter_Detail_Name
            // 
            this.Parameter_Detail_Name.DataPropertyName = "Parameter_Detail_Name";
            this.Parameter_Detail_Name.HeaderText = "参数内容名称";
            this.Parameter_Detail_Name.Name = "Parameter_Detail_Name";
            this.Parameter_Detail_Name.ReadOnly = true;
            this.Parameter_Detail_Name.Width = 280;
            // 
            // Detail_Remark
            // 
            this.Detail_Remark.DataPropertyName = "Remark";
            this.Detail_Remark.HeaderText = "参数内容描述";
            this.Detail_Remark.Name = "Detail_Remark";
            this.Detail_Remark.ReadOnly = true;
            this.Detail_Remark.Width = 300;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Create_User_Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "创建人";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Creation_Date";
            this.dataGridViewTextBoxColumn6.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 160;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Last_Update_Date";
            this.dataGridViewTextBoxColumn7.HeaderText = "编辑时间";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Edit_User_Name";
            this.dataGridViewTextBoxColumn8.HeaderText = "编辑人";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // DetailButtonPanel
            // 
            this.DetailButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DetailButtonPanel.Controls.Add(this.btn_Close);
            this.DetailButtonPanel.Controls.Add(this.btn_Detail_Del);
            this.DetailButtonPanel.Controls.Add(this.btn_Detail_Edit);
            this.DetailButtonPanel.Controls.Add(this.btn_Deatil_Add);
            this.DetailButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DetailButtonPanel.Location = new System.Drawing.Point(0, 208);
            this.DetailButtonPanel.Margin = new System.Windows.Forms.Padding(5);
            this.DetailButtonPanel.Name = "DetailButtonPanel";
            this.DetailButtonPanel.Size = new System.Drawing.Size(1350, 45);
            this.DetailButtonPanel.TabIndex = 28;
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
            this.btn_Close.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 4;
            this.btn_Close.ImageList = this.imageList2;
            this.btn_Close.Location = new System.Drawing.Point(244, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 40);
            this.btn_Close.TabIndex = 24;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
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
            // btn_Detail_Del
            // 
            this.btn_Detail_Del.BackColor = System.Drawing.Color.White;
            this.btn_Detail_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Detail_Del.BackgroundImage")));
            this.btn_Detail_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Detail_Del.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Detail_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Del.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Detail_Del.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Detail_Del.ImageIndex = 1;
            this.btn_Detail_Del.ImageList = this.imageList2;
            this.btn_Detail_Del.Location = new System.Drawing.Point(163, 2);
            this.btn_Detail_Del.Name = "btn_Detail_Del";
            this.btn_Detail_Del.Size = new System.Drawing.Size(80, 40);
            this.btn_Detail_Del.TabIndex = 23;
            this.btn_Detail_Del.Text = "删除";
            this.btn_Detail_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detail_Del.UseVisualStyleBackColor = false;
            this.btn_Detail_Del.Click += new System.EventHandler(this.btn_Detail_Del_Click);
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
            this.btn_Detail_Edit.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Detail_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Detail_Edit.ImageIndex = 2;
            this.btn_Detail_Edit.ImageList = this.imageList2;
            this.btn_Detail_Edit.Location = new System.Drawing.Point(82, 2);
            this.btn_Detail_Edit.Name = "btn_Detail_Edit";
            this.btn_Detail_Edit.Size = new System.Drawing.Size(80, 40);
            this.btn_Detail_Edit.TabIndex = 22;
            this.btn_Detail_Edit.Text = "编辑";
            this.btn_Detail_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Detail_Edit.UseVisualStyleBackColor = false;
            this.btn_Detail_Edit.Click += new System.EventHandler(this.btn_Detail_Edit_Click);
            // 
            // btn_Deatil_Add
            // 
            this.btn_Deatil_Add.BackColor = System.Drawing.Color.White;
            this.btn_Deatil_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Deatil_Add.BackgroundImage")));
            this.btn_Deatil_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Deatil_Add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Deatil_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Deatil_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Deatil_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Deatil_Add.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Deatil_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Deatil_Add.ImageIndex = 0;
            this.btn_Deatil_Add.ImageList = this.imageList2;
            this.btn_Deatil_Add.Location = new System.Drawing.Point(1, 2);
            this.btn_Deatil_Add.Name = "btn_Deatil_Add";
            this.btn_Deatil_Add.Size = new System.Drawing.Size(80, 40);
            this.btn_Deatil_Add.TabIndex = 21;
            this.btn_Deatil_Add.Text = "增加";
            this.btn_Deatil_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Deatil_Add.UseVisualStyleBackColor = false;
            this.btn_Deatil_Add.Click += new System.EventHandler(this.btn_Detail_Add_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.dgvCodeHead);
            this.TopPanel.Controls.Add(this.HeadButtonPanel);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1350, 408);
            this.TopPanel.TabIndex = 0;
            // 
            // dgvCodeHead
            // 
            this.dgvCodeHead.AllowUserToAddRows = false;
            this.dgvCodeHead.AllowUserToResizeColumns = false;
            this.dgvCodeHead.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCodeHead.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCodeHead.BackgroundColor = System.Drawing.Color.White;
            this.dgvCodeHead.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodeHead.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCodeHead.ColumnHeadersHeight = 40;
            this.dgvCodeHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCodeHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Parameter_Master_ID,
            this.Parameter_Master_Code,
            this.Parameter_Master_Name,
            this.Remark,
            this.Create_User_Name,
            this.Creation_Date,
            this.Last_Update_Date,
            this.Edit_User_Name});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCodeHead.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvCodeHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCodeHead.Location = new System.Drawing.Point(0, 0);
            this.dgvCodeHead.MultiSelect = false;
            this.dgvCodeHead.Name = "dgvCodeHead";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCodeHead.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvCodeHead.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCodeHead.RowTemplate.Height = 40;
            this.dgvCodeHead.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodeHead.Size = new System.Drawing.Size(1350, 363);
            this.dgvCodeHead.TabIndex = 11;
            this.dgvCodeHead.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCodeHead_CellMouseClick);
            this.dgvCodeHead.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvHead_RowStateChanged);
            // 
            // Parameter_Master_ID
            // 
            this.Parameter_Master_ID.DataPropertyName = "Parameter_Master_ID";
            this.Parameter_Master_ID.HeaderText = "Parameter_Master_ID";
            this.Parameter_Master_ID.Name = "Parameter_Master_ID";
            this.Parameter_Master_ID.ReadOnly = true;
            this.Parameter_Master_ID.Visible = false;
            // 
            // Parameter_Master_Code
            // 
            this.Parameter_Master_Code.DataPropertyName = "Parameter_Master_Code";
            this.Parameter_Master_Code.HeaderText = "参数项编码";
            this.Parameter_Master_Code.Name = "Parameter_Master_Code";
            this.Parameter_Master_Code.ReadOnly = true;
            this.Parameter_Master_Code.Width = 150;
            // 
            // Parameter_Master_Name
            // 
            this.Parameter_Master_Name.DataPropertyName = "Parameter_Master_Name";
            this.Parameter_Master_Name.HeaderText = "参数项名称";
            this.Parameter_Master_Name.Name = "Parameter_Master_Name";
            this.Parameter_Master_Name.ReadOnly = true;
            this.Parameter_Master_Name.Width = 280;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "参数项描述";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.Width = 300;
            // 
            // Create_User_Name
            // 
            this.Create_User_Name.DataPropertyName = "Create_User_Name";
            this.Create_User_Name.HeaderText = "创建人";
            this.Create_User_Name.Name = "Create_User_Name";
            this.Create_User_Name.ReadOnly = true;
            this.Create_User_Name.Visible = false;
            // 
            // Creation_Date
            // 
            this.Creation_Date.DataPropertyName = "Creation_Date";
            this.Creation_Date.HeaderText = "创建时间";
            this.Creation_Date.Name = "Creation_Date";
            this.Creation_Date.ReadOnly = true;
            this.Creation_Date.Visible = false;
            this.Creation_Date.Width = 160;
            // 
            // Last_Update_Date
            // 
            this.Last_Update_Date.DataPropertyName = "Last_Update_Date";
            this.Last_Update_Date.HeaderText = "编辑时间";
            this.Last_Update_Date.Name = "Last_Update_Date";
            this.Last_Update_Date.ReadOnly = true;
            this.Last_Update_Date.Width = 200;
            // 
            // Edit_User_Name
            // 
            this.Edit_User_Name.DataPropertyName = "Edit_User_Name";
            this.Edit_User_Name.HeaderText = "编辑人";
            this.Edit_User_Name.Name = "Edit_User_Name";
            this.Edit_User_Name.ReadOnly = true;
            this.Edit_User_Name.Width = 120;
            // 
            // HeadButtonPanel
            // 
            this.HeadButtonPanel.BackColor = System.Drawing.SystemColors.Control;
            this.HeadButtonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeadButtonPanel.Controls.Add(this.button1);
            this.HeadButtonPanel.Controls.Add(this.btn_Head_Del);
            this.HeadButtonPanel.Controls.Add(this.btn_Head_Edit);
            this.HeadButtonPanel.Controls.Add(this.btn_Head_Add);
            this.HeadButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HeadButtonPanel.Location = new System.Drawing.Point(0, 363);
            this.HeadButtonPanel.Margin = new System.Windows.Forms.Padding(5);
            this.HeadButtonPanel.Name = "HeadButtonPanel";
            this.HeadButtonPanel.Size = new System.Drawing.Size(1350, 45);
            this.HeadButtonPanel.TabIndex = 27;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 4;
            this.button1.ImageList = this.imageList2;
            this.button1.Location = new System.Drawing.Point(244, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 24;
            this.button1.Text = "关闭";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // btn_Head_Del
            // 
            this.btn_Head_Del.BackColor = System.Drawing.Color.White;
            this.btn_Head_Del.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Head_Del.BackgroundImage")));
            this.btn_Head_Del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Head_Del.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Head_Del.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Head_Del.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Head_Del.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Head_Del.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Head_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Head_Del.ImageIndex = 1;
            this.btn_Head_Del.ImageList = this.imageList2;
            this.btn_Head_Del.Location = new System.Drawing.Point(163, 1);
            this.btn_Head_Del.Name = "btn_Head_Del";
            this.btn_Head_Del.Size = new System.Drawing.Size(80, 40);
            this.btn_Head_Del.TabIndex = 23;
            this.btn_Head_Del.Text = "删除";
            this.btn_Head_Del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Head_Del.UseVisualStyleBackColor = false;
            this.btn_Head_Del.Click += new System.EventHandler(this.btn_Head_Del_Click);
            // 
            // btn_Head_Edit
            // 
            this.btn_Head_Edit.BackColor = System.Drawing.Color.White;
            this.btn_Head_Edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Head_Edit.BackgroundImage")));
            this.btn_Head_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Head_Edit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Head_Edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Head_Edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Head_Edit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Head_Edit.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Head_Edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Head_Edit.ImageIndex = 2;
            this.btn_Head_Edit.ImageList = this.imageList2;
            this.btn_Head_Edit.Location = new System.Drawing.Point(82, 1);
            this.btn_Head_Edit.Name = "btn_Head_Edit";
            this.btn_Head_Edit.Size = new System.Drawing.Size(80, 40);
            this.btn_Head_Edit.TabIndex = 22;
            this.btn_Head_Edit.Text = "编辑";
            this.btn_Head_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Head_Edit.UseVisualStyleBackColor = false;
            this.btn_Head_Edit.Click += new System.EventHandler(this.btn_Head_Edit_Click);
            // 
            // btn_Head_Add
            // 
            this.btn_Head_Add.BackColor = System.Drawing.Color.White;
            this.btn_Head_Add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Head_Add.BackgroundImage")));
            this.btn_Head_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Head_Add.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Head_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Head_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Head_Add.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Head_Add.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Head_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Head_Add.ImageIndex = 0;
            this.btn_Head_Add.ImageList = this.imageList2;
            this.btn_Head_Add.Location = new System.Drawing.Point(1, 1);
            this.btn_Head_Add.Name = "btn_Head_Add";
            this.btn_Head_Add.Size = new System.Drawing.Size(80, 40);
            this.btn_Head_Add.TabIndex = 21;
            this.btn_Head_Add.Text = "增加";
            this.btn_Head_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Head_Add.UseVisualStyleBackColor = false;
            this.btn_Head_Add.Click += new System.EventHandler(this.btn_Head_Add_Click);
            // 
            // FrmParamBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 661);
            this.Controls.Add(this.MainPanel);
            this.Name = "FrmParamBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基础参数维护窗口";
            this.Load += new System.EventHandler(this.FrmParamBase_Load);
            this.MainPanel.ResumeLayout(false);
            this.DetailPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeDetail)).EndInit();
            this.DetailButtonPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodeHead)).EndInit();
            this.HeadButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel DetailPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel HeadButtonPanel;
        private System.Windows.Forms.Button btn_Head_Add;
        private System.Windows.Forms.Button btn_Head_Edit;
        private System.Windows.Forms.Button btn_Head_Del;
        private System.Windows.Forms.Panel DetailButtonPanel;
        private System.Windows.Forms.Button btn_Detail_Del;
        private System.Windows.Forms.Button btn_Detail_Edit;
        private System.Windows.Forms.Button btn_Deatil_Add;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.DataGridView dgvCodeHead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter_Master_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter_Master_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter_Master_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_User_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creation_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Update_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edit_User_Name;
        private System.Windows.Forms.DataGridView dgvCodeDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter_Detail_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter_Detail_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter_Detail_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Detail_Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}

