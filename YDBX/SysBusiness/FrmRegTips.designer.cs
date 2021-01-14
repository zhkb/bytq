namespace Sys.SysBusiness
{
    partial class FrmRegTips
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegTips));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_RegInfo3 = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_RegInfo2 = new System.Windows.Forms.Label();
            this.lbl_RegInfo1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_RegInfo3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("宋体", 14F);
            this.panel2.Location = new System.Drawing.Point(0, 135);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 40);
            this.panel2.TabIndex = 5;
            // 
            // lbl_RegInfo3
            // 
            this.lbl_RegInfo3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_RegInfo3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_RegInfo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_RegInfo3.Location = new System.Drawing.Point(0, 0);
            this.lbl_RegInfo3.Name = "lbl_RegInfo3";
            this.lbl_RegInfo3.Size = new System.Drawing.Size(532, 40);
            this.lbl_RegInfo3.TabIndex = 2;
            this.lbl_RegInfo3.Text = " ";
            this.lbl_RegInfo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Find.ico");
            this.imageList.Images.SetKeyName(1, "Clear.ico");
            this.imageList.Images.SetKeyName(2, "Cancel.ico");
            this.imageList.Images.SetKeyName(3, "ok.ico");
            this.imageList.Images.SetKeyName(4, "Reg.ico");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_RegInfo2);
            this.panel1.Controls.Add(this.lbl_RegInfo1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("宋体", 14F);
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 80);
            this.panel1.TabIndex = 6;
            // 
            // lbl_RegInfo2
            // 
            this.lbl_RegInfo2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_RegInfo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_RegInfo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_RegInfo2.Location = new System.Drawing.Point(0, 40);
            this.lbl_RegInfo2.Name = "lbl_RegInfo2";
            this.lbl_RegInfo2.Size = new System.Drawing.Size(532, 40);
            this.lbl_RegInfo2.TabIndex = 1;
            this.lbl_RegInfo2.Text = " ";
            this.lbl_RegInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_RegInfo1
            // 
            this.lbl_RegInfo1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_RegInfo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_RegInfo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_RegInfo1.Location = new System.Drawing.Point(0, 0);
            this.lbl_RegInfo1.Name = "lbl_RegInfo1";
            this.lbl_RegInfo1.Size = new System.Drawing.Size(532, 40);
            this.lbl_RegInfo1.TabIndex = 0;
            this.lbl_RegInfo1.Text = " ";
            this.lbl_RegInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmRegTips
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 175);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegTips";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统注册";
            this.Load += new System.EventHandler(this.FrmRegTips_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_RegInfo2;
        private System.Windows.Forms.Label lbl_RegInfo1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label lbl_RegInfo3;
    }
}