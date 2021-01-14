using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Sys.Config;

namespace UI_Support
{
    public class DataHelper
    {
        //static string constr = @"Server=ZHOUJ\MSSQLSERVER2008;database=Haier_JNDR;user=sa;pwd=yufan3377;MultipleActiveResultSets=true";
       // static string constr = @"Server=192.168.2.177;Database=Haier_JNDR;user=sa;pwd=yufan3377;MultipleActiveResultSets=true";
          static string constr = BaseSystemInfo.BusinessDbConnection;

        public static DataSet Fill(string sql)
        {
            
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                    da.Dispose();
                }
            }
            if (con.State != ConnectionState.Closed)
                con.Close();
            return ds;
        }

        public static DataSet ExecuteProcedure(string procedureName, string[] tableNames, DbParameter[] dbParameters)
        {
            //string constr = @"Server=ZHOUJ\MSSQLSERVER2008;database=Haier_JNDR;user=sa;pwd=yufan3377;MultipleActiveResultSets=true";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            using (SqlCommand cmd = new SqlCommand(procedureName, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if ((dbParameters != null) && (dbParameters.Length > 0))
                {
                    cmd.Parameters.AddRange(dbParameters);
                }

                try
                {
                    using (IDataReader reader = cmd.ExecuteReader())
                        ds.Load(reader, LoadOption.Upsert, tableNames);
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                    throw new Exception("异常提示！" + ex.Message);
                }
            }
            if (con.State != ConnectionState.Closed)
                con.Close();
            return ds;
        }

        public static int ExecStoredProcedure(string procedureName, DbParameter[] dbParameters)
        {
            //string constr = @"Server=ZHOUJ\MSSQLSERVER2008;database=Haier_JNDR;user=sa;pwd=yufan3377;MultipleActiveResultSets=true";
            int rowCount = 0;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            using (SqlCommand cmd = new SqlCommand(procedureName, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if ((dbParameters != null) && (dbParameters.Length > 0))
                {
                    cmd.Parameters.AddRange(dbParameters);
                }
                try
                {
                    rowCount = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                    throw new Exception("异常提示！" + ex.Message);
                }
            }
            if (con.State != ConnectionState.Closed)
                con.Close();
            return rowCount;
        }

    }
}
