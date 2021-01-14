using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.Security.Cryptography;
using System.Management;
using System.Data;
using System.Web;
using System.Collections;
using FastReport.Data;
using ThoughtWorks.QRCode.Codec;
using BarcodeLib;

namespace Sys.SysBusiness
{
    using Sys.DbUtilities;
    using Sys.Config;
    using System.Text.RegularExpressions;

    public struct AlarmInfo
    {
        public string AlarmID;
        public string AlarmNo;
        public int EquipmentType;
        public string EquipmentCode;
        public string EquipmentName;
        public bool AlarmFlag;
        public string AlarmName;
    }
    public struct StoreMaterialInfo
    {
        public string MaterialBarCode;
        public string MaterialCode;
        public string MaterialName;
        public string StoreCode;
        public string StoreName;

        public string MaterialSort;
    }


    public struct LoginUserInfo
    {
        public int UserID;
        public string UserCode;
        public string UserName;
        public bool OperFlag; //操作员权限
        public bool TechFlag; //工艺员权限
        public bool PlanFlag; //计划员权限
        public bool CheckFlag;//质检员权限
        public bool AdminFlag;//管理员权限
    }

    public struct StoreInfo  //库存信息
    {
        public string StoreCode;
        public string BinNo;
        public string MaterialName;
        public int MaxQty;
        public int StoreQty;
        public int TransitQty;
        public bool InFlag; //是否禁止入库  true 可入库 false 禁止入库
        public bool OutFlag;//是否禁止出库  true 使用 false 禁用
        public bool AbNormal; //是否异常货道
        public bool UseFlag;  //是否禁用  true 使用 false 禁用
    }

    public struct TaskInfo
    {
        public int TaskID;
        public string MaterialBarCode;
        public string MaterialCode;
        public string MaterialName;
        public string RFIDBarCode;
    }

    #region 设备信息
    public struct EquipmentInfo
    {
        public string EquipmentType;
        public string EquipmentCode;
        public string EquipmentName;
    }
    #endregion

    #region 打印变量参数
    public struct PrintParameterInfo
    {
        public string ParameterName;
        public string ParameterValue;
    }
    #endregion
    #region 动作参数
    public struct ModuleInfo
    {
        public int MenuType;
        public bool MainMenuFlag; // true 主菜单 false 子菜单
        public string MenuID;
        public string MenuCode;
        public string MenuName;
        public string ModuleID;
        public string ModuleCode;
        public string ModuleName;
        public string ModuleSource;
        public string ModuleForm;
    }
    #endregion

    #region 模块参数
    public struct MenuInfo
    {
        public string MenuCode;
        public string MenuName;
        public int ModuleCount;
        public bool ShowFlag;
        public Panel Pnl_Menu;
    }
    #endregion


    public class GroupInfo
    {
        private string sGroupName;
        private string sGroupID;

        public GroupInfo(string sCode, string sName)
        {
            this.sGroupID = sCode;
            this.sGroupName = sName;
        }

        public string ID
        {
            get
            {
                return sGroupID;
            }
        }

        public string Name
        {

            get
            {
                return sGroupName;
            }
        }

    }

    public class SysBusinessFunction
    {

        public static ArrayList ModuleListInfo = new ArrayList();
    
        public static StoreInfo[] StoreInfoList = new StoreInfo[24]; //库存 

        public static int DialogAskMessage = 1;
        public static int DialogOKMessage = 2;
        public static int DialogYesNoMessage = 3;


        public static bool DBConn = false; //本地数据库连接状态
        public static bool ServerDBConn = false; //服务器数据库连接状态

        public static bool DataBaseStatus = false;
        public static bool HisDataBaseStatus = true;
        public static bool DBFlag = false;

        public static string HisCount = "";
        public static string NewCount = "";

        public static System.Threading.Timer CheckDBConnectionTimer;  //查看数据库连接
        public static System.Threading.Timer DisplayAlarmTimer; //刷新报警信息

        public static bool TipVisible = false; //是否显示信息提示
        public static string TipInfo = ""; //提示信息内容

        public static Color[] AlarmColor = { Color.Lime, Color.Red };

        public static readonly Encoding Encoding = Encoding.GetEncoding("UTF-8");

        public static Color[] ViewBackColor = { Color.White, Color.LightCyan, Color.Lime }; //列表间隔颜色

        public static void CreateCheckDBConnection()//判断数据库连接状态
        {
            CheckDBConnectionTimer = new System.Threading.Timer(CheckDBConnectionStatus, null, 0, Timeout.Infinite);
        }

        public static void CheckDBConnectionStatus(object o)
        {
            try
            {
                SysBusinessFunction.CheckDataBaseStatus();
            }
            finally
            {
                CheckDBConnectionTimer.Change(5000, Timeout.Infinite);
            }
        }

        public static void OperationInfoAdd(string OperInfo) //增加操作信息提示
        {
            try
            {
                string InfoStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + OperInfo;
                OptionSetting.OperationInfoList.Insert(0, InfoStr);

                //最大显示最新的10条提示信息 多余的数据进行删除
                for (int i = 20; i < OptionSetting.OperationInfoList.Count; i++)
                {
                    OptionSetting.OperationInfoList.RemoveAt(i);
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("增加业务日志信息异常。");
            }
        }

        public static void OperationAlarmAdd(string OperInfo) //增加操作异常信息提示
        {
            try
            {
                string InfoStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + OperInfo;
                OptionSetting.OperationAlarmList.Insert(0, InfoStr);

                //最大显示最新的10条提示信息 多余的数据进行删除
                for (int i = 20; i < OptionSetting.OperationAlarmList.Count; i++)
                {
                    OptionSetting.OperationAlarmList.RemoveAt(i);
                }
            }
            catch
            {
            }
        }

        public static void OperationTipsAdd(string OperInfo) //增加操作信息提示 包含异常和正常信息 方便设备监控界面进行相应的信息提示
        {
            try
            {
                string InfoStr = DateTime.Now.ToString("HH:mm:ss") + " " + OperInfo;

                OptionSetting.OperationTipsList.Insert(0, InfoStr);

                //最大显示最新的10条提示信息 多余的数据进行删除
                for (int i = 10; i < OptionSetting.OperationTipsList.Count; i++)
                {
                    OptionSetting.OperationTipsList.RemoveAt(i);
                }
            }
            catch
            {

            }

        }

        public static void WriteLog(string LogTxt) //记录日志
        {
            try
            {
                System.IO.File.AppendAllText(Application.StartupPath + "\\RunLog\\" + DateTime.Now.ToString("yyyyMMdd") + ".txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + LogTxt + "\r\n", System.Text.Encoding.Default);
            }
            catch
            {
            }
        }

        public static DialogResult SystemDialog(int DialogType, string InfoTxt) //系统提示框 DialogType 1 确定、取消 2 确定 3 是、否
        {
            try
            {
                FrmDialog DialogForm = new FrmDialog();
                DialogForm.DialogType = DialogType;
                DialogForm.InfoTxt = InfoTxt;
                DialogResult r = DialogForm.ShowDialog();
                DialogForm.Dispose();
                return r;
            }
            catch
            {
                return DialogResult.Cancel;
            }
        }

        public static DialogResult CheckLocalPwd() //系统提示框 
        {
            try
            {
                FrmLocalPwd DialogForm = new FrmLocalPwd();
                DialogResult r = DialogForm.ShowDialog();
                DialogForm.Dispose();
                return r;
            }
            catch
            {
                return DialogResult.Cancel;
            }
        }

        public static bool CheckDataBaseStatus()
        {
            try
            {
                Thread.Sleep(5);

                if (BaseSystemInfo.DataBaseType == "Oracle")
                {
                    DataHelper.Fill("select sysdate from dual");
                }
                else
                {
                    DataHelper.Fill("select getdate()");
                }

                DataBaseStatus = true;

                if ((DataBaseStatus != HisDataBaseStatus) && (!HisDataBaseStatus))
                {
                    SysBusinessFunction.WriteLog("数据库重新连接成功.....");
                    SysBusinessFunction.OperationInfoAdd("数据库重新连接成功.....");
                    DataHelper.RefreshDBConn();
                }
                HisDataBaseStatus = DataBaseStatus;
                NewCount = DateTime.Now.ToString("yyyyMMddHHmmss"); //

                return true;
            }
            catch
            {
                HisDataBaseStatus = false;

                return false;
            }
        }

        public static bool IsIpaddress(string input)
        {
            string pattern = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            return Regex.IsMatch(input, pattern);
        }

        /// 密码加密
        public static string HashPassword(string password)
        {
            using (var hasher = System.Security.Cryptography.SHA1.Create())
            {
                byte[] hashedPwd = hasher.ComputeHash(Encoding.GetBytes(password));
                password = Convert.ToBase64String(hashedPwd).ToUpper();
            }
            return password;
        }

        public static bool DownloadFile(string URL, string filename)
        {
            double percent = 0;
            try
            {

                System.Net.HttpWebRequest FMyrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);

                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)FMyrq.GetResponse();
                long totalBytes = myrp.ContentLength;

                System.IO.Stream st = myrp.GetResponseStream();

                System.IO.Stream so = new System.IO.FileStream(@Application.StartupPath + "\\" + filename, System.IO.FileMode.Create);

                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    Application.DoEvents();
                    so.Write(by, 0, osize);

                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (int)totalDownloadedByte / (int)totalBytes * 100;
                    double ww = Math.Ceiling(1.25);

                    Application.DoEvents();
                }
                so.Close();
                st.Close();
                return true;
            }
            catch (System.Exception)
            {

                Thread.Sleep(5);
                return false;
                //throw;
            }
        }

        public static bool CheckUpdateInfo() //初始化更新信息
        {
            try
            {
                bool DownSuccess = false;
                DownSuccess = DownloadFile("http://" + BaseSystemInfo.AutoUpdateIP + ":" + BaseSystemInfo.AutoUpdatePort + "/" + BaseSystemInfo.AutoUpdateDir + "/" + "UpdateConfig.xml", "UpdateConfig.xml");
                Thread.Sleep(100);
                if (!DownSuccess)
                    return false;

                // 读取配置文件               
                XmlDocument xmlDocument = new XmlDocument();

                if (File.Exists("UpdateConfig.xml"))
                {
                    xmlDocument.Load("UpdateConfig.xml");
                }
                else
                {
                    return false;
                }

                BaseSystemInfo.App_NewVersion = ConfigHelper.GetValue(xmlDocument, "SystemVersion"); //系统最新版本号

                bool UpFlag = BaseSystemInfo.App_NewVersion != BaseSystemInfo.App_Version;
                return UpFlag;
            }
            catch
            {
                return false;
            }
        }

        public static void ExportReport(ArrayList ParameterList, DataSet ReportDT, string TableDataSource, string ReportPath, string ExportName)
        {
            try
            {
                if (ReportDT != null && ReportDT.Tables.Count > 0)
                {

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Excel2007(*.xlsx)|*.xlsx";//设置文件类型
                    sfd.FileName = ExportName;//设置默认文件名
                    sfd.DefaultExt = "xlsx";//设置默认格式（可以不设）
                    sfd.AddExtension = true;//设置自动在文件名中添加扩展名
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FastReport.Report PrintReport = new FastReport.Report();
                        PrintReport.Load(ReportPath);
                        PrintReport.Dictionary.Connections[0].ConnectionString = BaseSystemInfo.BusinessDbConnection;

                        TableDataSource table = PrintReport.GetDataSource(TableDataSource) as TableDataSource;
                        table.Table = ReportDT.Tables[0];

                        if (ParameterList != null)
                        {
                            for (int i = 0; i < ParameterList.Count; i++)
                            {
                                PrintParameterInfo ParameterInfo = (PrintParameterInfo)ParameterList[i];

                                PrintReport.SetParameterValue(ParameterInfo.ParameterName, ParameterInfo.ParameterValue); //设置报表中变量内容   

                            }
                        }

                        //  report.Show(true);
                        PrintReport.Prepare();
                        FastReport.Export.OoXML.Excel2007Export export = new FastReport.Export.OoXML.Excel2007Export();

                        string BarPath = sfd.FileName;
                        PrintReport.Export(export, BarPath);

                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报表导出成功.");
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog("报表导出异常." + ex.Message);
                SystemDialog(SysBusinessFunction.DialogOKMessage, "报表导出异常.");
            }
            finally
            {

            }
        }

        public static string GetCpuSerial() //取得CPU序列号
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        public static string GetDiskSerial()//取得设备硬盘的卷标号
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        public static string Encrypt(string src) // DES 加密
        {
            string des = string.Empty;
            byte[] bysData = Encoding.UTF8.GetBytes(src);

            DESCryptoServiceProvider objDESCryptoServiceProvider = new DESCryptoServiceProvider();
            objDESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(BaseSystemInfo.RegisterKey);//密钥  
            objDESCryptoServiceProvider.Mode = CipherMode.ECB;
            objDESCryptoServiceProvider.Padding = PaddingMode.None;

            byte[] bysFixSizeData = new byte[(int)Math.Ceiling(bysData.Length / 8.0) * 8];
            Array.Copy(bysData, bysFixSizeData, bysData.Length);

            byte[] bysEncrypted = objDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bysFixSizeData, 0, bysFixSizeData.Length);//加密  
            des = Convert.ToBase64String(bysEncrypted);//加密后的字符串  
            if (des.Equals("")) des = "error";
            return des;
        }

        public static string Decrypt(string str) //DES解密
        {
            string des = string.Empty;
            byte[] inputByteArray = Convert.FromBase64String(str);

            DESCryptoServiceProvider objDESCryptoServiceProvider = new DESCryptoServiceProvider();
            objDESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(BaseSystemInfo.RegisterKey);//密钥  
            objDESCryptoServiceProvider.Mode = CipherMode.ECB;
            objDESCryptoServiceProvider.Padding = PaddingMode.None;

            byte[] bysDEcrypted = objDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);//解密  
            byte[] bysFixSizeData = new byte[(int)Math.Ceiling(bysDEcrypted.Length / 8.0) * 8];
            Array.Copy(bysDEcrypted, bysFixSizeData, bysDEcrypted.Length);

            des = Encoding.UTF8.GetString(bysFixSizeData);//解密后的字符串  
            if (des.Equals("")) des = "error";
            return des;
        }

        public static int StrToBinary(string DataStr) //字符串转换成ASCII  下传 PLC  两个字符
        {
            byte[] AsciiData = System.Text.Encoding.Default.GetBytes(DataStr);
            StringBuilder strResult = new StringBuilder(AsciiData.Length * 8);

            foreach (byte b in AsciiData)
            {
                strResult.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            string binary = strResult.ToString();
            return Convert.ToInt32(binary, 2);
        }

        public static string BinaryToStr(int num)
        {
            string BinaryStr = Convert.ToString(num, 2);

            for (int i = BinaryStr.Length; i < 16; i++)
            {
                BinaryStr = "0" + BinaryStr;
            }

            System.Text.RegularExpressions.CaptureCollection cs =
            System.Text.RegularExpressions.Regex.Match(BinaryStr, @"([01]{8})+").Groups[1].Captures;
            byte[] data = new byte[cs.Count];
            for (int i = 0; i < cs.Count; i++)
            {
                data[i] = Convert.ToByte(cs[i].Value, 2);
            }
            return Encoding.Default.GetString(data, 0, data.Length).Replace("\0", "");
        }

        public static string ReverseString(string s) //字符串反转
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static string MD5(string str) //ms5密码加密
        {
            int code = 32;
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }

            if (code == 32)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }

            return strEncrypt;
        }


        public static Image ArrayToPic(byte[] imageBytes)
        {

            // 读入MemoryStream对象
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            // 转成图片
            Image image = Image.FromStream(memoryStream);

            //memoryStream.Close(); //不要加上这一句否则就不对了

            // 将图片放置在 PictureBox 中
            //  this.pictureBox1.SizeMode = PictureBoxSizeMode.;
            return image;
        }

        public static void GetMenuInfoData(string UserID, string UserCode)//获取用户权限信息
        {
            try
            {
                bool AdminFlag = UserCode.ToUpper() != "ADMIN";

                if (!AdminFlag)
                {
                    string sqlQuery = string.Format(" Exec [UpdateUserAuthority]  '{0}','{1}','{2}','{3}','{4}','{5}',{6}",
                                      BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName, UserID);
                    DataHelper.Fill(sqlQuery);

                }

                DataSet MenuDataSet = new DataSet();
                string SqlStr = string.Format(@"select a.User_ID,b.Menu_Name,b.Menu_ID,b.Menu_Code,c.Module_Code,c.Module_ID,c.Module_Name,C.Module_Source,c.Module_Form,a.Use_Flag
                                                from Sys_BaseUserAuthority a left join Sys_BaseMenu b on (a.Company_Code = b.Company_Code and a.Factory_Code = b.Factory_Code  and a.Menu_Code = b.Menu_Code
                                                and a.product_line_code = b.Product_Line_Code)
                                                left join sys_BaseModule c on (b.Company_Code = c.Company_Code and b.Factory_Code = c.Factory_Code and b.product_line_code = c.product_line_code and b.Menu_Code = c.Menu_Code  and a.Module_Code =c.Module_Code)
                                                Where User_ID = '{0}' and a.Company_Code = '{1}' and a.Factory_Code = '{2}' and a.product_line_code = '{3}'
                                                and a.Use_Flag >= {4} and ISNULL(c.Module_Code,'') !=''
                                                Order By b.Menu_Sort desc,c.Module_Sort,c.Module_Code,c.Module_Name", UserID, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, Convert.ToInt32(AdminFlag));
                MenuDataSet = DataHelper.Fill(SqlStr);

                if (MenuDataSet.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < MenuDataSet.Tables[0].Rows.Count; i++)
                    {
                        ModuleInfo TempParentMenu = new ModuleInfo();
                        TempParentMenu.MenuID = MenuDataSet.Tables[0].Rows[i]["Menu_ID"].ToString();
                        TempParentMenu.MenuCode = MenuDataSet.Tables[0].Rows[i]["Menu_Code"].ToString();
                        TempParentMenu.MenuName = MenuDataSet.Tables[0].Rows[i]["Menu_Name"].ToString();
                        TempParentMenu.ModuleID = MenuDataSet.Tables[0].Rows[i]["Module_ID"].ToString();
                        TempParentMenu.ModuleCode = MenuDataSet.Tables[0].Rows[i]["Module_Code"].ToString();
                        TempParentMenu.ModuleName = MenuDataSet.Tables[0].Rows[i]["Module_Name"].ToString();
                        TempParentMenu.ModuleSource = MenuDataSet.Tables[0].Rows[i]["Module_Source"].ToString();
                        TempParentMenu.ModuleForm = MenuDataSet.Tables[0].Rows[i]["Module_Form"].ToString();

                        ModuleListInfo.Add(TempParentMenu);


                    }
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取用户权限信息失败." + ex.ToString());
            }
        }

        //二维码生成图片
        public static Bitmap CreateQRCode(string content)
        {
            try
            {
                QRCodeEncoder qrEncoder = new QRCodeEncoder();
                //二维码类型
                qrEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                //二维码尺寸
                qrEncoder.QRCodeScale = 4;
                //二维码版本
                qrEncoder.QRCodeVersion = 7;
                //二维码容错程度
                qrEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //字体与背景颜色
                qrEncoder.QRCodeBackgroundColor = Color.White;
                qrEncoder.QRCodeForegroundColor = Color.Black;
                //UTF-8编码类型
                Bitmap qrcode = qrEncoder.Encode(content, Encoding.UTF8);

                return qrcode;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static Image CreateBarCode(string content, int FWidth, int FHeight)
        {
            using (var barcode = new Barcode()
            {
                //true显示content，false反之
                IncludeLabel = false,

                //content的位置
                Alignment = AlignmentPositions.CENTER,

                //条形码的宽高
                Width = FWidth,
                Height = FHeight,

                //类型
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,

                //颜色
                BackColor = Color.Snow,
                ForeColor = Color.Black,
            })
            {
                return barcode.Encode(TYPE.CODE128, content);
            }
        }

        public static void PrintReport(ArrayList ParameterList, DataSet ReportDT, string TableDataSource, string ReportPath)
        {
            try
            {
                if (ReportDT != null && ReportDT.Tables.Count > 0)
                {
                    FastReport.Report PrintReport = new FastReport.Report();

                    (new FastReport.EnvironmentSettings()).ReportSettings.ShowProgress = false;
                    (new FastReport.EnvironmentSettings()).PreviewSettings.Buttons = FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Close;

                    PrintReport.Load(ReportPath);
                    PrintReport.Dictionary.Connections[0].ConnectionString = BaseSystemInfo.BusinessDbConnection;

                    TableDataSource table = PrintReport.GetDataSource(TableDataSource) as TableDataSource;
                    table.Table = ReportDT.Tables[0];

                    if (ParameterList != null)
                    {
                        for (int i = 0; i < ParameterList.Count; i++)
                        {
                            PrintParameterInfo ParameterInfo = (PrintParameterInfo)ParameterList[i];

                            PrintReport.SetParameterValue(ParameterInfo.ParameterName, ParameterInfo.ParameterValue); //设置报表中变量内容   

                        }
                    }


                    PrintReport.Show(true);

                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("报表导出异常," + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报表导出异常");
            }
            finally
            {

            }

        }
    }


}
