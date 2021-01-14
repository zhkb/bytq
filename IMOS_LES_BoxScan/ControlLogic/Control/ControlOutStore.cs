using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ControlLogic.Control
{
     public class ControlOutStore
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();


        public static System.Threading.Timer RunOutStoreTimer; //运行出库信号

        public static System.Threading.Timer OutStoreTimer; //运行出库信号  

        public static System.Threading.Timer TestStoreTimer; //测试信号
        #region 初始化
        public static void SystemInitialization()//初始化
        {
         
            
            RunOutStoreTimer = new System.Threading.Timer(RunPLCDevice, null, 0, Timeout.Infinite);
            OutStoreTimer = new System.Threading.Timer(RunOutPLCDevice, null, 0, Timeout.Infinite);
            TestStoreTimer = new System.Threading.Timer(TestPLCDevice, null, 0, Timeout.Infinite);

        }

        #endregion

  

        #region 出库中
        private static void RunPLCDevice(object state)
        {
            try
            {
                //查找数据库Task数据
                String ssql = String.Format(@"SELECT
	                                            MATERIAL_CODE,
                                                MATERIAL_NAME,
                                                TASK_ID
                                            FROM
	                                            IMOS_LO_TEMPORARY_TASK
                                            WHERE
	                                            TASK_STATE = '{0}'
                                            AND TASK_END = '{1}'
                                            AND TASK_TYPE = '{2}'
                                            ORDER BY
	                                            START_TIME", "0","CK001","O");
                DataSet ds = DataHelper.Fill(ssql);
                if (ds != null&&ds.Tables[0].Rows.Count>0)
                {
                    //查找库存数量存不存在
                    String selsql = String.Format(@"SELECT
	                                                    STORE_SORT,
	                                                    STORE_ROW,
	                                                    STORE_COLUMN,
	                                                    STORE_TIER
                                                    FROM
	                                                    IMOS_LO_STORE_BIN_DETIAL
                                                    WHERE
	                                                    MATERIAL_CODE = '{0}'
                                                    AND MATERIAL_STATE = '{3}'
                                                    AND (
	                                                    STORE_CODE = '{1}'
	                                                    OR STORE_CODE = '{2}'
                                                    )", ds.Tables[0].Rows[0]["MATERIAL_CODE"].ToString(), "D0001", "D0002", "1");
                    DataSet selds = DataHelper.Fill(selsql);
                    if (selds != null && selds.Tables[0].Rows.Count > 0)
                    {
                        //更新task
                        OptionSetting.Outflag = true;
                        OptionSetting.OutRow = selds.Tables[0].Rows[0]["STORE_ROW"].ToString();
                        OptionSetting.OutColumn = selds.Tables[0].Rows[0]["STORE_COLUMN"].ToString();
                        OptionSetting.OutTier = selds.Tables[0].Rows[0]["STORE_TIER"].ToString();
                        OptionSetting.OutSort = selds.Tables[0].Rows[0]["STORE_SORT"].ToString();
                        //下传PLC出库
                        // D200 反馈信息 0默认 1 下传 2 接受成功
                        // D201 库位号
                        // D202 排号
                        // D203 行号
                        // D204 层号
                        int downadress = 200;
                        int downblock = 0;
                        int downlen = 5;
                        object[] downbuff = new object[downlen];
                        object[] ReadBuff = new object[1];
                        downbuff[0] = 1;
                        downbuff[1] = selds.Tables[0].Rows[0]["STORE_SORT"].ToString();
                        downbuff[2] = selds.Tables[0].Rows[0]["STORE_ROW"].ToString();
                        downbuff[3] = selds.Tables[0].Rows[0]["STORE_COLUMN"].ToString();
                        downbuff[4] = selds.Tables[0].Rows[0]["STORE_TIER"].ToString();
                        bool re = ControlMaster.WriteData(downblock,downadress,downbuff);
                        if (!re)
                        {
                            SysBusinessFunction.WriteLog("出库任务【" + ds.Tables[0].Rows[0]["TASK_ID"].ToString() + "】下传信号错误");
                            OptionSetting.OutMsg = "出库任务下传PLC失败";
                            OptionSetting.Outflag = true;
                            OptionSetting.OutMsgColor = false;
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
                                OptionSetting.OutMsg = "下传信号成功，等待反馈信号超时";
                                OptionSetting.Outflag = true;
                                OptionSetting.OutMsgColor = false;
                                break;
                            }
                            bool flag = ControlMaster.ReadData(downblock, downadress, 1, out ReadBuff);
                            if (flag && "2".Equals(ReadBuff[0].ToString()))
                            {
                                //接受反馈信号成功
                                SysBusinessFunction.WriteLog("出库任务【" + ds.Tables[0].Rows[0]["TASK_ID"].ToString() + "】下传PLC成功！");
                                object[] wbuff = new object[1];
                                wbuff[0] = 0;
                                ControlMaster.WriteData(downblock, downadress, wbuff);
                                //更新状态将库位变为预出库
                                upBinState(selds.Tables[0].Rows[0]["STORE_SORT"].ToString(), "3");
                                //更新出库任务变为进行中
                                upStoreTask(ds.Tables[0].Rows[0]["TASK_ID"].ToString(),"1", selds.Tables[0].Rows[0]["STORE_SORT"].ToString());
                                downbuff[0] = 0;
                                downbuff[1] = 0;
                                downbuff[2] = 0;
                                downbuff[3] = 0;
                                downbuff[4] = 0;
                                ControlMaster.WriteData(downblock, downadress, downbuff);
                                OptionSetting.OutMsg = "下传信号成功，状态更新完成";
                                OptionSetting.Outflag = true;
                                OptionSetting.OutMsgColor = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        upStoreTask(ds.Tables[0].Rows[0]["TASK_ID"].ToString(), "4", "");
                        OptionSetting.OutMsg = "没有门体库存!";
                        OptionSetting.Outflag = true;
                        OptionSetting.OutMsgColor = false;

                        //SysBusinessFunction.WriteLog("门体【" + ds.Tables[0].Rows[0]["MATERIAL_NAME"].ToString() + "】没有库存！");
                    }
                }



            

            }
            catch (Exception ex)
            {

            }
            finally
            {
                RunOutStoreTimer.Change(1000, Timeout.Infinite);
            }

        }

        #endregion

        #region 出库完成
        private static void RunOutPLCDevice(object state)
        {
            try
            {
                //接受PLC出库
                // D210 反馈信息 0默认 1 上传 2 接受成功
                // D211 库位号
                // D213~D2105 预留
                int readadress = 210;
                int readblock = 0;
                int readlen = 5;
                object[] downbuff = new object[readlen];
                object[] ReadBuff = new object[readlen];

                bool res = ControlMaster.ReadData(readblock,readadress,readlen, out ReadBuff);
                
                if (res)
                {
                    if (ReadBuff[0].ToString() == "1")
                    {
                        //判断出库是否正确
                        
                        upBinState(ReadBuff[1].ToString(),"4");
                        downbuff[0] = 0;
                        downbuff[1] = 0;
                        downbuff[2] = 0;
                        downbuff[3] = 0;
                        downbuff[4] = 0;
                        ControlMaster.WriteData(readblock, readadress,downbuff);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                OutStoreTimer.Change(1000, Timeout.Infinite);
            }

        }

        #endregion

        private static void TestPLCDevice(object state)
        {
            try
            {
               
                int readadress = 100;
                int readblock = 0;
                int readlen = 5;
                object[] downbuff = new object[readlen];
                object[] ReadBuff = new object[readlen];
                bool res = ControlMaster.ReadData(readblock, readadress, readlen, out ReadBuff);
                if (res)
                {
                    if (ReadBuff[0].ToString() == "1")
                    {
                        ControlMaster.WriteData(readblock,readadress+50,ReadBuff);
                    }
                }

                readadress = 110;
                res = ControlMaster.ReadData(readblock, readadress, readlen, out ReadBuff);
                if (res)
                {
                    if (ReadBuff[0].ToString() == "1")
                    {
                        ControlMaster.WriteData(readblock, readadress + 50, ReadBuff);
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




        private static void upBinState(string storeSort,string state)
        {
            try
            {
                String sql = String.Format(@"UPDATE IMOS_LO_STORE_BIN_DETIAL
                                            SET MATERIAL_STATE = '{0}',
                                             OUT_TIME = sysdate,
                                             F_LASTMODIFYTIME = SYSDATE
                                            WHERE
	                                            STORE_SORT = '{1}'", state, storeSort);
                DataHelper.Fill(sql);
                SysBusinessFunction.WriteLog("【"+storeSort+"】库位状态变为【"+state+"】");

            }catch(Exception ex)
            {

            }
        }
        private static void upStoreTask(string tid, string state,string tfrom)
        {
            try
            {
                System.Data.OracleClient.OracleParameter[] values = {
                                    new System.Data.OracleClient.OracleParameter("TFROM",tfrom),
                                    new System.Data.OracleClient.OracleParameter("TID",tid),
                                    new System.Data.OracleClient.OracleParameter("STATE",state)
                                    };
                DataHelper.ExecuteProcedure("UP_TEMPOERARY_TASK", values);
                SysBusinessFunction.WriteLog("出库任务状态变更为【"+state+"】");
            }
            catch (Exception ex)
            {

            }
        }

    }
}
