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
    public partial class FrmEnergy : Form
    {
        private string energy_code = "";
        private string energy_name = "";
        public FrmEnergy()
        {
            InitializeComponent();

        }

        private void FrmEnergy_Load(object sender, EventArgs e)
        {

            dgvCommon.TopLeftHeaderCell.Value = "序号" +"\n\r"+"No.";
            dgvCommon1.TopLeftHeaderCell.Value = "序号" + "\n\r" + "No.";
            GetEnergyInfo();

        }

        private void GetEnergyInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name From IMOS_TA_Material where 
                                        Company_Code = '{0}' and Company_Name = '{1}'and Factory_Code = '{2}'and Factory_Name = '{3}'and
                                        Product_Line_Code = '{4}'and Product_Line_Name = '{5}' and Material_Type_Code = '{6}' ",
                                        BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                        BaseSystemInfo.ProductLineName, "NHT");
                DataSet ds = DataHelper.Fill(sql);
                if (ds == null)
                {
                    SysBusinessFunction.WriteLog("查询能耗贴信息操作失败！");
                    return;
                }
                dgvCommon.DataSource = ds.Tables[0];
                dgvCommon.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取能耗贴信息失败！");
            }
        }

        private void dgvCommon_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgvCommon.Rows)
            {
                r.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                r.HeaderCell.Value = string.Format("{0}", r.Index + 1);
            }
            dgvCommon.ClearSelection();
        }

        private void GetProductInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT ID,Product_Code,Product_Name From IMOS_TA_Map where 
                                        Company_Code = '{0}' and Company_Name = '{1}'and Factory_Code = '{2}'and Factory_Name = '{3}'and
                                        Product_Line_Code = '{4}'and Product_Line_Name = '{5}' and Material_Code = '{6}' and Material_Name = '{7}' and Material_Type = '{8}'",
                                     BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                     BaseSystemInfo.ProductLineName, energy_code, energy_name, "NXT");
                DataSet ds = DataHelper.Fill(sql);
                dgvCommon1.DataSource = ds.Tables[0];
                dgvCommon1.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgvCommon1.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取能耗贴对应的产品信息失败！");
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT ID,Product_Code,Product_Name From IMOS_TA_Map where 
                                        Company_Code = '{0}' and Company_Name = '{1}'and Factory_Code = '{2}'and Factory_Name = '{3}'and
                                        Product_Line_Code = '{4}'and Product_Line_Name = '{5}' and Material_Code = '{6}' and Material_Name = '{7}' and Material_Type = '{8}'",
                                     BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode,
                                     BaseSystemInfo.ProductLineName, energy_code, energy_name, "NXT");
                DataSet ds = DataHelper.Fill(sql);
                if(ds.Tables[0].Rows.Count >= 6)
                {
                    SysBusinessFunction.SystemDialog(2, "一个能耗贴最多对应6个产品 Not more than six");
                    return;
                }
                if (energy_code.Length == 0)
                {
                    return;
                }
                FrmEnergyModify fcm = new FrmEnergyModify();
                fcm.bModify = false;
                fcm.OldEnergyCode = energy_code;
                fcm.OldEnergyName = energy_name;

                DialogResult r = fcm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetProductInfo();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("添加冰箱-能效贴对应关系信息失败！");
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
                if (energy_code.Length == 0)
                {
                    return;
                }
                if (dgvCommon1.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请只选择一条数据! Only one data");
                    return;
                }
                string sMID = dgvCommon1.SelectedRows[0].Cells["Pro_Code"].Value.ToString();
                string sMessage = "是否删除编号为【" + sMID + "】的产品数据？ Delete 【" + sMID + "】";
                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, sMessage) == DialogResult.No)
                {
                    return;
                }

                String sql = String.Format(@"DELETE FROM IMOS_TA_Map where ID = '{0}'and Material_Type = '{1}' ", dgvCommon1.SelectedRows[0].Cells["ID"].Value.ToString(), "NXT");
                DataHelper.Fill(sql);
                GetProductInfo();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("删除冰箱-能效贴对应关系信息失败！");
            }

        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (energy_code.Length == 0)
                {
                    return;
                }
                if (dgvCommon1.SelectedRows.Count != 1)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请只选择一条数据! Only one data");
                    return;
                }
                FrmEnergyModify fcm = new FrmEnergyModify();
                fcm.bModify = true;
                fcm.MapID = dgvCommon1.SelectedRows[0].Cells["ID"].Value.ToString();
                fcm.Product_Code = dgvCommon1.SelectedRows[0].Cells["Pro_Code"].Value.ToString();
                fcm.Product_Name = dgvCommon1.SelectedRows[0].Cells["Pro_Name"].Value.ToString();
                fcm.OldEnergyCode = energy_code;
                fcm.OldEnergyName = energy_name;
                DialogResult r = fcm.ShowDialog();
                if (r == DialogResult.OK)
                {
                    GetProductInfo();
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("编辑冰箱-能效贴对应关系信息失败！");
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

        private void dgvCommon_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                //获取成品型号
                energy_code = dgvCommon.SelectedRows[0].Cells["EnergyCode"].Value.ToString();
                energy_name = dgvCommon.SelectedRows[0].Cells["EnergyName"].Value.ToString();
                //显示产品信息
                GetProductInfo();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
