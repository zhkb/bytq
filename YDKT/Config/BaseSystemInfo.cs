
using System;
using System.Management;
using System.Net;

namespace Sys.Config
{
    public class BaseSystemInfo
    {
        /// <summary>
        /// 数据库连接的字符串
        /// </summary>
        public static string ServerDbConnectionString = string.Empty;

        /// <summary>
        /// 数据库连接
        /// </summary>
        public static string ServerDbConnection = string.Empty;

        /// <summary>
        /// 业务数据库（连接串）
        /// </summary>
        public static string BusinessDbConnectionString = string.Empty;

        /// <summary>
        /// 业务数据库
        /// </summary>
        public static string BusinessDbConnection = string.Empty;


        public static string DbHelperClass = "IMOS.DbUtilities.SqlHelper";
        public static string DbHelperAssmely = "IMOS.DbUtilities";

        public static string SystemTitle = "青岛北洋天青数联智能股份有限公司";

        //系统注册标记
        public static bool RegisterFlag = true;
        public static string RegisterKey = "BYTQ2017";
        public static string RegisterFlagInfo = "BYTQ2017True";


        public static string CpuNo = "";
        public static string DiskNo = "";

        public static string RegSeq = "";

        public static string RegisterDate = "2017-05-03";

        public static string LimitDate = "2017-10-31";
        //数据库连接相关
        public static string DataBaseType = "SqlServer"; //数据库类型


        // 程序升级相关
        public static string AutoUpdateIP = "127.0.0.1";   // 程序自动更新IP地址
        public static string AutoUpdatePort = "8030";     // 程序自动更新IP端口
        public static string AutoUpdateDir = "DownLoad";
        public static string AutoExecuteName = "";        // 升级完成后自动打开的程序 默认为 IMOS.PTS.exe 
        public static int UpdateInterval = 5; //默认五分钟检查一次更新
        public static bool AutoUpdateFinish = false;     // 是否已经进行过升级
        public static bool AutoUpdateSuccess = true;       //升级是否成功 
        public static string App_Version = "1.0.0";
        public static string App_NewVersion = "1.0.0"; 

        public static string CompanyID = "1001"; //公司编码
        public static string CompanyCode = "C001"; //公司编码
        public static string CompanyName = "青岛北洋天青"; //公司名称
        public static string CompanyName_EN = "青岛北洋天青"; //公司名称

        public static string FactoryID = "2001"; //公司编码
        public static string FactoryCode = "F001"; //工厂编号 
        public static string FactoryName = "青岛北洋天青"; //工厂名称
        public static string FactoryName_EN = "青岛北洋天青"; //工厂名称

        public static string ProductLineID = "3001"; //生产线编码
        public static string ProductLineCode = "L001"; //生产线号
        public static string ProductLineName = "青岛北洋天青"; //生产线名称
        public static string ProductLineName_EN = "青岛北洋天青"; //生产线名称

        public static string CurrentUserID = "1"; //当前用户编号
        public static string CurrentUserCode = "admin"; //当前用户编号
        public static string CurrentUserName = "管理员"; //当前用户名称
        public static string CurrentUserName_EN = "Administrator"; //当前用户名称

        public static string CurrentProcessCode = "admin"; //当前用户编号
        public static string CurrentProcessName = "管理员"; //当前用户名称
        public static string CurrentProcessName_EN = "Administrator"; //当前用户名称
        public static string CurrentPlanName = "";
        public static string CurrentStationNo1 = "1";
        public static string CurrentStationNo2 = "2";
        public static string CurrentStationNo3 = "3";
        public static string CurrentStationNo4 = "4";

        public static string SerialPortName1 = "COM1";
        public static string SerialPortName2 = "COM2";
        public static string SerialPortName3 = "COM3";
        public static string SerialPortName4 = "COM4";
        public static string SerialPortName5 = "COM5";

        public static string CurrentPassword = "33";
        public static string CurrentClassCode = "1001"; //班次代码
        public static string CurrentClassName = "早班"; //班次名称
        public static string CurrentShiftCode = "1001"; //班组编码
        public static string CurrentShiftName = "A组"; //班组名称

        public static bool CurrentAdminFlag = false; //当前是否管理员



        public static int SystemType = 1; //系统类型 1 正极 2 负极
        //登录相关
        public static bool RunLogin = false;        // 登录需要验证
        public static bool RunLogout = false;        //退出需要验证

        public static bool ForcedExit = false;        //强制退出系统

        /// <summary>
        /// 主应用程序集名
        /// </summary>
        public static string MainAssembly = string.Empty;

        public static string PLCType = "1";

        public static string MasterPLCIP = "10.10.60.180";
        public static string RubberPLCIP = "10.10.60.176";
        public static string TerrinePLCIP = "10.10.60.180";
        public static string DispersePLCIP = "10.10.60.177";
        //PLC相关
        public static string WeightAddressA1 = "";
        public static string WeightAddressA2 = "";
        public static string WeightAddressB1 = "";
        public static string WeightAddressB2 = "";

        //灌注监控信息读取
        public static string MonitorAddress1 = "";
        public static string MonitorAddress2 = "";
        public static string MonitorAddress3 = "";
        public static string MonitorAddress4 = ""; 
    }
}