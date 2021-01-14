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

namespace Material
{
    public partial class FrmQualityDetailModify : Form
    {
        public string id;
        public string itemcode;
        public string detailcode;
        public string cnname;
        public string enname;
        public bool Flag; //false 增加质检项 true 编辑质检项
        public FrmQualityDetailModify()
        {
            InitializeComponent();
        }

        #region 界面加载
        private void FrmQualityDetailModify_Load(object sender, EventArgs e)
        {
            try
            {
                txt_Item_Code.Text = itemcode;
                txt_Item_Code.Enabled = false;
                if (Flag)//编辑
                {
                    txt_Detail_Code.Text = detailcode;
                    txt_Detail_Name_CN.Text = cnname;
                    txt_Detail_Name_EN.Text = enname;
                }else//增加
                {
                    txt_Detail_Code.Text = "";
                    txt_Detail_Name_CN.Text = "";
                    txt_Detail_Name_EN.Text = "";
                }

            }catch(Exception ex)
            {
                SysBusinessFunction.WriteLog("界面加载失败！");
            }
        }
        #endregion

        #region OK按钮触发事件
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                //数据        
                string detail_code = txt_Detail_Code.Text.ToString();
                string detail_name_cn = txt_Detail_Name_CN.Text.ToString();
                string detail_name_en = txt_Detail_Name_EN.Text.ToString();
                //判断数据是否合理
                if (detail_code.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, "质检缺陷编号不能为空！");
                    return;
                }
                if (detail_name_cn.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, "质检缺陷中文名称不能为空！");
                    return;
                }
                if (detail_name_en.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, "质检缺陷英文名称不能为空！");
                    return;
                }
                if (!Flag)//增加
                {
                    //判断重复
                    String sql = String.Format(@"SELECT 
                                                       ID 
                                                 FROM 
                                                      IMOS_PR_QualityItem_Detail 
                                                 Where 
                                                     Company_Code = '{0}'
                                                  and Factory_Code = '{1}'
                                                  and Product_Line_Code = '{2}'
                                                  and (Check_Item_Detail_Code = '{3}'
                                                  or  Check_Item_Detail_Name= '{4}'
                                                  or  Check_Item_Detail_Name_EN = '{5}')
                                                  ",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,detail_code, detail_name_cn, detail_name_en);
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds == null)
                    {
                        SysBusinessFunction.WriteLog("验证质检项重复操作失败！");
                        return;
                    }
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        SysBusinessFunction.SystemDialog(2, "编号，中文名称，英文名称中存在与现有质检缺陷重复！");
                        return;
                    }
                    else
                    {
                        //添加数据库操作
                        InsertItem(detail_code, detail_name_cn, detail_name_en);
                        DialogResult = DialogResult.OK;
                    }

                }
                else//编辑
                {
                    //判断重不重复
                    String sql = String.Format(@"SELECT 
                                                      ID 
                                                 FROM                                                  
                                                      IMOS_PR_QualityItem_Detail 
                                                 Where 
                                                      Company_Code = '{0}'
                                                  and Factory_Code = '{1}'
                                                  and Product_Line_Code = '{2}'
                                                  and ID!='{3}'
                                                  and (Check_Item_Detail_Code = '{4}'
                                                  or  Check_Item_Detail_Name = '{5}'
                                                  or  Check_Item_Detail_Name_EN = '{6}')",
                                                  BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,id, detail_code, detail_name_cn, detail_name_en);
                    DataSet ds = DataHelper.Fill(sql);
                    if (ds == null)
                    {
                        SysBusinessFunction.WriteLog("验证质检项重复操作失败！");
                        return;
                    }
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        SysBusinessFunction.SystemDialog(2, "编号，中文名称，英文名称中存在与现有质检项重复！");
                        return;
                    }
                    else
                    {
                        //更新数据库
                        UpdateItem(detail_code, detail_name_cn, detail_name_en);
                        DialogResult = DialogResult.OK;
                    }
                }

            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("质检项数据维护发生异常！" + ex.Message);
            }
        }

        #endregion

        #region Close按钮触发事件
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("关闭按钮异常！" + ex.Message);
            }
        }
        #endregion

        #region 添加质检项
        private void InsertItem(string code, string cnname, string enname)
        {
            try
            {
                String sql = String.Format(@"INSERT INTO 
                                                  IMOS_PR_QualityItem_Detail (
                                                             Company_Code,
                                                             Company_Name,
                                                             Factory_Code,
                                                             Factory_Name,
                                                             Product_Line_Code,
                                                             Product_Line_Name,
                                                             Check_Item_Code,
                                                             Check_Item_Detail_Code,
                                                             Check_Item_Detail_Name,
                                                             Check_Item_Detail_Name_EN,
                                                             Create_Time,
                                                             Create_By,
                                                             Modify_Time,
                                                             Modify_By             
                                                             )values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',
                                                                     '{7}','{8}','{9}',GetDate(),'{10}',GetDate(),'{10}')",
                                             BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode,
                                             BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                             itemcode, code, cnname, enname, BaseSystemInfo.CurrentUserCode);
                DataHelper.Fill(sql);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("数据表IMOS_PR_QualityItem插入数据失败！" + ex.Message);
            }
        }
        #endregion

        #region 更新数据库
        private void UpdateItem(string icode, string cnname, string enname)
        {
            try
            {
                
                String sql = String.Format(@"Update 
                                                  IMOS_PR_QualityItem_Detail
                                             SET  
                                                  Check_Item_Detail_Code = '{0}',
                                                  Check_Item_Detail_Name ='{1}',
                                                  Check_Item_Detail_Name_EN = '{2}',
                                                  Modify_Time = GetDate(),
                                                  Modify_By = '{3}'
                                              Where Check_Item_Code= '{4}' and ID = '{5}'", icode, cnname, enname, BaseSystemInfo.CurrentUserCode, itemcode,id);
                DataHelper.Fill(sql);
              
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
