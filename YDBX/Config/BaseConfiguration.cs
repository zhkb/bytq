//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Sys.Config
{
    /// <summary>
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class BaseConfiguration
    {
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

        //报表存储目录
        public const string APP_ReportDir = "APP_ReportDir";
        //系统启动退出的验证
        public const string RUN_LOGIN = "RunLogin";
        public const string RUN_LOGOUT = "RunLogout";

        //停机相关
        public const string BTNWIDTH = "BtnWidth";
        public const string BTNHEIGHT = "BtnHeight";

        //设备相关 相关的主要设备名称
        public const string COMPANYID = "CompanyID";
        public const string COMPANYCODE = "CompanyCode";
        public const string COMPANYNAME = "CompanyName";
        public const string FACTORYID = "FactoryID";
        public const string FACTORYCODE = "FactoryCode";
        public const string FACTORYNAME = "FactoryName";
        public const string PRODUCTLINEID = "ProductLineID";
        public const string PRODUCTLINECODE = "ProductLineCode";
        public const string PRODUCTLINENAME = "ProductLineName";
        //工序
        public const string CURRENTPROCESSCODE = "CurrentProcessCode";
        public const string CURRENTPROCESSNAME = "CurrentProcessName";
        public const string CURRENTPROCESSNAME_EN = "CurrentProcessName_EN";

        public const string CURRENTSTATIONNO = "CurrentStationNo";


        public const string STATIONCODE = "StationCode";//工位

        //登录用户名，班次和班组
        public const string CURRENTUSERID = "CurrentUserID";
        public const string CURRENTUSERCODE = "CurrentUserCode";
        public const string CURRENTUSERNAME = "CurrentUserName";
        public const string CURRENTCLASSCODE = "CurrentClassCode";
        public const string CURRENTCLASSNAME = "CurrentClassName";
        public const string CURRENTSHIFTCODE = "CurrentShiftCode";
        public const string CURRENTSHIFTNAME = "CurrentShiftName";

        public const string LOCALPWD = "LocalPWD";

        public const string SYSTEMTYPE = "SystemType";

        public const string PLCTYPE = "PLCType";

        public const string MASTERPLCSTATION = "MasterPLCStation";

        public const string BARSCANIP = "BarScanIP";
        public const string BARSCANPORT = "BarScanPort";

        public const string BARSCANPROIP = "BarScanProIP";
        public const string BARSCANPROPORT = "BarScanProPort";

        public const string BARSCANCOMIP = "BarScanComIP";
        public const string BARSCANCOMPORT = "BarScanComPort";

        public static string LANGUAGETYPE = "LanguageType";

        public static string USEDISCERNFLAG = "UseDiscernFlag";


        public const string STOCKBLOCK = "StockBlock";
        public const string STOCKADDRESS = "StockAddress";
        public const string STOCKLENGTH = "Stocklength";


        public const string AFDBLOCK = "AFDBlock";
        public const string AFDADDRESS = "AFDAddress";
        public const string AFDLENGTH = "AFDlength";

        public const string BFDBLOCK = "BFDBlock";
        public const string BFDADDRESS = "BFDAddress";
        public const string BFDLENGTH = "BFDlength";

        public const string AXTCKBLOCK = "AXTCKBlock";
        public const string AXTCKADDRESS = "AXTCKAddress";
        public const string BXTCKBLOCK = "BXTCKBlock";
        public const string BXTCKADDRESS = "BXTCKAddress";


        public const string CurrentProductionOutMode = "CurrentProductionOutMode";   //U壳出库模式：1=规则出库； 2=扫码出库； 3=手动出库；
        public const string CurrentStationPlcAddress = "CurrentStationPlcAddress";  //U壳出库PLC地址：U壳出库A地址50； U壳出库A地址70；



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
                ConfigurationHelper.GetConfig();
        }
        #endregion
    }
}