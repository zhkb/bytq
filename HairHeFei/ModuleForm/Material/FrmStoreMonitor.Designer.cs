namespace Material
{
    partial class FrmStoreMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvCommon = new System.Windows.Forms.DataGridView();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transit_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Use_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Create_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Updated_By = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvCommon);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1904, 1041);
            this.panel3.TabIndex = 2;
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
            this.dgvCommon.ColumnHeadersHeight = 40;
            this.dgvCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCommon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Material_Code,
            this.Material_Name,
            this.Area_Code,
            this.Area_Name,
            this.Store_Code,
            this.Store_Qty,
            this.Transit_Qty,
            this.Max_Qty,
            this.Use_Flag,
            this.Create_Time,
            this.Created_By,
            this.Update_Time,
            this.Last_Updated_By,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommon.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCommon.GridColor = System.Drawing.Color.Gray;
            this.dgvCommon.Location = new System.Drawing.Point(0, 0);
            this.dgvCommon.MultiSelect = false;
            this.dgvCommon.Name = "dgvCommon";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommon.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCommon.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCommon.RowTemplate.Height = 40;
            this.dgvCommon.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCommon.Size = new System.Drawing.Size(1904, 1041);
            this.dgvCommon.TabIndex = 11;
            this.dgvCommon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCommon_CellClick);
            this.dgvCommon.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgvCommon_RowStateChanged);
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "物料编码";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Width = 150;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "物料名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Width = 300;
            // 
            // Area_Code
            // 
            this.Area_Code.DataPropertyName = "Area_Code";
            this.Area_Code.HeaderText = "库位号";
            this.Area_Code.Name = "Area_Code";
            this.Area_Code.ReadOnly = true;
            // 
            // Area_Name
            // 
            this.Area_Name.DataPropertyName = "Area_Name";
            this.Area_Name.HeaderText = "库位名称";
            this.Area_Name.Name = "Area_Name";
            this.Area_Name.ReadOnly = true;
            // 
            // Store_Code
            // 
            this.Store_Code.DataPropertyName = "Store_Code";
            this.Store_Code.HeaderText = "货道号";
            this.Store_Code.Name = "Store_Code";
            this.Store_Code.ReadOnly = true;
            // 
            // Store_Qty
            // 
            this.Store_Qty.DataPropertyName = "Store_Qty";
            this.Store_Qty.HeaderText = "在库量";
            this.Store_Qty.Name = "Store_Qty";
            this.Store_Qty.ReadOnly = true;
            // 
            // Transit_Qty
            // 
            this.Transit_Qty.DataPropertyName = "Transit_Qty";
            this.Transit_Qty.HeaderText = "在途量";
            this.Transit_Qty.Name = "Transit_Qty";
            this.Transit_Qty.ReadOnly = true;
            // 
            // Max_Qty
            // 
            this.Max_Qty.DataPropertyName = "Max_Qty";
            this.Max_Qty.HeaderText = "最大库存";
            this.Max_Qty.Name = "Max_Qty";
            this.Max_Qty.ReadOnly = true;
            // 
            // Use_Flag
            // 
            this.Use_Flag.DataPropertyName = "Use_Flag";
            this.Use_Flag.HeaderText = "使用标志";
            this.Use_Flag.Name = "Use_Flag";
            this.Use_Flag.ReadOnly = true;
            // 
            // Create_Time
            // 
            this.Create_Time.DataPropertyName = "Create_Time";
            this.Create_Time.HeaderText = "创建时间";
            this.Create_Time.Name = "Create_Time";
            this.Create_Time.ReadOnly = true;
            this.Create_Time.Width = 300;
            // 
            // Created_By
            // 
            this.Created_By.DataPropertyName = "Created_By";
            this.Created_By.HeaderText = "创建人";
            this.Created_By.Name = "Created_By";
            this.Created_By.ReadOnly = true;
            this.Created_By.Visible = false;
            // 
            // Update_Time
            // 
            this.Update_Time.DataPropertyName = "Update_Time";
            this.Update_Time.HeaderText = "修改时间";
            this.Update_Time.Name = "Update_Time";
            this.Update_Time.ReadOnly = true;
            this.Update_Time.Width = 300;
            // 
            // Last_Updated_By
            // 
            this.Last_Updated_By.DataPropertyName = "Last_Updated_By";
            this.Last_Updated_By.HeaderText = "修改人";
            this.Last_Updated_By.Name = "Last_Updated_By";
            this.Last_Updated_By.ReadOnly = true;
            this.Last_Updated_By.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "操作";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // FrmStoreMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel3);
            this.Name = "FrmStoreMonitor";
            this.Text = "FrmStoreMonitor";
            this.Load += new System.EventHandler(this.FrmStoreMonitor_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvCommon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transit_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Use_Flag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Create_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Update_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Updated_By;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}