namespace Sys.SysBusiness
{
    partial class FrmTip
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
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer2 = new System.Windows.Forms.Timer();
            this.timer3 = new System.Windows.Forms.Timer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lst_tipslist = new System.Windows.Forms.ListBox();
            this.pic_DBState = new System.Windows.Forms.PictureBox();
            this.btn_Hide = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBState)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pic_DBState);
            this.panel1.Controls.Add(this.btn_Hide);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 424);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 39);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lst_tipslist);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 424);
            this.panel2.TabIndex = 6;
            // 
            // lst_tipslist
            // 
            this.lst_tipslist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_tipslist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_tipslist.Font = new System.Drawing.Font("宋体", 16F);
            this.lst_tipslist.FormattingEnabled = true;
            this.lst_tipslist.ItemHeight = 21;
            this.lst_tipslist.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lst_tipslist.Location = new System.Drawing.Point(0, 0);
            this.lst_tipslist.Name = "lst_tipslist";
            this.lst_tipslist.Size = new System.Drawing.Size(741, 422);
            this.lst_tipslist.TabIndex = 7;
            // 
            // pic_DBState
            // 
            this.pic_DBState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.pic_DBState.Image = global::Sys.SysBusiness.Properties.Resources.Status_Green;
            this.pic_DBState.Location = new System.Drawing.Point(364, 12);
            this.pic_DBState.Name = "pic_DBState";
            this.pic_DBState.Size = new System.Drawing.Size(15, 15);
            this.pic_DBState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_DBState.TabIndex = 30;
            this.pic_DBState.TabStop = false;
            // 
            // btn_Hide
            // 
            this.btn_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Hide.BackColor = System.Drawing.Color.White;
            this.btn_Hide.BackgroundImage = global::Sys.SysBusiness.Properties.Resources.button;
            this.btn_Hide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Hide.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Hide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Hide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Hide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Hide.Font = new System.Drawing.Font("宋体", 14F);
            this.btn_Hide.Location = new System.Drawing.Point(671, 2);
            this.btn_Hide.Name = "btn_Hide";
            this.btn_Hide.Size = new System.Drawing.Size(69, 34);
            this.btn_Hide.TabIndex = 1;
            this.btn_Hide.Text = "隐藏";
            this.btn_Hide.UseVisualStyleBackColor = false;
            this.btn_Hide.Click += new System.EventHandler(this.btn_Hide_Click);
            // 
            // FrmTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 463);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmTip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmTip";
            this.Load += new System.EventHandler(this.FrmTip_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Hide;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lst_tipslist;
        private System.Windows.Forms.PictureBox pic_DBState;
    }
}