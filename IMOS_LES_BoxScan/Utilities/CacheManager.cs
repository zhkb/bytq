﻿//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace Sys.Utilities
{

    /// <summary>
    /// CacheManager
    /// Assembly 缓存服务
    /// 
    /// 修改纪录
    /// 
    ///		2008.06.05 版本：1.0  创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name></name>
    ///		<date>2008.06.05</date>
    /// </author> 
    /// </summary>
    public class CacheManager
    {
        private CacheManager()
        {
        }

        private Hashtable ObjectCacheStore = new Hashtable(); 

        private static CacheManager instance = null;
        private static object locker = new Object();

        public static CacheManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new CacheManager();
                        }
                    }
                }
                return instance;
            }
        }

        /// <summary>
        /// 获得一个窗体
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="formName">窗体名</param>
        /// <returns>窗体</returns>
        public Form GetForm(string assemblyName, string formName)
        {
            Type type = this.GetType(assemblyName, formName);
            return (Form)Activator.CreateInstance(type);
        }

        public Type GetType(string assemblyName, string name)
        {
            Assembly assembly = this.Load(assemblyName);
            Type type = assembly.GetType(assemblyName + "." + name, false, true);
            return type;
        }

        /// <summary>
        /// 反射显示窗体
        /// </summary>
        /// <param name="assemblyName">命名空间</param>
        /// <param name="formName">窗体名称</param>
        /// <returns>对象</returns>
        public object CreateInstance(string assemblyName, string formName)
        {
            // 这里用了缓存技术，若已经被创建过就不反复创建了
            Assembly assembly = this.Load(assemblyName);
            Type type = assembly.GetType(assemblyName + "." + formName, true, false);
            return Activator.CreateInstance(type);
        }

        /// <summary>
        /// 加载 Assembly
        /// </summary>
        /// <param name="assemblyName">命名空间</param>
        /// <returns>Assembly</returns>
        public Assembly Load(string assemblyName)
        {
            Assembly assembly = null;
            if (this.ObjectCacheStore.ContainsKey(assemblyName))
            {
                assembly = (Assembly)this.ObjectCacheStore[assemblyName];
            }
            else
            {
                assembly = Assembly.Load(assemblyName);
                this.ObjectCacheStore.Add(assemblyName, assembly);
            }
            return assembly;
        }

        public void Add(string key, object storeObject)
        {
            if (!this.ObjectCacheStore.ContainsKey(key))
            {
                this.ObjectCacheStore.Add(key, storeObject);
            }
        }

        public object Retrieve(string key)
        {
            return this.ObjectCacheStore[key];
        }
    }
}