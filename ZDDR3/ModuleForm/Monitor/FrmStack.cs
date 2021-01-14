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
    public partial class FrmStack : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        public System.Threading.Timer GetPlcDataTimer;
        public System.Threading.Timer GetPlcDataTimer2;
        //1031 条码
        //1065 码垛1 不码垛2 等待0
        //1231 条码
        //1265 码垛1 不码垛2 等待0
        private string oldbarcode =null;
        private string oldbarcode2 = null;
        public FrmStack()
        {
            InitializeComponent();
        }

        private void FrmStack_Load(object sender, EventArgs e)
        {
            ControlMaster.SystemInitialization();
            lbFactoryNumber.Text = BaseSystemInfo.FactoryNumber;
            GetPlcDataTimer = new System.Threading.Timer(GetPLC, null, 0, Timeout.Infinite); //重新连接设备Timer 
            GetPlcDataTimer2 = new System.Threading.Timer(GetPLC2, null, 0, Timeout.Infinite); //重新连接设备Timer 
        }

        private void GetPLC2(object state)
        {
            try
            {
                if (oldbarcode2 == null)
                {
                    oldbarcode2 = "";
                    SysBusinessFunction.WriteLog("机器人初始化");
                    return;
                }
                bool flag = false;
                int Address = 1231;
                int DataBlock = 0;
                object[] readBuf = new object[10];
                flag = ControlMaster.ReadData(DataBlock, Address, 10, out readBuf);
                String lbarcode = "";
                for (int i = 0; i < 10; i++)
                {
                    lbarcode = lbarcode + SysBusinessFunction.ReverseString(SysBusinessFunction.BinaryToStr((int)readBuf[i]));
                }
                if(lbarcode == "")
                {
                    BeginInvoke(new Action(() =>
                    {
                        //清空数据
                        lbInfo2.Text = "";
                        lbPLCinfo2.Text = "";
                        lbSendWMStime2.Text = "";
                        lbWMSbackInfo2.Text = "";
                        lbWMSBackTime2.Text = "";
                        lbStoreInfo2.Text = "";
                        lbl_ScanTime2.Text = "";
                        txtBarCode2.Text = "";

                    }));
                    return;
                }
                if (lbarcode == oldbarcode2)
                {
                    return;
                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        oldbarcode2 = lbarcode;
                        //上传WMS
                       sendWMS2(lbarcode, BaseSystemInfo.FactoryNumber);
                    }));
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetPlcDataTimer2.Change(2000, Timeout.Infinite);
            }
        }

        private void GetPLC(object state)
        {
            try
            {
                if (oldbarcode == null)
                {
                    oldbarcode = "";
                    SysBusinessFunction.WriteLog("机器人初始化");
                    return;
                }
                bool flag = false;
                int Address = 1031;
                int DataBlock = 0;
                object[] readBuf = new object[10];
                flag = ControlMaster.ReadData(DataBlock, Address, 10, out readBuf);
                String mbarcode = "";

                for (int i = 0; i < 10; i++)
                {
                    mbarcode = mbarcode + SysBusinessFunction.ReverseString(SysBusinessFunction.BinaryToStr((int)readBuf[i]));
                }

                if(mbarcode == "")
                {
                    BeginInvoke(new Action(() =>
                    {
                        //清空数据
                        lbInfo.Text = "";
                        lbPLCinfo.Text = "";
                        lbSendWMStime.Text = "";
                        lbWMSbackInfo.Text = "";
                        lbWMSBackTime.Text = "";
                        lbStoreInfo.Text = "";
                        lbScanTime.Text = "";
                        txtBarCode.Text = "";
                        
                    }));
                    return;
                }

                if (mbarcode == oldbarcode)
                {
                    return;
                }
                else
                {
                    BeginInvoke(new Action(() =>
                    {
                        oldbarcode = mbarcode;
                        //上传WMS
                        sendWMS(mbarcode, BaseSystemInfo.FactoryNumber);
                    }));
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetPlcDataTimer.Change(2000, Timeout.Infinite);
            }
        }

        private void sendWMS(string strBarcode, string strFactory)
        {
            try
            {
                //清空数据
                lbInfo.Text = "";
                lbPLCinfo.Text = "";
                lbSendWMStime.Text = "";
                lbWMSbackInfo.Text = "";
                lbWMSBackTime.Text = "";
                lbStoreInfo.Text = "";

                string strInfo = "扫码:" + strBarcode;
                txtBarCode.Text = strBarcode;
                lbScanTime.Text = DateTime.Now.ToString();
                SysBusinessFunction.WriteLog(strInfo);
                //定义传入参数
                Haier_WMS_Interface.mdjBhDTO F_mdjBhDTO = new Haier_WMS_Interface.mdjBhDTO();

                F_mdjBhDTO.barCode = strBarcode;
                F_mdjBhDTO.factoryCode = strFactory;

                //定义返回值参数
                Haier_WMS_Interface.transResult F_transResult = new Haier_WMS_Interface.transResult();
                Haier_WMS_Interface.RfWebServiceImplService F_RfWebServiceImplService = new Haier_WMS_Interface.RfWebServiceImplService();

                //设置webservice参数
                F_RfWebServiceImplService.Url = BaseSystemInfo.webServiceAddress;
                F_RfWebServiceImplService.Timeout =7000;

                //调用接口函数
                lbSendWMStime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                F_transResult = F_RfWebServiceImplService.StackerCraneBH(F_mdjBhDTO);

                //显示返回值,返回消息
                lbWMSbackInfo.Text = F_transResult.code;
                lbWMSBackTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                if (F_transResult.code == "1")
                {
                    SysBusinessFunction.WriteLog("1#库位【"+ F_transResult.data + "】信息获取成功！");
                    lbInfo.Text = F_transResult.code + "," + F_transResult.data + "," + F_transResult.msg;
                    lbInfo.ForeColor = Color.Lime;
                    DownPLC(1);
                }
                else
                {
                    SysBusinessFunction.WriteLog("1#库位【" + F_transResult.msg + "】信息获取失败！");
                    lbInfo.Text = F_transResult.code + "," + F_transResult.data + "," + F_transResult.msg;
                    lbInfo.ForeColor = Color.Red;
                    //下传PLC
                    oldbarcode = "";
                    DownPLC(2);
                }
 

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("库位信息获取异常！");
                oldbarcode = "";
                //pic_PlcState.Image =  ;

                

            }
        }


        private void sendWMS2(string strBarcode, string strFactory)
        {
            try
            {
                lbInfo2.Text = "";
                lbPLCinfo2.Text = "";
                lbSendWMStime2.Text = "";
                lbWMSbackInfo2.Text = "";
                lbWMSBackTime2.Text = "";
                lbStoreInfo2.Text = "";
                string strInfo = "扫码:" + strBarcode;
                txtBarCode2.Text = strBarcode;
                lbl_ScanTime2.Text = DateTime.Now.ToString();
                SysBusinessFunction.WriteLog(strInfo);
                //定义传入参数
                Haier_WMS_Interface.mdjBhDTO F_mdjBhDTO = new Haier_WMS_Interface.mdjBhDTO();

                F_mdjBhDTO.barCode = strBarcode;
                F_mdjBhDTO.factoryCode = strFactory;

                //定义返回值参数
                Haier_WMS_Interface.transResult F_transResult = new Haier_WMS_Interface.transResult();
                Haier_WMS_Interface.RfWebServiceImplService F_RfWebServiceImplService = new Haier_WMS_Interface.RfWebServiceImplService();

                //设置webservice参数
                F_RfWebServiceImplService.Url = BaseSystemInfo.webServiceAddress;
                F_RfWebServiceImplService.Timeout = 7000;

                //调用接口函数
                lbSendWMStime2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                F_transResult = F_RfWebServiceImplService.StackerCraneBH(F_mdjBhDTO);

                //显示返回值,返回消息
                lbWMSbackInfo2.Text = F_transResult.code ;
                lbWMSBackTime2.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                if (F_transResult.code == "1")
                {
                    SysBusinessFunction.WriteLog("2#库位【" + F_transResult.data + "】信息获取成功！");
                    lbInfo2.Text = F_transResult.code + "," + F_transResult.data+"," + F_transResult.msg;
                    lbInfo2.ForeColor = Color.Lime;
                    DownPLC2(1);
                }
                else
                {
                    SysBusinessFunction.WriteLog("2#库位【" + F_transResult.msg + "】信息获取失败！");
                    lbInfo2.Text = F_transResult.code + "," + F_transResult.data + "," + F_transResult.msg;
                    lbInfo2.ForeColor = Color.Red;
                    //下传PLC
                    oldbarcode2 = "";
                    DownPLC2(2);
                }


            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("库位信息获取异常！");
                oldbarcode2 = "";
                DownPLC2(2);

            }
        }
        private void DownPLC(int v)
        {
            try
            {   bool flag = false;
                int Address = 1065;
                int DataBlock = 0;
                object[] WBuf = new object[1];
                WBuf[0] = v;
                flag = ControlMaster.WriteData(DataBlock, Address, WBuf);
                if (flag)
                {
                    SysBusinessFunction.WriteLog("1#PLC下传信号【" + v + "】成功！");
                    lbPLCinfo.Text = "PLC下传信号成功！";
                    lbPLCinfo.ForeColor = Color.Lime;
                }
                else
                {
                    SysBusinessFunction.WriteLog("1#PLC下传信号【" + v + "】失败！");
                    lbPLCinfo.ForeColor = Color.Red;
                    lbPLCinfo.Text = "PLC下传信号失败！";
                    // flag = ControlMaster.WriteData(DataBlock, Address, WBuf);
                }
            }
            catch(Exception ex)
            {

            }
        }
        private void DownPLC2(int v)
        {
            try
            {
                bool flag = false;
                int Address = 1265;
                int DataBlock = 0;
                object[] WBuf = new object[1];
                WBuf[0] = v;
                flag = ControlMaster.WriteData(DataBlock, Address, WBuf);
                if (flag)
                {
                    SysBusinessFunction.WriteLog("2PLC下传信号【" + v + "】成功！");
                    lbPLCinfo2.Text = "PLC下传信号成功！";
                    lbPLCinfo2.ForeColor = Color.Lime;
                }
                else
                {
                    SysBusinessFunction.WriteLog("2PLC下传信号【" + v + "】失败！");
                    lbPLCinfo2.Text = "PLC下传信号失败！";
                    lbPLCinfo2.ForeColor = Color.Red;
                  
                    // flag = ControlMaster.WriteData(DataBlock, Address, WBuf);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
