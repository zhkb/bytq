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
            this.pic_PlcState2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Key = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.lbl_Warning = new System.Windows.Forms.Label();
            this.lbl_LoginInfo = new System.Windows.Forms.Label();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.pic_DBState = new System.Windows.Forms.PictureBox();
            this.pic_PlcState = new System.Windows.Forms.PictureBox();
            this.btn_Menu = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_Register = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_SystemTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnl_Menu = new System.Windows.Forms.Panel();
            this.pnl_MenuList = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_User = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.pnl_Task.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlcState2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlcState)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_Menu.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Task
            // 
            this.pnl_Task.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Task.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Task.Controls.Add(this.pic_PlcState2);
            this.pnl_Task.Controls.Add(this.label3);
            this.pnl_Task.Controls.Add(this.label2);
            this.pnl_Task.Controls.Add(this.label1);
            this.pnl_Task.Controls.Add(this.btn_Key);
            this.pnl_Task.Controls.Add(this.lbl_Warning);
            this.pnl_Task.Controls.Add(this.lbl_LoginInfo);
            this.pnl_Task.Controls.Add(this.btn_Exit);
            this.pnl_Task.Controls.Add(this.pic_DBState);
            this.pnl_Task.Controls.Add(this.pic_PlcState);
            this.pnl_Task.Controls.Add(this.btn_Menu);
            this.pnl_Task.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Task.Location = new System.Drawing.Point(0, 646);
            this.pnl_Task.Name = "pnl_Task";
            this.pnl_Task.Size = new System.Drawing.Size(1734, 60);
            this.pnl_Task.TabIndex = 2;
            // 
            // pic_PlcState2
            // 
            this.pic_PlcState2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pic_PlcState2.Image = global::MainFrame.Properties.Resources.Status_Red;
            this.pic_PlcState2.Location = new System.Drawing.Point(712, 7);
            this.pic_PlcState2.Name = "pic_PlcState2";
            this.pic_PlcState2.Size = new System.Drawing.Size(40, 40);
            this.pic_PlcState2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_PlcState2.TabIndex = 35;
            this.pic_PlcState2.TabStop = false;
            this.pic_PlcState2.WaitOnLoad = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(617, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 34);
            this.label3.TabIndex = 34;
            this.label3.Text = "SPLC";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(459, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 34);
            this.label2.TabIndex = 33;
            this.label2.Text = "XPLC";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(350, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 34);
            this.label1.TabIndex = 32;
            this.label1.Text = "DB";
            // 
            // btn_Key
            // 
            this.btn_Key.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Key.BackgroundImage = global::MainFrame.Properties.Resources.button1;
            this.btn_Key.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Key.CausesValidation = false;
            this.btn_Key.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Key.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btn_Key.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Key.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Key.ImageIndex = 3;
            this.btn_Key.ImageList = this.imageList2;
            this.btn_Key.Location = new System.Drawing.Point(208, 2);
            this.btn_Key.Name = "btn_Key";
            this.btn_Key.Size = new System.Drawing.Size(100, 53);
            this.btn_Key.TabIndex = 31;
            this.btn_Key.Text = "键盘";
            this.btn_Key.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Key.UseVisualStyleBackColor = false;
            this.btn_Key.Visible = false;
            this.btn_Key.Click += new System.EventHandler(this.btn_Key_Click);
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
            // lbl_Warning
            // 
            this.lbl_Warning.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Warning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_Warning.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Warning.ForeColor = System.Drawing.Color.Red;
            this.lbl_Warning.Location = new System.Drawing.Point(796, 0);
            this.lbl_Warning.Name = "lbl_Warning";
            this.lbl_Warning.Size = new System.Drawing.Size(829, 58);
            this.lbl_Warning.TabIndex = 30;
            this.lbl_Warning.Text = "-";
            this.lbl_Warning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_LoginInfo
            // 
            this.lbl_LoginInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_LoginInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_LoginInfo.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_LoginInfo.ForeColor = System.Drawing.Color.Orange;
            this.lbl_LoginInfo.Location = new System.Drawing.Point(1625, 0);
            this.lbl_LoginInfo.Name = "lbl_LoginInfo";
            this.lbl_LoginInfo.Size = new System.Drawing.Size(107, 58);
            this.lbl_LoginInfo.TabIndex = 28;
            this.lbl_LoginInfo.Text = "报警复位";
            this.lbl_LoginInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_LoginInfo.Click += new System.EventHandler(this.lbl_LoginInfo_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Exit.BackgroundImage = global::MainFrame.Properties.Resources.button1;
            this.btn_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Exit.CausesValidation = false;
            this.btn_Exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Exit.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btn_Exit.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Exit.ImageIndex = 15;
            this.btn_Exit.ImageList = this.imageList2;
            this.btn_Exit.Location = new System.Drawing.Point(4, 2);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(100, 53);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // pic_DBState
            // 
            this.pic_DBState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pic_DBState.Image = global::MainFrame.Properties.Resources.Status_Green;
            this.pic_DBState.Location = new System.Drawing.Point(413, 7);
            this.pic_DBState.Name = "pic_DBState";
            this.pic_DBState.Size = new System.Drawing.Size(40, 40);
            this.pic_DBState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_DBState.TabIndex = 27;
            this.pic_DBState.TabStop = false;
            this.pic_DBState.Click += new System.EventHandler(this.pic_DBState_Click);
            // 
            // pic_PlcState
            // 
            this.pic_PlcState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pic_PlcState.Image = global::MainFrame.Properties.Resources.Status_Red;
            this.pic_PlcState.Location = new System.Drawing.Point(560, 7);
            this.pic_PlcState.Name = "pic_PlcState";
            this.pic_PlcState.Size = new System.Drawing.Size(40, 40);
            this.pic_PlcState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_PlcState.TabIndex = 25;
            this.pic_PlcState.TabStop = false;
            this.pic_PlcState.WaitOnLoad = true;
            this.pic_PlcState.Click += new System.EventHandler(this.pic_PlcState_Click);
            // 
            // btn_Menu
            // 
            this.btn_Menu.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Menu.BackgroundImage = global::MainFrame.Properties.Resources.button1;
            this.btn_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Menu.CausesValidation = false;
            this.btn_Menu.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Menu.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btn_Menu.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Menu.ImageIndex = 11;
            this.btn_Menu.ImageList = this.imageList2;
            this.btn_Menu.Location = new System.Drawing.Point(106, 2);
            this.btn_Menu.Name = "btn_Menu";
            this.btn_Menu.Size = new System.Drawing.Size(100, 53);
            this.btn_Menu.TabIndex = 3;
            this.btn_Menu.Text = "菜单";
            this.btn_Menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Menu.UseVisualStyleBackColor = false;
            this.btn_Menu.Visible = false;
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
            this.menuStrip1.Size = new System.Drawing.Size(1362, 25);
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
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(76)))), ((int)(((byte)(111)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lbl_SystemTitle);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.lbl_Time);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1734, 67);
            this.panel5.TabIndex = 38;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // lbl_SystemTitle
            // 
            this.lbl_SystemTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_SystemTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_SystemTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_SystemTitle.Font = new System.Drawing.Font("微软雅黑", 30F);
            this.lbl_SystemTitle.ForeColor = System.Drawing.Color.Transparent;
            this.lbl_SystemTitle.Location = new System.Drawing.Point(200, 0);
            this.lbl_SystemTitle.Name = "lbl_SystemTitle";
            this.lbl_SystemTitle.Size = new System.Drawing.Size(1350, 65);
            this.lbl_SystemTitle.TabIndex = 41;
            this.lbl_SystemTitle.Text = "合肥海尔A线门壳智选库系统";
            this.lbl_SystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 65);
            this.panel1.TabIndex = 40;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.pictureBox1.Image = global::MainFrame.Properties.Resources.HAIRLOGO_WHITE;
            this.pictureBox1.Location = new System.Drawing.Point(24, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Time
            // 
            this.lbl_Time.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.lbl_Time.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Time.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Time.ForeColor = System.Drawing.Color.White;
            this.lbl_Time.Location = new System.Drawing.Point(1550, 0);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(182, 65);
            this.lbl_Time.TabIndex = 1;
            this.lbl_Time.Text = "2017-08-17 16:48:21";
            this.lbl_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Time.Click += new System.EventHandler(this.lbl_Time_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 6000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pnl_Menu
            // 
            this.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_Menu.Controls.Add(this.pnl_MenuList);
            this.pnl_Menu.Controls.Add(this.panel3);
            this.pnl_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_Menu.Location = new System.Drawing.Point(0, 67);
            this.pnl_Menu.Name = "pnl_Menu";
            this.pnl_Menu.Size = new System.Drawing.Size(170, 579);
            this.pnl_Menu.TabIndex = 35;
            this.pnl_Menu.Visible = false;
            this.pnl_Menu.MouseLeave += new System.EventHandler(this.pnl_Menu_MouseLeave_1);
            // 
            // pnl_MenuList
            // 
            this.pnl_MenuList.AutoScroll = true;
            this.pnl_MenuList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_MenuList.Location = new System.Drawing.Point(0, 36);
            this.pnl_MenuList.Name = "pnl_MenuList";
            this.pnl_MenuList.Size = new System.Drawing.Size(170, 543);
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
            this.timer4.Interval = 5000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Enabled = true;
            this.timer5.Interval = 3000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1734, 706);
            this.Controls.Add(this.pnl_Menu);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnl_Task);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainFrameForm_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.pnl_Task.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlcState2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DBState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_PlcState)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel5.ResumeLayout(false);
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
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pic_PlcState;
        private System.Windows.Forms.PictureBox pic_DBState;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel pnl_Menu;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Panel pnl_MenuList;
        private System.Windows.Forms.Label lbl_LoginInfo;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label lbl_Warning;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Button btn_Key;
        private System.Windows.Forms.Label lbl_SystemTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_PlcState2;
        private System.Windows.Forms.Label label3;
    }
}

