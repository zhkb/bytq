namespace Monitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_Store = new System.Windows.Forms.DataGridView();
            this.Bin_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Max_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Use_FlagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_FlagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Out_FlagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abnormal_FlagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bin_UseFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bin_InFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bin_OutFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bin_AbnormalFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Store)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 60);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1212, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1370, 60);
            this.label4.TabIndex = 3;
            this.label4.Text = "箱体寄存库实时监控";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_Store);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1370, 438);
            this.panel2.TabIndex = 1;
            // 
            // dgv_Store
            // 
            this.dgv_Store.AllowUserToAddRows = false;
            this.dgv_Store.AllowUserToResizeColumns = false;
            this.dgv_Store.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Store.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Store.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.dgv_Store.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Store.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Store.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Store.ColumnHeadersHeight = 45;
            this.dgv_Store.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Store.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bin_No,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Max_Qty,
            this.Store_Qty,
            this.Store_Rate,
            this.Use_FlagName,
            this.In_FlagName,
            this.Out_FlagName,
            this.Abnormal_FlagName,
            this.Bin_UseFlag,
            this.Bin_InFlag,
            this.Bin_OutFlag,
            this.Bin_AbnormalFlag});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Store.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Store.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Store.EnableHeadersVisualStyles = false;
            this.dgv_Store.Location = new System.Drawing.Point(0, 35);
            this.dgv_Store.MultiSelect = false;
            this.dgv_Store.Name = "dgv_Store";
            this.dgv_Store.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Store.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Store.RowHeadersVisible = false;
            this.dgv_Store.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgv_Store.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Store.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Yellow;
            this.dgv_Store.RowTemplate.Height = 45;
            this.dgv_Store.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Store.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Store.Size = new System.Drawing.Size(1370, 403);
            this.dgv_Store.TabIndex = 20;
            this.dgv_Store.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_Store_RowPrePaint);
            // 
            // Bin_No
            // 
            this.Bin_No.DataPropertyName = "Bin_No";
            this.Bin_No.HeaderText = "货道";
            this.Bin_No.Name = "Bin_No";
            this.Bin_No.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Material_Code";
            this.dataGridViewTextBoxColumn6.HeaderText = "物料编码";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Material_Name";
            this.dataGridViewTextBoxColumn7.HeaderText = "物料名称";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 400;
            // 
            // Max_Qty
            // 
            this.Max_Qty.DataPropertyName = "Max_Qty";
            this.Max_Qty.HeaderText = "理论库存";
            this.Max_Qty.Name = "Max_Qty";
            this.Max_Qty.ReadOnly = true;
            this.Max_Qty.Width = 150;
            // 
            // Store_Qty
            // 
            this.Store_Qty.DataPropertyName = "Store_Qty";
            this.Store_Qty.HeaderText = "实际库存";
            this.Store_Qty.Name = "Store_Qty";
            this.Store_Qty.ReadOnly = true;
            this.Store_Qty.Width = 150;
            // 
            // Store_Rate
            // 
            this.Store_Rate.DataPropertyName = "Store_Rate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Store_Rate.DefaultCellStyle = dataGridViewCellStyle3;
            this.Store_Rate.HeaderText = "库存占用率";
            this.Store_Rate.Name = "Store_Rate";
            this.Store_Rate.ReadOnly = true;
            this.Store_Rate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Store_Rate.Width = 150;
            // 
            // Use_FlagName
            // 
            this.Use_FlagName.DataPropertyName = "Use_FlagName";
            this.Use_FlagName.HeaderText = "使用";
            this.Use_FlagName.Name = "Use_FlagName";
            this.Use_FlagName.ReadOnly = true;
            // 
            // In_FlagName
            // 
            this.In_FlagName.DataPropertyName = "In_FlagName";
            this.In_FlagName.HeaderText = "入库";
            this.In_FlagName.Name = "In_FlagName";
            this.In_FlagName.ReadOnly = true;
            // 
            // Out_FlagName
            // 
            this.Out_FlagName.DataPropertyName = "Out_FlagName";
            this.Out_FlagName.HeaderText = "出库";
            this.Out_FlagName.Name = "Out_FlagName";
            this.Out_FlagName.ReadOnly = true;
            // 
            // Abnormal_FlagName
            // 
            this.Abnormal_FlagName.DataPropertyName = "Abnormal_FlagName";
            this.Abnormal_FlagName.HeaderText = "异常";
            this.Abnormal_FlagName.Name = "Abnormal_FlagName";
            this.Abnormal_FlagName.ReadOnly = true;
            // 
            // Bin_UseFlag
            // 
            this.Bin_UseFlag.DataPropertyName = "Bin_UseFlag";
            this.Bin_UseFlag.HeaderText = "Bin_UseFlag";
            this.Bin_UseFlag.Name = "Bin_UseFlag";
            this.Bin_UseFlag.ReadOnly = true;
            this.Bin_UseFlag.Visible = false;
            // 
            // Bin_InFlag
            // 
            this.Bin_InFlag.DataPropertyName = "Bin_InFlag";
            this.Bin_InFlag.HeaderText = "Bin_InFlag";
            this.Bin_InFlag.Name = "Bin_InFlag";
            this.Bin_InFlag.ReadOnly = true;
            this.Bin_InFlag.Visible = false;
            // 
            // Bin_OutFlag
            // 
            this.Bin_OutFlag.DataPropertyName = "Bin_OutFlag";
            this.Bin_OutFlag.HeaderText = "Bin_OutFlag";
            this.Bin_OutFlag.Name = "Bin_OutFlag";
            this.Bin_OutFlag.ReadOnly = true;
            this.Bin_OutFlag.Visible = false;
            // 
            // Bin_AbnormalFlag
            // 
            this.Bin_AbnormalFlag.DataPropertyName = "Bin_AbnormalFlag";
            this.Bin_AbnormalFlag.HeaderText = "Bin_AbnormalFlag";
            this.Bin_AbnormalFlag.Name = "Bin_AbnormalFlag";
            this.Bin_AbnormalFlag.ReadOnly = true;
            this.Bin_AbnormalFlag.Visible = false;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1370, 35);
            this.label7.TabIndex = 19;
            this.label7.Text = "门壳实时库存";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1370, 438);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.splitter1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 498);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1370, 251);
            this.panel4.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, -218);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1370, 469);
            this.panel5.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1370, 35);
            this.label5.TabIndex = 17;
            this.label5.Text = "当前吊笼编号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1370, 8);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // FrmStoreMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmStoreMonitor";
            this.Text = "门壳输送";
            this.Load += new System.EventHandler(this.FrmStoreMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Store)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_Store;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Max_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Use_FlagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn In_FlagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Out_FlagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abnormal_FlagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin_UseFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin_InFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin_OutFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bin_AbnormalFlag;
    }
}