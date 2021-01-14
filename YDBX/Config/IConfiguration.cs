//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd.  
//-------------------------------------------------------------------------------------

using System;
using System.Data;

namespace IPOS.Common.Utilities
{
    /// <summary>
    /// IConfiguration
    /// 读取配置文件接口定义
    /// 
    /// 修改纪录
    /// 
    ///		2009.07.08 版本：1.0  创建代码。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name></name>
    ///		<date>2009.07.08</date>
    /// </author> 
    /// </summary>
    public interface IConfiguration
    {
        String GetValue(String key);
    }
}
