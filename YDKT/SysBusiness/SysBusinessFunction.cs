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


namespace Sys.SysBusiness
{
    using Sys.DbUtilities;
    using Sys.Config;
    using BarcodeLib;


    #region 质检缺陷信息
    public struct CheckDetailData
    {
        public string Item_Name;
        public string Item_Code;
        public string Detail_Code;
        public string Detail_Name_CN;//物料编码
        public string Detail_Name_EN;//物料名称

    }
    #endregion

    public struct AlarmInfo
    {
        public int EquipmentType;
        public int EquipmentNo;
        public string EquipmentName;
        public bool AlarmFlag;
        public string AlarmName;
    }

    public struct LoginUserInfo
    {
        public int UserID;
        public string UserCode;
        public string UserName;
        public bool OperFlag; //操作员权限
        public bool TechFlag;//工艺员权限
        public bool PlanFlag;//计划员权限
        public bool CheckFlag;//质检员权限
        public bool AdminFlag;//管理员权限
    }


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


        public static int DialogAskMessage = 1;
        public static int DialogOKMessage = 2;
        public static int DialogYesNoMessage = 3;

        public static int OrderNewStatus = 1; //订单状态 新订单
        public static int OrderLineStatus = 2;//订单状态 生产线
        public static int OrderGroupStatus = 3;//订单状态 组盘完成

        public static int LineNoExcute = 0; //订单产线状态 未执行
        public static int LineExcuteing = 1;//订单产线状态 执行中
        public static int LineFinish = 2;//订单产线状态 完成
        public static int LinePause = 3;//订单产线状态 暂停
        public static int LineForce = 9;//订单产线状态 强制结束

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

        public static Color[] NmpColor = { Color.Red, Color.Lime };

        public static Color[] AlarmColor = { Color.Lime, Color.Red };
        public static Color[] MainTainColor = { Color.Lime, Color.Yellow };

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

        public static int GetSeqNo(int SeqType) // 根据序列类型进行序列号的生成
        {
            try
            {
                string SqlStr = string.Format("Select * From Mixing_Seq Where Seq_Type={0}", SeqType);

                DataSet Plandb = DataHelper.Fill(SqlStr);
                if (Plandb.Tables[0].Rows.Count == 0)
                {
                    string InsertSql = string.Format("Insert Into Mixing_Seq(Seq_Type,Seq_No) Values ('{0}',{1})", SeqType, 1);
                    DataHelper.Fill(InsertSql);

                    return 1;
                }
                else
                {
                    int SeqNo = int.Parse(Plandb.Tables[0].Rows[0]["Seq_No"].ToString()) + 1;

                    if (SeqNo >= 10000)
                    {
                        SeqNo = 1;
                    }

                    string SqlStr1 = string.Format("Update Mixing_Seq Set Seq_No={0} Where seq_type={1}", SeqNo, SeqType);
                    DataHelper.Fill(SqlStr1);

                    return SeqNo;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {

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
                BackColor = Color.White,
                ForeColor = Color.Black,
            })
            {
                return barcode.Encode(TYPE.CODE128, content);
            }
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
        #region 2字PLC浮点型数据读取
        //public static float GetFloat(ushort P1, ushort P2)
        //{
        //    int intSign, intSignRest, intExponent, intExponentRest;
        //    float faResult, faDigit;
        //    intSign = P1 / 32768;
        //    intSignRest = P1 % 32768;
        //    intExponent = intSignRest / 128;
        //    intExponentRest = intSignRest % 128;
        //    faDigit = (float)(intExponentRest * 65536 + P2) / 8388608;
        //    faResult = (float)Math.Pow(-1, intSign) * (float)Math.Pow(2, intExponent - 127) * (faDigit + 1);
        //    return faResult;
        //}
        #endregion
    }


}
