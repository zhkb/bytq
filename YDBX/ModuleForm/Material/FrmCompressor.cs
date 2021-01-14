using Sys.Config;
using Sys.DbUtilities;
using Sys.Language;
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
    public partial class FrmCompressor : Form
    {
        private string product_code = "";
        private string product_name = "";
        public FrmCompressor()
        {
            InitializeComponent();
           
        }

        private void FrmCompressor_Load(object sender, EventArgs e)
        {
            if (BaseSystemInfo.LanguageType == "2")
            {
                ChangLanguage.SetLang("en-US", this, typeof(FrmCompressor));
                dgvCommon.Columns["Material_Code"].HeaderText = "Product_Code";
                dgvCommon.Columns["Material_Name"].HeaderText = "Product_Code";
                dgvCommon1.Columns["Compressor_Code"].HeaderText = "Compressor_Code";
                dgvCommon1.Columns["Compressor_Name"].HeaderText = "Compressor_Name";
                dgvCommon.TopLeftHeaderCell.Value = "NO";
                dgvCommon1.TopLeftHeaderCell.Value = "NO";
            }
            else
            {
                dgvCommon.TopLeftHeaderCell.Value = "序号"+"\n\r"+"No.";
                dgvCommon1.TopLeftHeaderCell.Value = "序号"+"\n\r"+"No.";
            }
            //获取冰箱成品信息
            GetProductInfo();
            
        }

        private void GetProductInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name From IMOS_TA_Material where 
                                        Company_Code = '{0}' and Company_Name = '{1}'and Factory_Code = '{2}'and Factory_Name = '{3}'and
                                        Product_Line_Code = '{4}'and Product_Line_Name = '{5}' and Material_Type_Code = '{6}' ",
                                        BaseSystemInfo.CompanyCode,BaseSystemInfo.CompanyName,BaseSystemInfo.FactoryCode,BaseSystemInfo.FactoryName,BaseSystemInfo.ProductLineCode,
                                        BaseSystemInfo.ProductLineName,"MN001");
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    SysBusinessFunction.WriteLog("查询成品操作失败！");
                    return;
                }
                dgvCommon.DataSource = ds.Tables[0];
                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("获取冰箱成品信息失败！");
            }
        }

        private void dgvCommon_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach(DataGridViewRow r in dgvCommon.Rows)
            {
                r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                r.HeaderCell.Value = string.Format("{0}", r.Index + 1);
            }
            dgvCommon.ClearSelection();
        }

        private void dgvCommon_MouseClick(object sender, MouseEventArgs e)
        {
            //获取成品型号
            product_code = dgvCommon.SelectedRows[0].Cells["Pro_Code"].Value.ToString();
            product_name = dgvCommon.SelectedRows[0].Cells["Pro_Name"].Value.ToString();
            //显示压缩机信息
            GetCompressorInfo();
        }

        private void GetCompressorInfo()
        {
           try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name From IMOS_TA_Map where 
                                        Company_Code = '{0}' and Company_Name = '{1}'and Factory_Code = '{2}'and Factory_Name = '{3}'and
                                        Product_Line_Code = '{4}'and Product_Line_Name = '{5}' and Product_Code = '{6}' and Product_Name = '{7}' and Material_Type = '{8}'",
                                     BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                     BaseSystemInfo.ProductLineName, product_code, product_name,"YSJ");
                DataSet ds = DataHelper.Fill(sql);
                dgvCommon1.DataSource = ds.Tables[0];
                dgvCommon1.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("获取压缩机信息失败！");
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (product_code.Length == 0)
                {
                    return;
                }
                FrmCompressorModify fcm = new FrmCompressorModify();
                fcm.bModify = false;
                fcm.Product_Code = product_code;
                fcm.Product_Name = product_name;
                DialogResult r = fcm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetCompressorInfo();
                }
            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("添加冰箱-压缩机对应关系信息失败！");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (product_code.Length == 0)
                {
                    return;
                }
                if (dgvCommon1.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请只选择一条数据!");
                    return;
                }
                string sMID = dgvCommon1.Rows[0].Cells["Compressor_Code"].Value.ToString();
                string sMessage = "是否删除编号为【"+sMID+ "】的压缩机数据？Delete Compressor Code 【" + sMID + "】";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                String sql = String.Format(@"DELETE FROM IMOS_TA_Map where Product_Code = '{0}'and Product_Name = '{1}' 
                                             and Material_Code= '{2}'and Material_Name = '{3}' and Material_Type = '{4}' ", 
                                             product_code,product_name, dgvCommon1.SelectedRows[0].Cells["Compressor_Code"].Value.ToString(), 
                                             dgvCommon1.SelectedRows[0].Cells["Compressor_Name"].Value.ToString(),"YSJ");
                DataHelper.Fill(sql);
                GetCompressorInfo();
            }
            catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("删除冰箱-压缩机对应关系信息失败！");
            }
         
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (product_code.Length == 0)
                {
                    return;
                }
                if (dgvCommon1.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请只选择一条数据!"+"\n\r"+ "Please select only one data!");
                    return;
                }
                FrmCompressorModify fcm = new FrmCompressorModify();
                fcm.bModify = true;
                fcm.Product_Code = product_code;
                fcm.Product_Name = product_name;
                fcm.OldCompressorCode = dgvCommon1.SelectedRows[0].Cells["Compressor_Code"].Value.ToString();
                fcm.OldCompressorName = dgvCommon1.SelectedRows[0].Cells["Compressor_Name"].Value.ToString();
                DialogResult r = fcm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetCompressorInfo();
                }
            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("编辑冰箱-压缩机对应关系信息失败！");
            }
          
        }

        private void dgvCommon1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvCommon1.Rows)
            {
                r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                r.HeaderCell.Value = string.Format("{0}", r.Index + 1);
            }
            dgvCommon1.ClearSelection();
        }
    }
}
