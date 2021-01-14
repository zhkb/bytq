using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Equipment
{
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using Sys.Config;
    public partial class FrmEquipment : Form
    {

        public string pEquipcode = "";       //设备编码
        public string pEquipName = "";       //名称
        public string pEquipType = "";          //类型
        public string pEquipmark = "";      //备注

       public int pEquipId = 0;
        public FrmEquipment()
        {
            InitializeComponent();
        }

        #region 获取数据
        public void strGetParamData()
        {
            //查询数据
            try
            {
                DataSet DBDataSet = new DataSet();
                string SqlStr = string.Format(@"select Equipment_Type,Equipment_Code,Equipment_Name,Remark from Sys_Equipment where Company_Code='{0}'and
                                   Factory_Code='{1}' and ProductLine_Code='{2}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
               

                string sOrder = " order by Equipment_Code desc ";
                SqlStr += sOrder;

                DBDataSet = DataHelper.Fill(SqlStr);
                dgv_Equdata.DataSource = DBDataSet.Tables[0];
                dgv_Equdata.RowsDefaultCellStyle.BackColor = Color.LightCyan;
                dgv_Equdata.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("获取机台管理信息异常." + ex.Message);
            }


        }
        #endregion

        #region 机台管理-新增
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmEquModify ModifyForm = new FrmEquModify();
                ModifyForm.ModifyState = true;  //增加

                DialogResult r = ModifyForm.ShowDialog();

                if (r == DialogResult.OK)
                {
                    strGetParamData();
                }
                ModifyForm.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("新增机台信息异常！" + ex.Message);

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "新增机台信息异常！请检查数据库连接.");
            }
        }
        #endregion

        #region 机台管理-修改
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                pEquipcode = dgv_Equdata.Rows[dgv_Equdata.CurrentRow.Index].Cells["Equipment_Code"].Value.ToString();
                pEquipName = dgv_Equdata.Rows[dgv_Equdata.CurrentRow.Index].Cells["Equipment_Name"].Value.ToString();
                pEquipType = dgv_Equdata.Rows[dgv_Equdata.CurrentRow.Index].Cells["Equipment_Type"].Value.ToString();
                pEquipmark = dgv_Equdata.Rows[dgv_Equdata.CurrentRow.Index].Cells["Remark"].Value.ToString();


                /*根据编号得到id*/
                DataSet DBDataSet = new DataSet();
                string SelectSql = string.Format(@"select * from Sys_Equipment 
                                                       where Equipment_Code = '{0}'", pEquipcode);
                DBDataSet = DataHelper.Fill(SelectSql);
                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    pEquipId = int.Parse(DBDataSet.Tables[0].Rows[0]["ID"].ToString());

                }

                FrmEquModify Modify = new FrmEquModify();
                Modify.strEquId = pEquipId;
                Modify.strEquCode = pEquipcode;
                Modify.strEquName = pEquipName;
                Modify.strEqutype = pEquipType;
                Modify.strEquMark = pEquipmark;
                Modify.ModifyState = false;
                DialogResult r = Modify.ShowDialog();

                if (r == DialogResult.OK)
                {
                    strGetParamData();
                }

                Modify.Dispose();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("编辑机台信息异常." + ex.Message);
            }

        }
        #endregion

        private void FrmEquipment_Load(object sender, EventArgs e)
        {
            strGetParamData();//获取数据
            dgv_Equdata.TopLeftHeaderCell.Value = "序号";
        }
        private void dgv_Equdata_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)//序号列
        {
            e.Row.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                pEquipcode = dgv_Equdata.Rows[dgv_Equdata.CurrentRow.Index].Cells["Equipment_Code"].Value.ToString();
                pEquipName = dgv_Equdata.Rows[dgv_Equdata.CurrentRow.Index].Cells["Equipment_Name"].Value.ToString();
                pEquipType = dgv_Equdata.Rows[dgv_Equdata.CurrentRow.Index].Cells["Equipment_Type"].Value.ToString();

                if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format("是否确认删除[{0}]的机台信息？", pEquipcode)) == DialogResult.No)
                {
                    return;
                }
                
                string SqlStr = string.Format(@"Delete From Sys_Equipment Where Equipment_Code = '{0}' and Company_Code ='{1}' and Factory_Code='{2}' and ProductLine_Code ='{3}'", 
                                                          pEquipcode, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                DataHelper.Fill(SqlStr);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "删除机台信息成功.");

                pEquipcode = "";
                pEquipName = "";
                pEquipType = "";

                strGetParamData(); //获取
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("机台信息删除异常." + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "机台信息删除异常.请检查数据库连接状态.");
            }
        }
    }
}
