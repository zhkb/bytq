using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitor.UShell;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System.Collections;
using System.Threading;
using Sys.Config;
using ControlLogic;
using System.Runtime.InteropServices;
using ControlLogic.Control;

using Monitor.BoxBodyStore;
using Material;

namespace Monitor
{
    public partial class FrmUshellStoreOut : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        private FrmPlanTask frmTask;
        private System.Timers.Timer RefreshDataTimer = new System.Timers.Timer(1000); //刷新库存数据Timer 
        private bool m_bFindBinNo = false;

        public FrmUshellStoreOut()
        {
            InitializeComponent();
        }

        private void FrmBoxBodyStorOut_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            WindowState = FormWindowState.Maximized;

            BaseSystemInfo.CurrentProductionOutMode = int.Parse(ConfigHelper.GetValue("CurrentProductionOutMode"));
            if (BaseSystemInfo.CurrentProductionOutMode != 2)
            {
                panelBarCode.Height = 0;
                panelINFO.Height = panelProduct.Height + panelTip.Height;
                panelINFO.Top = panelButton.Top - panelINFO.Height;
            }
            else
            {
                panelBarCode.Height = 50;
                panelINFO.Height = panelProduct.Height + panelTip.Height + panelBarCode.Height;
                panelINFO.Top = panelButton.Top - panelINFO.Height;
            }

            ShowStoreBinInfo();//显示8个货道: 在库，入库数量，使用状态等
    
            GetPlanData(null);
            GetStoreBinData(null);
            RefreshDataTimer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshEvent);
            RefreshDataTimer.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            RefreshDataTimer.Enabled = true; //是否触发Elapsed事件
            RefreshDataTimer.Start();

            

            


            ControlMaster2.SystemInitialization();//初始化PLC
            ControlData.SystemInitSerialPortLiner();  //初始化 内胆扫描的串口

            timer1.Start();

        }

        private void RefreshEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetStoreBinData(null);
            GetPlanData(null);
        }

        //显示8个货道: 在库，入库数量,使用状态等
        private void ShowStoreBinInfo()
        {
            //panel5.Width = 630;
            panel5.Width = 950;
            Application.DoEvents();
            for (int i = 0; i < 8; i++)
            {
                Application.DoEvents();
                FrmStoreDetailUshell TempForm = new FrmStoreDetailUshell();
                TempForm.FormBorderStyle = FormBorderStyle.None;
                TempForm.BinNo = i + 1;//货道号
                TempForm.MaxBinNo = 13;//货道数量
                TempForm.TopLevel = false;

                if (i < 8)
                {
                    TempForm.Parent = panel5;


                    if (i == 0)
                    {
                        TempForm.Height = 120;
                        TempForm.Top = i * 70;
                    }
                    else
                    {
                        TempForm.Height = 70;
                        TempForm.Top = i * 70 + 50;
                    }


                }
                else
                {
                    //TempForm.Parent = pnl_Store2;

                    //if (i == 8)
                    //{
                    //    TempForm.Height = 120;
                    //    TempForm.Top = (i - 8) * 70;
                    //}
                    //else
                    //{
                    //    TempForm.Height = 70;
                    //    TempForm.Top = (i - 8) * 70 + 50;
                    //}

                }



                TempForm.Show();
                //BinFormList.Insert(0, TempForm);
            }
            Application.DoEvents();
        }


        public delegate void Action2<in T>(T t);
        public void dgvPlan_mapping(DataTable dt)
        {
            dgvPlan.DataSource = dt;
            dgvPlan.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgvPlan.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPlan.ClearSelection();
        }
        private void GetPlanData(object o)
        {
            string SqlStr = string.Format(@" select  ID,Material_Code,Material_Name,
                                           Plan_Num,Act_Num,CONVERT(varchar(100), Creation_Date, 108)  as Creation_Date,Flag=CASE WHEN Flag = 0
                                            THEN '未执行'
                                            WHEN Flag = 1
                                            THEN '执行中'
                                            WHEN Flag = 2
                                            THEN '取消'
                                            WHEN Flag = 3
                                            THEN '完成'
                                            ELSE ' ' END ,'取消Cancel' as Cancel  from IMOS_LIST_OUT     where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Workstation_No='{3}' and Flag <2        ORDER BY   Creation_Date ",
                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo);

            DataSet ds = DataHelper.Fill(SqlStr);
            Action2<DataTable> a = new Action2<DataTable>(dgvPlan_mapping);
            Invoke(a, ds.Tables[0]); 

        }


        #region 刷新库存：获取在库，在途数量

        private void GetStoreBinData(object o)
        {
            try
            {
                string SqlStr = "";
                Thread.Sleep(10);

                if (!SysBusinessFunction.DBConn) //数据库连接失败时不再进行数据查询
                {
                    return;
                }
                //获取货道信息及货道状态
                DataSet DBDataSet = new DataSet();
                SqlStr = string.Format(@" select * from IMOS_LO_BIN a
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and  (Store_Code='1001' or  Store_Code='1002') 
                                          order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);




                // 初始化
                OptionSetting.StoreBinDataList = new List<StoreBinData>();

                ////获取在库，在途数量

                for (int i = 0; i < DBDataSet.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = DBDataSet.Tables[0].Rows[i];
                    int StoreBin = int.Parse(dr["Bin_No"].ToString());
                    StoreBinData StoreInfo = new StoreBinData();//
                    StoreInfo.Bin_ID = dr["Bin_ID"].ToString();
                    StoreInfo.BinNo = int.Parse(StoreBin.ToString());//货道名称
                    StoreInfo.Material_Code = dr["Material_Code"].ToString();//产品编码
                    StoreInfo.MaterialName = dr["Material_Name"].ToString();//产品名称
                    StoreInfo.TransitQty = int.Parse(dr["Transit_Qty"].ToString()); ;//货道在途
                    StoreInfo.ActualQty = int.Parse(dr["Actual_Qty"].ToString());//货道实际库存
                    StoreInfo.BinFlag = int.Parse(dr["Bin_Flag"].ToString());//货道状态
                    OptionSetting.StoreBinDataList.Add(StoreInfo);

                }

            }
            catch (Exception ex)
            {

            }
        }





        #endregion

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmAddPlanUshell addPlan = new FrmAddPlanUshell();

            DialogResult r = addPlan.ShowDialog();

            if (r == DialogResult.OK)
            {
                string Msg = addPlan.Msg;
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, Msg);
            }
            GetPlanData(null);
        }

        private void dgvPlan_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dgvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPlan.Columns[e.ColumnIndex].Name == "Cancel")
                {
                    int index = dgvPlan.CurrentRow.Index;
                    string Id = dgvPlan.CurrentRow.Cells["ID"].Value.ToString();
                    string Material_Name = dgvPlan.CurrentRow.Cells["Material_Name"].Value.ToString();
                    int Plan_Num = int.Parse(dgvPlan.CurrentRow.Cells["Plan_Num"].Value.ToString());
                    int Act_Num = int.Parse(dgvPlan.CurrentRow.Cells["Act_Num"].Value.ToString());
                    string sMessage = "是否取消名称为：" + Material_Name + "数量为" + Plan_Num + "的任务？" + Environment.NewLine + "Are you sure to Cancel the task ?";
                    if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                    {
                        return;
                    }

                    EditListOut(Id);
                    GetPlanData(null);
                }

            }
            catch
            {


            }
        }

        #region 任务编辑
        private void EditListOut(string id)
        {
            try
            {
                string CheckStr = "";
                CheckStr = CheckStr + string.Format(@"Update IMOS_LIST_OUT Set Flag = {0} Where ID = '{1}' ;", "2", id);
                CheckStr = CheckStr + string.Format(@"Update IMOS_BA_TRK Set Flag = {0} Where LIST_ID = '{1}' and Flag !=2 ;", "1", id);
                DataHelper.Fill(CheckStr);
            }
            catch
            {
            }
            finally
            {
            }
        }

        private bool ReAllTask()
        {
            try
            {
                string CheckStr = "";
                CheckStr = string.Format(@"Update IMOS_LIST_OUT Set Flag = 0,Act_Num=0  where Flag<>2 and Workstation_No='{0}';", BaseSystemInfo.CurrentStationNo);
                CheckStr = CheckStr + string.Format(@"Update IMOS_BA_TRK Set Flag = 0 where Flag<>1  and Workstation_No='{0}' ;", BaseSystemInfo.CurrentStationNo);
                DataHelper.Fill(CheckStr);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }

        private bool completeOneTask(string strTaskID,string strDetailTaskID)
        {
            try
            {
                string SqlStr = string.Format(@"select *
                                         from IMOS_LIST_OUT T
                                         where T.Company_Code = '{0}' and T.Factory_Code = '{1}' and T.Product_Line_Code = '{2}' 
                                         and T.ID ='{3}'",
                                        BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, strTaskID);

                DataSet ds = DataHelper.Fill(SqlStr);
    
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    int iPlan_Num =int.Parse( ds.Tables[0].Rows[0]["Plan_Num"].ToString());
                    int iAct_Num = int.Parse(ds.Tables[0].Rows[0]["Act_Num"].ToString()) +1;

                    string strTaskSQL = "";
                    string strAct_Num = "0";
                    if (iAct_Num>= iPlan_Num)
                    {//=3 完成
                        strAct_Num = iAct_Num.ToString();
                        strTaskSQL = string.Format(@"Update IMOS_LIST_OUT Set Flag = 3,Act_Num={0} Where ID = '{1}' ;", strAct_Num, strTaskID);
                    }
                    else
                    {//=1 执行中   
                        strAct_Num = iAct_Num.ToString();
                        strTaskSQL = string.Format(@"Update IMOS_LIST_OUT Set Flag = 1,Act_Num={0} Where ID = '{1}' ;", strAct_Num, strTaskID);
                    }
                    string CheckStr = strTaskSQL + string.Format(@"Update IMOS_BA_TRK Set Flag = 2 Where ID = '{0}';", strDetailTaskID);
                    DataHelper.Fill(CheckStr);
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmTask == null || frmTask.IsDisposed)
            {
                frmTask = new FrmPlanTask();
                frmTask.Show();//未打开，直接打开。
            }
            else
            {
                frmTask.Activate();//已打开，获得焦点，置顶。
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.lbLinerCode.Text = OptionSetting.LinerCode;
           
            this.lbmMaterialCode.Text = OptionSetting.MaterialName;

            this.lb_A_BinNo.Text = OptionSetting.XTBinNoA;
            this.lb_Msg.Text = OptionSetting.CodeMsg;

            if (OptionSetting.ToolingBoardRFID != "")
            {
                this.lbLinerCode.Text = OptionSetting.ToolingBoardRFID;
            }
            try
            {
                switch (BaseSystemInfo.CurrentProductionOutMode)
                {
                    case 1:
                        lblStoreOutMode.Text = "规则出库模式" + Environment.NewLine + "Rule mode";
                        GetTask();//规则扫胆
                        break;
                    case 2:
                        lblStoreOutMode.Text = "扫码出库模式" + Environment.NewLine + "Barcode mode";
                        if (OptionSetting.ToolingBoardRFID != "")
                        {
                            BindingData(); //扫码出库
                        }
                        break;
                    case 3:
                        //手动出库
                        lblStoreOutMode.Text = "手动出库模式" + Environment.NewLine + "Manual mode";
                        break;
                }

            }
            catch (Exception ex)
            {

            }
        }//Timer1


        private void BindingData()
        {
            timer1.Enabled = false;
            //条件判断

            if (OptionSetting.ToolingBoardRFID == "")
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请扫描工装板条码！" + Environment.NewLine + "Please scan the barcode of tooling board!");
                timer1.Enabled = true;
                return;
            }


            try
            {
                string strMaterialCode = "";
                string strMaterialName = "";
                DataSet DBDataSet = new DataSet();
                ////string SqlStr = string.Format(@"select u.Material_ID, u.barcodeType,m.Material_Code,m.Material_Name 
                ////                                  from IMOS_TA_barcodeUShell u, IMOS_TA_Material m 
                ////                                  where m.Company_Code = '{0}' and m.Factory_Code = '{1}' and m.Product_Line_Code = '{2}'
                ////                                  and  u.barcodeType = '{3}' and u.Material_ID = m.Material_ID", 
                ////                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode, 
                ////                                  OptionSetting.ToolingBoardRFID);
                string SqlStr = string.Format(@"select u.ID, u.Liner_Name,u.Coaming_Code,u.Coaming_Name 
                                                  from Base_Liner_Coaming u
                                                  where  u.Liner_Code = '{0}'",OptionSetting.ToolingBoardRFID);
                DBDataSet = DataHelper.Fill(SqlStr);
                if (DBDataSet.Tables[0].Rows.Count >= 1)
                {
                    strMaterialCode = DBDataSet.Tables[0].Rows[0]["Coaming_Code"].ToString();
                    strMaterialName = DBDataSet.Tables[0].Rows[0]["Coaming_Name"].ToString();
                    OptionSetting.MaterialName = strMaterialName;
                    ///////////////////////////////////////////////////////////

                    ////////////////////////计算PLC在库数量Begin///////////////////////////////////////
                    SqlStr = string.Format(@"select * from IMOS_Lo_Bin a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Store_Code='{3}'
                                              and Bin_Flag=0 and  Material_Code='{4}' ",
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo,
                                              strMaterialCode);
                    DataSet DBDataSet2 = DataHelper.Fill(SqlStr);
                    int iStoreCount = 0;
                    if (DBDataSet2.Tables[0].Rows.Count >= 1)
                    {
                        for (int i = 0; i < DBDataSet2.Tables[0].Rows.Count; i++)
                        {
                            iStoreCount = iStoreCount + int.Parse(DBDataSet2.Tables[0].Rows[i]["Actual_Qty"].ToString());
                        }
                    }
                    if (iStoreCount < 1)
                    {
                        OptionSetting.CodeMsg = "[" + strMaterialName + "]PLC库存为0,等待..." + Environment.NewLine + "[" + strMaterialName + "] quantity is 0, waiting...";
                        timer1.Enabled = true;
                        return;
                    }
                    ////////////////////////计算PLC在库数量End///////////////////////////////////////





                    SqlStr = string.Format(@"select * from IMOS_Lo_Bin_Detail a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Store_Code='{3}'
                                              and Flag=0 and  Bar_Code='{4}' order by a.Create_Time asc", 
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo,
                                              strMaterialCode);
                    DBDataSet = DataHelper.Fill(SqlStr);
                    string strBin_No = "";
                    bool result = false;
                    if (DBDataSet.Tables[0].Rows.Count >= 1)
                    {
                        string strBin_List_ID = DBDataSet.Tables[0].Rows[0]["Bin_List_ID"].ToString();
                        strBin_No = DBDataSet.Tables[0].Rows[0]["Bin_No"].ToString();
                        OptionSetting.XTBinNoA = strBin_No + "#";
                        ///////////////////////////////////////////////////////////////////////////////
                        //三菱PLC出库
                        result = PLCstoreOut(strBin_No, strMaterialCode);
                        if (result == false)
                        {
                            
                            return; //continue;
                        }

                        //存储U壳货道细表
                        string strBar_Code = strMaterialCode;
                        //string strSql = string.Format(@"delete from IMOS_Lo_Bin_Detail where Bin_List_ID={0}", strBin_List_ID);
                        string strSql = string.Format(@"update IMOS_Lo_Bin_Detail set Flag=1,Out_Time= GetDate()  where Bin_List_ID={0}", strBin_List_ID);
                        DataHelper.Fill(strSql);

                    }
                    else
                    {
                        OptionSetting.CodeMsg = "型号" + strMaterialName + "库存为0,等待..." + Environment.NewLine + "Empty inventory";
                    }
                    ////////////////////////////////////////////////////////////////////
                }
                else
                {
                    OptionSetting.CodeMsg = "没有此物料" + OptionSetting.ToolingBoardRFID + Environment.NewLine + "No found material code";
                }
                
            }
            catch (Exception ex)
            {
                timer1.Enabled = true;
                SysBusinessFunction.WriteLog("扫码处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "扫码处理异常！." + Environment.NewLine + "Scan barcode exception");
                OptionSetting.CodeMsg = "扫码处理异常！." + Environment.NewLine + "Scan barcode exception";
                OptionSetting.isSuccessFlag = "0";
            }
            finally
            {
                timer1.Enabled = true;
            }
        }

        private void btnManualStoreOut_Click(object sender, EventArgs e)
        {
            try
            {
                int iOldMode = BaseSystemInfo.CurrentProductionOutMode;
                
                FrmAssignBinNo form1 = new Monitor.FrmAssignBinNo();
                if (form1.ShowDialog() == DialogResult.OK)
                {
                    BaseSystemInfo.CurrentProductionOutMode = 3;
                    lblStoreOutMode.Text = "手动出库模式" + Environment.NewLine + "Manual mode";
                    Application.DoEvents();

                    string strBin_No = form1.m_strBin;
                    string strMaterialName = "";
                    string strMaterialCode = SearchMaterialCode(strBin_No,out strMaterialName);
                    string strID = SearchDetailBin(strBin_No);
                    if(strMaterialName.Length <1)
                    {
                        OptionSetting.CodeMsg = strBin_No + "#货道没有查询到产品型号" + Environment.NewLine + "Not found Product model from" + strBin_No + "#";
                        BaseSystemInfo.CurrentProductionOutMode = iOldMode;
                        return;
                    }

                    if(strID==null)
                    {
                        OptionSetting.CodeMsg = strBin_No + "#货道库存为0" + Environment.NewLine + strBin_No + "# have none.";
                        BaseSystemInfo.CurrentProductionOutMode = iOldMode;
                        return;
                    }

                    OptionSetting.XTBinNoA = strBin_No +"#";
                    OptionSetting.MaterialName = strMaterialName;


                    //三菱PLC出库
                    bool result = PLCstoreOut(strBin_No, strMaterialCode);
                    if (result == false)
                    {
                        BaseSystemInfo.CurrentProductionOutMode = iOldMode;
                        return; //continue;
                    }

                    ////存储U壳货道细表
                    //string strSql = string.Format(@"delete from IMOS_Lo_Bin_Detail where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' 
                    //                                                     and Bin_List_ID='{3}'",
                    //                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, strID);

                    string strSql = string.Format(@"update IMOS_Lo_Bin_Detail set Flag=1,Out_Time= GetDate()  where Bin_List_ID={0}", strID);
                    DataHelper.Fill(strSql);


                    m_bFindBinNo = true;
                    OptionSetting.XTMsgA = "手动出库成功" + Environment.NewLine + "Manual out Store succeeded";
                }

                BaseSystemInfo.CurrentProductionOutMode = iOldMode;
            }
            catch (Exception ex)
            {
                OptionSetting.XTMsgA = "手动出库异常" + "Manual out Store failed";
                lb_Msg.ForeColor = Color.Red;
            }

        }



        private bool PLCstoreOut(string strBin_No, string strMaterial_Code)
        {
            try
            {
                    //三菱PLC出库
                    int iBlack = 0;
                    int iAddress = int.Parse(BaseSystemInfo.CurrentStationPlcAddress); // 测试暂时 50;

                    object[] RBuff = new object[1];
                    RBuff[0] = 0;  
                    ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 1, out RBuff);
                    if ("1".Equals(RBuff[0].ToString().Trim()))
                    {//PLC置为1时申请请求，上位机读取置0
                        object[] WBuff_FD = new object[19];
                        for (int i = 0; i < WBuff_FD.Length; i++)
                        {
                            WBuff_FD[i] = 0;
                        }

                        WBuff_FD[0] = 1;//软件下传出库信息置为1，PLC读取后置为2
                        WBuff_FD[1] = int.Parse(strBin_No); //货道号
                        //WBuff_FD[2] = 1;    //型号编码
                        int iCount = 2;
                        string Code = strMaterial_Code;
                        while (Code.Length > 0)
                        {
                            if (Code.Length > 2)
                            {
                                WBuff_FD[iCount] = SysBusinessFunction.StrToBinary(Code.Substring(0, 2));
                            }
                            else
                            {
                                WBuff_FD[iCount] = SysBusinessFunction.StrToBinary(Code);
                            }

                            if (Code.Length > 2)
                            {
                                Code = Code.Substring(2);
                            }
                            else
                            {
                                Code = "";
                            }
                            iCount++;
                            if(iCount> WBuff_FD.Length)
                            {
                                break;
                            }
                        }

                        bool result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress+1, WBuff_FD);
                        if (!result)
                        {
                            SysBusinessFunction.WriteLog("MitsubishiPLC出库失败");
                            OptionSetting.CodeMsg = "MitsubishiPLC写入失败" + Environment.NewLine + "PLC write Failed";
                            lb_Msg.ForeColor = Color.Red;
                            return false;
                        }

                        object[] RBuff_FD = new object[2];
                        RBuff_FD[0] = 0;   RBuff_FD[1] = 0;
                        ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress+1, 2, out RBuff_FD);

                        SysBusinessFunction.WriteLog(string.Format("MitsubishiPLC出库应答【{0}】,货道为【{1}】", RBuff_FD[0].ToString(), RBuff_FD[1].ToString()));
                        //清除数据
                        int CoamingTick = GetTickCount();
                        while (true)
                        {
                            Thread.Sleep(1);
                            if (GetTickCount() - CoamingTick > 5000) //超时退出 重新下传 超时时间为5秒
                            {
                                string Msg = "MitsubishiPLC出库超时，未收到回应。";
                                SysBusinessFunction.WriteLog(Msg);
                                OptionSetting.CodeMsg = Msg + Environment.NewLine + "PLC read time out";
                                return false;//!!!!!!!!!!!!!!!!!
                            }

                            object[] Buf = new object[2];
                            Buf[0] = 0; Buf[1] = 0;
                            bool PLCRead = ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress+1, 2, out Buf);

                            if ((int)Buf[0] == 2) //应答字 上位机收到反馈标记2后将下传的信息置0
                            {
                                //只清空应答字
                                object[] writeBuf = new object[1];
                                writeBuf[0] = 0;
                                result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, writeBuf);
                                string Msg = "收到状态字=2，请求字写入0。";
                                SysBusinessFunction.WriteLog(Msg);
                                break;
                            }
                        }//while结束

                    }
                    else
                    {
                        OptionSetting.CodeMsg = "等待PLC允许出库" + Environment.NewLine + "Wait for plc agree";
                        return false;
                    }


                //m_bFindBinNo = true;
                OptionSetting.CodeMsg = "PLC出库成功" + Environment.NewLine + "Out of aisle succeeded";
                return true;
            }
            catch (Exception ex)
            {
                OptionSetting.XTMsgA = "出库异常" + Environment.NewLine + "Plc Error";
                OptionSetting.CodeMsg = OptionSetting.XTMsgA;
                lb_Msg.ForeColor = Color.Red;
                return false;
            }

        }

        private string SearchMaterialCode(string strBin,out string strOutMaterialName) //查询物料信息
        {
            string strMaterial_Name = "";
            try
            {
                string strMaterial_Code = null;
                
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@" SELECT Material_Code, Material_Name  FROM IMOS_Lo_Bin
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Store_Code='{3}'
                                           and Bin_No ='{4}'
                                           ", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo, strBin);
                DBDataSet = DataHelper.Fill(SqlStr);
                if (DBDataSet.Tables[0].Rows.Count >= 1)
                {
                    strMaterial_Code = DBDataSet.Tables[0].Rows[0]["Material_Code"].ToString();
                    strMaterial_Name = DBDataSet.Tables[0].Rows[0]["Material_Name"].ToString();
                }
                strOutMaterialName = strMaterial_Name;
                return strMaterial_Code;
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
                strOutMaterialName = strMaterial_Name;
                return null;
            }
        }

        private string SearchDetailBin(string strBin) //处理  ge 606 609
        {
            try
            {

                string strID= null;
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@" SELECT Bin_List_ID, Bar_Code  FROM IMOS_Lo_Bin_Detail
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Store_Code='{3}'
                                           and Bin_No ='{4}' order by Create_Time asc
                                           ", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo, strBin);
                DBDataSet = DataHelper.Fill(SqlStr);
                if (DBDataSet.Tables[0].Rows.Count >= 1)
                {
                    strID = DBDataSet.Tables[0].Rows[0]["Bin_List_ID"].ToString();
                }
                return strID;
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
                return null;
            }
        }



        private void GetTask()
        {
            try
            {
                timer1.Enabled = false;
                string SqlStr = string.Format(@"select T.ID,T.LIST_ID,T.Bin_No,T.Material_Code,T.Material_Name,T.SortNum,T.Flag,T.Creation_Date 
                                         from IMOS_BA_TRK T
                                         LEFT JOIN  IMOS_LIST_OUT L ON T.LIST_ID = L.ID      
                                         where T.Company_Code = '{0}' and T.Factory_Code = '{1}' and T.Product_Line_Code = '{2}' 
                                         and T.Workstation_No='{3}'  and T.IO='I'   and T.Flag <2   AND L.Flag<2        
                                         ORDER BY   T.Creation_Date ,T.ID",
                                        BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo);

                DataSet ds = DataHelper.Fill(SqlStr);

                if (ds.Tables[0].Rows.Count >= 1)
                {
                    string strDetailTask_ID = ds.Tables[0].Rows[0]["ID"].ToString();
                    string strMaterialCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                    string strMaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                    string strTaskID = ds.Tables[0].Rows[0]["LIST_ID"].ToString();
                    OptionSetting.MaterialName = strMaterialName;


                    ////////////////////////计算PLC在库数量Begin///////////////////////////////////////
                    SqlStr = string.Format(@"select * from IMOS_Lo_Bin a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Store_Code='{3}'
                                              and Bin_Flag=0 and  Material_Code='{4}' ",
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo,
                                              strMaterialCode);
                    DataSet DBDataSet2 = DataHelper.Fill(SqlStr);
                    int iStoreCount = 0;
                    if (DBDataSet2.Tables[0].Rows.Count >= 1)
                    {
                        for (int i = 0; i < DBDataSet2.Tables[0].Rows.Count; i++)
                        {
                            iStoreCount = iStoreCount + int.Parse(DBDataSet2.Tables[0].Rows[i]["Actual_Qty"].ToString());
                        }
                    }
                    if (iStoreCount < 1)
                    {
                        OptionSetting.CodeMsg = "[" + strMaterialName + "]PLC库存为0,等待..." + Environment.NewLine + "[" + strMaterialName + "] quantity is 0, waiting...";
                        timer1.Enabled = true;
                        return;
                    }
                    ////////////////////////计算PLC在库数量End///////////////////////////////////////

                    //////////////////////////U壳库中查询是否有此型号////////////////////////
                    SqlStr = string.Format(@"select * from IMOS_Lo_Bin_Detail a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Store_Code='{3}'
                                              and Flag=0 and  Bar_Code='{4}'  order by a.Create_Time asc",
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo,
                                              strMaterialCode);
                    DataSet DBDataSet = DataHelper.Fill(SqlStr);
                    string strBin_No = "";
                    bool result = false;
                    if (DBDataSet.Tables[0].Rows.Count >= 1)
                    {
                        string strBin_List_ID = DBDataSet.Tables[0].Rows[0]["Bin_List_ID"].ToString();
                        strBin_No = DBDataSet.Tables[0].Rows[0]["Bin_No"].ToString();
                        OptionSetting.XTBinNoA = strBin_No + "#";
                        ///////////////////////////////////////////////////////////////////////////////
                        //三菱PLC出库
                        result = PLCstoreOut(strBin_No, strMaterialCode);
                        if (result == false)
                        {
                            timer1.Enabled = true;
                            return; //continue;
                        }

                        //存储U壳货道细表
                        string strBar_Code = strMaterialCode;
                        //string strSql = string.Format(@"delete from IMOS_Lo_Bin_Detail where Bin_List_ID={0}", strBin_List_ID);
                        string strSql = string.Format(@"update IMOS_Lo_Bin_Detail set Flag=1,Out_Time= GetDate()  where Bin_List_ID={0}", strBin_List_ID);
                        DataHelper.Fill(strSql);

                        // 处理任务表，处理任务详细表
                        bool bResult_Task = completeOneTask(strTaskID, strDetailTask_ID);
                    }
                    else
                    {
                        OptionSetting.CodeMsg = "[" + strMaterialName + "]库存为0,等待..." + Environment.NewLine + "[" + strMaterialName + "] quantity is 0, waiting...";
                        timer1.Enabled = true;
                        return; //continue;
                    }

       
                    ////////////////////////////////////////////////////
                }
                else
                {
                    //重新处理FLAG标识
                    bool bResult_Task = ReAllTask();
                    
                }
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                timer1.Enabled = true;
                SysBusinessFunction.WriteLog("GetTask():" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FrmProductionMode form1 = new FrmProductionMode();

            DialogResult r = form1.ShowDialog();

            if (r == DialogResult.OK)
            {
                if (BaseSystemInfo.CurrentProductionOutMode != 2)
                {
                    panelBarCode.Height = 0;
                    panelINFO.Height = panelProduct.Height + panelTip.Height;
                    panelINFO.Top = panelButton.Top - panelINFO.Height;
                }
                else
                {
                    panelBarCode.Height = 50;
                    panelINFO.Height = panelProduct.Height + panelTip.Height + panelBarCode.Height;
                    panelINFO.Top = panelButton.Top - panelINFO.Height;
                }
                if(BaseSystemInfo.CurrentProductionOutMode==1)
                {
                    lblStoreOutMode.Text  = "规则出库模式" + Environment.NewLine + "Rule mode";
                }
                else if (BaseSystemInfo.CurrentProductionOutMode == 2)
                {
                    lblStoreOutMode.Text = "扫码出库模式" + Environment.NewLine + "Barcode mode";
                }
                else if (BaseSystemInfo.CurrentProductionOutMode == 3)
                {
                    lblStoreOutMode.Text = "手动出库模式" + Environment.NewLine + "Manual mode";
                }

                OptionSetting.MaterialName = "";
                OptionSetting.XTBinNoA = "";
                OptionSetting.CodeMsg = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmLinerCoaming form1 = new FrmLinerCoaming();
            DialogResult r = form1.ShowDialog();

            if (r == DialogResult.OK)
            {
            }
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            FrmOutRecord form1 = new FrmOutRecord();
            DialogResult r = form1.ShowDialog();

            if (r == DialogResult.OK)
            {
            }
        }
    }
}
