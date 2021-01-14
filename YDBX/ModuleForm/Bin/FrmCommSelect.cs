using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bin
{
    public partial class FrmCommSelect : Form
    {
        //public delegate void GetValueHandler(string code,string value);//声明委托
        public delegate void GetValueHandler(DataGridViewRow dgvr);//声明委托
        public GetValueHandler getValueHandler;//委托对象
        private string title;
        private string procedureName;
        private DbParameter[] dbParameters;
        private string sql;
        public string sBinId;
        private string sMaterialCode;

        public int pageSize = 20;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        DataTable dtSource = new DataTable();


        public FrmCommSelect()
        {
            InitializeComponent();
        }
        public FrmCommSelect(string title, string procedureName, DbParameter[] dbParameters)
        {
            InitializeComponent();
            this.title = title;
            this.Text = title;
            this.procedureName = procedureName;
            this.dbParameters = dbParameters;
            lbl_Title.Text = title;
            BindData(procedureName, dbParameters);
        }
        public FrmCommSelect(string title, string sql)
        {
            InitializeComponent();
            this.title = title;
            this.sql = sql;
            lbl_Title.Text = title;
            BindData(sql);
        }

        private void CommSelectFrm_Load(object sender, EventArgs e)
        {
            AutoSizeColumn(dgv);
        }
        private void BindData(string procedureName, DbParameter[] dbParameters)
        {
            try
            {
                DataSet ds = DataHelper.ExecuteProcedure(procedureName, new String[] { "List" }, dbParameters);

                if (ds != null)
                {
                    dtSource = ds.Tables[0];
                    recordCount = dtSource.Rows.Count;
                    pageCount = (recordCount / pageSize);

                    if ((recordCount % pageSize) > 0)
                    {
                        pageCount++;
                    }

                    //默认第一页
                    currentPage = 1;

                    LoadPage();//调用加载数据的方法
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("数据查询出错," + ex.Message);
            }
        }
        private void BindData(string sql)
        {
            try
            {
                DataSet ds = DataHelper.Fill(sql);

                if (ds != null)
                {
                    dtSource = ds.Tables[0];
                    recordCount = dtSource.Rows.Count;
                    pageCount = (recordCount / pageSize);

                    if ((recordCount % pageSize) > 0)
                    {
                        pageCount++;
                    }

                    //默认第一页
                    currentPage = 1;

                    LoadPage();//调用加载数据的方法
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("数据查询出错," + ex.Message);
            }
        }
        private void LoadPage()
        {
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            int beginRecord;
            int endRecord;
            DataTable dtTemp;
            dtTemp = dtSource.Clone();

            beginRecord = pageSize * (currentPage - 1);
            if (currentPage == 1) beginRecord = 0;
            endRecord = pageSize * currentPage;

            if (currentPage == pageCount) endRecord = recordCount;
            for (int i = beginRecord; i < endRecord && beginRecord >= 0; i++)
            {
                dtTemp.ImportRow(dtSource.Rows[i]);
            }
            dgv.DataSource = dtTemp;
            dgv.RowsDefaultCellStyle.BackColor = Color.LightCyan;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            //toolStripLabel1.Text = currentPage.ToString();//当前页
            //toolStripLabel4.Text = pageCount.ToString();//总页数
            //toolStripLabel6.Text = recordCount.ToString();//总记录数
        }

        /// <summary>
        /// DataGridView相关设置
        /// </summary>
        /// <param name="dgViewFiles"></param>
        public void AutoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //只显示前两列信息
            for (int i = 3; i < dgViewFiles.Columns.Count; i++)
            {
                dgViewFiles.Columns[i].Visible = false;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            dgViewFiles.Columns[0].Width = 80;
            //冻结某列 从左开始 0，1，2
            //dgViewFiles.Columns[1].Frozen = true;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index == -1 || CheckBin())
            {
                return;
            }
            if (getValueHandler != null)
            {
                //getValueHandler(dgv.CurrentRow.Cells[0].Value.ToString(), 
                //    dgv.CurrentRow.Cells[1].Value.ToString());
                getValueHandler(dgv.CurrentRow);
                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 双击选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (getValueHandler != null)
                {
                    //getValueHandler(dgv.CurrentRow.Cells[0].Value.ToString(), 
                    //    dgv.CurrentRow.Cells[1].Value.ToString());
                    getValueHandler(dgv.CurrentRow);
                    this.Close();
                }
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Before_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadPage();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Next_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadPage();
        }

        private void btn_Query_Click(object sender, EventArgs e)
        {
            dbParameters[0].Value = tbKey.Text;
            BindData(procedureName, dbParameters);
        }


        private void tbKey_Click(object sender, EventArgs e)
        {
            //Process kbpr = System.Diagnostics.Process.Start("osk.exe"); // 打开系统键盘
        }

        private void tbKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Query.PerformClick();
            }
        }

        private void dgv_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentRow == null || dgv.CurrentRow.Index == -1 || CheckBin())
            {
                return;
            }
            if (getValueHandler != null)
            {
                //getValueHandler(dgv.CurrentRow.Cells[0].Value.ToString(), 
                //    dgv.CurrentRow.Cells[1].Value.ToString());
                getValueHandler(dgv.CurrentRow);
                this.Close();
            }
        }

        private bool CheckBin()
        {
            sMaterialCode = dgv.Rows[dgv.CurrentRow.Index].Cells["物料编号"].Value.ToString();
            string sSQLCheck = string.Format(@"SELECT * FROM dbo.IMOS_TE_Bin WHERE Material_Code = '{0}' AND Bin_ID != {1}", sMaterialCode, sBinId);
            DataSet ds = DataHelper.Fill(sSQLCheck);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "该物料已被其他料仓选择");
                return true;
            }
            return false;
        }
    }
}
