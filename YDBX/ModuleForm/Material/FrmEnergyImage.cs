using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Material
{
    public partial class FrmEnergyImage : Form
    {
        public string BinNo;
        public FrmEnergyImage()
        {
            InitializeComponent();
        }

        #region 图像界面加载
        private void FrmEnergyImage_Load(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT  Energy_Label_Image FROM IMOS_TA_Energy_List WHERE Bin_No = '{0}'", BinNo);
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    SysBusinessFunction.WriteLog("显示图片失败！");
                    return;
                }
                byte[] imageBytes = Convert.FromBase64String(ds.Tables[0].Rows[0]["Energy_Label_Image"].ToString());
                this.pictureBox1.Image = SysBusinessFunction.ArrayToPic(imageBytes);
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("显示图片失败！"+ex.Message);
            }
 
        }
        #endregion
    }
}
