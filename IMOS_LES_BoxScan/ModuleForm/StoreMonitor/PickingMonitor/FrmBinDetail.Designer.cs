namespace PickingMonitor
{
    partial class FrmBinDetail
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
            this.lbl_BinNo = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbl_BinNo
            // 
            this.lbl_BinNo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbl_BinNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_BinNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_BinNo.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_BinNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_BinNo.Location = new System.Drawing.Point(0, 0);
            this.lbl_BinNo.Name = "lbl_BinNo";
            this.lbl_BinNo.Size = new System.Drawing.Size(96, 40);
            this.lbl_BinNo.TabIndex = 1;
            this.lbl_BinNo.Text = "001";
            this.lbl_BinNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_BinNo.DoubleClick += new System.EventHandler(this.lbl_BinNo_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmBinDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(96, 40);
            this.Controls.Add(this.lbl_BinNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBinDetail";
            this.Text = "FrmBinDetail";
            this.Load += new System.EventHandler(this.FrmBinDetail_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_BinNo;
        private System.Windows.Forms.Timer timer1;
    }
}