using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLogic.Control;
using System.Runtime.InteropServices;
//using System.Speech.Synthesis;
//问题： 怎么知道 在途？，入库？
//法式：GE 
//IMOS_LIST_OUT : 出库任务记录，包含已完成的任务(Flag = 3)， 还未执行的任务(Flag = 0), 
//                             '执行中'的任务(Flag = 1),    取消的任务(Flag = 2)

//[IMOS_BA_TRK]: 出库任务里的 详细记录分解（1个任务里，有好几个U壳）。
//                    flag= 0 '未执行',    flag= 1 '取消',    Flag = 2  '完成',
namespace Monitor
{
    public partial class FrmUshellStoreIN : Form
    {
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();

        private System.Timers.Timer RefreshStoreBinDataTimer = new System.Timers.Timer(1000); //刷新库存数据Timer 
        private ArrayList BinFormList = new ArrayList(); //库位详细信息

        public int StoreBinCount = 0; //货道数量
        //private SpeechSynthesizer speech = new SpeechSynthesizer();
        int m_iTimerCount = 0;
        private bool m_bFindBinNo = false;  //检测是否发现可以使用的货道
        public static System.Threading.Timer CheckSiemensPlcTimer;//检查西门子PLC 是否进来U壳
        public static System.Threading.Timer CheckSiemensPlcTimer2;//检查西门子PLC 是否进来U壳
        public static System.Threading.Timer CheckCountFromMitsubishiPlcTimer;//获取三菱PLC 在库，在途

        public FrmUshellStoreIN()
        {
            InitializeComponent();
            dgv_Store.TopLeftHeaderCell.Value = "序号";
            dgv_Store.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmBoxBodyStoreMonitor_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            StoreBinCount = 13;
            ControlBox = false;
            WindowState = FormWindowState.Maximized;
            ShowStoreBinInfo();//显示8个货道: 在库，入库数量，使用状态等

            GetStoreBinData(null);
            RefreshStoreBinDataTimer.Elapsed += new System.Timers.ElapsedEventHandler(RefreshStoreBinEvent);
            RefreshStoreBinDataTimer.AutoReset = true; //每到指定时间Elapsed事件是触发一次（false），还是一直触发（true）
            RefreshStoreBinDataTimer.Enabled = true; //是否触发Elapsed事件
            RefreshStoreBinDataTimer.Start();


            ControlMaster2.SystemInitialization();//初始化PLC

            CheckSiemensPlcTimer = new System.Threading.Timer(CheckSiemensUke1, null, 0, Timeout.Infinite);//检查西门子PLC 是否进来U壳
            CheckSiemensPlcTimer2 = new System.Threading.Timer(CheckSiemensUke2, null, 0, Timeout.Infinite);//检查西门子PLC 是否进来U壳
            CheckCountFromMitsubishiPlcTimer = new System.Threading.Timer(CountQtyFromMitsubishiPLC, null, 0, Timeout.Infinite);//获取三菱PLC 在库，在途
        }


        private  void CheckSiemensUke1(object o)
        {
            try
            {
                readStoreFromPLC1();
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
            }
            finally
            {
                CheckSiemensPlcTimer.Change(6000, Timeout.Infinite);
            }
        }

        private void CheckSiemensUke2(object o)
        {
            try
            {
                readStoreFromPLC2();
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
            }
            finally
            {
                CheckSiemensPlcTimer2.Change(6000, Timeout.Infinite);
            }
        }

        

        //private void readStoreFromPLC()
        //{
        //    ////int iBlack = 2;
        //    ////int iAddress = 0;
        //    int iBlack = 2;
        //    int iAddress = 0;
        //    object[] RBuff = new object[1];
        //    ControlMaster2.ReadData_siemens(iBlack, iAddress, 10, out RBuff);
        //    if ("1".Equals(RBuff[0].ToString().Trim()))
        //    {

        //        ////////////////////////////////////////////////////////////////////////////////////
        //        object[] BackWBuff = new object[1];
        //        BackWBuff[0] = 2;//上位机收到有效信息后发送2
        //        bool result = ControlMaster2.WriteData_siemens(iBlack, iAddress, BackWBuff);
        //        if (!result)
        //        {
        //            SysBusinessFunction.WriteLog("siemensPLC写入2异常");
        //            OptionSetting.XTMsgA = "siemensPLC写入2异常" + Environment.NewLine + "siemensPLC Write Data 2 exception";
        //            lb_A_Msg.ForeColor = Color.Red;

        //            //////////////////////////////////
        //            int CoamingTick2 = GetTickCount();
        //            while (true)
        //            {
        //                Thread.Sleep(10);
        //                if (GetTickCount() - CoamingTick2 > 5000) //超时退出 重新下传 超时时间为5秒
        //                {
        //                    SysBusinessFunction.WriteLog("siemensPLC写入2异常，超时5秒");
        //                    return;  /////////！！！！！！！！！
        //                }
        //                result = ControlMaster2.WriteData_siemens(iBlack, iAddress, BackWBuff);
        //                if (result) //应答字 上位机收到反馈标记2后将下传的信息置0
        //                {
        //                    SysBusinessFunction.WriteLog("siemensPLC写入2成功");
        //                    break;
        //                }
        //            }
        //            //////////////////////////////////
        //        }
        //        ////////////////////////////////////////////////////////////////////////////////////


        //        string strMaterialCode = "";
        //        string strMaterialName = "";
        //        for (int i = 1; i <= 9; i++)
        //        {
        //            int iData1 = (int)RBuff[i];
        //            string strCode = IntToString(iData1);
        //            strMaterialCode = strMaterialCode + strCode;
        //        }
        //        strMaterialCode = strMaterialCode.Trim();
        //        lb_A_barCode.Text = strMaterialCode;

        //        //获取物料名称
        //        strMaterialName = SearchMaterialName(strMaterialCode);

        //        //获取统计库存信息
        //        GetBinNumberFromPLC();

        //        //处理编码，查询数据库，入库
        //        string strBin_No = "";
        //        DataSet DBDataSet = new DataSet();
        //        string SqlStr = string.Format(@"select * from IMOS_LO_BIN a
        //                                  where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
        //                                  and  Material_Code='{3}'  and  FullFlag=0 and Bin_Flag=0 
        //                                  order by a.in_Time desc", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, strMaterialCode);
        //        DBDataSet = DataHelper.Fill(SqlStr);

        //        if (DBDataSet.Tables[0].Rows.Count >= 1)
        //        {
        //            //存储U壳货道细表
        //            strBin_No = DBDataSet.Tables[0].Rows[0]["Bin_No"].ToString();
        //            ///////////////////////////////////////////////////////////////////////////////
        //            //三菱PLC分道
        //            iBlack = 3;
        //            iAddress = 0;
        //            object[] WBuff_FD = new object[2];
        //            WBuff_FD[0] = 1;
        //            WBuff_FD[1] = int.Parse(strBin_No);
        //            result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, WBuff_FD);
        //            if (!result)
        //            {
        //                SysBusinessFunction.WriteLog("MitsubishiPLC分道失败");
        //                OptionSetting.XTMsgA = "MitsubishiPLC分道失败" + Environment.NewLine + "PLC Failed to allocate track";
        //                lb_A_Msg.ForeColor = Color.Red;
        //                return;
        //            }

        //            object[] RBuff_FD = new object[2];
        //            for (int i = 0; i < 2; i++)
        //            {
        //                RBuff_FD[i] = 0;
        //            }
        //            ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out RBuff_FD);

        //            SysBusinessFunction.WriteLog(string.Format("MitsubishiPLC分道应答【{0}】,分道为【{1}】", RBuff_FD[0].ToString(), RBuff_FD[1].ToString()));
        //            //清除数据
        //            int CoamingTick = GetTickCount();
        //            while (true)
        //            {
        //                Thread.Sleep(1);
        //                if (GetTickCount() - CoamingTick > 5000) //超时退出 重新下传 超时时间为5秒
        //                {
        //                    string Msg = "MitsubishiPLC分道，未收到回应。";
        //                    SysBusinessFunction.WriteLog(Msg);

        //                    //pic_PlcState.Image = ConnImage[Convert.ToInt32(false)];//PLC状态
        //                    break;
        //                }

        //                object[] Buf = new object[2];
        //                Buf[0] = 0; Buf[1] = 0;
        //                bool PLCRead = ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out RBuff_FD);

        //                if ((int)Buf[0] == 2) //应答字 上位机收到反馈标记2后将下传的信息置0
        //                {
        //                    //只清空应答字
        //                    object[] writeBuf = new object[1];
        //                    writeBuf[0] = 0;
        //                    result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, writeBuf);
        //                    string Msg = "收到状态字=2，状态字写入0。";
        //                    SysBusinessFunction.WriteLog(Msg);
        //                    //pic_PlcState.Image = ConnImage[Convert.ToInt32(true)];//PLC状态
        //                    break;
        //                }
        //            }





        //            string strBar_Code = strMaterialCode;
        //            string strSql = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, ProductLine_Code, ProductLine_Name,
        //                                                                            Bin_No,Bar_Code,Create_Time) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate())",
        //                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
        //                                              strBin_No, strBar_Code);
        //            DataHelper.Fill(strSql);


        //            //存储U壳货道表
        //            ////int iActual_Qty = int.Parse(DBDataSet.Tables[0].Rows[0]["Actual_Qty"].ToString());
        //            ////iActual_Qty = iActual_Qty + 1;
        //            ////string strActual_Qty = iActual_Qty.ToString();

        //            ////int iFullFlag = 0;
        //            ////if (iActual_Qty == 20)
        //            ////{
        //            ////    iFullFlag = 1;
        //            ////}

        //            ////string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Actual_Qty = {0},FullFlag={1} ,Create_Time = GetDate() Where Bin_No = '{2}'",
        //            ////                                      strActual_Qty, iFullFlag, strBin_No);
        //            string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Create_Time = GetDate() Where Bin_No = '{0}'",
        //                                              strBin_No);
        //            DataHelper.Fill(AlarmSql);
        //        }
        //        else
        //        {
        //            //插入新的列，先确认是否有空道
        //            //确认空道
        //            SqlStr = string.Format(@"select * from IMOS_LO_BIN a
        //                                  where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
        //                                  order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, strMaterialCode);
        //            DBDataSet = DataHelper.Fill(SqlStr);

        //            if (DBDataSet.Tables[0].Rows.Count < 8)
        //            {
        //                //存储U壳货道表
        //                strBin_No = (DBDataSet.Tables[0].Rows.Count + 1).ToString();
        //                //PLC分道


        //                string strSql = string.Format(@"Insert Into IMOS_LO_BIN(Company_Code, Company_Name, Factory_Code, Factory_Name, ProductLine_Code, ProductLine_Name,
        //                                              ,Bin_No ,Material_Code,Material_Name ,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,FullFlag) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate())",
        //                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
        //                                              strBin_No, strMaterialCode,"",20,0,0,0,0);
        //                DataHelper.Fill(strSql);



        //                //存储U壳货道细表
        //                string strBar_Code = strMaterialCode;
        //                string strSql2 = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, ProductLine_Code, ProductLine_Name,
        //                                                                            Bin_No,Bar_Code,Create_Time) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate())",
        //                                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
        //                                                  strBin_No, strBar_Code);
        //                DataHelper.Fill(strSql2);
        //            }
        //            else
        //            {
        //                OptionSetting.XTMsgA = "货道已满，无可用存储货道！" + Environment.NewLine + "The goods lane is full, no storage lanes are available.";
        //                lb_A_Msg.ForeColor = Color.Red;
        //                //无空闲货道，报警！
        //                //speech.SpeakAsync("报警:货道已满，无可用存储货道！");
        //            }
        //        }

        //        lb_A_BinNo.Text = strBin_No;
        //        //lb_A_Msg.ForeColor = Color.Gold;
        //    }
        //    else
        //    {
        //        //无
        //    }
        //}


        private void readStoreFromPLC1()//WYFchange   西门子PLC --->sanling PLC
        {
            ////int iBlack = 2;
            ////int iAddress = 0;
            bool result = false;
            int iBlack = 0;     //WYFchange
            int iAddress = 200;//WYFchange
            object[] RBuff = new object[1];
            ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 10, out RBuff);
            if ("1".Equals(RBuff[0].ToString().Trim()))
            {
                string strWorkstation_No = "1001";  //1,2,3,4 货道
                //////////////////////////////////////////////////////////////////////////////////////
                //object[] BackWBuff = new object[1];
                //BackWBuff[0] = 2;//上位机收到有效信息后发送2
                //bool result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                //if (!result)
                //{
                //    SysBusinessFunction.WriteLog("siemensPLC写入2异常");
                //    OptionSetting.XTMsgA = "siemensPLC写入2异常" + Environment.NewLine + "siemensPLC Write Data 2 exception";
                //    lb_A_Msg.ForeColor = Color.Red;

                //    int CoamingTick2 = GetTickCount();
                //    while (true)
                //    {
                //        Thread.Sleep(10);
                //        if (GetTickCount() - CoamingTick2 > 5000) //超时退出 重新下传 超时时间为5秒
                //        {
                //            SysBusinessFunction.WriteLog("siemensPLC写入2异常，超时5秒");
                //            return;  /////////！！！！！！！！！
                //        }
                //        result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                //        if (result) //应答字 上位机收到反馈标记2后将下传的信息置0
                //        {
                //            SysBusinessFunction.WriteLog("siemensPLC写入2成功");
                //            break;
                //        }
                //    }
                //}
                //////////////////////////////////////////////////////////////////////////////////////


                string strMaterialCode = "";
                string strMaterialName = "";
                for (int i = 1; i <= 9; i++)
                {
                    int iData1 = (int)RBuff[i];
                    string strCode = IntToString(iData1);
                    strMaterialCode = strMaterialCode + strCode;
                }
                //strMaterialCode = strMaterialCode.Trim();
                strMaterialCode = strMaterialCode.Replace("\0", ""); 
                OptionSetting.XTBarCodeA = strMaterialCode;  //lb_A_barCode.Text

                //获取物料名称
                strMaterialName = SearchMaterialName(strMaterialCode);
                if(strMaterialName==null)
                {
                    OptionSetting.XTMsgA = "未找到物料条码对应的产品型号" + Environment.NewLine + "Product Model Not Found";
                    return;
                }

                //查询数据库，入库
                string strBin_No = "";
                m_bFindBinNo = false;
                while (!m_bFindBinNo)
                {
                    //获取统计库存信息
                    GetBinNumberFromPLC();


                    DataSet DBDataSet = new DataSet();
                    string SqlStr = string.Format(@"select * from IMOS_LO_BIN a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                              and  Material_Code='{3}'  and  FullFlag=0 and Bin_Flag=0 and  Store_Code='1001' 
                                              order by a.in_Time desc", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,
                                              BaseSystemInfo.ProductLineCode, strMaterialCode);
                    DBDataSet = DataHelper.Fill(SqlStr);

                    if (DBDataSet.Tables[0].Rows.Count >= 1)
                    {
                        strBin_No = DBDataSet.Tables[0].Rows[0]["Bin_No"].ToString();
                        ///////////////////////////////////////////////////////////////////////////////
                        //三菱PLC分道
                        result = PointBinNoPLC(strBin_No);
                        if (result == false)
                        {
                            continue;
                        }

                        

                        //存储U壳货道细表
                        string strBar_Code = strMaterialCode;
                        string strSql = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                        Bin_No,Bar_Code,Create_Time,Store_Code) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate(),'{8}')",
                                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                          strBin_No, strBar_Code, strWorkstation_No);
                        DataHelper.Fill(strSql);


                        //存储U壳货道表
                        ////int iActual_Qty = int.Parse(DBDataSet.Tables[0].Rows[0]["Actual_Qty"].ToString());
                        ////iActual_Qty = iActual_Qty + 1;
                        ////string strActual_Qty = iActual_Qty.ToString();

                        ////int iFullFlag = 0;
                        ////if (iActual_Qty == 20)
                        ////{
                        ////    iFullFlag = 1;
                        ////}

                        ////string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Actual_Qty = {0},FullFlag={1} ,Create_Time = GetDate() Where Bin_No = '{2}'",
                        ////                                      strActual_Qty, iFullFlag, strBin_No);
                        string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set in_Time = GetDate() Where Bin_No = '{0}'  and  (Store_Code='1001' or  Store_Code='1002')",
                                                          strBin_No);
                        DataHelper.Fill(AlarmSql);
                        m_bFindBinNo = true;
                        OptionSetting.XTMsgA = "分道成功" + Environment.NewLine + "Distribution of aisle succeeded";
                    }
                    else
                    {
                         SqlStr = string.Format(@"select * from IMOS_LO_BIN a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                               and  FullFlag=-1 and Bin_Flag=0 and Store_Code='1001'
                                              order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,
                                              BaseSystemInfo.ProductLineCode);
                        DBDataSet = DataHelper.Fill(SqlStr);

                        if (DBDataSet.Tables[0].Rows.Count >= 1)
                        {//找到空货道
                            strBin_No = DBDataSet.Tables[0].Rows[0]["Bin_No"].ToString(); ;

                            //三菱PLC分道
                            result = PointBinNoPLC(strBin_No);
                            if (result == false)
                            {
                                continue;
                            }

                            //存储U壳货道表
                            string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set FullFlag=0,Material_Code ='{0}',Material_Name='{1}', in_Time = GetDate() Where Bin_No = '{2}'  and  (Store_Code='1001' or  Store_Code='1002')",
                                                          strMaterialCode, strMaterialName, strBin_No);
                            DataHelper.Fill(AlarmSql);


                            
                            //存储U壳货道细表
                            string strBar_Code = strMaterialCode;
                            string strSql2 = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                        Bin_No,Bar_Code,Create_Time,Store_Code) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate(),'{8}')",
                                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                              strBin_No, strBar_Code, strWorkstation_No);
                            DataHelper.Fill(strSql2);
                            m_bFindBinNo = true;
                            OptionSetting.XTMsgA = "分道成功" + Environment.NewLine + "Distribution of aisle succeeded";
                        }
                        else
                        {
                            //插入新的列，先确认是否有空道
                            //确认空道
                            SqlStr = string.Format(@"select * from IMOS_LO_BIN a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and  Store_Code='1001'   
                                              order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,
                                                  strMaterialCode);
                            DBDataSet = DataHelper.Fill(SqlStr);

                            if (DBDataSet.Tables[0].Rows.Count < 4)
                            {
                                strBin_No = (DBDataSet.Tables[0].Rows.Count + 1).ToString();

                                //三菱PLC分道
                                result = PointBinNoPLC(strBin_No);
                                if (result == false)
                                {
                                    continue;
                                }

                                //存储U壳货道表
                                string strSql = string.Format(@"Insert Into IMOS_LO_BIN(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                          Bin_No ,Material_Code,Material_Name ,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,FullFlag,in_Time,strWorkstation_No) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12},{13},GetDate(),'{14}')",
                                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                              strBin_No, strMaterialCode, strMaterialName, 20, 0, 0, 0, 0, strWorkstation_No);
                                DataHelper.Fill(strSql);


                               
                                //存储U壳货道细表
                                string strBar_Code = strMaterialCode;
                                string strSql2 = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                        Bin_No,Bar_Code,Create_Time,Store_Code) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate(),'{8}')",
                                                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                                  strBin_No, strBar_Code, strWorkstation_No);
                                DataHelper.Fill(strSql2);
                                m_bFindBinNo = true;
                                OptionSetting.XTMsgA = "分道成功" + Environment.NewLine + "Distribution of aisle succeeded";
                            }
                            else
                            {
                                OptionSetting.XTMsgA = "货道已满，无可用存储货道！" + Environment.NewLine + "There's no extra aisle.";
                                lb_A_Msg.ForeColor = Color.Red;
                                OptionSetting.XTBinNoA = "";
                                //无空闲货道，报警！
                                //speech.SpeakAsync("报警:货道已满，无可用存储货道！");
                            }
                        }
                        //////////////////////////////////////////

                    }
                }//while找货道


                ////////////////////////////////////////////////////////////////////////////////////
                object[] BackWBuff = new object[1];
                BackWBuff[0] = 2;//上位机收到有效信息后发送2
                result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                if (!result)
                {
                    SysBusinessFunction.WriteLog("siemensPLC写入2异常");
                    OptionSetting.XTMsgA = "siemensPLC写入2异常" + Environment.NewLine + "siemensPLC Write Data 2 exception";
                    lb_A_Msg.ForeColor = Color.Red;

                    int CoamingTick2 = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(10);
                        if (GetTickCount() - CoamingTick2 > 5000) //超时退出 重新下传 超时时间为5秒
                        {
                            SysBusinessFunction.WriteLog("siemensPLC写入2异常，超时5秒");
                            return;  /////////！！！！！！！！！
                        }
                        result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                        if (result) //应答字 上位机收到反馈标记2后将下传的信息置0
                        {
                            SysBusinessFunction.WriteLog("siemensPLC写入2成功");
                            break;
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////

                OptionSetting.XTBinNoA = strBin_No + "#"; //lb_A_BinNo.Text
                //lb_A_Msg.ForeColor = Color.Gold;
            }//if(RBuff[0]==1)
            else
            {
                //无
            }
        }



        private void readStoreFromPLC2()//WYFchange   西门子PLC --->sanling PLC
        {
            ////int iBlack = 2;
            ////int iAddress = 0;
            bool result = false;
            int iBlack = 0;     //WYFchange
            int iAddress = 210;//WYFchange
            object[] RBuff = new object[1];
            ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 10, out RBuff);
            if ("1".Equals(RBuff[0].ToString().Trim()))
            {
                string strWorkstation_No = "1002";  //1,2,3,4 货道
                //////////////////////////////////////////////////////////////////////////////////////
                //object[] BackWBuff = new object[1];
                //BackWBuff[0] = 2;//上位机收到有效信息后发送2
                //result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                //if (!result)
                //{
                //    SysBusinessFunction.WriteLog("siemensPLC写入2异常");
                //    OptionSetting.XTMsgA = "siemensPLC写入2异常" + Environment.NewLine + "siemensPLC Write Data 2 exception";
                //    lb_A_Msg.ForeColor = Color.Red;

                //    int CoamingTick2 = GetTickCount();
                //    while (true)
                //    {
                //        Thread.Sleep(10);
                //        if (GetTickCount() - CoamingTick2 > 5000) //超时退出 重新下传 超时时间为5秒
                //        {
                //            SysBusinessFunction.WriteLog("siemensPLC写入2异常，超时5秒");
                //            return;  /////////！！！！！！！！！
                //        }
                //        result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                //        if (result) //应答字 上位机收到反馈标记2后将下传的信息置0
                //        {
                //            SysBusinessFunction.WriteLog("siemensPLC写入2成功");
                //            break;
                //        }
                //    }
                //}
                //////////////////////////////////////////////////////////////////////////////////////


                string strMaterialCode = "";
                string strMaterialName = "";
                for (int i = 1; i <= 9; i++)
                {
                    int iData1 = (int)RBuff[i];
                    string strCode = IntToString(iData1);
                    strMaterialCode = strMaterialCode + strCode;
                }
                //strMaterialCode = strMaterialCode.Trim();
                strMaterialCode = strMaterialCode.Replace("\0", "");
                OptionSetting.XTBarCodeA = strMaterialCode;  //lb_A_barCode.Text

                //获取物料名称
                strMaterialName = SearchMaterialName(strMaterialCode);
                if (strMaterialName == null)
                {
                    OptionSetting.XTMsgA = "未找到物料条码对应的产品型号" + Environment.NewLine + "Product Model Not Found";
                    return;
                }

                //查询数据库，入库
                string strBin_No = "";
                m_bFindBinNo = false;
                while (!m_bFindBinNo)
                {
                    //获取统计库存信息
                    GetBinNumberFromPLC();


                    DataSet DBDataSet = new DataSet();
                    string SqlStr = string.Format(@"select * from IMOS_LO_BIN a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                              and  Material_Code='{3}'  and  FullFlag=0 and Bin_Flag=0 and  Store_Code='1002' 
                                              order by a.in_Time desc", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,
                                              BaseSystemInfo.ProductLineCode, strMaterialCode);
                    DBDataSet = DataHelper.Fill(SqlStr);

                    if (DBDataSet.Tables[0].Rows.Count >= 1)
                    {
                        strBin_No = DBDataSet.Tables[0].Rows[0]["Bin_No"].ToString();
                        ///////////////////////////////////////////////////////////////////////////////
                        //三菱PLC分道
                        result = PointBinNoPLC2(strBin_No);
                        if (result == false)
                        {
                            continue;
                        }



                        //存储U壳货道细表
                        string strBar_Code = strMaterialCode;
                        string strSql = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                        Bin_No,Bar_Code,Create_Time,Store_Code) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate(),'{8}')",
                                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                          strBin_No, strBar_Code, strWorkstation_No);
                        DataHelper.Fill(strSql);


                        //存储U壳货道表
                        ////int iActual_Qty = int.Parse(DBDataSet.Tables[0].Rows[0]["Actual_Qty"].ToString());
                        ////iActual_Qty = iActual_Qty + 1;
                        ////string strActual_Qty = iActual_Qty.ToString();

                        ////int iFullFlag = 0;
                        ////if (iActual_Qty == 20)
                        ////{
                        ////    iFullFlag = 1;
                        ////}

                        ////string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Actual_Qty = {0},FullFlag={1} ,Create_Time = GetDate() Where Bin_No = '{2}'",
                        ////                                      strActual_Qty, iFullFlag, strBin_No);
                        string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set in_Time = GetDate() Where Bin_No = '{0}'  and  (Store_Code='1001' or  Store_Code='1002')",
                                                          strBin_No);
                        DataHelper.Fill(AlarmSql);
                        m_bFindBinNo = true;
                        OptionSetting.XTMsgA = "分道成功" + Environment.NewLine + "Distribution of aisle succeeded";
                    }
                    else
                    {
                        SqlStr = string.Format(@"select * from IMOS_LO_BIN a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                               and  FullFlag=-1 and Bin_Flag=0 and Store_Code='1002'
                                              order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode,
                                             BaseSystemInfo.ProductLineCode);
                        DBDataSet = DataHelper.Fill(SqlStr);

                        if (DBDataSet.Tables[0].Rows.Count >= 1)
                        {//找到空货道
                            strBin_No = DBDataSet.Tables[0].Rows[0]["Bin_No"].ToString(); ;

                            //三菱PLC分道
                            result = PointBinNoPLC2(strBin_No);
                            if (result == false)
                            {
                                continue;
                            }

                            //存储U壳货道表
                            string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set FullFlag=0,Material_Code ='{0}',Material_Name='{1}', in_Time = GetDate() Where Bin_No = '{2}'  and  (Store_Code='1001' or  Store_Code='1002')",
                                                          strMaterialCode, strMaterialName, strBin_No);
                            DataHelper.Fill(AlarmSql);



                            //存储U壳货道细表
                            string strBar_Code = strMaterialCode;
                            string strSql2 = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                        Bin_No,Bar_Code,Create_Time,Store_Code) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate(),'{8}')",
                                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                              strBin_No, strBar_Code, strWorkstation_No);
                            DataHelper.Fill(strSql2);
                            m_bFindBinNo = true;
                            OptionSetting.XTMsgA = "分道成功" + Environment.NewLine + "Distribution of aisle succeeded";
                        }
                        else
                        {
                            //插入新的列，先确认是否有空道
                            //确认空道
                            SqlStr = string.Format(@"select * from IMOS_LO_BIN a
                                              where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and  Store_Code='1002'   
                                              order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,
                                                  strMaterialCode);
                            DBDataSet = DataHelper.Fill(SqlStr);

                            if (DBDataSet.Tables[0].Rows.Count < 4)
                            {
                                strBin_No = ( 4 + DBDataSet.Tables[0].Rows.Count + 1).ToString();

                                //三菱PLC分道
                                result = PointBinNoPLC2(strBin_No);
                                if (result == false)
                                {
                                    continue;
                                }

                                //存储U壳货道表
                                string strSql = string.Format(@"Insert Into IMOS_LO_BIN(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                          Bin_No ,Material_Code,Material_Name ,Max_Qty,Transit_Qty,Actual_Qty,Bin_Flag,FullFlag,in_Time,strWorkstation_No) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12},{13},GetDate(),'{14}')",
                                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                              strBin_No, strMaterialCode, strMaterialName, 20, 0, 0, 0, 0, strWorkstation_No);
                                DataHelper.Fill(strSql);



                                //存储U壳货道细表
                                string strBar_Code = strMaterialCode;
                                string strSql2 = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                        Bin_No,Bar_Code,Create_Time,Store_Code) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate(),'{8}')",
                                                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                                  strBin_No, strBar_Code, strWorkstation_No);
                                DataHelper.Fill(strSql2);
                                m_bFindBinNo = true;
                                OptionSetting.XTMsgA = "分道成功" + Environment.NewLine + "Distribution of aisle succeeded";
                            }
                            else
                            {
                                OptionSetting.XTMsgA = "货道已满，无可用存储货道！" + Environment.NewLine + "The goods lane is full, no storage lanes are available.";
                                lb_A_Msg.ForeColor = Color.Red;
                                OptionSetting.XTBinNoA = "";
                                //无空闲货道，报警！
                                //speech.SpeakAsync("报警:货道已满，无可用存储货道！");
                            }
                        }
                        //////////////////////////////////////////

                    }
                }//while找货道


                ////////////////////////////////////////////////////////////////////////////////////
                object[] BackWBuff = new object[1];
                BackWBuff[0] = 2;//上位机收到有效信息后发送2
                result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                if (!result)
                {
                    SysBusinessFunction.WriteLog("siemensPLC写入2异常");
                    OptionSetting.XTMsgA = "siemensPLC写入2异常" + Environment.NewLine + "siemensPLC Write Data 2 exception";
                    lb_A_Msg.ForeColor = Color.Red;

                    int CoamingTick2 = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(10);
                        if (GetTickCount() - CoamingTick2 > 5000) //超时退出 重新下传 超时时间为5秒
                        {
                            SysBusinessFunction.WriteLog("siemensPLC写入2异常，超时5秒");
                            return;  /////////！！！！！！！！！
                        }
                        result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, BackWBuff);
                        if (result) //应答字 上位机收到反馈标记2后将下传的信息置0
                        {
                            SysBusinessFunction.WriteLog("siemensPLC写入2成功");
                            break;
                        }
                    }
                }
                ////////////////////////////////////////////////////////////////////////////////////

                OptionSetting.XTBinNoA = strBin_No + "#"; //lb_A_BinNo.Text
                //lb_A_Msg.ForeColor = Color.Gold;
            }//if(RBuff[0]==1)
            else
            {
                //无
            }
        }


        //显示8个货道: 在库，入库数量,使用状态等
        private void ShowStoreBinInfo()
        {
            //panel5.Width = 630;
            pnl_Store1.Width = 680;
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
                    TempForm.Parent = pnl_Store1;


                    if (i == 0)
                    {
                        TempForm.Height = 120;
                        TempForm.Top = i * 70;
                    }
                    else
                    {
                        TempForm.Height = 67;
                        TempForm.Top = i * 67 + 50;
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
                BinFormList.Insert(0, TempForm);
            }
            Application.DoEvents();
        }


        private bool PointBinNoPLC(string strBin_No)
        {
            //三菱PLC分道
            int iBlack = 0;
            int iAddress = 0; //1-4货道

            try
            {
                OptionSetting.XTBinNoA = strBin_No + "#";
                object[] WBuff_FD = new object[2];
                WBuff_FD[0] = 1;
                WBuff_FD[1] = int.Parse(strBin_No);
                bool result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, WBuff_FD);
                if (!result)
                {
                    SysBusinessFunction.WriteLog("MitsubishiPLC写入失败");
                    OptionSetting.XTMsgA = "MitsubishiPLC写入失败" + Environment.NewLine + "PLC Write Data exception";
                    lb_A_Msg.ForeColor = Color.Red;
                    return false;
                }

                object[] RBuff_FD = new object[2];
                for (int i = 0; i < 2; i++)
                {
                    RBuff_FD[i] = 0;
                }
                ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out RBuff_FD);

                SysBusinessFunction.WriteLog(string.Format("MitsubishiPLC分道应答【{0}】,分道为【{1}】", RBuff_FD[0].ToString(), RBuff_FD[1].ToString()));
                //清除数据
                int CoamingTick = GetTickCount();
                while (true)
                {
                    Thread.Sleep(1);
                    if (GetTickCount() - CoamingTick > 5000) //超时退出 重新下传 超时时间为5秒
                    {
                        string Msg = "MitsubishiPLC分道，未收到回应。";
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.XTMsgA = Msg  + Environment.NewLine + "response didn't received From Track PLC";
                        return false;
                    }

                    object[] Buf = new object[2];
                    Buf[0] = 0; Buf[1] = 0;
                    bool PLCRead = ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out Buf);

                    if ((int)Buf[0] == 2) //应答字 上位机收到反馈标记2后将下传的信息置0
                    {
                        //只清空应答字
                        object[] writeBuf = new object[1];
                        writeBuf[0] = 0;
                        result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, writeBuf);
                        string Msg = "收到状态字=2，状态字写入0。";
                        SysBusinessFunction.WriteLog(Msg);
                        //pic_PlcState.Image = ConnImage[Convert.ToInt32(true)];//PLC状态
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        private bool PointBinNoPLC2(string strBin_No)
        {
            //三菱PLC分道
            int iBlack = 0;
            int iAddress = 10;
            try
            {
                OptionSetting.XTBinNoA = strBin_No + "#";
                object[] WBuff_FD = new object[2];
                WBuff_FD[0] = 1;
                WBuff_FD[1] = int.Parse(strBin_No);
                bool result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, WBuff_FD);
                if (!result)
                {
                    SysBusinessFunction.WriteLog("MitsubishiPLC写入失败");
                    OptionSetting.XTMsgA = "MitsubishiPLC写入失败" + Environment.NewLine + "PLC Write Data exception";
                    lb_A_Msg.ForeColor = Color.Red;
                    return false;
                }

                object[] RBuff_FD = new object[2];
                for (int i = 0; i < 2; i++)
                {
                    RBuff_FD[i] = 0;
                }
                ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out RBuff_FD);

                SysBusinessFunction.WriteLog(string.Format("MitsubishiPLC分道应答【{0}】,分道为【{1}】", RBuff_FD[0].ToString(), RBuff_FD[1].ToString()));
                //清除数据
                int CoamingTick = GetTickCount();
                while (true)
                {
                    Thread.Sleep(1);
                    if (GetTickCount() - CoamingTick > 5000) //超时退出 重新下传 超时时间为5秒
                    {
                        string Msg = "MitsubishiPLC分道，未收到回应。";
                        SysBusinessFunction.WriteLog(Msg);
                        OptionSetting.XTMsgA = Msg + Environment.NewLine + "response didn't received From Track PLC";
                        return false;
                    }

                    object[] Buf = new object[2];
                    Buf[0] = 0; Buf[1] = 0;
                    bool PLCRead = ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out Buf);

                    if ((int)Buf[0] == 2) //应答字 上位机收到反馈标记2后将下传的信息置0
                    {
                        //只清空应答字
                        object[] writeBuf = new object[1];
                        writeBuf[0] = 0;
                        result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, writeBuf);
                        string Msg = "收到状态字=2，状态字写入0。";
                        SysBusinessFunction.WriteLog(Msg);
                        //pic_PlcState.Image = ConnImage[Convert.ToInt32(true)];//PLC状态
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void RefreshStoreBinEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            GetStoreBinData(null);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_A_barCode.Text = OptionSetting.XTBarCodeA;
            //lb_B_barCode.Text = OptionSetting.XTBarCodeB;
            lb_A_BinNo.Text = OptionSetting.XTBinNoA;
            //lb_B_BinNo.Text = OptionSetting.XTBinNoB;
            lb_A_Msg.Text = OptionSetting.XTMsgA;
            //lb_B_Msg.Text = OptionSetting.XTMsgB;

            m_iTimerCount++;
            if (m_iTimerCount>1)
            {
                m_iTimerCount = 0;
                GetStoreData();
            }
        }

        private void dgv_South_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
        public void GetStoreData() //刷新界面数据
        {
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@" SELECT Material_Name, sum([Transit_Qty]) Transit_Qty,sum([Actual_Qty]) Actual_Qty, (sum([Transit_Qty])+sum([Actual_Qty])) All_Qty  FROM IMOS_Lo_Bin
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and  (Store_Code='1001' or  Store_Code='1002')
                                           GROUP BY Material_Code,Material_Name", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);

                if(DBDataSet.Tables[0].Rows.Count<8)
                {
                    int iRows = DBDataSet.Tables[0].Rows.Count;
                    for (int i = iRows + 1; i < 9; i++)
                    {
                        DataRow dr = DBDataSet.Tables[0].NewRow();
                        DBDataSet.Tables[0].Rows.Add(dr);
                    }
                }
                dgv_Store.DataSource = DBDataSet.Tables[0];
                

                ///////////////////////////////////////////////////
                SqlStr = string.Format(@" SELECT m.Material_Name, d.Bin_No, Convert(Varchar(100),d.Create_Time ,120) as Create_Time  FROM IMOS_Lo_Bin_Detail d, IMOS_TA_Material m 
                                          where d.Company_Code = '{0}' and d.Factory_Code = '{1}' and d.Product_Line_Code = '{2}' and  (Store_Code='1001' or  Store_Code='1002')
                                          and d.[Bar_Code] = m.Material_Code order by d.Create_Time desc", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DBDataSet = DataHelper.Fill(SqlStr);

                dgv_Record.DataSource = DBDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
            }
        }

        private string  SearchMaterialName(string strMaterial_Code) //查询物料信息
        {
            try
            {
                string strMaterial_Name =null;
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@" SELECT Material_Code, Material_Name  FROM IMOS_TA_Material
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                           and Material_Code ='{3}'
                                           ", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, strMaterial_Code);
                DBDataSet = DataHelper.Fill(SqlStr);
                if (DBDataSet.Tables[0].Rows.Count >= 1)
                {
                    strMaterial_Name = DBDataSet.Tables[0].Rows[0]["Material_Name"].ToString();
                }
                return strMaterial_Name;
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
                return null;
            }
        }

        private string SearchMaterialCode(string strBin) //查询物料信息
        {
            try
            {
                string strMaterial_Code = null;
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@" SELECT Material_Code, Material_Name  FROM IMOS_Lo_Bin
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                           and Bin_No ='{3}' and  (Store_Code='1001' or  Store_Code='1002')
                                           ", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, strBin);
                DBDataSet = DataHelper.Fill(SqlStr);
                if (DBDataSet.Tables[0].Rows.Count >= 1)
                {
                    strMaterial_Code = DBDataSet.Tables[0].Rows[0]["Material_Code"].ToString();
                }
                return strMaterial_Code;
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
                return null;
            }
        }

        private void pnl_Store1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_SelectBin_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAssignBinNo form1 = new Monitor.FrmAssignBinNo();
                if (form1.ShowDialog() == DialogResult.OK)
                {
                    string strBin_No = form1.m_strBin;
                    OptionSetting.XTBinNoA = strBin_No + "#";
                    string strBar_Code = SearchMaterialCode(strBin_No);
                    OptionSetting.XTMsgA = "正在手工分配货道..." + Environment.NewLine + "Manually allocatin track...";
                    Application.DoEvents();

                    if (strBar_Code== null)
                    {
                        OptionSetting.XTMsgA = strBin_No + "#货道未设置型号" + Environment.NewLine + "NO Product Model iN Store";
                        return;
                    }
                    
                    //三菱PLC分道
                    int iBlack = 0;
                    int iAddress = 0;//1-4货道
                    if (int.Parse(strBin_No) > 4)
                    {
                        iAddress = 10; //5-8货道
                    }
                    object[] WBuff_FD = new object[2];
                    WBuff_FD[0] = 1;
                    WBuff_FD[1] = int.Parse(strBin_No);
                    bool result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, WBuff_FD);
                    if (!result)
                    {
                        SysBusinessFunction.WriteLog("MitsubishiPLC写入失败");
                        OptionSetting.XTMsgA = "MitsubishiPLC写入失败" + Environment.NewLine + "PLC Write Data exception"; 
                        lb_A_Msg.ForeColor = Color.Red;
                        return;
                    }

                    object[] RBuff_FD = new object[2];
                    for (int i = 0; i < 2; i++)
                    {
                        RBuff_FD[i] = 0;
                    }
                    ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out RBuff_FD);

                    SysBusinessFunction.WriteLog(string.Format("MitsubishiPLC分道应答【{0}】,分道为【{1}】", RBuff_FD[0].ToString(), RBuff_FD[1].ToString()));
                    //清除数据
                    int CoamingTick = GetTickCount();
                    while (true)
                    {
                        Thread.Sleep(1);
                        Application.DoEvents();
                        if (GetTickCount() - CoamingTick > 25000) //超时退出 重新下传 超时时间为5秒
                        {
                            string Msg = "MitsubishiPLC分道，未收到回应。";
                            SysBusinessFunction.WriteLog(Msg);
                            OptionSetting.XTMsgA = Msg + Environment.NewLine + "response didn't received From MitsubishiPLC";
                            return;//!!!!!!!!!!!!!!!!!
                        }

                        object[] Buf = new object[2];
                        Buf[0] = 0; Buf[1] = 0;
                        bool PLCRead = ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 2, out Buf);

                        if ((int)Buf[0] == 2) //应答字 上位机收到反馈标记2后将下传的信息置0
                        {
                            //只清空应答字
                            object[] writeBuf = new object[1];
                            writeBuf[0] = 0;
                            result = ControlMaster2.WriteData_Mitsubishi(iBlack, iAddress, writeBuf);
                            string Msg = "收到状态字=2，状态字写入0。";
                            SysBusinessFunction.WriteLog(Msg);
                            //pic_PlcState.Image = ConnImage[Convert.ToInt32(true)];//PLC状态
                            break;
                        }
                    }

                    string strWorkstation_No = "1";
                    if(int.Parse(strBin_No)>4)
                    {
                        strWorkstation_No = "2";
                    }

                    //存储U壳货道细表
                    string strSql = string.Format(@"Insert Into IMOS_Lo_Bin_Detail(Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name,
                                                                                        Bin_No,Bar_Code,Create_Time,Store_Code) Values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',GetDate(),'{8}')",
                                                      BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                      strBin_No, strBar_Code, strWorkstation_No);
                    DataHelper.Fill(strSql);



                    /////////////////////////////////////////////////////////////////////////
                    //////获取库存信息
                    ////DataSet DBDataSet = new DataSet();
                    ////string SqlStr = string.Format(@"select * from IMOS_LO_BIN a
                    ////                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                    ////                          and  Bin_No='{3}' 
                    ////                          ", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, strBin_No);
                    ////DBDataSet = DataHelper.Fill(SqlStr);
                    ////string strTransit_Qty = "0";
                    ////string strActual_Qty = "0";
                    ////if (DBDataSet.Tables[0].Rows.Count >= 1)
                    ////{
                    ////    strTransit_Qty = DBDataSet.Tables[0].Rows[0]["Transit_Qty"].ToString();
                    ////    strActual_Qty  = DBDataSet.Tables[0].Rows[0]["Actual_Qty"].ToString();
                    ////}
                    //////////////////////////////////////////////////////////////////////

                    //存储U壳货道表
                    ////int iActual_Qty = int.Parse(strActual_Qty);
                    ////iActual_Qty = iActual_Qty + 1;
                    ////strActual_Qty = iActual_Qty.ToString();

                    ////int iFullFlag = 0;
                    ////if (iActual_Qty == 20)
                    ////{
                    ////    iFullFlag = 1;
                    ////}

                    ////string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Actual_Qty = {0},FullFlag={1} ,Create_Time = GetDate() Where Bin_No = '{2}'",
                    ////                                      strActual_Qty, iFullFlag, strBin_No);
                    string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set in_Time = GetDate() Where Bin_No = '{0}'  and  (Store_Code='1001' or  Store_Code='1002')",
                                                          strBin_No);
                    DataHelper.Fill(AlarmSql);

                    m_bFindBinNo = true;
                    OptionSetting.XTMsgA = "手动分道成功" + Environment.NewLine + "Manual shunting succeeded";
                }
            }
            catch (Exception ex)
            {
                OptionSetting.XTMsgA = "手动分配货道异常"  + "Manual shunting failed";
                lb_A_Msg.ForeColor = Color.Red;
            }

        }


        public  string IntToString(int num)
        {
            byte[] btTmp = new byte[2];
            btTmp[0] = (byte)(num / 256);
            btTmp[1] = (byte)(num % 256);
            string strResult = System.Text.Encoding.ASCII.GetString(btTmp);
            return strResult;
        }

        private void GetBinNumberFromPLC()
        {
            int iBlack = 0;
            int iAddress = 100;
            try
            {
                object[] RBuff = new object[1];
                ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 40, out RBuff);

                for (int i = 0; i <= 7; i++)
                {
                    int iBin_No = i + 1;
                    int iTransit_Qty = (int)RBuff[i * 5 + 0];
                    int iActual_Qty = (int)RBuff[i * 5 + 1];
                    int iBin_Flag = (int)RBuff[i * 5 + 2];

                    int iFullFlag = 0;
                    if ((iActual_Qty + iTransit_Qty) >= 20)
                    {
                        iFullFlag = 1;
                    }
                    else if ((iActual_Qty + iTransit_Qty) == 0)
                    {
                        iFullFlag = -1;//无
                    }
                    else
                    {
                        iFullFlag = 0;//有，但不满
                    }
                    //string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Actual_Qty = {0},Transit_Qty ={1},FullFlag={2}  Where Bin_No = '{3}'  and  (Store_Code='1001' or  Store_Code='1002')",
                    //                                    iActual_Qty, iTransit_Qty, iFullFlag, iBin_No.ToString());
                    string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Actual_Qty = {0},Transit_Qty ={1},FullFlag={2},Bin_Flag=(CASE when  Bin_Flag=2 then 2 ELSE {4} end)  Where Bin_No = '{3}'  and  (Store_Code='1001' or  Store_Code='1002')",
                                                        iActual_Qty, iTransit_Qty, iFullFlag, iBin_No.ToString(), iBin_Flag);
                    DataHelper.Fill(AlarmSql);
                }
                
            }
            catch (Exception ex)
            {
                OptionSetting.XTMsgA = "获取货道库存异常:" + Environment.NewLine + "Exception in getting aisle inventory.."; 
                lb_A_Msg.ForeColor = Color.Red;
            }
        }



        private void CountQtyFromMitsubishiPLC(object o)
        {
            try
            {
                int iBlack = 0;  
                int iAddress = 100;

                object[] RBuff = new object[1];
                ControlMaster2.ReadData_Mitsubishi(iBlack, iAddress, 40, out RBuff);

                for (int i = 0; i <= 7; i++)
                {
                    int iBin_No = i + 1;  //货道号
                    int iTransit_Qty = (int)RBuff[i * 5 + 0];
                    int iActual_Qty = (int)RBuff[i * 5 + 1];
                    int iBin_Flag = (int)RBuff[i * 5 + 2];

                    int iFullFlag = 0;
                    if ((iActual_Qty + iTransit_Qty) >= 20)
                    {
                        iFullFlag = 1;
                    }
                    else if ((iActual_Qty + iTransit_Qty) == 0)
                    {
                        iFullFlag = -1;
                    }
                    else
                    {
                        iFullFlag = 0;
                    }
                    string AlarmSql = string.Format(@"UpDate IMOS_Lo_Bin Set Actual_Qty = {0},Transit_Qty ={1},FullFlag={2},Bin_Flag=(CASE when  Bin_Flag=2 then 2 ELSE {4} end)  Where Bin_No = '{3}'  and  (Store_Code='1001' or  Store_Code='1002')",
                                                        iActual_Qty, iTransit_Qty, iFullFlag, iBin_No.ToString(), iBin_Flag);
                    DataHelper.Fill(AlarmSql);
                }
            }
            catch (Exception ex)
            {
                OptionSetting.XTMsgA = "获取货道库存异常:" + Environment.NewLine + "Exception in getting aisle inventory..";
                lb_A_Msg.ForeColor = Color.Red;
            }
            finally
            {
                CheckCountFromMitsubishiPlcTimer.Change(2000, Timeout.Infinite);
            }
        }


        private void dgv_Store_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("{0}", e.Row.Index + 1); 
        }

        private void dgv_Record_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("{0}", e.Row.Index + 1);
        }



        //GA0C 6J E1 D  
        //      6H  = 0X3648
        //      6M  = 0X364D
        //      6K  = 0X364B
        //      6F  = 0X3646
        //////////int[] RBuff = new int[10];
        //////////GA,RBuff[1] = 0X4741;
        //////////0C,RBuff[2] = 0X3043;
        //////////6J,RBuff[3] = 0X364A;
        //////////E1,RBuff[4] = 0X4531;
        //////////D,RBuff[5] = 0X44;
        //////////RBuff[6] = 0X2020;
        //////////RBuff[7] = 0X2020;
        //////////RBuff[8] = 0X2020;
        //////////RBuff[9] = 0X2020;
        ////////////GA 0C 6B E1 D
        //////////string strMaterialCode = "";
        //////////for (int i = 1; i <= 9; i++)
        //////////{
        //////////    int iData1 = (int)RBuff[i];
        //////////    string strCode = IntToString(iData1);
        //////////    strMaterialCode = strMaterialCode + strCode;
        //////////}
        //////////strMaterialCode = strMaterialCode.Trim();
        //////////string str1 = IntToString(12544);
        //////////str1 = str1.Trim();
    }
}
