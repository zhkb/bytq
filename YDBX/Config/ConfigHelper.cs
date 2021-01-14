//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using System.Windows.Forms;

namespace Sys.Config
{
    /// <summary>
    /// ConfigHelper
    /// 访问用户配置文件的类。
    /// 
    /// 修改纪录
    ///
    ///		2008.06.08 版本：1.3  命名修改为 ConfigHelper。
    ///		2008.04.22 版本：1.2  从指定的文件读取配置项。
    ///		2007.07.31 版本：1.1  规范化 FielName 变量。
    ///		2007.04.14 版本：1.0  专门读取注册表的类，主键书写格式改进。
    ///		
    ///	版本：1.2
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.04.22</date>
    /// </author> 
    /// </summary>
    public class ConfigHelper
    {
        public static string LogOnTo = "Config";

        public static string FileName
        {
            get
            {
                return LogOnTo + ".xml";
            }
        }

        public static string SelectPath = "//appSettings/add";

        public static string ConfigFielName
        {
            get
            {
                return FileName;
                // return Application.StartupPath + "\\" + FielName;
            }
        }

        #region public static Dictionary<String, String> GetLogOnTo() 获取配置文件选项
        /// <summary>
        /// 获取配置文件选项
        /// </summary>
        /// <returns>配置文件设置</returns>
        public static Dictionary<String, String> GetLogOnTo()
        {
            Dictionary<String, String> returnValue = new Dictionary<String, String>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(SelectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals("LogOnTo".ToUpper()))
                {
                    returnValue.Add(xmlNode.Attributes["value"].Value, xmlNode.Attributes["dispaly"].Value);
                }
            }
            return returnValue;
        }
        #endregion      

        #region public static string GetValue(string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string key)
        {
            return GetValue(ConfigFielName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string fileName, string key)
        {
            return GetValue(fileName, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(string fileName, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(string fileName, string selectPath, string key)
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(fileName);

            return GetValue(xmlDocument, selectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string key) 读取配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(XmlDocument xmlDocument, string key)
        {
            return GetValue(xmlDocument, SelectPath, key);
        }
        #endregion

        #region public static string GetValue(XmlDocument xmlDocument, string selectPath, string key) 设置配置项
        /// <summary>
        /// 读取配置项
        /// </summary>
        /// <param name="xmlDocument">配置文件</param>
        /// <param name="selectPath">查询条件</param>
        /// <param name="key">键</param>
        /// <returns>值</returns>
        public static string GetValue(XmlDocument xmlDocument, string selectPath, string key)
        {
            string returnValue = string.Empty;
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);

            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    returnValue = xmlNode.Attributes["value"].Value;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static void GetConfig() 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public static void GetConfig()
        {
            GetConfig(ConfigFielName);
        }
        #endregion

        #region public static void GetConfig(string fileName) 从指定的文件读取配置项
        /// <summary>
        /// 从指定的文件读取配置项
        /// </summary>
        /// <param name="fileName">配置文件</param>
        public static void GetConfig(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            // 客户信息配置

            //   BaseSystemInfo.Version = GetValue(xmlDocument, BaseConfiguration.VERSION);

            //BaseSystemInfo.DbHelperClass = GetValue(xmlDocument, BaseConfiguration.DBHELPER_CLASSNAME);
            //BaseSystemInfo.DbHelperAssmely = GetValue(xmlDocument, BaseConfiguration.DBHELPER_ASSMELY);

            //BaseSystemInfo.LogOnAssembly = GetValue(xmlDocument, BaseConfiguration.LOGON_ASSEMBLY);
            //BaseSystemInfo.LogOnForm = GetValue(xmlDocument, BaseConfiguration.LOGON_FORM);
            //BaseSystemInfo.MainForm = GetValue(xmlDocument, BaseConfiguration.MAIN_FORM);

            // 打开数据库连接
            BaseSystemInfo.BusinessDbConnectionString = GetValue(xmlDocument, BaseConfiguration.BUSINESS_DBCONNECTION);
            BaseSystemInfo.ServerDbConnectionString = GetValue(xmlDocument, BaseConfiguration.SERVER_DBCONNECTION);

            BaseSystemInfo.BusinessDbConnection = BaseSystemInfo.BusinessDbConnectionString;
            BaseSystemInfo.ServerDbConnection = BaseSystemInfo.ServerDbConnectionString;

            BaseSystemInfo.DataBaseType = GetValue(xmlDocument, BaseConfiguration.DATABASE_TYPE);

            // 程序升级相关
            BaseSystemInfo.AutoUpdateIP = GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEIP);
            BaseSystemInfo.AutoUpdatePort = GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEPORT);
            BaseSystemInfo.AutoUpdateDir = GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEDIR);
            BaseSystemInfo.AutoExecuteName = GetValue(xmlDocument, BaseConfiguration.APP_AUTOEXECUTENAME);
            BaseSystemInfo.UpdateInterval = int.Parse(GetValue(xmlDocument, BaseConfiguration.APP_UPDATEINTERVAL));
            BaseSystemInfo.AutoUpdateFinish = (String.Compare(GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEFINISH), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            BaseSystemInfo.AutoUpdateSuccess = (String.Compare(GetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATESUCCESS), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            BaseSystemInfo.App_Version = GetValue(xmlDocument, BaseConfiguration.APP_VERSION);
            //验证相关
            BaseSystemInfo.RunLogin = (String.Compare(GetValue(xmlDocument, BaseConfiguration.RUN_LOGIN), "TRUE", true, CultureInfo.CurrentCulture) == 0);
            BaseSystemInfo.RunLogout = (String.Compare(GetValue(xmlDocument, BaseConfiguration.RUN_LOGOUT), "TRUE", true, CultureInfo.CurrentCulture) == 0);

            //系统相关
            BaseSystemInfo.CompanyID = GetValue(xmlDocument, BaseConfiguration.COMPANYID);
            BaseSystemInfo.CompanyCode = GetValue(xmlDocument, BaseConfiguration.COMPANYCODE);
            BaseSystemInfo.CompanyName = GetValue(xmlDocument, BaseConfiguration.COMPANYNAME);
            BaseSystemInfo.FactoryID = GetValue(xmlDocument, BaseConfiguration.FACTORYID);
            BaseSystemInfo.FactoryCode = GetValue(xmlDocument, BaseConfiguration.FACTORYCODE);
            BaseSystemInfo.FactoryName = GetValue(xmlDocument, BaseConfiguration.FACTORYNAME);
            BaseSystemInfo.ProductLineID = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINEID);
            BaseSystemInfo.ProductLineCode = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINECODE);
            BaseSystemInfo.ProductLineName = GetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME);

            //工序
            BaseSystemInfo.CurrentProcessCode = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSCODE);
            BaseSystemInfo.CurrentProcessName = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSNAME);
            BaseSystemInfo.CurrentProcessName_EN = GetValue(xmlDocument, BaseConfiguration.CURRENTPROCESSNAME_EN);

            BaseSystemInfo.CurrentStationNo = GetValue(xmlDocument, BaseConfiguration.CURRENTSTATIONNO);

            BaseSystemInfo.StationCode = GetValue(xmlDocument, BaseConfiguration.STATIONCODE);


            //登录名、班组、班次
            BaseSystemInfo.CurrentUserID = GetValue(xmlDocument, BaseConfiguration.CURRENTUSERID);
            BaseSystemInfo.CurrentUserCode = GetValue(xmlDocument, BaseConfiguration.CURRENTUSERCODE);
            BaseSystemInfo.CurrentUserName = GetValue(xmlDocument, BaseConfiguration.CURRENTUSERNAME);
            BaseSystemInfo.CurrentClassCode = GetValue(xmlDocument, BaseConfiguration.CURRENTCLASSCODE);
            BaseSystemInfo.CurrentClassName = GetValue(xmlDocument, BaseConfiguration.CURRENTCLASSNAME);
            BaseSystemInfo.CurrentShiftCode = GetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTCODE);
            BaseSystemInfo.CurrentShiftName = GetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTNAME);
            //系统类型
            BaseSystemInfo.SystemType = int.Parse(GetValue(xmlDocument, BaseConfiguration.SYSTEMTYPE));
            //PLC相关
            BaseSystemInfo.PLCType = GetValue(xmlDocument, BaseConfiguration.PLCTYPE);

            BaseSystemInfo.MasterPLCStation = GetValue(xmlDocument, BaseConfiguration.MASTERPLCSTATION);

            BaseSystemInfo.BarScanIP = GetValue(xmlDocument, BaseConfiguration.BARSCANIP);
            BaseSystemInfo.BarScanPort = GetValue(xmlDocument, BaseConfiguration.BARSCANPORT);

            BaseSystemInfo.BarScanProIP = GetValue(xmlDocument, BaseConfiguration.BARSCANPROIP);
            BaseSystemInfo.BarScanProPort = GetValue(xmlDocument, BaseConfiguration.BARSCANPROPORT);

            BaseSystemInfo.BarScanComIP = GetValue(xmlDocument, BaseConfiguration.BARSCANCOMIP);
            BaseSystemInfo.BarScanComPort = GetValue(xmlDocument, BaseConfiguration.BARSCANCOMPORT);

            BaseSystemInfo.LanguageType = GetValue(xmlDocument, BaseConfiguration.LANGUAGETYPE);


            BaseSystemInfo.UseDiscernFlag = GetValue(xmlDocument, BaseConfiguration.USEDISCERNFLAG);

            BaseSystemInfo.StockBlock = GetValue(xmlDocument, BaseConfiguration.STOCKBLOCK);
            BaseSystemInfo.StockAddress = GetValue(xmlDocument, BaseConfiguration.STOCKADDRESS);
            BaseSystemInfo.Stocklength = GetValue(xmlDocument, BaseConfiguration.STOCKLENGTH);

            BaseSystemInfo.AFDBlock = GetValue(xmlDocument, BaseConfiguration.AFDBLOCK);
            BaseSystemInfo.AFDAddress = GetValue(xmlDocument, BaseConfiguration.AFDADDRESS);
            BaseSystemInfo.AFDlength = GetValue(xmlDocument, BaseConfiguration.AFDLENGTH);

            BaseSystemInfo.BFDBlock = GetValue(xmlDocument, BaseConfiguration.BFDBLOCK);
            BaseSystemInfo.BFDAddress = GetValue(xmlDocument, BaseConfiguration.BFDADDRESS);
            BaseSystemInfo.BFDlength = GetValue(xmlDocument, BaseConfiguration.BFDLENGTH);

            BaseSystemInfo.AXTCKBlock = GetValue(xmlDocument, BaseConfiguration.AXTCKBLOCK);
            BaseSystemInfo.AXTCKAddress = GetValue(xmlDocument, BaseConfiguration.AXTCKADDRESS);
            BaseSystemInfo.BXTCKBlock = GetValue(xmlDocument, BaseConfiguration.BXTCKBLOCK);
            BaseSystemInfo.BXTCKAddress = GetValue(xmlDocument, BaseConfiguration.BXTCKADDRESS);


            BaseSystemInfo.CurrentProductionOutMode = int.Parse(GetValue(xmlDocument, BaseConfiguration.CurrentProductionOutMode));
            BaseSystemInfo.CurrentStationPlcAddress = GetValue(xmlDocument, BaseConfiguration.CurrentStationPlcAddress);
        }
        #endregion

        public static bool SetValue(string key, string keyValue)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigFielName);

            bool ret = SetValue(xmlDocument, SelectPath, key, keyValue);

            xmlDocument.Save(ConfigFielName);
            return ret;
        }

        public static bool SetValue(XmlDocument xmlDocument, string key, string keyValue)
        {
            return SetValue(xmlDocument, SelectPath, key, keyValue);
        }

        public static bool SetValue(XmlDocument xmlDocument, string selectPath, string key, string keyValue)
        {
            bool returnValue = false;
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes(selectPath);
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(key.ToUpper()))
                {
                    xmlNode.Attributes["value"].Value = keyValue;
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        #region public static void SaveConfig() 保存配置文件

        /// <summary>
        /// 保存配置文件
        /// </summary>
        public static void SaveConfig()
        {
            SaveConfig(ConfigFielName);
        }
        #endregion

        #region public static void SaveConfig(string fileName) 保存到指定的文件
        /// <summary>
        /// 保存到指定的文件
        /// </summary>
        /// <param name="fileName">配置文件</param>
        public static void SaveConfig(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);

            // 客户信息配置

            //  SetValue(xmlDocument, BaseConfiguration.CURRENT_PASSWORD, BaseSystemInfo.CurrentPassword);

            ////  SetValue(xmlDocument, BaseConfiguration.VERSION, BaseSystemInfo.Version);

            //  SetValue(xmlDocument, BaseConfiguration.LOGON_ASSEMBLY, BaseSystemInfo.LogOnAssembly);
            //  SetValue(xmlDocument, BaseConfiguration.LOGON_FORM, BaseSystemInfo.LogOnForm);
            //  SetValue(xmlDocument, BaseConfiguration.MAIN_FORM, BaseSystemInfo.MainForm);

            SetValue(xmlDocument, BaseConfiguration.BUSINESS_DBCONNECTION, BaseSystemInfo.BusinessDbConnectionString);
            SetValue(xmlDocument, BaseConfiguration.SERVER_DBCONNECTION, BaseSystemInfo.ServerDbConnectionString);

            SetValue(xmlDocument, BaseConfiguration.DATABASE_TYPE, BaseSystemInfo.DataBaseType.ToString());

            // 升级相关
            SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEIP, BaseSystemInfo.AutoUpdateIP);
            SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEPORT, BaseSystemInfo.AutoUpdatePort);

            SetValue(xmlDocument, BaseConfiguration.APP_AUTOEXECUTENAME, BaseSystemInfo.AutoExecuteName);
            SetValue(xmlDocument, BaseConfiguration.APP_UPDATEINTERVAL, BaseSystemInfo.UpdateInterval.ToString());
            // SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATEFINISH, BaseSystemInfo.AutoUpdateFinish.ToString());
            //  SetValue(xmlDocument, BaseConfiguration.APP_AUTOUPDATESUCCESS, BaseSystemInfo.AutoUpdateSuccess.ToString());

            //验证相关
            SetValue(xmlDocument, BaseConfiguration.RUN_LOGIN, BaseSystemInfo.RunLogin.ToString());
            SetValue(xmlDocument, BaseConfiguration.RUN_LOGOUT, BaseSystemInfo.RunLogout.ToString());

            //菜单按钮相关
            SetValue(xmlDocument, BaseConfiguration.BTNWIDTH, BaseSystemInfo.BtnWidth.ToString());
            SetValue(xmlDocument, BaseConfiguration.BTNHEIGHT, BaseSystemInfo.BtnHeight.ToString());

            //系统相关
            SetValue(xmlDocument, BaseConfiguration.COMPANYID, BaseSystemInfo.CompanyID);
            SetValue(xmlDocument, BaseConfiguration.COMPANYCODE, BaseSystemInfo.CompanyCode);
            SetValue(xmlDocument, BaseConfiguration.COMPANYNAME, BaseSystemInfo.CompanyName);

            SetValue(xmlDocument, BaseConfiguration.FACTORYID, BaseSystemInfo.FactoryID);
            SetValue(xmlDocument, BaseConfiguration.FACTORYCODE, BaseSystemInfo.FactoryCode);
            SetValue(xmlDocument, BaseConfiguration.FACTORYNAME, BaseSystemInfo.FactoryName);

            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINEID, BaseSystemInfo.ProductLineID);
            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINECODE, BaseSystemInfo.ProductLineCode);
            SetValue(xmlDocument, BaseConfiguration.PRODUCTLINENAME, BaseSystemInfo.ProductLineName);

            //登录用户名、班次和班组
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERID, BaseSystemInfo.CurrentUserID);
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERCODE, BaseSystemInfo.CurrentUserCode);
            SetValue(xmlDocument, BaseConfiguration.CURRENTUSERNAME, BaseSystemInfo.CurrentUserName);
            SetValue(xmlDocument, BaseConfiguration.CURRENTCLASSCODE, BaseSystemInfo.CurrentClassCode);
            SetValue(xmlDocument, BaseConfiguration.CURRENTCLASSNAME, BaseSystemInfo.CurrentClassName);
            SetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTCODE, BaseSystemInfo.CurrentShiftCode);
            SetValue(xmlDocument, BaseConfiguration.CURRENTSHIFTNAME, BaseSystemInfo.CurrentShiftName);
            xmlDocument.Save(fileName);
        }

        public static void CheckNodeExists(string KeyName, string DefaultValue) //查看是否存在属性值
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ConfigFielName);

            XmlNodeList xmlNodeList = xmlDoc.SelectNodes(SelectPath);

            bool ExistsFlag = false;
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                if (xmlNode.Attributes["key"].Value.ToUpper().Equals(KeyName.ToUpper()))
                {
                    ExistsFlag = true;
                    break;
                }
            }

            if (!ExistsFlag)
            {
                XmlNode NodeList = xmlDoc.SelectSingleNode("configuration/appSettings");
                XmlElement member = xmlDoc.CreateElement("add");
                member.SetAttribute("key", KeyName);
                member.SetAttribute("value", DefaultValue);

                NodeList.AppendChild(member);
                xmlDoc.Save(ConfigFielName);
            }

        }


        #endregion
    }
}