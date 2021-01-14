using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Setting
{
    using Sys.Config;
    using Sys.SysBusiness;
    using System.Text.RegularExpressions;

    public partial class FrmBarDetial : Form
    {
        public int BarNo = 1;

        public FrmBarDetial()
        {
            InitializeComponent();
        }

        private void FrmBarDetial_Load(object sender, EventArgs e)
        {
            lbl_BinNo.Text = BarNo.ToString();
            lbl_BarScanIP.Text = BaseSystemInfo.BarScanInfoList[BarNo - 1].BarIP;
            lbl_BarScanPort.Text = BaseSystemInfo.BarScanInfoList[BarNo - 1].BarPort;

            lbl_BarScanIP.BorderStyle = BorderStyle.None;
            lbl_BarScanPort.BorderStyle = BorderStyle.None;
        }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save.Enabled = false;

                bool IPFlag = SysBusinessFunction.IsIpaddress(lbl_BarScanIP.Text.Trim());
                if (!IPFlag)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "IP地址不合法，请重新输入！");
                    return;
                }

                    DialogResult r = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "是否确定修改【" + BarNo.ToString() + "】号扫码器配置参数！");

                if (r != DialogResult.OK)
                {
                    return;
                }

                ConfigHelper.SetValue("BarScanIP" + (BarNo).ToString(), lbl_BarScanIP.Text);
                ConfigHelper.SetValue("BarScanPort" + (BarNo).ToString(), lbl_BarScanPort.Text);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "扫码参数修改完成.");
            }
            catch
            {

            }
            finally
            {
                btn_Save.Enabled = true;
            }

        }
    }
}
