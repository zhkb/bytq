namespace Monitor
{
    partial class FrmFPMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_fp = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Use_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 50);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(846, 50);
            this.label3.TabIndex = 13;
            this.label3.Text = "发泡叫料信息";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_Name);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbl_Code);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 45);
            this.panel2.TabIndex = 1;
            // 
            // lbl_Name
            // 
            this.lbl_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lbl_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Name.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Name.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Name.Location = new System.Drawing.Point(419, 0);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(427, 45);
            this.lbl_Name.TabIndex = 15;
            this.lbl_Name.Text = "BCD-505WNCDF";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(269, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 45);
            this.label2.TabIndex = 14;
            this.label2.Text = "出库产品";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Code
            // 
            this.lbl_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.lbl_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Code.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_Code.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Code.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Code.Location = new System.Drawing.Point(150, 0);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(119, 45);
            this.lbl_Code.TabIndex = 13;
            this.lbl_Code.Text = "26";
            this.lbl_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 45);
            this.label9.TabIndex = 12;
            this.label9.Text = "出库序号";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_fp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 95);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(846, 448);
            this.panel3.TabIndex = 2;
            // 
            // dgv_fp
            // 
            this.dgv_fp.AllowUserToAddRows = false;
            this.dgv_fp.AllowUserToDeleteRows = false;
            this.dgv_fp.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_fp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_fp.ColumnHeadersHeight = 45;
            this.dgv_fp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_fp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Material_Name,
            this.MX,
            this.Use_Flag});
            this.dgv_fp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_fp.EnableHeadersVisualStyles = false;
            this.dgv_fp.GridColor = System.Drawing.Color.White;
            this.dgv_fp.Location = new System.Drawing.Point(0, 0);
            this.dgv_fp.Name = "dgv_fp";
            this.dgv_fp.ReadOnly = true;
            this.dgv_fp.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_fp.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_fp.RowHeadersVisible = false;
            this.dgv_fp.RowHeadersWidth = 100;
            this.dgv_fp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.dgv_fp.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_fp.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_fp.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_fp.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_fp.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.dgv_fp.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_fp.RowTemplate.Height = 40;
            this.dgv_fp.RowTemplate.ReadOnly = true;
            this.dgv_fp.Size = new System.Drawing.Size(846, 448);
            this.dgv_fp.TabIndex = 5;
            this.dgv_fp.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_fp_DataBindingComplete);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID.HeaderText = "出库序号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 180;
            // 
            // Material_Name
            // 
            this.Material_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Material_Name.DataPropertyName = "Material_Name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Material_Name.DefaultCellStyle = dataGridViewCellStyle3;
            this.Material_Name.HeaderText = "出库型号";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Material_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MX
            // 
            this.MX.DataPropertyName = "MX";
            this.MX.HeaderText = "MX";
            this.MX.Name = "MX";
            this.MX.ReadOnly = true;
            this.MX.Visible = false;
            // 
            // Use_Flag
            // 
            this.Use_Flag.DataPropertyName = "Use_Flag";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Use_Flag.DefaultCellStyle = dataGridViewCellStyle4;
            this.Use_Flag.HeaderText = "出库状态";
            this.Use_Flag.Name = "Use_Flag";
            this.Use_Flag.ReadOnly = true;
            this.Use_Flag.Width = 250;
            // 
            // FrmFPMonitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(846, 543);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFPMonitor";
            this.Text = "FrmFPMonitor";
            this.Load += new System.EventHandler(this.FrmFPMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_fp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgv_fp;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn MX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Use_Flag;
    }
}