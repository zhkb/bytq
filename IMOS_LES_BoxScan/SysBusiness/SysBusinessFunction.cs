using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Security.Cryptography;
using System.Management;
using System.Data;
using System.Data.OracleClient;

namespace Sys.SysBusiness
{
    using Sys.Config;
    using Sys.DbUtilities;

    #region 实时监控数据
    public class MonitorInfo
    {
        public object OBJ4Lock = new object();
        //主轴电机
        public int ZZDJ_Status;//状态 0 停止，1启动
        public int ZZDJ_RPMSet;//设定转速
        public int ZZDJ_RealRPM;//实际转速
        public float ZZDJ_OperTemp;//工作温度
        public float ZZDJ_OperCurr;//工作电流
        //给料泵
        public int GLB_Status;//状态 0 停止，1启动
        public float GLB_FlowSet;//设定流量
        public float GLB_RealFlow;//实际流量
        //控制器
        public float KZQ_OperTemp;//工作温度
        public int KZQ_MotorTorque;//电机扭矩
        //缓冲罐
        public int HCG_Status;//状态 0 停止，1启动
        public int HCG_RPMSet;//设定转速
        public int HCG_RealRPM;//实际转速
        public float HCG_Temper;//温度
        public float HCG_LiquidLeve;//液位
        //浆料
        public float JL_FeedTemp;//进料温度
        public float JL_PrecoolTemp;//预冷温度
        public float JL_DischargeTemp;//出料温度
        public float JL_BufferTemp;//缓冲温度
        public float JL_GasChannelPress;//气路压力
        public float JL_DispersePress;//分散压力
        //常温冷却水
        public float CWLQS_MotorInfluTemp;//电机进水温度
        public float CWLQS_MotorEffluTemp;//电机回水温度
        public float CWLQS_DriverInfluTemp;//驱动器进水温度
        public float CWLQS_DriverEffluTemp;//驱动器回水温度
        public float CWLQS_SpindleInfluTemp;//主轴进水温度
        public float CWLQS_SpindleEffluTemp;//主轴回水温度
        //低温冷却水
        public float DWLQS_PrecoolInfluTemp;//预冷进水温度
        public float DWLQS_DischargePortInfluTemp;//出料口进水温度
        public float DWLQS_ScatterBarrelInfluTemp;//分散桶进水温度
        public float DWLQS_BufferTankInfluTemp;//缓冲罐进水温度
        public float DWLQS_PrecoolEffluTemp;//预冷回水温度
        public float DWLQS_DischargePortEffluTemp;//出料口回水温度
        public float DWLQS_ScatterBarrelEffluTemp;//分散桶回水温度
        public float DWLQS_BufferTankEffluTemp;//缓冲罐回水温度
        //分散参数数据
        public int FSCS_MasterInverterCoolWaterStatus;//主变频冷却水状态
        public int FSCS_MasterMotorCoolWaterStatus;//主电机冷却水状态
        public int FSCS_PasteFlowSwitch;//浆料流动开关
        public int FSCS_FeedMotorLock;//给料电机互锁
        public int FSCS_ScatterDuration;//分散时间
        public float FSCS_LineSpeed;//线速度
        public float FSCS_CoolInfluPress;//冷却水进水压力
        public float FSCS_CoolEffluPress;//冷却水回水压力
        public float FSCS_NormInfluPress;//常温水进水压力
        public float FSCS_NormEffluPress;//常温水回水压力
        public float FSCS_GasSealPress;//气密封气压力
        public float FSCS_DisperseCavityPress;//分散腔压力
        public float FSCS_GasSealDiffPressSet;//气密封压差设定值
    }
    #endregion

    #region 门体信息
    public struct DoorInfo
    {
        public int qty;
        public string DoorCode;
        public string DoorName;
    }
    #endregion

    public class SysBusinessFunction
    {
        public static int DialogAskMessage = 1;
        public static int DialogOKMessage = 2;
        public static int DialogYesNoMessage = 3;

        public static int OrderNewStatus = 1; //订单状态 新订单
        public static int OrderLineStatus = 2;//订单状态 生产线
        public static int OrderGroupStatus = 3;//订单状态 组盘完成

        public static int LineNoExcute = 0; //订单产线状态 未执行
        public static int LineExcuteing = 1;//订单产线状态 执行中
        public static int LineFinish = 2;//订单产线状态 完成
        public static int LinePause = 3;//订单产线状态 暂停
        public static int LineForce = 9;//订单产线状态 强制结束

        public static bool DBConn = false; //本地数据库连接状态
        public static bool ServerDBConn = false; //服务器数据库连接状态

        public static bool DataBaseStatus = false;
        public static bool HisDataBaseStatus = true;
        public static bool DBFlag = false;

        public static string HisCount = "";
        public static string NewCount = "";

        public static System.Threading.Timer CheckDBConnectionTimer;  //查看数据库连接
        public static System.Threading.Timer DisplayAlarmTimer; //刷新报警信息

        public static bool TipVisible = false; //是否显示信息提示
        public static string TipInfo = ""; //提示信息内容

        public static Color[] AlarmColor = { Color.Lime, Color.Red };
        public static Color[] MainTainColor = { Color.Lime, Color.Yellow };

        private static int AlarmSEQNum = 0;

        public static readonly Encoding Encoding = Encoding.GetEncoding("UTF-8");

        public static Color[] ViewBackColor = { Color.White, Color.LightCyan, Color.Lime }; //列表间隔颜色

        public static MonitorInfo MonitorInfoInstance = new MonitorInfo();//实时监控数据


   
        public static void CreateCheckDBConnection()//判断数据库连接状态
        {
            CheckDBConnectionTimer = new System.Threading.Timer(CheckDBConnectionStatus, null, 0, Timeout.Infinite);
        }

        public static void CheckDBConnectionStatus(object o)
        {
            try
            {
                SysBusinessFunction.CheckDataBaseStatus();
            }
            finally
            {
                CheckDBConnectionTimer.Change(20000, Timeout.Infinite);
            }
        }

        public static string BinaryToStr(int num)
        {
            string BinaryStr = Convert.ToString(num, 2);

            for (int i = BinaryStr.Length; i < 16; i++)
            {
                BinaryStr = "0" + BinaryStr;
            }

            System.Text.RegularExpressions.CaptureCollection cs =
            System.Text.RegularExpressions.Regex.Match(BinaryStr, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Default.GetString(data, 0, data.Length).Replace("\0", "");
        }

        public static void OperationInfoAdd(string OperInfo) //增加操作信息提示
        {
            try
            {
                string InfoStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + OperInfo;
                OptionSetting.OperationInfoList.Insert(0, InfoStr);

                //最大显示最新的10条提示信息 多余的数据进行删除
                for (int i = 20; i < OptionSetting.OperationInfoList.Count; i++)
                {
                    OptionSetting.OperationInfoList.RemoveAt(i);
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("增加业务日志信息异常。");
            }
        }

        public static void OperationAlarmAdd(string OperInfo) //增加操作异常信息提示
        {
            try
            {
                string InfoStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + OperInfo;
                OptionSetting.OperationAlarmList.Insert(0, InfoStr);

                //最大显示最新的10条提示信息 多余的数据进行删除
                for (int i = 20; i < OptionSetting.OperationAlarmList.Count; i++)
                {
                    OptionSetting.OperationAlarmList.RemoveAt(i);
                }
            }
            catch
            {
            }
        }

        public static void OperationTipsAdd(string OperInfo) //增加操作信息提示 包含异常和正常信息 方便设备监控界面进行相应的信息提示
        {
            try
            {
                string InfoStr = DateTime.Now.ToString("HH:mm:ss") + " " + OperInfo;

                OptionSetting.OperationTipsList.Insert(0, InfoStr);

                //最大显示最新的10条提示信息 多余的数据进行删除
                for (int i = 10; i < OptionSetting.OperationTipsList.Count; i++)
                {
                    OptionSetting.OperationTipsList.RemoveAt(i);
                }
            }
            catch
            {

            }

        }

        public static void WriteLog(string LogTxt) //记录日志
        {
            try
            {
                System.IO.File.AppendAllText(Application.StartupPath + "\\RunLog\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + LogTxt + "\r\n", System.Text.Encoding.Default);
            }
            catch
            {
            }
        }

        public static DialogResult SystemDialog(int DialogType, string InfoTxt) //系统提示框 DialogType 1 确定、取消 2 确定 3 是、否
        {
            try
            {
                FrmDialog DialogForm = new FrmDialog();
                DialogForm.DialogType = DialogType;
                DialogForm.InfoTxt = InfoTxt;
                DialogResult r = DialogForm.ShowDialog();
                DialogForm.Dispose();
                return r;
            }
            catch
            {
                return DialogResult.Cancel;
            }
        }

        public static bool CheckDataBaseStatus()
        {
            try
            {
                Thread.Sleep(5);

                if (BaseSystemInfo.DataBaseType == "Oracle")
                {
                    DataHelper.Fill("select sysdate from dual");
                }
                else
                {
                    DataHelper.Fill("select getdate()");
                }

                DataBaseStatus = true;

                if ((DataBaseStatus != HisDataBaseStatus) && (!HisDataBaseStatus))
                {
                    SysBusinessFunction.WriteLog("数据库重新连接成功.....");
                    SysBusinessFunction.OperationInfoAdd("数据库重新连接成功.....");
                    DataHelper.RefreshDBConn();
                }
                HisDataBaseStatus = DataBaseStatus;
                NewCount = DateTime.Now.ToString("yyyyMMddHHmmss"); //

                return true;
            }
            catch
            {
                HisDataBaseStatus = false;

                return false;
            }
        }


        /// 密码加密
        public static string HashPassword(string password)
        {
            using (var hasher = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hashedPwd = hasher.ComputeHash(Encoding.GetBytes(password));
                password = Convert.ToBase64String(hashedPwd).ToUpper();
            }
            return password;
        }

        public static bool DownloadFile(string URL, string filename)
        {
            float percent = 0;
            try
            {

                System.Net.HttpWebRequest FMyrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);

                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)FMyrq.GetResponse();
                long totalBytes = myrp.ContentLength;

                System.IO.Stream st = myrp.GetResponseStream();

                System.IO.Stream so = new System.IO.FileStream(@Application.StartupPath + "\\" + filename, System.IO.FileMode.Create);

                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    Application.DoEvents();
                    so.Write(by, 0, osize);

                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (int)totalDownloadedByte / (int)totalBytes * 100;
                    double ww = Math.Ceiling(1.25);

                    Application.DoEvents();
                }
                so.Close();
                st.Close();
                return true;
            }
            catch (System.Exception)
            {

                Thread.Sleep(5);
                return false;
                //throw;
            }
        }

        public static string GetCpuSerial() //取得CPU序列号
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        public static string GetDiskSerial()//取得设备硬盘的卷标号
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        public static int GetSEQ(string SEQName) //按照序列名称取得相应的序列号
        {
            DataSet SEQDataSet = new DataSet();
            string SEQStr = "SELECT " + SEQName + ".NEXTVAL from DUAL";
            SEQDataSet = DataHelper.Fill(SEQStr);

            if (SEQDataSet.Tables[0].Rows.Count > 0)
            {
                int SEQNum = int.Parse(SEQDataSet.Tables[0].Rows[0]["NEXTVAL"].ToString());
                return SEQNum;
            }
            else
            {
                return 1;
            }
        }
        public static bool ExeuteCreateBarCodeProduce(string FactoryCode, string OrderNo, string OrderType)
        {
            string BackResult = "";
            try
            {
                OracleParameter[] values = {
                                           new OracleParameter("IN_SITE_NUM",FactoryCode),
                                           new OracleParameter("IN_ORDER_NO", OrderNo),
                                           new OracleParameter("IN_ORDER_TYPE",OrderType),
                                           new OracleParameter("V_ERR","0"),
                                           new OracleParameter("V_ERR_DESC",""),
                                       };
                values[0].Direction = ParameterDirection.Input;
                values[1].Direction = ParameterDirection.Input;
                values[2].Direction = ParameterDirection.Input;
                values[3].Direction = ParameterDirection.Output;
                values[4].Direction = ParameterDirection.Output;

                values[0].OracleType = OracleType.VarChar;
                values[1].OracleType = OracleType.VarChar;
                values[2].OracleType = OracleType.VarChar;
                values[3].OracleType = OracleType.Int32;
                values[4].OracleType = OracleType.VarChar;

                values[0].Size = 4000;
                values[1].Size = 4000;
                values[2].Size = 4000;
                values[3].Size = 1000;
                values[4].Size = 4000;


                int resultDb = DataHelper.ExecuteProcedure("IMOS_MOM_CREATE_BARCODE", values);
                //输出参数
                //string a = values[3].Value.ToString();
                BackResult = Convert.ToString(values[4].Value);

            }
            catch(Exception ex)
            {

            }
            return BackResult == "S";
        }
        //三菱获取双字方法
        public static float GetFloat(ushort P1, ushort P2)
        {
            int intSign, intSignRest, intExponent, intExponentRest;
            float faResult, faDigit; intSign = P1 / 32768;
            intSignRest = P1 % 32768;
            intExponent = intSignRest / 128;
            intExponentRest = intSignRest % 128;
            faDigit = (float)(intExponentRest * 65536 + P2) / 8388608;
            faResult = (float)Math.Pow(-1, intSign) * (float)Math.Pow(2, intExponent - 127) * (faDigit + 1);
            return faResult;

        }

    }



}
