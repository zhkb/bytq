using Sys.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Option
{
    public partial class FrmConfigModify : Form
    {
        public FrmConfigModify()
        {
            InitializeComponent();
            //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }

        private void FrmConfigModify_Load(object sender, EventArgs e)
        {
            //数据库
            tb_dbt.Text = BaseSystemInfo.DataBaseType;
            tb_sdbt.Text = BaseSystemInfo.ServerDataBaseType;
            tb_sdbc.Text = BaseSystemInfo.ServerDbConnection;
            tb_bdbc.Text = BaseSystemInfo.BusinessDbConnection;
            //打印机
            tb_epname1.Text = BaseSystemInfo.EnergyPrinterName1;
            tb_epname2.Text = BaseSystemInfo.EnergyPrinterName2;
            tb_epname3.Text = BaseSystemInfo.EnergyPrinterName3;
            //系统相关
            tb_cid.Text = BaseSystemInfo.CompanyID;
            tb_ccode.Text = BaseSystemInfo.CompanyCode;
            tb_cname.Text = BaseSystemInfo.CompanyName;
            tb_fid.Text = BaseSystemInfo.FactoryID;
            tb_fcode.Text = BaseSystemInfo.FactoryCode;
            tb_fname.Text = BaseSystemInfo.FactoryName;
            tb_plid.Text = BaseSystemInfo.ProductLineID;
            tb_plcode.Text = BaseSystemInfo.ProductLineCode;
            tb_plname.Text = BaseSystemInfo.ProductLineName;
            tb_cpcode.Text = BaseSystemInfo.CurrentProcessCode;
            tb_cpname.Text = BaseSystemInfo.CurrentProcessName;
            //PLC
            tb_plctype.Text = BaseSystemInfo.PLCType;
            tb_plcip.Text = BaseSystemInfo.MasterPLCIP;
            //串口
            tb_port1.Text = BaseSystemInfo.SerialPortName1;
            tb_port2.Text = BaseSystemInfo.SerialPortName2;
            tb_port3.Text = BaseSystemInfo.SerialPortName3;
            //扫码器
            tb_bardip.Text = BaseSystemInfo.BarDeviceIP;
            tb_bardport.Text = BaseSystemInfo.BarDevicePort;
            tb_bareip.Text = BaseSystemInfo.BarEnergyIP;
            tb_bareport.Text = BaseSystemInfo.BarEnergyPort;
            tb_bbardip.Text = BaseSystemInfo.BeforeBarDeviceIP;
            tb_bbardport.Text = BaseSystemInfo.BeforeBarDevicePort;
            tb_abardip.Text = BaseSystemInfo.AfterBarDeviceIP;
            tb_abardport.Text = BaseSystemInfo.AfterBarDevicePort;


        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            //数据库
            BaseSystemInfo.DataBaseType = tb_dbt.Text.ToString().Trim();
            BaseSystemInfo.ServerDataBaseType = tb_sdbt.Text.ToString().Trim();
            BaseSystemInfo.ServerDbConnection = tb_sdbc.Text.ToString().Trim();
            BaseSystemInfo.BusinessDbConnection = tb_bdbc.Text.ToString().Trim();
            //打印机
            BaseSystemInfo.EnergyPrinterName1 = tb_epname1.Text.ToString().Trim();
            BaseSystemInfo.EnergyPrinterName2 = tb_epname2.Text.ToString().Trim();
            BaseSystemInfo.EnergyPrinterName3 = tb_epname3.Text.ToString().Trim();
            //系统相关
            BaseSystemInfo.CompanyID = tb_cid.Text.ToString().Trim();
            BaseSystemInfo.CompanyCode = tb_ccode.Text.ToString().Trim();
            BaseSystemInfo.CompanyName = tb_cname.Text.ToString().Trim();
            BaseSystemInfo.FactoryID = tb_fid.Text.ToString().Trim();
            BaseSystemInfo.FactoryCode = tb_fcode.Text.ToString().Trim();
            BaseSystemInfo.FactoryName = tb_fname.Text.ToString().Trim();
            BaseSystemInfo.ProductLineID = tb_plid.Text.ToString().Trim();
            BaseSystemInfo.ProductLineCode = tb_plcode.Text.ToString().Trim();
            BaseSystemInfo.ProductLineName = tb_plname.Text.ToString().Trim();
            BaseSystemInfo.CurrentProcessCode = tb_cpcode.Text.ToString().Trim();
            BaseSystemInfo.CurrentProcessName = tb_cpname.Text.ToString().Trim();
            //PLC
            BaseSystemInfo.PLCType = tb_plctype.Text.ToString().Trim();
            BaseSystemInfo.MasterPLCIP = tb_plcip.Text.ToString().Trim();
            //串口
            BaseSystemInfo.SerialPortName1 = tb_port1.Text.ToString().Trim();
            BaseSystemInfo.SerialPortName2 = tb_port2.Text.ToString().Trim();
            BaseSystemInfo.SerialPortName3 = tb_port3.Text.ToString().Trim();
            //扫码器
            BaseSystemInfo.BarDeviceIP = tb_bardip.Text.ToString().Trim();
            BaseSystemInfo.BarDevicePort = tb_bardport.Text.ToString().Trim();
            BaseSystemInfo.BarEnergyIP = tb_bareip.Text.ToString().Trim();
            BaseSystemInfo.BarEnergyPort = tb_bareport.Text.ToString().Trim();
            BaseSystemInfo.BeforeBarDeviceIP = tb_bbardip.Text.ToString().Trim();
            BaseSystemInfo.BeforeBarDevicePort = tb_bbardport.Text.ToString().Trim();
            BaseSystemInfo.AfterBarDeviceIP = tb_abardip.Text.ToString().Trim();
            BaseSystemInfo.AfterBarDevicePort = tb_abardport.Text.ToString().Trim();

            ConfigHelper.SaveConfig();
            MessageBox.Show("修改成功！","提示", MessageBoxButtons.OK);
        }
    }
}
