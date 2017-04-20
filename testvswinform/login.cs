using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using testvswinform.Model;
using testvswinform.Bll;
using testvswinform.View;

namespace testvswinform
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private Point mPoint = new Point();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userBll _userbll = new userBll();
            userBean _userbean=new userBean();
            _userbean = null;
            _userbean=_userbll.GetLoginBllProc(this.txtName.Text.ToString(), this.txtPwd.Text.ToString());
            //userBean _userbean1 = new userBean();
            //_userbean1 = _userbll.(this.txtName.Text.ToString(), this.txtPwd.Text.ToString());
            if( _userbean != null )
            {
                //MessageBox.Show("登录成功！" + this.txtPwd.Text.ToString(), "提示");
                new Main().Show();
                this.Hide();
                Common.Id = _userbean.UId;
                Common.UserName = this.txtName.Text.ToString();
                
            }else
            {
                MessageBox.Show("登录失败！" + this.txtPwd.Text.ToString(), "提示");
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtName.Text = string.Empty;
            this.txtPwd.Text = string.Empty;
     
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void login_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            } 
        }


    }
}
/**
 
 
 warduserBll _wuBll = new warduserBll();
        List<warduserBean> _wuserList = _wuBll.GetAllUsersBll();
        foreach (warduserBean _wbBean in _wuserList)
        {
            this.lnameLst.Items.Add(_wbBean.WName.ToString());
            //(_wbBean.WName.ToString()) ;
            //_wbBean.WId.ToString());
        }//Response.Write("<scirpt>alert('" + ex.Message.ToString() + "')</script>");
 
 protected void btn_login_Click(object sender, EventArgs e)
    {
        if (this.tpassagain.Text == Session["image"].ToString())
        {
            //Convert.ToInt32()强制转换成整型
            string Lname = this.lnameLst.SelectedItem.Value.Trim().ToString();
            string Lpass = this.lpass.Text.Trim().ToString();
            //FormsAuthentication.HashPasswordForStoringInConfigFile(this.lpass.Text.Trim().ToString(),"MD5");
            warduserBll _LuserBll=new warduserBll();
            warduserBean _LuserBean = _LuserBll.GetLoginBll(Lname, Lpass);
            if (_LuserBean == null)
            {
                lpass.Text = "";
                tpassagain.Text = "";
                Response.Write("<script>alert('密码错误！')</script>");
            }
            else
            {
                Session["LoginName"] = _LuserBean.WName.ToString();
                Session["LoginPwd"] = _LuserBean.WPwd.ToString();
                Session["LoginID"] = _LuserBean.WId.ToString();
                Session["LoginQx"] = _LuserBean.WQx;
                //依据【LoginQx】查找角色名称
                wardroleBean _wdroleBean = new wardroleBean();
                wardroleBll _wroleBll = new wardroleBll();
                _wdroleBean = _wroleBll.GetRolebyIDBll(_LuserBean.WQx);
                Session["LoginQxName"] = _wdroleBean.RoleName;
                Session["LoginIP"] = Request.UserHostAddress;
                //增加系统日志
                //mylog.UserID = _LuserBean.WName.ToString(); 
                //mylog.LogTime = DateTime.Now;
                //mylog.LogContent = "登陆系统 IP：" + Request.UserHostAddress;
                //mylog.Add();
                //----
                //Response.Write("<script>alert('" + Session["LoginQxName"].ToString() + "')</script>");
                //Response.End();
                Response.Redirect("MainHome.aspx");
            }
        }
        else
        {
            tpassagain.Text = "";
            //tpassagain.Text.Remove(0);
            Response.Write("<script>alert('验证码错误！')</script>");
        }
    }
 **/