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
    public partial class FrmBoxDoorMonitor : Form
    {
        public FrmBoxDoorMonitor()
        {
            InitializeComponent();
            //dataGridViewA.TopLeftHeaderCell.Value = "序号";
            //dataGridViewA.RowHeadersWidth = 60;
            //dataGridViewB.TopLeftHeaderCell.Value = "序号";
            //dataGridViewB.RowHeadersWidth = 60;
        }
        private DataSet MasterDataSetA = new DataSet();
        private DataSet MasterDataSetB = new DataSet();
        private void FrmBoxDoorMonitor_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 7; i++)
            {
                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                l.Text = "";
            }
            for (int i = 1; i < 7; i++)
            {
                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                l.Text = "";
            }
            for (int i = 1; i < 7; i++)
            {
                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                l.Text = "";
            }
            for (int i = 1; i < 7; i++)
            {
                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                l.Text = "";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string SqlStr = string.Format(@"select 
                                                    MAX(rowNum1)rowNum1 ,MAX(Box_BarCode1)Box_BarCode1,MAX(Create_time1) Create_time1,
                                                    case when isnull(MAX(rowNum2),0) <1 then ' ' else cast(MAX(rowNum2) as varchar(10))  end rowNum2,
                                                    MAX(Box_BarCode2)Box_BarCode2,MAX(Create_time2)Create_time2  from  
                                                    (select Ceiling(rowNum/2.1) rowNum,
                                                     case when rowNum %2 = 1 then rowNum else 0 end  rowNum1,
                                                     case when rowNum %2 = 1 then Box_BarCode else '' end Box_BarCode1,
                                                     case when rowNum %2 = 1 then Convert(varchar(10),Create_time,108) else ' ' end Create_time1,
                                                     case when rowNum %2 = 0 then rowNum else 0 end  rowNum2,
                                                     case when rowNum %2 = 0 then Box_BarCode else '' end Box_BarCode2,
                                                     case when rowNum %2 = 0 then Convert(varchar(10),Create_time,108) else ' ' end Create_time2
                                                    from
                                                     (select top 20  row_number() over (order by Create_time desc)rowNum,Box_BarCode,Create_time   
                                                    from IMOS_TA_BoxDoor_Record where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                     and Scan_Flag = 1 ) A)B 
                                                     group by B.rowNum ",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, "L001");

                MasterDataSetA = DataHelper.Fill(SqlStr);
                dataGridViewA.DataSource = MasterDataSetA.Tables[0];
                string SqlStr1 = string.Format(@"select A.Door_Code, COUNT(A.Door_Code) as num FROM
                                                (SELECT top 20 B.Door_Code                             
                                                FROM IMOS_TA_BoxDoor_Record  B
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and Scan_Flag = 1 )A group by A.Door_Code
                                                ",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, "L001");
                DataSet ds1 = DataHelper.Fill(SqlStr1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {                                      
                    int icount = ds1.Tables[0].Rows.Count;
                    switch (icount.ToString())
                    {
                        case "1":
                            lbl_DoorCodeA1.Text = ds1.Tables[0].Rows[0]["Door_Code"].ToString();
                            lbl_NumA1.Text = ds1.Tables[0].Rows[0]["num"].ToString();
                            for (int i = 2; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 2; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "2":
                            for (int i = 1; i < 3; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 3; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            for (int i = 3; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 3; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "3":
                            for (int i = 1; i < 4; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i-1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 4; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i-1]["num"].ToString();
                            }
                            for (int i = 4; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 4; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "4":
                            for (int i = 1; i < 5; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 5; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            for (int i = 5; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 5; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "5":
                            for (int i = 1; i < 6; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 6; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            for (int i = 6; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 6; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "6":
                            for (int i = 1; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Label l = Controls.Find("lbl_DoorCodeA" + i, true)[0] as Label;
                        l.Text = "";
                    }
                    for (int i = 1; i < 7; i++)
                    {
                        Label l = Controls.Find("lbl_NumA" + i, true)[0] as Label;
                        l.Text = "";
                    }
                    
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.Message.ToString());
            }
        }

        private void dataGridViewA_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void dataGridViewB_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                string SqlStr = string.Format(@"select 
                                                    MAX(rowNum3)rowNum3 ,MAX(Box_BarCode3)Box_BarCode3,MAX(Create_time3) Create_time3,
                                                    case when isnull(MAX(rowNum4),0) <1 then ' ' else cast(MAX(rowNum4) as varchar(10))  end rowNum4,
                                                    MAX(Box_BarCode4)Box_BarCode4,MAX(Create_time4)Create_time4  from  
                                                    (select Ceiling(rowNum/2.1) rowNum,
                                                     case when rowNum %2 = 1 then rowNum else 0 end  rowNum3,
                                                     case when rowNum %2 = 1 then Box_BarCode else '' end Box_BarCode3,
                                                     case when rowNum %2 = 1 then Convert(varchar(10),Create_time,108) else ' ' end Create_time3,
                                                     case when rowNum %2 = 0 then rowNum else 0 end  rowNum4,
                                                     case when rowNum %2 = 0 then Box_BarCode else '' end Box_BarCode4,
                                                     case when rowNum %2 = 0 then Convert(varchar(10),Create_time,108) else ' ' end Create_time4
                                                    from
                                                     (select top 20  row_number() over (order by Create_time desc)rowNum,Box_BarCode,Create_time   
                                                    from IMOS_TA_BoxDoor_Record where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                     and Scan_Flag = 1 ) A)B 
                                                     group by B.rowNum ",
                                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, "L002");

                MasterDataSetB = DataHelper.Fill(SqlStr);
                dataGridViewB.DataSource = MasterDataSetB.Tables[0];
                string SqlStr1 = string.Format(@"select A.Door_Code, COUNT(A.Door_Code) as num FROM
                                                (SELECT top 20 B.Door_Code                             
                                                FROM IMOS_TA_BoxDoor_Record  B
                                                where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                and Scan_Flag = 1 )A group by A.Door_Code
                                                ",
                                               BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, "L002");
                DataSet ds1 = DataHelper.Fill(SqlStr1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    int icount = ds1.Tables[0].Rows.Count;
                    switch (icount.ToString())
                    {
                        case "1":
                            lbl_DoorCodeB1.Text = ds1.Tables[0].Rows[0]["Door_Code"].ToString();
                            lbl_NumB1.Text = ds1.Tables[0].Rows[0]["num"].ToString();
                            for (int i = 2; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 2; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "2":
                            for (int i = 1; i < 3; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 3; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            for (int i = 3; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 3; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "3":
                            for (int i = 1; i < 4; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 4; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            for (int i = 4; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 4; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "4":
                            for (int i = 1; i < 5; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 5; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            for (int i = 5; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 5; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "5":
                            for (int i = 1; i < 6; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 6; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }
                            for (int i = 6; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            for (int i = 6; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = "";
                            }
                            break;
                        case "6":
                            for (int i = 1; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["Door_Code"].ToString();
                            }
                            for (int i = 1; i < 7; i++)
                            {
                                Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                                l.Text = ds1.Tables[0].Rows[i - 1]["num"].ToString();
                            }

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        Label l = Controls.Find("lbl_DoorCodeB" + i, true)[0] as Label;
                        l.Text = "";
                    }
                    for (int i = 1; i < 7; i++)
                    {
                        Label l = Controls.Find("lbl_NumB" + i, true)[0] as Label;
                        l.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {

                SysBusinessFunction.WriteLog(ex.Message.ToString());
            }
        }
    }
}
