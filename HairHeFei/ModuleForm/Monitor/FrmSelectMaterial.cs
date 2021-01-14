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
    public partial class FrmSelectMaterial : Form
    {
        public DataTable seldt;

        public FrmSelectMaterial()
        {
            InitializeComponent();
            dgvall.TopLeftHeaderCell.Value = "序号";
            dgvselect.TopLeftHeaderCell.Value = "序号";
        }

        private void FrmSelectMaterial_Load(object sender, EventArgs e)
        {

            //String[] strMaterial = BaseSystemInfo.selectMaterialStr.Split(',');
            //OptionSetting.SelectMaterialList.Clear();
            //foreach (String str in strMaterial)
            //{
            //    OptionSetting.SelectMaterialList.Add(str);
            //}


            //获取产品型号
            GetMaterialInfo();
            //获取选择型号
            GetSelectMaterialInfo();
        }

        private void GetSelectMaterialInfo()
        {
            try
            {
                seldt = new DataTable();
                seldt.Columns.Add("Material_Code");
                object[] values = new object[1];
                for (int i = 0; i < OptionSetting.SelectMaterialList.Count; i++)
                {
                    values[0] = OptionSetting.SelectMaterialList[i];
                    seldt.Rows.Add(values);
                }
                dgvselect.DataSource = seldt;

            }
            catch (Exception ex)
            {

            }
        }

        private void GetMaterialInfo()
        {
            try
            {
                String sql = String.Format(@"SELECT Material_Code,Material_Name From IMOS_TA_Material Where 1=1");
                DataSet ds = DataHelper.Fill(sql);
                if (ds != null)
                {
                    dgvall.DataSource = ds.Tables[0];
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Input_Click(object sender, EventArgs e)
        {
            try
            {
                //插入
                for (int i = 0; i < dgvall.Rows.Count; i++)
                {
                    if (dgvall.Rows[i].Selected)
                    {
                        bool flag = false;
                        for (int j = 0; j < seldt.Rows.Count; j++)
                        {
                            if (seldt.Rows[j]["Material_Code"].ToString() == dgvall.Rows[i].Cells["Material_Code"].Value.ToString())
                            {
                                flag = true;
                            }
                        }
                        if (!flag)
                        {
                            object[] values = new object[1];
                            values[0] = dgvall.Rows[i].Cells["Material_Code"].Value.ToString();
                            seldt.Rows.Add(values);
                        }
                    }
                }
                dgvall.ClearSelection();
                dgvselect.DataSource = seldt;
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Output_Click(object sender, EventArgs e)
        {
            try
            {
                List<String> nlist = new List<string>();
                for (int i = 0; i < dgvselect.Rows.Count; i++)
                {
                    if (dgvselect.Rows[i].Selected)
                    {
                        nlist.Add(seldt.Rows[i]["Material_Code"].ToString());                     
                    }
                }
                for(int j = 0; j < nlist.Count; j++)
                {
                    for (int i = 0; i < dgvselect.Rows.Count; i++)
                    {
                        if (seldt.Rows[i]["Material_Code"].ToString() == nlist[j])
                        {
                            seldt.Rows[i].Delete();
                            break;
                        }
                       
                    }
                }
                dgvall.ClearSelection();           
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvall_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvall.Rows.Count; i++)
                {
                    dgvall.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvall.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void dgvselect_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvselect.Rows.Count; i++)
                {
                    dgvselect.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvselect.Rows[i].HeaderCell.Value = string.Format("{0}", i + 1);
                }
                  dgvselect.ClearSelection();
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                OptionSetting.SelectMaterialList.Clear();
                for (int i = 0; i < dgvselect.Rows.Count; i++)
                {
                    OptionSetting.SelectMaterialList.Add(dgvselect.Rows[i].Cells["Select_Material_Code"].Value.ToString());

                }
                String selectMaterialStr = "";
                foreach (string str in OptionSetting.SelectMaterialList)
                {
                    if (selectMaterialStr == "")
                    {
                        selectMaterialStr = selectMaterialStr + str;
                    }
                    else
                    {
                        selectMaterialStr = selectMaterialStr + "," + str;
                    }

                }
                ConfigHelper.SetValue("selectMaterialStr", selectMaterialStr);
                SysBusinessFunction.WriteLog(selectMaterialStr);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
