using Communication;
using ControlLogic.Control;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{

    public partial class FrmFrontCacheStoreMonitor : Form
    {
        #region 局部变量定义
        private System.Timers.Timer RefreshStoreBinDataTimer = new System.Timers.Timer(1000); //刷新库存数据Timer 
        private System.Timers.Timer RefreshOutTaskDataTimer = new System.Timers.Timer(2000); //刷新获取出库任务Timer

        private ArrayList BinFormList = new ArrayList(); //库位详细信息
        public static bool ScanConnOne = false; //扫描设备One连接状态
        public static bool BarScanStateOne = false; //条码扫描是否正常
        private static Thread ScanSocketThreadOne = null; // 创建用于接收服务端消息的 
        private static Socket ScanSocketOne = null;
        private static IPEndPoint ScanPointOne;
        private static int ScanReConnCountOne = 0;
        public static bool SerialPortStatusOne = false;
        private static int HisReceiveCountOne = 0;
        private static int ReceiveCountOne = 0;
        public static System.Threading.Timer CheckConnectionTimerOne;  //检查设备ONE连接状态Timer

        public static bool ScanConnTwo = false; //扫描设备Two连接状态
        public static bool BarScanStateTwo = false; //条码扫描是否正常
        private static Thread ScanSocketThreadTwo = null; // 创建用于接收服务端消息的 
        private static Socket ScanSocketTwo = null;
        private static IPEndPoint ScanPointTwo;
        private static int ScanReConnCountTwo = 0;
        public static bool SerialPortStatusTwo = false;
        private static int HisReceiveCountTwo = 0;
        private static int ReceiveCountTwo = 0;
        public static System.Threading.Timer CheckConnectionTimerTwo;  //检查设备Two连接状态Timer

        public int StoreBinCount = 0; //货道数量

        public static System.Threading.Timer GetStoStockDataTimer; //读取PLC货道信息

        public static System.Threading.Timer OutStockDataTimer; //出库操作

        #endregion

        public FrmFrontCacheStoreMonitor()
        {
            InitializeComponent();
        }

        private void InitData()
        {
            try
            {
                ControlMaster.SystemInitialization();//PLC 初始化
                GetStoStockDataTimer = new System.Threading.Timer(GetStoStockData, null, 0, Timeout.Infinite);//入库取得PLC数据
                OutStockDataTimer = new System.Threading.Timer(OutStock, null, 0, Timeout.Infinite);//出库取得PLC数据

                InitOne();//一号位扫码器初始化
                CheckConnectionTimerOne = new System.Threading.Timer(CheckConnectionStatusOne, null, 0, Timeout.Infinite);//以太网产品码扫码器A

                InitTwo();//二号位扫码器初始化
                CheckConnectionTimerTwo = new System.Threading.Timer(CheckConnectionStatusTwo, null, 0, Timeout.Infinite);//以太网产品码扫码器B

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.ToString());
            }
        }

        #region 窗体初始化
        private void FrmBoxBodyStoreMonitor_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            StoreBinCount = 6;
            ControlBox = false;

            InitControlData();//刷新信息
            SetStoreBinForm();//设置货道
            GetStoreBinData();//刷新货道
            GetOutTaskData();
            InitData();


        }

        private void InitControlData()
        {
            lbBarCodeA.Text = "";
            lbBarCodeB.Text = "";
            lbBinNoA.Text = "";
            lbBinNoB.Text = "";
            lbTipsA.Text = "";
            lbTipsB.Text = "";
        }

        #endregion

        #region 从PLC获取库存信息
        private void GetStoStockData(object state)
        {
            try
            {

                if (!ControlMaster.MasterPLCPLCConn) //读取PLC失败
                {
                    return;
                }
                int DataAddress = 0;
                int DataLen = 0;
                DataAddress = int.Parse(BaseSystemInfo.StockAddress);
                DataLen = int.Parse(BaseSystemInfo.Stocklength);
                object[] Buf = new object[DataLen];//库存
                for (int i = 0; i < DataLen; i++)
                {
                    Buf[i] = 0;
                }
                ControlMaster.ReadData(0, DataAddress, DataLen, out Buf);
                string sql = "";
                for (int i = 0; i < 6; i++)
                {
                    int Bin_No = i + 1;
                    int Transit_Qty = int.Parse(Buf[i * 5].ToString());
                    int Actual_Qty = int.Parse(Buf[i * 5 + 1].ToString());
                    int BinFlag = int.Parse(Buf[i * 5 + 2].ToString());
                    int FullFlag = int.Parse(Buf[i * 5 + 3].ToString());


                    sql = sql + string.Format(@"if exists(select 1 from IMOS_Lo_Bin where Bin_No={0})
                                                update IMOS_Lo_Bin
                                                set Transit_Qty = {1},Actual_Qty={2},Bin_Flag={3},FullFlag={4}
                                                where Bin_No = {0} and Store_Code = '{8}'
                                                else 
                                                Insert Into IMOS_Lo_Bin(Company_Code,Factory_Code,Product_Line_Code,Bin_No,Material_Code,Material_Name,Max_Qty,Transit_Qty,Actual_Qty) 
                                               Values ('{5}','{6}','{7}',{0},'','',20,{1},{2} );"
                                          , Bin_No, Transit_Qty, Actual_Qty, BinFlag, FullFlag, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode
                                          , "3001");
                }

                DataHelper.Fill(sql);
                GetStoreBinData();

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("库存" + ex.ToString());

            }
            finally
            {
                GetStoStockDataTimer.Change(3000, Timeout.Infinite);
            }
        }

        #endregion

        #region 设置货道数据
        private void SetStoreBinForm()
        {
            panel5.Width = 626;
            pnl_Store1.Width = 676;

            //            Application.DoEvents();
            for (int i = 0; i < 6; i++)
            {
                //                Application.DoEvents();
                FrmStoreDetail TempForm = new FrmStoreDetail();
                TempForm.FormBorderStyle = FormBorderStyle.None;
                TempForm.BinNo = i + 1;//货道号
                TempForm.MaxBinNo = 13;//货道数量
                TempForm.TopLevel = false;

                TempForm.Parent = pnl_Store1;
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



                TempForm.Show();
                BinFormList.Insert(0, TempForm);
            }
            //            Application.DoEvents();
        }
        #endregion

        #region 刷新库存
        private void GetStoreBinData()
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
                                          where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Store_Code = '{3}'
                                          order by a.Bin_No", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode
                                          , "3001");
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
                    StoreInfo.TransitQty = int.Parse(dr["Transit_Qty"].ToString()); //货道在途
                    StoreInfo.ActualQty = int.Parse(dr["Actual_Qty"].ToString());//货道实际库存
                    StoreInfo.BinFlag = int.Parse(dr["Bin_Flag"].ToString());//货道状态
                    OptionSetting.StoreBinDataList.Add(StoreInfo);

                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.ToString());
            }
        }
        #endregion

        #region 下传PLC不放行
        private void PLCNoReleaseA()
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    int WriteReleaseAddress = 201;
                    object[] WBuff = new object[1];
                    object[] RBuff = new object[1];
                    WBuff[0] = 2;
                    ControlMaster.ReadData(0, WriteReleaseAddress, 1, out RBuff);
                    if ("2".Equals(RBuff[0].ToString()))
                    {
                        return;
                    }
                    bool result = ControlMaster.WriteData(0, WriteReleaseAddress, WBuff);
                    if (!result)
                    {
                        SysBusinessFunction.WriteLog("下传信号异常......");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lbTipsA.Text = "下传PLC失败 Fail";
                    lbTipsA.ForeColor = Color.Red;
                    SysBusinessFunction.WriteLog(string.Format("一号位下传PLC失败:" + ex.Message));
                }
            }));
        }

        private void PLCNoReleaseB()
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    int WriteReleaseAddress = 201;
                    object[] RBuff = new object[1];
                    object[] WBuff = new object[1];
                    WBuff[0] = 2;
                    ControlMaster.ReadData(0, WriteReleaseAddress, 1, out RBuff);
                    if ("2".Equals(RBuff[0].ToString()))
                    {
                        return;
                    }
                    bool result = ControlMaster.WriteData(0, WriteReleaseAddress, WBuff);
                    if (!result)
                    {
                        SysBusinessFunction.WriteLog("下传信号异常......");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    lbTipsB.Text = "下传PLC失败 Fail";
                    lbTipsB.ForeColor = Color.Red;
                    SysBusinessFunction.WriteLog(string.Format("二号位下传失败:" + ex.Message));
                }
            }));
        }
        #endregion

        #region 下传PLC放行
        private void PLCReleaseA(int binNo, string code)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    int WriteReleaseAddress = 201;

                    object[] WBuff = new object[2];
                    WBuff[0] = 1;
                    WBuff[1] = binNo;
                    bool result = ControlMaster.WriteData(0, WriteReleaseAddress, WBuff);
                    if (!result)
                    {
                        SysBusinessFunction.WriteLog("下传信号异常......");
                        //  lbTipsA.Text = "下传信号异常 Fail";
                        return;
                    }

                }
                catch (Exception ex)
                {
                    lbTipsA.Text = "下传失败 Fail";
                    lbTipsA.ForeColor = Color.Red;
                    SysBusinessFunction.WriteLog(string.Format("下传失败:" + ex.Message));
                }
            }));
        }

        private void PLCReleaseB(int binNo, string code)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    int WriteReleaseAddress = 201;

                    object[] WBuff = new object[2];
                    WBuff[0] = 1;
                    WBuff[1] = binNo;
                    bool result = ControlMaster.WriteData(0, WriteReleaseAddress, WBuff);
                    if (!result)
                    {
                        SysBusinessFunction.WriteLog("下传信号异常......");
                        //                       lbTipsB.Text = "下传信号异常 Fail";
                        return;
                    }

                }
                catch (Exception ex)
                {
                    lbTipsB.Text = "下传失败 Fail";
                    lbTipsB.ForeColor = Color.Red;
                    SysBusinessFunction.WriteLog(string.Format("下传失败:" + ex.Message));
                }
            }));
        }
        #endregion

        #region 初始化扫码器A
        private void InitOne()
        {

            IPAddress SanIPOne = IPAddress.Parse(BaseSystemInfo.BarScanOneIP);//IP
            ScanPointOne = new IPEndPoint(SanIPOne, int.Parse(BaseSystemInfo.BarScanOnePort));//端口
            ScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocketOne.Blocking = true;
            try
            {
                ScanSocketOne.Connect(ScanPointOne);
                ScanConnOne = true;
            }
            catch (SocketException ex)
            {
                ScanConnOne = false;
                //   string TipInfo = string.Format("条码扫描设备连接出现异常.IP地址{0}端口{1}", SanIPOne, ScanPointOne);
                //   SysBusinessFunction.WriteLog(TipInfo);
                //   OptionSetting.MsgInfoA = "条码扫描设备异常 Fail";
                //   lbTipsA.Text = OptionSetting.MsgInfoA;
                //  lbTipsA.ForeColor = Color.Red;
            }

            ScanSocketThreadOne = new Thread(ScanRecMsgOne);
            ScanSocketThreadOne.IsBackground = true;
            ScanSocketThreadOne.Start();

        }
        #endregion

        #region 检查扫码器A状态重连
        private void CheckConnectionStatusOne(object o)
        {
            try
            {
                Thread.Sleep(5);
                SerialPortStatusOne = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCountOne = ReceiveCountOne;
                byte[] arrMsgRec = new byte[1];
                #region 条码扫描
                if (!ScanConnOne)
                {
                    try
                    {
                        if (ScanReConnCountOne == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", ScanPointOne.ToString()));
                        }
                        ScanReConnCountOne++;
                        ScanSocketOne = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocketOne.Blocking = true;
                        ScanSocketOne.Connect(ScanPointOne);
                        ScanConnOne = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", ScanReConnCountOne, ScanPointOne.ToString()));
                        ScanReConnCountOne = 0;
                    }
                    catch (SocketException ex)
                    {
                        //SysBusinessFunction.WriteLog(ex.ToString());
                        //OptionSetting.MsgInfoA = "条码扫描设备异常 Fail";                            
                        //lbTipsA.Text = OptionSetting.MsgInfoA;
                    }
                }

                try
                {
                    int sLen = ScanSocketOne.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConnOne = sLen == 1;
                }
                catch (Exception ex)
                {
                    //SysBusinessFunction.WriteLog(ex.ToString());
                    //ScanConnOne = false;
                    //OptionSetting.MsgInfoA = "条码扫描设备异常 Fail";                      
                    //lbTipsA.Text = OptionSetting.MsgInfoA;
                }
                #endregion

            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog(ex.ToString());
                //OptionSetting.MsgInfoA = "条码扫描设备异常 Fail";                    
                //lbTipsA.Text = OptionSetting.MsgInfoA;
            }
            finally
            {
                CheckConnectionTimerOne.Change(10000, Timeout.Infinite);
            }

        }
        #endregion

        #region 获取扫码器A扫描结果
        public void ScanRecMsgOne()
        {
            try
            {
                string strMsg = "";
                while (true)
                {
                    Thread.Sleep(5);
                    byte[] arrMsgRec = new byte[50];
                    // 将接收到的数据存入到输入  arrMsgRec中；  
                    int length = -1;
                    try
                    {
                        if (!ScanConnOne)
                        {
                            OptionSetting.ProductModeA = "";
                            OptionSetting.ModifyBinA = true;
                            RefreshTipsA();
                        }
                        length = ScanSocketOne.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConnOne = true;
                    }
                    catch (Exception ex)
                    {
                        ScanConnOne = false;
                        OptionSetting.ModifyBinA = true;
                        continue;
                    }
                    if ((strMsg.Trim().Length > 0) && (ScanConnOne))
                    {
                        BarCodeOneDataHandle(strMsg.Trim());
                    }

                }
            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog(string.Format("产品码异常", ex.ToString()));
                //OptionSetting.MsgInfoA = "产品码异常 Fail";
                //lbTipsA.Text = OptionSetting.MsgInfoA;
                //lbTipsA.ForeColor = Color.Red;
                OptionSetting.ProductModeA = "";
                OptionSetting.ModifyBinA = true;
                #region PLC 下传不放行
                PLCNoReleaseA();
                #endregion
            }


        }
        #endregion

        #region 一号工位产品码处理
        private void BarCodeOneDataHandle(string code)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    lbBarCodeA.Text = code;
                    OptionSetting.ProBarCodeA = code;
                    SysBusinessFunction.WriteLog(string.Format("前排寄存库一号位固定扫码器扫码：" + code));
                    //条码格式判断
                    if (code.Trim().Length == 0)
                    {
                        return;
                    }
                    if (code.ToUpper() == "NO READ")
                    {
                        OptionSetting.ScanFlagA = true;
                        OptionSetting.MsgInfoA = "一号工位产品码读取失败 Fail";
                        OptionSetting.ProBarCodeA = "NO READ";
                        OptionSetting.ProductModeA = "";
                        lbTipsA.Text = OptionSetting.MsgInfoA;
                        lbTipsA.ForeColor = Color.Red;
                        #region PLC 下传不放行
                        PLCNoReleaseA();
                        #endregion

                        return;
                    }
                    else if (code.Length != 20)
                    {
                        OptionSetting.ScanFlagA = true;
                        OptionSetting.MsgInfoA = "一号工位产品码格式不正确 Fail";
                        OptionSetting.ProBarCodeA = code;
                        OptionSetting.ProductModeA = "";
                        OptionSetting.ModifyBinA = true;
                        lbTipsA.Text = OptionSetting.MsgInfoA;
                        lbTipsA.ForeColor = Color.Red;
                        #region PLC 下传不放行
                        PLCNoReleaseA();
                        #endregion
                        return;
                    }
                    OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + "读取条码成功 OK";
                    string sMaterialCode = code.Substring(0, 11).Trim();//可扩展 条码前十一位是物料编码
                    //查询物料信息
                    string MaterialSQL = string.Format(@"SELECT A.Material_Code , A.Material_Name, A.Bin_No
	                                                    FROM dbo.IMOS_Lo_Bin AS A
	                                                    WHERE A.Material_Code = '{0}'AND A.Store_Code = '3001'
	                                                    AND A.Company_Code = '{1}' AND A.Factory_Code = '{2}'
	                                                    AND A.Product_Line_Code = '{3}' ", sMaterialCode ,
                                                        BaseSystemInfo.CompanyCode,
                                                        BaseSystemInfo.FactoryCode,
                                                        BaseSystemInfo.ProductLineCode);
                    DataSet ds = DataHelper.Fill(MaterialSQL);
                                                                       /*                System.Data.Common.DbParameter parameter = null;
                                                                                       parameter.ParameterName = "@Material_Code";
                                                                                       parameter.DbType = DbType.String;
                                                                                       parameter.Direction = ParameterDirection.Input;
                                                                                       parameter.Value = sMaterialCode;
                    DbParameter[] parameters = { new SqlParameter("@Material_Code", sMaterialCode),
                                                 new SqlParameter("@Store_Code", "3001"),
                                                 new SqlParameter("@Company_Code",BaseSystemInfo.CompanyCode),
                                                 new SqlParameter("@Factory_Code",BaseSystemInfo.FactoryCode),
                                                 new SqlParameter("Product_Line_Code",BaseSystemInfo.ProductLineCode)};
                    DataSet ds = DataHelper.ExecuteProcedure("up_PR_Bin_Query", new String[] { "IMOS_Lo_Bin" }, parameters);*/
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        OptionSetting.ProductModeA = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                        string sMaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        OptionSetting.BinNoA = ds.Tables[0].Rows[0]["Bin_No"].ToString();
                        lbBinNoA.Text = OptionSetting.BinNoA + "#";
                        lbTipsA.Text = OptionSetting.MsgInfoA;
                        lbTipsA.ForeColor = Color.Lime;
                        #region PLC 入库上传下传

                        int TransQtyAddress = 90 + (10 * (int.Parse(OptionSetting.BinNoA)));
                        int ActQtyAddress = 91 + (10 * (int.Parse(OptionSetting.BinNoA)));
                        int BinFlagAddress = 92 + (10 * (int.Parse(OptionSetting.BinNoA)));
                        int FullFlagAddress = 93 + (10 * (int.Parse(OptionSetting.BinNoA)));
                        int TransQty = 0;
                        int ActualQty = 0;
                        object[] RBuff = new object[1];
                        ControlMaster.ReadData(0, BinFlagAddress, 1, out RBuff);
                        if (!"1".Equals(RBuff[0].ToString().Trim()))
                        {
                            ControlMaster.ReadData(0, TransQtyAddress, 1, out RBuff);
                            if (!string.IsNullOrEmpty(RBuff[0].ToString().Trim()))
                            {
                                TransQty = int.Parse(RBuff[0].ToString().Trim());
                            }
                            ControlMaster.ReadData(0, ActQtyAddress, 1, out RBuff);
                            if (!string.IsNullOrEmpty(RBuff[0].ToString().Trim()))
                            {
                                ActualQty = int.Parse(RBuff[0].ToString().Trim());
                            }
                            if (TransQty + ActualQty < 20)
                            {
                                ControlMaster.ReadData(0, FullFlagAddress, 1, out RBuff);
                                if ("0".Equals(RBuff[0].ToString().Trim()))
                                {
                                    #region PLC 下传
                                    PLCReleaseA(int.Parse(OptionSetting.BinNoA), OptionSetting.ProductModeA);
                                    #endregion

                                    #region 修改明细表
                                    string sql = string.Format(@"INSERT INTO [IMOS_Lo_Bin_Detail] (
                                                                  [Company_Code]
                                                                  ,[Company_Name]
                                                                  ,[Factory_Code]
                                                                  ,[Factory_Name]
                                                                  ,[Product_Line_Code]
                                                                  ,[Product_Line_Name]
                                                                  ,[Bin_No]
                                                                  ,[Bar_Code]
                                                                  ,[Material_Status]
                                                                  ,[Create_Time]
                                                                  ,[Store_Code])
                                                                  VALUES
                                                                    ('{0}'
                                                                    ,'{1}'
                                                                    ,'{2}'
                                                                    ,'{3}'
                                                                    ,'{4}'
                                                                    ,'{5}'
                                                                    ,'{6}'
                                                                    ,'{7}'
                                                                    ,'{8}'
                                                                    ,GETDATE()
                                                                    ,'{9}')",
                                                                   BaseSystemInfo.CompanyCode
                                                                   , BaseSystemInfo.CompanyName
                                                                   , BaseSystemInfo.FactoryCode
                                                                   , BaseSystemInfo.FactoryName
                                                                   , BaseSystemInfo.ProductLineCode
                                                                   , BaseSystemInfo.ProductLineName
                                                                   , int.Parse(OptionSetting.BinNoA)
                                                                   , code
                                                                   , 0
                                                                   , "3001");
                                    DataHelper.Fill(sql);
                                    OptionSetting.ModifyBinA = false;
                                    OptionSetting.ProBarCodeA = "";
                                    OptionSetting.ProductModeA = "";
                                    #endregion
                                    GetOutTaskData();
                                }
                                else
                                {
                                    OptionSetting.MsgInfoA = "货道已满,请手动分道 Full";
                                    OptionSetting.ModifyBinA = true;
                                    lbTipsA.Text = OptionSetting.MsgInfoA;
                                    lbTipsA.ForeColor = Color.Red;
                                    #region PLC 下传不放行
                                    PLCNoReleaseA();
                                    #endregion
                                }
                            }
                            else
                            {
                                OptionSetting.MsgInfoA = "货道已满,请手动分道 Full";
                                OptionSetting.ModifyBinA = true;
                                lbTipsA.Text = OptionSetting.MsgInfoA;
                                lbTipsA.ForeColor = Color.Red;
                                #region PLC 下传不放行
                                PLCNoReleaseA();
                                #endregion
                            }
                        }
                        else
                        {
                            OptionSetting.MsgInfoA = "货道禁用状态,请手动分道 NG";
                            OptionSetting.ModifyBinA = true;
                            lbTipsA.Text = OptionSetting.MsgInfoA;
                            lbTipsA.ForeColor = Color.Red;
                            #region PLC 下传不放行
                            PLCNoReleaseA();
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        //                        OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("一号工位产品条码【{0}】的产品型号未维护 Fail", code);
                        OptionSetting.MsgInfoA = DateTime.Now.ToString("HH:mm:ss") + " " + "读取条码失败 Fail";
                        OptionSetting.BinNoA = "";
                        OptionSetting.ProductModeA = "";
                        OptionSetting.ModifyBinA = true;
                        lbTipsA.Text = OptionSetting.MsgInfoA;
                        lbTipsA.ForeColor = Color.Red;
                        #region PLC 下传不放行
                        PLCNoReleaseA();
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("一号工位接收条码异常！" + ex.Message);
                    OptionSetting.MsgInfoA = "一号工位接收条码异常,请手动分道 Fail";
                    OptionSetting.ModifyBinA = true;
                    lbTipsA.Text = OptionSetting.MsgInfoA;
                    lbTipsA.ForeColor = Color.Red;
                    #region PLC 下传不放行
                    PLCNoReleaseA();
                    #endregion
                }
            }));
        }
        #endregion

        #region 初始化扫码器B
        private void InitTwo()
        {
            IPAddress SanIPTwo = IPAddress.Parse(BaseSystemInfo.BarScanTwoIP);//IP
            ScanPointTwo = new IPEndPoint(SanIPTwo, int.Parse(BaseSystemInfo.BarScanTwoPort));//端口
            ScanSocketTwo = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ScanSocketTwo.Blocking = true;
            try
            {
                ScanSocketTwo.Connect(ScanPointTwo);
                ScanConnTwo = true;
            }
            catch (SocketException ex)
            {
                ScanConnTwo = false;
                //                    string TipInfo = string.Format("条码扫描设备连接出现异常.IP地址{0}端口{1}，", SanIPTwo, ScanPointTwo);
                // OptionSetting.MsgInfoB = "条码扫描设备异常 Fail";
                //                   SysBusinessFunction.WriteLog(TipInfo);
                //                   lbTipsB.Text = OptionSetting.MsgInfoB;
                //                   lbTipsB.ForeColor = Color.Red;
            }

            ScanSocketThreadTwo = new Thread(ScanRecMsgTwo);
            ScanSocketThreadTwo.IsBackground = true;
            ScanSocketThreadTwo.Start();

        }
        #endregion

        #region 检查扫码器B状态
        private void CheckConnectionStatusTwo(object o)
        {

            try
            {
                Thread.Sleep(5);
                SerialPortStatusTwo = true;// (HisReceiveCount != ReceiveCount);
                HisReceiveCountTwo = ReceiveCountTwo;
                byte[] arrMsgRec = new byte[1];

                #region 条码扫描
                if (!ScanConnTwo)
                {
                    try
                    {
                        if (ScanReConnCountTwo == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("条码扫描设备断线重连中......，{0}", ScanPointTwo.ToString()));
                        }
                        ScanReConnCountTwo++;
                        ScanSocketTwo = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        ScanSocketTwo.Blocking = true;
                        ScanSocketTwo.Connect(ScanPointTwo);
                        ScanConnTwo = true;
                        SysBusinessFunction.WriteLog(string.Format("条码扫描设备重新连接成功，重连次数{0}，{1}", ScanReConnCountTwo, ScanPointTwo.ToString()));
                        ScanReConnCountTwo = 0;
                    }
                    catch (SocketException ex)
                    {
                        //SysBusinessFunction.WriteLog(ex.ToString());
                        //  OptionSetting.MsgInfoB = "条码扫描设备异常 Fail";
                        // lbTipsB.Text = OptionSetting.MsgInfoB;
                    }
                }

                try
                {
                    int sLen = ScanSocketTwo.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConnTwo = sLen == 1;
                }
                catch (Exception ex)
                {
                    // SysBusinessFunction.WriteLog(ex.ToString());
                    //ScanConnTwo = false;
                    //OptionSetting.MsgInfoB = "条码扫描设备异常 Fail";
                    // lbTipsB.Text = OptionSetting.MsgInfoB;
                }
                #endregion

            }
            catch (Exception ex)
            {
                //  SysBusinessFunction.WriteLog(ex.ToString());
                //  OptionSetting.MsgInfoB = "条码扫描设备异常,请手动分道 Fail";
                //  lbTipsB.Text = OptionSetting.MsgInfoB;
            }
            finally
            {
                CheckConnectionTimerTwo.Change(10000, Timeout.Infinite);
            }
        }
        #endregion

        #region 获取扫码器B扫描结果
        public void ScanRecMsgTwo()
        {
            try
            {
                string strMsg = "";
                while (true)
                {
                    Thread.Sleep(5);
                    byte[] arrMsgRec = new byte[50];
                    // 将接收到的数据存入到输入  arrMsgRec中；  
                    int length = -1;
                    try
                    {
                        if (!ScanConnTwo)
                        {
                            OptionSetting.ProductModeB = "";
                            OptionSetting.ModifyBinB = true;
                            RefreshTipsB();
                        }
                        length = ScanSocketTwo.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConnTwo = true;
                    }
                    catch (Exception ex)
                    {
                        ScanConnTwo = false;
                        OptionSetting.ModifyBinB = true;
                        continue;
                    }
                    if ((strMsg.Trim().Length > 0) && (ScanConnTwo))
                    {
                        BarCodeTwoDataHandle(strMsg.Trim());
                    }

                }
            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog(string.Format("产品码异常", ex.ToString()));
                //OptionSetting.MsgInfoB = "产品码异常 Fail";
                //lbTipsB.Text = OptionSetting.MsgInfoB;
                //lbTipsB.ForeColor = Color.Red;
                OptionSetting.ProductModeB = "";
                OptionSetting.ModifyBinB = true;
                #region PLC 下传不放行
                PLCNoReleaseB();
                #endregion
            }


        }
        #endregion

        #region 二号工位产品码处理
        private void BarCodeTwoDataHandle(string code)
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    lbBarCodeB.Text = code;
                    OptionSetting.ProBarCodeB = code;
                    SysBusinessFunction.WriteLog(string.Format("前排寄存库二号位固定扫码器扫码：" + code));
                    //条码格式判断
                    if (code.Trim().Length == 0)
                    {
                        return;
                    }
                    if (code.ToUpper() == "NO READ")
                    {
                        OptionSetting.ScanFlagB = true;
                        OptionSetting.MsgInfoB = "二号工位产品码读取失败 Fail";
                        OptionSetting.ProBarCodeB = "NO READ";
                        OptionSetting.ProductModeB = "";
                        OptionSetting.ModifyBinB = true;
                        lbTipsB.Text = OptionSetting.MsgInfoB;
                        lbTipsB.ForeColor = Color.Red;
                        #region PLC 下传不放行
                        PLCNoReleaseB();
                        #endregion

                        return;
                    }
                    else if (code.Length != 20)
                    {
                        OptionSetting.ScanFlagB = true;
                        OptionSetting.MsgInfoB = "二号工位产品码格式不正确 Fail";
                        OptionSetting.ProBarCodeB = code;
                        OptionSetting.ProductModeB = "";
                        OptionSetting.ModifyBinB = true;
                        lbTipsB.Text = OptionSetting.MsgInfoB;
                        lbTipsB.ForeColor = Color.Red;
                        #region PLC 下传不放行
                        PLCNoReleaseB();
                        #endregion

                        return;
                    }
                    OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + "读取条码成功 OK";
                    string sMaterialCode = code.Substring(0, 11).Trim();//可扩展 条码前十一位是物料编码
                    //查询物料信息
                    string MaterialSQL = string.Format(@"SELECT A.Material_Code , A.Material_Name, A.Bin_No
	                                                    FROM dbo.IMOS_Lo_Bin AS A
	                                                    WHERE A.Material_Code = '{0}'AND A.Store_Code = '3001'
	                                                    AND A.Company_Code = '{1}' AND A.Factory_Code = '{2}'
	                                                    AND A.Product_Line_Code = '{3}' ", sMaterialCode,
                                     BaseSystemInfo.CompanyCode,
                                     BaseSystemInfo.FactoryCode,
                                     BaseSystemInfo.ProductLineCode);
                    DataSet ds = DataHelper.Fill(MaterialSQL);
                    /*                System.Data.Common.DbParameter parameter = null;
                                    parameter.ParameterName = "@Material_Code";
                                    parameter.DbType = DbType.String;
                                    parameter.Direction = ParameterDirection.Input;
                                    parameter.Value = sMaterialCode;
DbParameter[] parameters = { new SqlParameter("@Material_Code", sMaterialCode),
new SqlParameter("@Store_Code", "3001"),
new SqlParameter("@Company_Code",BaseSystemInfo.CompanyCode),
new SqlParameter("@Factory_Code",BaseSystemInfo.FactoryCode),
new SqlParameter("Product_Line_Code",BaseSystemInfo.ProductLineCode)};
DataSet ds = DataHelper.ExecuteProcedure("up_PR_Bin_Query", new String[] { "IMOS_Lo_Bin" }, parameters);*/
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        OptionSetting.ProductModeB = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                        string sMaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                        OptionSetting.BinNoB = ds.Tables[0].Rows[0]["Bin_No"].ToString();
                        lbBinNoB.Text = OptionSetting.BinNoB + "#";
                        lbTipsB.Text = OptionSetting.MsgInfoB;
                        lbTipsB.ForeColor = Color.Lime;
                        #region PLC 上传

                        int TransQtyAddress = 95 + (5 * (int.Parse(OptionSetting.BinNoB)));
                        int ActQtyAddress = 96 + (5 * (int.Parse(OptionSetting.BinNoB)));
                        int BinFlagAddress = 97 + (5 * (int.Parse(OptionSetting.BinNoB)));
                        int FullFlagAddress = 98 + (5 * (int.Parse(OptionSetting.BinNoB)));
                        int TransQty = 0;
                        int ActualQty = 0;
                        object[] RBuff = new object[1];
                        ControlMaster.ReadData(0, BinFlagAddress, 1, out RBuff);
                        if (!"1".Equals(RBuff[0].ToString().Trim()))
                        {
                            ControlMaster.ReadData(0, TransQtyAddress, 1, out RBuff);
                            if (!string.IsNullOrEmpty(RBuff[0].ToString().Trim()))
                            {
                                TransQty = int.Parse(RBuff[0].ToString().Trim());
                            }
                            ControlMaster.ReadData(0, ActQtyAddress, 1, out RBuff);
                            if (!string.IsNullOrEmpty(RBuff[0].ToString().Trim()))
                            {
                                ActualQty = int.Parse(RBuff[0].ToString().Trim());
                            }
                            if (TransQty + ActualQty < 20)
                            {
                                ControlMaster.ReadData(0, FullFlagAddress, 1, out RBuff);
                                if ("0".Equals(RBuff[0].ToString().Trim()))
                                {
                                    #region PLC 下传
                                    PLCReleaseB(int.Parse(OptionSetting.BinNoB), OptionSetting.ProductModeB);
                                    #endregion

                                    #region 修改明细表
                                    string sql = string.Format(@"INSERT INTO [IMOS_Lo_Bin_Detail] (
                                                                  [Company_Code]
                                                                  ,[Company_Name]
                                                                  ,[Factory_Code]
                                                                  ,[Factory_Name]
                                                                  ,[Product_Line_Code]
                                                                  ,[Product_Line_Name]
                                                                  ,[Bin_No]
                                                                  ,[Bar_Code]
                                                                  ,[Material_Status]
                                                                  ,[Create_Time]
                                                                  ,[Store_Code]
                                                                  )
                                                                  VALUES
                                                                    ('{0}'
                                                                    ,'{1}'
                                                                    ,'{2}'
                                                                    ,'{3}'
                                                                    ,'{4}'
                                                                    ,'{5}'
                                                                    ,'{6}'
                                                                    ,'{7}'
                                                                    ,{8}
                                                                    ,GETDATE()
                                                                    ,'{9}')",
                                                                   BaseSystemInfo.CompanyCode
                                                                   , BaseSystemInfo.CompanyName
                                                                   , BaseSystemInfo.FactoryCode
                                                                   , BaseSystemInfo.FactoryName
                                                                   , BaseSystemInfo.ProductLineCode
                                                                   , BaseSystemInfo.ProductLineName
                                                                   , int.Parse(OptionSetting.BinNoB)
                                                                   , code
                                                                   , 0
                                                                   , "3001");
                                    DataHelper.Fill(sql);
                                    OptionSetting.ModifyBinB = false;
                                    OptionSetting.ProBarCodeB = "";
                                    OptionSetting.ProductModeB = "";
                                    #endregion
                                    GetOutTaskData();
                                }
                                else
                                {
                                    OptionSetting.MsgInfoB = "货道已满,请手动分道 Full";
                                    OptionSetting.ModifyBinB = true;
                                    lbTipsB.Text = OptionSetting.MsgInfoB;
                                    lbTipsB.ForeColor = Color.Red;
                                    #region PLC 下传不放行
                                    PLCNoReleaseB();
                                    #endregion
                                }
                            }
                            else
                            {
                                OptionSetting.MsgInfoB = "货道已满,请手动分道 Full";
                                OptionSetting.ModifyBinB = true;
                                lbTipsB.Text = OptionSetting.MsgInfoB;
                                lbTipsB.ForeColor = Color.Red;
                                #region PLC 下传不放行
                                PLCNoReleaseB();
                                #endregion
                            }
                        }
                        else
                        {
                            OptionSetting.MsgInfoB = "货道禁用状态,请手动分道 NG";
                            OptionSetting.ModifyBinB = true;
                            lbTipsB.Text = OptionSetting.MsgInfoB;
                            lbTipsB.ForeColor = Color.Red;
                            #region PLC 下传不放行
                            PLCNoReleaseB();
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        //                        OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("二号工位产品条码【{0}】的产品型号未维护", code);
                        OptionSetting.MsgInfoB = DateTime.Now.ToString("HH:mm:ss") + " " + "读取条码失败 Fail";
                        OptionSetting.BinNoB = "";
                        OptionSetting.ProductModeB = "";
                        OptionSetting.ModifyBinB = true;
                        lbTipsB.Text = OptionSetting.MsgInfoB;
                        lbTipsB.ForeColor = Color.Red;
                        #region PLC 下传不放行
                        PLCNoReleaseB();
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("二号工位接收条码异常！" + ex.Message);
                    OptionSetting.MsgInfoB = "二号工位接收条码异常,请手动分道 Fail";
                    OptionSetting.ModifyBinB = true;
                    lbTipsB.Text = OptionSetting.MsgInfoB;
                    lbTipsB.ForeColor = Color.Red;
                    #region PLC 下传不放行
                    PLCNoReleaseB();
                    #endregion
                }
            }));
        }

        #endregion

        #region 一号工位手动分道
        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OptionSetting.ModifyBinA)
                {
                    return;
                }
                if (string.IsNullOrEmpty(OptionSetting.ProBarCodeA))
                {
                    lbTipsA.Text = "无法获取物料编码 Fail";
                    lbTipsA.ForeColor = Color.Red;
                }               
                FrmFrontCacheBinModify ModifyForm = new FrmFrontCacheBinModify(OptionSetting.ProBarCodeA);
                ModifyForm.Process_Flag = false;
                DialogResult r = ModifyForm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    lbBinNoA.Text = OptionSetting.BinNoA+"#";
                    OptionSetting.ProBarCodeA = "";
                    OptionSetting.ProductModeA = "";
                    GetOutTaskData();
                }
                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("手动分道!" + ex.Message);
            }
        }
        #endregion

        #region 二号工位手动分道
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!OptionSetting.ModifyBinB)
                {
                    return;
                }
                if (string.IsNullOrEmpty(OptionSetting.ProBarCodeB))
                {
                    lbTipsB.Text = "无法获取物料编码 Fail";
                    lbTipsB.ForeColor = Color.Red;
                }
                FrmFrontCacheBinModify ModifyForm = new FrmFrontCacheBinModify(OptionSetting.ProBarCodeB);
                ModifyForm.Process_Flag = true;
                DialogResult r = ModifyForm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    lbBinNoB.Text = OptionSetting.BinNoB + "#";
                    OptionSetting.ProBarCodeB = "";
                    OptionSetting.ProductModeB = "";
                    GetOutTaskData();
                }
                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("手动分道!" + ex.Message);
            }
        }
        #endregion

        #region 出库操作
        private void OutStock(object state)
        {
            try
            {
                int ReadAddress = 0;
                int ReadLen = 1;
                object[] RBuf = new object[ReadLen];

                int WriteAddress = 1;
                int WriteLen = 2;
                object[] WriteBuf = new object[WriteLen];

                string sql = "";
                string mCode = "";
                string binNo = "";
                string detailID = "";
                DataSet ds = new DataSet();

                bool result = ControlMaster.ReadData(0, ReadAddress, ReadLen, out RBuf);
                if (!result)
                {
                    SysBusinessFunction.WriteLog("出库操作PLC上传信号异常");
                    return;
                }
                string flag = RBuf[0].ToString();
                if (string.IsNullOrEmpty(flag))
                {
                    SysBusinessFunction.WriteLog("PLC没有设置出库请求位");
                    return;
                }
                if (!"1".Equals(flag))
                {
                    SysBusinessFunction.WriteLog("PLC没有准备好出库");
                    return;
                }
                else
                {
                    sql = string.Format(@"select 
                                        a.Bin_List_ID , a.Bar_Code , a.Bin_No 
                                        from IMOS_Lo_Bin_Detail a, IMOS_Lo_Bin b
                                        where a.Material_Status = 0 
                                        and b.Bin_Flag = 0 
                                        and a.Bin_No = b.Bin_No and a.Store_Code = '{0}'
                                        and a.Company_Code = '{1}'
                                        and a.Factory_Code = '{2}'
                                        and a.Product_Line_Code ='{3}'
                                        order by a.Bin_List_ID", "3001", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                    ds = DataHelper.Fill(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        detailID = ds.Tables[0].Rows[0][0].ToString();
                        binNo = ds.Tables[0].Rows[0][2].ToString();
                        sql = string.Format(@"select count(Bin_List_ID) 
                                            from IMOS_Lo_Bin_Detail
                                            where Bin_No = {0} and 
                                            Material_Status = 0  and Store_Code = '{1}'
                                            and Company_Code = '{2}'
                                            and Factory_Code = '{3}'
                                            and Product_Line_Code ='{4}'
                                            ", int.Parse(binNo), "3001", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                        ds = DataHelper.Fill(sql);
                        int DetailTransQty = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                        int TransQtyAddress = 95 + (5 * (int.Parse(binNo)));
                        //                       int ActQtyAddress = 96 + (5 * (int.Parse(binNo)));
                        int TransQty = 0;
                        //                        int ActualQty = 0;
                        ControlMaster.ReadData(0, TransQtyAddress, 1, out RBuf);
                        if (!string.IsNullOrEmpty(RBuf[0].ToString().Trim()))
                        {
                            TransQty = int.Parse(RBuf[0].ToString().Trim());
                        }

                        if (TransQty < DetailTransQty)
                        {
                            int BinFlagAddress = 97 + (5 * (int.Parse(binNo)));
                            ControlMaster.ReadData(0, BinFlagAddress, 1, out RBuf);
                            if (!"1".Equals(RBuf[0].ToString().Trim()))
                            {
                                WriteBuf[0] = 1;
                                WriteBuf[1] = int.Parse(binNo);
                                //                                WriteBuf[2] = mCode;
                                ControlMaster.WriteData(0, WriteAddress, WriteBuf);
                                sql = string.Format(@"update IMOS_Lo_Bin_Detail set Material_Status = 1 , Out_Time = GETDATE() where Bin_List_ID = {0} and Store_Code = '{1}'
                                                     and Company_Code = '{2}'
                                                     and Factory_Code = '{3}'
                                                     and Product_Line_Code ='{4}' "
                                                    , int.Parse(detailID), "3001", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                                DataHelper.Fill(sql);
                                GetOutTaskData();
                            }
                            else
                            {
                                SysBusinessFunction.WriteLog("货道禁用状态");
                            }
                        }
                    }
                    else if (ds.Tables[0].Rows.Count == 0)
                    {
                        SysBusinessFunction.WriteLog("货道没有产品");
                    }
                    object[] WriteBuffer = new object[1];
                    WriteBuffer[0] = 0;
                    ControlMaster.WriteData(0, 0, WriteBuffer);
                  
                    /*                     sql = string.Format(@"select Material_Code 
                                                            from IMOS_Lo_Bin_Plan
                                                            where Complete_Qty < Out_Qty 
                                                            order by Material_ID");
                                        ds = DataHelper.Fill(sql);
                                        if(ds.Tables[0].Rows.Count == 0)
                                        {
                                            SysBusinessFunction.WriteLog("出库规则表为空或已完成所有任务");
                                            return;
                                        }
                                        else
                                        {

                                           mCode = ds.Tables[0].Rows[0][0].ToString();
                                            sql = string.Format(@"select Bin_No from IMOS_Lo_Bin 
                                                                  where Material_Code = '{0}' 
                                                                  and Actual_Qty > 0
                                                                ",mCode);
                                            ds = DataHelper.Fill(sql);
                                            if(ds.Tables[0].Rows.Count == 0)
                                            {
                                                SysBusinessFunction.WriteLog("查询不到该产品编码所在的货道");
                                                return;
                                            }
                                            else
                                            {
                                                binNo = ds.Tables[0].Rows[0][0].ToString();
                                                int BinFlagAddress = 97 + (5 * (int.Parse(binNo)));
                                                ControlMaster.ReadData(0, BinFlagAddress, 1, out RBuf);
                                                if (!"0".Equals(RBuf[0].ToString().Trim()))
                                                {
                                                    WriteBuf[0] = 1;
                                                    WriteBuf[1] = int.Parse(binNo);
                                                    WriteBuf[2] = mCode;
                                                    ControlMaster.WriteData(0, WriteAddress, WriteBuf);
                                                    sql = string.Format(@"update IMOS_Lo_Bin_Plan set Complete_Qty = Complete_Qty + 1 where Material_Code = '{0}'", mCode);
                                                    DataHelper.Fill(sql);
                                                }
                                                else
                                                {
                                                    SysBusinessFunction.WriteLog("货道禁用状态");
                                                }
                                            }
                                        }*/

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("前排缓存库出库" + ex.ToString());
            }
            finally
            {
                OutStockDataTimer.Change(3000, Timeout.Infinite);
            }
        }
        #endregion

        #region 获取等待出库任务
        private void GetOutTaskData()
        {
            BeginInvoke(new Action(() =>
            {
                try
            {
                string sql = string.Format(@"select top 10 a.Bin_No ,a.Bar_Code,
                                    (Case when a.Material_Status = 0   then '等待 Waiting' else '错误 Error' End) as Material_Status
                                    from IMOS_Lo_Bin_Detail a 
                                    where a.Material_Status = 0 
                                    and a.Store_Code = '{0}'
                                    and a.Company_Code = '{1}'
                                    and a.Factory_Code = '{2}'
                                    and a.Product_Line_Code ='{3}'
                                    order by a.Bin_List_ID", "3001",BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode);
                DataSet ds = DataHelper.Fill(sql);
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    //判断条码是否符合格式 1.满足20位 
                    if(dr["Bar_Code"].ToString().Length == 20)
                    {
                        dr["Bar_Code"] = GetMaterialName(dr["Bar_Code"].ToString());
                    }
                   
                }
                    


                dgvCommon.DataSource = ds.Tables[0]; 
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("获取等待出库任务异常" + ex.ToString()));
            }
        }));
        }

        private string GetMaterialName(string v)
        {
           try
            {
                String sql = String.Format(@"Select Material_Name From IMOS_TA_Material Where Material_Code = '{0}'  
                                            And Company_Code = '{1}'
                                            And Factory_Code = '{2}'
                                            And Product_Line_Code ='{3}'
                                            Group by Material_Name", v.Substring(0, 11), BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DataSet ds = DataHelper.Fill(sql);
                if (ds!=null&&ds.Tables[0].Rows.Count == 1)
                {
                    return ds.Tables[0].Rows[0]["Material_Name"].ToString();
                }else
                {
                    return "";
                }

            }catch(Exception ex)
            {
                return "";
            }
        }

        #endregion


        #region 扫码器断开连接时刷新界面
        private void RefreshTipsA()
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    lbTipsA.Text = "连接失败无法获取物料编码 Fail";
                    lbTipsA.ForeColor = Color.Red;
                }
                catch(Exception ex)
                {

                }
            }));
        }

        private void RefreshTipsB()
        {
            BeginInvoke(new Action(() =>
            {
                try
                {
                    lbTipsB.Text = "连接失败无法获取物料编码 Fail";
                    lbTipsB.ForeColor = Color.Red;
                }
                catch (Exception ex)
                {

                }
            }));
        }
        #endregion

        #region 列编号自动改变
        private void dgvCommon_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                for(int i = 0; i < dgvCommon.Rows.Count; i++)
                {
                    dgvCommon.Rows[i].Cells["ID"].Value = i + 1;
                }
            }catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
