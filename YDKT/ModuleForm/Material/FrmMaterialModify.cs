﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Material
{
    using Sys.Config;
    using Sys.DbUtilities;
    using Sys.SysBusiness;

    public partial class FrmMaterialModify : Form
    {
        public string sMID = "";
        public string sMCode = "";
        public string sMName = "";
        public string sTName = "";
        public string sBatch = "";
        public string sDesc = "";

        public string sSpesc = "";
        public string sUnit = "";
        public bool bModify = false;

        //private int sOldMID = 0;

        public FrmMaterialModify()
        {
            InitializeComponent();
        }

        private void FrmMaterialModify_Load(object sender, EventArgs e)
        {
            try

            {
                tbMID.Text = sMCode;
                tbMName.Text = sMName;
                txt_Spesc.Text = sSpesc;
                tbDesc.Text = sDesc;

                //初始化
                ArrayList TypeGroups = new ArrayList();
                string sSQL = string.Format(@"SELECT [Parameter_Detail_Code],[Parameter_Detail_Name] 
                            FROM [Sys_Parameters_Detail] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                            and Parameter_Master_Name = '{3}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, "物料类型");

                DataSet ds = DataHelper.Fill(sSQL);
                if (ds != null)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        TypeGroups.Add(new GroupInfo(dr["Parameter_Detail_Code"].ToString(), dr["Parameter_Detail_Name"].ToString()));
                    }

                    cbbMaterialType.DataSource = TypeGroups;
                    cbbMaterialType.DisplayMember = "Name";
                    cbbMaterialType.ValueMember = "ID";
                }

                ArrayList UnitGroups = new ArrayList();
                string sSQL1 = string.Format(@"SELECT [Parameter_Detail_Code],[Parameter_Detail_Name] 
                            FROM [Sys_Parameters_Detail] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                            and Parameter_Master_Name = '{3}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, "单位");

                DataSet ds1 = DataHelper.Fill(sSQL1);
                if (ds1 != null)
                {
                    foreach (DataRow dr in ds1.Tables[0].Rows)
                    {
                        UnitGroups.Add(new GroupInfo(dr["Parameter_Detail_Code"].ToString(), dr["Parameter_Detail_Name"].ToString()));
                    }

                    com_Unit.DataSource = UnitGroups;
                    com_Unit.DisplayMember = "Name";
                    com_Unit.ValueMember = "ID";
                }

                tbMID.Text = sMCode;
                tbMName.Text = sMName;
                txt_Spesc.Text = sSpesc;
                cbbMaterialType.Text = sTName;
                com_Unit.Text = sUnit;
                tbDesc.Text = sDesc;
            }
            catch (Exception ex)
            {

            }


            // sOldMID = sMCode;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void WndProc(ref Message m)
        {
            //拦截双击标题栏、移动窗体的系统消息  
            if (m.Msg != 0xA3 && m.Msg != 0x0003 && m.WParam != (IntPtr)0xF012)
            {
                base.WndProc(ref m);
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            sMCode = tbMID.Text.Trim();
            sMName = tbMName.Text.Trim();
            sUnit = com_Unit.Text.Trim();
            sDesc = tbDesc.Text.Trim();
            sSpesc = txt_Spesc.Text.Trim();
            //对数据进行检查

            if (sMCode.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编码不可为空");
                return;
            }

            if (sMName.Length == 0)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料名称不可为空");
                return;
            }
            //if (sBatch.Length == 0)
            //{
            //    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "批次不可为空");
            //    return;
            //}

            if (sDesc.Length > 50)
            {
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料描述过长");
                return;
            }
            //新增记录，编号，名称重复检查
            if (bModify == false)
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_TA_Material 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}' and Material_Code = '{3}' or Material_Name = '{4}'",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编号或物料名称重复");
                    return;
                }
            }
            //更新记录 编号，名称重复检查
            else
            {
                string sSQLCheck = string.Format(@"select Material_Code from IMOS_TA_Material 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                                                   and (Material_Code = '{3}' or Material_Name = '{4}') and Material_ID != {5}",
                                                   BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, sMCode, sMName, sMID);
                DataSet ds = DataHelper.Fill(sSQLCheck);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料编号或物料名称重复");
                    return;
                }
            }

            try
            {
                if (bModify == false)//添加类型记录
                {
                    string SqlStr = string.Format(@"INSERT INTO [IMOS_TA_Material]
                                                   ([Material_Code]
                                                    ,[Material_Name]
                                                    ,[Material_Type_Code]
                                                    ,[Material_Type_Name]
                                                    ,[Material_Spec]
                                                    ,[Material_Unit]
                                                    ,[Remark]
                                                    ,[Created_By]
                                                    ,[Creation_Date]
                                                    ,[Last_Updated_By]
                                                    ,[Last_Update_Date],Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name)
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,'{4}'
                                                    ,'{5}','{6}','{7}'
                                                    ,GETDATE(),'{8}'
                                                    ,GETDATE(),'{9}','{10}','{11}','{12}','{13}','{14}')", sMCode, sMName, cbbMaterialType.SelectedValue.ToString(), cbbMaterialType.Text, sSpesc, sUnit,sDesc, BaseSystemInfo.CurrentUserID, BaseSystemInfo.CurrentUserID,
                                                    BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;

                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE [IMOS_TA_Material] 
                                                    SET [Material_Code] = '{0}' ,
                                                    [Material_Name] = '{1}',
                                                    [Material_Type_Code] = '{2}',
                                                    [Material_Type_Name] = '{3}',
                                                    [Material_Spec] = '{4}',
                                                    [Material_Unit] = '{5}',
                                                    [Remark] = '{6}',
                                                    [Last_Updated_By] = '{7}' ,
                                                    [Last_Update_Date] = GETDATE() 
                                                    WHERE Material_ID = '{8}'",
                                                    sMCode, sMName, cbbMaterialType.SelectedValue.ToString(), cbbMaterialType.Text,  sSpesc, sUnit, sDesc, BaseSystemInfo.CurrentUserID, sMID);
                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog("物料数据处理异常！" + ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "物料数据处理异常！.");
            }

        }

        private void tbMID_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class GroupInfo
    {
        private string sGroupName;
        private string sGroupID;

        public GroupInfo(string sCode, string sName)
        {
            this.sGroupID = sCode;
            this.sGroupName = sName;
        }

        public string ID
        {
            get
            {
                return sGroupID;
            }
        }

        public string Name
        {

            get
            {
                return sGroupName;
            }
        }

    }

}


