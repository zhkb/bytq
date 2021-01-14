using Communication;
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
/// <summary>
/// 产品上线下线 焊接
/// </summary>
namespace ControlLogic.Control
{
   
  public  class ControlQualityData
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        #region  变量
     
        //条码
        public static bool ScanConnOne = false; //扫描设备连接状态
        public static bool BarScanStateOne = false; //条码扫描是否正常
        private static Thread ScanSocketThreadOne = null; // 创建用于接收服务端消息的 
        private static Socket ScanSocketOne = null;
        private static IPEndPoint ScanPointOne;
        private static int ScanReConnCountOne = 0;
        public static bool SerialPortStatusOne = false;
        private static int HisReceiveCountOne = 0;
        private static int ReceiveCountOne = 0;
        public static System.Threading.Timer CheckConnectionTimerOne;  //检查设备ONE连接状态Timer

        #endregion


        #region 初始化
        public static void SystemInitialization()//初始化
        {
            if (ConfigHelper.GetValue("IsInitBarOne") == "1")
            {
                InitOne();
                CheckConnectionTimerOne = new System.Threading.Timer(CheckConnectionStatusOne, null, 0, Timeout.Infinite);//以太网产品码扫码器
            }

        }

        #endregion

        #region 条码相关操作

        #region 初始化
        private static void InitOne()
        {
            IPAddress SanIPOne = IPAddress.Parse(ConfigHelper.GetValue("IntelligentDeviceIP1"));//IP
            ScanPointOne = new IPEndPoint(SanIPOne, int.Parse(ConfigHelper.GetValue("IntelligentDevicePort1")));//端口
            ScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocketOne.Blocking = true;
            try
            {
                ScanSocketOne.Connect(ScanPointOne);
                ScanConnOne = true;
            }
            catch (SocketException ex)
            {
                ScanConnOne = false;
                string TipInfo = string.Format("条码扫描设备连接出现异常.IP地址{0}端口{1}，", SanIPOne, ScanPointOne);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            ScanSocketThreadOne = new Thread(ScanRecMsgOne);
            ScanSocketThreadOne.IsBackground = true;
            ScanSocketThreadOne.Start();
        }
        #endregion

        #region 重连
        private static void CheckConnectionStatusOne(object o)
        {
            try
            {
                Thread.Sleep(5);
                SerialPortStatusOne = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCountOne = ReceiveCountOne;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!ScanConnOne)
                {
                    try
                    {
                        if (ScanReConnCountOne == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", ScanPointOne.ToString()));
                        }
                        ScanReConnCountOne++;
                        ScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocketOne.Blocking = true;
                        ScanSocketOne.Connect(ScanPointOne);
                        ScanConnOne = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", ScanReConnCountOne, ScanPointOne.ToString()));
                        ScanReConnCountOne = 0;
                    }
                    catch (SocketException ex)
                    {
                    }
                }

                try
                {
                    int sLen = ScanSocketOne.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConnOne = sLen == 1;
                }
                catch
                {
                    ScanConnOne = false;
                }
                #endregion

            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimerOne.Change(10000, Timeout.Infinite);
            }
        }

        #endregion


        #region 数据获取
        public static void ScanRecMsgOne()
        {
            try
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
                        length = ScanSocketOne.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConnOne = true;
                    }
                    catch
                    {
                        //  SysBusinessFunction.WriteLog("产品码扫码器心跳信息号失败.");
                        ScanConnOne = false;
                        continue;
                    }

                    if ((strMsg.Trim().Length > 0) && (ScanConnOne) && strMsg.Trim() != "NO READ")
                    {
                        string code = strMsg.Trim();//获取条码
                        OptionSetting.BarCode = code;
                        BarCodeOneDataHandle(code);

                    }
                    else
                    {
                        OptionSetting.Msg = "读取产品码失败！";
                        //OptionSetting.ScanFlag = false;
                        SysBusinessFunction.WriteLog(string.Format("读取产品码失败！"));
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("产品码异常", ex.ToString()));
            }
        }




        #endregion


        #endregion

        #region 逻辑相关操作
        private static void BarCodeOneDataHandle(string code)
        {
            try
            {
                SysBusinessFunction.WriteLog(string.Format("产品条码【{0}】", code));
                if (code.Length > 5)
                {
                    DataSet ds = new DataSet();
                    string sMaterialCode = code.Substring(0, 5).Trim();//可扩展 条码前五位是物料编码
                    string SqlStr = string.Format(@" select Material_ID,Material_Code,Material_Name,Material_Type_Code,Material_Type_Name from IMOS_TA_Material where Material_Code='{0}'
                               ", sMaterialCode
                              );
                    ds = DataHelper.Fill(SqlStr);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        string MCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                        string MName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        string MaterialTypeCode = ds.Tables[0].Rows[0]["Material_Type_Code"].ToString();
                        string MaterialTypeName = ds.Tables[0].Rows[0]["Material_Type_Name"].ToString();

                        OptionSetting.MCode = MCode;
                        OptionSetting.MName = MName;

                        EditPRQuality(code, MCode, MName, MaterialTypeCode, MaterialTypeName);



                    }
                    else {         
                        OptionSetting.Msg = "未获取产品信息";
                        SysBusinessFunction.WriteLog(string.Format("未获取产品信息"));
                    }





                }
            }
            catch (Exception ex) {

            }
          
        }

        private static void EditPRQuality(string code, string mCode, string mName,string MaterialTypeCode,string MaterialTypeName)
        {
            try
            {
                //查询是否有记录
                DataSet ds = new DataSet();
                string SqlStr = string.Format(@" select ID from IMOS_PR_QualityResult where Product_BarCode='{0}' 
                               ", code
                          );
                ds = DataHelper.Fill(SqlStr);
                int Check_Result = 0;
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    //以获取记录 更新
                    Check_Result = int.Parse(ds.Tables[0].Rows[0]["Check_Result"].ToString());
               

                }
             
                 
             

                //PLC数据下传
                int DataAddress = 11;
                int DataBlock = 0;
                object[] BackBuff = new object[2];
                BackBuff[0] = 2;//下传PLC存储称重信息完成标志2        
                BackBuff[1] = Check_Result; //下传PLC称重是否合格标记      
                bool PLCWrite = ControlData.MasterPLC.Write(DataBlock, DataAddress, BackBuff);
                int Result = 0;
                if (Check_Result == 1&& PLCWrite)
                {

                    Result= OptionSetting.Check_Result = 1;
                 
                    OptionSetting.Msg = code + "验证成功";
                    SysBusinessFunction.WriteLog(string.Format("【{0}】验证成功", code));
                }
                else
                {
                    Result= OptionSetting.Check_Result = 0;
                    OptionSetting.Msg = code + "结果失败";
                    SysBusinessFunction.WriteLog(string.Format("【{0}】结果失败", code));
                }
                //插入数据记录
            
                    // string ID = Guid.NewGuid().ToString("N");
                    //未获取记录 插入
                    string sql = string.Format(@"insert into IMOS_PR_Quality(Company_Code,Company_Name,Factory_Code,Factory_Name,Product_Line_Code,Product_Line_Name,Product_BarCode,Material_Code,Material_Name,Material_Type_Code,Material_Type_Name,Process_Code,Process_Name,Station_No,Scan_Time,Shift_Name,Use_Flag,Creation_Date,Created_By,Check_Result) 
                                                    VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',GETDATE(),'{14}','{15}',GETDATE(),'{16}',{17}); ",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName,
                                                BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName, code, mCode, mName, MaterialTypeCode,
                                                MaterialTypeName, BaseSystemInfo.CurrentProcessCode, BaseSystemInfo.CurrentProcessName, BaseSystemInfo.CurrentStationNo1, BaseSystemInfo.CurrentShiftName, '1', BaseSystemInfo.CurrentUserName, Result);
                    DataHelper.Fill(sql);
                    OptionSetting.ScanTime = DateTime.Now.ToString();
                    SysBusinessFunction.WriteLog(string.Format("【{0}】数据记录添加成功PLC状态【{1}】,质检结果【{2}】", code, Result, Check_Result));
              
                OptionSetting.TaktTimeFlag = true;

            }   
            catch (Exception ex) {
               
                OptionSetting.Msg = code+"信息记录失败";
                SysBusinessFunction.WriteLog(string.Format("【{0}】失败，异常信息：{1}", code,ex.ToString()));
            }
         


            
        }
        #endregion


    }
}
