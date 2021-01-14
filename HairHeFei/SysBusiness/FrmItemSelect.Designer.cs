namespace Sys.SysBusiness
{
    partial class FrmItemSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItemSelect));
            this.lv_DataList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lv_DataList
            // 
            this.lv_DataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader9});
            this.lv_DataList.Font = new System.Drawing.Font("宋体", 14F);
            this.lv_DataList.FullRowSelect = true;
            this.lv_DataList.Location = new System.Drawing.Point(3, 56);
            this.lv_DataList.Name = "lv_DataList";
            this.lv_DataList.Size = new System.Drawing.Size(437, 308);
            this.lv_DataList.TabIndex = 8;
            this.lv_DataList.UseCompatibleStateImageBehavior = false;
            this.lv_DataList.View = System.Windows.Forms.View.Details;
            this.lv_DataList.DoubleClick += new System.EventHandler(this.lv_DataList_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "序号";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "编码";
            this.columnHeader5.Width = 117;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "名称";
            this.columnHeader9.Width = 216;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.BackgroundImage")));
            this.btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_Cancel.Location = new System.Drawing.Point(360, 368);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(80, 40);
            this.btn_Cancel.TabIndex = 10;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_OK.Location = new System.Drawing.Point(277, 368);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(80, 40);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.lv_DataList_DoubleClick);
            // 
            // FrmItemSelect
            // 
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 411);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lv_DataList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmItemSelect";
            this.Text = "请选择列表信息";
            this.Load += new System.EventHandler(this.FrmItemSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_DataList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}