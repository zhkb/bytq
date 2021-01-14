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
using Sys.Config;

namespace Monitor.UShell
{
    public partial class FrmOutRecord : Form
    {
        public FrmOutRecord()
        {
            InitializeComponent();
        }

       

        private void FrmOutRecord_Load(object sender, EventArgs e)
        {
            ControlBox = false;
            GetRecordData();
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void GetRecordData() //刷新界面数据
        {
            try
            {
                DataSet DBDataSet = new DataSet();

                string SqlStr = string.Format(@" SELECT top 200 m.Material_Name, d.Bin_No, Convert(Varchar(100),d.Out_Time ,120) as Out_Time  FROM IMOS_Lo_Bin_Detail d, IMOS_TA_Material m 
                                          where d.Company_Code = '{0}' and d.Factory_Code = '{1}' and d.Product_Line_Code = '{2}' and Store_Code='{3}'
                                          and Flag=1 and d.[Bar_Code] = m.Material_Code order by d.Out_Time desc", 
                                          BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.CurrentStationNo);
                DBDataSet = DataHelper.Fill(SqlStr);

                dgv_Record.DataSource = DBDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                string str1 = ex.Message;
            }
        }

        private void dgv_Record_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.Cells[0].Value = string.Format("{0}", e.Row.Index + 1);
        }
    }
}
