using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLogic.Control
{
   public  class ControlOutStore
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        #region  OUTRFID扫码器变量
        //以太网OUTRFID扫码
        private static Socket OUTRFIDSocket; //OUTRFID扫码
        private static IPEndPoint OUTRFIDPoint;//IP及端口信息
        private static bool OUTRFIDConn = false;
        private static Thread OUTRFIDInSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer OUTRFIDReConnectDeviceTimer; //重新连接socket
        private static int OUTRFIDReConnCount = 0;
        #endregion

        public static System.Threading.Timer GetOutStoreTimer; //接受出库信号

        public static System.Threading.Timer RunOutStoreTimer; //运行出库信号  
        #region 初始化
        public static void SystemInitialization()//初始化
        {
            CreateOUTRFIDSocket();
            OUTRFIDReConnectDeviceTimer = new System.Threading.Timer(ReOUTRFIDDevice, null, 0, Timeout.Infinite);//条码扫描设备重连           
            GetOutStoreTimer = new System.Threading.Timer(GetPLCDevice, null, 0, Timeout.Infinite);
            RunOutStoreTimer = new System.Threading.Timer(RunPLCDevice, null, 0, Timeout.Infinite);
        }

      

        #endregion

        #region OUTRFID 扫码器创建
        private static void CreateOUTRFIDSocket()//创建OUTRFID扫码器
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.OUTRFIDIP);//IP地址
            OUTRFIDPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.OUTRFIDPort));//端口号
            OUTRFIDSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            OUTRFIDSocket.Blocking = true;
            try
            {
                OUTRFIDSocket.Connect(OUTRFIDPoint);
                OUTRFIDSocket.Blocking = false;
                OUTRFIDConn = true;
            }
            catch (SocketException ex)
            {
                OUTRFIDConn = false;
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.OUTRFIDPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            OUTRFIDInSocketThread = new Thread(OUTRFIDInRecMsg);
            OUTRFIDInSocketThread.IsBackground = true;
            OUTRFIDInSocketThread.Start();
            #endregion
        }

        #endregion

        #region OUTRFID扫码器获取数据
        private static void OUTRFIDInRecMsg()
        {
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(5);
                byte[] arrMsgRec = new byte[50];
                // 将接受到的数据存入到arrMsgRec中；  
                int length = -1;
                try
                {
                    length = OUTRFIDSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    OUTRFIDConn = true;
                }
                catch
                {
                    OUTRFIDConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (OUTRFIDConn))
                {
                    HandleOUTRFIDData(strMsg.Trim());
                }
            }
        }

        #endregion

        #region OUTRFID扫码器数据处理
        private static void HandleOUTRFIDData(string BarCode)//产品条码
        {
            //扫码出库
            try
            {              
                String RFIDCode = BarCode.Trim();
                SysBusinessFunction.WriteLog("出库工装板RFID【" + RFIDCode + "】");
                //判断RFID是否满足规范
                if (RFIDCode.ToUpper() == "NO READ")
                {
                    SysBusinessFunction.WriteLog("RFID读取失败NOREAD");
                    return;
                }
                if (RFIDCode.Length != 5)
                {
                    SysBusinessFunction.WriteLog("RFID条码格式不对");
                    return;
                }

                //删除绑定信息
                String sql = String.Format(@"DELETE FROM IMOS_Lo_Pallet WHERE RFID_Code = '{0}'",RFIDCode);
                DataSet ds = DataHelper.Fill(sql);

                SysBusinessFunction.WriteLog("绑定信息删除【"+ RFIDCode + "】");
                //修改出库任务
                String updsql = String.Format(@"update IMOS_Lo_Task SET Task_State = '{0}' where RFID_BarCode = '{1}' and Task_Type = '{2}' and Task_State = '{3}'","2",RFIDCode,"2","1");
                DataHelper.Fill(updsql);
                SysBusinessFunction.WriteLog("出库任务信息更新【" + RFIDCode + "】出库完成");
                //删除详细表
                String delsql =  String.Format(@"DELETE From IMOS_Lo_Bin_Detial Where   RFID_Code = '{0}'  and  Material_State = '{1}'",RFIDCode,"3");
                DataHelper.Fill(delsql);

                SysBusinessFunction.WriteLog("工装板【" + RFIDCode + "】出库完成，详细表删除");
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 以太网扫码器重连
        public static void ReOUTRFIDDevice(object o)//OUTRFID重连接
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!OUTRFIDConn)
                {
                    try
                    {
                        if (OUTRFIDReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("出库RFID扫描设备断线重连中......，{0}", OUTRFIDReConnCount.ToString()));
                        }
                        OUTRFIDReConnCount++;
                        OUTRFIDSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        OUTRFIDSocket.Connect(OUTRFIDPoint);
                        OUTRFIDConn = true;
                        SysBusinessFunction.WriteLog(string.Format("出库RFID扫描设备重新连接成功，重连次数{0}，{1}", OUTRFIDReConnCount, OUTRFIDPoint.ToString()));
                        OUTRFIDReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = OUTRFIDSocket.Send(arrMsgRec);
                    OUTRFIDConn = sLen == 1;
                }
                catch
                {
                    OUTRFIDConn = false;
                }
            }
            catch
            {
            }
            finally
            {
                OUTRFIDReConnectDeviceTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion

        #region PLC信息
        private static void GetPLCDevice(object state)
        {
            try
            {
                //PLC获取产品型号
                Thread.Sleep(10);
                int address = 320;
                int Address = 330;
                int block = 0;
                int len = 7;
                object[] Rbuf = new object[len];
                object[] WBuf = new object[1];
                object[] Wbuf = new object[5];
                bool result = ControlMaster.ReadData(block, address,len,out Rbuf);
                if (result)
                {
                    if (Rbuf[0].ToString() == "1")
                    {
                        String mcode ="";
                        for(int i = 1; i <= 6; i++)
                        {
                            mcode = mcode + SysBusinessFunction.BinaryToStr(int.Parse(Rbuf[i].ToString()));
                        }
                        if(mcode != null && mcode.Trim().Length == 6)
                        {
                            String sql = String.Format(@"SELECT Top 1
                                                            A.Bar_Code,   
	                                                        A.Store_Code,
                                                            B.Store_Name,
	                                                        A.Material_Name,
                                                            A.RFID_Code
                                                        FROM
	                                                        IMOS_Lo_Bin_Detial  A left join IMOS_Lo_Bin  B on  A.Store_Code =  B.Store_Code 
                                                        WHERE
	                                                        A.Material_Code = '{0}'and Material_State = '{1}'
                                                        Order by In_Time", mcode,"1");
                            DataSet ds = DataHelper.Fill(sql);
                            if(ds!=null && ds.Tables[0].Rows.Count == 1)
                            {
                                //创建出库任务
                                String insql = String.Format(@"INSERT INTO IMOS_LO_TASK
                                                                           (  Task_ID,
                                                                              Company_Code,
                                                                              Company_Name,
                                                                              Factory_Code,
                                                                              Factory_Name,
                                                                              Product_Line_Code,
                                                                              Product_Line_Name,
                                                                              Area_Code,
                                                                              Area_Name,
                                                                              Store_Code,
                                                                              Store_Name,
                                                                              Material_Code,
                                                                              Material_Name,
                                                                              Bar_Code,
                                                                              Task_State,
                                                                              Task_Type,
                                                                              Create_Time ,
                                                                              Update_Time ,
                                                                              CurrentProcessCode,
                                                                              CurrentProcessName,
                                                                              RFID_BarCode)
                                                                  VALUES      ('{0}','{1}' ,'{2}','{3}','{4}', '{5}','{6}' ,
	                                                                          '{7}' ,'{8}','{9}','{10}' ,'{11}' ,'{12}',
	                                                                          '{13}','{14}','{15}',getdate(),getdate(),
                                                                              '{16}','{17}','{18}')",
                                                  mcode+DateTime.Now.ToString("yyyyMMddHHmmss"),BaseSystemInfo.CompanyCode,BaseSystemInfo.CompanyName,
                                                  BaseSystemInfo.FactoryCode,BaseSystemInfo.FactoryName,BaseSystemInfo.ProductLineCode,BaseSystemInfo.ProductLineName,
                                                  BaseSystemInfo.AreaCode,BaseSystemInfo.AreaCode,ds.Tables[0].Rows[0]["Store_Code"].ToString(),ds.Tables[0].Rows[0]["Store_Name"].ToString(),
                                                  mcode, ds.Tables[0].Rows[0]["Material_Name"].ToString(),ds.Tables[0].Rows[0]["Bar_Code"].ToString(),"0","2",
                                                  "GX002","产品出库", ds.Tables[0].Rows[0]["RFID_Code"].ToString());
                                DataHelper.Fill(insql);
                                SysBusinessFunction.WriteLog("出库任务创建成功，出库吊笼【"+ ds.Tables[0].Rows[0]["RFID_Code"].ToString() + "】出库产品【"+ ds.Tables[0].Rows[0]["Bar_Code"].ToString() + "】");
                                String updsql = String.Format(@"UPDATE IMOS_Lo_Bin_Detial SET Material_State = '{0}' where RFID_Code = '{1}' and Material_State = '{2}' and Store_Code = '{3}' and Area_Code = '{4}'",
                                                                 "2", ds.Tables[0].Rows[0]["RFID_Code"].ToString(),"1", ds.Tables[0].Rows[0]["Store_Code"].ToString(),BaseSystemInfo.AreaCode);
                                DataHelper.Fill(updsql);
                                SysBusinessFunction.WriteLog("产品【"+ ds.Tables[0].Rows[0]["Bar_Code"].ToString() + "】详细表更新：准备出库");
                                WBuf[0] = 2;
                                ControlMaster.WriteData(block, address, WBuf);//下传
                                //下传PLC
                                Wbuf[0] = 1;//应答字
                                Wbuf[1] = int.Parse(ds.Tables[0].Rows[0]["Store_Code"].ToString());//库位号
                                Wbuf[2] = 1;//数量
                                Wbuf[3] = 0;//备用字
                                Wbuf[4] = 0;//备用字
                                ControlMaster.WriteData(block,Address,Wbuf);//下传

                                int DownCount = GetTickCount();
                                while (true)
                                {
                                    Thread.Sleep(5);
                                    // Application.DoEvents();
                                    //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                                    if (GetTickCount() - DownCount > 5000) //超时处理
                                    {
                                        SysBusinessFunction.WriteLog("下传PLC出库任务成功，等待PLC反馈信号超时");
                                        break;
                                    }

                                    object[] RBuf = new object[1];
                                    ControlMaster.ReadData(0, address + 3, 1, out RBuf);

                                    if (RBuf[0].ToString() == "2")
                                    {
                                        Wbuf[0] = 0;//应答字
                                        Wbuf[1] = 0;//库位号
                                        Wbuf[2] = 0;//数量
                                        Wbuf[3] = 0;//备用字
                                        ControlMaster.WriteData(block, address, Wbuf);
                                        SysBusinessFunction.WriteLog("下传PLC出库任务成功，接受PLC出库任务成功");
                                    }
                                }
                            }
                            else
                            {
                                //库存不足时如何进行报警
                                int warnaddress = 340;
                                SysBusinessFunction.WriteLog("PLC上传的产品型号【" + mcode + "】库存不足！");
                                object[] WriteBuf = new object[1];
                                WriteBuf[0] = 1;
                                bool flag=ControlMaster.WriteData(0,warnaddress ,WriteBuf);
                                if (flag)
                                {
                                    SysBusinessFunction.WriteLog("下传报警信号成功！");
                                }else
                                {
                                    SysBusinessFunction.WriteLog("下传报警信号失败！");
                                }
                               
                            }
                        }else
                        {
                            SysBusinessFunction.WriteLog("PLC上传的产品型号【" + mcode + "】不正确！");
                        }
                    }
                    //插入任务表

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetOutStoreTimer.Change(1000, Timeout.Infinite);
            }

        }

        #endregion

        #region 出库动作
        private static void RunPLCDevice(object state)
        {
            try
            {
                //PLC获取产品型号
                Thread.Sleep(10);
                int address = 150;
                int block = 0;
                int len = 40;
                object[] Rbuf = new object[40];
                object[] Wbuf = new object[1];
                bool result = ControlMaster.ReadData(block, address, len, out Rbuf);
                if (result)
                {
                    for(int i = 0; i < 8; i++)
                    {
                         if (Rbuf[2+5*i].ToString() == "1")
                        {
                            SysBusinessFunction.WriteLog("货道【"+(i+1)+"】正在出库！");
                            string rfidcode = Rbuf[5 * i].ToString();
                            string storecode = Rbuf[1 + 5 * i].ToString();
                            //修改任务表
                            String updsql = String.Format(@"update IMOS_Lo_Task SET Task_State = '{0}' where RFID_BarCode = '{1}' and Task_Type = '{2}' and Task_State = '{3}'", "1", rfidcode, "2", "0");
                            DataHelper.Fill(updsql);
                            SysBusinessFunction.WriteLog("出库任务更新【"+ rfidcode + "】：正在出库！");

                            //修改详细表
                            String usql = String.Format(@"UPDATE IMOS_Lo_Bin_Detial SET Material_State = '{0}' where RFID_Code = '{1}' and Store_Code = '{2}' and Area_Code = '{3}'and Material_State = '{4}'", "3", rfidcode, storecode, BaseSystemInfo.AreaCode,"2");
                            DataHelper.Fill(usql);
                            SysBusinessFunction.WriteLog("详细表更新【" + rfidcode + "】：正在出库！");
                            Wbuf[0] = 2;
                            bool flag = ControlMaster.WriteData(block, address+2 + 5 * i, Wbuf);
                            if (flag)
                            {
                                SysBusinessFunction.WriteLog("下传PLC反馈成功！");
                            }else
                            {
                                SysBusinessFunction.WriteLog("下传PLC反馈失败！");
                            }
                            
                        }
                    }

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                RunOutStoreTimer.Change(1000, Timeout.Infinite);
            }

        }

        #endregion
    }
}
