using Sys.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlLogic;
using Sys.SysBusiness;
using Sys.DbUtilities;

namespace Monitor
{
    public partial class FrmFillMonitor : Form
    {
        public FrmFillMonitor()
        {
            InitializeComponent();
        }
        #region 定义PLC数据类
        public class PLCProData
        {
            public string RequestFlag;//请求标志           
            public string sProdCode;//产品编码
            public string sPerfusion;//灌注量
        }
        #endregion

        public static System.Threading.Timer DataProcessingTimer;//数据处理
        //Random sRand = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OptionSetting.MonitorRefreshFlag1 == true)
            {
                LoadDataA();
                OptionSetting.MonitorRefreshFlag1 = false;
            }
            if (OptionSetting.MonitorRefreshFlag2 == true)
            {
                LoadDataB();
                OptionSetting.MonitorRefreshFlag2 = false;
            }
            if (OptionSetting.MonitorRefreshFlag3 == true)
            {
                LoadDataC();
                OptionSetting.MonitorRefreshFlag3 = false;
            }
            if (OptionSetting.MonitorRefreshFlag4 == true)
            {
                LoadDataD();
                OptionSetting.MonitorRefreshFlag4 = false;
            }

        }
        #region 加载数据
        private void LoadDataD()
        {           
            lbl_BarCode4.Text = OptionSetting.ProBarCode4;            
            lbl_FillCont4.Text = OptionSetting.Perfusion4;           
            lbl_ProductInfo4.Text = GetMaterialInfo(OptionSetting.ProBarCode4);           
            cht_DY4.Series[0].Points.AddXY(DateTime.Now.ToString("HH:mm"), float.Parse(OptionSetting.Perfusion4));
            if (cht_DY4.Series[0].Points.Count > cht_DY4.ChartAreas[0].AxisX.Maximum)
            {
                cht_DY4.Series[0].Points.RemoveAt(0);
            }

        }
        private void LoadDataA()
        {
            lbl_BarCode1.Text = OptionSetting.ProBarCode1;           
            lbl_FillCont1.Text = OptionSetting.Perfusion1;           
            lbl_ProductInfo1.Text = GetMaterialInfo(OptionSetting.ProBarCode1);
            cht_DY1.Series[0].Points.AddXY(DateTime.Now.ToString("HH:mm"), float.Parse(OptionSetting.Perfusion1));
            if (cht_DY1.Series[0].Points.Count > cht_DY1.ChartAreas[0].AxisX.Maximum)
            {
                cht_DY1.Series[0].Points.RemoveAt(0);
            }
           

        }
        private void LoadDataB()
        {
           
            lbl_BarCode2.Text = OptionSetting.ProBarCode2;                       
            lbl_FillCont2.Text = OptionSetting.Perfusion2;            
            lbl_ProductInfo2.Text = GetMaterialInfo(OptionSetting.ProBarCode2);           
            cht_DY2.Series[0].Points.AddXY(DateTime.Now.ToString("HH:mm"), float.Parse(OptionSetting.Perfusion2));
            if (cht_DY2.Series[0].Points.Count > cht_DY2.ChartAreas[0].AxisX.Maximum)
            {
                cht_DY2.Series[0].Points.RemoveAt(0);
            }
           

        }
        private void LoadDataC()
        {
           
            lbl_BarCode3.Text = OptionSetting.ProBarCode3;            
            lbl_FillCont3.Text = OptionSetting.Perfusion3;            
            lbl_ProductInfo3.Text = GetMaterialInfo(OptionSetting.ProBarCode3);                       
            cht_DY3.Series[0].Points.AddXY(DateTime.Now.ToString("HH:mm"), float.Parse(OptionSetting.Perfusion3));
            if (cht_DY3.Series[0].Points.Count > cht_DY3.ChartAreas[0].AxisX.Maximum)
            {
                cht_DY3.Series[0].Points.RemoveAt(0);
            }
           

        }
        #endregion

        #region 获取物料信息
        private static string  GetMaterialInfo(string sProdBarCode)
        {
            string MCode = "";
            try
            {                
                DataSet ds = new DataSet();
                string sMaterialCode = sProdBarCode.Substring(0,5);
                if (!string.IsNullOrEmpty(sMaterialCode))
                {
                    string SqlStr = string.Format(@"SELECT  Material_Code,Material_Name  
                                                         FROM IMOS_TA_Material 
                                                         WHERE Material_Code = '{0}'", sMaterialCode
                                                  );
                    ds = DataHelper.Fill(SqlStr);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        MCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                                              
                    }
                }
                return MCode;
            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog("查询物料信息异常" + ex.ToString());
                return MCode;
            }

        }


        #endregion

        private static void DataFun(object state)
        {
            try
            {
                StartLinkFunC(1);
                StartLinkFunC(2);
                StartLinkFunC(3);
                StartLinkFunC(4);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DataProcessingTimer.Change(1000, Timeout.Infinite);
            }
        }
        private static void StartLinkFunC(int state)
        {
            try
            {
                #region 基础数据处理
                if (!ControlData.MasterPLCPLCConn) //读取PLC失败
                {
                    //SysBusinessFunction.WriteLog("读取设备状态PLC数据失败，请检查PLC连接.");
                    return;
                }
                PLCProData ProData = new PLCProData();//PLC获取数据及状态
                int DataBlock = 0;//地址块
                int DataAddress = 0;//开始地址

                switch (state.ToString())
                {
                    case "1":                       
                        DataAddress = int.Parse(BaseSystemInfo.MonitorAddress1);                                              
                        break;
                    case "2":                       
                        DataAddress = int.Parse(BaseSystemInfo.MonitorAddress2);                                               
                        break;
                    case "3":                       
                        DataAddress = int.Parse(BaseSystemInfo.MonitorAddress3);                                              
                        break;
                    case "4":                       
                        DataAddress = int.Parse(BaseSystemInfo.MonitorAddress4);                                              
                        break;
                    default:
                        break;
                }

                #endregion

                #region  获取PLC数据
                try
                {
                    //获取PLC地址
                    int DataLen = 23;//长度
                    object[] Buf = new object[DataLen];//定义存放从PLC获取数据的数组
                    //初始化数组
                    for (int j = 0; j < DataLen; j++)
                    {
                        Buf[j] = 0;
                    }
                    bool PLCRead = ControlData.MasterPLC.Read("0", DataAddress, DataLen, out Buf);//读取PLC
                    //解析数据
                    ProData = new PLCProData();
                    ProData.RequestFlag = Buf[0].ToString();//请求标志位                   
                    ProData.sProdCode = GetStringPLCData(1, 20, Buf);//产品码
                    ProData.sPerfusion = Buf[21].ToString();//灌注量

                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog(string.Format("【{0}】#获取PLC数据异常！" + ex.Message, state.ToString()));
                }
                #endregion

                #region 数据处理
                try
                {
                    if (ProData.RequestFlag=="1")
                    {
                        switch (state.ToString())
                        {
                            case "1":
                                OptionSetting.ProBarCode1 = ProData.sProdCode;
                                OptionSetting.Perfusion1 = ProData.sPerfusion;
                                OptionSetting.MonitorRefreshFlag1 = true;
                                break;
                            case "2":
                                OptionSetting.ProBarCode2 = ProData.sProdCode;
                                OptionSetting.Perfusion2 = ProData.sPerfusion;
                                OptionSetting.MonitorRefreshFlag2 = true;
                                break;
                            case "3":
                                OptionSetting.ProBarCode3 = ProData.sProdCode;
                                OptionSetting.Perfusion3 = ProData.sPerfusion;
                                OptionSetting.MonitorRefreshFlag3 = true;
                                break;
                            case "4":
                                OptionSetting.ProBarCode4 = ProData.sProdCode;
                                OptionSetting.Perfusion4 = ProData.sPerfusion;
                                OptionSetting.MonitorRefreshFlag4 = true;
                                break;
                            default:
                                break;
                        }
                        object[] DownBuff = new object[1];
                        DownBuff[0] = 2;
                        bool PLCWrite = ControlData.MasterPLC.Write(0, DataAddress, DownBuff);
                        if (PLCWrite)
                        {
                            
                            SysBusinessFunction.WriteLog(string.Format("【{0}】#读取完成标志下传成功！", state.ToString()));
                        }
                        else
                        {
                            SysBusinessFunction.WriteLog(string.Format("【{0}】#读取完成标志下传失败！", state.ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {

                    
                }
                #endregion
            }
            catch (Exception ex)
            {



            }
        }

        #region PLC数据转换处理
        private static string GetStringPLCData(int addr, int DataLen, object[] DataBuff)
        {
            string reStr = "";
            try
            {

                for (int i = addr; i < (addr + DataLen); i++) //读取PLC数据 
                {
                    int AsciiCode = (int)DataBuff[i];
                    if (AsciiCode == 0)
                    {
                        break;
                    }
                    reStr = reStr + SysBusinessFunction.ReverseString(SysBusinessFunction.BinaryToStr(AsciiCode));
                    //reStr = reStr + SysBusinessFunction.BinaryToStr(AsciiCode);
                }
            }
            catch (Exception ex)
            {
                reStr = "";
            }
            return reStr;
        }
        #endregion

        private void FrmFillMonitor_Load(object sender, EventArgs e)
        {
            lbl_BarCode1.Text = "";
            lbl_BarCode2.Text = "";
            lbl_BarCode3.Text = "";
            lbl_BarCode4.Text = "";
            lbl_FillCont1.Text = "";
            lbl_FillCont2.Text = "";
            lbl_FillCont3.Text = "";
            lbl_FillCont4.Text = "";
            lbl_ProductInfo1.Text = "";
            lbl_ProductInfo2.Text = "";
            lbl_ProductInfo3.Text = "";
            lbl_ProductInfo4.Text = "";

            int MaxCount = 20;
            cht_DY1.ChartAreas[0].AxisX.Maximum = MaxCount;
            cht_DY1.ChartAreas[0].AxisX.Interval = 1;
            cht_DY1.ChartAreas[0].AxisY.Maximum = 3;
            cht_DY1.ChartAreas[0].AxisY.Minimum = 1;
            cht_DY1.ChartAreas[0].AxisY.Interval = 1;

            cht_DY2.ChartAreas[0].AxisX.Maximum = MaxCount;
            cht_DY2.ChartAreas[0].AxisX.Interval = 1;
            cht_DY2.ChartAreas[0].AxisY.Maximum = 3;
            cht_DY2.ChartAreas[0].AxisY.Minimum = 1;
            cht_DY2.ChartAreas[0].AxisY.Interval = 1;

            cht_DY3.ChartAreas[0].AxisX.Maximum = MaxCount;
            cht_DY3.ChartAreas[0].AxisX.Interval = 1;
            cht_DY3.ChartAreas[0].AxisY.Maximum = 3;
            cht_DY3.ChartAreas[0].AxisY.Minimum = 1;
            cht_DY3.ChartAreas[0].AxisY.Interval = 1;

            cht_DY4.ChartAreas[0].AxisX.Maximum = MaxCount;
            cht_DY4.ChartAreas[0].AxisX.Interval = 1;
            cht_DY4.ChartAreas[0].AxisY.Maximum = 3;
            cht_DY4.ChartAreas[0].AxisY.Minimum = 1;
            cht_DY4.ChartAreas[0].AxisY.Interval = 1;
            //Random sRand = new Random();
            //for (int i = 0; i < MaxCount; i++)
            //{
            //    cht_DY1.Series[0].Points.AddXY("", sRand.Next(100, 200));
            //    cht_DY2.Series[0].Points.AddXY("", sRand.Next(100, 200));
            //    cht_DY3.Series[0].Points.AddXY("", sRand.Next(100, 200));
            //    cht_DY4.Series[0].Points.AddXY("", sRand.Next(100, 200));
            //}
            DataProcessingTimer = new System.Threading.Timer(DataFun, null, 0, Timeout.Infinite);//PLC数据处理
        }
    }
}
