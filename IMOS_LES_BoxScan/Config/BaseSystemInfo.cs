
using System;
using System.Collections.Generic;
using System.Management;
using System.Net;

namespace Sys.Config
{
    public class BaseSystemInfo
    {
        public static string[] DBHelperList = new string[] { "IMOS.DbUtilities.SqlHelper", "IMOS.DbUtilities.OracleHelper", "IMOS.DbUtilities.OleDbHelper", "IMOS.DbUtilities.OleDbHelper", "IMOS.DbUtilities.MySqlHelper", "IMOS.DbUtilities.SqLiteHelper" };

        /// <summary>
        /// RegistryKey、Configuration、UserConfig 注册表或者配置文件读取参数
        /// </summary>
        public static ConfigurationCategory ConfigurationFrom = ConfigurationCategory.UserConfig;

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
        /// 
        public static string MainAssembly = string.Empty;

        public static string BusinessDbConnection = string.Empty;

        public static string DbHelperClass = "IMOS.DbUtilities.SqlHelper";
        public static string DbHelperAssmely = "IMOS.DbUtilities";

        public static string LogOnAssembly = "IMOS.PTS.LogOn";
        public static string LogOnForm = "FrmLogOn";
        public static string MainForm = "MainForm";

        //数据库连接相关
        public static string DataBaseType = "SqlServer"; //数据库类型
        public static string FactoryCode = "2004"; //公司编码
        public static string FactoryName = "澳柯玛"; //公司名称
        //扫码相关
        public static string LinerInScanIP = "127.0.0.1";
        public static string LinerInScanPort = "4001";


        public static string MasterPLCStation = "1";
        public static string PLCType = "1";
        public static string LeftTaskFrom = "入库1";
        public static string RightTaskFrom = "入库2";
        public static string TaskType = "I";
        public static string TaskState = "0";
        public static string AutoFlag = "2";

        public static string SocketIP = "127.0.0.1";
        public static string SocketPort = "2112";

        public static string Company_Code = "C001";
        public static string Company_Name = "青岛澳柯玛智慧冷链有限公司";
        public static string Factory_Code = "2004";
        public static string Factory_Name = "中德生态园智慧工厂1号线";
        public static string Device_Code = "CKSB01";
        public static string Device_Name = "SMQ001";

        public static string StoreCode1 = "D0001";//1库位号
        public static string StoreCode2 = "D0002";//2库位号
        public static string TaskFrom1 = "入库1";//入库地1
        public static string TaskFrom2 = "入库2";//入库地2
    }
}