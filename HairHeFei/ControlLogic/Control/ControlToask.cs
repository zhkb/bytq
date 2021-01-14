using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;

namespace ControlLogic.Control
{
    public class ControlToask
    {
        private static bool flag = true;
        public static System.Threading.Timer RefreshTimer;  //刷新
        public static void SystemInitialization()
        {
            try
            {
                RefreshTimer = new System.Threading.Timer(RefreshData, null, 0, Timeout.Infinite);
                //RefreshData();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("异常处理"+ex.Message);
            }
        }
        private static void RefreshData(object state)
        {
            try
            {
                //通过PLC获取Toask
                int Address = 0;
                object[] RBuf = new object[40];
                bool result = ControlMaster.ReadData(0, Address, 40, out RBuf);
               
                if (!result)
                {
                    if (flag)
                    {
                        SysBusinessFunction.WriteLog("PLC连接失败！");
                        flag = false;
                    }
                        return;                  
                }
                flag = true;
                for (int i = 0; i < 40; i = i + 2)
                {

                    if (1 == int.Parse(RBuf[i].ToString()) && int.Parse(RBuf[i + 1].ToString()) == 0)
                    {
                        // 当握手信号为1 时新建 任务
                        //通过PLC地址来获取工位号
                        int st_no = (i + 2) / 2;
                        string station_no = "";
                        if (st_no < 10)
                        {
                            station_no = "A0" + st_no;
                        }
                        else
                        {
                            station_no = "A" + st_no;
                        }
                        string material_code = "";
                        string material_name = "";
                        //通过工位号获取名称编号
                        string selSql = String.Format(@"SELECT
	                                                        Material_Code,
	                                                        Material_Name
                                                        FROM
	                                                        IMOS_Pr_Foaming
                                                        WHERE
	                                                        Station_No = '{0}'", station_no);
                        DataSet ds = DataHelper.Fill(selSql);

                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            material_code = ds.Tables[0].Rows[0]["Material_Code"].ToString().Trim();
                            material_name = ds.Tables[0].Rows[0]["Material_Name"].ToString().Trim();
                        }
                        else
                        {
                            return;
                        }

                        String sql = String.Format(@"INSERT INTO IMOS_Lo_Task (
	                                                                        Company_Code,
	                                                                        Company_Name,
	                                                                        Factory_Code,
	                                                                        Factory_Name,
	                                                                        Product_Line_Code,
	                                                                        Product_Line_Name,
	                                                                        Station_No,
	                                                                        Material_Code,
	                                                                        Material_Name,
	                                                                        Delete_Flag
                                                                        )
                                                                        VALUES
	                                                                        ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',0)",
                                                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName,
                                                                            BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName, station_no, material_code, material_name);
                        DataHelper.Fill(sql);
                        //置2
                        object[] WBuf = new object[1];
                        WBuf[0] = 2;
                        ControlMaster.WriteData(0, i + 1, WBuf);
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取注料枪口任务信息失败！"+ex.Message);
            }
            finally
            {
                RefreshTimer.Change(3000, Timeout.Infinite);
            }

        }
    }
}
