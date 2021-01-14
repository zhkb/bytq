using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sys.DbUtilities;
using Sys.SysBusiness;
using Sys.Config;


namespace Monitor
{
    public partial class FrmBoxDoorMatch : Form
    {
        public FrmBoxDoorMatch()
        {
            InitializeComponent();
            //dgvCommon.TopLeftHeaderCell.Value = "序号" + "\n" +"Number";
        }
        private DataSet MasterDataSet = new DataSet();
        private void FrmBoxDoorMatch_Load(object sender, EventArgs e)
        {
            lbl_BoxBarCode.Text = "";
            lbl_BoxCode.Text = "";
            lbl_BoxName.Text = "";
            lbl_DoorCode.Text = "";
            lbl_DoorName.Text = "";
            lbl_Message.Text = "";
            GetMaterialData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_BoxBarCode.Text = OptionSetting.BoxBarCodeA;
            lbl_BoxCode.Text = OptionSetting.BoxCodeA;
            lbl_BoxName.Text = OptionSetting.BoxNameA;
            lbl_DoorCode.Text = OptionSetting.DoorCodeA;
            lbl_DoorName.Text = OptionSetting.DoorNameA;
            lbl_Message.Text = OptionSetting.MsgInfo;
            GetMaterialData();
        }
        private void GetMaterialData()
        {
            try
            {
                string SqlStr = string.Format(@" select top 10  row_number() over (order by Create_time desc)rowNum,Box_BarCode,Door_Code,Convert(varchar(10),Create_time,108)Create_time1   
                                                 from IMOS_TA_BoxDoor_Record  where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                 and Scan_Flag = 1 
                                                    ",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                MasterDataSet = DataHelper.Fill(SqlStr);

                dgvCommon.DataSource = MasterDataSet.Tables[0];
                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询失败，请检查数据库连接.");
            }
        }

       

      

        private void dgvCommon_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
