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

namespace testvswinform.View
{
    public partial class SystemSetting : Form
    {
        SystemSettingBll bll = new SystemSettingBll();
        public SystemSetting()
        {
            InitializeComponent();
            DataTable dt = bll.GetAll();
            if (dt.Rows.Count > 0)
            {
                txtParameter.Text = dt.Rows[0]["parameter"].ToString();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           int result = bll.Create(txtParameter.Text.Trim());
           if (result > 0)
           {
               MessageBox.Show("设置成功");
               this.Hide();
           }
        }


    }
}
