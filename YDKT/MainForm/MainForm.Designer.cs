namespace MainFrame
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnl_Task = new System.Windows.Forms.Panel();
            this.pic_PlcState = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pic_DBState = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Menu = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Register = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_SystemTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.pnl_MenuList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_User = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.pnl_Task.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlcState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBState)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Menu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Task
            // 
            this.pnl_Task.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.pnl_Task.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_Task.Controls.Add(this.pic_PlcState);
            this.pnl_Task.Controls.Add(this.label3);
            this.pnl_Task.Controls.Add(this.pic_DBState);
            this.pnl_Task.Controls.Add(this.label2);
            this.pnl_Task.Controls.Add(this.lbl_LoginInfo);
            this.pnl_Task.Controls.Add(this.btn_Exit);
            this.pnl_Task.Controls.Add(this.btn_Menu);
            this.pnl_Task.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Task.Location = new System.Drawing.Point(0, 635);
            this.pnl_Task.Name = "pnl_Task";
            this.pnl_Task.Size = new System.Drawing.Size(1695, 71);
            this.pnl_Task.TabIndex = 2;
            // 
            // pic_PlcState
            // 
            this.pic_PlcState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.pic_PlcState.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic_PlcState.Image = global::MainFrame.Properties.Resources.Status_Red;
            this.pic_PlcState.Location = new System.Drawing.Point(441, 0);
            this.pic_PlcState.Name = "pic_PlcState";
            this.pic_PlcState.Size = new System.Drawing.Size(86, 67);
            this.pic_PlcState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_PlcState.TabIndex = 33;
            this.pic_PlcState.TabStop = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(341, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 67);
            this.label3.TabIndex = 32;
            this.label3.Text = "PLC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pic_DBState
            // 
            this.pic_DBState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.pic_DBState.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic_DBState.Image = global::MainFrame.Properties.Resources.Status_Green;
            this.pic_DBState.Location = new System.Drawing.Point(260, 0);
            this.pic_DBState.Name = "pic_DBState";
            this.pic_DBState.Size = new System.Drawing.Size(81, 67);
            this.pic_DBState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_DBState.TabIndex = 31;
            this.pic_DBState.TabStop = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(160, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 67);
            this.label2.TabIndex = 29;
            this.label2.Text = "数据库\r\nDB";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_LoginInfo
            // 
            this.lbl_LoginInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LoginInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_LoginInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_LoginInfo.ForeColor = System.Drawing.Color.Orange;
            this.lbl_LoginInfo.Location = new System.Drawing.Point(1454, 0);
            this.lbl_LoginInfo.Name = "lbl_LoginInfo";
            this.lbl_LoginInfo.Size = new System.Drawing.Size(237, 67);
            this.lbl_LoginInfo.TabIndex = 28;
            this.lbl_LoginInfo.Text = "管理员 - 早班 - 甲组";
            this.lbl_LoginInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Exit.BackgroundImage = global::MainFrame.Properties.Resources.button1;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.CausesValidation = false;
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Exit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Exit.ImageIndex = 15;
            this.btn_Exit.ImageList = this.imageList2;
            this.btn_Exit.Location = new System.Drawing.Point(80, 0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(80, 67);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Monitor_64.png");
            this.imageList2.Images.SetKeyName(1, "Report_64.png");
            this.imageList2.Images.SetKeyName(2, "Recipe_64.png");
            this.imageList2.Images.SetKeyName(3, "Material_64.png");
            this.imageList2.Images.SetKeyName(4, "User_64.png");
            this.imageList2.Images.SetKeyName(5, "Key_64.png");
            this.imageList2.Images.SetKeyName(6, "Module.ico");
            this.imageList2.Images.SetKeyName(7, "Type_64.png");
            this.imageList2.Images.SetKeyName(8, "Setting_64.png");
            this.imageList2.Images.SetKeyName(9, "Plan_64.png");
            this.imageList2.Images.SetKeyName(10, "Exit_64.png");
            this.imageList2.Images.SetKeyName(11, "Home_64.png");
            this.imageList2.Images.SetKeyName(12, "Chart_64.png");
            this.imageList2.Images.SetKeyName(13, "DownLoad.ico");
            this.imageList2.Images.SetKeyName(14, "Alarm.png");
            this.imageList2.Images.SetKeyName(15, "Exit.ico");
            // 
            // btn_Menu
            // 
            this.btn_Menu.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Menu.BackgroundImage = global::MainFrame.Properties.Resources.button1;
            this.btn_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Menu.CausesValidation = false;
            this.btn_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Menu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Menu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Menu.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Menu.ImageIndex = 11;
            this.btn_Menu.ImageList = this.imageList2;
            this.btn_Menu.Location = new System.Drawing.Point(0, 0);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(80, 67);
            this.btn_Menu.TabIndex = 3;
            this.btn_Menu.UseVisualStyleBackColor = false;
            this.btn_Menu.Click += new System.EventHandler(this.btn_Menu_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Monitor_64.png");
            this.imageList1.Images.SetKeyName(1, "Report_64.png");
            this.imageList1.Images.SetKeyName(2, "Recipe_64.png");
            this.imageList1.Images.SetKeyName(3, "Material_64.png");
            this.imageList1.Images.SetKeyName(4, "User_64.png");
            this.imageList1.Images.SetKeyName(5, "Key_64.png");
            this.imageList1.Images.SetKeyName(6, "Module.ico");
            this.imageList1.Images.SetKeyName(7, "Setting_64.png");
            this.imageList1.Images.SetKeyName(8, "Type_64.png");
            this.imageList1.Images.SetKeyName(9, "Plan_64.png");
            this.imageList1.Images.SetKeyName(10, "Exit_64.png");
            this.imageList1.Images.SetKeyName(11, "Home_64.png");
            this.imageList1.Images.SetKeyName(12, "Chart_64.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1695, 25);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // ToolStripMenuItem1
            // 
            this.ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem2,
            this.tsm_Register,
            this.ToolStripMenuItem3});
            this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            this.ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.ToolStripMenuItem1.Text = "系统";
            // 
            // ToolStripMenuItem2
            // 
            this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
            this.ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem2.Text = "修改密码";
            // 
            // tsm_Register
            // 
            this.tsm_Register.Name = "tsm_Register";
            this.tsm_Register.Size = new System.Drawing.Size(124, 22);
            this.tsm_Register.Text = "注册";
            // 
            // ToolStripMenuItem3
            // 
            this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
            this.ToolStripMenuItem3.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem3.Text = "关于";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.lbl_Time);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1695, 99);
            this.panel5.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_SystemTitle);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1291, 95);
            this.panel2.TabIndex = 40;
            // 
            // lbl_SystemTitle
            // 
            this.lbl_SystemTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lbl_SystemTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SystemTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_SystemTitle.Font = new System.Drawing.Font("微软雅黑", 20F);
            this.lbl_SystemTitle.ForeColor = System.Drawing.Color.White;
            this.lbl_SystemTitle.Location = new System.Drawing.Point(0, 53);
            this.lbl_SystemTitle.Name = "lbl_SystemTitle";
            this.lbl_SystemTitle.Size = new System.Drawing.Size(1291, 42);
            this.lbl_SystemTitle.TabIndex = 41;
            this.lbl_SystemTitle.Text = " Barcode acquisition system for India Haier Air conditioner final assmebly Line";
            this.lbl_SystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1291, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "印度海尔空调总装生产线条码采集系统";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Time
            // 
            this.lbl_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Time.Font = new System.Drawing.Font("微软雅黑", 22F);
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Location = new System.Drawing.Point(1491, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(200, 95);
            this.lbl_Time.TabIndex = 39;
            this.lbl_Time.Text = "2017-08-17 16:48:21";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 95);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.pictureBox1.Image = global::MainFrame.Properties.Resources.HAIRLOGO_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(10, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 7500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 2000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Menu.Controls.Add(this.pnl_MenuList);
            this.pnl_Menu.Controls.Add(this.panel3);
            this.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Menu.Location = new System.Drawing.Point(0, 99);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(170, 536);
            this.pnl_Menu.TabIndex = 35;
            this.pnl_Menu.Visible = false;
            this.pnl_Menu.MouseLeave += new System.EventHandler(this.pnl_Menu_MouseLeave_1);
            // 
            // pnl_MenuList
            // 
            this.pnl_MenuList.AutoScroll = true;
            this.pnl_MenuList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.pnl_MenuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MenuList.Location = new System.Drawing.Point(0, 36);
            this.pnl_MenuList.Name = "pnl_MenuList";
            this.pnl_MenuList.Size = new System.Drawing.Size(170, 500);
            this.pnl_MenuList.TabIndex = 17;
            this.pnl_MenuList.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lbl_User);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(170, 36);
            this.panel3.TabIndex = 16;
            // 
            // lbl_User
            // 
            this.lbl_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.lbl_User.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_User.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_User.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_User.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_User.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_User.ImageIndex = 4;
            this.lbl_User.ImageList = this.imageList1;
            this.lbl_User.Location = new System.Drawing.Point(0, 0);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(168, 35);
            this.lbl_User.TabIndex = 16;
            this.lbl_User.Text = "Admin";
            this.lbl_User.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_User.Click += new System.EventHandler(this.lbl_User_Click);
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.ClientSize = new System.Drawing.Size(1695, 706);
            this.Controls.Add(this.pnl_Menu);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnl_Task);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainFrameForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.pnl_Task.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlcState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBState)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_Menu.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnl_Task;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsm_Register;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.Button btn_Menu;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Panel pnl_MenuList;
        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_SystemTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pic_PlcState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic_DBState;
    }
}

