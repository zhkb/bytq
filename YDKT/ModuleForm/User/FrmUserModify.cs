using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.IO;
using System.Drawing.Imaging;

namespace User
{
    using Sys.SysBusiness;
    using Sys.DbUtilities;
    using System.Collections;
    using Sys.Config;

    public partial class FrmUserModify : Form
    {
        public string uloginname = "";
        public string ucname = "";
        public string upassword = "";
        public string udeptname = "";
        public string utelno = "";
        public string umail = "";
        public string uremark = "";
        public string userid = "";
        public string uloginImage = "";

        public bool ModifyState = true; //新增 true 编辑  false
        public string InitialPwd = "123";

        private bool InitializePass = false; //是否重置密码
        public FrmUserModify()
        {
            InitializeComponent();
        }

        private void FrmUserModify_Load(object sender, EventArgs e)//加载
        {
            ArrayList TypeGroups = new ArrayList();
            string sSQL = string.Format(@"SELECT [Parameter_Detail_Code],[Parameter_Detail_Name] 
                            FROM [Sys_Parameters_Detail] 
                            Where Company_Code = '{0}' and Factory_Code = '{1}' and Product_Line_Code = '{2}'
                            and Parameter_Master_Name = '{3}'", BaseSystemInfo.CompanyCode, BaseSystemInfo.FactoryCode, BaseSystemInfo.ProductLineCode, "部门");

            DataSet ds = DataHelper.Fill(sSQL);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TypeGroups.Add(new GroupInfo(dr["Parameter_Detail_Code"].ToString(), dr["Parameter_Detail_Name"].ToString()));
                }

                cbbDept.DataSource = TypeGroups;
                cbbDept.DisplayMember = "Name";
                cbbDept.ValueMember = "ID";
            }

            if (!ModifyState) //编辑状态显示信息
            {
                txt_uloginname.Text = uloginname;
                txt_ucname.Text = ucname;
                cbbDept.Text = udeptname;
                txt_utelno.Text = utelno;
                txt_umail.Text = umail;
                txt_uremark.Text = uremark;

                txt_upassword.Enabled = false;
                txt_ConfirmPwd.Enabled = false;

                // 直接返Base64码转成数组
                try
                {
                    if (uloginImage != "")
                    {
                        byte[] imageBytes = Convert.FromBase64String(uloginImage);
                        this.pic_ResultFace.Image = ArrayToPic(imageBytes);

                    }
                }
                catch
                {
                    SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "加载图片异常.");
                }
            }
            else
            {
                btn_InitialPwd.Visible = false;
            }
        }



        private void btn_InitialPwd_Click(object sender, EventArgs e)//初始化密码
        {
            if (SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogYesNoMessage, string.Format("是否确认重置密码？", uloginname)) == DialogResult.No)
            {
                return;
            }

            InitializePass = true;

            txt_upassword.Enabled = true;
            txt_ConfirmPwd.Enabled = true;

            txt_upassword.Text = "123";
            txt_ConfirmPwd.Text = "123";
        }


        private byte[] PicToArray(PictureBox sourceImage)
        {
            Bitmap bm = new Bitmap(sourceImage.Image);
            MemoryStream ms = new MemoryStream();
            bm.Save(ms, ImageFormat.Jpeg);
            return ms.GetBuffer();
        }

        private Image ArrayToPic(byte[] imageBytes)
        {

            // 读入MemoryStream对象
            MemoryStream memoryStream = new MemoryStream(imageBytes, 0, imageBytes.Length);
            memoryStream.Write(imageBytes, 0, imageBytes.Length);
            // 转成图片
            Image image = Image.FromStream(memoryStream);

            //memoryStream.Close(); //不要加上这一句否则就不对了

            // 将图片放置在 PictureBox 中
            //  this.pictureBox1.SizeMode = PictureBoxSizeMode.;
            return image;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                uloginname = txt_uloginname.Text;
                ucname = txt_ucname.Text;
                utelno = txt_utelno.Text;
                umail = txt_umail.Text;
                uremark = txt_uremark.Text;

                if (ModifyState)//新增
                {
                    if (uloginname == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录名不能为空.");
                        txt_uloginname.Focus();
                        return;
                    }
                    if (ucname == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "姓名不能为空.");
                        txt_ucname.Focus();
                        return;
                    }
                    if (txt_upassword.Text == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "密码不能为空.");
                        txt_upassword.Focus();
                        return;
                    }
                    if (txt_ConfirmPwd.Text == "")
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请再次输入密码.");
                        txt_ConfirmPwd.Focus();
                        return;
                    }
                    if (txt_upassword.Text != txt_ConfirmPwd.Text)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "两次输入的密码不一致，请重新输入.");
                        txt_upassword.Clear();
                        txt_ConfirmPwd.Clear();
                        txt_upassword.Focus();
                        return;
                    }

                    DataSet DBDataSet = new DataSet();
                    string SelectSql = string.Format(@"select * from Sys_BaseUser 
                                                       where User_Code = '{0}'", uloginname);
                    DBDataSet = DataHelper.Fill(SelectSql);
                    if (DBDataSet.Tables[0].Rows.Count > 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录名不能重复.");
                        txt_uloginname.Clear();
                        txt_uloginname.Focus();
                        return;
                    }
                    else//添加新用户
                    {
                        try
                        {
                            string imgSourse = "";
                            if (pic_ResultFace.Image != null) {
                                byte[] arr = PicToArray(pic_ResultFace);
                                 imgSourse = Convert.ToBase64String(arr);
                            }
                            //存储人脸图片
                       


                            upassword = SysBusinessFunction.MD5(txt_upassword.Text);

                            string SqlStr = string.Format(@"INSERT INTO dbo.Sys_BaseUser (Company_Code, Company_Name, Factory_Code, Factory_Name, Product_Line_Code, Product_Line_Name, User_Code, User_Name, User_PassWord, Dept_Code, Dept_Name, User_TelNo, User_EMail, Remark, Creation_Date, Created_By, Last_Update_Date, Last_Updated_By,User_Image)
	                                                            VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', GETDATE(), {14}, GETDATE(), {14}, '{15}')",
                                                            BaseSystemInfo.CompanyCode, BaseSystemInfo.CompanyName,
                                                            BaseSystemInfo.FactoryCode, BaseSystemInfo.FactoryName,
                                                            BaseSystemInfo.ProductLineCode, BaseSystemInfo.ProductLineName,
                                                            uloginname, ucname, upassword, cbbDept.SelectedValue.ToString(), cbbDept.Text,
                                                            utelno, umail, uremark, BaseSystemInfo.CurrentUserID, imgSourse);
                            DataHelper.Fill(SqlStr);
                            SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "增加新用户成功.");
                        }
                        catch (Exception ex)
                        {
                            SysBusinessFunction.WriteLog(ex.ToString());
                        }
                    }
                }
                else//修改
                {
                    DataSet DBDataSet = new DataSet();
                    string SelectSql = string.Format(@"select * from Sys_BaseUser 
                                                       where User_Code = '{0}'and User_ID <>'{1}'", uloginname, userid);
                    DBDataSet = DataHelper.Fill(SelectSql);
                    if (DBDataSet.Tables[0].Rows.Count > 0)
                    {
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "登录名不能重复.");
                        txt_uloginname.Clear();
                        txt_uloginname.Focus();
                        return;
                    }
                    else
                    {
                        //存储人脸图片
                        string imgSourse = "";
                        if (pic_ResultFace.Image != null)
                        {
                            byte[] arr = PicToArray(pic_ResultFace);
                            imgSourse = Convert.ToBase64String(arr);
                        }
                        if (InitializePass)
                        {
                            if (txt_upassword.Text == "")
                            {
                                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "密码不能为空.");
                                txt_upassword.Focus();
                                return;
                            }



                            if (txt_ConfirmPwd.Text == "")
                            {
                                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "请再次输入密码.");
                                txt_ConfirmPwd.Focus();
                                return;
                            }


                            if (txt_upassword.Text != txt_ConfirmPwd.Text)
                            {
                                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "两次输入的密码不一致，请重新输入.");
                                txt_upassword.Clear();
                                txt_ConfirmPwd.Clear();
                                txt_upassword.Focus();
                                return;
                            }
                            string NewPassword = "";
                            NewPassword = SysBusinessFunction.MD5(txt_upassword.Text);

                            string SqlStr = string.Format(@"UPDATE dbo.Sys_BaseUser 
	                                                        SET User_Code = '{0}', User_Name = '{1}', User_PassWord = '{2}', 
	                                                        Dept_Code = '{3}', Dept_Name = '{4}', User_TelNo = '{5}', 
	                                                        User_EMail = '{6}', Remark = '{7}', Last_Update_Date = GETDATE(), Last_Updated_By = {8},User_Image='{9}'
                                                        WHERE User_ID = {10}", uloginname, ucname, NewPassword,
                                                            cbbDept.SelectedValue.ToString(), cbbDept.Text, utelno,
                                                            umail, uremark, BaseSystemInfo.CurrentUserID, imgSourse, userid);
                            DataHelper.Fill(SqlStr);
                        }
                        else
                        {
                            string SqlStr = string.Format(@"UPDATE dbo.Sys_BaseUser 
	                                                        SET User_Code = '{0}', User_Name = '{1}', 
	                                                        Dept_Code = '{2}', Dept_Name = '{3}', User_TelNo = '{4}', 
	                                                        User_EMail = '{5}', Remark = '{6}', Last_Update_Date = GETDATE(), Last_Updated_By = {7},User_Image='{8}'
                                                        WHERE User_ID = {9}", uloginname, ucname,
                                                            cbbDept.SelectedValue.ToString(), cbbDept.Text, utelno,
                                                            umail, uremark, BaseSystemInfo.CurrentUserID, imgSourse, userid);
                            DataHelper.Fill(SqlStr);
                        }
                        SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "修改用户信息成功.");
                    }
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                SysBusinessFunction.WriteLog(ex.Message);
                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "用户信息存储失败，注意用户ID不能重复.");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "jpg|*.jpg|jpeg|*.jpeg";
                fileDialog.FileName = string.Empty;
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.pic_ResultFace.Image = Image.FromFile(fileDialog.FileName);
                }
            }
            catch
            {

                SysBusinessFunction.SystemDialog(SysBusinessFunction.DialogOKMessage, "图片异常，请重新选择图像.");
            }


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
