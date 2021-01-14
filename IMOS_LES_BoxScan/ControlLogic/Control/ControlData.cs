using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

namespace ControlLogic.Control
{
    using Communication;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    using Sys.SysBusiness;


    public class ControlData
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        private static MPlcLink BoxPLC = new MPlcLink(); //PLC
        public static MPlcLink CheckOnlinePLC = new MPlcLink(); //内胆上位机重连PLC

        public static bool BoxPLCConn = false;//下传PLC状态



        public static System.Threading.Timer GetBoxMonitorDataTimer; ////读取箱体库信息线程Timer
        public static System.Threading.Timer CheckPlcStatusTimer;  //检测PLC在线状态

        public static Thread BoxInSocketThread = null; // 创建用于接收服务端消息的 线程； 内胆入库 
        public static Socket BoxInSocket = null;
        public static bool BoxInBarConn = false; //入库条码扫描设备连接状态

        private static IPEndPoint BoxInendPoint;
        private static int BoxInReConnCount = 0;


        public static void CreateBarScanSocket()//创建条码扫描Socket
        {
            #region 创建内胆入库Socket
            IPAddress BoxInIP = IPAddress.Parse(BaseSystemInfo.LinerInScanIP);
            BoxInendPoint = new IPEndPoint(BoxInIP, int.Parse(BaseSystemInfo.LinerInScanPort));
            BoxInSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            BoxInSocket.Blocking = false;
            try
            {
                BoxInSocket.Connect(BoxInendPoint);
                BoxInBarConn = true;

            }
            catch (SocketException ex)
            {
                BoxInBarConn = false;
                string TipInfo = string.Format("箱体入库条码扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", BoxInIP, BoxInendPoint.Port);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            OptionSetting.ScanStatus = BoxInBarConn;

            BoxInSocketThread = new Thread(BoxInRecMsg);
            BoxInSocketThread.IsBackground = true;
            BoxInSocketThread.Start();
            #endregion
        }

        private static void BoxInRecMsg()
        {
            string strMsg = "";

            while (true)
            {
                Thread.Sleep(5);
                byte[] arrMsgRec = new byte[50];
                // 将接收到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = BoxInSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    BoxInBarConn = true;
                }
                catch
                {
                    //  SysBusinessFunction.WriteLog("条码设备心跳信息号失败.");
                    BoxInBarConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (BoxInBarConn))
                {
                    CreateBoxInTask(strMsg.Trim());
                    GC.Collect();
                }
            }
        }

        public static void CreateBoxInTask(string BoxMaterBarCode)//条码扫描后生成内胆入库物流任务
        {
            #region 入库任务生成规则
            /*
             * 1、判断是否存在存放该物料货道  存在则下传相应的货道信息，在判断时需要考虑在途量
             * 2、如不存在存储该物料的货道 则查看是否存在空货道 存在则下传货道信息 不存在则进行报警提示
             */
            #endregion

            string ErrorBinNo = "9";
            try
            {
                bool DownFlag = false;
                string BoxBinNo = "";

                OptionSetting.CurrentScanBoxBarCode = BoxMaterBarCode;

                string FoamingBoxBarCode = "";
                int TempIndex = BoxMaterBarCode.IndexOf("B");

                string TemmpMaterCode = "";
                if ((BoxMaterBarCode.Length >= 21) && (TempIndex >= 0))
                {
                    FoamingBoxBarCode = BoxMaterBarCode.Trim().Substring(TempIndex, 21);

                    TemmpMaterCode = FoamingBoxBarCode.Substring(7, 10);

                }
                else
                {
                    OptionSetting.CurrentTip = "条码格式异常";
                    SysBusinessFunction.WriteLog("条码格式异常：" + BoxMaterBarCode);
                    BoxBinNo = ErrorBinNo;
                }

                if (TemmpMaterCode == "")
                {
                    BoxBinNo = ErrorBinNo;
                }

                #region 判断可存储货道
                if (BoxBinNo != ErrorBinNo)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        //如在库量+在途量
                        if (OptionSetting.BoxStoreBinInfo[i].MaxQty <= OptionSetting.BoxStoreBinInfo[i].StoreQty + OptionSetting.BoxStoreBinInfo[i].TransitQty)
                        {
                            continue;
                        }


                        int TempMaterIndex = OptionSetting.BoxStoreBinInfo[i].MaterialCodeStr.IndexOf(TemmpMaterCode);

                        if (TempMaterIndex >= 0)
                        {
                            BoxBinNo = (i + 1).ToString();

                        }
                    }
                }
                if (BoxBinNo == "")
                {
                    BoxBinNo = "9";

                    OptionSetting.CurrentTip = string.Format("无可存储货道.", BoxMaterBarCode);
                }
                OptionSetting.DownBinNo = BoxBinNo;


                #endregion 
                int BoxInStart = 810;
                #region 生成相应的内胆入库任务
                if (BoxBinNo != "") //生成内胆入库任务
                {
                    OptionSetting.DownBinNo = BoxBinNo;
                    SysBusinessFunction.WriteLog(string.Format("确定内胆目的货道【{0}】", BoxBinNo));

                    DownFlag = true;
                    int LinerLen = 2;
                    object[] BoxWBuff = new object[LinerLen];
                    BoxWBuff[0] = BoxBinNo;
                    BoxWBuff[1] = 1;
                    bool wresult1 = BoxPLC.Write(0, BoxInStart, BoxWBuff);

                    OptionSetting.CurrentTip = string.Format("下传内胆货道信息【{0}】成功.", BoxBinNo);
                    

                    if (!wresult1)
                    {
                        OptionSetting.CurrentTip = "下传内胆入库信息出现异常";

                        SysBusinessFunction.WriteLog("下传内胆入库信息出现异常，请检查PLC连接.");
                        return;
                    }

                    int LinerCount = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(5);

                        //下位机在收到货道信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                        if (GetTickCount() - LinerCount > 5000) //超时处理
                        {
                            OptionSetting.CurrentTip = string.Format("下传内胆货道信息【{0}】成功，等待反馈信号超时.", BoxBinNo);
                            DownFlag = false;
                            break;
                        }

                        object[] RBuf1 = new object[2];
                        BoxPLC.Read("0", BoxInStart, LinerLen, out RBuf1);

                        if (RBuf1[1].ToString() == "2")
                        {

                            BoxWBuff[0] = 0;
                            BoxWBuff[1] = 0;
                            BoxWBuff[2] = 0;
                            BoxPLC.Write(0, BoxInStart, BoxWBuff);
                            break;
                        }
                    }
                }
                else
                {
                    OptionSetting.CurrentTip = string.Format("无可存储货道.", BoxMaterBarCode);
                    return;
                }
                #endregion

            }
            catch
            {
                SysBusinessFunction.WriteLog("信息查询异常.");
            }
            finally
            {


                GC.Collect();
            }
        }


        public static void SystemInitialization()//发泡上位机系统初始化
        {
            try
            {
                BoxPLC.ActLogicalStationNumber = 1;
                BoxPLCConn = BoxPLC.Open();
                OptionSetting.PLCStatus = BoxPLCConn;
                CreateBarScanSocket();
                GetBoxMonitorDataTimer = new System.Threading.Timer(GetBoxStorePLCData, null, 0, Timeout.Infinite);//读取工位发泡信息
                CheckPlcStatusTimer = new System.Threading.Timer(CheckPlcOnLineStatus, null, 0, Timeout.Infinite);//检测PLC在线状态timer

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("箱体入库控制模块初始化异常：" + ex.Message);
            }

        }
        public static void GetBoxStorePLCData(object o)//读取柜体库中8个货道的货道号，物料编码和存储量等信息
        {
            try
            {
                #region 各货道的具体库存信息

                if (!BoxPLCConn)
                    return;

                int Len = 300; //分垛需要读取的PLC数据长度 每个货道占用32个字
                object[] Buf = new object[Len];
                object[] CountBuf = new object[8]; //货道数量 按照位进行统计 1 有料 0 无料
                object[] TempBuf = new object[1]; //货道启用状态                

                bool PLCRead = BoxPLC.Read("0", 820, Len, out Buf);

                object[] QtyBuf = new object[20];

                bool PLCRead1 = BoxPLC.Read("0", 700, 20, out QtyBuf);

                for (int i = 0; i < 8; i++)
                {
                    int StoreBinNo = i + 1; //货道号

                    string MaterialCode1 = "";
                    string MaterialCode2 = "";
                    string MaterialCode3 = "";


                    for (int j = 0; j < 5; j++) //读取PLC数据 取得相应的库存物料编号 长度为5位 每个字占用2字符 共10个字符
                    {
                        //  SysBusinessFunction.WriteLog("发泡货道 " + (i+1).ToString() + " == " + (int)Buf[i * 20 + j]);
                        int AsciiCode = (int)Buf[i * 30 + j];

                        if (AsciiCode == 0)
                        {
                            break;
                        }
                        MaterialCode1 = MaterialCode1 + SysBusinessFunction.BinaryToStr(AsciiCode);//物料编码
                    }

                    OptionSetting.BoxStoreBinInfo[i].MaterialCode1 = MaterialCode1;
                    OptionSetting.BoxStoreBinInfo[i].MaxQty = (int)QtyBuf[i];
                    OptionSetting.BoxStoreBinInfo[i].StoreQty = (int)Buf[i];
                    OptionSetting.BoxStoreBinInfo[i].TransitQty = (int)QtyBuf[10 + i];
                    //如第一个物料为空 获取第二个物料

                    for (int j = 0; j < 5; j++) //读取PLC数据 取得相应的库存物料编号 长度为5位 每个字占用2字符 共10个字符
                    {
                        //  SysBusinessFunction.WriteLog("发泡货道 " + (i+1).ToString() + " == " + (int)Buf[i * 20 + j]);
                        int AsciiCode = (int)Buf[i * 30 + j + 6];

                        if (AsciiCode == 0)
                        {
                            break;
                        }
                        MaterialCode2 = MaterialCode2 + SysBusinessFunction.BinaryToStr(AsciiCode);//物料编码

                    }
                    OptionSetting.BoxStoreBinInfo[i].MaterialCode2 = MaterialCode2;


                    //如第二个物料为空 获取第三个物料

                    for (int j = 0; j < 5; j++) //读取PLC数据 取得相应的库存物料编号 长度为5位 每个字占用2字符 共10个字符
                    {
                        //  SysBusinessFunction.WriteLog("发泡货道 " + (i+1).ToString() + " == " + (int)Buf[i * 20 + j]);
                        int AsciiCode = (int)Buf[i * 30 + j + 12];

                        if (AsciiCode == 0)
                        {
                            break;
                        }
                        MaterialCode3 = MaterialCode3 + SysBusinessFunction.BinaryToStr(AsciiCode);//物料编码
                    }

                    OptionSetting.BoxStoreBinInfo[i].MaterialCode3 = MaterialCode3;

                     OptionSetting.BoxStoreBinInfo[i].MaterialCodeStr = MaterialCode1 + "," + MaterialCode2 + "," + MaterialCode3;

                 //   OptionSetting.BoxStoreBinInfo[i].MaterialCodeStr = (i+1).ToString() + "234567890";
                }



            }
            #endregion

            catch
            {

            }
            finally
            {
                GetBoxMonitorDataTimer.Change(500, Timeout.Infinite);
            }
        }

        private static void CheckPlcOnLineStatus(object o)//检查各PLC的在线状态 离线进行重连
        {
            try
            {
                //箱壳产线PLC连接
                CheckOnlinePLC.Close();
                CheckOnlinePLC.ActLogicalStationNumber = BoxPLC.ActLogicalStationNumber;
                BoxPLCConn = CheckOnlinePLC.Open();
                if (!BoxPLCConn) //PLC连接失败
                {
                    BoxPLC.Close();
                    BoxPLCConn = BoxPLC.Open();
                }

                byte[] arrMsgRec = new byte[1];

                #region 内胆入库条码扫描


                if (!BoxInBarConn)
                {
                    try
                    {
                        if (BoxInReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("箱体入库条码扫描设备断线重连中......，{0}", BoxInendPoint.ToString()));
                        }
                        BoxInReConnCount++;
                        BoxInSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        BoxInSocket.Connect(BoxInendPoint);
                        BoxInBarConn = true;
                        SysBusinessFunction.WriteLog(string.Format("箱体入库条码扫描设备重新连接成功，重连次数{0}，{1}", BoxInReConnCount, BoxInendPoint.ToString()));
                        BoxInReConnCount = 0;
                    }
                    catch (SocketException ex)
                    {
                    }
                }

                try
                {
                    int sLen = BoxInSocket.Send(arrMsgRec);
                    BoxInBarConn = sLen == 1;
                }
                catch
                {
                    BoxInBarConn = false;
                }
                #endregion

            }
            catch
            {
            }
            finally
            {
                CheckPlcStatusTimer.Change(5000, Timeout.Infinite);
            }
        }

    }
}
