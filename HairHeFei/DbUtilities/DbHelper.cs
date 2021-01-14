//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Windows.Forms;

namespace Sys.DbUtilities
{
    using Sys.Config;

    /// <summary>
    /// DbHelper
    /// 有关数据库连接的方法。
    /// 
    /// 修改纪录
    /// 
    ///		2008.09.03 版本：1.0  创建。
    /// 
    /// 版本：1.2
    /// 
    /// <author>
    ///		<name></name>
    ///		<date>2008.08.26</date>
    /// </author> 
    /// </summary>
    public class DbHelper
    {
        /// <summary>
        /// 数据库连接串，这里是为了简化思路
        /// </summary>
        public static string BusinessDbConnection = BaseSystemInfo.BusinessDbConnection;

        private static readonly IDbHelper dbHelper = DbHelperFactory.GetHelper();

        /// <summary> DbProviderFactory 实例
        /// DbProviderFactory实例
        /// </summary>
        private static DbProviderFactory factory = null;

        /// <summary> DbFactory实例
        /// DbFactory实例
        /// </summary>
        public static DbProviderFactory Factory
        {
            get
            {
                if (factory == null)
                {
                    factory = dbHelper.GetInstance();
                }
                return factory;
            }
        }

        /// <summary> 构造方法
        /// 构造方法
        /// </summary>
        private DbHelper()
        {
        }

        /// <summary> 当前数据库类型
        /// 当前数据库类型
        /// </summary>
        public DataBaseType CurrentDataBaseType
        {
            get
            {
                return dbHelper.CurrentDataBaseType;
            }
        }

        #region public static string GetDBNow() 获得数据库日期时间
        /// <summary>
        /// 获得数据库日期时间
        /// </summary>
        /// <returns>日期时间</returns>
        public static string GetDBNow()
        {
            return dbHelper.GetDBNow();
        }
        #endregion

        #region public static string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public static string SqlSafe(string value)
        {
            return dbHelper.SqlSafe(value);
        }
        #endregion

        #region string PlusSign(params string[] values)  获得Sql字符串相加符号
        /// <summary>
        ///  获得Sql字符串相加符号
        /// </summary>
        /// <param name="values">参数值</param>
        /// <returns>字符加</returns>
        public static string PlusSign(params string[] values)
        {
            return dbHelper.PlusSign(values);
        }
        #endregion

        #region public static string GetParameter(string parameter) 获得参数Sql表达式
        /// <summary>
        /// 获得参数Sql表达式
        /// </summary>
        /// <param name="parameter">参数名称</param>
        /// <returns>字符串</returns>
        public static string GetParameter(string parameter)
        {
            return dbHelper.GetParameter(parameter);
        }
        #endregion

        #region public static DbParameter MakeInParam(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数</returns>
        public static DbParameter MakeInParam(string targetFiled, object targetValue)
        {
            return dbHelper.MakeInParam(targetFiled, targetValue);
        }
        #endregion

        #region public static DbParameter[] MakeParameters(string targetFiled, object targetValue) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public static DbParameter[] MakeParameters(string targetFiled, object targetValue)
        {
            return dbHelper.MakeParameters(targetFiled, targetValue);
        }
        #endregion

        #region public static DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="targetFiled">目标字段</param>
        /// <param name="targetValue">值</param>
        /// <returns>参数集</returns>
        public static DbParameter[] MakeParameters(string[] targetFileds, Object[] targetValues)
        {
            return dbHelper.MakeParameters(targetFileds, targetValues);
        }
        #endregion

        #region public static DbParameter MakeParam(string paramName, DbType DbType, Int32 size, ParameterDirection direction, object value) 获取参数
        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="paramName">参数名称</param>
        /// <param name="DbType">数据类型</param>
        /// <param name="size">大小</param>
        /// <param name="Direction">输出方向</param>
        /// <param name="Value">值</param>
        /// <returns>参数集</returns>
        public static DbParameter MakeParam(string paramName, DbType DbType, Int32 size, ParameterDirection direction, object value)
        {
            return dbHelper.MakeParam(paramName, DbType, size, direction, value);
        }
        #endregion

        #region public static int ExecuteNonQuery(string commandText) 执行查询返回受影响的行数, SQL BUILDER 用了这个东西？参数需要保存, 不能丢失.
        /// <summary>
        /// 执行查询返回受影响的行数, SQL BUILDER 用了这个东西？参数需要保存, 不能丢失.
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, null);
        }
        #endregion

        #region public static int ExecuteNonQuery(string commandText, DbParameter[] dbParameters); 执行查询返回受影响的行数
        /// <summary>
        /// 执行查询返回受影响的行数
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteNonQuery(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static int ExecuteNonQuery(CommandType commandType, string commandText, DbParameter[] dbParameters) 执行查询返回受影响的行数
        /// <summary>
        /// 执行查询返回受影响的行数
        /// </summary>
        /// <param name="CommandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            int returnValue = 0;
            dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteNonQuery(commandType, commandText, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region static public object ExecuteScalar(string commandText) 执行查询返回受首行首列
        /// <summary>
        /// 执行查询返回受首行首列
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>object</returns>
        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(CommandType.Text, commandText, null);
        }
        #endregion

        #region static public object ExecuteScalar(string commandText, DbParameter[] dbParameters) 执行查询返回受首行首列
        /// <summary>
        /// 执行查询返回受首行首列
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>Object</returns>
        public static object ExecuteScalar(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteScalar(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static object ExecuteScalar(CommandType commandType, string commandText, DbParameter[] dbParameters) 执行查询返回受首行首列
        /// <summary>
        /// 执行查询返回受首行首列
        /// </summary>
        /// <param name="CommandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>Object</returns>
        public static object ExecuteScalar(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            object returnValue = null;
            dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteScalar(commandType, commandText, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region public static IDataReader ExecuteReader(string commandText) 执行查询返回DataReader
        /// <summary>
        /// 执行查询返回DataReader
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>结果集流</returns>
        public static IDataReader ExecuteReader(string commandText)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.AutoOpenClose = true;
            return dbHelper.ExecuteReader(commandText);
        }
        #endregion

        #region public static IDataReader ExecuteReader(string commandText, DbParameter[] dbParameters); 执行查询返回DataReader
        /// <summary>
        /// 执行查询返回DataReader
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>结果集流</returns>
        public static IDataReader ExecuteReader(string commandText, DbParameter[] dbParameters)
        {
            return ExecuteReader(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public IDataReader ExecuteReader(string commandText, List<DbParameter> dbParameters); 执行查询返回DataReader
        /// <summary>
        /// 执行查询返回DataReader
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>结果集流</returns>
        public IDataReader ExecuteReader(string commandText, List<DbParameter> dbParameters)
        {
            return ExecuteReader(CommandType.Text, commandText, dbParameters.ToArray());
        }
        #endregion

        #region public static IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters) 执行查询返回DataReader
        /// <summary>
        /// 执行查询返回DataReader
        /// </summary>
        /// <param name="commandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>结果集流</returns>
        public static IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.AutoOpenClose = true;
            return dbHelper.ExecuteReader(commandType, commandText, dbParameters);
        }
        #endregion

        #region public static IDataReader ExecuteReader(CommandType commandType, string commandText, DbParameter[] dbParameters) 执行查询返回DataReader
        /// <summary>
        /// 执行查询返回DataReader
        /// </summary>
        /// <param name="commandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>结果集流</returns>
        public static IDataReader ExecuteReader(CommandType commandType, string commandText, List<DbParameter> dbParameters)
        {
            return ExecuteReader(commandType, commandText, dbParameters.ToArray());
        }
        #endregion

        #region public static DataTable Fill(string commandText) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">查询</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(string commandText)
        {
            DataTable dataTable = new DataTable();
            Fill(dataTable, CommandType.Text, commandText, null);
            return dataTable;
        }
        #endregion

        #region public static DataTable Fill(DataTable dataTable, string commandText) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="dataTable">目标数据表</param>
        /// <param name="commandText">查询</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(DataTable dataTable, string commandText)
        {
            return Fill(dataTable, CommandType.Text, commandText, null);
        }
        #endregion

        #region public static DataTable Fill(string commandText, DbParameter[] dbParameters) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(string commandText, DbParameter[] dbParameters)
        {
            return dbHelper.Fill(CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static DataTable Fill(DataTable dataTable, string commandText, DbParameter[] dbParameters) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="dataTable">目标数据表</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(DataTable dataTable, string commandText, DbParameter[] dbParameters)
        {
            return dbHelper.Fill(dataTable, CommandType.Text, commandText, dbParameters);
        }
        #endregion

        #region public static DataTable Fill(DataTable dataTable, CommandType commandType, string commandText, DbParameter[] dbParameters) 填充数据表
        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="dataSet">目标数据表</param>
        /// <param name="CommandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        public static DataTable Fill(DataTable dataTable, CommandType commandType, string commandText, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataTable, commandType, commandText, dbParameters);
            dbHelper.Close();
            return dataTable;
        }
        #endregion

        #region public static DataTable FillSchema(string dataTableName) 填充数据表结构
        /// <summary>
        /// 填充数据表结构
        /// </summary>
        /// <param name="dataTableName">目标数据表名称</param>
        /// <returns>带有结构的空数据表</returns>
        public static DataTable FillSchema(string dataTableName)
        {
            dbHelper.Open(BusinessDbConnection);
            DataTable dataTable = dbHelper.FillSchema(dataTableName);
            dbHelper.Close();
            return dataTable;
        }
        #endregion

        #region public static DataSet Fill(DataSet dataSet, string commandText, string tableName) 填充数据集
        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="dataSet">目标数据集</param>
        /// <param name="commandText">查询</param>
        /// <param name="tableName">填充表</param>
        /// <returns>数据集</returns>
        public static DataSet Fill(DataSet dataSet, string commandText, string tableName)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataSet, commandText, tableName);
            dbHelper.Close();
            return dataSet;
        }
        #endregion

        #region static public DataSet Fill(DataSet dataSet, string commandText, string tableName, DbParameter[] dbParameters) 填充数据集
        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="dataSet">数据集</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="tableName">填充表</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据集</returns>
        public static DataSet Fill(DataSet dataSet, string commandText, string tableName, DbParameter[] dbParameters)
        {
            return Fill(dataSet, CommandType.Text, commandText, tableName, dbParameters);
        }
        #endregion

        #region public static DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, DbParameter[] dbParameters) 填充数据集
        /// <summary>
        /// 填充数据集
        /// </summary>
        /// <param name="dataSet">数据集</param>
        /// <param name="CommandType">命令分类</param>
        /// <param name="commandText">sql查询</param>
        /// <param name="tableName">填充表</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据集</returns>
        public static DataSet Fill(DataSet dataSet, CommandType commandType, string commandText, string tableName, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            dbHelper.Fill(dataSet, commandType, commandText, tableName, dbParameters);
            dbHelper.Close();
            return dataSet;
        }
        #endregion

        #region public static int ExecuteProcedure(string procedureName) 执行存储过程
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procedureName">存储过程</param>
        /// <returns>int</returns>
        public static int ExecuteProcedure(string procedureName)
        {
            return ExecuteProcedure(procedureName, null);
        }
        #endregion

        #region public static int ExecuteProcedure(string procedureName, DbParameter[] dbParameters) 执行存储过程
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procedureName">存储过程名</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        public static int ExecuteProcedure(string procedureName, DbParameter[] dbParameters)
        {
            int returnValue = 0;
            dbHelper.Open(BusinessDbConnection);
            returnValue = dbHelper.ExecuteProcedure(procedureName, dbParameters);
            dbHelper.Close();
            return returnValue;
        }
        #endregion

        #region public static DataSet ExecuteProcedureForDataTable(string procedureName, string tableName, DbParameter[] dbParameters) 执行存储过程返回数据表
        /// <summary>
        /// 执行存储过程返回数据表
        /// </summary>
        /// <param name="dataSet">数据集</param>
        /// <param name="procedureName">存储过程</param>
        /// <param name="tableName">填充表</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据集</returns>
        public static DataTable ExecuteProcedureForDataTable(string procedureName, string tableName, DbParameter[] dbParameters)
        {
            dbHelper.Open(BusinessDbConnection);
            DataTable dataTable = dbHelper.ExecuteProcedureForDataTable(procedureName, tableName, dbParameters);
            dbHelper.Close();
            return dataTable;
        }
        #endregion

    }
}