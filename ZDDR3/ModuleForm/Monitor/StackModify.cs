using Sys.DbUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Monitor
{
    public partial class StackModify : Form
    {
        public int PlanNum = -1;
        public int ActualNum = -1;
        private int QuaNum = -1;
        
        public string MaterialCode = "";

        public StackModify()
        {
            InitializeComponent();
        }

        private void StackModify_Load(object sender, EventArgs e)
        {
            lbl_Code.Text = MaterialCode;
            lbl_PlanNum.Text = PlanNum.ToString();
            lbl_ActualNum.Text = ActualNum.ToString();
            QuaNum = Convert.ToInt32(PlanNum * 0.8);
            lbl_different.Text = (PlanNum - ActualNum).ToString();
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void GetNum()
        {
            String sql = String.Format(@"SELECT (case when isnull(wanchengshu) then 0 else wanchengshu end )as wanchengshu From view_15daysorderplancomplete 
                                              WHERE  TO_DAYS(est) = TO_DAYS(NOW()) AND Production_Line_Code = '{0}' AND prod_code = '{1}'", "3U",MaterialCode);
            DataSet ds = DataHelper.MySqlFill(sql);
            if(ds != null)
            {
                lbl_ActualNum.Text = ds.Tables[0].Rows[0]["wanchengshu"].ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetNum();
            lbl_ActualNum.Text = ActualNum.ToString();
            lbl_different.Text = (PlanNum - ActualNum).ToString();            
            if(ActualNum>QuaNum && ActualNum < PlanNum)
            {
                lbl_different.ForeColor = Color.Gold;
            }
            else if(ActualNum >= PlanNum)
            {
                lbl_different.ForeColor = Color.Lime;
            }
            else
            {
                lbl_different.ForeColor = Color.Red;
            }
        }
    }
}
