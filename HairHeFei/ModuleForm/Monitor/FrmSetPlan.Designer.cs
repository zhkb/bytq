namespace Monitor
{
    partial class FrmSetPlan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Upd_Plan = new System.Windows.Forms.Button();
            this.btn_Del_Plan = new System.Windows.Forms.Button();
            this.btn_Add_Plan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_Plan = new System.Windows.Forms.DataGridView();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Plan_Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Plan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 52);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1163, 52);
            this.label8.TabIndex = 13;
            this.label8.Text = "设置计划";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_Upd_Plan);
            this.panel2.Controls.Add(this.btn_Del_Plan);
            this.panel2.Controls.Add(this.btn_Add_Plan);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1163, 49);
            this.panel2.TabIndex = 1;
            // 
            // btn_Upd_Plan
            // 
            this.btn_Upd_Plan.BackColor = System.Drawing.Color.Green;
            this.btn_Upd_Plan.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Upd_Plan.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Upd_Plan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Upd_Plan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Upd_Plan.ForeColor = System.Drawing.Color.Gold;
            this.btn_Upd_Plan.Location = new System.Drawing.Point(214, 0);
            this.btn_Upd_Plan.Name = "btn_Upd_Plan";
            this.btn_Upd_Plan.Size = new System.Drawing.Size(107, 49);
            this.btn_Upd_Plan.TabIndex = 33;
            this.btn_Upd_Plan.Text = "修改";
            this.btn_Upd_Plan.UseVisualStyleBackColor = false;
            this.btn_Upd_Plan.Click += new System.EventHandler(this.btn_Upd_Plan_Click);
            // 
            // btn_Del_Plan
            // 
            this.btn_Del_Plan.BackColor = System.Drawing.Color.Green;
            this.btn_Del_Plan.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Del_Plan.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Del_Plan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del_Plan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Del_Plan.ForeColor = System.Drawing.Color.Gold;
            this.btn_Del_Plan.Location = new System.Drawing.Point(107, 0);
            this.btn_Del_Plan.Name = "btn_Del_Plan";
            this.btn_Del_Plan.Size = new System.Drawing.Size(107, 49);
            this.btn_Del_Plan.TabIndex = 32;
            this.btn_Del_Plan.Text = "删除";
            this.btn_Del_Plan.UseVisualStyleBackColor = false;
            this.btn_Del_Plan.Click += new System.EventHandler(this.btn_Del_Plan_Click);
            // 
            // btn_Add_Plan
            // 
            this.btn_Add_Plan.BackColor = System.Drawing.Color.Green;
            this.btn_Add_Plan.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Add_Plan.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Add_Plan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add_Plan.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Add_Plan.ForeColor = System.Drawing.Color.Gold;
            this.btn_Add_Plan.Location = new System.Drawing.Point(0, 0);
            this.btn_Add_Plan.Name = "btn_Add_Plan";
            this.btn_Add_Plan.Size = new System.Drawing.Size(107, 49);
            this.btn_Add_Plan.TabIndex = 31;
            this.btn_Add_Plan.Text = "添加";
            this.btn_Add_Plan.UseVisualStyleBackColor = false;
            this.btn_Add_Plan.Click += new System.EventHandler(this.btn_Add_Plan_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_Plan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1163, 271);
            this.panel3.TabIndex = 2;
            // 
            // dgv_Plan
            // 
            this.dgv_Plan.AllowUserToAddRows = false;
            this.dgv_Plan.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Plan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Plan.ColumnHeadersHeight = 45;
            this.dgv_Plan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Plan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Material_Name,
            this.Material_Code,
            this.Material_Plan_Num});
            this.dgv_Plan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Plan.EnableHeadersVisualStyles = false;
            this.dgv_Plan.GridColor = System.Drawing.Color.White;
            this.dgv_Plan.Location = new System.Drawing.Point(0, 0);
            this.dgv_Plan.Name = "dgv_Plan";
            this.dgv_Plan.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Plan.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Plan.RowHeadersWidth = 70;
            this.dgv_Plan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dgv_Plan.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Plan.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Plan.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Plan.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_Plan.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            this.dgv_Plan.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_Plan.RowTemplate.Height = 45;
            this.dgv_Plan.RowTemplate.ReadOnly = true;
            this.dgv_Plan.Size = new System.Drawing.Size(1163, 271);
            this.dgv_Plan.TabIndex = 5;
            this.dgv_Plan.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_Plan_DataBindingComplete);
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "产品型号";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Material_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Material_Name.Width = 450;
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "产品编号";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Visible = false;
            // 
            // Material_Plan_Num
            // 
            this.Material_Plan_Num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Material_Plan_Num.DataPropertyName = "Material_Plan_Num";
            this.Material_Plan_Num.HeaderText = "计划数量";
            this.Material_Plan_Num.Name = "Material_Plan_Num";
            this.Material_Plan_Num.ReadOnly = true;
            // 
            // FrmSetPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1163, 372);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSetPlan";
            this.Text = "FrmSetPlan";
            this.Load += new System.EventHandler(this.FrmSetPlan_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Plan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Del_Plan;
        private System.Windows.Forms.Button btn_Add_Plan;
        private System.Windows.Forms.Button btn_Upd_Plan;
        private System.Windows.Forms.DataGridView dgv_Plan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Plan_Num;
    }
}