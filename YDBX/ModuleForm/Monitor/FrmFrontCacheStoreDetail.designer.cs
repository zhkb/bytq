namespace Monitor
{
    partial class FrmFrontCacheStoreDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFrontCacheStoreDetail));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnl_Title = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_Material_Code = new System.Windows.Forms.Label();
            this.lb_Bin_ID = new System.Windows.Forms.Label();
            this.lb_Bin_Flag = new System.Windows.Forms.Label();
            this.lb_Transit_Qty = new System.Windows.Forms.Label();
            this.lb_Actual_Qty = new System.Windows.Forms.Label();
            this.lb_Max_Qty = new System.Windows.Forms.Label();
            this.lbl_StoreMaterName = new System.Windows.Forms.Label();
            this.lbl_BinNo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pnl_Title.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Green_Status.png");
            this.imageList1.Images.SetKeyName(1, "Light_Status.png");
            this.imageList1.Images.SetKeyName(2, "Blue_Status.png");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnl_Title
            // 
            this.pnl_Title.Controls.Add(this.label1);
            this.pnl_Title.Controls.Add(this.label8);
            this.pnl_Title.Controls.Add(this.label9);
            this.pnl_Title.Controls.Add(this.label10);
            this.pnl_Title.Controls.Add(this.label11);
            this.pnl_Title.Controls.Add(this.label12);
            this.pnl_Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Title.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.pnl_Title.Location = new System.Drawing.Point(0, 0);
            this.pnl_Title.Name = "pnl_Title";
            this.pnl_Title.Size = new System.Drawing.Size(913, 50);
            this.pnl_Title.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(581, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 50);
            this.label1.TabIndex = 13;
            this.label1.Text = "状态\r\nstate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(480, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 50);
            this.label8.TabIndex = 12;
            this.label8.Text = "在途量\r\nTransit Qty";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(379, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 50);
            this.label9.TabIndex = 11;
            this.label9.Text = "实际数量\r\nActual";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(278, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 50);
            this.label10.TabIndex = 10;
            this.label10.Text = "最大量\r\nMax";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(51, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(227, 50);
            this.label11.TabIndex = 9;
            this.label11.Text = "产品型号\r\nProduct Model";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 50);
            this.label12.TabIndex = 8;
            this.label12.Text = "No.";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(913, 70);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(913, 14);
            this.panel2.TabIndex = 14;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lb_Material_Code);
            this.panel5.Controls.Add(this.lb_Bin_ID);
            this.panel5.Controls.Add(this.lb_Bin_Flag);
            this.panel5.Controls.Add(this.lb_Transit_Qty);
            this.panel5.Controls.Add(this.lb_Actual_Qty);
            this.panel5.Controls.Add(this.lb_Max_Qty);
            this.panel5.Controls.Add(this.lbl_StoreMaterName);
            this.panel5.Controls.Add(this.lbl_BinNo);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panel5.Location = new System.Drawing.Point(0, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(913, 50);
            this.panel5.TabIndex = 12;
            // 
            // lb_Material_Code
            // 
            this.lb_Material_Code.AutoSize = true;
            this.lb_Material_Code.Location = new System.Drawing.Point(932, 15);
            this.lb_Material_Code.Name = "lb_Material_Code";
            this.lb_Material_Code.Size = new System.Drawing.Size(55, 21);
            this.lb_Material_Code.TabIndex = 15;
            this.lb_Material_Code.Text = "label2";
            this.lb_Material_Code.Visible = false;
            // 
            // lb_Bin_ID
            // 
            this.lb_Bin_ID.AutoSize = true;
            this.lb_Bin_ID.Location = new System.Drawing.Point(735, 15);
            this.lb_Bin_ID.Name = "lb_Bin_ID";
            this.lb_Bin_ID.Size = new System.Drawing.Size(55, 21);
            this.lb_Bin_ID.TabIndex = 14;
            this.lb_Bin_ID.Text = "label2";
            this.lb_Bin_ID.Visible = false;
            // 
            // lb_Bin_Flag
            // 
            this.lb_Bin_Flag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lb_Bin_Flag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Bin_Flag.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Bin_Flag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Bin_Flag.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.lb_Bin_Flag.ForeColor = System.Drawing.Color.Gold;
            this.lb_Bin_Flag.Location = new System.Drawing.Point(581, 0);
            this.lb_Bin_Flag.Name = "lb_Bin_Flag";
            this.lb_Bin_Flag.Size = new System.Drawing.Size(99, 50);
            this.lb_Bin_Flag.TabIndex = 13;
            this.lb_Bin_Flag.Text = "正常";
            this.lb_Bin_Flag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lb_Bin_Flag.DoubleClick += new System.EventHandler(this.lb_Bin_Flag_DoubleClick);
            // 
            // lb_Transit_Qty
            // 
            this.lb_Transit_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lb_Transit_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Transit_Qty.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Transit_Qty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Transit_Qty.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.lb_Transit_Qty.ForeColor = System.Drawing.Color.Gold;
            this.lb_Transit_Qty.Location = new System.Drawing.Point(480, 0);
            this.lb_Transit_Qty.Name = "lb_Transit_Qty";
            this.lb_Transit_Qty.Size = new System.Drawing.Size(101, 50);
            this.lb_Transit_Qty.TabIndex = 12;
            this.lb_Transit_Qty.Text = "5";
            this.lb_Transit_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Actual_Qty
            // 
            this.lb_Actual_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lb_Actual_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Actual_Qty.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Actual_Qty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Actual_Qty.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.lb_Actual_Qty.ForeColor = System.Drawing.Color.Gold;
            this.lb_Actual_Qty.Location = new System.Drawing.Point(379, 0);
            this.lb_Actual_Qty.Name = "lb_Actual_Qty";
            this.lb_Actual_Qty.Size = new System.Drawing.Size(101, 50);
            this.lb_Actual_Qty.TabIndex = 11;
            this.lb_Actual_Qty.Text = "10";
            this.lb_Actual_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Max_Qty
            // 
            this.lb_Max_Qty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lb_Max_Qty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Max_Qty.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Max_Qty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_Max_Qty.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.lb_Max_Qty.ForeColor = System.Drawing.Color.Gold;
            this.lb_Max_Qty.Location = new System.Drawing.Point(278, 0);
            this.lb_Max_Qty.Name = "lb_Max_Qty";
            this.lb_Max_Qty.Size = new System.Drawing.Size(101, 50);
            this.lb_Max_Qty.TabIndex = 10;
            this.lb_Max_Qty.Text = "20";
            this.lb_Max_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_StoreMaterName
            // 
            this.lbl_StoreMaterName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lbl_StoreMaterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_StoreMaterName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_StoreMaterName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_StoreMaterName.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.lbl_StoreMaterName.ForeColor = System.Drawing.Color.Gold;
            this.lbl_StoreMaterName.Location = new System.Drawing.Point(51, 0);
            this.lbl_StoreMaterName.Name = "lbl_StoreMaterName";
            this.lbl_StoreMaterName.Size = new System.Drawing.Size(227, 50);
            this.lbl_StoreMaterName.TabIndex = 9;
            this.lbl_StoreMaterName.Text = "BC/BD 208";
            this.lbl_StoreMaterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_StoreMaterName.DoubleClick += new System.EventHandler(this.lbl_StoreMaterName_DoubleClick);
            // 
            // lbl_BinNo
            // 
            this.lbl_BinNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lbl_BinNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_BinNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_BinNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_BinNo.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.lbl_BinNo.ForeColor = System.Drawing.Color.Gold;
            this.lbl_BinNo.Location = new System.Drawing.Point(0, 0);
            this.lbl_BinNo.Name = "lbl_BinNo";
            this.lbl_BinNo.Size = new System.Drawing.Size(51, 50);
            this.lbl_BinNo.TabIndex = 8;
            this.lbl_BinNo.Text = "1#";
            this.lbl_BinNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(913, 5);
            this.label7.TabIndex = 0;
            // 
            // FrmFrontCacheStoreDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 120);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnl_Title);
            this.Name = "FrmFrontCacheStoreDetail";
            this.Text = "FrmFrontCacheStoreDetail";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.pnl_Title.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnl_Title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lb_Bin_Flag;
        private System.Windows.Forms.Label lb_Transit_Qty;
        private System.Windows.Forms.Label lb_Actual_Qty;
        private System.Windows.Forms.Label lb_Max_Qty;
        private System.Windows.Forms.Label lbl_StoreMaterName;
        private System.Windows.Forms.Label lbl_BinNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_Bin_ID;
        private System.Windows.Forms.Label lb_Material_Code;
    }
}