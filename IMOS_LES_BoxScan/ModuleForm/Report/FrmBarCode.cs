using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using FastReport.Export.Pdf;

using FastReport;


namespace BarReport
{
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Sys.Config;
    public partial class FrmBarCode : Form
    {
        private string MasterTypeCode = "1002";
        private string DetialTypeCode = "";
        public FrmBarCode()
        {
            InitializeComponent();
        }

        private void GetOrderBarData(string SerchTxt)//按照条件进行组盘数据查询
        {
            DataSet OrderBarDataSet = new DataSet();

            string PrintFlag = "";
            if (chk_NoPrint.Checked)
            {
                PrintFlag = "0";
            }
            try
            {
                string SqlStr = string.Format(@"select * from (select TO_CHAR(b.creation_date, 'YYYY-MM-DD') Order_Data,a.Order_No,a.Plan_No,a.Material_code,a.Material_Name,a.Master_Type_Code,a.Detial_Type_Code,a.Print_State,
                                                Case when a.Print_State = 0 then '未打印' when a.Print_State = 1 then '打印中' else '已打印' end Print_StateName,
                                                a.Plan_Qty,a.Create_Qty,a.Act_Qty,
                                                Case when a.Create_BarCode = 0 then '未生成' when a.Create_BarCode = 1 then '未完成' else '已生成' end Create_BarCode,a.Order_Material,a.Record_No
                                                from imos_pr_barcode_manage a left join imos_pr_order b on a.order_no = b.order_no
                                                where a.Factory_Code = '{0}'
                                                and  b.creation_date is not null
                                                and  (a.Order_No like '00001%' or a.Order_No like '00005%')
                                                and (a.Order_No like '%{1}%' or a.Material_Code like '%{1}%' or a.Material_Name like '%{1}%')
                                                and a.Master_Type_Code = '{2}'
                                                and a.Detial_Type_Code like '%{3}%'
                                                and a.Print_State like '%{4}%'
                                                Order By b.creation_date desc ,a.Order_No desc,a.Print_State)a
                                                where  rownum <=50", BaseSystemInfo.FactoryCode, SerchTxt, MasterTypeCode, DetialTypeCode, PrintFlag);

                OrderBarDataSet = DataHelper.Fill(SqlStr);

                BarGrid.DataSource = OrderBarDataSet.Tables[0];

                BarGrid.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                BarGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            }
            catch
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询条码数据异常，请检查数据库连接.");
            }
            finally
            {
                OrderBarDataSet.Dispose();
            }
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < BarGrid.Rows.Count; i++)
                {
                    BarGrid.Rows[i].Cells["ItemCheck"].Value = true;
                }
                //btn_Up.Enabled = true;
            }
            catch
            {

            }
        }

        private void btn_CancelAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < BarGrid.Rows.Count; i++)
                {
                    BarGrid.Rows[i].Cells["ItemCheck"].Value = false;
                }
                //btn_Up.Enabled = false;
            }
            catch
            {

            }
        }

        private void PrintMaterialBarCode(string OrderNo, string MasterCode, string DetialCode, int PrintCount, bool AddFlag)
        {
            try
            {
                DataSet BarDataSet = new DataSet();
                string BarStr = "";
                if (AddFlag)
                {
                    BarStr = string.Format(@"Select * From (select Material_Name,Order_Material,Bar_Code,substr(Order_No,5,9)Order_No
                                             from imos_pr_barcode_record
                                             where  Print_Flag = 0
                                             and Factory_Code = '{0}'
                                             and Order_No = '{1}'
                                             and Master_Type_Code = '{2}'
                                             and Detial_Type_Code = '{3}'
                                             order by Bar_Code)
                                             Where ROWNUM <= {4} order by Bar_Code", BaseSystemInfo.FactoryCode, OrderNo, MasterCode, DetialCode, PrintCount);
                }
                else
                {
                    BarStr = string.Format(@"select Material_Name,Order_Material,Bar_Code,substr(Order_No,5,9)Order_No
                                             from imos_pr_barcode_record
                                             where  Print_Flag = 9
                                             and Factory_Code = '{0}'
                                             order by Order_No,Master_Type_Code,Detial_Type_Code,Bar_Code", BaseSystemInfo.FactoryCode, OrderNo, MasterCode, DetialCode);
                }

                BarDataSet = DataHelper.Fill(BarStr);

                if (BarDataSet.Tables[0].Rows.Count == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, string.Format("无法查询打印条码数据."));
                    BarDataSet.Dispose();
                    return;
                }

                //int DataCount = BarDataSet.Tables[0].Rows.Count;
                //string MaterialName = BarDataSet.Tables[0].Rows[0]["Material_Name"].ToString();
                //string MaterialDesc = BarDataSet.Tables[0].Rows[0]["Order_Material"].ToString();

                Report BarReport = new Report();
                (new FastReport.EnvironmentSettings()).ReportSettings.ShowProgress = false;
                (new FastReport.EnvironmentSettings()).PreviewSettings.Buttons = PreviewButtons.Print | PreviewButtons.Save | PreviewButtons.Close;

                BarReport.Prepare();

                BarReport.Load(Application.StartupPath + @"\Report\MaterialBar.frx"); //加载报表控件

                //  SysBusinessFunction.WriteLog(string.Format("包装箱条码打印. 编号：{0},名称：{1}，数量：{2}，条码：{3} ~ {4}", PartNo, PartName, DataCount, StartNo, EndNo));

                BarReport.RegisterData(BarDataSet.Tables[0], "BoxBarData");

                DataBand data = BarReport.FindObject("Data1") as DataBand;
                data.DataSource = BarReport.GetDataSource("BoxBarData");

                BarReport.PrintSettings.Copies = 1;

                BarReport.PrintSettings.ShowDialog = true;
                BarReport.Prepare();

                string BarPath = Application.StartupPath + @"\pdf\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                BarReport.Export(new PDFExport(), BarPath);

                //BarReport.Show(); //预览                

                //  BarReport.Print(); //直接进行条码打印

                //更改打印条码的打印状态
                string UpStr = "";
                if (AddFlag)
                {
                    UpStr = string.Format(@"Update imos_pr_barcode_record
                                               Set Print_Flag = 1
                                               Where Bar_Code in 
                                               (Select Bar_Code  From (select Material_Name,Order_Material,Bar_Code 
                                               from imos_pr_barcode_record
                                               where  Print_Flag = 0
                                               and Factory_Code = '{0}'
                                               and Order_No = '{1}'
                                               and Master_Type_Code = '{2}'
                                               and Detial_Type_Code like '%{3}%'
                                               order by Bar_Code)
                                               Where ROWNUM <= {4})", BaseSystemInfo.FactoryCode, OrderNo, MasterCode, DetialCode, PrintCount);
                }
                else
                {
                    UpStr = string.Format(@"Update imos_pr_barcode_record
                                            Set Print_Flag = 1
                                            Where Print_Flag =9");
                }

                DataHelper.Fill(UpStr);

                try
                {
                    System.Diagnostics.Process.Start(BarPath);
                }
                catch
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, string.Format("文件打开异常，请手动打开.", BarPath));
                }


                //SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, string.Format("", PartNo, PartName, StartNo, EndNo.Substring(EndNo.Length - 5, 5)));

            }
            catch
            {
            }
            finally
            {

            }
        }

        private void FrmUpSelect_Load(object sender, EventArgs e)
        {
            // UpdateGroupStatus(OrderID);
            //  GetOrderBarData(OrderID);
        }

        private void BarGrid_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void AddBarCodePrint()
        {
            try
            {
                btn_Print.Enabled = false;
                if (BarGrid.Rows.Count == 0)
                {
                    return;
                }

                int PrintCount = 1;

                if (txt_PrintCount.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "打印数量不能为0");
                    txt_PrintCount.Focus();
                    return;
                }

                PrintCount = int.Parse(txt_PrintCount.Text.Trim());

                if (PrintCount == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "打印数量不能为0");
                    txt_PrintCount.Focus();
                    return;
                }

                string RecordNo = BarGrid.Rows[BarGrid.CurrentRow.Index].Cells["Record_No"].Value.ToString();
                string OrderNo = BarGrid.Rows[BarGrid.CurrentRow.Index].Cells["Order_No"].Value.ToString();
                string MaterName = BarGrid.Rows[BarGrid.CurrentRow.Index].Cells["Material_Name"].Value.ToString();
                string MasterCode = BarGrid.Rows[BarGrid.CurrentRow.Index].Cells["Master_Type_Code"].Value.ToString();
                string DetialCode = BarGrid.Rows[BarGrid.CurrentRow.Index].Cells["Detial_Type_Code"].Value.ToString();

                //DialogResult dr = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, string.Format("确认打印订单【{0}】,物料名称【{1}】的条码数据.", OrderNo, MaterName));
                //if (dr != DialogResult.OK)
                //{
                //    return;
                //}

                PrintMaterialBarCode(OrderNo, MasterCode, DetialCode, PrintCount, true);

                string UpStr = string.Format(@"Update IMOS_PR_BARCODE_MANAGE 
                                                Set Print_State = 2
                                                Where Factory_Code = '{0}'
                                                and Record_No = '{1}'", BaseSystemInfo.FactoryCode, RecordNo);
                DataHelper.Fill(UpStr);

            }
            catch
            {

            }
            finally
            {
                btn_Print.Enabled = true;
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Select.Enabled = false;
                GetOrderBarData(txt_SearchText.Text.Trim());
            }
            catch
            {

            }
            finally
            {
                btn_Select.Enabled = true;

                btn_Print.Enabled = BarGrid.Rows.Count > 0;
                btn_Create.Enabled = BarGrid.Rows.Count > 0;
                btn_Add.Enabled = BarGrid.Rows.Count > 0;

                txt_SearchText.Focus();
            }


        }

        private void btn_CancelAll_Click_1(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < BarGrid.Rows.Count; i++)
                {
                    BarGrid.Rows[i].Cells["ItemCheck"].Value = false;
                }
                //btn_Up.Enabled = false;
            }
            catch
            {

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            DetialTypeCode = "1003";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DetialTypeCode = "1002";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            DetialTypeCode = "1001";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            DetialTypeCode = "1004";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            DetialTypeCode = "";
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Create.Enabled = false;
                if (BarGrid.Rows.Count == 0)
                {
                    return;
                }

                DialogResult dr = SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogAskMessage, "确认生成订单条码数据.");
                if (dr != DialogResult.OK)
                {
                    return;
                }

                int DataCount = 0;
                for (int i = 0; i < BarGrid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(BarGrid.Rows[i].Cells["ItemCheck"].Value))
                    {
                        string OrderNo = BarGrid.Rows[i].Cells["Order_No"].Value.ToString();
                        SysBusinessFunction.ExeuteCreateBarCodeProduce(BaseSystemInfo.FactoryCode, OrderNo, "123");
                        DataCount++;
                    }
                }


                if (DataCount > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "条码生成完成.");
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请选择订单信息.");
                }
            }
            catch
            {

            }
            finally
            {
                btn_Create.Enabled = true;
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Add.Enabled = false;
                if (BarGrid.Rows.Count == 0)
                {
                    return;
                }

                int PrintCount = 1;

                if (txt_PrintCount.Text.Trim() == "")
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "追加数量不能为空");
                    txt_PrintCount.Focus();
                    return;
                }

                PrintCount = int.Parse(txt_PrintCount.Text.Trim());

                if (PrintCount == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "追加数量不能为0");
                    txt_PrintCount.Focus();
                    return;
                }


                if (PrintCount > 10)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "追加数量不能大于10");
                    txt_PrintCount.Focus();
                    return;
                }

                int DataCount = 0;
                int NoPrintCount = 0;
                for (int i = 0; i < BarGrid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(BarGrid.Rows[i].Cells["ItemCheck"].Value))
                    {
                        string PrintState = BarGrid.Rows[i].Cells["Print_State"].Value.ToString();

                        if (PrintState == "0")//状态为未打印
                        {
                            NoPrintCount++;
                            continue;
                        }

                        string RecordNo = BarGrid.Rows[i].Cells["Record_No"].Value.ToString();
                        string OrderNo = BarGrid.Rows[i].Cells["Order_No"].Value.ToString();
                        string PlanNo = BarGrid.Rows[i].Cells["Plan_No"].Value.ToString();
                        string MaterCode = BarGrid.Rows[i].Cells["Material_Code"].Value.ToString();
                        string MaterName = BarGrid.Rows[i].Cells["Material_Name"].Value.ToString();
                        string MasterCode = BarGrid.Rows[i].Cells["Master_Type_Code"].Value.ToString();
                        string DetialCode = BarGrid.Rows[i].Cells["Detial_Type_Code"].Value.ToString();
                        string OrderMaterial = BarGrid.Rows[i].Cells["Order_Material"].Value.ToString();

                        int sIndex = OrderMaterial.IndexOf(",");

                        if (sIndex > 0)
                        {
                            OrderMaterial = OrderMaterial.Substring(0, sIndex);
                        }
                        int sIndex1 = OrderMaterial.IndexOf("-");
                        if (sIndex1 > 0)
                        {
                            OrderMaterial = OrderMaterial.Substring(sIndex1+1, OrderMaterial.Length - sIndex1-1);
                        }

                        if (OrderMaterial.Length > 3)
                        {
                            OrderMaterial = OrderMaterial.Substring(0, 3) + "MES" + OrderMaterial.Substring(3, OrderMaterial.Length - 3);
                        }


                        for (int j = 0; j < PrintCount; j++)
                        {
                            int SeqNo = 0;
                            string BarType = "";

                            if (DetialCode == "1000")
                            {
                                SeqNo = SysBusinessFunction.GetSEQ("SEQ_PR_BARCODE_MANAGE_DOOR");
                                BarType = "D";
                            }
                            else if (DetialCode == "1001")
                            {
                                SeqNo = SysBusinessFunction.GetSEQ("SEQ_PR_BARCODE_MANAGE_BOX");
                                BarType = "B";
                            }
                            else if (DetialCode == "1002")
                            {
                                SeqNo = SysBusinessFunction.GetSEQ("SEQ_PR_BARCODE_MANAGE_COAMING");
                                BarType = "C";
                            }
                            else if (DetialCode == "1003")
                            {
                                SeqNo = SysBusinessFunction.GetSEQ("SEQ_PR_BARCODE_MANAGE_LINER");
                                BarType = "L";
                            }

                            string BarCode = BarType + DateTime.Now.ToString("yyMMdd") + MaterCode + string.Format("{0:D4}", SeqNo);

                            string AgainFlag = "0";
                            int AgainCount = 0;
                            string CreateUser = "001";
                            string PrintFlag = "9";
                            string AddFlag = "1";
                            //更改打印条码的打印状态
                            string BarStr = string.Format(@"insert into IMOS_PR_BARCODE_RECORD(RECORD_NO,BAR_CODE,PLAN_NO,ORDER_NO,MATERIAL_CODE,MATERIAL_NAME,
                                                    MASTER_TYPE_CODE,DETIAL_TYPE_CODE,PRINT_TIME,PRINT_AGAIN,PRINT_AGAIN_COUNT,creation_date,created_by,PRINT_FLAG,ADD_FLAG,ORDER_MATERIAL)
                                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',sysdate,'{8}',{9},sysdate,'{10}','{11}','{12}','{13}')",
                                                           BarCode, BarCode, PlanNo, OrderNo, MaterCode, MaterName, MasterCode, DetialCode, AgainFlag, AgainCount, CreateUser, PrintFlag, AddFlag, OrderMaterial);
                            DataHelper.Fill(BarStr);
                        }

                        string UpStr = string.Format(@"Update IMOS_PR_BARCODE_MANAGE 
                                                Set Act_Qty = Act_Qty + {0},Print_State = 2
                                                Where Factory_Code = '{1}'
                                                and Record_No = '{2}'", PrintCount, BaseSystemInfo.FactoryCode, RecordNo);
                        DataHelper.Fill(UpStr);

                        DataCount++;
                    }
                }

                if (NoPrintCount > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "存在条码未打印状态订单，已限制追加打印.");
                }

                if (DataCount > 0)
                {
                    PrintMaterialBarCode("", "", "", 0, false);
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请选择订单信息.");
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "追加条码数据异常. \r\n异常信息" + ex.Message);
            }
            finally
            {
                btn_Add.Enabled = true;
            }
        }

        private void txt_PrintCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void txt_SearchText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)//这是允许输入退格键
            {
                btn_Select_Click(null, null);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {

                btn_Print.Enabled = false;

                int DataCount = 0;
                for (int i = 0; i < BarGrid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(BarGrid.Rows[i].Cells["ItemCheck"].Value))
                    {
                        string RecordNo = BarGrid.Rows[i].Cells["Record_No"].Value.ToString();
                        string OrderNo = BarGrid.Rows[i].Cells["Order_No"].Value.ToString();
                        string MasterCode = BarGrid.Rows[i].Cells["Master_Type_Code"].Value.ToString();
                        string DetialCode = BarGrid.Rows[i].Cells["Detial_Type_Code"].Value.ToString();
                        string OrderMaterial = BarGrid.Rows[i].Cells["Order_Material"].Value.ToString();

                        int sIndex = OrderMaterial.IndexOf(",");

                        if (sIndex > 0)
                        {
                            OrderMaterial = OrderMaterial.Substring(0, sIndex);
                        }
                        int sIndex1 = OrderMaterial.IndexOf("-");
                        if (sIndex1 > 0)
                        {
                            OrderMaterial = OrderMaterial.Substring(sIndex1 + 1, OrderMaterial.Length - sIndex1 - 1);
                        }

                        if (OrderMaterial.Length > 3)
                        {
                            OrderMaterial = OrderMaterial.Substring(0, 3) + "MES" + OrderMaterial.Substring(3, OrderMaterial.Length - 3);
                        }

                        //更改打印条码的打印状态
                        string UpStr = string.Format(@"Update imos_pr_barcode_record
                                               Set Print_Flag = 9,Order_Material = '{0}'
                                               Where Print_Flag = 0
                                               and Order_No = '{1}'
                                               and Master_Type_Code = '{2}'
                                               and Detial_Type_Code = '{3}'", OrderMaterial,OrderNo, MasterCode, DetialCode);
                        DataHelper.Fill(UpStr);

                        string UpStr1 = string.Format(@"Update IMOS_PR_BARCODE_MANAGE 
                                                Set Print_State = 2,Act_Qty = Plan_Qty
                                                Where Factory_Code = '{0}'
                                                and Record_No = '{1}'", BaseSystemInfo.FactoryCode, RecordNo);
                        DataHelper.Fill(UpStr1);

                        DataCount++;
                    }
                }

                if (DataCount > 0)
                {
                    PrintMaterialBarCode("", "", "", 0, false);
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请选择订单信息.");
                }

            }
            catch
            {

            }
            finally
            {
                btn_Print.Enabled = true;
            }

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Clear.Enabled = false;
                txt_SearchText.Text = "";
                GetOrderBarData(txt_SearchText.Text.Trim());
            }
            catch
            {

            }
            finally
            {
                btn_Clear.Enabled = true;

                btn_Print.Enabled = BarGrid.Rows.Count > 0;
                btn_Create.Enabled = BarGrid.Rows.Count > 0;
                btn_Add.Enabled = BarGrid.Rows.Count > 0;

                txt_SearchText.Focus();
            }
        }

        private void btn_foaming_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string OrderMaterial = "发泡箱体,BCD - 186CGEX,炫金色,PCM板";

                             int sIndex = OrderMaterial.IndexOf(",");

            if (sIndex > 0)
            {
                OrderMaterial = OrderMaterial.Substring(0, sIndex);
            }
            int sIndex1 = OrderMaterial.IndexOf("-");
            if (sIndex1 > 0)
            {
                OrderMaterial = OrderMaterial.Substring(sIndex1 + 1, OrderMaterial.Length - sIndex1 - 1);
            }

            if (OrderMaterial.Length > 3)
            {
                OrderMaterial = OrderMaterial.Substring(0, 3) + "MES" + OrderMaterial.Substring(3, OrderMaterial.Length - 3);
            }

        }
    }
}
