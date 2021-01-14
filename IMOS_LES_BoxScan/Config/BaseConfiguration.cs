//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Sys.Config
{
    /// <summary>
    /// BaseConfiguration
    /// 连接配置。
    /// 
    /// 修改纪录
    /// 
    ///		2011.01.21 版本：3.6  自动登录、加密数据库连接功能完善。
    ///		2008.06.08 版本：3.5  将读取配置文件进行分离。
    ///		2008.05.08 版本：3.4  获得不同的数据库连接字符串 OracleConnection、SqlConnection、OleDbConnection。
    ///		2007.11.28 版本：3.2  获得数据连接字符串，减少配置文件的读的次序，提高性能。
    ///		2007.05.23 版本：3.1  增加 public const string 定义部分。
    ///		2007.04.14 版本：3.0  检查程序格式通过，不再进行修改主键操作。
    ///		2006.11.17 版本：2.4  GetFromRegistryKey() 方法主键进行整理，删除多余的引用。
    ///		2006.05.02 版本：2.3  GetFromConfig 增加从配置文件读取数据库联接的方法。
    ///		2006.04.18 版本：2.2  重新调整主键的规范化。
    ///		2006.02.02 版本：2.0  删除数据库连接池的想法，修改了命名，更规范化，贴切了。 
    ///		2005.12.29 版本：1.0  从配置文件读取数据库连接。
    /// 
    /// 版本：3.5
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class BaseConfiguration
    {
        public const string CURRENT_LOGON_TO = "LogOnTo";


        public const string REMEMBER_PASSWORD = "RememberPassword";
        public const string CURRENT_USERNAME = "CurrentUserName";
        public const string CURRENT_PASSWORD = "CurrentPassword";
        public const string ALLOW_NULLPASSWORD = "AllowNullPassword";

        // 客户信息配置
        public const string VERSION = "Version";

        // 这里是服务器设置项
        public const string SYSTEM_TYPE = "SystemType";

        public const string SERVICE_FACTORY = "ServiceFactory";
        public const string SERVICE_PATH = "ServicePath";
        public const string DBHELPER_CLASSNAME = "DbHelperClass";
        public const string DBHELPER_ASSMELY = "DbHelperAssmely";
        public const string RECORD_LOG = "RecordLog";

        // 登录窗体

        public const string LOGON_ASSEMBLY = "LogOnAssembly";
        public const string LOGON_FORM = "LogOnForm";
        public const string MAIN_FORM = "MainForm";


        // 数据库连接

        public const string SERVER_DBCONNECTION = "ServerDbConnection";
        public const string BUSINESS_DBCONNECTION = "BusinessDbConnection";

        public const string DATABASE_TYPE = "DataBaseType";
        public const string REGISTER_KEY = "RegisterKey";

        public const string SERVERIP = "ServerIP";
        public const string SERVERUSER = "ServerUser";
        public const string SERVERPWD = "ServerPwd";
        public const string SERVERDB = "ServerDB";
        // 程序升级
        public const string APP_AUTOUPDATEIP = "App_AutoUpdateIP";
        public const string APP_AUTOUPDATEPORT = "App_AutoUpdatePort";
        public const string APP_AUTOUPDATEDIR = "App_AutoUpdateDir";
        public const string APP_AUTOEXECUTENAME = "App_AutoExecuteName";
        public const string APP_UPDATEINTERVAL = "App_UpdateInterval";
        public const string APP_AUTOUPDATEFINISH = "App_AutoUpdateFinish";
        public const string APP_AUTOUPDATESUCCESS = "App_AutoUpdateSuccess";
        public const string APP_VERSION = "App_Version";

        //条码扫描相关
        public const string BARCODESCANIP = "BarCodeScanIP";
        public const string BARCODESCANPORT = "BarCodeScanPort";       

        //喷码机相关
        public const string PRINTERIP = "PrinterIP";
        public const string PRINTERPORT = "PrinterPort";



        //报表存储目录
        public const string APP_ReportDir = "APP_ReportDir";
        //系统启动退出的验证
        public const string RUN_LOGIN = "RunLogin";
        public const string RUN_LOGOUT = "RunLogout";

        public const string MENUCOUNT = "MenuCount";
        public const string MENUKEY = "SystemMenuName";
        public const string SOURVEKEY = "SystemMenuSource";
        public const string FORMKEY = "SystemMenuForm";
        public const string VISIBLEKEY = "SystemMenuVisible";

        //停机相关
        public const string BTNWIDTH = "BtnWidth";
        public const string BTNHEIGHT = "BtnHeight";

        //设备相关 相关的主要设备名称
        public const string COMPANYID = "CompanyID";
        public const string COMPANYCODE = "CompanyCode";
        public const string COMPANYNAME = "CompanyName";
        public const string DEPTID = "DeptID";
        public const string DEPTCODE = "DeptCode";
        public const string DEPTNAME = "DeptName";
        public const string PRODUCTLINEID = "ProductLineID";
        public const string PRODUCTLINECODE = "ProductLineCode";
        public const string PRODUCTLINENAME = "ProductLineName";

        //登录用户名，班次和班组
        public const string CURRENTUSERID = "CurrentUserID";
        public const string CURRENTUSERCODE = "CurrentUserCode";
        public const string CURRENTUSERNAME = "CurrentUserName";
        public const string CURRENTCLASSCODE = "CurrentClassCode";
        public const string CURRENTCLASSNAME = "CurrentClassName";
        public const string CURRENTSHIFTCODE = "CurrentShiftCode";
        public const string CURRENTSHIFTNAME = "CurrentShiftName";

        public const string LOCALPWD = "LocalPWD";

        public const string BOXBARFLAG = "BoxBarFlag";

        public const string SERIALPORTNAME = "SerialPortName";

        public const string SENDPRINTERFLAG = "SendPrinterFlag";

        public const string LINERINSCANIP = "LinerInScanIP";
        public const string LINERINSCANPORT = "LinerInScanPort";

        #region public BaseConfiguration()
        /// <summary>
        /// 构造方法
        /// </summary>
        public BaseConfiguration()
        {
        }
        #endregion


        #region public static ConfigurationCategory GetConfiguration(string configuration)
        /// <summary>
        /// 配置信息的类型判断
        /// </summary>
        /// <param name="configuration">配置信息类型</param>
        /// <returns>配置信息类型</returns>
        public static ConfigurationCategory GetConfiguration(string configuration)
        {
            ConfigurationCategory returnValue = ConfigurationCategory.Configuration;
            foreach (ConfigurationCategory configurationCategory in Enum.GetValues(typeof(ConfigurationCategory)))
            {
                if (configurationCategory.ToString().Equals(configuration))
                {
                    returnValue = configurationCategory;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void GetSetting()
        /// <summary>
        /// 读取配置信息
        /// </summary>
        public static void GetSetting()
        {

            if (BaseSystemInfo.ConfigurationFrom == ConfigurationCategory.Configuration)
            {
                ConfigurationHelper.GetConfig();
            }
            if (BaseSystemInfo.ConfigurationFrom == ConfigurationCategory.UserConfig)
            {
                ConfigHelper.GetConfig();
            }
        }
        #endregion
    }
}