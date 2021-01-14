//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Globalization;

namespace Sys.Config
{
    /// <summary>
    /// ConfigurationHelper
    /// 连接配置。
    /// 
    /// 修改纪录
    /// 
    ///		2008.06.08 版本：1.0  将程序从 BaseConfiguration 进行了分离。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>
    public class ConfigurationHelper
    {
         #region public static void GetConfig()
        /// <summary>
        /// 从配置信息获取配置信息
        /// </summary>
        /// <param name="configuration">配置</param>
        public static void GetConfig()
        {

            //BaseSystemInfo.Version = ConfigurationManager.AppSettings[BaseConfiguration.VERSION];

            //BaseSystemInfo.LogOnAssembly = ConfigurationManager.AppSettings[BaseConfiguration.LOGON_ASSEMBLY];
            //BaseSystemInfo.LogOnForm = ConfigurationManager.AppSettings[BaseConfiguration.LOGON_FORM];
            //BaseSystemInfo.MainForm = ConfigurationManager.AppSettings[BaseConfiguration.MAIN_FORM];

            // 数据库连接
            BaseSystemInfo.BusinessDbConnectionString = ConfigurationManager.AppSettings[BaseConfiguration.BUSINESS_DBCONNECTION];
            BaseSystemInfo.ServerDbConnectionString = ConfigurationManager.AppSettings[BaseConfiguration.SERVER_DBCONNECTION];


            BaseSystemInfo.DataBaseType = ConfigurationManager.AppSettings[BaseConfiguration.DATABASE_TYPE];
        }
        #endregion
    }
}