
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
        public static string ServerDataBaseType = "MySql"; //数据库类型

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

        public static string FactoryID = "2001"; //公司编码
        public static string FactoryCode = "F001"; //工厂编号 
        public static string FactoryName = "青岛北洋天青"; //工厂名称

        public static string ProductLineID = "3001"; //生产线编码
        public static string ProductLineCode = "L001"; //生产线号
        public static string ProductLineName = "青岛北洋天青"; //生产线名称

        public static string CurrentProcessCode = ""; //工位编号
        public static string CurrentProcessName = ""; //工位名称
        public static string CurrentProcessCode_Sec = ""; //第二工位编号
        public static string CurrentProcessName_Sec = ""; //第二工位名称

        public static string ApplicationSource = ""; //默认资源dll
        public static string ApplicationForm = ""; //默认窗体
        public static string ApplicationTitle = ""; //默认标题内容

        public static string CurrentUserID = "2"; //当前用户编号
        public static string CurrentUserCode = "admin"; //当前用户编号
        public static string CurrentUserName = "管理员"; //当前用户名称
        public static string CurrentPassword = "33";
        public static string CurrentClassCode = "101"; //班次代码
        public static string CurrentClassName = "早班"; //班次名称
        public static string CurrentShiftCode = "201"; //班组编码
        public static string CurrentShiftName = "A组"; //班组名称

        public static bool CurrentAdminFlag = false; //管理员
        


        public static int SystemType = 1; //系统类型 1 正极 2 负极
        //登录相关
        public static bool RunLogin = false;        // 登录需要验证
        public static bool RunLogout = false;        //退出需要验证

        public static bool ForcedExit = false;        //强制退出系统

        /// <summary>
        /// 主应用程序集名
        /// </summary>
        public static string MainAssembly = string.Empty;

        public static string PLCType = "1"; //1 三菱 2 西门子

        public static bool PLC_UseFlag = true; //是否启用PLC

        //PLC IP地址  用于西门子PLC
        public static string MasterPLCIP_First = "10.10.60.180";
        public static string MasterPLCIP_Sencond = "10.10.60.180";

        //PLC站点号 用于三菱PLC
        public static string MasterPLCStation_First = "1";
        public static string MasterPLCStation_Sencond = "2";

        public static string SerialPortName1 = "COM1";
        public static string SerialPortName2 = "COM2";
        public static string SerialPortName3 = "COM3";

        public static string BarScanIP_1 = "127.0.0.1";
        public static string BarScanPort_1 = "4001";

        public static string BarScanIP_2 = "127.0.0.1";
        public static string BarScanPort_2 = "4001";

        public static string BarScanIP_3 = "127.0.0.1";
        public static string BarScanPort_3 = "4001";

        public static string BarScanIP_4 = "127.0.0.1";
        public static string BarScanPort_4 = "4001";

        public static string BarScanIP_5 = "127.0.0.1";
        public static string BarScanPort_5 = "4001";

        //打印机
        public static string EnergyPrinterName1 = "一号能效贴打印机";
        public static string EnergyPrinterName2 = "二号能效贴打印机";
        public static string EnergyPrinterName3 = "三号能效贴打印机";

        public static string webServiceAddress = "";
        public static string FactoryNumber = "";

        public static string CurrentStoreCode = "";
        public static string PreviousStoreCode = "";

        //socket1
        public static string IPAddress1 = "";//ip
        public static string IPEndPoint1 = "";//端口

        //码垛机器人库位 Socket
        public static string BarScanIPA = "127.0.0.1";
        public static string BarScanPortA = "4001";

        public static string BarScanIPB = "127.0.0.1";
        public static string BarScanPortB = "4002";
    }
}