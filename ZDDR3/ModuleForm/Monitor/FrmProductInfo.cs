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
using System.Speech.Synthesis;

namespace Monitor
{

    using Sys.Config;
    using Sys.SysBusiness;
    using ControlLogic.BarCode;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    public partial class FrmProductInfo : Form
    {
        //扫描枪变量
        private ScanProvider _scanner;
        private static string CurrentProductBarCode = "";
        private static string HisProductName = "";
        private SpeechSynthesizer speech = new SpeechSynthesizer();

        public FrmProductInfo()
        {
            InitializeComponent();
        }
        public static Int32 ToInt32(string refData)
        {
            if (string.IsNullOrEmpty(refData))
                return 0;
            else
                return Convert.ToInt32(refData);
        }

        private void product_Load(object sender, EventArgs e)
        {
            txt_StationName.Text = BaseSystemInfo.CurrentProcessName; //BaseSystemInfo.CurrentProcessCode
            txt_MsgInfo.Text = "";
            txt_BarCode.Text = "";
            txt_MaterialName.Text = "";
            txt_MaterialCode.Text = "";
            txt_MaterialLevel.Text = "";

            timer1.Enabled = false;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            InitScanner();
        }

        private void InitScanner()
        {
            try
            {
                // 打开串口  
                _scanner = new ScanProvider(BaseSystemInfo.SerialPortName1, 9600);
                Task task = new Task(() =>
                {
                    // 打开串口  
                    if (_scanner.Open())
                        //关联事件处理程序  
                        _scanner.DataReceived += _scanner_DataReceived;
                });
                task.Start();
            }
            catch (Exception ex)
            {
                string TipInfo = string.Format("条码枪连接出现异常.端口【{0}】波特率【{1}】，", BaseSystemInfo.SerialPortName1, 9600);
                SysBusinessFunction.WriteLog(TipInfo);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, TipInfo);
            }
        }

        /// <summary>
        /// 接收扫码枪信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _scanner_DataReceived(object sender, SerialSortEventArgs e)
        {
            BeginInvoke(new Action<string>(args =>
            {
                OptionSetting.CurrentBarcode = args.Trim();
                //是否加入判断语句，如不足20位，读取失败等情况
                txt_BarCode.Text = OptionSetting.CurrentBarcode;
                CurrentProductBarCode = OptionSetting.CurrentBarcode;
                string sSQL = string.Format(@"SELECT Material_Code,Material_Name,Material_Level FROM dbo.IMOS_TA_Material 
                                              WHERE Material_Code = '{0}' AND Company_Code = '{1}' AND Factory_Code = '{2}' AND Product_Line_Code = '{3}' ",
                            CurrentProductBarCode.Substring(0, 9), BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DataTable Dt = DataHelper.Fill(sSQL).Tables[0];
                if (Dt.Rows.Count > 0)
                {
                    txt_MaterialName.Text = Dt.Rows[0]["Material_Name"].ToString();
                    txt_MaterialCode.Text = Dt.Rows[0]["Material_Code"].ToString();
                    txt_MaterialLevel.Text = Dt.Rows[0]["Material_Level"].ToString();
                    OptionSetting.CurrentMaterName = txt_MaterialName.Text;
                    OptionSetting.CurrentMatercode = txt_MaterialCode.Text;
                    OptionSetting.CurrentLevel = txt_MaterialLevel.Text;
                    txt_MsgInfo.Text = "条码扫描成功......";
                    txt_MsgInfo.ForeColor = Color.Lime;
                    if (HisProductName != txt_MaterialName.Text)
                    {
                        HisProductName = txt_MaterialName.Text;
                        speech.SpeakAsync("当前型号" + txt_MaterialName.Text);
                    }

                    //存储扫描信息
                    int ilevel = ToInt32(txt_MaterialLevel.Text.Trim());
                    string InSqlStr = string.Format(@"INSERT INTO [IMOS_PR_Scan]
                                                   ([Company_Code]
                                                    ,[Company_Name]
                                                    ,[Factory_Code]
                                                    ,[Factory_Name]
                                                    ,[Product_Line_Code]
                                                    ,[Product_Line_Name]
                                                    ,[Process_Code]
                                                    ,[Process_Name]
                                                    ,[Material_Code]
                                                    ,[Material_Name]
                                                    ,[Material_Level]
                                                    ,[Product_BarCode]
                                                    ,[Scan_Time]
                                                    )
                                                    VALUES
                                                    ('{0}','{1}','{2}','{3}','{4}','{5}'
                                                    ,'{6}','{7}','{8}','{9}',{10},'{11}',GETDATE())",
                                                            BaseSystemInfo.CompanyCode,
                                                            BaseSystemInfo.CompanyName,
                                                            BaseSystemInfo.FactoryCode,
                                                            BaseSystemInfo.FactoryName,
                                                            BaseSystemInfo.ProductLineCode,
                                                            BaseSystemInfo.ProductLineName,
                                                            BaseSystemInfo.CurrentProcessCode,
                                                            BaseSystemInfo.CurrentProcessName,
                                                            txt_MaterialCode.Text.ToString(),
                                                            txt_MaterialName.Text.ToString(),
                                                            ilevel,
                                                            txt_BarCode.Text.ToString()
                                                                );
                     DataHelper.Fill(InSqlStr);
                }
                else
                {
                    txt_MaterialName.Text = "";
                    txt_MaterialCode.Text = "";
                    txt_MaterialLevel.Text = "";
                    txt_MsgInfo.Text = "该条码无对应产品信息......";
                    txt_MsgInfo.ForeColor = Color.Red;
                    speech.SpeakAsync("该条码无对应产品信息");
                    return;
                }

                SysBusinessFunction.WriteLog("扫码记录：" + OptionSetting.CurrentBarcode);


            }), e.Code);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                txt_StationName.Text = BaseSystemInfo.CurrentProcessName;
                txt_BarCode.Text = OptionSetting.CurrentBarcode;
                txt_MaterialName.Text = OptionSetting.CurrentMaterName;
                txt_MaterialCode.Text = OptionSetting.CurrentMatercode;
                txt_MaterialLevel.Text = OptionSetting.CurrentLevel;
            }
            catch
            {

            }
        }
        
        

        

       

    }

    
}
