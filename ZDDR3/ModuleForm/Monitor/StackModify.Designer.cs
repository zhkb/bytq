namespace Monitor
{
    partial class StackModify
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_different = new System.Windows.Forms.Label();
            this.lbl_ActualNum = new System.Windows.Forms.Label();
            this.lbl_PlanNum = new System.Windows.Forms.Label();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.panel5.Controls.Add(this.lbl_different);
            this.panel5.Controls.Add(this.lbl_ActualNum);
            this.panel5.Controls.Add(this.lbl_PlanNum);
            this.panel5.Controls.Add(this.lbl_Code);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(215, 240);
            this.panel5.TabIndex = 4;
            // 
            // lbl_different
            // 
            this.lbl_different.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_different.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_different.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_different.ForeColor = System.Drawing.Color.Gold;
            this.lbl_different.Location = new System.Drawing.Point(0, 180);
            this.lbl_different.Name = "lbl_different";
            this.lbl_different.Size = new System.Drawing.Size(215, 55);
            this.lbl_different.TabIndex = 7;
            this.lbl_different.Text = "0";
            this.lbl_different.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ActualNum
            // 
            this.lbl_ActualNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ActualNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_ActualNum.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_ActualNum.ForeColor = System.Drawing.Color.Gold;
            this.lbl_ActualNum.Location = new System.Drawing.Point(0, 120);
            this.lbl_ActualNum.Name = "lbl_ActualNum";
            this.lbl_ActualNum.Size = new System.Drawing.Size(215, 60);
            this.lbl_ActualNum.TabIndex = 6;
            this.lbl_ActualNum.Text = "234";
            this.lbl_ActualNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PlanNum
            // 
            this.lbl_PlanNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_PlanNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_PlanNum.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_PlanNum.ForeColor = System.Drawing.Color.Gold;
            this.lbl_PlanNum.Location = new System.Drawing.Point(0, 60);
            this.lbl_PlanNum.Name = "lbl_PlanNum";
            this.lbl_PlanNum.Size = new System.Drawing.Size(215, 60);
            this.lbl_PlanNum.TabIndex = 5;
            this.lbl_PlanNum.Text = "234";
            this.lbl_PlanNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Code
            // 
            this.lbl_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Code.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_Code.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_Code.ForeColor = System.Drawing.Color.Gold;
            this.lbl_Code.Location = new System.Drawing.Point(0, 0);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(215, 60);
            this.lbl_Code.TabIndex = 4;
            this.lbl_Code.Text = "GA0SZW01B";
            this.lbl_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StackModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 240);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StackModify";
            this.Text = "StackModify";
            this.Load += new System.EventHandler(this.StackModify_Load);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_different;
        private System.Windows.Forms.Label lbl_ActualNum;
        private System.Windows.Forms.Label lbl_PlanNum;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Timer timer1;
    }
}