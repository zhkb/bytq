using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.Language;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Monitor
{

    public partial class FrmEnErMonitor : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        public FrmEnErMonitor()
        {
            InitializeComponent();
            ControlEnEr.SystemInitialization();//串口扫码器初始化
        }

        #region 界面加载

        private void FrmEnErMonitor_Load(object sender, EventArgs e)//加载窗口
        {
            try
            {
                SysBusinessFunction.DBConn = DataHelper.DBConnection();//数据库连接状态
                SysBusinessFunction.ServerDBConn = DataHelper.DBServerConnection();//数据库连接状态
                SysBusinessFunction.CreateCheckDBConnection();
                ControlMaster.SystemInitialization();//初始化PLC
                timer1.Enabled = true;
                timer1.Interval = 300;
                timer1.Start();
                timer2.Start();
                if (BaseSystemInfo.LanguageType == "2")
                {
                    ChangLanguage.SetLang("en-US", this, typeof(FrmEnErMonitor));
                }
                for (int i = 16; i >= 1; i--)
                {
                    AddForm(i);
                }

            }
            catch (Exception ex)
            {

            }

        }
        #endregion

        #region 图片刷新
        private void ReFreshIMage(string ProImage, string EnergyImage) //刷新图片
        {
            try
            {
                if (ProImage != "")
                {
                    byte[] imageBytes = Convert.FromBase64String(ProImage);
                    this.pic_Product.Image = SysBusinessFunction.ArrayToPic(imageBytes);
                }
                if (EnergyImage != "")
                {
                    byte[] imageBytes = Convert.FromBase64String(EnergyImage);
                    this.pic_Energy_Label.Image = SysBusinessFunction.ArrayToPic(imageBytes);
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 网格添加
        private void AddForm(int i)//添加网格
        {
            FrmGridding fg = new FrmGridding();
            fg.lbl_NO.Text = i + "";
            fg.TopLevel = false;
            fg.Dock = DockStyle.Left;
            fg.Show();
            #region 竖着排放

            //switch (i % 4)
            //{
            //    case 1:
            //        fg.Parent = this.panel5;
            //        break;
            //    case 2:
            //        fg.Parent = this.panel6;
            //        break;
            //    case 3:
            //        fg.Parent = this.panel7;
            //        break;
            //    case 0:
            //        fg.Parent = this.panel8;
            //        break;
            //}
            #endregion
            //横着排放
            switch ((i - 1) / 4)
            {
                case 0:
                    fg.Parent = this.panel5;
                    break;
                case 1:
                    fg.Parent = this.panel6;
                    break;
                case 2:
                    fg.Parent = this.panel7;
                    break;
                case 3:
                    fg.Parent = this.panel8;
                    break;
            }

            fg.Name = "fg" + i;

        }

        #endregion

        #region 系统事件
        private void timer1_Tick(object sender, EventArgs e)//显示时间
        {
            try
            {
                lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (OptionSetting.ShowFlag)
                {
                    lbl_BarCode.Text = OptionSetting.EProBarCode;
                    lbl_Name.Text = OptionSetting.EProName;
                    lbl_Msg.Text = OptionSetting.EMsg;
                    if (OptionSetting.EResultFlag)
                    {
                        lbl_Msg.ForeColor = Color.Lime;
                    }
                    else
                    {
                        lbl_Msg.ForeColor = Color.Red;
                    }
                    ReFreshIMage(OptionSetting.ProImage, OptionSetting.EnergyImage);
                    OptionSetting.ShowFlag = false;
                }
                else
                {
                    //ReFreshIMage("","");
                }
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)//退出
        {

            DialogResult r = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "是否确认退出系统？如退出，将不能正常接收生产数据.");

            if (r == DialogResult.OK)
            {
                Close();
            }

            SysBusinessFunction.WriteLog("系统正常退出.");

        }

        #endregion

        #region 触发加料事件
        private void timer2_Tick(object sender, EventArgs e)
        {
            if ("-1".Equals(OptionSetting.Eqty.Trim()))
            {
                return;
            }
            else
            {
                FrmEnErEdit EnErEdit = new FrmEnErEdit();
                EnErEdit.Show();
                OptionSetting.Eqty = "-1";

            }
        }
        #endregion

        #region  放料按钮
        private void btn_Put_Click(object sender, EventArgs e)
        {
            try
            {
                if (OptionSetting.PutFlag)
                {
                    OptionSetting.PutFlag = !OptionSetting.PutFlag;
                    btn_Put.ForeColor = Color.White;
                    btn_Put.Text = String.Format(@"取    料
Toke Energy Label");
                }
                else
                {
                    OptionSetting.PutFlag = !OptionSetting.PutFlag;
                    btn_Put.ForeColor = Color.Red;
                    btn_Put.Text = String.Format(@"放   料
Put Energy Label");
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
