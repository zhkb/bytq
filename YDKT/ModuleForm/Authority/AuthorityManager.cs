using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Authority
{
    using Sys.DbUtilities;
    using Sys.Config;

    #region  权限结构体
    public struct AuthorityInfo
    {
        public int ID;  //权限ID
        public int UserID;  //ID用户
        public string ModuleCode;  //模块ID
        public string ModuleName;  //模块名称
        public bool UseFlag;  //使用
        public bool AddFlag;  //增加
        public bool EditFlag;  //修改
        public bool DeleteFlag;  //删除
        public bool SaveFlag;   //保存
        public bool ExportFlag;  //导出
        public bool ImportFlag;  //导入    
    }

    #endregion


    public class AuthorityManager
    {
        //更新权限数据
        public static bool UpdateAuthority(AuthorityInfo FAuthorityInfo)
        {
            try
            {
                //更新计划状态
                String SqlStr = string.Format(@"Update Sys_BaseUserAuthority  
                                               Set Use_Flag = {0},Add_Flag = {1},Edit_Flag = {2},Delete_Flag = {3},Save_Flag = {4},Export_Flag = {5},Import_Flag = {6}
                                               Where ID = '{7}' and Company_Code = '{8}' and Factory_Code = '{9}' and Product_Line_Code = '{10}'",
                                               Convert.ToInt32(FAuthorityInfo.UseFlag), Convert.ToInt32(FAuthorityInfo.AddFlag), Convert.ToInt32(FAuthorityInfo.EditFlag), Convert.ToInt32(FAuthorityInfo.DeleteFlag),
                                               Convert.ToInt32(FAuthorityInfo.SaveFlag), Convert.ToInt32(FAuthorityInfo.ExportFlag), Convert.ToInt32(FAuthorityInfo.ImportFlag), FAuthorityInfo.ID,
                                               BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode);

                DataHelper.Fill(SqlStr);

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }

        //取得权限数据
        public static AuthorityInfo GetAuthority(string UserID, string MenuID)
        {
            AuthorityInfo FAuthorityInfo = new AuthorityInfo();

            try
            {
                DataSet DBDataSet = new DataSet();
              
                String SqlStr = string.Format(@"Select ID,User_ID,Module_Code,Module_Name,Use_Flag,Add_Flag,Edit_Flag,Delete_Flag,Save_Flag,Export_Flag,Import_Flag
                                                From Sys_BaseUserAuthority
                                                Where User_ID = '{0}' and Module_Code = '{1}'
                                                and Company_Code = '{2}' and Factory_Code = '{3}' and Product_Line_Code = '{4}'", 
                                                UserID, MenuID,BaseSystemInfo.CompanyCode,BaseSystemInfo.FactoryCode,BaseSystemInfo.ProductLineCode);

                DBDataSet = DataHelper.Fill(SqlStr);

                if (DBDataSet.Tables[0].Rows.Count > 0)
                {
                    FAuthorityInfo.ID = int.Parse(DBDataSet.Tables[0].Rows[0]["ID"].ToString());
                    FAuthorityInfo.UserID = int.Parse(DBDataSet.Tables[0].Rows[0]["User_ID"].ToString());
                    FAuthorityInfo.ModuleCode = DBDataSet.Tables[0].Rows[0]["Module_Code"].ToString();
                    FAuthorityInfo.ModuleName = DBDataSet.Tables[0].Rows[0]["Module_Name"].ToString();
                    FAuthorityInfo.UseFlag = DBDataSet.Tables[0].Rows[0]["Use_Flag"].ToString() == "1";
                    FAuthorityInfo.AddFlag = DBDataSet.Tables[0].Rows[0]["Add_Flag"].ToString() == "1";
                    FAuthorityInfo.EditFlag = DBDataSet.Tables[0].Rows[0]["Edit_Flag"].ToString() == "1";
                    FAuthorityInfo.DeleteFlag = DBDataSet.Tables[0].Rows[0]["Delete_Flag"].ToString() == "1";
                    FAuthorityInfo.SaveFlag = DBDataSet.Tables[0].Rows[0]["Save_Flag"].ToString() == "1";
                    FAuthorityInfo.ExportFlag = DBDataSet.Tables[0].Rows[0]["Export_Flag"].ToString() == "1";
                    FAuthorityInfo.ImportFlag = DBDataSet.Tables[0].Rows[0]["Import_Flag"].ToString() == "1";
                }
                else
                {
                    FAuthorityInfo.ID = 0;
                    FAuthorityInfo.UserID = 0;
                    FAuthorityInfo.ModuleCode = "";
                    FAuthorityInfo.ModuleName = "";
                    FAuthorityInfo.UseFlag = false;
                    FAuthorityInfo.AddFlag = false;
                    FAuthorityInfo.EditFlag = false;
                    FAuthorityInfo.DeleteFlag = false;
                    FAuthorityInfo.SaveFlag = false;
                    FAuthorityInfo.ExportFlag = false;
                    FAuthorityInfo.ImportFlag = false;
                }


            }
            catch
            {

            }
            finally
            {

            }

            return FAuthorityInfo;
        }

    }
}
