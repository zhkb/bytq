using ControlLogic;
using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmPerfusionWeighMonitor : Form
    {
        public int ShowNum = 1;

        public FrmPerfusionWeighMonitor()
        {
            InitializeComponent();
        }

        #region 界面加载
        private void FrmPerfusionWeighMonitor_Load(object sender, EventArgs e)
        {
            ControlData.SystemInitialization();//PLC 初始化
            SysBusinessFunction.DBConn = DataHelper.DBConnection();//数据库连接状态
            SysBusinessFunction.CreateCheckDBConnection();
            //加载界面
            FrmWeighDetail Lfwd = new FrmWeighDetail();
            if (ShowNum == 1)
            {
                Lfwd.Process_Flag = 1;
            }
            else
            {
                Lfwd.Process_Flag = 3;
            }

            Lfwd.TopLevel = false;
            Lfwd.Parent = panel3;
            Lfwd.Dock = DockStyle.Fill;
            Lfwd.Show();
            FrmWeighDetail Rfwd = new FrmWeighDetail();
            if (ShowNum == 1)
            {
                Rfwd.Process_Flag = 2;
            }
            else
            {
                Rfwd.Process_Flag = 4;
            }

            Rfwd.TopLevel = false;
            Rfwd.Parent = panel4;
            Rfwd.Dock = DockStyle.Fill;
            Rfwd.Show();
        }
        #endregion



        #region 图片点击
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult r = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "是否确认退出系统？" + Environment.NewLine + Environment.NewLine +
                                                                                                      "Are you sure to exit the system ?");
                if (r != DialogResult.OK)
                {
                    return;
                }
                if(ShowNum == 1)
                {
                    SysBusinessFunction.WriteLog("工位AB操作界面正常退出.");
                }
                else
                {
                    SysBusinessFunction.WriteLog("工位CD操作界面正常退出.");
                }
                OptionSetting.ExitFlag++;
                //if (OptionSetting.ExitFlag == 2)
                //{
                //    Application.Exit();
                //}else
                //{
                    Close();
                
                //}
               
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
