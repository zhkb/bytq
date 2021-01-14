
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

        public static string FactoryID = "2001"; //公司编码
        public static string FactoryCode = "F001"; //工厂编号 
        public static string FactoryName = "青岛北洋天青"; //工厂名称

        public static string ProductLineID = "3001"; //生产线编码
        public static string ProductLineCode = "L001"; //生产线号
        public static string ProductLineName = "青岛北洋天青"; //生产线名称
        //工序
        public static string CurrentProcessCode = "admin"; //当前用户编号
        public static string CurrentProcessName = "管理员"; //当前用户名称
        public static string CurrentProcessName_EN = "Administrator"; //当前用户名称

        public static string StationCode = "1"; //工位


        public static string CurrentStationNo = ""; //
        public static string CurrentUserID = "1"; //当前用户编号
        public static string CurrentUserCode = "admin"; //当前用户编号
        public static string CurrentUserName = "管理员"; //当前用户名称
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

        public static int MenuCount = 10; //菜单数量 固定为10个 后续可根据项目进行更改 但建议不要放在配置文件中
        public static string[] MenuName;
        public static string[] MenuSourve;
        public static string[] MenuForm;
        public static bool[] MenuVisible;

        public static int BtnWidth = 130;//菜单按钮宽度
        public static int BtnHeight = 60;//菜单按钮高度


        
        /// <summary>
        /// 主应用程序集名
        /// </summary>
        public static string MainAssembly = string.Empty;

        public static string PLCType = "1";
        public static string MasterPLCStation = "1";

        public static string MasterPLCIP = "10.10.60.180";
        public static string RubberPLCIP = "10.10.60.176";
        public static string TerrinePLCIP = "10.10.60.180";
        public static string DispersePLCIP = "10.10.60.177";

        public static string BarScanIP = "127.0.0.1";//扫码器IP
        public static string BarScanPort = "2112";//扫码器端口号

        public static string BarScanProIP = "127.0.0.1";//产品扫码器IP
        public static string BarScanProPort = "2112";//产品扫码器端口号

        public static string BarScanComIP = "127.0.0.1";//压缩机扫码器IP
        public static string BarScanComPort = "2113";//压缩机扫码器端口号



        public static string BarScanOneIP = "127.0.0.1";//一号工位扫码器IP
        public static string BarScanOnePort = "2000";// 一号工位扫码器端口号      
        public static string BarScanTwoIP = "127.0.0.1";//二号工位扫码器IP
        public static string BarScanTwoPort = "2001";//二号工位扫码器端口号

        //public static string BarScanOneIP = "127.0.0.1";//一号工位扫码器IP
        //public static string BarScanOnePort = "2000";// 一号工位扫码器端口号      
        //public static string BarScanTwoIP = "127.0.0.1";//二号工位扫码器IP
        //public static string BarScanTwoPort = "2001";//二号工位扫码器端口号

        //public static string BarScanOneIP = "127.0.0.1";//前排缓存库一号工位扫码器IP
        //public static string BarScanOnePort = "2000";// 前排缓存库一号工位扫码器端口号      
        //public static string BarScanTwoIP = "127.0.0.1";//前排缓存库二号工位扫码器IP
        //public static string BarScanTwoPort = "2001";//前排缓存库二号工位扫码器端口号



        public static string LanguageType = "1";//1. 中文简体，2.英语（US）
        public static string PortName = "COM1";
        public static string TimeFormat;

        public static string UseDiscernFlag = "1";//1启用串口扫码器扫描能耗贴 2不启用串口扫码器扫描能耗贴

        public static string StockBlock = "0";
        public static string StockAddress = "0";
        public static string Stocklength = "0";

        public static string AFDBlock = "0";
        public static string AFDAddress = "0";
        public static string AFDlength = "0";

        public static string BFDBlock = "0";
        public static string BFDAddress = "0";
        public static string BFDlength = "0";

        public static string AXTCKBlock = "0";
        public static string AXTCKAddress = "0";
        public static string BXTCKBlock = "0";
        public static string BXTCKAddress = "0";

        //U壳寄存库
        public static int m_iAutoScanBarcode = 0;  //WYF：自动扫描
        public static int CurrentProductionOutMode = 1; //U壳出库模式：1=规则出库； 2=扫码出库； 3=手动出库；
        public static string CurrentStationPlcAddress = ""; //U壳出库PLC地址：U壳出库A地址50； U壳出库A地址70；
    }
}