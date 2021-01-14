using Communication;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ControlLogic.Control
{
    public class ControlInStore
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        private static System.Threading.Timer GetLeftTaskTimer; //查找数据库任务表
        private static System.Threading.Timer GetRightTaskTimer; //查找数据库任务表
        private static String oldLeftTaskID = "";
        private static String oldRightTaskID = "";
        private static int leftdoCount = 0;
        private static int rightdoCount = 0;
        private static System.Threading.Timer GetLeftInStorePLCTimer;//获取左入库的成功信号
        private static System.Threading.Timer GetRightInStorePLCTimer;//获取右入库的成功信号
        public static System.Threading.Timer TestStoreTimer; //测试信号
        public static void SystemInitialization()
        {
            GetLeftTaskTimer = new System.Threading.Timer(GetLeftDBDevice, null, 0, 3000);
            GetRightTaskTimer = new System.Threading.Timer(GetRightDBDevice, null, 0, 3000);
            GetLeftInStorePLCTimer = new System.Threading.Timer(GetLeftPLCDevice, null, 0, 3000);
            GetRightInStorePLCTimer = new System.Threading.Timer(GetRightPLCDevice, null, 0, 3000);
            TestStoreTimer = new System.Threading.Timer(TestPLCDevice, null, 0, Timeout.Infinite);
        }

        #region 获取入库Task 


        private static void GetLeftDBDevice(object state)
        {
            try
            {
                
                //    D100：反馈信号 0默认 1下传 2 上传     1个字
                //    D101：计划号(双字)        2个字              
                //    D103: 库位号     1个字                  
                //    D104：排号       1个字                  
                //    D105：列号       1个字                            
                //    D106: 层号       1个字                 
                //    D107：备用 3个字  
                StoreWPLC(0, 100, 10, "1");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetLeftTaskTimer.Change(3000, Timeout.Infinite);
            }

        }

        private static void GetRightDBDevice(object state)
        {
            try
            {
                //    D110：反馈信号 0默认 1下传 2 上传     1个字
                //    D111：计划号(双字)        2个字              
                //    D113: 库位号     1个字                  
                //    D114：排号       1个字                  
                //    D115：列号       1个字                            
                //    D116: 层号       1个字                 
                //    D117：备用 3个字  
                StoreWPLC(0,110,10,"2");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetRightTaskTimer.Change(1000, Timeout.Infinite);
            }

        }

        #endregion


        //1.接受入库成功PLC信号
   
        //2.修改状态信息（Task  Detail）
        #region 获取入库PLC信号
        private static void GetLeftPLCDevice(object state)
        {
            try
            {
                //   D150 反馈信息  PLC上传1 上位机接受后置为2        1个字
                //   D151 计划号                                      2个字
                //   D153 结果   1入库成功 2 入库失败 3 出现异常      1个字
                //   D154 库位号                                      1个字
                //   D155 排号                                        1个字
                //   D156 列号                                        1个字
                //   D157 层号                                        1个字
                //   D158 反馈信息 1入库成功 2 入库失败 接受后置为3   2个字

                InStorePLC(0,150,10, 1);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetLeftInStorePLCTimer.Change(3000, Timeout.Infinite);
            }

        }

        private static void GetRightPLCDevice(object state)
        {
            try
            {
                //   D160 反馈信息 PLC上传1 上位机接受后置为2         1个字
                //   D161 计划号                                      2个字
                //   D163 结果   1入库成功 2 入库失败 3 出现异常      1个字
                //   D164 库位号                                      1个字
                //   D165 排号                                        1个字
                //   D166 列号                                        1个字
                //   D167 层号                                        1个字
                //   D168 反馈信息 1入库成功 2 入库失败 接受后置为3   2个字
                InStorePLC(0, 160, 10, 2);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetRightInStorePLCTimer.Change(3000, Timeout.Infinite);
            }

        }
        #endregion


        #region 入库PLC成功标志
        private static void InStorePLC(int block,int address,int len,int type){
            try
            {
                object[] ReadBuff = new object[len];
                //接受反馈信号
                bool flag = ControlMaster.ReadData(block, address, len, out ReadBuff);
                if (!flag)
                {
                    SysBusinessFunction.WriteLog("接受入库结果信息时PLC连接中断！");
                    return;
                }
                if (ReadBuff[0].ToString() == "1")
                {

                    SysBusinessFunction.WriteLog("接受【"+ReadBuff[4].ToString()+"】入库结果信息成功！");
                    //获取计划号
                    String PlanNo = "";
                    ushort P1;
                    ushort P2;
                    if (BaseSystemInfo.PLCType == "2")//西门子
                    {
                        P1 = ushort.Parse(ReadBuff[1] == null ? "0" : ReadBuff[1].ToString());
                        P2 = ushort.Parse(ReadBuff[2] == null ? "0" : ReadBuff[2].ToString());
                    }
                    else//三菱
                    {
                        P1 = ushort.Parse(ReadBuff[2] == null ? "0" : ReadBuff[2].ToString());
                        P2 = ushort.Parse(ReadBuff[1] == null ? "0" : ReadBuff[1].ToString());
                    }
                    if (P1 == 0 && P2 == 0)
                    {
                        PlanNo = "";
                    }
                    else
                    {
                        Decimal intdec = P2 * 65536 + P1;
                        PlanNo = intdec.ToString();
                    }
                    int Rkflag = -1;
                    //读取入库结果 : 入库成功
                    if ("1" == ReadBuff[3].ToString())
                    {
                        SysBusinessFunction.WriteLog("计划号【"+PlanNo+"】库位【"+ReadBuff[4].ToString()+"入库成功！");
                        Rkflag = ChStore(PlanNo, ReadBuff);
                    }
                    //读取入库结果 : 入库失败
                    else if ("2" == ReadBuff[3].ToString())
                    {

                        Rkflag = 4;
                    }
                    //入库结果: 入库异常
                    else
                    {
                        
                        Rkflag = 4;
                    }

                    //String sql = String.Format("");
                    // DataHelper.ExecuteProcedure("DEL_TEMPORARY_TASK", new System.Data.OracleClient.OracleParameter[0]);
                    //String sql = String.Format(@"UPDATE IMOS_LO_TASK
                    //                                            SET TASK_STATE = '{0}'
                    //                                            WHERE
                    //                                             USE_FLAG = '{1}'
                    //                                            AND TASK_STATE = {2}
                    //                                            AND PLAN_NO = {3}",
                    //                                            "2", "1", Rkflag.ToString(), PlanNo);
                    // DataHelper.Fill(sql);
                    System.Data.OracleClient.OracleParameter[] values = {
                                    new System.Data.OracleClient.OracleParameter("USE_FLAG","1"),
                                    new System.Data.OracleClient.OracleParameter("TASK_TYPE", "I"),
                                    new System.Data.OracleClient.OracleParameter("OLD_TASK_STATE","0"),
                                    new System.Data.OracleClient.OracleParameter("TASK_ID", PlanNo),
                                    new System.Data.OracleClient.OracleParameter("NEW_TASK_STATE", "1")
                                    };
                    DataHelper.ExecuteProcedure("UPD_ALL_TASK", values);

                    //回写清空
                    object[] WBuff = new object[10];
                    for(int i = 0; i < 10; i++)
                    {
                        WBuff[i] = 0;
                    }
                    ControlMaster.WriteData(block,address,WBuff);

                }

            }
            catch(Exception ex)
            {

            }
          }
        #endregion


        #region 预入库下传PLC
        //1.查询数据库Task入库表 找到最远的入库记录
        //2.验证入库记录是否没变，(超过三次表示下传失败，进行报警处理)
        //3.验证通过后下传PLC
  

        //4.接受反馈信号成功，修改Task表为入库中
        //
        private static void StoreWPLC(int block, int address, int len, string StoreFlag)
        {
            try
            {
                #region 查询入库Task
                String sql = "";
                if(StoreFlag == "1")
                {
                    sql = String.Format(@"SELECT
	                                            TASK_ID,
	                                            PLAN_NO,
	                                            TASK_END,
	                                            START_TIME
                                            FROM
	                                            IMOS_LO_TEMPORARY_TASK
                                            WHERE
	                                            USE_FLAG = '{0}'
                                            AND TASK_FROM = '{1}'
                                            AND TASK_TYPE = '{2}'
                                            AND TASK_STATE = {3}
                                            AND AUTO_FLAG = {4}
                                            ORDER BY
	                                            START_TIME", "1",BaseSystemInfo.TaskFrom1, "I", "0", "2");
                }
                else
                {
                    sql = String.Format(@"SELECT
	                                            TASK_ID,
	                                            PLAN_NO,
	                                            TASK_END,
	                                            START_TIME
                                            FROM
	                                            IMOS_LO_TEMPORARY_TASK
                                            WHERE
	                                            USE_FLAG = '{0}'
                                            AND TASK_FROM = '{1}'
                                            AND TASK_TYPE = '{2}'
                                            AND TASK_STATE = {3}
                                            AND AUTO_FLAG = {4}
                                            ORDER BY
	                                            START_TIME", "1", BaseSystemInfo.TaskFrom2, "I", "0", "2");
                }
                DataSet ds = DataHelper.Fill(sql);
                #endregion

                if (ds != null && ds.Tables[0].Rows.Count != 0)
                {
                    //判断是否重复任务
                    if ("1" == StoreFlag)//左库
                    {
                        if (oldLeftTaskID == ds.Tables[0].Rows[0]["TASK_ID"].ToString())
                        {
                            leftdoCount++;
                            SysBusinessFunction.WriteLog("左库下传PLC入库任务失败，失败次数【" + leftdoCount + "】");
                            if (leftdoCount > 3)
                            {
                                //报警处理程序
                                //SysBusinessFunction.SystemDialog(2, "下传PLC执行任务失败，失败次数【" + doCount + "】");
                            }
                        }
                        else
                        {
                            //下传PLC执行成功，计数清零
                            leftdoCount = 0;
                            oldLeftTaskID = ds.Tables[0].Rows[0]["TASK_ID"].ToString();
                        }
                    }
                     {
                        if (oldRightTaskID == ds.Tables[0].Rows[0]["TASK_ID"].ToString())
                        {
                            rightdoCount++;
                            SysBusinessFunction.WriteLog("右库下传PLC入库任务失败，失败次数【" + rightdoCount + "】");
                            if (rightdoCount > 3)
                            {                                //报警处理程序
                                //SysBusinessFunction.SystemDialog(2, "下传PLC执行任务失败，失败次数【" + doCount + "】");
                            }
                        }
                        else
                        {
                            //下传PLC执行成功，计数清零
                            rightdoCount = 0;
                            oldLeftTaskID = ds.Tables[0].Rows[0]["TASK_ID"].ToString();
                        }
                    }

                    //查询目的库位的信息
                    object[] DownBuff = new object[len];
                    object[] ReadBuff = new object[1];
                    double dec = Double.Parse(ds.Tables[0].Rows[0]["PLAN_NO"].ToString());
                    if (BaseSystemInfo.PLCType == "1")//三菱
                    {
                        DownBuff[2] = dec % 65536;
                        DownBuff[1] = (int)dec / 65536;
                    }
                    else//西门子
                    {
                        DownBuff[1] = dec % 65536;
                        DownBuff[2] = (int)dec / 65536;
                    }

                    DownBuff[0] = 1;
                    DownBuff[3] = ds.Tables[0].Rows[0]["TASK_END"].ToString();

                    String ssql = String.Format(@"SELECT
	                                                STORE_SORT,
	                                                STORE_ROW,
	                                                STORE_COLUMN,
	                                                STORE_TIER
                                                FROM
	                                                IMOS_LO_STORE_BIN_DETIAL
                                                WHERE
	                                                (
		                                                STORE_CODE = '{0}'
		                                                OR STORE_CODE = '{1}'
	                                                )
                                                AND STORE_SORT = '{2}'",
                                                BaseSystemInfo.StoreCode1,
                                                BaseSystemInfo.StoreCode2,
                                                ds.Tables[0].Rows[0]["TASK_END"].ToString());
                    DataSet sds = DataHelper.Fill(ssql);


                    //执行PLC下传(会一直执行)
                    if (sds!=null&&sds.Tables[0].Rows.Count==1)
                    {
                        DownBuff[4] = sds.Tables[0].Rows[0]["STORE_ROW"].ToString();//排
                        DownBuff[5] = sds.Tables[0].Rows[0]["STORE_COLUMN"].ToString();//列
                        DownBuff[6] = sds.Tables[0].Rows[0]["STORE_TIER"].ToString();//层
                        DownBuff[7] = 0;//备用字
                        DownBuff[8] = 0;//备用字
                        DownBuff[9] = 0;//备用字
                        bool dd = ControlMaster.WriteData(block, address, DownBuff);
                        //判断是否下传
                        if (!dd)
                        {
                            SysBusinessFunction.WriteLog("【" + ds.Tables[0].Rows[0]["TASK_ID"].ToString() + "】入库任务写入PLC失败！");
                            return;
                        }

                        int LinerCount = GetTickCount();
                        //接受反馈信号
                        while (true)
                        {
                            //超时处理
                            Application.DoEvents();
                            //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                            if (GetTickCount() - LinerCount > 20000) //超时处理
                            {
                                SysBusinessFunction.WriteLog("下传信号成功，等待反馈信号超时");
                                break;
                            }
                            bool flag = ControlMaster.ReadData(block, address, 1, out ReadBuff);
                            if (flag && "2".Equals(ReadBuff[0].ToString()))
                            {

                                //接受反馈信号成功，表示任务开始
                                System.Data.OracleClient.OracleParameter[] values = {
                                    new System.Data.OracleClient.OracleParameter("USE_FLAG","1"),
                                    new System.Data.OracleClient.OracleParameter("TASK_TYPE", "I"),
                                    new System.Data.OracleClient.OracleParameter("OLD_TASK_STATE","0"),
                                    new System.Data.OracleClient.OracleParameter("TASK_ID", ds.Tables[0].Rows[0]["TASK_ID"].ToString()),
                                    new System.Data.OracleClient.OracleParameter("NEW_TASK_STATE", "1")
                                    };
                                DataHelper.ExecuteProcedure("UPD_ALL_TASK", values);


                                //清空数据
                                object[] WBuff = new object[len];
                                for(int i = 0; i < WBuff.Length; i++)
                                {
                                    WBuff[i] = 0;
                                }
                                //ControlMaster.WriteData(block, address, WBuff);

                            }
                        }

                    }
                    else//不执行
                    {
                        SysBusinessFunction.WriteLog("没有找到库位坐标！");
                        return;
                    }
                   
                   
                }

            }
            catch(Exception ex)
            {

            }
        }

        #endregion
    
    
        private static int ChStore(String PlanNo,object[] ReadBuff)
        {
            try
            {
                //判断PLC反馈的库存数据对不对
                
                //判读库位放置正不正确
                String selsql = String.Format(@"SELECT TASK_END FROM IMOS_LO_TEMPORARY_TASK WHERE  TASK_TYPE = '{0}'
                                                                AND TASK_STATE = {1} AND PLAN_NO = {2}",
                                             BaseSystemInfo.TaskType, "1", PlanNo);
                DataSet ds = DataHelper.Fill(selsql);
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    if (ReadBuff[4].ToString() != ds.Tables[0].Rows[0]["TASK_END"].ToString())
                    {
                        SysBusinessFunction.WriteLog("放置的库位【" + ReadBuff[4].ToString() + "】和规定库位【" + ds.Tables[0].Rows[0]["TASK_END"].ToString() + "】不一致！");
                        UpdBinDetail("5", ReadBuff[4].ToString());
                        return 3;
                    }
                }
                //读取判断库位坐标信息
                String chsql = String.Format(@"SELECT
	                                                        STORE_BIN,
	                                                        STORE_ROW,
	                                                        STORE_COLUMN,
	                                                        STORE_TIER
                                                        FROM
	                                                        IMOS_LO_STORE_BIN_DETIAL
                                                        WHERE
	                                                        STORE_SORT = '{0}'
                                                        AND (STORE_CODE = '{1}'or
                                                        STORE_CODE = '{2}')",
                                                ReadBuff[4].ToString(),
                                                BaseSystemInfo.StoreCode1, BaseSystemInfo.StoreCode2);
                DataSet chds = DataHelper.Fill(chsql);
                if (chds != null && chds.Tables[0].Rows.Count == 1)
                {
                    bool res1 = ReadBuff[5].ToString() == chds.Tables[0].Rows[0]["STORE_ROW"].ToString();
                    bool res2 = ReadBuff[6].ToString() == chds.Tables[0].Rows[0]["STORE_COLUMN"].ToString();
                    bool res3 = ReadBuff[7].ToString() == chds.Tables[0].Rows[0]["STORE_TIER"].ToString();
                    if (!(res1 && res2 && res3))
                    {
                        String str = String.Format(@"放置坐标【{0},{1},{2}】库位坐标【{3},{4},{5}】不一致",
                                                      ReadBuff[5].ToString(), ReadBuff[6].ToString(), ReadBuff[7].ToString(),
                                                      chds.Tables[0].Rows[0]["STORE_ROW"].ToString(),
                                                      chds.Tables[0].Rows[0]["STORE_COLUMN"].ToString(),
                                                      chds.Tables[0].Rows[0]["STORE_TIER"].ToString());
                        SysBusinessFunction.WriteLog(str);
                        UpdBinDetail("5", ReadBuff[4].ToString());
                        return 3;
                    }
          

                }
                
                 UpdBinDetail("1", ReadBuff[4].ToString());
                 return 2;
                
            }
            catch(Exception ex)
            {
                return -1;
            }
        }

        private static void UpdBinDetail(String StateCode,String SortCode)
        {
            try
            {
                //更新详情表

                String upsql = String.Format(@"UPDATE IMOS_LO_STORE_BIN_DETIAL
                                                SET MATERIAL_STATE = '{0}',
                                                    IN_TIME = sysdate
                                                WHERE
	                                                STORE_SORT = '{1}'
                                                AND (
	                                                STORE_CODE = '{2}'
	                                                OR STORE_CODE = '{3}')",
                                                StateCode, SortCode,BaseSystemInfo.StoreCode1,BaseSystemInfo.StoreCode2);
                DataHelper.Fill(upsql);


            }
            catch(Exception ex)
            {

            }
        }

        private static void TestPLCDevice(object state)
        {
            try
            {

                int readadress = 100;
                int readblock = 0;
                int readlen = 10;
                object[] downbuff = new object[readlen];
                object[] ReadBuff = new object[readlen];
                
                bool res = ControlMaster.ReadData(readblock, readadress, readlen, out ReadBuff);

                downbuff[0] = ReadBuff[0];
                downbuff[1] = ReadBuff[1];
                downbuff[2] = ReadBuff[2];
                downbuff[3] = "1";
                downbuff[4] = ReadBuff[3];
                downbuff[5] = ReadBuff[4];
                downbuff[6] = ReadBuff[5];
                downbuff[7] = ReadBuff[6];
                downbuff[8] = ReadBuff[7];
                downbuff[9] = ReadBuff[8];
                if (res)
                {
                    if (ReadBuff[0].ToString() == "2")
                    {
                        ControlMaster.WriteData(readblock, readadress + 50, downbuff);
                    }
                }

                readadress = 110;
                res = ControlMaster.ReadData(readblock, readadress, readlen, out ReadBuff);
                downbuff[0] = ReadBuff[0];
                downbuff[1] = ReadBuff[1];
                downbuff[2] = ReadBuff[2];
                downbuff[3] = "1";
                downbuff[4] = ReadBuff[3];
                downbuff[5] = ReadBuff[4];
                downbuff[6] = ReadBuff[5];
                downbuff[7] = ReadBuff[6];
                downbuff[8] = ReadBuff[7];
                downbuff[9] = ReadBuff[8];
                if (res)
                {
                    if (ReadBuff[0].ToString() == "2")
                    {
                        ControlMaster.WriteData(readblock, readadress + 50, downbuff);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                TestStoreTimer.Change(1000, Timeout.Infinite);
            }

        }


    }


}

