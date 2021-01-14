using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using Communication;
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
    public partial class FrmFrontCacheBinModify : Form
    {
        #region 变量定义
        public static MPlcLink MasterPLC = new MPlcLink(); //定义PLC
        public static MPlcLink CheckOnlinePLC = new MPlcLink();//重连
        public static bool MasterPLCPLCConn = false;//设备PLC状态
        public static System.Threading.Timer CheckPlcStatusTimer;//检查PLC设备连接状态Time
                                                                 //读取PLC货道信息
        public static System.Threading.Timer GetStoStockDataTimer; //读取货道信息
        public bool Process_Flag = false; //工位标志 false 1 true 2
        string proCode = "";
        
        #endregion

        public FrmFrontCacheBinModify(string code)
        {
            InitializeComponent();
            proCode = code;
        }

        private void FrmFrontCacheBinModify_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            ControlMaster.SystemInitialization();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBinNo.Text))
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请选择货道号 Please Select");
                return;
            }

            int Bin_No = int.Parse(txtBinNo.Text.Trim().Substring(0,1));
            string code = proCode;

            #region PLC 上传

            int TransQtyAddress = 95 + (5 * (Bin_No));
            int ActQtyAddress = 96 + (5 * (Bin_No));
            int BinFlagAddress = 97 + (5 * (Bin_No));
            int FullFlagAddress = 98 + (5 * (Bin_No));
            int TransQty = 0;
            int ActualQty = 0;
            object[] RBuff = new object[1];
            ControlMaster.ReadData(0, BinFlagAddress, 1, out RBuff);
            if (!"1".Equals(RBuff[0].ToString().Trim()))
            {
                ControlMaster.ReadData(0, TransQtyAddress, 1, out RBuff);
                if (!string.IsNullOrEmpty(RBuff[0].ToString().Trim()))
                {
                    TransQty = int.Parse(RBuff[0].ToString().Trim());
                }
                ControlMaster.ReadData(0, ActQtyAddress, 1, out RBuff);
                if (!string.IsNullOrEmpty(RBuff[0].ToString().Trim()))
                {
                    ActualQty = int.Parse(RBuff[0].ToString().Trim());
                }
                if (TransQty + ActualQty < 20)
                {
                    ControlMaster.ReadData(0, FullFlagAddress, 1, out RBuff);
                    if ("0".Equals(RBuff[0].ToString().Trim()))
                    {
                        if (Process_Flag)
                        {
                            OptionSetting.BinNoB = Bin_No.ToString();
                        }
                        else
                        {
                            OptionSetting.BinNoA = Bin_No.ToString();
                        }
                        #region PLC 下传放行
                        PLCRelease(Bin_No,code);
                        #endregion

                        #region 修改明细表
                        string sql = string.Format(@"INSERT INTO [IMOS_Lo_Bin_Detail] (
                                                                  [Company_Code]
                                                                  ,[Company_Name]
                                                                  ,[Factory_Code]
                                                                  ,[Factory_Name]
                                                                  ,[Product_Line_Code]
                                                                  ,[Product_Line_Name]
                                                                  ,[Bin_No]
                                                                  ,[Bar_Code]
                                                                  ,[Material_Status]
                                                                  ,[Create_Time]
                                                                  ,[Store_Code])
                                                                  VALUES
                                                                    ('{0}'
                                                                    ,'{1}'
                                                                    ,'{2}'
                                                                    ,'{3}'
                                                                    ,'{4}'
                                                                    ,'{5}'
                                                                    ,'{6}'
                                                                    ,'{7}'
                                                                    ,'{8}'
                                                                    ,GETDATE()
                                                                    ,'{9}')",
                                                       BaseSystemInfo.CompanyCode
                                                       , BaseSystemInfo.CompanyName
                                                       , BaseSystemInfo.FactoryCode
                                                       , BaseSystemInfo.FactoryName
                                                       , BaseSystemInfo.ProductLineCode
                                                       , BaseSystemInfo.ProductLineName
                                                       , Bin_No
                                                       , code
                                                       , 0,"3001");
                        DataHelper.Fill(sql);
                        #endregion
                        DialogResult = DialogResult.OK;
                        OptionSetting.ModifyBinA = false;
                        OptionSetting.ModifyBinB = false;
                    }
                    else
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "货道已满 Full");
                    }
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "货道已满 Full");
                }
            }
            else
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "货道禁用状态 NG");
            }
            #endregion          
        }

        #region 选择分道
        private void btnBin1_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "1" + "#";
        }

        private void btnBin2_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "2" + "#";
        }

        private void btnBin3_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "3" + "#";
        }

        private void btnBin4_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "4" + "#";
        }

        private void btnBin5_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "5" + "#";
        }

        private void btnBin6_Click(object sender, EventArgs e)
        {
            txtBinNo.Text = "6" + "#";
        }
        #endregion

        #region 下传PLC放行
        private void PLCRelease(int binNo , string code)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    int WriteReleaseAddress = 201;


                    object[] WBuff = new object[2];
                    WBuff[0] = 1;
                    WBuff[1] = binNo;
                    bool result = ControlMaster.WriteData(0, WriteReleaseAddress, WBuff);
                    if (!result)
                    {
                        SysBusinessFunction.WriteLog("下传信号异常......");
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "下传信号异常 Fail");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "下传失败 Fail");
                    SysBusinessFunction.WriteLog(string.Format("下传失败:" + ex.Message));
                }
            }));
        }
        #endregion
/*
        #region 下传PLC不放行
        private void PLCNoRelease(int binNo, string code)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    int WriteReleaseAddress = 201;

                    object[] WBuff = new object[2];
                    WBuff[0] = 2;
                    WBuff[1] = binNo;
                    bool result = ControlMaster.WriteData(0, WriteReleaseAddress, WBuff);
                    if (!result)
                    {
                        SysBusinessFunction.WriteLog("下传信号异常......");
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "下传失败 Fail");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "下传失败 Fail");
                    SysBusinessFunction.WriteLog(string.Format("下传失败:" + ex.Message));
                }
            }));
        }
        #endregion*/
    }
   
}
