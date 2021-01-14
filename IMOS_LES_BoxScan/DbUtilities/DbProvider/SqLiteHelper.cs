//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;

namespace Sys.DbUtilities
{
        using System.Data.SQLite;
    
    /// <summary>
    /// SQLite 数据库操作
    /// 有关数据库连接的方法。
    /// 
    /// 修改纪录
    ///
    ///		2010.10.18 版本：1.0 yanzi 创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>yanzi</name>
    ///		<date>2010.10.18</date>
    /// </author> 
    /// </summary>
    
    public class SqLiteHelper:BaseDbHelper,IDbHelper
    {
        #region   构造方法

        public SqLiteHelper()
        {
            FileName = "SQLite.txt";   // sql查询句日志
        }

        /// <summary>
		/// 数据库连接
		/// </summary>
        /// <param name="connectionString">数据连接</param>
        public SqLiteHelper(string connectionString)
            : this()
		{
            this.ConnectionString = connectionString;
		}
        #endregion

        #region  public override DbProviderFactory GetInstance() 当前数据库实例
        /// <summary>
        /// 当前数据库实例
        /// </summary>
        /// <returns></returns>
        public override DbProviderFactory GetInstance()
        {
            return SQLiteFactory.Instance;
        }
        #endregion 

        #region 当前数据库类型
        /// <summary>
        /// 当前数据库类型
        /// </summary>
        public DataBaseType CurrentDataBaseType
        {
            get
            {
                return DataBaseType.SQLite;
            }
        }
        #endregion 

        #region public string GetDBNow() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public string GetDBNow()
        {
            return "datetime('now');";
        }
        #endregion

        #region public string GetDBDateTime() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public string GetDBDateTime()
        {
            string commandText = " SELECT " + this.GetDBNow();
            this.Open();
            string dateTime = this.ExecuteScalar(CommandType.Text, commandText, new DbParameter[0]).ToString();
            this.Close();
            return dateTime;
        }
        #endregion

        #region public string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public string SqlSafe(string value)
        {
            value = value.Replace("'", "''");
            // value = value.Replace("%", "'%");
            return value;
        }
        #endregion

        #region public DbParameter MakeInParam(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数</returns>
        public DbParameter MakeInParam(string targetFiled, object targetValue)
        {
            return new SQLiteParameter(targetFiled, targetValue);
        }
        #endregion

        #region public DbParameter[] MakeParameters(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public DbParameter[] MakeParameters(string targetFiled, object targetValue)
        {
            DbParameter[] dbParameters = null;
            if (targetFiled != null && targetValue != null)
            {
                dbParameters = new DbParameter[1];
                dbParameters[0] = this.MakeInParam(targetFiled, targetValue);
            }
            return dbParameters;
        }
        #endregion

        #region public DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        {
            DbParameter[] dbParameters = new DbParameter[0];
            if (targetFileds != null && targetValues != null)
            {
                dbParameters = new DbParameter[targetFileds.Length];
                for (int i = 0; i < targetFileds.Length; i++)
                {
                    if (targetFileds[i] != null && targetValues[i] != null)
                    {
                        dbParameters[i] = this.MakeInParam(targetFileds[i], targetValues[i]);
                    }
                }
            }
            return dbParameters;
        }
        #endregion

        #region public DbParameter MakeOutParam(string paramName, DbType dbType, int size) 获取输出参数
        /// <summary>
        /// 获取输出参数
        /// </summary>
        /// <param name="paramName">目标字段</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">长度</param>
        /// <returns>参数</returns>
        public DbParameter MakeOutParam(string paramName, DbType dbType, int size)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Output, null);
        }
        #endregion

        #region public DbParameter MakeInParam(string paramName, DbType dbType, int size, object value) 获取输出参数
        /// <summary>
        /// 获取输出参数
        /// </summary>
        /// <param name="paramName">目标字段</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">长度</param>
        /// <param name="value">值</param>
        /// <returns>参数</returns>
        public DbParameter MakeInParam(string paramName, DbType dbType, int size, object value)
        {
            return MakeParam(paramName, dbType, size, ParameterDirection.Input, value);
        }
        #endregion

        #region public DbParameter MakeParam(string paramName, DbType dbType, Int32 dize, ParameterDirection direction, object value) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="paramName">目标字段</param>
        /// <param name="dbType">数据类型</param>
        /// <param name="size">长度</param>
        /// <param name="direction">参数类型</param>
        /// <param name="value">值</param>
        /// <returns>参数</returns>
        public DbParameter MakeParam(string paramName, DbType dbType, Int32 size, ParameterDirection direction, object value)
        {
            SQLiteParameter parameter;

            if (size > 0)
            {
                parameter = new SQLiteParameter(dbType, size, paramName);
            }
            else
            {
                parameter = new SQLiteParameter(paramName, (DbType)dbType);
            }

            parameter.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
            {
                parameter.Value = value;
            }

            return parameter;
        }
        #endregion

        #region public string GetParameter(string parameter) 获得参数Sql表达式
        /// <summary>
        /// 获得参数Sql表达式
        /// </summary>
        /// <param name="parameter">参数名称</param>
        /// <returns>字符串</returns>
        public string GetParameter(string parameter)
        {
            return " ?" + parameter;
        }
        #endregion

        #region string PlusSign(params string[] values) 获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <param name="values">参数值</param>
        /// <returns>字符加</returns>
        public string PlusSign(params string[] values)
        {
            string returnValue = string.Empty;
            returnValue = " CONCAT(";
            for (int i = 0; i < values.Length; i++)
            {
                returnValue += values[i] + " ,";
            }
            returnValue = returnValue.Substring(0, returnValue.Length - 2);
            returnValue += ")";
            return returnValue;
        }
        #endregion
    }
}