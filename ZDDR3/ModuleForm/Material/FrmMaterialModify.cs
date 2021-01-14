using System;
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
        public string sDesc = "";

        public string sP_Voltage = "";
        public string sP_Capacity = "";
        public string sP_Frequency = "";
        public string sP_Temperature = "";
        public string sP_Water = "";
        public string sP_3D = "";
        public string sP_Waterproof = "";
        public string sP_Internal = "";
        public string sP_Pic_Path = "";

        public bool bModify = false;

        //private int sOldMID = 0;

        public FrmMaterialModify()
        {
            InitializeComponent();
        }

        private void FrmMaterialModify_Load(object sender, EventArgs e)
        {
            //初始化
            ArrayList Groups = new ArrayList();

            string sSQL = @"SELECT [Type_Code],[Type_Name] FROM [Mixing_MaterialType]";

            DataSet ds = DataHelper.Fill(sSQL);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Groups.Add(new GroupInfo(dr["Type_Name"].ToString(), dr["Type_Code"].ToString()));
                }
            }

            cbbMaterialType.DataSource = Groups;
            cbbMaterialType.DisplayMember = "Name";
            cbbMaterialType.ValueMember = "ID";

            tbMID.Text = sMCode;
            tbMName.Text = sMName;
            cbbMaterialType.Text = sTName;
            tbDesc.Text = sDesc;

            txtP_Voltage.Text = sP_Voltage;
            txtP_Capacity.Text = sP_Capacity;
            txtP_Frequency.Text = sP_Frequency;
            txtP_Temperature.Text = sP_Temperature;
            txtP_Water.Text = sP_Water;
            txtP_3D.Text = sP_3D;
            txtP_Waterproof.Text = sP_Waterproof;
            txtP_Internal.Text = sP_Internal;
            txtPic_Path.Text = sP_Pic_Path;

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
           // sBatch = tbBatch.Text.Trim();
            sDesc = tbDesc.Text.Trim();

            sP_Voltage= txtP_Voltage.Text.Trim();
            sP_Capacity= txtP_Capacity.Text ;
            sP_Frequency= txtP_Frequency.Text;
            sP_Temperature= txtP_Temperature.Text;
            sP_Water= txtP_Water.Text;
            sP_3D= txtP_3D.Text;
            sP_Waterproof= txtP_Waterproof.Text;
            sP_Internal= txtP_Internal.Text;
            sP_Pic_Path = txtPic_Path.Text;

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
                string sSQLCheck = string.Format(@"select Material_Code from Mixing_Material 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and ProductLine_Code = '{2}' and Material_Code = '{3}' or Material_Name = '{4}'",
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
                string sSQLCheck = string.Format(@"select Material_Code from Mixing_Material 
                                                   where Company_Code = '{0}' and Factory_Code = '{1}' and ProductLine_Code = '{2}'
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
                    string SqlStr = string.Format(@"INSERT INTO [Mixing_Material]
                                                   ([Material_Code]
                                                    ,[Material_Name]
                                                    ,[Type_Code]
                                                    ,[Batch_No]
                                                    ,[Material_Desc]
                                                    ,[Modify_User]
                                                    ,[Modify_Time],Company_Code, Company_Name, Factory_Code, Factory_Name, ProductLine_Code, ProductLine_Name,
                                                    ,[P_Voltage]
                                                    ,[P_Capacity]
                                                    ,[P_Frequency]
                                                    ,[P_Temperature]
                                                    ,[P_Water]
                                                    ,[P_3D]
                                                    ,[P_Waterproof]
                                                    ,[P_Internal]
                                                    ,[Pic_Path])
                                                    VALUES
                                                    ('{0}'
                                                    ,'{1}'
                                                    ,'{2}'
                                                    ,'{3}'
                                                    ,'{4}'
                                                    ,'{5}'
                                                    ,GETDATE(),'{6}','{7}','{8}','{9}','{10}','{11}',
                                                    '{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}')", sMCode, sMName, cbbMaterialType.SelectedValue.ToString(), "", sDesc, BaseSystemInfo.CurrentUserName,
                                                    BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName, BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName, BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                    sP_Voltage, sP_Capacity, sP_Frequency, sP_Temperature, sP_Water, sP_3D, sP_Waterproof, sP_Internal, sP_Pic_Path);

                    DataHelper.Fill(SqlStr);
                    DialogResult = DialogResult.OK;


                }
                else//修改类型记录
                {
                    string SqlStr = string.Format(@"UPDATE [Mixing_Material] 
                                                    SET [Material_Code] = '{0}' ,
                                                    [Material_Name] = '{1}',
                                                    [Type_Code] = '{2}',
                                                    [Batch_No] = '{3}',
                                                    [Material_Desc] = '{4}',
                                                    [Modify_User] = '{5}' ,
                                                    [Modify_Time] = GETDATE()
                                                    ,[P_Voltage]='{6}'
                                                    ,[P_Capacity]='{7}'
                                                    ,[P_Frequency]='{8}'
                                                    ,[P_Temperature]='{9}'
                                                    ,[P_Water]='{10}'
                                                    ,[P_3D]='{11}'
                                                    ,[P_Waterproof]='{12}'
                                                    ,[P_Internal]='{13}'
                                                    ,[Pic_Path]='{14}'
                                                    WHERE Material_ID = '{15}'",
                                                    sMCode, sMName, cbbMaterialType.SelectedValue.ToString(), "", sDesc, BaseSystemInfo.CurrentUserName,
                                                    sP_Voltage, sP_Capacity, sP_Frequency, sP_Temperature, sP_Water, sP_3D, sP_Waterproof, sP_Internal,sP_Pic_Path
                                                    , sMID);
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

        public GroupInfo(string sName, string sID)
        {
            this.sGroupID = sID;
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


