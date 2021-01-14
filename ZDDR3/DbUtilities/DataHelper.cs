using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data.Common;

namespace Sys.DbUtilities
{
    using Config;
    using MySql.Data.MySqlClient;

    public class DataHelper
    {
        public static string BusinessDBConnection = BaseSystemInfo.BusinessDbConnection;
        public static string ServerConnection = BaseSystemInfo.ServerDbConnection;

        public static OracleConnection OracledbConn; //Oracle
        public static OracleConnection OracleServerConn; //Oracle
        public static OracleConnection OracledbReConn; //Oracle

        public static SqlConnection SqlConn; //SQL
        public static SqlConnection ServerSqlConn; //SQL

        public static MySqlConnection MySqlConn;
        public static MySqlConnection MySqlServerConn;

        public static SqlConnection SqlReConn;//SQL

        public static bool DBConn;
        public static DataSet Fill(string commandText)
        {

            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                return NewOracleHelper.ExecuteDataset(OracledbConn, CommandType.Text, commandText);
            }
            else if (BaseSystemInfo.DataBaseType == "MySql")
            {
                return MySqlHelper.ExecuteDataset(MySqlConn, CommandType.Text, commandText);
            }
            else
            {
                return SqlHelper.ExecuteDataset(SqlConn, CommandType.Text, commandText);
            }
        }


        public static DataSet ServerFill(string commandText)
        {
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                return NewOracleHelper.ExecuteDataset(OracleServerConn, CommandType.Text, commandText);
            }
            else if (BaseSystemInfo.DataBaseType == "MySql")
            {
                return MySqlHelper.ExecuteDataset(MySqlServerConn, CommandType.Text, commandText);
            }
            else
            {
                return SqlHelper.ExecuteDataset(ServerSqlConn, CommandType.Text, commandText);
            }
        }

        public static DataSet ExecuteProcedure(string procedureName, string[] tableNames, DbParameter[] dbParameters)
        {
            return SqlHelper.ExecuteProcedure(SqlConn, procedureName, tableNames, dbParameters);

        }
        public static DataSet ExecuteProcedure(SqlConnection connection, string procedureName, string[] tableNames, DbParameter[] dbParameters)
        {

            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(procedureName, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if ((dbParameters != null) && (dbParameters.Length > 0))
                {
                    cmd.Parameters.AddRange(dbParameters);
                }
                using (IDataReader reader = cmd.ExecuteReader())
                    ds.Load(reader, LoadOption.Upsert, tableNames);
                //Liucl-20180118-Add
                cmd.Parameters.Clear();
            }
            return ds;
        }


        public static DataSet MySqlFill(string commandText)
        {
            return MySqlHelper.ExecuteDataset(MySqlServerConn, CommandType.Text, commandText);

        }

        public static bool DBConnection()//数据库链接
        {
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                try
                {
                    OracledbConn = new OracleConnection(BusinessDBConnection);
                    OracledbConn.Open();
                    return true;
                }
                catch (Exception)
                {
                    if (OracledbConn.State != ConnectionState.Closed)
                        OracledbConn.Close();
                    return false;
                }
            }
            else if (BaseSystemInfo.DataBaseType == "MySql")
            {
                try
                {
                    MySqlConn = new MySqlConnection(BusinessDBConnection);
                    MySqlConn.Open();

                    return true;
                }
                catch (Exception)
                {
                    if (MySqlConn.State != ConnectionState.Closed)
                        MySqlConn.Close();
                    return false;
                }
            }
            else
            {
                bool r1 = false;
                try
                {
                    SqlConn = new SqlConnection(BusinessDBConnection);
                    SqlConn.Open();

                    r1 = true;
                }
                catch (Exception ex)
                {
                    if (SqlConn.State != ConnectionState.Closed)
                        SqlConn.Close();

                    r1 = false;
                }
                return r1;
            }

        }

        public static bool DBServerConnection()//数据库链接
        {
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                try
                {
                    OracleServerConn = new OracleConnection(ServerConnection);
                    OracleServerConn.Open();
                    return true;
                }
                catch (Exception)
                {
                    if (OracleServerConn.State != ConnectionState.Closed)
                        OracleServerConn.Close();
                    return false;
                }
            }
            else if (BaseSystemInfo.ServerDataBaseType == "MySql")
            {
                try
                {
                    MySqlServerConn = new MySqlConnection(ServerConnection);
                    MySqlServerConn.Open();

                    return true;
                }
                catch (Exception)
                {
                    if (MySqlServerConn.State != ConnectionState.Closed)
                        MySqlServerConn.Close();
                    return false;
                }
            }
            else
            {
                try
                {
                    ServerSqlConn = new SqlConnection(ServerConnection);
                    ServerSqlConn.Open();

                    return true;
                }
                catch (Exception ex)
                {
                    if (ServerSqlConn.State != ConnectionState.Closed)
                        ServerSqlConn.Close();
                    return false;
                }
            }

        }

        public static bool RefreshDBConn()//数据库链接
        {
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                try
                {
                    if (OracledbConn.State != ConnectionState.Closed)
                        OracledbConn.Close();
                    OracledbConn.Open();
                    return true;
                }
                catch (Exception)
                {
                    if (OracledbConn.State != ConnectionState.Closed)
                        OracledbConn.Close();
                    return false;
                }
            }
            else
            {
                try
                {
                    if (SqlConn.State != ConnectionState.Closed)
                        SqlConn.Close();
                    SqlConn.Open();


                    return true;
                }
                catch (Exception)
                {
                    if (SqlConn.State != ConnectionState.Closed)
                        SqlConn.Close();

                    return false;
                }
            }


        }
    }
}
