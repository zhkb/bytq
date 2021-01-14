namespace Param
{
    partial class FrmAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlarm));
            this.dgvAction = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipment_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alarm_Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btn_Edit4Action = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAction)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAction
            // 
            this.dgvAction.AllowUserToAddRows = false;
            this.dgvAction.AllowUserToResizeColumns = false;
            this.dgvAction.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvAction.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAction.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAction.ColumnHeadersHeight = 50;
            this.dgvAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Equipment_Code,
            this.Equipment_Name,
            this.Alarm_Desc,
            this.Remark});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAction.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAction.Location = new System.Drawing.Point(0, 0);
            this.dgvAction.MultiSelect = false;
            this.dgvAction.Name = "dgvAction";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAction.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAction.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvAction.RowTemplate.Height = 30;
            this.dgvAction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAction.Size = new System.Drawing.Size(1904, 981);
            this.dgvAction.TabIndex = 28;
            this.dgvAction.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_RowStateChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 150;
            // 
            // Equipment_Code
            // 
            this.Equipment_Code.DataPropertyName = "Equipment_Code";
            this.Equipment_Code.HeaderText = "设备编号";
            this.Equipment_Code.Name = "Equipment_Code";
            this.Equipment_Code.ReadOnly = true;
            this.Equipment_Code.Width = 150;
            // 
            // Equipment_Name
            // 
            this.Equipment_Name.DataPropertyName = "Equipment_Name";
            this.Equipment_Name.HeaderText = "报警设备";
            this.Equipment_Name.Name = "Equipment_Name";
            this.Equipment_Name.ReadOnly = true;
            this.Equipment_Name.Width = 200;
            // 
            // Alarm_Desc
            // 
            this.Alarm_Desc.DataPropertyName = "Alarm_Desc";
            this.Alarm_Desc.HeaderText = "报警描述";
            this.Alarm_Desc.Name = "Alarm_Desc";
            this.Alarm_Desc.ReadOnly = true;
            this.Alarm_Desc.Width = 600;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Remark.Width = 300;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_Close);
            this.panel4.Controls.Add(this.btn_Edit4Action);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panel4.Location = new System.Drawing.Point(0, 981);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1904, 60);
            this.panel4.TabIndex = 27;
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
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 1;
            this.btn_Close.ImageList = this.imageList;
            this.btn_Close.Location = new System.Drawing.Point(120, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(120, 60);
            this.btn_Close.TabIndex = 24;
            this.btn_Close.Text = "关闭";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
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
            this.imageList.Images.SetKeyName(5, "ok.ico");
            this.imageList.Images.SetKeyName(6, "Same.ico");
            // 
            // btn_Edit4Action
            // 
            this.btn_Edit4Action.BackColor = System.Drawing.Color.White;
            this.btn_Edit4Action.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Edit4Action.BackgroundImage")));
            this.btn_Edit4Action.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Edit4Action.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Edit4Action.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Edit4Action.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Edit4Action.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Edit4Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit4Action.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Edit4Action.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Edit4Action.ImageIndex = 3;
            this.btn_Edit4Action.ImageList = this.imageList;
            this.btn_Edit4Action.Location = new System.Drawing.Point(0, 0);
            this.btn_Edit4Action.Name = "btn_Edit4Action";
            this.btn_Edit4Action.Size = new System.Drawing.Size(120, 60);
            this.btn_Edit4Action.TabIndex = 19;
            this.btn_Edit4Action.Text = "编辑";
            this.btn_Edit4Action.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit4Action.UseVisualStyleBackColor = false;
            this.btn_Edit4Action.Click += new System.EventHandler(this.btn_Edit4Action_Click);
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.dgvAction);
            this.Controls.Add(this.panel4);
            this.Name = "FrmAlarm";
            this.Text = "报警参数维护窗口";
            this.Load += new System.EventHandler(this.FrmParam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAction)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAction;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Edit4Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipment_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm_Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.ImageList imageList;
    }
}

