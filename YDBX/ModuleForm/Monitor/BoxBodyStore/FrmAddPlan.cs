using Material;
using Sys.Config;
using Sys.DbUtilities;
using Sys.SysBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor.BoxBodyStore
{
    public partial class FrmAddPlan : Form
    {
      public  string Msg = "";
        public FrmAddPlan()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            FrmMaterialSelect SelectMaterial = new FrmMaterialSelect();
            SelectMaterial.MaterialType = "MN001";
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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
               
                string sMCode = tbMCode.Text.Trim();
                string sMName = tbMName.Text.Trim();
                if (sMCode.Length == 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "产品信息不可为空");
                    return;
                }
                Regex rx = new Regex("^[1-9]*$");

                if (!rx.IsMatch(tbQty.Text) )
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "出库数量只能为数字");
                    return;
                }
                int Qty = int.Parse(tbQty.Text.Trim());

                //判断是否有库存

                //查询未出库的，查询现在库存的
                //统计一个数据与库存信息做判断，有足够库存则可以出库
                //库存数量=在库+在途-已创建任务未执行的
                int TaskNum = 0;
                int StoreNum = 0;//库存
                int OutStoreNum = 0;
                //未出库任务数量
                string sqlStr = string.Format(@"select count(*) as Num from IMOS_BA_TRK T 
                        where t.Company_Code = '{0}' and T.Factory_Code = '{1}' and T.Product_Line_Code = '{2}' and T.Workstation_No='{3}' and Material_Code = '{4}'  and T.IO='I'   and T.Flag =0  and Process_Code='{5}'",
                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.StationCode, sMCode, BaseSystemInfo.CurrentProcessCode);
                  DataSet  ds = DataHelper.Fill(sqlStr);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                     TaskNum =int.Parse( ds.Tables[0].Rows[0]["Num"].ToString());
                }
                //在库数量
                string sqlStr1 = string.Format(@"select  Transit_Qty+Actual_Qty as Num from IMOS_Lo_Bin 
                        where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'  and Material_Code = '{3}'  and Bin_Flag = 0 and  and Process_Code='{4}'",
                                BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, BaseSystemInfo.CurrentProcessCode);
                DataSet ds1 = DataHelper.Fill(sqlStr1);
                if (ds1 != null && ds1.Tables[0].Rows.Count > 0)
                {
                    StoreNum = int.Parse(ds1.Tables[0].Rows[0]["Num"].ToString());
                }
                //可出库数量
                OutStoreNum = StoreNum - TaskNum;
                if (Qty > OutStoreNum) {

                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料【" +sMName + "】剩余出库数量为"+ OutStoreNum + "无法出库");
                    return;

                }

               





                string GUID = Guid.NewGuid().ToString("N");
                string sql = "";
                sql = sql + string.Format(@" Insert Into IMOS_LIST_OUT(Company_Code,Factory_Code,Product_Line_Code,Workstation_No,Material_Code,Material_Name,Plan_Num,Flag,Creation_Date,Created_By,ID,Process_Code) 
                                               Values ('{0}','{1}','{2}','{3}','{4}','{5}',{6},'0',GETDATE(),'{7}','{8}','{9}' );"
                                  , BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,BaseSystemInfo.StationCode, sMCode,sMName,Qty, BaseSystemInfo.CurrentUserID, GUID, BaseSystemInfo.CurrentProcessCode);

                for (int i = 0; i < Qty; i++)
                {


                    DbParameter[] param = {
                                      new SqlParameter("@CompanyCode", BaseSystemInfo.CompanyCode),
                                 
                                      new SqlParameter("@FactoryCode",BaseSystemInfo.FactoryCode),//
                                 
                                      new SqlParameter("@ProductLineCode",BaseSystemInfo.ProductLineCode),//
    
                                      new SqlParameter("@SeqType",1),//类型 箱体寄存库
     
                                      };
                    DataSet seqNoDs = DataHelper.ExecuteProcedure("up_Comm_Get_SeqNo", new String[] { "List" }, param);
                    string SeqNO = "";
                    if (seqNoDs != null && seqNoDs.Tables[0].Rows.Count > 0) {

                        SeqNO = seqNoDs.Tables[0].Rows[0]["Seq_No"].ToString();
                    }






                        sql = sql + string.Format(@" Insert Into IMOS_BA_TRK(Company_Code,Factory_Code,Product_Line_Code,Workstation_No,Material_Code,Material_Name,IO,LIST_ID,Flag,Creation_Date,Created_By,SortNum,SER_NO,Process_Code) 
                                               Values ( '{0}','{1}','{2}','{3}','{4}','{5}','I','{6}','0',GETDATE(),'{7}',{8},{9},'{10}');"
                                   , BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, BaseSystemInfo.StationCode, sMCode, sMName,GUID, BaseSystemInfo.CurrentUserID,(i+1),SeqNO, BaseSystemInfo.CurrentProcessCode);

                }
                DataHelper.Fill(sql);
                Msg = "创建成功";

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {

                DialogResult = DialogResult.No;
            }
         



          
        }
    }
}
