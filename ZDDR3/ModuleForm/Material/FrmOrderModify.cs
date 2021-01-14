using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Material
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;

    public partial class FrmOrderModify : Form
    {
        public int cBarcode_Order_Id;
        public string cOrder_No;
        public DateTime cOrder_Date;
        public string cMaterial_code;
        public string cMaterial_Name;
        public string cMaterial_Spec;

        public int cBarCode_Type_Id;
        public int cQty;
        public string cRemark;
        public DateTime cCreate_Date;

        public bool bModify = false;

        public FrmOrderModify()
        {
            InitializeComponent();
        }

        private void FrmMaterialModify_Load(object sender, EventArgs e)
        {
            //初始化

            string sSQL = @"SELECT BarCode_Type_Id,BarCode_Type_Name FROM View_Code_BarCode_Type";
            DataSet ds = DataHelper.Fill(sSQL);

            lueBarCode_Type_Id.DataSource = ds.Tables[0];
            lueBarCode_Type_Id.DisplayMember = "BarCode_Type_Name";
            lueBarCode_Type_Id.ValueMember = "BarCode_Type_Id";

            txtOrder_No.Text = cOrder_No;
            dtpOrder_Date.Value = cOrder_Date;
            txtMaterial_code.Text = cMaterial_code;
            txtMaterial_Name.Text = cMaterial_Name;
            txtMaterial_Spec.Text = cMaterial_Spec;
            txtQty.Text = ToString(cQty);
            lueBarCode_Type_Id.SelectedValue = cBarCode_Type_Id;
            txtRemark.Text = cRemark;
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {

            //对数据进行检查

            cOrder_No= txtOrder_No.Text;
            cOrder_Date= dtpOrder_Date.Value;
            cMaterial_code= txtMaterial_code.Text;
            cMaterial_Name = txtMaterial_Name.Text;
            cMaterial_Spec = txtMaterial_Spec.Text;
            cQty=ToInt32(txtQty.Text);
            cBarCode_Type_Id= ToInt32(lueBarCode_Type_Id.SelectedValue);
            cRemark= txtRemark.Text;

            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"SELECT Order_No FROM IMOS_PR_BARCODE_ORDER
                                                   WHERE Order_No = '{0}' AND Barcode_Order_Id<>{1}",
                                                   cOrder_No, cBarcode_Order_Id);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "单据号重复，不能保存");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"
                        UPDATE [dbo].[IMOS_PR_BARCODE_ORDER]
                        SET [Order_Date] ='{0}'
                          ,[Material_code] ='{1}'
                          ,[Material_Name] ='{2}'
                          ,[Material_Spec] ='{3}'
                          ,[BarCode_Type_Id] ={4}
                          ,[Qty] ={5}
                          ,[Remark] ='{6}'
                        WHERE Barcode_Order_Id={7}",
                       cOrder_Date, cMaterial_code,cMaterial_Name,cMaterial_Spec,cBarCode_Type_Id,cQty,cRemark,cBarcode_Order_Id);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("订单数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "订单数据处理异常！.");
            }

        }

        private static string ToString(object refData)
        {
            if (refData == null)
                return "";
            else
                return refData == DBNull.Value ? "" : refData.ToString();
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

        private void tbMID_TextChanged(object sender, EventArgs e)
        {

        }
    }


}


