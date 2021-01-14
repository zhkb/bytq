namespace Material
{
    partial class FrmEnergyBin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnergyBin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Edit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCommon = new System.Windows.Forms.DataGridView();
            this.Bin_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Energy_Label_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Energy_Label_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Actual_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Theory_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Image = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_Edit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 511);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1350, 50);
            this.panel1.TabIndex = 0;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.White;
            this.btn_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.BackgroundImage")));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 4;
            this.btn_Close.ImageList = this.imageList2;
            this.btn_Close.Location = new System.Drawing.Point(1270, 0);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(80, 50);
            this.btn_Close.TabIndex = 25;
            this.btn_Close.Text = "关闭\r\nClose";
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
            this.btn_Edit.Location = new System.Drawing.Point(0, 0);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(80, 50);
            this.btn_Edit.TabIndex = 23;
            this.btn_Edit.Text = "编辑\r\nEdit\r\n";
            this.btn_Edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCommon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1350, 511);
            this.panel2.TabIndex = 1;
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
            this.Bin_No,
            this.Energy_Label_Code,
            this.Energy_Label_Name,
            this.Material_Actual_Qty,
            this.Material_Theory_Qty,
            this.Material_Image});
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
            this.dgvCommon.ReadOnly = true;
            this.dgvCommon.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommon.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCommon.RowHeadersVisible = false;
            this.dgvCommon.RowHeadersWidth = 75;
            this.dgvCommon.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCommon.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvCommon.RowTemplate.Height = 35;
            this.dgvCommon.RowTemplate.ReadOnly = true;
            this.dgvCommon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommon.Size = new System.Drawing.Size(1350, 511);
            this.dgvCommon.TabIndex = 12;
            this.dgvCommon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommon_CellClick);
            // 
            // Bin_No
            // 
            this.Bin_No.DataPropertyName = "Bin_No";
            this.Bin_No.HeaderText = "网格号    Bin No";
            this.Bin_No.Name = "Bin_No";
            this.Bin_No.ReadOnly = true;
            // 
            // Energy_Label_Code
            // 
            this.Energy_Label_Code.DataPropertyName = "Energy_Label_Code";
            this.Energy_Label_Code.HeaderText = "能效贴编号                                          Energy efficiency label code";
            this.Energy_Label_Code.Name = "Energy_Label_Code";
            this.Energy_Label_Code.ReadOnly = true;
            this.Energy_Label_Code.Width = 350;
            // 
            // Energy_Label_Name
            // 
            this.Energy_Label_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Energy_Label_Name.DataPropertyName = "Energy_Label_Name";
            this.Energy_Label_Name.HeaderText = "能效贴名称                                                              Energy efficie" +
    "ncy label model";
            this.Energy_Label_Name.Name = "Energy_Label_Name";
            this.Energy_Label_Name.ReadOnly = true;
            // 
            // Material_Actual_Qty
            // 
            this.Material_Actual_Qty.DataPropertyName = "Material_Actual_Qty";
            this.Material_Actual_Qty.HeaderText = "实际数量            Actual Qty";
            this.Material_Actual_Qty.Name = "Material_Actual_Qty";
            this.Material_Actual_Qty.ReadOnly = true;
            this.Material_Actual_Qty.Width = 160;
            // 
            // Material_Theory_Qty
            // 
            this.Material_Theory_Qty.DataPropertyName = "Material_Theory_Qty";
            this.Material_Theory_Qty.HeaderText = "理论数量            Theoretical Qty ";
            this.Material_Theory_Qty.Name = "Material_Theory_Qty";
            this.Material_Theory_Qty.ReadOnly = true;
            this.Material_Theory_Qty.Width = 160;
            // 
            // Material_Image
            // 
            this.Material_Image.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Material_Image.HeaderText = "能耗贴图片     Image";
            this.Material_Image.Name = "Material_Image";
            this.Material_Image.ReadOnly = true;
            this.Material_Image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Material_Image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Material_Image.Text = "查看图片 Check";
            this.Material_Image.UseColumnTextForButtonValue = true;
            this.Material_Image.Width = 150;
            // 
            // FrmEnergyBin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmEnergyBin";
            this.Text = "FrmEnergyBin";
            this.Load += new System.EventHandler(this.FrmEnergyBin_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCommon;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Energy_Label_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Energy_Label_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Actual_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Theory_Qty;
        private System.Windows.Forms.DataGridViewButtonColumn Material_Image;
    }
}