using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace ControlLogic.Control
{
    using Communication;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    public class ControlAlarmData
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        public static int StirAlarmCount = 500;//报警数量

        public static System.Threading.Timer GetAlarmDataTimer; //读取报警信息

        public static AlarmInfo[] StirAlarmInfo = new AlarmInfo[StirAlarmCount];

        public static void SystemInitialization()//初始化
        {
            GetAlarmList();
            GetAlarmDataTimer = new System.Threading.Timer(GetAlarmData, null, 0, Timeout.Infinite);//读取报警信息
        }

        private static void GetAlarmList() //取得报警信息列表
        {
            try
            {
                string SqlStr = "";
                DataSet AlarmDataSet = new DataSet();

                SqlStr = string.Format(@"SELECT ID,Alarm_Desc,isnull(Equipment_Type,0) Equipment_Type,Equipment_Code,Equipment_Name,Alarm_Flag,Alarm_No FROM Sys_Alarm Order By ID");

                AlarmDataSet = DataHelper.Fill(SqlStr);

                for (int i = 0; i < AlarmDataSet.Tables[0].Rows.Count; i++)//i是查到的数据条数
                {
                    DataRow dr = AlarmDataSet.Tables[0].Rows[i];
                    StirAlarmInfo[i].AlarmID = dr["ID"].ToString();
                    StirAlarmInfo[i].AlarmNo = dr["Alarm_No"].ToString();
                    StirAlarmInfo[i].AlarmName = dr["Alarm_Desc"].ToString();
                    StirAlarmInfo[i].AlarmFlag = dr["Alarm_Flag"].ToString() == "1"; // 是否报警状态

                    StirAlarmInfo[i].EquipmentType = int.Parse(dr["Equipment_Type"].ToString());
                    StirAlarmInfo[i].EquipmentCode = dr["Equipment_Code"].ToString();
                    StirAlarmInfo[i].EquipmentName = dr["Equipment_Name"].ToString();

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "获取报警列表失败.");
                SysBusinessFunction.WriteLog(ex.ToString());
            }
            finally
            {

            }
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
                GetAlarmDataTimer.Change(1000, Timeout.Infinite);
            }
        }

        public static void GetStirAlarmData()
        {
            try
            {
                #region  读取报警数据
                int DataLen = 0;
                int remainder = 0;
                int DataBlock = 100;// StirAlarmDataBlock[AIndex];
                int DataAddress = 0;// StirAlarmDataAddress[AIndex];

                Boolean[] PlcAlarmFlag = new Boolean[StirAlarmCount];

                remainder = StirAlarmCount % 16;
                if(remainder == 0)
                {
                    DataLen = StirAlarmCount / 16;
                }
                else if(remainder > 0)
                {
                    DataLen = (StirAlarmCount / 16) + 1;
                }

                object[] DataBuff = new object[DataLen];

                bool PLCRead = ControlMaster.ReadData(DataBlock, DataAddress, DataLen, out DataBuff);

                if (!PLCRead)
                {
                    return;
                }

 //               PlcAlarmFlag[0] = ((int)DataBuff[0] & OptionSetting.BinArray[0]) == OptionSetting.BinArray[0];
                int k = 0;
                for (int j = 0 ;  j < DataLen ; j++)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if(k < StirAlarmCount)
                        {
                            PlcAlarmFlag[k] = ((int)DataBuff[j] & OptionSetting.BinArray[i]) == OptionSetting.BinArray[i];
                            UpDateStirAlarmData(PlcAlarmFlag[k], k);
                            k++;
                        }
                        else if(k >= StirAlarmCount)
                        {
                            break;
                        }
                    }
                }
/*                for (int i = 0; i < StirAlarmCount; i++)
                {
                    //                   bool AlarmFlag = (int)DataBuff[i] == 1;
                    //                   if (StirAlarmInfo[i].AlarmFlag != AlarmFlag)
                    bool AlarmFlag = PlcAlarmFlag[i];
                                        
                    if (StirAlarmInfo[i].AlarmFlag != AlarmFlag)
                    {
                        string UpdateAlarmSql = string.Format(@"UpDate Sys_Alarm Set Alarm_Flag = {0},Alarm_Time = GetDate() Where ID = {1}",
                                                        Convert.ToInt32(AlarmFlag), StirAlarmInfo[i].AlarmID);
                        DataHelper.Fill(UpdateAlarmSql);

                        if (AlarmFlag) //如是报警状态 进行新纪录的记录并生成报警编号 GUID
                        {
                            string AlarmNo = Guid.NewGuid().ToString("N");
                            //存储报警
                            string AlarmSql = string.Format(@"Insert Into IMOS_TA_AlarmLog(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                    Equipment_Type,Equipment_Code, Equipment_Name,Alarm_Desc,Alarm_No,Create_Time)
                                                              Select '{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}','{10}',GetDate()",
                                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                              StirAlarmInfo[i].EquipmentType, StirAlarmInfo[i].EquipmentCode, StirAlarmInfo[i].EquipmentName, StirAlarmInfo[i].AlarmName, AlarmNo);
                            DataHelper.Fill(AlarmSql);

                            string UpdateAlarmSql1 = string.Format(@"UpDate Sys_Alarm Set Alarm_No = '{0}' Where ID = {1}", AlarmNo, StirAlarmInfo[i].AlarmID);

                            DataHelper.Fill(UpdateAlarmSql1);
                            StirAlarmInfo[i].AlarmNo = AlarmNo;
                        }
                        else //报警清除
                        {
                            string ClearAlarmSql = string.Format(@"UpDate IMOS_TA_AlarmLog Set Clear_Time = GetDate(),Alarm_No ='' Where Alarm_No = '{0}'", StirAlarmInfo[i].AlarmNo);
                            DataHelper.Fill(ClearAlarmSql);

                            StirAlarmInfo[i].AlarmNo = "";
                        }
                    }

                    StirAlarmInfo[i].AlarmFlag = AlarmFlag;
                }*/

                #endregion
            }
            catch (Exception ex)
            {
//                SysBusinessFunction.WriteLog("处理报警信息异常.异常信息：" + ex.Message);
            }
            finally
            {

            }
        }

        public static void UpDateStirAlarmData(bool flag ,int row_no)
        {
            try
            {
                bool AlarmFlag = flag;

                if (StirAlarmInfo[row_no].AlarmFlag != AlarmFlag)
                {
                    string UpdateAlarmSql = string.Format(@"UpDate Sys_Alarm Set Alarm_Flag = {0},Alarm_Time = GetDate() Where ID = {1}",
                                                    Convert.ToInt32(AlarmFlag), StirAlarmInfo[row_no].AlarmID);
                    DataHelper.Fill(UpdateAlarmSql);

                    if (AlarmFlag) //如是报警状态 进行新纪录的记录并生成报警编号 GUID
                    {
                        string AlarmNo = Guid.NewGuid().ToString("N");
                        //存储报警
                        string AlarmSql = string.Format(@"Insert Into IMOS_TA_AlarmLog(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                    Equipment_Type,Equipment_Code, Equipment_Name,Alarm_Desc,Alarm_No,Create_Time)
                                                              Select '{0}','{1}','{2}','{3}','{4}','{5}',{6},'{7}','{8}','{9}','{10}',GetDate()",
                                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                          StirAlarmInfo[row_no].EquipmentType, StirAlarmInfo[row_no].EquipmentCode, StirAlarmInfo[row_no].EquipmentName, StirAlarmInfo[row_no].AlarmName, AlarmNo);
                        DataHelper.Fill(AlarmSql);

                        string UpdateAlarmSql1 = string.Format(@"UpDate Sys_Alarm Set Alarm_No = '{0}' Where ID = {1}", AlarmNo, StirAlarmInfo[row_no].AlarmID);

                        DataHelper.Fill(UpdateAlarmSql1);
                        StirAlarmInfo[row_no].AlarmNo = AlarmNo;
                    }
                    else //报警清除
                    {
                        string ClearAlarmSql = string.Format(@"UpDate IMOS_TA_AlarmLog Set Clear_Time = GetDate(),Alarm_No ='' Where Alarm_No = '{0}'", StirAlarmInfo[row_no].AlarmNo);
                        DataHelper.Fill(ClearAlarmSql);

                        StirAlarmInfo[row_no].AlarmNo = "";
                    }
                }

                StirAlarmInfo[row_no].AlarmFlag = AlarmFlag;
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("处理报警信息异常.异常信息：" + ex.Message);
            }
            finally
            {

            }
        }
    }
}
