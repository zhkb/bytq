namespace Monitor
{
    partial class FrmStoreTask2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_Record = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bar_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Task_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Store_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_Record2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Record)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Record2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1924, 596);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.tabPage1.Controls.Add(this.dgv_Record);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1916, 552);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "入库任务";
            // 
            // dgv_Record
            // 
            this.dgv_Record.AllowUserToAddRows = false;
            this.dgv_Record.AllowUserToDeleteRows = false;
            this.dgv_Record.AllowUserToResizeColumns = false;
            this.dgv_Record.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Record.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Record.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.dgv_Record.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Record.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Record.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Record.ColumnHeadersHeight = 64;
            this.dgv_Record.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Material_Name,
            this.Bar_Code,
            this.Task_From,
            this.Task_To,
            this.Task_State,
            this.Start_Time,
            this.Store_Code});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Record.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Record.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Record.Enabled = false;
            this.dgv_Record.EnableHeadersVisualStyles = false;
            this.dgv_Record.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgv_Record.Location = new System.Drawing.Point(3, 3);
            this.dgv_Record.Name = "dgv_Record";
            this.dgv_Record.ReadOnly = true;
            this.dgv_Record.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Record.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Record.RowHeadersVisible = false;
            this.dgv_Record.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.dgv_Record.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Record.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Record.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.dgv_Record.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.dgv_Record.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_Record.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.dgv_Record.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_Record.RowTemplate.Height = 64;
            this.dgv_Record.RowTemplate.ReadOnly = true;
            this.dgv_Record.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Record.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Record.Size = new System.Drawing.Size(1910, 546);
            this.dgv_Record.TabIndex = 5;
            this.dgv_Record.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_Record_RowStateChanged);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "No";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Material_Name
            // 
            this.Material_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "物料名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            // 
            // Bar_Code
            // 
            this.Bar_Code.DataPropertyName = "Bar_Code";
            this.Bar_Code.HeaderText = "条码";
            this.Bar_Code.Name = "Bar_Code";
            this.Bar_Code.ReadOnly = true;
            this.Bar_Code.Width = 330;
            // 
            // Task_From
            // 
            this.Task_From.DataPropertyName = "Task_From";
            this.Task_From.HeaderText = "起始地";
            this.Task_From.Name = "Task_From";
            this.Task_From.ReadOnly = true;
            this.Task_From.Width = 166;
            // 
            // Task_To
            // 
            this.Task_To.DataPropertyName = "Task_To";
            this.Task_To.HeaderText = "目的地";
            this.Task_To.Name = "Task_To";
            this.Task_To.ReadOnly = true;
            this.Task_To.Width = 166;
            // 
            // Task_State
            // 
            this.Task_State.DataPropertyName = "Task_State";
            this.Task_State.HeaderText = "状态";
            this.Task_State.Name = "Task_State";
            this.Task_State.ReadOnly = true;
            this.Task_State.Width = 120;
            // 
            // Start_Time
            // 
            this.Start_Time.DataPropertyName = "Start_Time";
            this.Start_Time.HeaderText = "开始时间";
            this.Start_Time.Name = "Start_Time";
            this.Start_Time.ReadOnly = true;
            this.Start_Time.Width = 306;
            // 
            // Store_Code
            // 
            this.Store_Code.DataPropertyName = "Store_Code";
            this.Store_Code.HeaderText = "Store_Code";
            this.Store_Code.Name = "Store_Code";
            this.Store_Code.ReadOnly = true;
            this.Store_Code.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.tabPage2.Controls.Add(this.dgv_Record2);
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1916, 552);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "出库任务";
            // 
            // dgv_Record2
            // 
            this.dgv_Record2.AllowUserToAddRows = false;
            this.dgv_Record2.AllowUserToDeleteRows = false;
            this.dgv_Record2.AllowUserToResizeColumns = false;
            this.dgv_Record2.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgv_Record2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Record2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.dgv_Record2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Record2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Record2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Record2.ColumnHeadersHeight = 65;
            this.dgv_Record2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Record2.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Record2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Record2.Enabled = false;
            this.dgv_Record2.EnableHeadersVisualStyles = false;
            this.dgv_Record2.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgv_Record2.Location = new System.Drawing.Point(3, 3);
            this.dgv_Record2.Name = "dgv_Record2";
            this.dgv_Record2.ReadOnly = true;
            this.dgv_Record2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 18F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Record2.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Record2.RowHeadersVisible = false;
            this.dgv_Record2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.dgv_Record2.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_Record2.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_Record2.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.dgv_Record2.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.dgv_Record2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Gold;
            this.dgv_Record2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.dgv_Record2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Gold;
            this.dgv_Record2.RowTemplate.Height = 65;
            this.dgv_Record2.RowTemplate.ReadOnly = true;
            this.dgv_Record2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Record2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_Record2.Size = new System.Drawing.Size(1910, 546);
            this.dgv_Record2.TabIndex = 6;
            this.dgv_Record2.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dgv_Record2_RowStateChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Material_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "物料名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Bar_Code";
            this.dataGridViewTextBoxColumn3.HeaderText = "条码";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 330;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Task_From";
            this.dataGridViewTextBoxColumn4.HeaderText = "起始地";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 166;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Task_To";
            this.dataGridViewTextBoxColumn5.HeaderText = "目的地";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 166;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Task_State";
            this.dataGridViewTextBoxColumn6.HeaderText = "状态";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Start_Time";
            this.dataGridViewTextBoxColumn7.HeaderText = "开始时间";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 306;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Store_Code";
            this.dataGridViewTextBoxColumn8.HeaderText = "Store_Code";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // FrmStoreTask2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 596);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmStoreTask2";
            this.Text = "FrmStoreTask2";
            this.Load += new System.EventHandler(this.FrmStoreTask2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Record)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Record2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgv_Record;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bar_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_From;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_To;
        private System.Windows.Forms.DataGridViewTextBoxColumn Task_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Store_Code;
        private System.Windows.Forms.DataGridView dgv_Record2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}