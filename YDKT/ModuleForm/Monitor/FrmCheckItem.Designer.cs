namespace Monitor
{
    partial class FrmCheckItem
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
            this.btn_item = new System.Windows.Forms.Button();
            this.lbl_Detail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_item
            // 
            this.btn_item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.btn_item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_item.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.btn_item.ForeColor = System.Drawing.Color.White;
            this.btn_item.Location = new System.Drawing.Point(0, 0);
            this.btn_item.Name = "btn_item";
            this.btn_item.Size = new System.Drawing.Size(350, 80);
            this.btn_item.TabIndex = 38;
            this.btn_item.Text = "不合格项 1\r\nUnqualified Item 1";
            this.btn_item.UseVisualStyleBackColor = false;
            this.btn_item.Click += new System.EventHandler(this.btn_item_Click);
            // 
            // lbl_Detail
            // 
            this.lbl_Detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lbl_Detail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Detail.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_Detail.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Detail.Location = new System.Drawing.Point(0, 0);
            this.lbl_Detail.Name = "lbl_Detail";
            this.lbl_Detail.Size = new System.Drawing.Size(350, 80);
            this.lbl_Detail.TabIndex = 39;
            this.lbl_Detail.Text = "质检项目列表\r\nCheck item list";
            this.lbl_Detail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmCheckItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(350, 80);
            this.Controls.Add(this.lbl_Detail);
            this.Controls.Add(this.btn_item);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCheckItem";
            this.Text = "FrmCheckItem";
            this.Load += new System.EventHandler(this.FrmCheckItem_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_item;
        private System.Windows.Forms.Label lbl_Detail;
    }
}