
using System;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Sys.Config
{
    public struct BarScanInfo  //条码信息
    {
        public string BarNo;
        public string BarIP;
        public string BarPort;
        public string BarCode;
        public int BarStatus;
        public string BarTips;
    }

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


        public static string CpuNo = "";
        public static string DiskNo = "";

        public static string RegisterKey = "BYTQ";

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

        public static string CurrentUserID = "1"; //当前用户编号
        public static string CurrentUserCode = "admin"; //当前用户编号
        public static string CurrentUserName = "管理员"; //当前用户名称
        public static string CurrentUserImage = ""; //
        public static string CurrentUserCardImage = ""; //
        public static string CurrentUserWorkTime = ""; //

        public static string CurrentPassword = "33";
        public static string CurrentClassCode = "1001"; //班次代码
        public static string CurrentClassName = "早班"; //班次名称
        public static string CurrentShiftCode = "1001"; //班组编码
        public static string CurrentShiftName = "A组"; //班组名称

        public static string CurrentProcessCode = "101"; //工序代码 
        public static string CurrentProcessName = "内胆上线工位"; //工序名称 

        public static string CurrentMaterialName = "";
        public static string CurrentPlanName = "";

        public static string CurrentStoreCode = "S001";
        public static string CurrentStoreName = "门体库";


        public static bool CurrentAdminFlag = false; //当前是否管理员

        public static string SerialPortName1 = "COM1";
        public static string SerialPortName2 = "COM2";


        public static int SystemType = 1; //系统类型 1 正极 2 负极


        /// <summary>
        /// 主应用程序集名
        /// </summary>
        public static string MainAssembly = string.Empty;

        public static string PLCType = "1";
        public static string MasterPLCStation = "3";

        public static string MasterPLCIP1 = "10.10.60.180";
        public static string MasterPLCIP2 = "10.10.60.180";

        //PLC IP地址  用于西门子PLC
        public static string MasterPLCIP_First = "10.10.60.180";
        public static string MasterPLCIP_Sencond = "10.10.60.180";

        //PLC站点号 用于三菱PLC
        public static string MasterPLCStation_First = "3";
        public static string MasterPLCStation_Sencond = "4";

        public static int DownBlockNo = 1;
        public static int DownAddressNo = 30;

        public static int SocketNum = 15;
        public static BarScanInfo[] BarScanInfoList = new BarScanInfo[SocketNum]; // 

        public static Thread[] BarScanSocketThread = new Thread[SocketNum]; // 创建用于接收服务端消息的 线程； 
        public static Socket[] BarScanSocket = new Socket[SocketNum]; // 创建用于接收服务端消息的 线程； 
        public static IPEndPoint[] BarScanendPoint = new IPEndPoint[SocketNum];
        public static bool[] BarScanBarConn = new bool[SocketNum]; //条码扫描设备连接状态
        public static int[] BarScanBarConnCount = new int[SocketNum];


        public static string SystemControlType = "1";

        //BOM产品的物料类型编号
        public static string Material_Type_Code = "MN001";

        public static string BarScanProIP = "127.0.0.1";
        public static string BarScanProPort = "2112";

        public static string AreaCode = "";//货道所在区域

        public static string selectMaterialStr = "";





        //合肥玻璃门壳输送

        public static string RFIDIP = "127.0.0.1"; 
        public static string RFIDPort = "2000";

        public static string INRFIDIP = "192.168.3.61";
        public static string INRFIDPort = "2112";

        public static string OUTRFIDIP = "127.0.0.1";
        public static string OUTRFIDPort = "2002";



        public static string CurrentINStoreCode = "1";
        //预装入库左
        public static int RKAddress1 = 420;
        public static int RKAddress2 = 425;
        public static int RKLen = 2;

        //预装入库右
       

        //预装绑定
        public static int BDAddress = 430;
        public static int BDLen = 2;

        //RFID入库
        public static int INRAddress = 325;
        public static int INRLen = 5;

        //空板模式信号
        public static int Maddress = 435;
        public static int Mlen = 1;
        public static int Naddress = 437;
        public static int Nlen = 1;

        public static int KCaddress = 2100;

        public static int CKAddress = 3270;
        public static int CKLen = 1;

        public static int RKWCAddress = 400;
        public static int RKWCLen = 8;

        public static int FWaddress = 438;

        public static int FWlen = 1;

        public static int YXJaddress = 1150;

        public static int YXJlen = 8;

        public static int FPAddress = 3300;

        public static int MMAddress = 3110;

        public static int MCXFlag = 1;

        public static int WLaddress =433;
        public static int WLlen =2;
    }
}