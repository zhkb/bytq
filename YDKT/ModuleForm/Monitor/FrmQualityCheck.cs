using ControlLogic.Control;
using Report;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmQualityCheck : Form
    {
        public FrmQualityCheck()
        {
            InitializeComponent();
        }
        int TaktTime = 0;
        bool StatusFlag = false;
        int DetailCount = 0;
        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi)]
        extern static int GetTickCount();
        public static bool ScanConnOne = false; //扫描设备连接状态
        public static bool BarScanStateOne = false; //条码扫描是否正常
        private static Thread ScanSocketThreadOne = null; // 创建用于接收服务端消息的 
        private static Socket ScanSocketOne = null;
        private static IPEndPoint ScanPointOne;
        private static int ScanReConnCountOne = 0;
        public static bool SerialPortStatusOne = false;
        private static int HisReceiveCountOne = 0;
        private static int ReceiveCountOne = 0;
        public static System.Threading.Timer CheckConnectionTimerOne;  //检查设备ONE连接状态Timer
        private Image[] ConnImage = { Monitor.Properties.Resources.Status_Red, Monitor.Properties.Resources.Status_Green }; //连接状态显示颜色 
        public static System.Threading.Timer RefreshProductionThread;//产量刷新

        private void FrmQualityCheck_Load(object sender, EventArgs e)
        {
            ControlDetailData.SystemInitialization();
            InitProductMonitor();
            InitOne();
            GetCheckItem();
            OptionSetting.CheckResult = true;
            StatusFlag = true;
            CheckConnectionTimerOne = new System.Threading.Timer(CheckConnectionStatusOne, null, 0, Timeout.Infinite);//扫码器 产品码
            RefreshProductionThread = new System.Threading.Timer(GetProductionDBMsg, null, 0, 1000);//产量刷新
            timer2.Start();
            getProductNumDate();
        }

        #region 扫码器 产品码

        #region 初始化
        private static void InitOne()
        {
            IPAddress SanIPOne = IPAddress.Parse(ConfigHelper.GetValue("IntelligentDeviceIP1"));//IP
            ScanPointOne = new IPEndPoint(SanIPOne, int.Parse(ConfigHelper.GetValue("IntelligentDevicePort1")));//端口
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
                string TipInfo = string.Format("条码扫描设备连接出现异常.IP地址{0}端口{1}，", SanIPOne, ScanPointOne);
                SysBusinessFunction.WriteLog(TipInfo);
            }
            ScanSocketThreadOne = new Thread(ScanRecMsgOne);
            ScanSocketThreadOne.IsBackground = true;
            ScanSocketThreadOne.Start();
        }
        #endregion

        #region 重连
        private static void CheckConnectionStatusOne(object o)
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
                    }
                }

                try
                {
                    int sLen = ScanSocketOne.Send(arrMsgRec); //检测发送与接收数据的
                    ScanConnOne = sLen == 1;
                }
                catch
                {
                    ScanConnOne = false;
                }
                #endregion
            }
            catch
            {

            }
            finally
            {
                CheckConnectionTimerOne.Change(10000, Timeout.Infinite);
            }
        }
        #endregion

        #region 数据获取
        public static void ScanRecMsgOne()
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
                        length = ScanSocketOne.Receive(arrMsgRec); // 接收数据，并返回数据的长度；  
                        strMsg = Encoding.Default.GetString(arrMsgRec, 0, 50).Replace("\0", "");
                        ScanConnOne = true;
                    }
                    catch
                    {
                        //  SysBusinessFunction.WriteLog("产品码扫码器心跳信息号失败.");
                        ScanConnOne = false;
                        continue;
                    }

                    if ((strMsg.Trim().Length > 4) && (ScanConnOne) && strMsg.Trim() != "NO READ")
                    {
                        string code = strMsg.Trim();//获取条码  
                        OptionSetting.QCScanFlag = true;
                        BarCodeOneDataHandle(code);

                    }
                    else
                    {
                        OptionSetting.QCScanFlag = true;
                        OptionSetting.QCMsgInfo = DateTime.Now.ToString("HH:mm:ss") + " " + "产品码读取失败！";
                        OptionSetting.QCProBarCode = "";
                        OptionSetting.QCProductMode = "";
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(string.Format("产品码读取异常", ex.ToString()));
            }
        }


        #endregion

        #endregion

        #region 产品码处理
        private static void BarCodeOneDataHandle(string code)
        {
            try
            {
                SysBusinessFunction.WriteLog(string.Format("产品条码【{0}】", code));
                OptionSetting.QCProBarCode = code;
                OptionSetting.nGUID = Guid.NewGuid().ToString("N");
                OptionSetting.QCMsgInfo = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("读取产品条码【{0}】成功", code);
                string sMaterialCode = code.Substring(0, 5).Trim();//可扩展 条码前五位是物料编码
                //查询物料信息
                string MaterialSQL = string.Format(@"SELECT  Material_Code,Material_Name  
                                                         FROM IMOS_TA_Material 
                                                         WHERE Material_Code = '{0}'", sMaterialCode);
                DataSet ds = DataHelper.Fill(MaterialSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.QCProductMode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                }
                else
                {
                    OptionSetting.QCMsgInfo = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("产品条码【{0}】的产品型号未维护", code);
                    OptionSetting.QCProductMode = "";
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("接收条码异常！" + ex.Message);
                OptionSetting.QCProductMode = "";

            }
        }
        #endregion

        #region 初始化界面数据
        private void InitProductMonitor()
        {
            //1.工位显示
            lb_chs_process.Text = BaseSystemInfo.CurrentProcessName;
            lb_en_process.Text = BaseSystemInfo.CurrentProcessName_EN;
            //2.上岗人员
            lb_UserCode.Text = BaseSystemInfo.CurrentUserCode;
            lb_UserName.Text = BaseSystemInfo.CurrentUserName;
            //3.节拍初始化
            TaktTime = 0;
            //4.产量
            lbl_ActualCount.Text = "0";
            lbl_PlanNum.Text = "0";
            lbl_finish.Text = "0";
            lbl_Repair.Text = "0%";
            lbl_MessageInfo.Text = "";

        }

        #endregion

        #region 产量统计获取
        public static void GetProductionDBMsg(object o)
        {
            try
            {
                string sSQL = string.Format(@"SELECT  COUNT(GUID) num
                                            FROM IMOS_PR_QualityCheck 
                                            WHERE CONVERT(VARCHAR(100), Creation_Date, 23) = CONVERT(VARCHAR(100), GETDATE(), 23)");
                DataSet ds = DataHelper.Fill(sSQL);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.QCActualCount = ds.Tables[0].Rows[0]["num"].ToString();
                }
                string sSQL1 = string.Format(@"SELECT  COUNT(GUID) num
                                            FROM IMOS_PR_QualityCheck 
                                            WHERE Check_Result = 1 and CONVERT(VARCHAR(100), Creation_Date, 23) = CONVERT(VARCHAR(100), GETDATE(), 23)");
                DataSet ds1 = DataHelper.Fill(sSQL1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    OptionSetting.QCFinishCount = ds1.Tables[0].Rows[0]["num"].ToString();
                }
                double percent = (double.Parse(OptionSetting.QCActualCount) - double.Parse(OptionSetting.QCFinishCount)) / double.Parse(OptionSetting.QCActualCount);
                if (int.Parse(OptionSetting.QCActualCount)==0)
                {
                    OptionSetting.QCRepairCount = "0.0%";
                }else
                {
                    OptionSetting.QCRepairCount = percent.ToString("0.0%");
                }         
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("读取数据库信息异常！" + ex.Message);
            }
        }
        #endregion

        #region 工位状态更改
        private void lbl_Status_Click(object sender, EventArgs e)
        {

            if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, "是否更改当前工位状态?" + "\n\r\n\r" + "Whether to change the current station status?") == DialogResult.Yes)
            {
                StatusFlag = !StatusFlag;
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 控件刷新Tinmer
        private void timer1_Tick(object sender, EventArgs e)
        {
            TaktTime = TaktTime + 1;
            lb_TaktTime.Text = TaktTime + "S";
            lbl_ActualCount.Text = OptionSetting.QCActualCount;
            lbl_finish.Text = OptionSetting.QCFinishCount;
            lbl_Repair.Text = OptionSetting.QCRepairCount;
            pic_DBState.Image = ConnImage[Convert.ToInt32(StatusFlag)];
            if (StatusFlag)
            {
                lbl_Status.Text = "正常" + "\n" + "Normal";
            }
            else
            {
                lbl_Status.Text = "禁用" + "\n" + "Disabled";
            }
            if (OptionSetting.QCScanFlag == true)
            {
                lbl_BarCode.Text = OptionSetting.QCProBarCode;
                lbl_ProductInfo.Text = OptionSetting.QCProductMode;
                lbl_MessageInfo.Text = OptionSetting.QCMsgInfo;
                OptionSetting.QCScanFlag = false;
            }

        }
        #endregion

        #region 合格按钮
        private void btn_Pass_Click(object sender, EventArgs e)
        {
            if (OptionSetting.CheckDetailList.Count != 0)
            {
                DialogResult result = SysBusinessFunction.SystemDialog(1, String.Format(@"确定该产品合格吗？
Are you sure the product is qualified?"));
                if (result.Equals(DialogResult.OK))
                {
                    OptionSetting.CheckDetailList.Clear();
                    OptionSetting.ReDeFlag = true;
                }
                else
                {
                    return;
                }
            }
            btn_NG.BackColor = Color.FromArgb(224, 224, 224);
            btn_Pass.BackColor = Color.Lime;
            OptionSetting.CheckResult = true;
        }
        #endregion

        #region NG按钮
        private void btn_NG_Click(object sender, EventArgs e)
        {
            if (OptionSetting.QCProBarCode.Length != 0)
            {
                btn_NG.BackColor = Color.Red;
                btn_Pass.BackColor = Color.FromArgb(224, 224, 224);
                OptionSetting.CheckResult = false;
            }
         
        }
        #endregion

        #region 确定按钮
        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!StatusFlag)
                {
                    SysBusinessFunction.SystemDialog(2, String.Format(@"该工位处于禁用状态!
This station is in the disabled state"));
                }
                else
                {
                    int iResult = (OptionSetting.CheckResult == true) ? 1 : 2;//合格1，不合格2
                    if (!String.IsNullOrEmpty(OptionSetting.QCProBarCode))
                    {
                        if (iResult == 2 && OptionSetting.CheckDetailList.Count == 0)
                        {
                            SysBusinessFunction.SystemDialog(2,"质检缺陷不能为空！" + "\n\r\n\r" + "Quality inspection defects can not be empty!");
                            return;
                        }

                        #region 插入子表数据
                        for (int i = 0; i < OptionSetting.CheckDetailList.Count; i++)
                        {
                            string sSql1 = string.Format(@"INSERT INTO [IMOS_PR_QualityCheck_Detail]
                           ([GUID]
                           ,[Product_BarCode]
                           ,[Check_Item_Code]
                           ,[Check_Item_Detail_Code]
                           ,[Check_Item_Detail_Name]
                           ,[Check_Item_Detail_Name_EN]
                           ,[Create_Time]
                           ,[Create_By]
                           ,[Check_Item_Name]     
                           ,[Company_Code]
                           ,[Company_Name]
                           ,[Factory_Code]
                           ,[Factory_Name]
                           ,[Product_Line_Code]
                           ,[Product_Line_Name]                     
                           )
                           VALUES
                           ('{0}'
                           ,'{1}'
                           ,'{2}'
                           ,'{3}'
                           ,'{4}'
                           ,'{5}' 
                           ,GetDate()                
                           ,'{6}'
                           ,'{7}'
                           ,'{8}'
                           ,'{9}'
                           ,'{10}'
                           ,'{11}'
                           ,'{12}'
                           ,'{13}'                    
                           )", OptionSetting.nGUID, OptionSetting.QCProBarCode, OptionSetting.CheckDetailList[i].Item_Code.ToString(),
                                      OptionSetting.CheckDetailList[i].Detail_Code.ToString(), OptionSetting.CheckDetailList[i].Detail_Name_CN.ToString(),
                                      OptionSetting.CheckDetailList[i].Detail_Name_EN.ToString(), BaseSystemInfo.CurrentUserCode, OptionSetting.CheckDetailList[i].Item_Name.ToString(),
                                      BaseSystemInfo.CompanyCode,BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                      BaseSystemInfo.ProductLineName);
                            DataHelper.Fill(sSql1);
                        }
                        #endregion

                        #region 插入主表数据
                        string sSql = string.Format(@"INSERT INTO [IMOS_PR_QualityCheck]
                           ([GUID]
                           ,[Product_BarCode]
                           ,[Material_Name]
                           ,[Check_Result]
                           ,[Created_By]
                           ,[Creation_Date]
                           ,[Material_Code]
                           ,[Company_Code]
                           ,[Company_Name]
                           ,[Factory_Code]
                           ,[Factory_Name]
                           ,[Product_Line_Code]
                           ,[Product_Line_Name]
                           )
                     VALUES
                           ('{0}'
                           ,'{1}'
                           ,'{2}'
                           ,{3}
                           ,'{4}'                          
                           ,GETDATE()
                           ,'{5}'
                           ,'{6}'
                           ,'{7}'
                           ,'{8}'
                           ,'{9}'
                           ,'{10}'
                           ,'{11}'
                           )", OptionSetting.nGUID, OptionSetting.QCProBarCode, lbl_ProductInfo.Text.ToString(), iResult,
                               BaseSystemInfo.CurrentUserCode,OptionSetting.QCProBarCode.Substring(0,5),BaseSystemInfo.CompanyCode,
                               BaseSystemInfo.CompanyName,BaseSystemInfo.FactoryCode,BaseSystemInfo.FactoryName,BaseSystemInfo.ProductLineCode,
                               BaseSystemInfo.ProductLineName);
                        DataHelper.Fill(sSql);
                        #endregion
                        lbl_MessageInfo.Text = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("产品【{0}】质检完成上传数据库成功", OptionSetting.QCProBarCode);
                    }
                    else
                    {
                        lbl_MessageInfo.Text = DateTime.Now.ToString("HH:mm:ss") + " " + string.Format("产品条码为空，无法上传质检结果");
                    }
                    #region 恢复初始化状态
                    TaktTime = 0;
                    OptionSetting.CheckDetailList.Clear();
                    OptionSetting.ReDeFlag = true;
                    OptionSetting.nGUID = "";
                    OptionSetting.CheckResult = true;
                    btn_NG.BackColor = Color.FromArgb(224, 224, 224);
                    btn_Pass.BackColor = Color.Lime;
                    OptionSetting.QCProBarCode = "";
                    OptionSetting.QCProductMode = "";
                    lbl_BarCode.Text = "";
                    lbl_ProductInfo.Text = "";
                    #endregion
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("提交质检结果异常！" + ex.Message);

            }
        }
        #endregion

        #region 获取计划数量
        private void getProductNumDate()
        {
            try
            {
                string sSQL = string.Format(@"SELECT B.Parameter_Detail_ID, B.Parameter_Detail_Code, B.Remark FROM dbo.Sys_Parameters_Master AS A 
	                                        LEFT JOIN dbo.Sys_Parameters_Detail AS B ON A.Parameter_Master_Code = B.Parameter_Master_Code 
                                        WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' AND A.Parameter_Master_Name = '{3}'",
                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentPlanName);

                DataSet ds = DataHelper.Fill(sSQL);
                lbl_PlanNum.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region 计划修改
        private void lbl_PlanNum_Click(object sender, EventArgs e)
        {
            try
            {
                string sSQL = string.Format(@"SELECT B.Parameter_Detail_ID, B.Parameter_Detail_Code, B.Remark FROM dbo.Sys_Parameters_Master AS A 
	                                        LEFT JOIN dbo.Sys_Parameters_Detail AS B ON A.Parameter_Master_Code = B.Parameter_Master_Code 
                                        WHERE A.Company_Code = '{0}' AND A.Factory_Code = '{1}' AND A.Product_Line_Code = '{2}' AND A.Parameter_Master_Name = '{3}'",
                                       BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentPlanName);

                DataSet ds = DataHelper.Fill(sSQL);

                FrmPlanNumModify DownModifyForm = new FrmPlanNumModify();

                DownModifyForm.sPlanID = ds.Tables[0].Rows[0]["Parameter_Detail_ID"].ToString();
                DownModifyForm.sPlanNum = ds.Tables[0].Rows[0]["Remark"].ToString();

                DialogResult r = DownModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {

                }
                DownModifyForm.Dispose();
                getProductNumDate();
            }
            catch (Exception ex)
            {


            }
        }
        #endregion

        #region 质检项显示
        private void GetCheckItem()
        {
            try
            {
                String sql = String.Format(@"SELECT Check_Item_Code,Check_Item_Name,Check_Item_Name_EN FROM IMOS_PR_QualityItem_Master WHERE  1=1");
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    SysBusinessFunction.WriteLog("获取质检项数据失败！");
                    return;
                }
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    AddCheckItem(ds.Tables[0].Rows[i]["Check_Item_Code"].ToString(), ds.Tables[0].Rows[i]["Check_Item_Name"].ToString(), ds.Tables[0].Rows[i]["Check_Item_Name"].ToString(), ds.Tables[0].Rows[i]["Check_Item_Name_EN"].ToString(), i);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("显示质检项失败！");
            }
        }

        private void AddCheckItem(string icode,string iname, string cnname, string enname, int count)
        {
            try
            {
                FrmCheckItem FCI = new FrmCheckItem();
                FCI.IName = iname;
                FCI.ICode = icode;
                FCI.CNName = cnname;
                FCI.ENName = enname;
                FCI.Show_Flag = false;
                FCI.TopLevel = false;
                FCI.Parent = panel19;
                int y = 10 + 99 * (count / 2);
                if (count % 2 == 0)
                {
                    FCI.Location = new System.Drawing.Point(25, y);
                }
                else
                {
                    FCI.Location = new System.Drawing.Point(395, y);
                }

                FCI.Show();
                FCI.Name = "FCI" + count;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加质检项失败！");
            }
        }

        #endregion

        #region 刷新缺陷

        private void GetDetail()
        {
            try
            {
                for (int i = 0; i < OptionSetting.CheckDetailList.Count; i++)
                {
                    FrmCheckItem FCI = new FrmCheckItem();
                    FCI.ICode = OptionSetting.CheckDetailList[i].Detail_Code;
                    FCI.CNName = OptionSetting.CheckDetailList[i].Detail_Name_CN;
                    FCI.ENName = OptionSetting.CheckDetailList[i].Detail_Name_EN;
                    FCI.Show_Flag = true;
                    FCI.TopLevel = false;
                    FCI.Parent = panel23;
                    int y = 10 + 99 * i;
                    FCI.Location = new System.Drawing.Point(20, y);
                    FCI.Show();
                    FCI.Name = "FCID" + i;

                }
                DetailCount = OptionSetting.CheckDetailList.Count;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新缺陷失败！");
            }
        }

        #endregion

        #region timer2 缺陷定时刷新
        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {

                if (OptionSetting.ReDeFlag)
                {
                    for (int i = 0; i < DetailCount; i++)
                    {
                        FrmCheckItem FCI = Controls.Find("FCID" + i, true)[0] as FrmCheckItem;
                        FCI.Dispose();
                    }
                    GetDetail();
                    OptionSetting.ReDeFlag = !OptionSetting.ReDeFlag;
                }

            }
            catch (Exception ex)
            {
                //SysBusinessFunction.WriteLog("定时刷新缺陷失败！");
            }
        }

        #endregion

        #region  重置按钮
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            try
            {
                OptionSetting.CheckDetailList.Clear();
                OptionSetting.ReDeFlag = true;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("重置缺陷失败！");
            }
        }
        #endregion

        #region  报表按钮事件
        private void btn_Report_Click(object sender, EventArgs e)
        {
            try
            {
                FrmQualityCheckReport fqcr = new FrmQualityCheckReport();
                fqcr.WindowState = FormWindowState.Normal;
                fqcr.Show();
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("显示质检报表界面错误！");
            }
        }
        #endregion

    }
}
