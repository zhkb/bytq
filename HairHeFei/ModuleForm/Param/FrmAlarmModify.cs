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

namespace Param
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;

    public partial class FrmAlarmModify : Form
    {
        private ArrayList EquipmentList = new ArrayList();

        public string sPID = "";
        public string sPNo = "";
        public string sEType = "1";
        public string sECode = "";
        public string sEName = "";
        public string sPName = "";
        public string sDesc = "";

        public bool bModify = false;
//        public ParamType paramType;
        public FrmAlarmModify()
        {
            InitializeComponent();
        }

        private void FrmParamModify_Load(object sender, EventArgs e)
        {
            GetEquipmentData();

            tbPID.Text = sPID;
            com_Equipment.Text = sEName;
            txt_AlarmDesc.Text = sPName;
            txt_AlarmRemark.Text = sDesc;
        }

        private void GetEquipmentData()
        {
            try
            {
                string SqlStr = "";
                DataSet PartDataSet = new DataSet();

                SqlStr = string.Format(@"SELECT * FROM Sys_Equipment 
                                       Where Equipment_Type={0} and Company_Code = '{1}' and Factory_Code = '{2}' and Product_Line_Code = '{3}'
                                       Order By Equipment_Code", 1, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);

                PartDataSet = DataHelper.Fill(SqlStr);
                EquipmentList.Clear();
                com_Equipment.Items.Clear();

                EquipmentInfo EquipmentData = new EquipmentInfo();
                //EquipmentData.ActionNo = 0;
                //EquipmentData.ActionName = "";
                //EquipmentList.Add(EquipmentData);

                //com_Equipment.Items.Add("");
                for (int i = 0; i < PartDataSet.Tables[0].Rows.Count; i++)//i是查到的数据条数
                {
                    DataRow dr = PartDataSet.Tables[0].Rows[i];
                    EquipmentData.EquipmentType = dr["Equipment_Type"].ToString();
                    EquipmentData.EquipmentCode = dr["Equipment_Code"].ToString();
                    EquipmentData.EquipmentName = dr["Equipment_Name"].ToString();
                    EquipmentList.Add(EquipmentData);

                    com_Equipment.Items.Add(dr["Equipment_Name"].ToString());
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "查询设备数据失败，请检查数据库连接.");
            }
            finally
            {

            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {


            sPName = txt_AlarmDesc.Text.Trim();
            sDesc = txt_AlarmRemark.Text.Trim();

            int ItemIndex = com_Equipment.SelectedIndex;

            EquipmentInfo EquipmentData = (EquipmentInfo)EquipmentList[ItemIndex];
            sECode = EquipmentData.EquipmentCode;
            sEName = EquipmentData.EquipmentName;

            //sEName = com_Equipment.Text.Trim();
            //对数据进行检查

            if (sEName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "设备不能为空.");
                return;
            }

            if (sPID.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警编码不可为空");
                return;
            }

            if (sDesc.Length > 200)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警描述过长");
                return;
            }

            try
            {
                string SqlStr = string.Format(@"UPDATE [Sys_Alarm] 
                                                SET [Alarm_Desc] = '{0}',[Remark] = '{1}',[Equipment_Type] = '{2}',[Equipment_Code] = '{3}',[Equipment_Name] = '{4}'
                                                WHERE ID = '{5}'",
                                                sPName, sDesc, sEType, sECode, sEName, sPID);
                DataHelper.Fill(SqlStr);
                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("报警数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "报警数据处理异常！.");
            }

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txt_AlarmRemark_TextChanged(object sender, EventArgs e)
        {

        }

        private void com_Equipment_DropDown(object sender, EventArgs e)
        {

        }
    }
}
