using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Threading;
using System.Runtime.InteropServices;
using BarcodeScan;

namespace ControlLogic
{
    using Communication;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    public class ControlData
    {
       

        private static SPlcLink MasterPLC = new SPlcLink(); //搅拌设备PLC
        private static SPlcLink CheckOnlinePLC = new SPlcLink(); //搅拌设备PLC
        public static bool MasterPLCPLCConn = false;//搅拌设备PLC状态

        public static int StirAlarmCount = 1000;//报警数量
         
        public static System.Threading.Timer CheckRegisterInfoTimer;  //检测系统注册信息

        public static System.Threading.Timer GetAlarmDataTimer; //读取报警信息

        public static System.Threading.Timer CheckPlcStatusTimer;  //检测PLC在线状态


        public static AlarmInfo[] StirAlarmInfo = new AlarmInfo[StirAlarmCount]; //搅拌罐报警


        public static void SystemInitialization()//初始化
        {
            //初始化PLC连接
            //MasterPLC.ActLogicalStationNumber = 1;
            //MasterPLCPLCConn = MasterPLC.Open();

            // MasterPLC = new SPlcLink();
            MasterPLC.PLCConnectionIP = BaseSystemInfo.MasterPLCIP;//PLC 地址

            SysBusinessFunction.WriteLog("1#plc" + BaseSystemInfo.MasterPLCIP);
            MasterPLC.PLCConNo = 11;
            MasterPLCPLCConn = MasterPLC.Open();


            GetAlarmList();//取得报警信息


          //  GetAlarmDataTimer = new System.Threading.Timer(GetAlarmData, null, 0, Timeout.Infinite);//取得报警信息PLC数据

            CheckPlcStatusTimer = new System.Threading.Timer(CheckPlcOnLineStatus, null, 0, Timeout.Infinite);//检测PLC在线状态timer

            CheckRegisterInfoTimer = new System.Threading.Timer(CheckRegisterInfo, null, 0, Timeout.Infinite);//查询注册信息
        }


        public static void GetAlarmData(object o)
        {
            try
            {
                GetStirAlarmData();
            }
            catch
            {

            }
            finally
            {
                GetAlarmDataTimer.Change(5000, Timeout.Infinite);
            }
        }

        public static void GetStirAlarmData()
        {
            try
            {
                #region  读取报警数据
                int DataLen = StirAlarmCount;
                int DataBlock = 98;// StirAlarmDataBlock[AIndex];
                int DataAddress = 0;// StirAlarmDataAddress[AIndex];

                object[] DataBuff = new object[DataLen];

                bool PLCRead = MasterPLC.Read(DataBlock.ToString(), DataAddress, DataLen, out DataBuff);

                if (!PLCRead)
                {
                    return;
                }

                for (int i = 0; i < StirAlarmCount; i++)
                {
                    bool AlarmFlag = (int)DataBuff[i] == 1;

                    if ((StirAlarmInfo[i].AlarmFlag != AlarmFlag) && AlarmFlag)
                    {
                        //存储报警
                        string AlarmSql = string.Format(@"Insert Into Mixing_Alarm(Company_Code, Company_Name, Factory_Code, Factory_Name, ProductLine_Code, ProductLine_Name,
                                                                                    Equipment_Type,Equipment_Code, Equipment_Name,Alarm_Desc,Create_Time)
                                                          Select '{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}',GetDate()",
                                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                          StirAlarmInfo[i].EquipmentType, StirAlarmInfo[i].EquipmentNo, StirAlarmInfo[i].EquipmentName, StirAlarmInfo[i].AlarmName);
                        DataHelper.Fill(AlarmSql);
                    }

                    if (StirAlarmInfo[i].AlarmFlag != AlarmFlag)
                    {
                        string AlarmSql = string.Format(@"UpDate Sys_Alarm Set Alarm_Flag = {0},Alarm_Time = GetDate() Where ID = {1}",
                                                      Convert.ToInt32(AlarmFlag), i + 1);
                        DataHelper.Fill(AlarmSql);
                    }
                    StirAlarmInfo[i].AlarmFlag = AlarmFlag;
                }

                #endregion
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("处理报警信息异常.异常信息：" + ex.Message);
            }
            finally
            {

            }
        }

        private static void CheckPlcOnLineStatus(object o)//检查各PLC的在线状态 离线进行重连
        {
            try
            {
                //PLC连接
                CheckOnlinePLC.Close();
                // CheckOnlinePLC.ActLogicalStationNumber = MasterPLC.ActLogicalStationNumber;
                CheckOnlinePLC.PLCConnectionIP = MasterPLC.PLCConnectionIP;
                MasterPLCPLCConn = CheckOnlinePLC.Open();
                if (!MasterPLCPLCConn) //PLC连接失败
                {
                    MasterPLC.Close();
                    MasterPLCPLCConn = MasterPLC.Open();
                }

            }
            catch
            {
            }
            finally
            {
                CheckPlcStatusTimer.Change(3000, Timeout.Infinite);
            }
        }

        public static void CheckRegisterInfo(object o) //检测系统注册信息
        {
            DataSet RegDataSet = new DataSet();
            string ServerRegStr = "";
            try
            {
                ServerRegStr = string.Format(@"select CONVERT(varchar(10),getdate(),112) NowDate,* 
                                               from Sys_Register
                                               where Company_Code = '{0}'     
                                               and Factory_Code = '{1}'  
                                               and Product_Line_Code = '{2}'   
                                               and Reg_SeqNo = '{3}'",BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode, BaseSystemInfo.RegSeq);
                RegDataSet = DataHelper.Fill(ServerRegStr);

                if (RegDataSet.Tables[0].Rows.Count == 0)
                {
                    BaseSystemInfo.RegisterFlag = false;
                }
                else
                {
                    string RegSeqNo = RegDataSet.Tables[0].Rows[0]["Reg_SeqNo"].ToString();                    
                    string RegDateStr = RegDataSet.Tables[0].Rows[0]["Register_Date"].ToString();
;                    string ServerDateStr = RegDataSet.Tables[0].Rows[0]["NowDate"].ToString();
                    string RegisterInfo = RegDataSet.Tables[0].Rows[0]["Register_Info"].ToString(); //注册信息
                    string CurrentRegisterInfo = "";
                    BaseSystemInfo.RegisterFlag = Register.RegisterFunction.CheckRegisterInfo(RegSeqNo, RegisterInfo, ServerDateStr, out CurrentRegisterInfo);

                    if (!BaseSystemInfo.RegisterFlag) //如过期则删除注册信息，强制重新注册
                    {
                        String UpStr = string.Format(@"Delete From Sys_Register 
                                                       Where Company_Code = '{0}'     
                                                       and Factory_Code = '{1}'  
                                                       and Product_Line_Code = '{2}' 
                                                       and Reg_Seq = '{3}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.RegSeq);
                        DataHelper.Fill(UpStr);
                    }
                }
            }
            catch
            {
                BaseSystemInfo.RegisterFlag = false;
            }
            finally
            {
                RegDataSet.Dispose();

                if (CheckRegisterInfoTimer != null) //在系统启动时执行一次
                {
                    CheckRegisterInfoTimer.Change(20000, Timeout.Infinite);

                }

            }
        }

        private static void GetAlarmList() //取得报警信息列表
        {
            try
            {
                string SqlStr = "";
                DataSet AlarmDataSet = new DataSet();

                SqlStr = string.Format(@"SELECT * FROM sys_BaseAlarm Order By Alarm_ID");

                AlarmDataSet = DataHelper.Fill(SqlStr);

                for (int i = 0; i < AlarmDataSet.Tables[0].Rows.Count; i++)//i是查到的数据条数
                {
                    DataRow dr = AlarmDataSet.Tables[0].Rows[i];

                    ControlData.StirAlarmInfo[i].AlarmName = dr["Alarm_Desc"].ToString();

                }
            }
            catch (Exception ex)
            {
              //  SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询动作数据失败，请检查数据库连接.");
            }
            finally
            {

            }
        }



        public static void SystemInitSerialPortLiner()//初始化
        {
            //内胆条码扫描 //Liner 内胆
            InitScanner();
            CheckConnectionTimer = new System.Threading.Timer(CheckConnectionStatus, null, 0, Timeout.Infinite);//条码扫描设备重连
        }

        private static ScanProvider _scanner;
        public static bool BarScanConn = false; //条码扫描设备连接状态
        private static int HisReceiveCount = 0;
        private static int ReceiveCount = 0;
        private static int BarScanReConnCount = 0;
        public static System.Threading.Timer CheckConnectionTimer;  //检查设备连接状态Timer

        private static void InitScanner()
        {
            try
            {
                //打开串口  
                _scanner = new ScanProvider(BaseSystemInfo.PortName, 9600);
                Task task = new Task(() =>
                {
                    //打开串口  
                    if (_scanner.Open())

                        _scanner.DataReceived += sp_DataReceived;
                });
                task.Start();
            }
            catch (Exception ex)
            {
                string TipInfo = string.Format("条码枪连接出现异常.端口【{0}】波特率【{1}】，{2}", BaseSystemInfo.PortName, 9600, ex.Message);
                SysBusinessFunction.WriteLog(TipInfo);
            }
        }
        private static void sp_DataReceived(object sender, SerialSortEventArgs e)
        {
            string g_s_Data = "";
            try
            {

                g_s_Data = e.Code;
                if (g_s_Data.Length > 0)
                {
                    BarScanConn = true;
                    string code = g_s_Data.Trim();//获取条码
                    SysBusinessFunction.WriteLog(string.Format("读取条码{0}成功:", code));
                    string code2 = code; //内胆码
                    string subCode = code.Substring(0, 1);//截取条码用于判断读取到的是RFID还是条码
                    //if (subCode == "B" && code.Length == 8)
                    if (code.Length == 6)
                    {
                        OptionSetting.ToolingBoardRFID = code;
                        OptionSetting.CodeMsg = "读取内胆条码成功";
                        SysBusinessFunction.WriteLog(string.Format("读取内胆条码{0}成功！", code));
                        OptionSetting.isSuccessFlag = "1";
                    }
                    else
                    {


                    }

                }
                else
                {
                    OptionSetting.CodeMsg = "读取条码信息失败，请重新读取！";
                    SysBusinessFunction.WriteLog(string.Format("读取条码信息失败，请重新读取！"));
                    OptionSetting.isSuccessFlag = "0";
                }


            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("error:接收返回消息异常！具体原因：" + ex.Message);
            }
        }


        private static void CheckConnectionStatus(object o)//PLC和条码扫描设备重连
        {
            try
            {
                Thread.Sleep(5);
                HisReceiveCount = ReceiveCount;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!BarScanConn)
                {
                    try
                    {
                        if (BarScanReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", BaseSystemInfo.PortName));
                        }
                        BarScanReConnCount++;
                        _scanner.Open();
                        BarScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", BarScanReConnCount));
                        BarScanReConnCount = 0;
                    }
                    catch (Exception ex)
                    {
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连异常:{0}", ex.Message));
                    }
                }
                #endregion
            }
            catch
            {
            }
            finally
            {
                CheckConnectionTimer.Change(10000, Timeout.Infinite);
            }
        }



    }
}
