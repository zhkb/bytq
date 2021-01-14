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
            this.label4 = new System.Windows.Forms.Label();
            this.pic_ScanStatus = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pic_ServerStatus = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Menu = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Close = new System.Windows.Forms.Button();
            this.pic_DBStatus = new System.Windows.Forms.PictureBox();
            this.pic_PLCStatus = new System.Windows.Forms.PictureBox();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Register = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_SystemTitle = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.pnl_MenuList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_User = new System.Windows.Forms.Label();
            this.pnl_Task.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScanStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ServerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PLCStatus)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Menu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Task
            // 
            this.pnl_Task.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Task.Controls.Add(this.label4);
            this.pnl_Task.Controls.Add(this.pic_ScanStatus);
            this.pnl_Task.Controls.Add(this.label3);
            this.pnl_Task.Controls.Add(this.pic_ServerStatus);
            this.pnl_Task.Controls.Add(this.label2);
            this.pnl_Task.Controls.Add(this.label1);
            this.pnl_Task.Controls.Add(this.btn_Menu);
            this.pnl_Task.Controls.Add(this.btn_Close);
            this.pnl_Task.Controls.Add(this.pic_DBStatus);
            this.pnl_Task.Controls.Add(this.pic_PLCStatus);
            this.pnl_Task.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Task.Location = new System.Drawing.Point(0, 1025);
            this.pnl_Task.Name = "pnl_Task";
            this.pnl_Task.Size = new System.Drawing.Size(1920, 55);
            this.pnl_Task.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(678, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 40);
            this.label4.TabIndex = 35;
            this.label4.Text = "扫描";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // pic_ScanStatus
            // 
            this.pic_ScanStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pic_ScanStatus.Image = global::MainFrame.Properties.Resources.Status_Green;
            this.pic_ScanStatus.Location = new System.Drawing.Point(736, 9);
            this.pic_ScanStatus.Name = "pic_ScanStatus";
            this.pic_ScanStatus.Size = new System.Drawing.Size(40, 40);
            this.pic_ScanStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ScanStatus.TabIndex = 34;
            this.pic_ScanStatus.TabStop = false;
            this.pic_ScanStatus.Visible = false;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(365, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 40);
            this.label3.TabIndex = 33;
            this.label3.Text = "MES";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Visible = false;
            // 
            // pic_ServerStatus
            // 
            this.pic_ServerStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pic_ServerStatus.Image = global::MainFrame.Properties.Resources.Status_Green;
            this.pic_ServerStatus.Location = new System.Drawing.Point(446, 9);
            this.pic_ServerStatus.Name = "pic_ServerStatus";
            this.pic_ServerStatus.Size = new System.Drawing.Size(40, 40);
            this.pic_ServerStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ServerStatus.TabIndex = 32;
            this.pic_ServerStatus.TabStop = false;
            this.pic_ServerStatus.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(515, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 40);
            this.label2.TabIndex = 31;
            this.label2.Text = "PLC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(215, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 40);
            this.label1.TabIndex = 30;
            this.label1.Text = "DB";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // btn_Menu
            // 
            this.btn_Menu.BackColor = System.Drawing.Color.Transparent;
            this.btn_Menu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Menu.BackgroundImage")));
            this.btn_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Menu.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Menu.FlatAppearance.BorderSize = 0;
            this.btn_Menu.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Menu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Menu.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Menu.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Menu.ImageIndex = 10;
            this.btn_Menu.ImageList = this.imageList1;
            this.btn_Menu.Location = new System.Drawing.Point(3, 3);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(100, 50);
            this.btn_Menu.TabIndex = 28;
            this.btn_Menu.Text = "菜单";
            this.btn_Menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Menu.UseVisualStyleBackColor = false;
            this.btn_Menu.Click += new System.EventHandler(this.btn_Menu_Click_1);
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
            this.imageList1.Images.SetKeyName(6, "Setting_64.png");
            this.imageList1.Images.SetKeyName(7, "Type_64.png");
            this.imageList1.Images.SetKeyName(8, "Plan_64.png");
            this.imageList1.Images.SetKeyName(9, "Exit_64.png");
            this.imageList1.Images.SetKeyName(10, "Home_64.png");
            this.imageList1.Images.SetKeyName(11, "Exit.ico");
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.BackgroundImage")));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btn_Close.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.ImageIndex = 11;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(104, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(100, 50);
            this.btn_Close.TabIndex = 29;
            this.btn_Close.Text = "退出";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // pic_DBStatus
            // 
            this.pic_DBStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pic_DBStatus.Image = global::MainFrame.Properties.Resources.Status_Green;
            this.pic_DBStatus.Location = new System.Drawing.Point(296, 9);
            this.pic_DBStatus.Name = "pic_DBStatus";
            this.pic_DBStatus.Size = new System.Drawing.Size(40, 40);
            this.pic_DBStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_DBStatus.TabIndex = 27;
            this.pic_DBStatus.TabStop = false;
            this.pic_DBStatus.Visible = false;
            this.pic_DBStatus.Click += new System.EventHandler(this.pic_DBState_Click);
            // 
            // pic_PLCStatus
            // 
            this.pic_PLCStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pic_PLCStatus.Image = global::MainFrame.Properties.Resources.Status_Red;
            this.pic_PLCStatus.Location = new System.Drawing.Point(596, 9);
            this.pic_PLCStatus.Name = "pic_PLCStatus";
            this.pic_PLCStatus.Size = new System.Drawing.Size(40, 40);
            this.pic_PLCStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_PLCStatus.TabIndex = 25;
            this.pic_PLCStatus.TabStop = false;
            this.pic_PLCStatus.Click += new System.EventHandler(this.pic_PLCStatus_Click);
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
            this.imageList2.Images.SetKeyName(6, "Setting_64.png");
            this.imageList2.Images.SetKeyName(7, "Type_64.png");
            this.imageList2.Images.SetKeyName(8, "Plan_64.png");
            this.imageList2.Images.SetKeyName(9, "Exit_64.png");
            this.imageList2.Images.SetKeyName(10, "Home_64.png");
            this.imageList2.Images.SetKeyName(11, "Chart_64.png");
            this.imageList2.Images.SetKeyName(12, "DownLoad.ico");
            this.imageList2.Images.SetKeyName(13, "Alarm.png");
            this.imageList2.Images.SetKeyName(14, "Exit.ico");
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 25);
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
            this.panel5.Controls.Add(this.lbl_SystemTitle);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.lbl_Time);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1920, 74);
            this.panel5.TabIndex = 38;
            // 
            // lbl_SystemTitle
            // 
            this.lbl_SystemTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_SystemTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SystemTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_SystemTitle.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_SystemTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_SystemTitle.Location = new System.Drawing.Point(199, 0);
            this.lbl_SystemTitle.Name = "lbl_SystemTitle";
            this.lbl_SystemTitle.Size = new System.Drawing.Size(1531, 74);
            this.lbl_SystemTitle.TabIndex = 51;
            this.lbl_SystemTitle.Text = "中德电热精益生产扫码系统";
            this.lbl_SystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.panel7.Controls.Add(this.pictureBox1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(199, 74);
            this.panel7.TabIndex = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Time
            // 
            this.lbl_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(58)))), ((int)(((byte)(110)))));
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Time.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Location = new System.Drawing.Point(1730, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(190, 74);
            this.lbl_Time.TabIndex = 1;
            this.lbl_Time.Text = "2017-08-17 16:48:21";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5333;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Menu.Controls.Add(this.pnl_MenuList);
            this.pnl_Menu.Controls.Add(this.panel3);
            this.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Menu.Location = new System.Drawing.Point(0, 74);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(170, 951);
            this.pnl_Menu.TabIndex = 40;
            this.pnl_Menu.Visible = false;
            // 
            // pnl_MenuList
            // 
            this.pnl_MenuList.AutoScroll = true;
            this.pnl_MenuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MenuList.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pnl_MenuList.Location = new System.Drawing.Point(0, 36);
            this.pnl_MenuList.Name = "pnl_MenuList";
            this.pnl_MenuList.Size = new System.Drawing.Size(170, 915);
            this.pnl_MenuList.TabIndex = 17;
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
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pnl_Menu);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnl_Task);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中德电热系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainFrameForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.pnl_Task.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ScanStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ServerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PLCStatus)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pic_PLCStatus;
        private System.Windows.Forms.PictureBox pic_DBStatus;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lbl_SystemTitle;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Panel pnl_MenuList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Button btn_Menu;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pic_ServerStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pic_ScanStatus;
    }
}

