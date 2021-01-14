using FastReport;
using FastReport.Export.Pdf;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Material
{
    public partial class FrmBarCodePrint : Form
    {
        DataTable dtList1;
        DataTable dtList2;
        int iBarCodeTypeId = 1;
        string strCurOrderNo = "";
        string strCurMaterialCode = "";
        public FrmBarCodePrint()
        {
            InitializeComponent();
        }

        private void FrmBarCodePrint_Load(object sender, EventArgs e)
        {
            DataIni();
        }
        
        private void DataIni()
        {
            txt_SearchText.Text = "";
            chkPrint.Checked = false;

        }

        public void DataRead()
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    if (rdo01.Checked == true)
                        iBarCodeTypeId = 1;
                    if (rdo02.Checked == true)
                        iBarCodeTypeId = 2;
                    if (rdo03.Checked == true)
                        iBarCodeTypeId = 3;

                SqlParameter[] values = {
                        new SqlParameter("UserNo",""),
                        new SqlParameter("StrSearch", ToString(txt_SearchText.Text)),
                        new SqlParameter("BarCodeTypeId", ToString(iBarCodeTypeId)),
                        new SqlParameter("IsAll", chkPrint.Checked)
                    };
                    DataSet ds = DataHelper.ExecuteProcedure("up_BarCode_Print_Head", new String[] { "List" }, values);
                    dtList1 = ds.Tables[0];
                    gvList1.DataSource = dtList1;


                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("读数据时异常FrmReportList02！具体原因：" + ex.Message);
                }

            }));
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DataRead();
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                btn_SelectAll.Enabled = false;
                for (int i = 0; i < gvList1.Rows.Count; i++)
                {
                    gvList2.Rows[i].Cells["ItemCheck"].Value = true;
                }
                btn_SelectAll.Enabled = true;

                gvList2.EndEdit();
            }
            catch
            {

            }
        }

        private void Comm_Print(int iPrintType,int iPrintClass)
        {
            try
            {
                DataTable dtPrint;
                DataView dv = new DataView(dtList2);
                dv.RowFilter = "Is_Select=1";
                DataTable dt = dv.ToTable();
                if(iPrintClass==1)
                {
                    dtPrint = dt;
                }
                else
                {
                    SqlParameter[] values = {
                        new SqlParameter("UserNo",""),
                        new SqlParameter("BarcodeOrderId", ToString(strCurOrderNo)),
                        new SqlParameter("MaterialCode", ToString(strCurMaterialCode)),
                        new SqlParameter("Qty", ToInt32(txtPrintQty.Text))
                    };

                    DataSet ds = DataHelper.ExecuteProcedure("up_BarCode_Print_To", new String[] { "List" }, values);

                 //   System.Data.DataSet ds = DataHelper.DsFill("up_BarCode_Print_To", values);
                    dtPrint = ds.Tables[0];
                }
                if(dtPrint != null && dtPrint.Rows.Count>0)
                {
                    iBarCodeTypeId = ToInt32(dtPrint.Rows[0]["BarCode_Type_Id"]);

                    Report BarReport = new Report();
                    (new FastReport.EnvironmentSettings()).ReportSettings.ShowProgress = false;
                    (new FastReport.EnvironmentSettings()).PreviewSettings.Buttons = PreviewButtons.Print | PreviewButtons.Save | PreviewButtons.Close;
                    BarReport.Prepare();

                    if(iBarCodeTypeId==1)
                        BarReport.Load(Application.StartupPath + @"\Report\BarCodeType01.frx");
                    else if(iBarCodeTypeId==2)
                        BarReport.Load(Application.StartupPath + @"\Report\BarCodeType02.frx");
                    else if (iBarCodeTypeId == 3)
                        BarReport.Load(Application.StartupPath + @"\Report\BarCodeType03.frx");
                    else
                        BarReport.Load(Application.StartupPath + @"\Report\BarCodeType01.frx");


                    BarReport.RegisterData(dtPrint, "BoxBarData");
                    DataBand data = BarReport.FindObject("Data1") as DataBand;
                    data.DataSource = BarReport.GetDataSource("BoxBarData");
                    BarReport.PrintSettings.Copies = 1;
                    BarReport.PrintSettings.ShowDialog = true;
                    BarReport.Prepare();
                    string BarPath = Application.StartupPath + @"\Report\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";
                    BarReport.Export(new PDFExport(), BarPath);

                    foreach(DataRow dr in dtPrint.Rows)
                    {
                        string UpStr = string.Format(@"
                            UPDATE dbo.IMOS_PR_BARCODE_MANAGER
                            SET Print_Qty=ISNULL(Print_Qty,0)+1,Print_Date=GETDATE()
                            WHERE Barcode_Manager_Id={0}",ToString(dr["Barcode_Manager_Id"]));
                        DataHelper.Fill(UpStr);
                    }

                    try
                    {
                        if(iPrintType==1)
                        {
                            BarReport.Show(); //预览 
                        }
                                       
                        //BarReport.Print(); //直接进行条码打印
                        if(iPrintType==2)
                        {
                            System.Diagnostics.Process.Start(BarPath);
                        }
                        
                    }
                    catch
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, string.Format("文件打开异常，请手动打开.", BarPath));
                    }

                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage,"打印完成");

                    DataRead();
                }
                else
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "未找到符合条件的打印数据，请重新查询打印");
                }

            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("打印时异常FrmBarCodePrint！具体原因：" + ex.Message);
            }

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if(ToInt32(txtPrintQty.Text)>0)
            {
                Comm_Print(1, 2);
            }
            else
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请输入本次打印数量");
            }
            
        }

        private void btn_CancelAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvList1.Rows.Count; i++)
                {
                    gvList2.Rows[i].Cells["ItemCheck"].Value = false;
                }

                gvList2.EndEdit();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }
        }

        private void btn_Pdf_Click(object sender, EventArgs e)
        {
            Comm_Print(2,2);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void DetailRead(string strBarcodeOrderId,string strMaterialCode)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    if (rdo01.Checked == true)
                        iBarCodeTypeId = 1;
                    if (rdo02.Checked == true)
                        iBarCodeTypeId = 2;
                    if (rdo03.Checked == true)
                        iBarCodeTypeId = 3;

                    this.gvList1.EndEdit();

                    SqlParameter[] values = {
                    new SqlParameter("UserNo",""),
                    new SqlParameter("StrSearch", ToString(txt_SearchText.Text)),
                    new SqlParameter("BarCodeTypeId", ToString(iBarCodeTypeId)),
                    new SqlParameter("IsAll", chkPrint.Checked),
                    new SqlParameter("BarcodeOrderId", strBarcodeOrderId),
                    new SqlParameter("MaterialCode", strMaterialCode)
                    };

                    DataSet ds = DataHelper.ExecuteProcedure("up_BarCode_Print", new String[] { "List" }, values);

                   // System.Data.DataSet ds = DataHelper.DsFill("up_BarCode_Print", values);
                    dtList2 = ds.Tables[0];
                    gvList2.DataSource = dtList2;
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("读数据时异常FrmReportList02！具体原因：" + ex.Message);
                }

            }));
        }

        public void CodeCreate()
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    this.gvList1.EndEdit();

                    DataView dvDetail = new DataView(dtList1);
                    dvDetail.RowFilter = "Is_Select=1";
                    DataTable dtDetail = dvDetail.ToTable();
                    if (dtDetail != null && dtDetail.Rows.Count>0)
                    {

                        SqlParameter[] values = {
                            new SqlParameter("OrderNo",ToString(dtDetail.Rows[0]["Order_No"])),
                            new SqlParameter("MaterialCode", ToString(dtDetail.Rows[0]["Material_Code"])),
                            new SqlParameter("Qty", ToDouble(txt_PrintCount.Text))
                        };

                        DataSet ds = DataHelper.ExecuteProcedure("up_BarCode_Print_Create", new String[] { "List" }, values);


                   //     System.Data.DataSet ds = DataHelper.DsFill("up_BarCode_Print_Create", values);

                    }
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("读数据时异常FrmReportList02！具体原因：" + ex.Message);
                }

            }));
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            CodeCreate();
        }

        private static string ToString(object refData)
        {
            if (refData == null)
                return "";
            else
                return refData == DBNull.Value ? "" : refData.ToString();
        }

        private static Double ToDouble(object refData)
        {
            if (refData == null)
                return 0;
            else
                return refData == DBNull.Value ? 0 : Convert.ToDouble(refData);
        }

        private static Int32 ToInt32(object refData)
        {
            if (refData == null)
                return 0;
            else
                return refData == DBNull.Value ? 0 : Convert.ToInt32(refData);
        }

        private static DateTime ToDateTime(object refData)
        {
            if (refData == null)
                return DateTime.Now;
            else
                return refData == DBNull.Value ? DateTime.Now : Convert.ToDateTime(refData);
        }

        private void btnPrint2_Click(object sender, EventArgs e)
        {
            Comm_Print(1, 1);
        }

        private void gvList1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                strCurOrderNo = ToString(this.gvList1.Rows[e.RowIndex].Cells["Order_No"].Value);
                strCurMaterialCode = ToString(this.gvList1.Rows[e.RowIndex].Cells["Material_Code"].Value);
                int PrintQty = ToInt32(this.gvList1.Rows[e.RowIndex].Cells["OrderDif_Qty"].Value);
                txtPrintQty.Text = ToString(PrintQty);
                DetailRead(strCurOrderNo, strCurMaterialCode);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvList1.CurrentRow == null || gvList1.CurrentRow.Index == -1)
                {
                    return;
                }

                FrmOrderModify OrderForm = new FrmOrderModify();
                OrderForm.bModify = true;

                OrderForm.cBarcode_Order_Id= ToInt32(gvList1.Rows[gvList1.CurrentRow.Index].Cells["Barcode_Order_Id"].Value);
                OrderForm.cOrder_No = ToString(gvList1.Rows[gvList1.CurrentRow.Index].Cells["Order_No"].Value);
                OrderForm.cMaterial_code = ToString(gvList1.Rows[gvList1.CurrentRow.Index].Cells["Material_code"].Value);
                OrderForm.cMaterial_Name = ToString(gvList1.Rows[gvList1.CurrentRow.Index].Cells["Material_Name"].Value);
                OrderForm.cMaterial_Spec = ToString(gvList1.Rows[gvList1.CurrentRow.Index].Cells["colMaterial_Spec"].Value);
                OrderForm.cQty = ToInt32(gvList1.Rows[gvList1.CurrentRow.Index].Cells["OrderQty"].Value);
                OrderForm.cRemark= ToString(gvList1.Rows[gvList1.CurrentRow.Index].Cells["colRemark"].Value);
                OrderForm.cBarCode_Type_Id= ToInt32(gvList1.Rows[gvList1.CurrentRow.Index].Cells["BarCode_Type_Id"].Value);
                OrderForm.cOrder_Date = ToDateTime(gvList1.Rows[gvList1.CurrentRow.Index].Cells["colOrder_Date"].Value);

                DialogResult r = OrderForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    DataRead();
                }
                OrderForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("修改物料数据异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改物料数据异常！，请检查数据库连接.");
            }
        }

        private void gvList1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               gvList1.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   gvList1.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   gvList1.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void gvList2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //自动编号，与数据无关
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
               e.RowBounds.Location.Y,
               gvList2.RowHeadersWidth - 4,
               e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                  (e.RowIndex + 1).ToString(),
                   gvList2.RowHeadersDefaultCellStyle.Font,
                   rectangle,
                   gvList2.RowHeadersDefaultCellStyle.ForeColor,
                   TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
