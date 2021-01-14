using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
   public class FrmBindingControlcs
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        public static System.Threading.Timer GetBindingTimer; //绑定信息
        public static System.Threading.Timer GetMaterialTimer; //控制入库
        public static int cpount = 0;
        private static bool nflag = false;
        //public static bool GetFlag = false;

        public static void SystemInitialization()//初始化
        {
            GetBindingTimer = new System.Threading.Timer(BindingDevice, null, 0, Timeout.Infinite);           
            GetMaterialTimer = new System.Threading.Timer(MaterialDevice, null, 0, Timeout.Infinite);        
        }

        private static void MaterialDevice(object state)
        {
            try
            {

                Thread.Sleep(50);
                if (OptionSetting.RKTypeFlag == 3)
                {
                    return;
                }

                if (OptionSetting.Check)//空板模式
                {
                    return;
                }

                else
                {

                    String sql = String.Format(@"SELECT * FROM IMOS_Lo_Scan_Code Where 1=1 ORDER BY CreateTime DESC");
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {

                        //库存数据更新
                        for (int k = 1; k <= 8; k++)
                        {
                            int kaddress = BaseSystemInfo.KCaddress + (k - 1) * 10;

                            object[] KRbuf = new object[1];
                            bool result = ControlXPLC.ReadData(0, kaddress, 1, out KRbuf);
                            if (result)
                            {
                                String upsql = String.Format(@"UPDATE IMOS_Lo_Bin SET Store_Qty = '{0}' Where Store_Code = '{1}'", KRbuf[0].ToString(), k);
                                DataHelper.Fill(upsql);
                            }
                            else
                            {
                                return;
                            }

                        }
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            //判断库存是否已满
                            String chsql = String.Format(@"SELECT
	                                                           ISNULL(SUM (Store_Qty), 0) Store_Sum_Qty,
	                                                           ISNULL(SUM (Max_Qty), 0) Max_Sum_Qty
                                                            FROM
	                                                            IMOS_Lo_Bin
                                                            WHERE
	                                                            Material_Code = '{0}' and In_Flag = '{1}'", ds.Tables[0].Rows[j]["MaterialCode"].ToString(), "0");
                            DataSet chds = DataHelper.Fill(chsql);
                            if (chds != null)
                            {

                                if (chds.Tables[0].Rows.Count >= 0)
                                {
                                    String getsql = String.Format(@"SELECT ISNULL(SUM (1), 0) de_sum_Qty  FROM IMOS_Lo_Bin_Detial Where Material_Code = '{0}'", ds.Tables[0].Rows[j]["MaterialCode"].ToString());
                                    DataSet getds = DataHelper.Fill(getsql);
                                    if (getds != null && getds.Tables[0].Rows.Count > 0)
                                    {
                                        int ssq = int.Parse(chds.Tables[0].Rows[0]["Store_Sum_Qty"].ToString());
                                        int msq = int.Parse(chds.Tables[0].Rows[0]["Max_Sum_Qty"].ToString());
                                        int dsq = int.Parse(getds.Tables[0].Rows[0]["de_sum_Qty"].ToString());
                                        if (dsq + ssq >= msq - 1)
                                        {
                                            SysBusinessFunction.WriteLog("库存满了：在途" + dsq + ",在库" + ssq + ",最大" + msq);
                                            continue;
                                        }
                                        SysBusinessFunction.WriteLog("没满：在途" + dsq + ",在库" + ssq + ",最大" + msq);
                                        //验证是否可以抓取
                                        int ad = BaseSystemInfo.FWaddress;
                                        if ("2"== ds.Tables[0].Rows[j]["Store_Sort"].ToString())
                                        {
                                            ad = BaseSystemInfo.FWaddress + 1;
                                        }
                                        
                                        int len = BaseSystemInfo.FWlen;
                                        object[] RB = new object[len];
                                        bool fldg = ControlMaster.ReadData(0, ad, len, out RB);
                                        if (!fldg)
                                        {
                                            return;
                                        }
                                        if (RB[0].ToString() == "1")//可以抓取
                                        {

                                            DownPLC(ds.Tables[0].Rows[j]["Store_Sort"].ToString());
                                        }
                                        else
                                        {
                                            SysBusinessFunction.WriteLog("物料未到位不能抓取！");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetMaterialTimer.Change(1000, Timeout.Infinite);
            }
        }

        private static void BindingDevice(object state)
        {
            try
            {
                
                Thread.Sleep(50);
                if (OptionSetting.Check)//空板模式
                {


                    OptionSetting.smi.MaterialSort = OptionSetting.KBSort;
                    OptionSetting.smi.MaterialBarCode = OptionSetting.KBMaterialBarCode;
                    OptionSetting.smi.MaterialCode = OptionSetting.KBMaterialCode;
                    OptionSetting.smi.MaterialName = OptionSetting.KBMaterialName;
                    BindingMaterial();
                    DownKBPLC();//直接下传
                    OptionSetting.BasketCode = "";
                }

                else
                {
                    int ad = BaseSystemInfo.WLaddress;
                    int len = BaseSystemInfo.WLlen;
                    object[] RB = new object[len];
                    bool fldg = ControlMaster.ReadData(0, ad, len, out RB);
                    if (!fldg)
                    {
                        return;
                    }
                    if (RB[0].ToString() == "1")//PLC下传物料信号成功
                    {
                        String sql = String.Format(@"SELECT * From IMOS_TA_Material Where Material_Sort = {0}", RB[1].ToString());
                        DataSet ds = DataHelper.Fill(sql);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            OptionSetting.smi.MaterialBarCode = "";
                            OptionSetting.smi.MaterialSort = ds.Tables[0].Rows[0]["Material_Sort"].ToString();
                            OptionSetting.smi.MaterialCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                            OptionSetting.smi.MaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        }
                        BindingMaterial();
                        if (OptionSetting.SFlag)
                        {
                            RB[0] = 0;
                            RB[1] = 0;
                            OptionSetting.SFlag = false;
                            ControlMaster.WriteData(0, ad, RB);
                        }
                    }
                }
                 
            }
            catch (Exception ex)
            {

            }
            finally
            {
                GetBindingTimer.Change(1000, Timeout.Infinite);
            }

        }

       
        private static void DownKBPLC()
        {
            try
            {
                int ad = BaseSystemInfo.Maddress;
                int len = BaseSystemInfo.Mlen;
                object[] RB = new object[len];
                bool fldg = ControlMaster.ReadData(0, ad, len, out RB);
                if (!fldg)
                {

                    return;
                }
                if (RB[0].ToString() == "1")
                {
                    
                    ControlMaster.WriteData(0,ad+1,RB);
                }

             }catch(Exception ex)
            {

            }
        }

        private static string getStoreCode()
        {
            try
            {
                String chsql = String.Format(@"SELECT
	                                                    A.Store_Code,
	                                                    COUNT (1) SumNUM
                                                    FROM
	                                                    IMOS_Lo_Bin A
                                                    LEFT JOIN IMOS_Lo_Bin_Detial B ON A.Store_Code = B.Store_Code
                                 
                                                    GROUP BY
	                                                    A.Store_Code");

                DataSet chds = DataHelper.Fill(chsql);
                if (chds != null)
                {
                    if (chds.Tables[0].Rows.Count == 0)
                    {
                        return "1";
                    }
                   
                }
                for (int i = 0; i < chds.Tables[0].Rows.Count; i++)
                {
                    if (int.Parse(chds.Tables[0].Rows[i]["SumNUM"].ToString()) < 7)
                    {
                        String StoreCode = chds.Tables[0].Rows[i]["Store_Code"].ToString();
                        return StoreCode;

                     }
                 }
                return null;
            }
            
            catch(Exception e)
            {
                return null;
            }
        }

        public static bool DownPLC(String scode)
        {
            try
            {
               

                //if (GetFlag)
                //{
                //    return true;
                //}
                if (scode == null || scode.Length == 0)
                {
                    return false;
                }
             


                int address = BaseSystemInfo.BDAddress;
                int len = BaseSystemInfo.BDLen;
                int block = 0;

                object[] Wbuf = new object[len];
                Wbuf[0] = 1;
                Wbuf[1] = scode;
                bool result = ControlMaster.WriteData(block, address,Wbuf);
                if (result)
                {
                    
                    int DownCount = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(5);
                        // Application.DoEvents();
                        //下位机在收到信息后需要将应答字修改为2 当上位机收到信息后将下传的信息清空
                        if (GetTickCount() - DownCount > 5000) //超时处理
                        {
                            SysBusinessFunction.WriteLog("抓取方向下传"+ scode + "信号成功，等待反馈信号超时");
                            break;
                        }

                        object[] RBuf = new object[1];
                        ControlMaster.ReadData(0, address, 1, out RBuf);
                        if (RBuf[0].ToString() == "2")
                        {
                            //GetFlag = true;
                            Wbuf[0] = 0;
                            Wbuf[1] = 0;
                            ControlMaster.WriteData(block, address, Wbuf);
                            SysBusinessFunction.WriteLog("抓取方向下传" + scode + "信号成功，接受反馈信号成功");
                            break;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
             


            }
            catch(Exception ex)
            {
                return false;
            }
        }

        #region  绑定物料
        public static void BindingMaterial()
        {
            try
            {
                Application.DoEvents();
                if (string.IsNullOrEmpty(OptionSetting.BasketCode))
                {
                    return;
                }
                bool rflag = UpdateForm(true);
                if (rflag)
                {

                    //GetFlag = false;
                    //删除存储表
                    if (OptionSetting.RKTypeFlag != 3)
                    {
                        //String delsql = String.Format(@"DELETE FROM IMOS_Lo_Scan_Code Where Store_Sort = '{0}'", BaseSystemInfo.CurrentINStoreCode);
                        //DataHelper.Fill(delsql);
                    }
                    
                    SysBusinessFunction.WriteLog("绑定信息成功！工装板RFID【" + OptionSetting.OldBasketCode + "】产品信息【"+OptionSetting.smi.MaterialName+"】产品编号【"+ OptionSetting.smi.MaterialCode + "】产品代号【"+ OptionSetting.smi.MaterialSort+ "】");
                    
                    // OptionSetting.BasketCode = "";
                }
                else
                {

                    SysBusinessFunction.WriteLog("绑定信息失败！！");
                }
            
               
                
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("绑定信息异常！");
     
                //

            }
        }


        #endregion

        #region  更新数据库
        public static bool UpdateForm(bool typeflag)
        {
            try
            {
                if (!OptionSetting.Check)
                {
                    string selectsql = String.Format(@"Select Store_Code,Store_Name From IMOS_Lo_Bin where Material_Code = '{0}' and Area_Code = '{1}'", OptionSetting.smi.MaterialCode, BaseSystemInfo.AreaCode);
                    DataSet selectds = DataHelper.Fill(selectsql);
                    if (selectds != null && selectds.Tables[0].Rows.Count > 0)
                    {

                    }
                    else
                    {
                        SysBusinessFunction.WriteLog(OptionSetting.smi.MaterialCode + "该型号没有分配的货道！！");
                        return false;
                    }
                }
               
                String TaskID = Guid.NewGuid().ToString();
                // 创建个存储过程 ，实现更新数据和插入任务
                SqlParameter[] values = {
                                            new SqlParameter("@Bin_ID",  OptionSetting.BasketCode+ DateTime.Now.ToString("yyyyMMddHHmmss")),
                                            new SqlParameter("@Task_ID", TaskID),
                                            new SqlParameter("@Company_Code", BaseSystemInfo.CompanyCode),
                                            new SqlParameter("@Company_Name", BaseSystemInfo.CompanyName),
                                            new SqlParameter("@Factory_Code", BaseSystemInfo.FactoryCode),
                                            new SqlParameter("@Factory_Name", BaseSystemInfo.FactoryName),
                                            new SqlParameter("@Product_Line_Code", BaseSystemInfo.ProductLineCode),
                                            new SqlParameter("@Product_Line_Name", BaseSystemInfo.ProductLineName),
                                            new SqlParameter("@Area_Code", BaseSystemInfo.AreaCode),
                                            new SqlParameter("@Area_Name", BaseSystemInfo.AreaCode),
                                            new SqlParameter("@Store_Code", ""),
                                            new SqlParameter("@Store_Name ",  ""),
                                            new SqlParameter("@Material_Sort", OptionSetting.smi.MaterialSort),
                                            new SqlParameter("@Material_Code", OptionSetting.smi.MaterialCode),
                                            new SqlParameter("@Material_Name", OptionSetting.smi.MaterialName),
                                            new SqlParameter("@Bar_Code",OptionSetting.smi.MaterialBarCode),
                                            new SqlParameter("@Task_State","0"),
                                            new SqlParameter("@Task_Type", "1"),
                                            new SqlParameter("@RFID_Code", OptionSetting.BasketCode),
                                            new SqlParameter("@Qty", 1),
                                            new SqlParameter("@Scan_Time", OptionSetting.ScanTime),
                                            new SqlParameter("@Process_Code", BaseSystemInfo.CurrentProcessCode),
                                            new SqlParameter("@Process_Name", BaseSystemInfo.CurrentProcessName)
                                      };

                if (typeflag)
                {
                    DataHelper.ExecuteProcedure("del_Pallet_Task", new String[] { "List" }, values);
                    DataHelper.ExecuteProcedure("in_Pallet_Task", new String[] { "List" }, values);
                    OptionSetting.OldBasketCode = OptionSetting.BasketCode;
                    OptionSetting.BasketCode = "";
                    //OptionSetting.JLFlag = false;
                    if(OptionSetting.RKTypeFlag == 3)
                    {
                        SysBusinessFunction.WriteLog("执行到第"+ OptionSetting.PlanCount + "条任务");
                        String sql = String.Format(@"UPDATE IMOS_Lo_RKPlan SET Use_Flag = '{0}' Where ID = '{1}'", 0, OptionSetting.PlanCount);
                        DataHelper.Fill(sql);
                        if (OptionSetting.PlanCount == 26)
                        {
                            sql = String.Format(@"UPDATE IMOS_Lo_RKPlan SET Use_Flag = '{0}' Where ID = '{1}'", 1, 1);
                            DataHelper.Fill(sql);
                        }
                        else
                        {
                            sql = String.Format(@"UPDATE IMOS_Lo_RKPlan SET Use_Flag = '{0}' Where ID = '{1}'", 1, OptionSetting.PlanCount + 1);
                            DataHelper.Fill(sql);
                        }
                        
                    }
                    OptionSetting.SFlag = true;
                    //OptionSetting.SDRKCode = OptionSetting.smi.MaterialCode + "123";
                }
                else
                {
                    DataHelper.ExecuteProcedure("in_Pallet_Task", new String[] { "List" }, values);
                    OptionSetting.OldBasketCode = OptionSetting.BasketCode;
                    OptionSetting.BasketCode = "";
                    //OptionSetting.JLFlag = false;
                    //OptionSetting.SDRKCode = OptionSetting.smi.MaterialCode + "123";
                }
                
                OptionSetting.Bindingflag = true;
                return true;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("是不是这里出错了" + ex.Message);
                return false;
            }
        }

        #endregion
    }
}
