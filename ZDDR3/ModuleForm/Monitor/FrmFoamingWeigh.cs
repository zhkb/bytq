using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Data.Common;
using System.Data.SqlClient;

namespace Monitor
{
    using Sys.Config;
    using Sys.SysBusiness;
    using ControlLogic.BarCode;
    using Sys.DbUtilities;

    public partial class FrmFoamingWeigh : Form
    {
        private static Socket BeforeSocket; //发泡前socket
        private static Socket AfterSocket; //发泡后socket
        private static IPEndPoint BeforePoint;//发泡前IP及端口信息
        private static IPEndPoint AfterPoint;//发泡后IP及端口信息
        private static bool BeforeBarScanConn = false;
        private static bool AfterBarScanConn = false;
        private static Thread BeforeSocketThread = null; // 创建用于接收发泡前服务端消息的线程；
        private static Thread AfterSocketThread = null; // 创建用于接收发泡后服务端消息的线程；  
        public static System.Threading.Timer BeforeReConnectDeviceTimer; //发泡前socket重连
        public static System.Threading.Timer AfterReConnectDeviceTimer; //发泡后socket重连
        private static int BarReConnCount = 0;
        public static Double ToDouble(string refData)
        {
            if (string.IsNullOrEmpty(refData))
                return 0.00;
            else
                return Convert.ToDouble(refData);
        }
        public FrmFoamingWeigh()
        {
            InitializeComponent();
        }

        #region 发泡前扫码器扫码
        public void CreateBeforeScanSocket()//创建条码扫描Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanIP_1);
            BeforePoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanPort_1));
            BeforeSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            BeforeSocket.Blocking = true;
            try
            {
                BeforeSocket.Connect(BeforePoint);
                BeforeSocket.Blocking = false;
                BeforeBarScanConn = true;
            }
            catch (SocketException ex)
            {
                BeforeBarScanConn = false;
                string TipInfo = string.Format("发泡前扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", BaseSystemInfo.BarScanIP_1, BaseSystemInfo.BarScanPort_1);
                SysBusinessFunction.WriteLog(TipInfo);
            }

            BeforeSocketThread = new Thread(BeforeSocketRecMsg);
            BeforeSocketThread.IsBackground = true;
            BeforeSocketThread.Start();
            #endregion
        }
        private void BeforeSocketRecMsg()
        {
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(10);
                byte[] arrMsgRec = new byte[50];
                // 将接收到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = BeforeSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    BeforeBarScanConn = true;

                }
                catch (Exception ex)
                {
                    BeforeBarScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (BeforeBarScanConn))
                {
                    HandleBeforeBarCode(strMsg.Trim());
                }
            }
        }
        private void HandleBeforeBarCode(string strMsg)
        {

            BeginInvoke(new Action(() =>
            {
                try
                {
                    lbl_BeforeTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    OptionSetting.CurrentBeforeBarcode = strMsg.Trim();
                    txt_BFbarcode.Text = OptionSetting.CurrentBeforeBarcode;
                    txt_BFbarcode.ForeColor = Color.Gold;
                    SysBusinessFunction.WriteLog(string.Format("发泡前扫码器扫码：" + OptionSetting.CurrentBeforeBarcode));

                    if (OptionSetting.CurrentBeforeBarcode.ToUpper() == "NO READ")
                    {
                        txt_BFbarcode.Text = "条码扫描失败";
                        txt_BFbarcode.ForeColor = Color.Red;
                        txt_BFname.Text = "";
                        txt_BFcode.Text = "";
                        txt_BFStandWeight.Text = "";
                        txt_BFActualWeight.Text = "";
                        return;
                    }
                    else  if (OptionSetting.CurrentBeforeBarcode.Trim().Length != 20)
                    {
                        txt_BFbarcode.Text = "扫描条码格式错误";
                        txt_BFbarcode.ForeColor = Color.Red;
                        txt_BFname.Text = "";
                        txt_BFcode.Text = "";
                        txt_BFStandWeight.Text = "";
                        txt_BFActualWeight.Text = "";
                        return;
                    }


                    //查询物料信息
                    string MaterialSQL = string.Format(@"SELECT  Prod_Desc,Prod_Code  
                                                         FROM view_product_info 
                                                         WHERE prod_code = '{0}'", OptionSetting.CurrentBeforeBarcode.Substring(0, 9));

                    DataTable Dt = DataHelper.MySqlFill(MaterialSQL).Tables[0];

                    if (Dt.Rows.Count > 0)
                    {
                        txt_BFname.Text = Dt.Rows[0]["Prod_Desc"].ToString();
                        txt_BFcode.Text = Dt.Rows[0]["prod_code"].ToString();
                      //  txt_BFStandWeight.Text = Dt.Rows[0]["Foaming_Weight_Standard"].ToString();
                        txt_BFActualWeight.Text = "0.000Kg";
                        lbl_BeforeTime.Text = "产品信息查询正常......";
                        lbl_BeforeTime.ForeColor = Color.Lime;
                    }
                    else
                    {
                        txt_BFname.Text = "";
                        txt_BFcode.Text = "";
                        txt_BFStandWeight.Text = "";
                        lbl_BeforeTime.Text = "该条码无对应产品信息......";
                        lbl_BeforeTime.ForeColor = Color.Red;
                        return;
                    }
                    //上传数据
                    //string ssSQL = string.Format(@"INSERT INTO [IMOS_PR_FoamingWeigh]
                    //                               ([Company_Code]
                    //                                ,[Company_Name]
                    //                                ,[Factory_Code]
                    //                                ,[Factory_Name]
                    //                                ,[Product_Line_Code]
                    //                                ,[Product_Line_Name]
                    //                                ,[Process_Code]
                    //                                ,[Process_Name]
                    //                                ,[Product_BarCode]
                    //                                ,[Material_Code]
                    //                                ,[Material_Name]
                    //                                ,[Foaming_Weight_Before]
                    //                                ,[Foaming_Time_Before]                                                                                                        
                    //                                )
                    //                                VALUES
                    //                                ('{0}','{1}','{2}','{3}','{4}','{5}'
                    //                                ,'{6}','{7}','{8}','{9}','{10}',{11},GETDATE())",
                    //                                        BaseSystemInfo.CompanyCode,
                    //                                        BaseSystemInfo.CompanyName,
                    //                                        BaseSystemInfo.FactoryCode,
                    //                                        BaseSystemInfo.FactoryName,
                    //                                        BaseSystemInfo.ProductLineCode,
                    //                                        BaseSystemInfo.ProductLineName,
                    //                                        BaseSystemInfo.CurrentProcessCode,
                    //                                        BaseSystemInfo.CurrentProcessName,
                    //                                        txt_BFbarcode.Text.ToString(),
                    //                                        txt_BFcode.Text.ToString(),
                    //                                        txt_BFname.Text.ToString(),
                    //                                        ToDouble(txt_BFActualWeight.Text.ToString()));
                    //DataSet ds = DataHelper.Fill(ssSQL);
                   
                }

                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    SysBusinessFunction.WriteLog(string.Format("发泡前称重处理异常:" + ex.Message + OptionSetting.CurrentBeforeBarcode));                   
                }

            }));
        }
        public static void BeforeReConnectDevice(object o)//发泡前socket重连
        {
            try
            {
                Thread.Sleep(10);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!BeforeBarScanConn)
                {
                    try
                    {
                        if (BarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("返修条码扫描设备断线重连中......，{0}", BarReConnCount.ToString()));
                        }
                        BarReConnCount++;
                        BeforeSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        BeforeSocket.Connect(BeforePoint);
                        BeforeBarScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("包装条码扫描设备重新连接成功，重连次数{0}，{1}", BarReConnCount, BeforePoint.ToString()));
                        BarReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = BeforeSocket.Send(arrMsgRec);
                    BeforeBarScanConn = sLen == 1;
                }
                catch
                {
                    BeforeBarScanConn = false;
                }
            }
            catch
            {
            }
            finally
            {
                BeforeReConnectDeviceTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion

        #region 发泡后扫码器扫码
        public void CreateAfterScanSocket()//创建条码扫描Socket
        {
            #region 创建Socket
            IPAddress InIP = IPAddress.Parse(BaseSystemInfo.BarScanIP_2);
            AfterPoint = new IPEndPoint(InIP, int.Parse(BaseSystemInfo.BarScanPort_2));
            AfterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            AfterSocket.Blocking = true;
            try
            {
                AfterSocket.Connect(AfterPoint);
                AfterSocket.Blocking = false;
                AfterBarScanConn = true;
            }
            catch (SocketException ex)
            {
                AfterBarScanConn = false;
                string TipInfo = string.Format("发泡后扫描设备连接出现异常.IP地址【{0}】端口【{1}】，", BaseSystemInfo.BarScanIP_2, BaseSystemInfo.BarScanPort_2);                
                SysBusinessFunction.WriteLog(TipInfo);
            }

            AfterSocketThread = new Thread(AfterSocketRecMsg);
            AfterSocketThread.IsBackground = true;
            AfterSocketThread.Start();
            #endregion
        }
        private void AfterSocketRecMsg()
        {
            string strMsg = "";
            while (true)
            {
                Thread.Sleep(10);
                byte[] arrMsgRec = new byte[50];
                // 将接收到的数据存入到输入  arrMsgRec中；  
                int length = -1;
                try
                {
                    length = AfterSocket.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                    strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                    AfterBarScanConn = true;

                }
                catch (Exception ex)
                {
                    AfterBarScanConn = false;
                    continue;
                }

                if ((strMsg.Trim().Length > 0) && (AfterBarScanConn))
                {
                    HandleAfterBarCode(strMsg.Trim());
                }
            }
        }
        private void HandleAfterBarCode(string strMsg)
        {

            BeginInvoke(new Action(() =>
            {

                try
                {
                    lbl_AfterTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    OptionSetting.CurrentAfterBarcode = strMsg.Trim();
                    txt_AFbarcode.Text = OptionSetting.CurrentAfterBarcode;
                    txt_AFbarcode.ForeColor = Color.Gold;
                    SysBusinessFunction.WriteLog(string.Format("发泡后扫码器扫码：" + OptionSetting.CurrentAfterBarcode));
                    if (OptionSetting.CurrentAfterBarcode == "NO READ")
                    {
                        txt_AFname.Text = "";
                        txt_AFcode.Text = "";
                        txt_AFStandWeight.Text = "";
                        txt_AFActualWeight.Text = "";

                        lbl_AfterMsg.Text = "条码扫描失败";
                        lbl_AfterMsg.ForeColor = Color.Red;
                        return;
                    }

                    if (OptionSetting.CurrentAfterBarcode.Trim().Length != 20)
                    {
                        txt_AFname.Text = "";
                        txt_AFcode.Text = "";
                        txt_AFStandWeight.Text = "";
                        txt_AFActualWeight.Text = "";

                        lbl_AfterMsg.Text = "产品条码格式异常";
                        lbl_AfterMsg.ForeColor = Color.Red;
                        return;
                    }
                    //查询物料信息
                    string MaterialSQL = string.Format(@"SELECT  Prod_Desc,Prod_Code  
                                                         FROM view_product_info 
                                                         WHERE prod_code = '{0}'", OptionSetting.CurrentAfterBarcode.Substring(0, 9));

                    DataTable Dt = DataHelper.MySqlFill(MaterialSQL).Tables[0];

                    if (Dt.Rows.Count > 0)
                    {
                        txt_AFname.Text = Dt.Rows[0]["Prod_Desc"].ToString();
                        txt_AFcode.Text = Dt.Rows[0]["prod_code"].ToString();
                        //  txt_BFStandWeight.Text = Dt.Rows[0]["Foaming_Weight_Standard"].ToString();
                        txt_AFActualWeight.Text = "0.000Kg";
                        lbl_AfterMsg.Text = "产品信息查询正常......";
                        lbl_AfterMsg.ForeColor = Color.Lime;
                    }
                    else
                    {
                        txt_AFname.Text = "";
                        txt_AFcode.Text = "";
                        txt_AFStandWeight.Text = "0.000Kg";
                        lbl_AfterMsg.Text = "该条码无对应产品信息......";
                        lbl_AfterMsg.ForeColor = Color.Red;
                        return;
                    }
                    //更新数据
                    //string ssSQL = string.Format(@"UPDATE [IMOS_PR_FoamingWeigh] SET 
                    //                             [Foaming_Weight_After]={0}, 
                    //                             [Foaming_Time_After]=GETDATE(),
                    //                             [Foaming_Weight_Actual]={5}
                    //                             WHERE Company_Code = '{1}' AND Factory_Code = '{2}' AND Product_Line_Code = '{3}' AND Product_BarCode = '{4}'",
                    //                              ToDouble(txt_AFActualWeight.Text.ToString()),BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, txt_AFbarcode.Text.ToString()
                    //                              ,ToDouble(txt_AFActualWeight.Text.ToString())-ToDouble(txt_BFActualWeight.Text.ToString()));
                    //DataSet ds = DataHelper.Fill(ssSQL);

                }

                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    //SysBusinessFunction.WriteLog(string.Format("处理异常:" + ex.Message + OptionSetting.CurrentAfterBarcode));
                }

            }));
        }
        public static void AfterReConnectDevice(object o)//发泡前socket重连
        {
            try
            {
                Thread.Sleep(10);

                byte[] arrMsgRec = new byte[1];

                //条码扫描设备连接状态
                if (!AfterBarScanConn)
                {
                    try
                    {
                        if (BarReConnCount == 1)
                        {
                            SysBusinessFunction.WriteLog(string.Format("返修条码扫描设备断线重连中......，{0}", BarReConnCount.ToString()));
                        }
                        BarReConnCount++;
                        AfterSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        AfterSocket.Connect(AfterPoint);
                        AfterBarScanConn = true;
                        SysBusinessFunction.WriteLog(string.Format("包装条码扫描设备重新连接成功，重连次数{0}，{1}", BarReConnCount, AfterPoint.ToString()));
                        BarReConnCount = 0;
                    }
                    catch
                    {

                    }
                }

                try
                {
                    int sLen = AfterSocket.Send(arrMsgRec);
                    AfterBarScanConn = sLen == 1;
                }
                catch
                {
                    AfterBarScanConn = false;
                }
            }
            catch
            {
            }
            finally
            {
                AfterReConnectDeviceTimer.Change(10000, Timeout.Infinite);
            }
        }
        #endregion


        private void FrmFoamingWeigh_Load(object sender, EventArgs e)
        {
            panel3.Width = 960;
            panel17.Height = 280;
            panel17.Width = 675;
            panel20.Height = 280;
            panel20.Width = 675;

            txt_BFbarcode.Text = "";
            txt_BFname.Text = "";
            txt_BFcode.Text = "";
            txt_BFStandWeight.Text = "0.00Kg";
            txt_BFActualWeight.Text = "0.00Kg";
            lbl_BeforeTime.Text = "";
            lbl_BeforeMsg.Text = "请扫描产品码......";
            lbl_BeforeResult.Text = "OK";

            txt_AFbarcode.Text = ""; 
            txt_AFname.Text = "";
            txt_AFcode.Text = "";
            txt_AFStandWeight.Text = "0.00Kg";
            txt_AFActualWeight.Text = "0.00Kg";
            lbl_AfterTime.Text = "";
            lbl_AfterMsg.Text = "请扫描产品码......";
            lbl_AfterResult.Text = "OK";

            CreateBeforeScanSocket();
            BeforeReConnectDeviceTimer = new System.Threading.Timer(BeforeReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备Timer 包含PLC 条码
            CreateAfterScanSocket();
            AfterReConnectDeviceTimer = new System.Threading.Timer(AfterReConnectDevice, null, 0, Timeout.Infinite); //重新连接设备Timer 包含PLC 条码
          
        }




    }
}
