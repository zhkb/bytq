using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLogic.Control
{
    public  class ControlInStore
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        #region  INRFID扫码器变量
        //以太网INRFID扫码
        private static Socket INRFIDSocket; //INRFID扫码
        private static IPEndPoint INRFIDPoint;//IP及端口信息
        private static bool INRFIDConn = false;
        private static Thread INRFIDInSocketThread = null; // 创建用于接收服务端消息的 线程； 
        public static System.Threading.Timer INRFIDReConnectDeviceTimer; //重新连接socket
        private static int INRFIDReConnCount = 0;
        #endregion

        //接受入库信号线程
        public static System.Threading.Timer GetInStoreTimer; //接受入库信号
        public static System.Threading.Timer UpdateStoreTimer; //更新库存信息
        public static String oldRFID = "";
        #region 初始化
        public static  void SystemInitialization()//初始化
        {
       
            CreateINRFIDSocket();
            INRFIDReConnectDeviceTimer = new System.Threading.Timer(ReINRFIDDevice, null, 0, Timeout.Infinite);//条码扫描设备重连           
            GetInStoreTimer  = new System.Threading.Timer(GetPLCDevice, null, 0, Timeout.Infinite);
                
        }

       
        #endregion


        #region INRFID 扫码器创建
        private static  void CreateINRFIDSocket()//创建INRFID扫码器
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.INRFIDIP);//IP地址
            INRFIDPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.INRFIDPort));//端口号
            INRFIDSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            INRFIDSocket.Blocking = true;
            try
            {
                INRFIDSocket.Connect(INRFIDPoint);
                INRFIDSocket.Blocking = false;
                INRFIDConn = true;
            }
            catch (SocketException ex)
            {
                INRFIDConn = false;
                string TipInfo = string.Format("扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", InIP, BaseSystemInfo.INRFIDPort);
                // MessageBox.Show(TipInfo);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            INRFIDInSocketThread = new Thread(INRFIDInRecMsg);
            INRFIDInSocketThread.IsBackground = true;
            INRFIDInSocketThread.Start();
            #endregion
        }

        #endregion

        #region INRFID扫码器获取数据
        private static void INRFIDInRecMsg()
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
                    length = INRFIDSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    INRFIDConn = true;
                }
                catch
                {
                    INRFIDConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (INRFIDConn))
                {
                    HandleINRFIDData(strMsg.Trim());
                }
            }
        }

        #endregion

        #region INRFID扫码器数据处理
        private static void HandleINRFIDData(string RFIDCode)//产品条码
        {
            //扫码入库
            try
            {
                SysBusinessFunction.WriteLog("入库工装板RFID【"+RFIDCode+"】");

                //根据RFID的条码查找绑定信息
                string rfidcode = RFIDCode.Trim();

                //查看是否存在RFID  堆栈中
                String ssql = String.Format(@"SELECT  * FROM IMOS_RFID_List where RFID_Code = '{0}'", rfidcode);
                DataSet sds = DataHelper.Fill(ssql);


                if (sds != null && sds.Tables[0].Rows.Count == 0)
                {
                    //没有旧rfid
                    if (oldRFID.Length == 0)
                    {
                        String psql = String.Format(@"SELECT
	                                            A.RFID_Code
                                            FROM
	                                            IMOS_Lo_Bin_Detial A
                                            WHERE A.Material_State = '0' Order By A.Create_Time");
                        DataSet pds = DataHelper.Fill(psql);
                        if (pds != null)
                        {
                            rfidcode = pds.Tables[0].Rows[0]["RFID_Code"].ToString();
                        }
                    }
                    else
                    {
                        //有旧rfid
                        ssql = String.Format(@"SELECT  * FROM IMOS_RFID_List where RFID_Code = '{0}'", oldRFID);
                        DataSet sds1 = DataHelper.Fill(ssql);
                        if (sds1 != null && sds1.Tables[0].Rows.Count != 0)
                        {
                            ssql = String.Format(@"SELECT  * FROM IMOS_RFID_List where ID = {0}", int.Parse(sds1.Tables[0].Rows[0]["ID"].ToString()) + 1);
                            DataSet sds2 = DataHelper.Fill(ssql);
                            if (sds2 != null && sds2.Tables[0].Rows.Count > 0)
                            {
                                rfidcode = sds2.Tables[0].Rows[0]["RFID_Code"].ToString();
                            }
                        }
                    }
                }

                //判断RFID是否满足规范
                //if (rfidcode.ToUpper() == "NOREAD")
                //{
                //    SysBusinessFunction.WriteLog("RFID读取失败NOREAD");
                //    //rfidcode = "99";
                //    //DownPLC("99", rfidcode);
                //    ssql = String.Format(@"SELECT  * FROM IMOS_RFID_List where RFID_Code = '{0}'", oldRFID);
                //    DataSet sds1 = DataHelper.Fill(ssql);
                //    if (sds1 != null && sds1.Tables[0].Rows.Count != 0)
                //    {
                //        ssql = String.Format(@"SELECT  * FROM IMOS_RFID_List where ID = {0}", int.Parse(sds1.Tables[0].Rows[0]["ID"].ToString()) + 1);
                //        DataSet sds2 = DataHelper.Fill(ssql);
                //        if (sds2 != null && sds2.Tables[0].Rows.Count > 0)
                //        {
                //            rfidcode = sds2.Tables[0].Rows[0]["RFID_Code"].ToString();
                //        }
                //    }

                //}
                if (rfidcode.Length != 5)
                {
                    SysBusinessFunction.WriteLog("RFID条码格式不对");
                    return;
                }
                oldRFID = rfidcode;
                String sql = String.Format(@"SELECT
                                                  A.BarCode,
                                                  A.Material_Sort,
                                                  A.Material_Code,
                                                  A.Material_Name,
	                                              B.Store_Code
                                                FROM
	                                                IMOS_Lo_Pallet  A LEFT JOIN IMOS_Lo_Task B on  A.RFID_Code = B.RFID_BarCode
                                                WHERE
	                                                A.RFID_Code = '{0}'
                                                AND A.Company_Code = '{1}'
                                                AND A.Factory_Code = '{2}'
                                                AND A.Product_Line_Code = '{3}'
                                                AND B.Task_State = '{4}'", rfidcode, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, "0");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count == 1)
                {
                    SysBusinessFunction.WriteLog("查询工装板【" + rfidcode + "】的绑定信息成功");
                    String selsql = String.Format(@"SELECT
	                                                    A.RFID_BarCode
                                                    FROM
	                                                    IMOS_Lo_Task A
                                                    LEFT JOIN IMOS_Lo_Task B ON 1 = 1
                                                    WHERE
	                                                    A.Create_Time <= B.Create_Time
                                                    AND B.RFID_BarCode = '{0}'
                                                    AND A.Task_State = '{1}'
                                                    AND B.Task_State = '{2}'
                                                    AND A.Task_Type = {3}
                                                    Order By A.Create_Time", rfidcode, "0", "0", "1");
                    DataSet mds = DataHelper.Fill(selsql);
                    if (mds != null)
                    {
                        for (int i = 0; i < mds.Tables[0].Rows.Count; i++)
                        {

                            // 更新任务数据
                            String dupdsql = String.Format(@"UPDATE IMOS_Lo_Task
                                                            SET Task_State = '{0}',
                                                             Update_Time = GETDATE()
                                                            WHERE
	                                                            RFID_BarCode = '{1}'
                                                            AND Area_Code = '{2}'
                                                            AND Task_State = '{3}' 
                                                            AND Task_Type = '{4}'", "1", mds.Tables[0].Rows[i]["RFID_BarCode"].ToString(), BaseSystemInfo.AreaCode, "0", 1);

                            DataHelper.Fill(dupdsql);
                        }
                    }
                    selsql = String.Format(@"SELECT
	                                            A.RFID_Code
                                            FROM
	                                            IMOS_Lo_Bin_Detial A
                                            LEFT JOIN IMOS_Lo_Bin_Detial B ON 1 = 1
                                            WHERE
	                                            A.Create_Time <= B.Create_Time
                                            AND B.RFID_Code = '{0}'
                                            AND A.Material_State = '{1}'
                                            AND B.Material_State = '{2}'", rfidcode, "0", "0");
                    DataSet msds = DataHelper.Fill(selsql);
                    if (msds != null)
                    {
                        for (int i = 0; i < msds.Tables[0].Rows.Count; i++)
                        {


                            // 更新任务数据
                            String updsql = String.Format(@"UPDATE IMOS_Lo_Bin_Detial SET Material_State = '{0}' Where  
                                                                RFID_Code = '{1}' 
                                                            AND Area_Code = '{2}'
                                                            AND Material_State = '{4}' ", "1", msds.Tables[0].Rows[i]["RFID_Code"].ToString(), BaseSystemInfo.AreaCode, ds.Tables[0].Rows[0]["Store_Code"].ToString(), "0");

                            DataHelper.Fill(updsql);
                        }
                    }

                    // 更新详细信息
                    DownPLC(ds.Tables[0].Rows[0]["Material_Sort"].ToString(), rfidcode);


                    SysBusinessFunction.WriteLog("执行工装板【" + rfidcode + "】的入库sql语句完成");

                }
                else
                {
                    SysBusinessFunction.WriteLog("产品条码绑定信息不存在！！执行首条任务");
                    String psql = String.Format(@"SELECT
	                                            A.RFID_Code
                                            FROM
	                                            IMOS_Lo_Bin_Detial A
                                            WHERE A.Material_State = '0' Order By A.Create_Time");
                    DataSet pds = DataHelper.Fill(psql);
                    if (pds != null)
                    {
                        if (pds.Tables[0].Rows.Count > 0)
                        {
                            DownPLC("1",pds.Tables[0].Rows[0]["RFID_Code"].ToString());
                        }
                    }
                    
                    //下传PLC不放行或者进一号货道
                    //DownPLC("99","99");
                    return;
                }


            }
            catch (Exception ex)
            {

            }
        }

      
        #endregion


        #region 以太网扫码器重连
        public static void ReINRFIDDevice(object o)//INRFID重连接
        {
            try
            {
                Thread.Sleep(5);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!INRFIDConn)
                {
                    try
                    {
                        if (INRFIDReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("入库RFID扫描设备断线重连中......，{0}", INRFIDReConnCount.ToString()));
                        }
                        INRFIDReConnCount++;
                        INRFIDSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        INRFIDSocket.Connect(INRFIDPoint);
                        INRFIDConn = true;
                        SysBusinessFunction.WriteLog(string.Format("入库RFID扫描设备重新连接成功，重连次数{0}，{1}", INRFIDReConnCount, INRFIDPoint.ToString()));
                        INRFIDReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = INRFIDSocket.Send(arrMsgRec);
                    INRFIDConn = sLen == 1;
                }
                catch
                {
                    INRFIDConn = false;
                }
            }
            catch
            {
            }
            finally
            {
                INRFIDReConnectDeviceTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion

        #region  入库放行
        private static void DownPLC(string v,string barcode)
        {
            try
            {
                //下传PLC放行
                int address = BaseSystemInfo.INRAddress;
                int block = 0;
                int len = 5;
                object[] WBuf = new object[len];
                WBuf[0] = barcode;//RFID编号
                WBuf[1] = v;      //产品代码

                WBuf[2] = 0;      //货道号(PLC 自己获取)
                WBuf[3] = 1;      //应答字
                WBuf[4] = 0;      //反馈信息
                bool flsg = ControlXPLC.WriteData(block,address,WBuf);
                if (!flsg)
                {
                    SysBusinessFunction.WriteLog("PLC下传失败");
                }
                int DownCount = GetTickCount();
                while (true)
                {
                    Thread.Sleep(5);
                    // Application.DoEvents();
                    //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                    if (GetTickCount() - DownCount > 5000) //超时处理
                    {
                        SysBusinessFunction.WriteLog("下传["+ barcode + "]入库放行信号成功，产品代号【" + v + "】等待入库放行信号超时");
                        break;
                    }

                    object[] RBuf = new object[1];
                    ControlXPLC.ReadData(0, address + 3, 1, out RBuf);
               
                    if (RBuf[0].ToString() == "2")
                    {
                        WBuf[0] = 0;
                        WBuf[1] = 0;
                        WBuf[2] = 0;
                        WBuf[3] = 0;
                        WBuf[4] = 0;
                        ControlXPLC.WriteData(block,address,WBuf);
                        SysBusinessFunction.WriteLog("下传[" + barcode + "]入库放行信号成功,产品代号【"+v+"】接受入库放行信号成功");
                        break;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region 获取入库数据
        private static void GetPLCDevice(object state)
        {
            try
            {
                Thread.Sleep(10);
                int address = BaseSystemInfo.RKWCAddress;
                int block = 0;
                int len = BaseSystemInfo.RKWCLen;
                object[] Rbuf = new object[len];
                bool result = ControlXPLC.ReadData(block,address,len,out Rbuf);
                if (result)
                {
                    for(int i = 0; i < 8; i++)
                    {
                        string rfidcode = Rbuf[i].ToString();//RFID 条码
                        if (rfidcode =="99"||rfidcode == "0")
                        {
                            continue;
                        }

                        SysBusinessFunction.WriteLog("工装板【"+rfidcode+"】接受入库货道号【" + (i+1)+ "】信号成功");

                        //String sql = String.Format(@"SELECT Area_Code,Area_Name,Store_Code,Material_Code,Material_Name,Bar_Code  
                        //                                            FROM IMOS_Lo_Task WHERE RFID_BarCode = '{0}' and Task_State = '{1}' and Area_Code = '{2}'",
                        //                                            rfidcode, "1", BaseSystemInfo.AreaCode);
                        //DataSet ds = DataHelper.Fill(sql);
                        //if (ds == null || ds.Tables[0].Rows.Count != 1)
                        //{
                        //    SysBusinessFunction.WriteLog("根据吊笼号【" + rfidcode + "】查询任务表出错！");
                        //    continue;
                        //}

                        // 更新任务数据
                        String updsql = String.Format(@"UPDATE IMOS_Lo_Task
                                                            SET Task_State = '{0}',
                                                             Update_Time = GETDATE()
                                                            WHERE
	                                                            RFID_BarCode = '{1}'
                                                            AND Area_Code = '{2}'
                                                           
                                                            AND Task_State = '{3}' 
                                                            AND Task_Type = '{4}'", "2",rfidcode,BaseSystemInfo.AreaCode,  "1",1);

                        DataHelper.Fill(updsql);
                        // 更新详细信息
                        //updsql = String.Format(@"UPDATE IMOS_Lo_Bin_Detial SET Material_State = '{0}' Where  
                        //                                        RFID_Code = '{1}' 
                        //                                    AND Area_Code = '{2}'
                        //                                    AND Store_Code = '{3}'
                        //                                    AND Material_State = '{4}' ", "2", rfidcode, BaseSystemInfo.AreaCode, ds.Tables[0].Rows[0]["Store_Code"].ToString(), "1");

                        //DataHelper.Fill(updsql);
                        String delsql = String.Format(@"DELETE From IMOS_Lo_Bin_Detial Where RFID_Code = '{0}'", rfidcode);
                        DataHelper.Fill(delsql);
                        SysBusinessFunction.WriteLog("工装板【" + rfidcode + "】入库成功，详细表删除");
                        //SysBusinessFunction.WriteLog("更新工装板【" + rfidcode + "】产品【" + ds.Tables[0].Rows[0]["Bar_Code"].ToString() + "】的任务数据，库存信息成功");
                        object[] Wbuf = new object[1];
                        Wbuf[0] = 0;
                        bool flag = ControlXPLC.WriteData(block,address+i, Wbuf);
                        if (flag)
                        {
                            //下传成功
                            SysBusinessFunction.WriteLog("【" + rfidcode + "】下传入库确认信息成功");
                        }
                        else
                        {
                                //下传失败
                            SysBusinessFunction.WriteLog("【" + rfidcode + "】下传入库确认信息失败");
                        }
                        
                    }
                }

            }
            catch(Exception ex)
            {
                
            }
            finally
            {
                GetInStoreTimer.Change(1000, Timeout.Infinite);
            }
          
        }

        #endregion

        #region 更新库存信息
         
        private static void UpdateStoreDevice(object state)
        {
           try
            {
                Thread.Sleep(10);
                int address = 190;
                int block = 0;
                int len = 40;
                object[] Rbuf = new object[len];
                bool result = ControlXPLC.ReadData(block, address, len, out Rbuf);
                if (result)
                {
                    for(int i = 0; i < 8; i++)
                    {
                        // 更新库存数据
                        String updsql = String.Format(@"UPDATE IMOS_Lo_Bin
                                                        SET Store_Qty = '{0}',
                                                         Transit_Qty = '{1}',
                                                         Full_Flag = '{2}'
                                                        WHERE
	                                                        Area_Code = '{3}'
                                                        AND Store_Code = '{4}'",
                                                        Rbuf[5*i].ToString(),Rbuf[1+5*i].ToString(),Rbuf[2+5*i].ToString(),BaseSystemInfo.AreaCode,i+1);
                        DataHelper.Fill(updsql);
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                UpdateStoreTimer.Change(2000, Timeout.Infinite);
            }

        }


        #endregion


    }
}
