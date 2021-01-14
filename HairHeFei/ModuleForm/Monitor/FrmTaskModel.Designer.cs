namespace Monitor
{
    partial class FrmTaskModel
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStart_TimeTOP = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBar_Code = new System.Windows.Forms.Label();
            this.lblTask_Store_Code = new System.Windows.Forms.Label();
            this.lblTask_RFID_Code = new System.Windows.Forms.Label();
            this.lblTask_State = new System.Windows.Forms.Label();
            this.lblStart_Time = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelTop.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label7);
            this.panelTop.Controls.Add(this.label4);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.label11);
            this.panelTop.Controls.Add(this.label12);
            this.panelTop.Controls.Add(this.lblStart_TimeTOP);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1924, 65);
            this.panelTop.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(66, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(659, 65);
            this.label7.TabIndex = 13;
            this.label7.Text = "物料名称";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 65);
            this.label4.TabIndex = 12;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(725, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(327, 65);
            this.label2.TabIndex = 10;
            this.label2.Text = "条码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1052, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 65);
            this.label1.TabIndex = 9;
            this.label1.Text = "货道号";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Dock = System.Windows.Forms.DockStyle.Right;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1218, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(243, 65);
            this.label11.TabIndex = 7;
            this.label11.Text = "吊笼编号";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Dock = System.Windows.Forms.DockStyle.Right;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1461, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 65);
            this.label12.TabIndex = 5;
            this.label12.Text = "状态";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStart_TimeTOP
            // 
            this.lblStart_TimeTOP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lblStart_TimeTOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStart_TimeTOP.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStart_TimeTOP.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblStart_TimeTOP.ForeColor = System.Drawing.Color.White;
            this.lblStart_TimeTOP.Location = new System.Drawing.Point(1623, 0);
            this.lblStart_TimeTOP.Name = "lblStart_TimeTOP";
            this.lblStart_TimeTOP.Size = new System.Drawing.Size(301, 65);
            this.lblStart_TimeTOP.TabIndex = 8;
            this.lblStart_TimeTOP.Text = "开始时间";
            this.lblStart_TimeTOP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblName);
            this.panel4.Controls.Add(this.lblBar_Code);
            this.panel4.Controls.Add(this.lblTask_Store_Code);
            this.panel4.Controls.Add(this.lblTask_RFID_Code);
            this.panel4.Controls.Add(this.lblTask_State);
            this.panel4.Controls.Add(this.lblStart_Time);
            this.panel4.Controls.Add(this.lblID);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 65);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1924, 65);
            this.panel4.TabIndex = 11;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblName.ForeColor = System.Drawing.Color.Gold;
            this.lblName.Location = new System.Drawing.Point(66, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(659, 65);
            this.lblName.TabIndex = 15;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBar_Code
            // 
            this.lblBar_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.lblBar_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBar_Code.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblBar_Code.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblBar_Code.ForeColor = System.Drawing.Color.Gold;
            this.lblBar_Code.Location = new System.Drawing.Point(725, 0);
            this.lblBar_Code.Name = "lblBar_Code";
            this.lblBar_Code.Size = new System.Drawing.Size(327, 65);
            this.lblBar_Code.TabIndex = 14;
            this.lblBar_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTask_Store_Code
            // 
            this.lblTask_Store_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.lblTask_Store_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTask_Store_Code.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTask_Store_Code.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblTask_Store_Code.ForeColor = System.Drawing.Color.Gold;
            this.lblTask_Store_Code.Location = new System.Drawing.Point(1052, 0);
            this.lblTask_Store_Code.Name = "lblTask_Store_Code";
            this.lblTask_Store_Code.Size = new System.Drawing.Size(166, 65);
            this.lblTask_Store_Code.TabIndex = 13;
            this.lblTask_Store_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTask_RFID_Code
            // 
            this.lblTask_RFID_Code.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.lblTask_RFID_Code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTask_RFID_Code.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTask_RFID_Code.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblTask_RFID_Code.ForeColor = System.Drawing.Color.Gold;
            this.lblTask_RFID_Code.Location = new System.Drawing.Point(1218, 0);
            this.lblTask_RFID_Code.Name = "lblTask_RFID_Code";
            this.lblTask_RFID_Code.Size = new System.Drawing.Size(243, 65);
            this.lblTask_RFID_Code.TabIndex = 12;
            this.lblTask_RFID_Code.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTask_State
            // 
            this.lblTask_State.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.lblTask_State.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTask_State.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTask_State.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblTask_State.ForeColor = System.Drawing.Color.Gold;
            this.lblTask_State.Location = new System.Drawing.Point(1461, 0);
            this.lblTask_State.Name = "lblTask_State";
            this.lblTask_State.Size = new System.Drawing.Size(162, 65);
            this.lblTask_State.TabIndex = 11;
            this.lblTask_State.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStart_Time
            // 
            this.lblStart_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.lblStart_Time.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStart_Time.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblStart_Time.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblStart_Time.ForeColor = System.Drawing.Color.Gold;
            this.lblStart_Time.Location = new System.Drawing.Point(1623, 0);
            this.lblStart_Time.Name = "lblStart_Time";
            this.lblStart_Time.Size = new System.Drawing.Size(301, 65);
            this.lblStart_Time.TabIndex = 10;
            this.lblStart_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(68)))), ((int)(((byte)(92)))));
            this.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblID.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblID.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.lblID.ForeColor = System.Drawing.Color.Gold;
            this.lblID.Location = new System.Drawing.Point(0, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(66, 65);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "1";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmTaskModel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1924, 131);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panelTop);
            this.Name = "FrmTaskModel";
            this.Text = "FrmTaskModel";
            this.Load += new System.EventHandler(this.FrmTaskModel_Load);
            this.panelTop.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStart_TimeTOP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblStart_Time;
        private System.Windows.Forms.Label lblTask_State;
        private System.Windows.Forms.Label lblTask_RFID_Code;
        private System.Windows.Forms.Label lblTask_Store_Code;
        private System.Windows.Forms.Label lblBar_Code;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
    }
}