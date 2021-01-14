namespace Material
{
    partial class FrmMaterialList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialList));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PartGrid = new System.Windows.Forms.DataGridView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.Material_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.PartGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 405);
            this.panel1.TabIndex = 0;
            // 
            // PartGrid
            // 
            this.PartGrid.AllowUserToAddRows = false;
            this.PartGrid.AllowUserToResizeColumns = false;
            this.PartGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.PartGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PartGrid.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PartGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PartGrid.ColumnHeadersHeight = 30;
            this.PartGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PartGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Material_Code,
            this.Material_Name});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PartGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.PartGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.PartGrid.Location = new System.Drawing.Point(0, 0);
            this.PartGrid.MultiSelect = false;
            this.PartGrid.Name = "PartGrid";
            this.PartGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 14F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PartGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.PartGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.PartGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.PartGrid.RowTemplate.Height = 30;
            this.PartGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartGrid.Size = new System.Drawing.Size(419, 362);
            this.PartGrid.TabIndex = 4;
            this.PartGrid.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.PartGrid_RowStateChanged);
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
            this.imageList.Images.SetKeyName(6, "update.png");
            this.imageList.Images.SetKeyName(7, "Down.ico");
            this.imageList.Images.SetKeyName(8, "Delete.ico");
            this.imageList.Images.SetKeyName(9, "End.ico");
            // 
            // Material_Code
            // 
            this.Material_Code.DataPropertyName = "Material_Code";
            this.Material_Code.HeaderText = "物料编码";
            this.Material_Code.Name = "Material_Code";
            this.Material_Code.ReadOnly = true;
            this.Material_Code.Width = 120;
            // 
            // Material_Name
            // 
            this.Material_Name.DataPropertyName = "Material_Name";
            this.Material_Name.HeaderText = "物料名称";
            this.Material_Name.Name = "Material_Name";
            this.Material_Name.ReadOnly = true;
            this.Material_Name.Width = 200;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btn_Down);
            this.panel2.Controls.Add(this.btn_Refresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 362);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(419, 35);
            this.panel2.TabIndex = 5;
            // 
            // btn_Down
            // 
            this.btn_Down.BackColor = System.Drawing.Color.White;
            this.btn_Down.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Down.BackgroundImage")));
            this.btn_Down.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Down.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Down.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Down.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Down.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Down.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Down.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Down.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Down.ImageIndex = 7;
            this.btn_Down.ImageList = this.imageList;
            this.btn_Down.Location = new System.Drawing.Point(257, 0);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(80, 33);
            this.btn_Down.TabIndex = 30;
            this.btn_Down.Text = "下传";
            this.btn_Down.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Down.UseVisualStyleBackColor = false;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.White;
            this.btn_Refresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.BackgroundImage")));
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Refresh.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Refresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Refresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Refresh.ImageIndex = 6;
            this.btn_Refresh.ImageList = this.imageList;
            this.btn_Refresh.Location = new System.Drawing.Point(337, 0);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(80, 33);
            this.btn_Refresh.TabIndex = 29;
            this.btn_Refresh.Text = "刷新";
            this.btn_Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // FrmMaterialList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(419, 405);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMaterialList";
            this.Text = "物料列表";
            this.Load += new System.EventHandler(this.FrmMaterialList_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PartGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView PartGrid;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Material_Name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Refresh;
    }
}