using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sys.SysBusiness
{
    using Sys.Utilities;
    
    using Sys.DbUtilities;
    
    using Sys.SysBusiness;
    public partial class FrmItemSelect : BaseForm
    {
        public string SelectSql = "";
        public string DataCode = "";
        public string DataName = "";

        public FrmItemSelect()
        {
            InitializeComponent();
        }

        private bool GetListData()
        {
            DataSet DBDataSet = new DataSet();
            try
            {
                DBDataSet = DataHelper.Fill(SelectSql);

                int DataCount = 0;
                foreach (DataRow dr in DBDataSet.Tables[0].Rows)
                {
                    DataCount++;
                    string[] TempletItems = new String[3];
                    TempletItems[0] = DataCount.ToString();
                    TempletItems[1] = dr["DataCode"].ToString();
                    TempletItems[2] = dr["DataName"].ToString();

                    ListViewItem LVItem = new ListViewItem(TempletItems);

                    int ModNum = DataCount % 2;

                    for (int i = 0; i < 3; i++)
                    {
                        LVItem.SubItems[i].BackColor = OptionSetting.ViewBackColor[ModNum];
                    }

                    LVItem.UseItemStyleForSubItems = false;
                    lv_DataList.Items.Add(LVItem);
                }

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("初始化数据失败，请确认数据库连接和数据准确性.");
                SysBusinessFunction.WriteLog("初始化数据失败，请确认数据库连接和数据准确性." + "\r\n" + ex);
                return false;

            }
            finally
            {
                DBDataSet.Dispose();
            }
        }

        private void FrmItemSelect_Load(object sender, EventArgs e)
        {
            GetListData();
        }


        private void lv_DataList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int ItemSelCount = lv_DataList.SelectedItems.Count;
                int ItemCount = lv_DataList.Items.Count;

                if (ItemSelCount > 0)
                {
                    int FIndex = lv_DataList.SelectedItems[0].Index;
                    DataCode = lv_DataList.Items[FIndex].SubItems[1].Text;
                    DataName = lv_DataList.Items[FIndex].SubItems[2].Text;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
