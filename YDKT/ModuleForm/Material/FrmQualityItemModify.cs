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
    public partial class FrmQualityItemModify : Form
    {
        public string id;
        public string code;
        public string cnname;
        public string enname;
        public bool Flag; //false 增加质检项 true 编辑质检项
        public FrmQualityItemModify()
        {
            InitializeComponent();
        }

        #region  质检项维护界面加载
        private void FrmQualityItemModify_Load(object sender, EventArgs e)
        {
            try
            {
                if (Flag)//编辑质检项目时初始化
                {
                    txt_Item_Code.Text = code;
                    txt_Item_Name_CN.Text = cnname;
                    txt_Item_Name_EN.Text = enname;
                }
                else
                {
                    txt_Item_Code.Text = "";
                    txt_Item_Name_CN.Text = "";
                    txt_Item_Name_EN.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region OK按钮触发事件
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                //数据
                string item_code = txt_Item_Code.Text.ToString();
                string item_name_cn = txt_Item_Name_CN.Text.ToString();
                string item_name_en = txt_Item_Name_EN.Text.ToString();
                //判断数据是否合理
                if (item_code.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, "质检项编号不能为空！");
                    return;
                }
                if (item_name_cn.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, "质检项中文名称不能为空！");
                    return;
                }
                if (item_name_en.Trim().Length == 0)
                {
                    SysBusinessFunction.SystemDialog(2, "质检项英文名称不能为空！");
                    return;
                }
                if (!Flag)//编辑
                {
                    //判断重复
                    String sql = String.Format(@"SELECT 
                                                       ID 
                                                 FROM 
                                                      IMOS_PR_QualityItem_Master 
                                                 Where 
                                                  Check_Item_Code = '{0}'
                                                  or  Check_Item_Name = '{1}'
                                                  or  Check_Item_Name_EN = '{2}'
                                                  and Company_Code = '{3}'
                                                  and Factory_Code = '{4}'
                                                  and Product_Line_Code = '{5}'",
                                                  item_code, item_name_cn, item_name_en, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
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
                        //添加数据库操作
                        InsertItem(item_code,item_name_cn,item_name_en);
                        DialogResult = DialogResult.OK;
                    }

                }
                else//增加
                {
                    //判断重不重复
                    String sql = String.Format(@"SELECT 
                                                       ID 
                                                 FROM 
                                                      IMOS_PR_QualityItem_Master 
                                                 Where 
                                                      Company_Code = '{3}'
                                                  and Factory_Code = '{4}'
                                                  and Product_Line_Code = '{5}'
                                                  and ID != '{6}'
                                                  and (Check_Item_Code = '{0}'
                                                  or  Check_Item_Name = '{1}'
                                                  or  Check_Item_Name_EN = '{2}')",
                                                item_code, item_name_cn, item_name_en, BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode,id);
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
                    }else
                    {
                        //更新数据库
                        UpdateItem(item_code,item_name_cn,item_name_en);
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
        private void InsertItem(string code,string cnname,string enname)
        {
            try
            {
                String sql = String.Format(@"INSERT INTO 
                                                  IMOS_PR_QualityItem_Master (
                                                             Company_Code,
                                                             Company_Name,
                                                             Factory_Code,
                                                             Factory_Name,
                                                             Product_Line_Code,
                                                             Product_Line_Name,
                                                             Check_Item_Num,
                                                             Check_Item_Code,
                                                             Check_Item_Name,
                                                             Check_Item_Name_EN,
                                                             Creation_Date,
                                                             Created_By,
                                                             Last_Update_Date,
                                                             Last_Updated_By             
                                                             )values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',
                                                                     '{7}','{8}','{9}',GetDate(),'{10}',GetDate(),'{10}')",
                                             BaseSystemInfo.CompanyCode,BaseSystemInfo.CompanyName,BaseSystemInfo.FactoryCode,
                                             BaseSystemInfo.FactoryName,BaseSystemInfo.ProductLineCode,BaseSystemInfo.ProductLineName,
                                             "",code,cnname,enname,BaseSystemInfo.CurrentUserCode);
                DataHelper.Fill(sql);
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("数据表IMOS_PR_QualityItem插入数据失败！"+ex.Message);
            }
        }
        #endregion

        #region 更新数据库
        private void UpdateItem(string icode,string cnname,string enname)
        {
            try
            {
                //修改主列表
                String sql = String.Format(@"Update 
                                                  IMOS_PR_QualityItem_Master 
                                             SET  
                                                  Check_Item_Code = '{0}',
                                                  Check_Item_Name ='{1}',
                                                  Check_Item_Name_EN = '{2}',
                                                  Last_Update_Date = GetDate(),
                                                  Last_Updated_By = '{3}'
                                              Where ID= '{4}' and
                                              Company_Code = '{5}' and
                                              Factory_Code = '{6}' and 
                                              Product_Line_Code = '{7}'
                                             ", icode,cnname,enname,BaseSystemInfo.CurrentUserCode,id,
                                             BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode);
                DataHelper.Fill(sql);
                if (code.Equals(icode))
                {

                }else
                {
                    //修改缺陷列表
                    String str = String.Format(@"Update 
                                                  IMOS_PR_QualityItem_Detail
                                             SET  
                                                  Check_Item_Code = '{0}',
                                                  Modify_Time = GetDate(),
                                                  Modify_By = '{1}'
                                              Where  Check_Item_Code = '{2}'and
                                              Company_Code = '{3}' and
                                              Factory_Code = '{4}' and 
                                              Product_Line_Code = '{5}'", icode, BaseSystemInfo.CurrentUserCode, code,
                                              BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode);
                    DataHelper.Fill(str);
                }
               
            }catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
