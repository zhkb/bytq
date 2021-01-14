using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace Sys.SysBusiness
{
    using Sys.Utilities;
    using Sys.DbUtilities;

    public partial class FrmTip : Form
    {
        public int TipType = 1; // 1 报警信息  2 异常信息  3 操作提示信息
        public string FormTitle = "报警信息";

        private System.Threading.Timer DisplayAlarmTimer; //刷新报警信息
        private ArrayList AlarmList = new ArrayList();
        private bool GetAlarm = false;
        private int MaxInfoCount = 20; //最大显示信息数量

        public FrmTip()
        {
            InitializeComponent();
        }

        private void FrmTip_Load(object sender, EventArgs e)
        {
            lst_tipslist.Items.Clear();

            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;

            if (TipType == 1)
            {
                Text = "报警信息";

                timer1.Enabled = true;
            }

            if (TipType == 2)
            {
                Text = "异常信息";
                timer2.Enabled = true;
            }

            if (TipType == 3)
            {
                Text = "操作信息";
                timer3.Enabled = true;
            }
        }


        private void timer1_Tick(object sender, EventArgs e) //刷新报警日志信息 
        {
            try
            {
                timer1.Enabled = false;
                for (int i = 0; i < AlarmList.Count; i++)
                {
                    string AlarmInfo = (i + 1).ToString() + " " + (string)AlarmList[i];
                    if (i < lst_tipslist.Items.Count)
                    {
                        lst_tipslist.Items[i] = AlarmInfo;
                    }
                    else
                    {
                        lst_tipslist.Items.Add(AlarmInfo);
                    }
                }

                for (int k = AlarmList.Count; k < lst_tipslist.Items.Count; k++)
                {
                    lst_tipslist.Items[k] = "";
                }
            }
            catch
            {

            }
            finally
            {
                timer1.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e) //刷新异常信息处理 
        {
            try
            {
                timer2.Enabled = false;
                for (int i = 0; i < OptionSetting.OperationAlarmList.Count; i++)
                {
                    string OperInfo = (i + 1).ToString() + " " + (string)OptionSetting.OperationAlarmList[i];
                    if (i < lst_tipslist.Items.Count)
                    {
                        lst_tipslist.Items[i] = OperInfo;
                    }
                    else
                    {
                        lst_tipslist.Items.Add(OperInfo);
                    }
                }
                //仅显示最新的10条数据 其他置为空
                for (int k = OptionSetting.OperationAlarmList.Count; k < lst_tipslist.Items.Count; k++)
                {
                    lst_tipslist.Items[k] = "";
                }
            }
            catch
            {

            }
            finally
            {
                timer2.Enabled = true;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)//刷新操作日志信息 
        {
            try
            {
                timer3.Enabled = false;
                for (int i = 0; i < OptionSetting.OperationInfoList.Count; i++)
                {
                    string OperInfo = (i + 1).ToString() + " " + (string)OptionSetting.OperationInfoList[i];
                    if (i < lst_tipslist.Items.Count)
                    {
                        lst_tipslist.Items[i] = OperInfo;
                    }
                    else
                    {
                        lst_tipslist.Items.Add(OperInfo);
                    }
                }

                for (int k = OptionSetting.OperationInfoList.Count; k < lst_tipslist.Items.Count; k++)
                {
                    lst_tipslist.Items[k] = "";
                }
            }
            catch
            {

            }
            finally
            {
                timer3.Enabled = true;
            }
        }

        private void btn_Hide_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
