//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

namespace Sys.Config
{
    /// <summary>
    /// ConfigurationCategory
    /// 系统配置信息读取。
    /// 
    /// 修改纪录
    /// 
    ///		2008.06.08 版本：3.1  将命名修改为 ConfigurationCategory。 
    ///		2007.04.14 版本：3.0  检查程序格式通过，不再进行修改主键操作。 
    ///		2006.11.17 版本：2.0  变量命规范化。
    ///		2006.09.11 版本：1.0  重新调整主键的规范化。
    ///		
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.08</date>
    /// </author> 
    /// </summary>  
    public enum ConfigurationCategory
    {
        RegistryKey,    // 从注册表读取
        Configuration,  // 从配置文件读取
        UserConfig      // 用户的配置文件
    }
}