using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;

namespace Monitor
{
    public partial class FrmMaterialGridding : Form
    {
        public string MaterialCode = "";
        public string MaterialName = "";
        public string ScanTime;
        public FrmMaterialGridding()
        {
            InitializeComponent();
        }

        private void FrmMaterialGridding_Load(object sender, EventArgs e)
        {
            try
            {
                btn_Material.Text = "";
                ReMaterialInfo();
                //btn_Material.Text = MaterialName;
                //pic_BarCode.Image = SysBusinessFunction.CreateBarCode(MaterialCode, 270, 53);
                timer1.Interval = 300;
                timer1.Enabled = true;
                timer1.Start();
            }
            catch (Exception ex)
            {

            }
        }

        #region 加载物料信息
        private void ReMaterialInfo()
        {
            try
            {
                string sql = String.Format(@"select a.[Material_ID],a.[Material_Code],a.[Material_Name]
                                                from IMOS_TA_Material a 
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and a.[Material_Code] = '{3}'",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, MaterialCode);
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    MaterialCode = ds.Tables[0].Rows[0]["Material_Code"].ToString();
                    MaterialName = ds.Tables[0].Rows[0]["Material_Name"].ToString();
                    btn_Material.Text = MaterialName;
                    pic_BarCode.Image = SysBusinessFunction.CreateBarCode(MaterialCode, 270,53);
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("刷新物料信息失败！" + ex.ToString());
            }
        }
        #endregion

        private void btn_Material_Click(object sender, EventArgs e)
        {
            OptionSetting.MaterialBarCode = MaterialCode;
            OptionSetting.MaterialCode = MaterialCode;
            OptionSetting.MaterialName = MaterialName;
            ScanTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            OptionSetting.ScanTime = ScanTime;
            OptionSetting.MsgInfo = "点击按钮获取物料条码" + OptionSetting.MaterialCode;
            OptionSetting.MsgColorRed = false;
            btn_Material.BackColor = Color.Green;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (OptionSetting.MaterialCode == MaterialCode)
            {
                btn_Material.BackColor = Color.Green;
            }
            else
            {
                btn_Material.BackColor = Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            }
        }
    }
}
