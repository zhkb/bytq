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

        public const string SYSTEMTYPE = "SystemType";
        // 数据库连接
        public const string SERVER_DBCONNECTION = "ServerDbConnection";
        public const string BUSINESS_DBCONNECTION = "BusinessDbConnection";

        public const string DATABASE_TYPE = "DataBaseType";
        public const string REGISTER_KEY = "RegisterKey";

        public const string SERVERIP = "ServerIP";
        public const string SERVERUSER = "ServerUser";
        public const string SERVERPWD = "ServerPwd";
        public const string SERVERDB = "ServerDB";

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

        //登录用户名，班次和班组
        public const string CURRENTUSERID = "CurrentUserID";
        public const string CURRENTUSERCODE = "CurrentUserCode";
        public const string CURRENTUSERNAME = "CurrentUserName";
        public const string CURRENTCLASSCODE = "CurrentClassCode";
        public const string CURRENTCLASSNAME = "CurrentClassName";
        public const string CURRENTSHIFTCODE = "CurrentShiftCode";
        public const string CURRENTSHIFTNAME = "CurrentShiftName";

        //工序
        public const string CURRENTPROCESSCODE = "CurrentProcessCode";
        public const string CURRENTPROCESSNAME = "CurrentProcessName";
        public const string CURRENTMATERIALNAME = "CurrentMaterialName";
        public const string CURRENTPLANNAME = "CurrentPlanName";

        public const string SERIALPORTNAME1 = "SerialPortName1";
        public const string SERIALPORTNAME2 = "SerialPortName2";

        public const string MASTERPLCIP1 = "MasterPLCIP1";
        public const string MASTERPLCIP2 = "MasterPLCIP2";

        public const string MASTERPLCIP_FIRST = "MasterPLCIP_First";
        public const string MASTERPLCIP_SENCOND = "MasterPLCIP_Sencond";

        public const string MASTERPLCSTATION_FIRST = "MasterPLCStation_First";
        public const string MASTERPLCSTATION_SENCOND = "MasterPLCStation_Sencond";

        public const string DOWNBLOCKNO = "DownBlockNo";
        public const string DOWNADDRESSNO = "DownAddressNo";

        public const string PLCTYPE = "PLCType";

        public const string BARSCANIP1 = "BarScanIP";
        public const string BARSCANIP2 = "BarScanIP2";
        public const string BARSCANIP3 = "BarScanIP3";
        public const string BARSCANIP4 = "BarScanIP4";
        public const string BARSCANIP5 = "BarScanIP5";
        public const string BARSCANIP6 = "BarScanIP6";
        public const string BARSCANIP7 = "BarScanIP7";
        public const string BARSCANIP8 = "BarScanIP8";
        public const string BARSCANIP9 = "BarScanIP9";
        public const string BARSCANIP10 = "BarScanIP10";
        public const string BARSCANIP11 = "BarScanIP11";
        public const string BARSCANIP12 = "BarScanIP12";
        public const string BARSCANIP13 = "BarScanIP13";
        public const string BARSCANIP14 = "BarScanIP14";
        public const string BARSCANIP15 = "BarScanIP15";

        public const string BARSCANPORT1 = "BarScanPort1";
        public const string BARSCANPORT2 = "BarScanPort2";
        public const string BARSCANPORT3 = "BarScanPort3";
        public const string BARSCANPORT4 = "BarScanPort4";
        public const string BARSCANPORT5 = "BarScanPort5";
        public const string BARSCANPORT6 = "BarScanPort6";
        public const string BARSCANPORT7 = "BarScanPort7";
        public const string BARSCANPORT8 = "BarScanPort8";
        public const string BARSCANPORT9 = "BarScanPort9";
        public const string BARSCANPORT10 = "BarScanPort10";
        public const string BARSCANPORT11 = "BarScanPort11";
        public const string BARSCANPORT12 = "BarScanPort12";
        public const string BARSCANPORT13 = "BarScanPort13";
        public const string BARSCANPORT14 = "BarScanPort14";
        public const string BARSCANPORT15 = "BarScanPort15";

        public const string BARSCANPROIP = "BarScanProIP";
        public const string BARSCANPROPORT = "BarScanProPort";

        public const string AREACODE = "AreaCode";




        public const string SELECTMATERIALSTR = "selectMaterialStr";

        public const string RFIDIP = "RFIDIP";
        public const string RFIDPORT = "RFIDPort";
        public const string INRFIDIP = "INRFIDIP";
        public const string INRFIDPORT = "INRFIDPort";
        public const string OUTRFIDIP = "OUTRFIDIP";
        public const string OUTRFIDPORT = "OUTRFIDPort";
       

        public const string CURRENTINSTORECODE = "CurrentINStoreCode";
        public const string RKADDRESS1 = "RKAddress1";
        public const string RKADDRESS2 = "RKAddress2";
        public const string RKLEN = "RKLen";
        public const string BDADDRESS = "BDAddress";
        public const string BDLEN = "BDLen";
        public const string INRADDRESS = "INRAddress";
        public const string INRLEN = "INRLen";
        public const string MADDRESS = "Maddress";
        public const string MLEN = "Mlen";
        public const string NADDRESS = "Naddress";
        public const string NLEN = "Nlen";
        public const string KCADDRESS = "KCaddress";

        public const string CKADDRESS = "CKAddress";
        public const string CKLEN = "CKLen";
        public const string RKWCADDRESS = "RKWCAddress";
        public const string RKWCLEN = "RKWCLen";


        public const string FWADDRESS = "FWaddress";
        public const string FWLEN = "FWlen";
        public const string YXJADDRESS = "YXJaddress";
        public const string YXJLEN = "YXJlen";

        public const string FPADDRESS = "FPAddress";
        public const string MMADDRESS = "MMAddress";
        public const string MCXFLAG = "MCXFlag";
        public const string WLADDRESS = "WLaddress";
        public const string WLLEN = "WLlen";

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