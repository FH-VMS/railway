using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testvswinform.Bll;
using testvswinform.Model;

namespace testvswinform.View
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            txtUserName.Text = Common.UserName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblUserName.Text))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(txtOriginPwd.Text))
            {
                MessageBox.Show("原密码不能为空");
                return;
            }

            if (string.IsNullOrEmpty(txtNewPwd.Text))
            {
                MessageBox.Show("新密码不能为空");
                return;
            }

            if (string.IsNullOrEmpty(txtConfirmPwd.Text))
            {
                MessageBox.Show("确认密码不能为空");
                return;
            }

            if(txtNewPwd.Text!=txtConfirmPwd.Text){
                MessageBox.Show("两次密码不一致");
                return;
            }

            userBll _userbll = new userBll();
            userBean _userbean = new userBean();
            _userbean = null;
            _userbean = _userbll.GetLoginBllProc(Common.UserName, txtOriginPwd.Text.ToString());
            //userBean _userbean1 = new userBean();
            //_userbean1 = _userbll.(this.txtName.Text.ToString(), this.txtPwd.Text.ToString());
            if (_userbean == null)
            {
                //MessageBox.Show("登录成功！" + this.txtPwd.Text.ToString(), "提示");
                MessageBox.Show("原密码不正确");
                return;

            }

            int result = _userbll.UpdateUser(Common.Id, txtUserName.Text.Trim(), txtNewPwd.Text.Trim());
            if (result > 0)
            {
                this.Hide();
                MessageBox.Show("更新成功");
            }


        }
    }
}
