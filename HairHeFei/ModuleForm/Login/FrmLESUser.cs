using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Login
{
    using Sys.Utilities;
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using Sys.Config;
    using System.IO;

    public partial class FrmLESUser : Form
    {
        public struct ItemInfo
        {
            public string ItemCode; //项目编号   
            public string ItemName;//项目名称
        }


        public string UserName = "";
        public string UserNo = "";
        public string UserID = "";
        public string UserPass = "";
        public string ClassCode = "";
        public string ClassName = "";
        public string ShiftCode = "";
        public string ShiftName = "";

        public bool OperFlag; //操作员权限
        public bool TechFlag;//工艺员权限
        public bool PlanFlag;//计划员权限
        public bool CheckFlag;//质检员权限
        public bool AdminFlag;//管理员权限

        private ArrayList ClassList = new ArrayList();
        private ArrayList ShiftList = new ArrayList();

        public FrmLESUser()
        {
            InitializeComponent();
        }


        private void btn_Ok_Click(object sender, EventArgs e)//保存
        {
            try
            {
                if (txt_UserName.Text == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请输入登录用户");
                    return;
                }

                if (txt_PassWord.Text == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请输入登录密码.");
                    txt_PassWord.Focus();
                    return;
                }
                string PassWord = SysBusinessFunction.MD5(txt_PassWord.Text.Trim());

                DataSet DbDataSet = new DataSet();
                string sql = string.Format(@"select * from sys_BaseUser where User_Code='{0}'and User_Password='{1}'", txt_UserName.Text, PassWord);
                DbDataSet = DataHelper.Fill(sql);

                if (DbDataSet.Tables[0].Rows.Count == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录密码错误，请重新输入.");
                    txt_PassWord.Clear();
                    txt_PassWord.Focus();
                    return;
                }

                BaseSystemInfo.CurrentUserID = DbDataSet.Tables[0].Rows[0]["User_ID"].ToString();
                BaseSystemInfo.CurrentUserCode = DbDataSet.Tables[0].Rows[0]["User_Code"].ToString();
                BaseSystemInfo.CurrentUserName = DbDataSet.Tables[0].Rows[0]["User_Name"].ToString();
                BaseSystemInfo.CurrentAdminFlag = DbDataSet.Tables[0].Rows[0]["User_Code"].ToString().ToUpper() == "ADMIN";
              //  BaseSystemInfo.CurrentUserImage = DbDataSet.Tables[0].Rows[0]["User_Image"].ToString();
              ////  BaseSystemInfo.CurrentUserCardImage = DbDataSet.Tables[0].Rows[0]["User_CardImage"].ToString();
              //  BaseSystemInfo.CurrentUserWorkTime =DateTime.Now.ToString("HH:mm:ss");

                ConfigHelper.SetValue(BaseConfiguration.CURRENTUSERCODE, BaseSystemInfo.CurrentUserCode);
               

                if (!SysBusinessFunction.DBConn)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录失败，无法连接服务器数据库，");
                    return;
                }


                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("登录异常，请检查数据或数据库连接.异常信息：" + ex.Message);
            }
        }

        private void FrmLESUser_Load(object sender, EventArgs e)//窗体加载
        {
            txt_UserName.Text = BaseSystemInfo.CurrentUserCode;

            lbl_Company.Text = BaseSystemInfo.CompanyName;
            lbl_Factory.Text = BaseSystemInfo.FactoryName;
            lbl_Line.Text = BaseSystemInfo.ProductLineName;

            btn_Ok.Parent = pictureBox2;
            btn_Cancel.Parent = pictureBox2;
            btn_Reg.Parent = pictureBox2;
            ControlBox = false;
            //   FormBorderStyle = FormBorderStyle.None;

            panel2.Parent = pictureBox2;
            panel2.BackColor = Color.White;
            lbl_Company.Parent = pictureBox2;
            lbl_Factory.Parent = pictureBox2;
            lbl_Line.Parent = pictureBox2;
            label1.Parent = pictureBox2;
            label2.Parent = pictureBox2;
            label3.Parent = pictureBox2;
            label4.Parent = pictureBox2;
            label5.Parent = pictureBox2;
            label6.Parent = pictureBox2;
            label7.Parent = pictureBox2;
            //label8.Parent = pictureBox2;
           // label9.Parent = pictureBox2;
            btn_Reg.Visible = !BaseSystemInfo.RegisterFlag;

            BaseSystemInfo.AutoUpdateFinish = false;
            BaseSystemInfo.AutoUpdateSuccess = false;

            ConfigHelper.SetValue(BaseConfiguration.APP_AUTOUPDATEFINISH, BaseSystemInfo.AutoUpdateFinish.ToString());
            ConfigHelper.SetValue(BaseConfiguration.APP_AUTOUPDATESUCCESS, BaseSystemInfo.AutoUpdateSuccess.ToString());

            try
            {
                if (!SysBusinessFunction.DBConn)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "数据库连接异常，无法登陆.请检查配置信息后重新登录.");
                    Close();
                    return;
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("初始化数据失败，请检查数据库连接.");
            }




            txt_UserName.Focus();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Reg_Click(object sender, EventArgs e)
        {

        }

        private void FrmLESUser_Activated(object sender, EventArgs e)
        {
            // OptionSetting.MenuTitle = "计划管理";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btn_User_Click_1(object sender, EventArgs e)
        {

        }


    }
}
