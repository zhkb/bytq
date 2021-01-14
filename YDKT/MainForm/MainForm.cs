using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Collections;

namespace MainFrame
{
    using Sys.Utilities;
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using Login;
    using ControlLogic;
    using Sys.Config;
    using Monitor;
    using Register;
    using ControlLogic.Control;

    public partial class MainForm : Form
    {

        private DataSet MasterDataSet = null;
        private Image[] ConnImage = { MainFrame.Properties.Resources.Status_Red, MainFrame.Properties.Resources.Status_Green }; //连接状态显示颜色 

        //循环显示报警信息
        List<string> lstWarning = new List<string>();
        int nWarningDispIndex = 0;

        Thread thread4UpdateWarning = null;
        bool bLoop4UpdateWarning = true;

        public delegate void delegateUpdate4Warning();
        public delegateUpdate4Warning myDelegate4Warning;

        private bool SystemLogonFlag = false;

        private ArrayList MenuListInfo = new ArrayList();
        public MainForm()
        {
            InitializeComponent();

            //循环显示报警信息
            lstWarning.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + " 缓冲罐设备故障");
            lstWarning.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + " 主轴电机设备故障");
            lstWarning.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + " 给料泵设备故障");
            //myDelegate4Warning = new delegateUpdate4Warning(UpdateWarning);
            //InitThread4UpdateWarning();
        }

        private void InitThread4UpdateWarning()
        {
            bLoop4UpdateWarning = true;

            thread4UpdateWarning = new Thread(new ThreadStart(this.Thread4UpdateWarning));
            thread4UpdateWarning.Start();
        }

        private void Thread4UpdateWarning()
        {
            int nIndex = 0;
            try
            {
                while (bLoop4UpdateWarning)
                {
                    if (nIndex < 30)
                    {
                        nIndex++;
                        Thread.Sleep(100);
                    }
                    else
                    {
                        nIndex = 0;
                        Invoke(myDelegate4Warning, new Object[] { });
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void CloseThread4UpdateWarning()
        {
            bLoop4UpdateWarning = false;
            thread4UpdateWarning.Join();
        }

        private void UpdateWarning()
        {
            try
            {
                string sSQL = string.Format(@"SELECT top 3 [Alarm_ID]
                                                  ,[Equipment_Code]
                                                  ,[Equipment_Name]
                                                  ,[Alarm_Desc]
                                                  ,[Create_Time]
                                              FROM [Mixing_Alarm] order by [Create_Time] desc");
                DataSet ds = null;
                ds = DataHelper.Fill(sSQL);
                if (ds == null || ds.Tables[0].Rows.Count == 0)
                {
                    return;
                }

                lstWarning = new List<string>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string sWarning = ((DateTime)dr["Create_Time"]).ToString("yyyy-MM-dd HH:mm:ss")
                                        + "  "
                                        + dr["Alarm_Desc"].ToString();
                    lstWarning.Add(sWarning);
                }

                if (nWarningDispIndex >= lstWarning.Count)
                {
                    nWarningDispIndex = 0;
                }
                // lbl_Warning.Text = lstWarning[nWarningDispIndex];
                nWarningDispIndex++;
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadChildrenForm(string assemblyName, string formName, string FormTitle, string TagValue)
        {
            if (formName.Length == 0)
            {
                return;
            }

            foreach (Form childrenForm in Application.OpenForms)
            {
                if (childrenForm.Name == formName)
                {
                    childrenForm.Tag = TagValue;
                    childrenForm.Text = FormTitle;
                    childrenForm.Visible = true;
                    childrenForm.WindowState = FormWindowState.Maximized;
                    childrenForm.Activate();
                    return;
                }
            }
            //// 一些特殊的页面处理。
            switch (formName)
            {
                case "FormLogOn":
                    // 关闭所有打开的窗口
                    foreach (Form childrenForm in Application.OpenForms)
                    {
                        childrenForm.Close();
                    }
                    this.ShowChildrenForm(assemblyName, formName, FormTitle, TagValue);
                    break;
                case "FrmMessage":

                    foreach (Form childrenForm in Application.OpenForms)
                    {
                        if (childrenForm.Name == formName)
                        {
                            childrenForm.Visible = true;
                            childrenForm.Activate();
                            return;
                        }
                    }

                    ShowSDIForm(assemblyName, formName, FormTitle);
                    break;
                default:
                    this.ShowChildrenForm(assemblyName, formName, FormTitle, TagValue);
                    return;
            }
        }

        private Form ShowSDIForm(string assemblyName, string formName, string FormTitle)
        {
            Form childrenForm = (Form)CacheManager.Instance.CreateInstance(assemblyName, formName);

            if (childrenForm != null)
            {
                childrenForm.Tag = 1;
                childrenForm.Name = formName;
                childrenForm.Text = FormTitle;
                //childrenForm.MdiParent = this;
                childrenForm.ShowInTaskbar = true;
                childrenForm.WindowState = FormWindowState.Maximized;
                //if (childrenForm is IBaseForm)
                //{
                //    ((IBaseForm)childrenForm).OnButtonStateChange += new BaseForm.SetControlStateEventHandler(SetControlState);
                //}
                childrenForm.ShowIcon = false;
                childrenForm.Show();
                childrenForm.Activate();
            }
            return childrenForm;
        }

        private Form ShowChildrenForm(string assemblyName, string formName, string FormTitle, string TagValue)
        {
            //TabPage MDIPage = new TabPage();
            //tabControl1.TabPages.Add(MDIPage);
            try
            {
                Form childrenForm = (Form)CacheManager.Instance.CreateInstance(assemblyName, formName);
                childrenForm.Tag = TagValue;
                childrenForm.Name = formName;
                childrenForm.Text = FormTitle;
                childrenForm.TopLevel = false;
                childrenForm.MdiParent = this;
                childrenForm.ShowIcon = true;
                //   childrenForm.FormBorderStyle = FormBorderStyle.no;
                childrenForm.ControlBox = true;
                //     childrenForm.Dock = DockStyle.Fill;

                childrenForm.Show();
                childrenForm.WindowState = FormWindowState.Maximized;
                return childrenForm;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private void MainFrameForm_Load(object sender, EventArgs e)
        {
            Hide(); //▲ ▼

            Application.DoEvents();
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;

            ControlBox = false;
            WindowState = FormWindowState.Maximized; 


            SysBusinessFunction.DBConn = DataHelper.DBConnection();//数据库连接状态

            SysBusinessFunction.CreateCheckDBConnection();


            FrmLESUser PassForm = new FrmLESUser();//弹出登录对话框
            PassForm.TopLevel = true;
            DialogResult r = PassForm.ShowDialog();

            if (r != DialogResult.OK)
            {
                Close();
                return;
            }

            ControlBox = false;
            WindowState = FormWindowState.Maximized; ;

            lbl_User.Text = BaseSystemInfo.CurrentUserName;

            pnl_Menu.Visible = false;
            SystemLogonFlag = true;

            SysBusinessFunction.GetMenuInfoData(BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserCode);
            SetMenuButton();

            Show();
            timer1.Enabled = true;

            //ControlData.SystemInitialization();

            timer2.Enabled = true;
            timer3.Enabled = true;

            if (BaseSystemInfo.CurrentProcessCode == "1001" || BaseSystemInfo.CurrentProcessCode == "1010" || BaseSystemInfo.CurrentProcessCode == "1090")
            {
                label3.Visible = false;
                pic_PlcState.Visible = false;
                LoadChildrenForm("Monitor", "FrmProductMonitor", "", "1");
                ControlProductMonitorData.SystemInitialization();
            }

            if (BaseSystemInfo.CurrentProcessCode == "1040")
            {

                LoadChildrenForm("Monitor", "FrmWeighMonitor", "自动称重 Procuct On Line", "1");
                ControlData.SystemInitialization();
                ControlWeightInfoData.SystemInitialization();

            }

            if (BaseSystemInfo.CurrentProcessCode == "1020")
            {

                LoadChildrenForm("Monitor", "FrmQuality", "捡漏", "1");
                ControlData.SystemInitialization();
                ControlQualityData.SystemInitialization();

            }
            if (BaseSystemInfo.CurrentProcessCode == "1100")
            {
                LoadChildrenForm("Monitor", "FrmFillMonitor", "灌注监控 Perfusion Monitor", "1");
                ControlData.SystemInitialization();
                //ControlWeightInfoData.SystemInitialization();
            }
          
            if (BaseSystemInfo.CurrentProcessCode == "1110")//质检缺陷
            {
                LoadChildrenForm("Monitor", "FrmQualityCheck", "质检", "1");
                
            }

            if (BaseSystemInfo.CurrentProcessCode == "1200")//灌注称重
            {
                LoadChildrenForm("Monitor", "FrmPerfusionWeighMonitor", "质检", "1");
               
                
            }


        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {
            pnl_Menu.Visible = !pnl_Menu.Visible;
            pnl_Menu.Location = new Point(0, pnl_Task.Top - pnl_Menu.Height);

            //pnl_Menu1.Visible = !pnl_Menu1.Visible;
            //pnl_Menu1.Location = new Point(0, pnl_Task.Top - pnl_Menu1.Height);
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //pnl_Menu.Visible = false;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            bool plcstate = ControlData.MasterPLCPLCConn;
            pic_PlcState.Image = ConnImage[Convert.ToInt32(ControlData.MasterPLCPLCConn)];
            pic_DBState.Image = ConnImage[Convert.ToInt32(SysBusinessFunction.DBConn)];

            if (ActiveMdiChild != null)
            {
                OptionSetting.MenuTitle = ActiveMdiChild.Text;
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseSystemInfo.ForcedExit)
            {

            }
            else
            {
                if (BaseSystemInfo.RunLogout)
                {
                    //IMOS.LogOn.FrmLESLogOn PassForm = new IMOS.LogOn.FrmLESLogOn();
                    //// PassForm.grpLogOn.Text = "退出";
                    //PassForm.LoginName = BaseSystemInfo.CurrentUserName;

                    //DialogResult r = PassForm.ShowDialog();

                    //if (r != DialogResult.OK)
                    //{
                    //    e.Cancel = true;
                    //    return;
                    //}
                }
                else
                {
                    if (SystemLogonFlag)
                    {
                        DialogResult r = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "是否确认退出系统？" + Environment.NewLine + Environment.NewLine +
                                                                                                              "Are you sure to exit the system ?");

                        if (r != DialogResult.OK)
                        {
                            e.Cancel = true;
                            return;
                        }

                        SysBusinessFunction.WriteLog("系统正常退出.");
                    }
                }
            }

            //if (SystemLogonFlag)
            //{
            //    pnl_Menu.Visible = false;
            //    DialogResult r = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "是否确认退出系统？如退出，将不能正常接收生产数据.");

            //    if (r != DialogResult.OK)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}

        }

        private void btn_Password_Click(object sender, EventArgs e)
        {
            FrmPassWord PassWordForm = new FrmPassWord();
            PassWordForm.ShowDialog();
            PassWordForm.Dispose();
        }


        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pic_DBState_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                SysBusinessFunction.DBConn = SysBusinessFunction.HisCount != SysBusinessFunction.NewCount;

                SysBusinessFunction.HisCount = SysBusinessFunction.NewCount;

                if ((!SysBusinessFunction.DBConn) && (!SysBusinessFunction.DBFlag))
                {
                    SysBusinessFunction.WriteLog("数据库连接失败，重新连接中.....");
                    SysBusinessFunction.DBFlag = true;
                }

                if (SysBusinessFunction.DBConn)
                {
                    SysBusinessFunction.DBFlag = false;
                }
                Application.DoEvents();
            }
            finally
            {

            }
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    if ((!BaseSystemInfo.RegisterFlag) && (SystemLogonFlag)) // 未注册进行提示 
            //    {
            //        timer3.Enabled = false;
            //        FrmRegTips RegForm = new FrmRegTips();
            //        DialogResult r = RegForm.ShowDialog();
            //        RegForm.Dispose();
            //    }
            //}
            //catch
            //{

            //}
            //finally
            //{

            //}
        }



        private void SetMenuButton()//设置菜单按钮
        {
            int FHeight = 40;
            int FWidth = 150;
            pnl_Menu.Width = 170;

            Panel Temp_MenuBtn = new Panel();

            int ModuleCount = 0;
            string ParentMenuName = "";
            int FIndex = -1;
            for (int i = 0; i < SysBusinessFunction.ModuleListInfo.Count; i++)
            {
                ModuleInfo FModuleInfo = (ModuleInfo)SysBusinessFunction.ModuleListInfo[i];

                if (FModuleInfo.MenuCode != ParentMenuName) //主菜单
                {
                    FIndex++;
                    ParentMenuName = FModuleInfo.MenuCode;
                    Panel pnl_MenuBtn = new Panel();
                    ModuleCount = 0;
                    pnl_MenuBtn.Name = FModuleInfo.MenuCode;
                    pnl_MenuBtn.Parent = pnl_MenuList;
                    pnl_MenuBtn.Dock = DockStyle.Top;

                    pnl_MenuBtn.Width = FWidth;
                    pnl_MenuBtn.Height = FHeight;

                    pnl_MenuBtn.Top = FHeight * i + 2; ;

                    Button Main_MenuBtn = new Button();
                    Main_MenuBtn.Parent = pnl_MenuBtn;
                    Main_MenuBtn.Width = FWidth;
                    Main_MenuBtn.Height = FHeight;

                    Main_MenuBtn.Left = 2;
                    Main_MenuBtn.Top = 2;

                    Main_MenuBtn.Text = FModuleInfo.MenuName + "  ▲";
                    Main_MenuBtn.TextAlign = ContentAlignment.MiddleRight;
                    Main_MenuBtn.ForeColor = Color.White;
                    Main_MenuBtn.Font = new Font(btn_Exit.Font.FontFamily, btn_Exit.Font.Size, btn_Exit.Font.Style);
                    Main_MenuBtn.BackgroundImage = Properties.Resources.button1;
                    Main_MenuBtn.BackgroundImageLayout = ImageLayout.Stretch;
                    Main_MenuBtn.ImageList = imageList2;
                    Main_MenuBtn.ImageIndex = 2;
                    Main_MenuBtn.ImageAlign = ContentAlignment.MiddleLeft;

                    Main_MenuBtn.Click += new System.EventHandler(ShowMenuPanel); //赋值窗体打开事件
                    Main_MenuBtn.Tag = FIndex;

                    Temp_MenuBtn = pnl_MenuBtn;

                    MenuInfo FMenuInfo = new MenuInfo();
                    FMenuInfo.MenuCode = FModuleInfo.MenuCode;
                    FMenuInfo.MenuName = FModuleInfo.MenuName;
                    FMenuInfo.ModuleCount = FMenuInfo.ModuleCount + 1;
                    FMenuInfo.ShowFlag = true;

                    FMenuInfo.Pnl_Menu = Temp_MenuBtn;
                    MenuListInfo.Add(FMenuInfo);

                }
                else
                {
                    MenuInfo FMenuInfo = (MenuInfo)MenuListInfo[FIndex];

                    FMenuInfo.ModuleCount = FMenuInfo.ModuleCount + 1;
                    MenuListInfo.RemoveAt(FIndex);
                    MenuListInfo.Insert(FIndex, FMenuInfo);
                }


                ModuleCount++;
                Button Detail_MenuBtn = new Button();
                Detail_MenuBtn.Parent = Temp_MenuBtn;
                Detail_MenuBtn.Width = 130;
                Detail_MenuBtn.Height = FHeight;

                Detail_MenuBtn.Left = 22;
                Detail_MenuBtn.Top = FHeight * ModuleCount + 2; ;

                Detail_MenuBtn.Text = "  " + FModuleInfo.ModuleName;
                Detail_MenuBtn.ForeColor = Color.White;
                Detail_MenuBtn.Font = new Font(btn_Exit.Font.FontFamily, btn_Exit.Font.Size, btn_Exit.Font.Style);
                Detail_MenuBtn.BackgroundImage = Properties.Resources.button1;
                Detail_MenuBtn.BackgroundImageLayout = ImageLayout.Stretch;
                Detail_MenuBtn.ImageList = imageList2;
                Detail_MenuBtn.ImageIndex = 6;
                Detail_MenuBtn.ImageAlign = ContentAlignment.MiddleLeft;

                Detail_MenuBtn.Click += new System.EventHandler(ShowMenuForm); //赋值窗体打开事件

                Detail_MenuBtn.Tag = i;
                Temp_MenuBtn.Height = (ModuleCount + 1) * FHeight;

                //FMenuInfo.MenuCode = FModuleInfo.MenuCode;
                //FMenuInfo.MenuName = FModuleInfo.MenuName;
                //FMenuInfo.ModuleCount = ModuleCount + 1;
                //FMenuInfo.ShowFlag = true;
                //FMenuInfo.Pnl_Menu = Temp_MenuBtn;
                //ModuleListInfo.Add(FModuleInfo);

            }

        }
        private void ShowMenuForm(object sender, EventArgs e)//菜单按钮事件
        {
            Button btnMenu = (Button)sender;
            int FTag = int.Parse(btnMenu.Tag.ToString());
            ModuleInfo FModuleInfo = (ModuleInfo)SysBusinessFunction.ModuleListInfo[FTag];
            string ModuleName = FModuleInfo.ModuleName;
            string SourceName = FModuleInfo.ModuleSource;
            string FormName = FModuleInfo.ModuleForm;
            string MoudleCode = FModuleInfo.ModuleCode;
            LoadChildrenForm(SourceName, FormName, ModuleName, MoudleCode);

            //  pnl_Menu.Visible = false;
        }

        private void ShowMenuPanel(object sender, EventArgs e)//菜单按钮事件
        {
            Button pnl_Btn = (Button)sender;
            int FIndex = (int)pnl_Btn.Tag;


            MenuInfo FMenuInfo = (MenuInfo)MenuListInfo[FIndex];

            if (FMenuInfo.ShowFlag)
            {
                FMenuInfo.Pnl_Menu.Height = 40;
                pnl_Btn.Text = FMenuInfo.MenuName + "   ▼";
                //  ▲ 
            }
            else
            {
                pnl_Btn.Text = FMenuInfo.MenuName + "   ▲";
                FMenuInfo.Pnl_Menu.Height = FMenuInfo.ModuleCount * 40 + 42;
            }

            FMenuInfo.ShowFlag = !FMenuInfo.ShowFlag;
            MenuListInfo.RemoveAt(FIndex);
            MenuListInfo.Insert(FIndex, FMenuInfo);
            // pnl_MenuBtn. = !pnl_MenuBtn.Visible;

        }

        private void pnl_Menu_MouseLeave_1(object sender, EventArgs e)
        {
            int x = MousePosition.X;
            int y = MousePosition.Y;
            int p_x = MousePosition.X - this.Location.X;
            int p_y = MousePosition.Y - this.Location.Y;
            pnl_Menu.Visible = ((p_x <= pnl_Menu.Width) && (p_y > (pnl_Menu.Top) + 35));
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_User_Click(object sender, EventArgs e)
        {
            FrmPassWord PassWordForm = new FrmPassWord();
            PassWordForm.ShowDialog();
            PassWordForm.Dispose();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
        //    lbl_SystemTitle.Text = OptionSetting.MenuTitle;
            lbl_LoginInfo.Text = BaseSystemInfo.CurrentUserName + " - " + BaseSystemInfo.CurrentClassName + " - " + BaseSystemInfo.CurrentShiftName;
        
        }


    }
}
