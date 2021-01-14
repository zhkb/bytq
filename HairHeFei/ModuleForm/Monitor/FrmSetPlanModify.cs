using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public partial class FrmSetPlanModify : Form
    {
        public bool ModifyFlag = false;
        public string MaterialCode = "";
        public string MaterialName = "";
        public int MaterialNum = 0;
        public FrmSetPlanModify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.No;
            }
            catch(Exception ex)
            {

            }
        }

        private void FrmSetPlanModify_Load(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name FROM IMOS_TA_Material WHERE Material_Plan_Num = 0");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    comboBox1.DataSource = ds.Tables[0];
                    comboBox1.DisplayMember = "Material_Name";
                    comboBox1.ValueMember = "Material_Code";
                }
                if (ModifyFlag) {
                    comboBox1.Text = MaterialName;
                    textBox1.Text = MaterialNum.ToString();
                    comboBox1.Enabled = false;
                }
               

            }
            catch(Exception ex)
            {

            }
        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string mcode = comboBox1.SelectedValue.ToString();
                if (ModifyFlag)
                {
                    mcode = MaterialCode;
                }
                string mname = comboBox1.SelectedText.ToString();
                if (!IsInt(textBox1.Text.ToString())){
                    SysBusinessFunction.WriteLog("输入非数字！");
                    return;
                }
                int m = int.Parse(textBox1.Text.ToString());
                if(mcode==null||mcode.Length == 0)
                {
                    SysBusinessFunction.WriteLog("编号不能为空！");
                    return;
                }
                if (mname == null || mcode.Length == 0)
                {
                    SysBusinessFunction.WriteLog("名称不能为空！");
                    return;
                }
                String sql = String.Format(@"UPDATE  IMOS_TA_Material Set Material_Plan_Num = {0} WHERE Material_Code = '{1}'",m,mcode);

                DataHelper.Fill(sql);
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {

            }
        }

        #region 检验数量是否数字
        private bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
        #endregion
    }
}
