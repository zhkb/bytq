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
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;
    using Material;
    public partial class FrmFrontCachePlanModify : Form
    {
        public string sMID = "";
        public string sMCode = "";
        public string sMName = "";
        public string sQty = "";

        public bool bModify = false;

        public FrmFrontCachePlanModify()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 /*&& m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012*/)
            {
                base.WndProc(ref m);
            }
        }

        private void FrmFrontCachePlanModify_Load(object sender, EventArgs e)
        {
            tbMCode.Text = sMCode;
            tbMName.Text = sMName;
            tbQty.Text = sQty;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            sMCode = tbMCode.Text.Trim();
            sMName = tbMName.Text.Trim();
            sQty = tbQty.Text.Trim();

            //对数据进行检查

            if (sMCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品编码不可为空");
                return;
            }

            if (sMName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品名称不可为空");
                return;
            }

            if (sQty.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "出库数量不可为空");
                return;
            }
            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_Lo_Bin_Plan 
                                                   where Material_Code = '{0}' or Material_Name = '{1}'",
                                                    sMCode, sMName);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品编号或物料名称重复");
                    return;
                }
            }
            //更新记录 编号，名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_Lo_Bin_Plan
                                                   and (Material_Code = '{0}' or Material_Name = '{1}') and Material_ID != {2}",
                                                   sMCode,sMName,sMID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品编号或物料名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO IMOS_Lo_Bin_Plan
                                                   (Material_Code
                                                    ,Material_Name
                                                    ,Out_Qty)
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,{2}
                                                    )", sMCode, sMName,int.Parse(sQty));

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE IMOS_Lo_Bin_Plan 
                                                    SET Material_Code = '{0}' ,
                                                    Material_Name = '{1}',
                                                    Out_Qty = {2}                                                  
                                                    WHERE Material_ID = {3}",
                                                    sMCode, sMName, int.Parse(sQty),sMID);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("出库规则数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "出库规则数据处理异常！");
            }

        }

        private void bt_Select_Click(object sender, EventArgs e)
        {
            FrmMaterialSelect SelectMaterial = new FrmMaterialSelect();

            DialogResult r = SelectMaterial.ShowDialog();

            if (r == DialogResult.OK)
            {

                string MaterialCode = SelectMaterial.MaterialCode;
                string MaterialName = SelectMaterial.MaterialName;
                try
                {                  
                    tbMCode.Text = MaterialCode;
                    tbMName.Text = MaterialName;
                }
                catch (Exception ex)
                {
                    SysBusinessFunction.WriteLog("选择产品名称异常" + ex.Message);
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "选择产品名称异常");
                }

            }
        }
    }
}
