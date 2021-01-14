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
    using Sys.Config;
    public class DataHelper
    {
        public static string BusinessDBConnection = BaseSystemInfo.BusinessDbConnection;
        public static string ServerConnection = BaseSystemInfo.ServerDbConnection;

        public static OracleConnection OracledbConn; //Oracle
        public static OracleConnection OracleServerConn; //Oracle
        public static OracleConnection OracledbReConn; //Oracle

        public static SqlConnection SqlConn; //SQL
        public static SqlConnection LocalSqlConn; //SQL
        public static SqlConnection ServerSqlConn; //SQL

        public static SqlConnection SqlReConn;//SQL

        public static bool DBConn;
        public static DataSet Fill(string commandText)
        {
     
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                return NewOracleHelper.ExecuteDataset(OracledbConn, CommandType.Text, commandText);
            }
            else
            {
                //DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                //dt = DbHelper.Fill(commandText);
                //ds.Tables.Add(dt);
                //return ds;
             
                return SqlHelper.ExecuteDataset(SqlConn, CommandType.Text, commandText);
            }
        }

        public static DataSet LocalFill(string commandText)
        {
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                return NewOracleHelper.ExecuteDataset(OracledbConn, CommandType.Text, commandText);
            }
            else
            {
                //DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                //dt = DbHelper.Fill(commandText);
                //ds.Tables.Add(dt);
                //return ds;
                return SqlHelper.ExecuteDataset(LocalSqlConn, CommandType.Text, commandText);
            }
        }

        public static DataSet ServerFill(string commandText)
        {
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                return NewOracleHelper.ExecuteDataset(OracleServerConn, CommandType.Text, commandText);
            }
            else
            {
                //DataSet ds = new DataSet();
                //DataTable dt = new DataTable();
                //dt = DbHelper.Fill(commandText);
                //ds.Tables.Add(dt);
                //return ds;
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
            else
            {
                bool r1 = false;
                bool r2 = false;
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

                try
                {
                    LocalSqlConn = new SqlConnection(BusinessDBConnection);
                    LocalSqlConn.Open();
                    r2 = true;
                }
                catch (Exception ex)
                {
                    if (LocalSqlConn.State != ConnectionState.Closed)
                        LocalSqlConn.Close();
                    r2 = false;
                }

                return r1 && r2; 
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
            else
            {
                try
                {
                    ServerSqlConn = new SqlConnection(ServerConnection);
                    ServerSqlConn.Open();
                    return true;
                }
                catch (Exception)
                {
                    if (ServerSqlConn.State != ConnectionState.Closed)
                        ServerSqlConn.Close();
                    return false;
                }
            }

        }

        public static bool DBReConnection()//数据库链接
        {
            if (BaseSystemInfo.DataBaseType == "Oracle")
            {
                try
                {
                    OracledbReConn = new OracleConnection(BusinessDBConnection);
                    OracledbReConn.Open();
                    if (OracledbReConn.State != ConnectionState.Closed)
                        OracledbReConn.Close();
                    return true;
                }
                catch (Exception)
                {
                    if (OracledbReConn.State != ConnectionState.Closed)
                        OracledbReConn.Close();

                    return false;
                }
            }
            else
            {
                try
                {
                    SqlReConn = new SqlConnection(BusinessDBConnection);
                    SqlReConn.Open();
                    if (SqlReConn.State != ConnectionState.Closed)
                        SqlReConn.Close();
                    return true;
                }
                catch (Exception)
                {
                    if (SqlReConn.State != ConnectionState.Closed)
                        SqlReConn.Close();

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

                    if (LocalSqlConn.State != ConnectionState.Closed)
                        LocalSqlConn.Close();
                    LocalSqlConn.Open();
                    return true;
                }
                catch (Exception)
                {
                    if (SqlConn.State != ConnectionState.Closed)
                        SqlConn.Close();

                    if (LocalSqlConn.State != ConnectionState.Closed)
                        LocalSqlConn.Close();
                    return false;
                }
            }


        }
    }
}
