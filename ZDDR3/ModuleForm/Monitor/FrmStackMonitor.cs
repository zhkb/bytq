using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sys.SysBusiness;
using Sys.Config;
using ControlLogic.Control;
using System.Runtime.InteropServices;
using System.Threading;
using Sys.DbUtilities;

namespace Monitor
{
    public partial class FrmStackMonitor : Form
    {
        //[DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        //extern static int GetTickCount();
        string m_strInfo = "";
        private bool DifferentiateFlag = true;
        private Image[] ConnImage = { Monitor.Properties.Resources.Status_Red, Monitor.Properties.Resources.Status_Green }; //连接状态显示颜色 
        public FrmStackMonitor()
        {
            InitializeComponent();
        }

        private void FrmStack_Load(object sender, EventArgs e)
        {
            lbFactoryNumber.Text = BaseSystemInfo.FactoryNumber;

            //从PLC获取 条码》WMS》库位号》下传PLC（库位号改变换产）

            timer1.Enabled = true;
            timer2.Enabled = true;
            //从PLC中实时获取数据刷新界面

        }

        private void sendWMS(string strBarcode, string strFactory)
        {
            try
            {
                string strInfo = "扫码:" + strBarcode;
                m_strInfo = strInfo;
                //定义传入参数
                Haier_WMS_Interface.mdjBhDTO F_mdjBhDTO = new Haier_WMS_Interface.mdjBhDTO();

                F_mdjBhDTO.barCode = strBarcode;
                F_mdjBhDTO.factoryCode = strFactory;

                //定义返回值参数
                Haier_WMS_Interface.transResult F_transResult = new Haier_WMS_Interface.transResult();
                Haier_WMS_Interface.RfWebServiceImplService F_RfWebServiceImplService = new Haier_WMS_Interface.RfWebServiceImplService();

                //设置webservice参数
                F_RfWebServiceImplService.Url = BaseSystemInfo.webServiceAddress;
                F_RfWebServiceImplService.Timeout = 5000;

                //调用接口函数
                lbSendWMStime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                F_transResult = F_RfWebServiceImplService.StackerCraneBH(F_mdjBhDTO);

                //显示返回值,返回消息
                lbWMSbackInfo.Text = F_transResult.code + "," + F_transResult.msg;
                lbWMSBackTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (F_transResult.code == "1")
                {
                    lbInfo.ForeColor = Color.Gold;
                    lbWMSbackInfo.ForeColor = Color.Gold;
                    m_strInfo = m_strInfo + ";   WMS信息:成功 ";
                    string strStoreCode = (string)F_transResult.data; //库位信息
                    lbStoreInfo.Text = strStoreCode; //库位信息
                    if (OptionSetting.G_CurrentStoreCode1 == "" || OptionSetting.G_CurrentStoreCode1 == strStoreCode)
                    {
                        OptionSetting.G_CurrentStoreCode1 = strStoreCode; //库位信息                                                 
                    }
                    else
                    {
                        OptionSetting.G_PreviousStoreCode1 = OptionSetting.G_CurrentStoreCode1; //前一个库位
                        OptionSetting.G_CurrentStoreCode1 = strStoreCode; //库位信息
                        DifferentiateFlag = !DifferentiateFlag;
                    }
                    if (DifferentiateFlag)//true 码垛A false 码垛B
                    {
                        DownPLC(1);//下传码垛信号和库位信号
                    }
                    else 
                    {
                        DownPLC(2);           
                    }

                }
                else
                {
                    m_strInfo = m_strInfo + ";   WMS信息:" + F_transResult.msg;
                    lbInfo.ForeColor = Color.Red;
                    lbWMSbackInfo.ForeColor = Color.Red;
                    //dealwithPLC(99, strBarcode);//PLC发送 99异常
                }
                lbInfo.Text = m_strInfo;

            }
            catch (Exception ex)
            {
                lbWMSBackTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                lbInfo.ForeColor = Color.Red;
                lbWMSbackInfo.Text = ex.Message;
                lbWMSbackInfo.ForeColor = Color.Red;
                DownPLC(3);
            
        }
        }

        private void DownPLC(int v)//下传码垛区号和库位号
        {
          try
            {
                string strInfo = "";
                int DataBlock = 0;
                int StartDataAddress = 30;
                object[] WriteBuff = new object[7];
                WriteBuff[0] = 1; //应答字 
                WriteBuff[1] = v; //产品码垛分区
                for(int i = 0; i <= 4; i++)
                {
                    WriteBuff[i + 2] = SysBusinessFunction.StrToBinary(OptionSetting.G_CurrentStoreCode1[i].ToString());
                }
                bool PLCWriteFlag =  ControlMaster.WriteData(DataBlock,StartDataAddress,WriteBuff);

            }
            catch(Exception ex)
            {

            }
        }

        //private void dealwithPLC(int iData, string strBarcode)
        //{
        //    // bool flag = false;
        //    string strInfo = "";
        //    int DataBlock = 0;
        //    int StartDataAddress = 30;
        //    object[] WriteBuff = new object[2];
        //    WriteBuff[0] = 1;//应答字
        //    WriteBuff[1] = iData;//PLC发送 1不换托盘 2 换托盘 99 异常（讨论异常情况如何处理）
        //    bool PLCWrite = ControlMaster.WriteData(DataBlock, StartDataAddress, WriteBuff);//传入换产标志
        //    Thread.Sleep(10);
        //    if (PLCWrite)
        //    {
        //        /////////////////////////////////////////////////////////
        //        object[] readBuf = new object[2];
        //        for (int i = 0; i < 2; i++)
        //        {
        //            readBuf[i] = 0;
        //        }
        //        int CoamingTick = GetTickCount();
        //        while (true) {
        //            Thread.Sleep(1);
        //            if (GetTickCount() - CoamingTick < 5000) //超时退出 重新下传 超时时间为5秒
        //            {
        //                ControlMaster.ReadData(DataBlock, StartDataAddress, 2, out readBuf);
        //                Application.DoEvents();
        //                if ("2".Equals(readBuf[0].ToString().Trim()))
        //                {
        //                    strInfo = string.Format("扫码【{0}】应答成功", strBarcode);
        //                    lbInfo.Text = m_strInfo + "PLC下传换产信号成功;";
        //                    lbPLCinfo.Text = strInfo;
        //                    lbPLCinfo.ForeColor = Color.Gold;
        //                    strInfo = string.Format("扫码【{0}】应答【{1}】信号【{2}】", strBarcode, readBuf[0].ToString(), readBuf[1].ToString());
        //                    SysBusinessFunction.WriteLog(strInfo);
        //                    break;
        //                }
        //            } else
        //            {
        //                SysBusinessFunction.WriteLog(string.Format("扫码{0}下传PLC反馈数据超时，请检查PLC连接", strBarcode));
        //                pic_PlcState.Image = ConnImage[Convert.ToInt32(false)];//PLC状态
        //                strInfo = "PLC下传,读取反馈数据超时";
        //                lbPLCinfo.ForeColor = Color.Red;
        //                m_strInfo = m_strInfo + ";   PLC下传超时失败";
        //                lbInfo.Text = m_strInfo;
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        SysBusinessFunction.WriteLog(string.Format("扫码{0}，下传PLC失败", OptionSetting.G_productCodeA));
        //        strInfo = "PLC写入指令失败，请检查连接状态";
        //        lbPLCinfo.ForeColor = Color.Red;
        //        m_strInfo = m_strInfo + ";   PLC写入指令失败";
        //    }
        //    lbPLCinfo.Text = strInfo;
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bool flag = false;
                int Address = 0;
                int DataBlock = 0;
                object[] readBuf = new object[21];
                flag = ControlMaster.ReadData(DataBlock, Address, 21, out readBuf);
                OptionSetting.G_productCodeA = "";
                if (flag  && "1".Equals(readBuf[0].ToString().Trim()))
                {
                    for (int i = 0; i <= 19; i++)
                    {
                        OptionSetting.G_productCodeA = OptionSetting.G_productCodeA + SysBusinessFunction.BinaryToStr((int)readBuf[i+1]);
                    }
                    if (OptionSetting.G_productCodeA.Length > 0)
                    {
                        txtBarCode.Text = OptionSetting.G_productCodeA;
                        lbScanTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        Application.DoEvents();
                    }
                    if (OptionSetting.G_productCodeA.Length == 20)
                    {
                        m_strInfo = "扫描成功";
                        timer1.Enabled = false;
                        object[] wBuf = new object[1];
                        wBuf[0] = 0;
                        ControlMaster.WriteData(DataBlock, Address, wBuf);//读取完置为0
                        DownPLC(1);
                        sendWMS(OptionSetting.G_productCodeA, BaseSystemInfo.FactoryNumber);
                        OptionSetting.G_productCodeA = "";
                    }
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                timer1.Enabled = true;
            }
        }

     
        private void FrmStack_Resize(object sender, EventArgs e)
        {
            panelGRIDL.Width = panelDOWN.Width / 2;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //从PLC读取库位号
            try
            {
                string storecodeA = "";
                string storecodeB = "";
                bool flag = false;
                int Address = 40;
                int DataBlock = 0;
                object[] readBuf = new object[10];
                flag = ControlMaster.ReadData(DataBlock, Address, 10, out readBuf);
                for(int i = 0; i < readBuf.Length; i++)
                {
                    if (i < 5)
                    {
                        storecodeA = storecodeA + SysBusinessFunction.BinaryToStr((int)readBuf[i]);
                    }else
                    {
                        storecodeB = storecodeB + SysBusinessFunction.BinaryToStr((int)readBuf[i]);
                    }
                }
                lbl_StoreCodeA.Text = storecodeA;
                lbl_StoreCodeB.Text = storecodeB;
                lbl_Time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            }
            catch(Exception ex)
            {

            }
        }
    }
}
