using Sys.Config;
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

namespace Monitor
{
    public partial class FrmBoxDoor : Form
    {
        public FrmBoxDoor()
        {
            InitializeComponent();
            
        }
        private DataSet MasterDataSet = new DataSet();
        private void FrmBoxDoor_Load(object sender, EventArgs e)
        {
            dgvCommon.AutoGenerateColumns = false;
            GetMaterialData();
            timer1.Start();

        }
        private void GetMaterialData()
        {
            try
            {
                //型号，编码
                string SqlStr = string.Format(@" select top 10 a.Box_Code,a.Box_Name,row_number() over (order by a.Create_time desc) as rowNum
                                           from(
                                           select s.*  
                                           from ( 
                                           select *, row_number() over (partition by Box_Code order by Create_time desc) as group_idx  
                                           from IMOS_TA_BoxDoor_Record where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                           ) s
                                           where s.group_idx = 1 
                                           ) a 
                                                    ",
                                           BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                MasterDataSet = DataHelper.Fill(SqlStr);                
                dgvCommon.DataSource = MasterDataSet.Tables[0];
                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
                for (int i = 0; i < 10; i++)
                {
                    //上线数量
                    string SName = dgvCommon.Rows[i].Cells["Box_Name"].Value.ToString();
                    string sSQL = string.Format(@"SELECT count(*)
                            FROM [IMOS_TA_BoxDoor_Record] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and DateDiff(dd,Create_time,getdate())=0
                            and Box_Name = '{3}'",
                           BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, SName);
                    DataSet ds = DataHelper.Fill(sSQL);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvCommon.Rows[i].Cells["TotalNum"].Value = ds.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        dgvCommon.Rows[i].Cells["TotalNum"].Value = null;

                    }
                    //箱体库存数
                    string sSql = string.Format(@"SELECT sum(Actual_Qty) as Box_num
                            FROM [IMOS_Lo_Bin] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' 
                            and Material_Name = '{3}'",
                           BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, SName);
                    DataSet ds2 = DataHelper.Fill(sSql);
                    if (ds2 != null && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvCommon.Rows[i].Cells["BoxNum"].Value = ds2.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        dgvCommon.Rows[i].Cells["BoxNum"].Value = null;

                    }
                    //在线数量
                    string ssSQL = string.Format(@"SELECT count(*)
                            FROM [IMOS_TA_BoxDoor_Record] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and DateDiff(dd,Create_time,getdate())=0
                            and Box_Name = '{3}'and Scan_Flag = 1",
                           BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, SName);
                    DataSet ds1 = DataHelper.Fill(ssSQL);
                    if (ds1 != null && ds.Tables[0].Rows.Count > 0)
                    {
                        dgvCommon.Rows[i].Cells["OnLineNum"].Value = ds1.Tables[0].Rows[0][0].ToString();
                    }
                    else
                    {
                        dgvCommon.Rows[i].Cells["OnLineNum"].Value = 0;

                    }
                }
                //每十分钟产量
                String sql = String.Format(@"select                                             
                                            SUM(CASE when  dateName(mi,a.Create_Time)<10  then 1 ELSE 0 end )  Min_Qty1,
                                            SUM(CASE when  dateName(mi,a.Create_Time)<20  then 1 ELSE 0 end )  Min_Qty2,
                                            SUM(CASE when  dateName(mi,a.Create_Time)<30  then 1 ELSE 0 end )  Min_Qty3,
                                            SUM(CASE when  dateName(mi,a.Create_Time)<40  then 1 ELSE 0 end )  Min_Qty4,
                                            SUM(CASE when  dateName(mi,a.Create_Time)<50  then 1 ELSE 0 end )  Min_Qty5,
                                            SUM(CASE when  dateName(mi,a.Create_Time)<60  then 1 ELSE 0 end )  Min_Qty6                                            
                                            from IMOS_TA_BoxDoor_Record  a where  CONVERT(varchar(13), Create_Time, 120) = CONVERT(varchar(13), getdate(), 120) 
                                            and Company_Code = '{0}' 
                                            and Factory_Code = '{1}'
                                            and Product_Line_Code = '{2}'
                                            ", BaseSystemInfo.CompanyCode,
                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DataSet ds3 = DataHelper.Fill(sql);
                if (ds3 != null && ds3.Tables[0].Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(ds3.Tables[0].Rows[0]["Min_Qty1"].ToString()))
                    {
                        lbl_num1.Text = "";
                    }
                    else
                    {
                        lbl_num1.Text = ds3.Tables[0].Rows[0]["Min_Qty1"].ToString() + "台";
                    }
                    for (int i = 2; i < 7; i++)
                    {
                        Label lb = Controls.Find("lbl_num" + i, true)[0] as Label;
                        if (string.IsNullOrEmpty(ds3.Tables[0].Rows[0]["Min_Qty" + i].ToString())|| string.IsNullOrEmpty(ds3.Tables[0].Rows[0]["Min_Qty" + (i - 1)].ToString()))
                        {
                            lb.Text = "";
                        }
                        else
                        {
                            int num = Int32.Parse(ds3.Tables[0].Rows[0]["Min_Qty" + i].ToString()) - Int32.Parse(ds3.Tables[0].Rows[0]["Min_Qty" + (i - 1)].ToString());
                            lb.Text = num.ToString() + "台";
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Label lb = Controls.Find("lbl_num" + i, true)[0] as Label;
                        lb.Text = "";
                    }

                }
                //门面图片，型号加载
                for (int i = 1; i < 11; i++)
                {
                    Label l = Controls.Find("lbl_Model" + i , true)[0] as Label;
                    PictureBox px = Controls.Find("pb_" + i, true)[0] as PictureBox;
                    if (MasterDataSet.Tables[0].Rows[i-1]["Box_Name"] == null)
                    {
                        l.Text = "";
                        px.Image = null;
                    }
                    else
                    {
                        l.Text = MasterDataSet.Tables[0].Rows[i-1]["Box_Name"].ToString();
                        string sSQL = string.Format(@"SELECT [Material_Image]
                            FROM [IMOS_TA_Material] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                            and Material_Name = '{3}'", 
                            BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, l.Text.ToString());
                        DataSet ds = DataHelper.Fill(sSQL);
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            string sMPicture = ds.Tables[0].Rows[0]["Material_Image"].ToString();
                            if (sMPicture.Length != 0 )
                            {
                                byte[] imageBytes = Convert.FromBase64String(sMPicture);
                                px.SizeMode = PictureBoxSizeMode.Zoom;
                                px.Image = SysBusinessFunction.ArrayToPic(imageBytes);
                            }
                            else
                            {
                                px.Image = null;
                            }
                        }
                        else
                        {
                            px.Image = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, ex.Message);
            }
        }

        private void dgvCommon_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetMaterialData();
        }
    }
}
