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
    public partial class MaterialManageDialog : Form
    {
        private Main f1;
        public MaterialManageDialog(Main main)
        {
            InitializeComponent();
            f1 = main;
            InitializeData();
        }

        private void InitializeData()
        {
            if (!Common.IsNew)
            {
                MaterialManageBll bll = new MaterialManageBll();
                DataTable dt = bll.GetItemById(Common.Id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblCardNum.Text = Common.Id;
                    txtNumber.Text = dt.Rows[0]["material_num"].ToString();
                    txtName.Text = dt.Rows[0]["material_name"].ToString();
                    txtRemark.Text = dt.Rows[0]["remark"].ToString();
                }
            } 
            else
            {
                lblCardNum.Text = Guid.NewGuid().ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                MessageBox.Show("物料号不能为空");
                return;
            }

            MaterialManageBll bll = new MaterialManageBll();
            int result = bll.CreateMaterial(lblCardNum.Text, txtNumber.Text,txtName.Text, txtRemark.Text);
            if (result > 0)
            {
                this.Hide();
                f1.callBack();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
