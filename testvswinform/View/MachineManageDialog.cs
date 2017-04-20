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
    public partial class MachineManageDialog : Form
    {
       private Main f1;
       public MachineManageDialog(Main main)
        {
            InitializeComponent();
            f1 = main;
            InitializeData();
        }


       private void InitializeData()
       {
           if (!Common.IsNew)
           {
               MachineManageBll bll = new MachineManageBll();
               DataTable dt = bll.GetItemById(Common.Id);
               if (dt != null && dt.Rows.Count > 0)
               {
                   txtMachineNum.Text = Common.Id;
                   txtName.Text = dt.Rows[0]["machine_type"].ToString();
                   txtRemark.Text = dt.Rows[0]["remark"].ToString();
                   txtMachineName.Text = dt.Rows[0]["machine_name"].ToString();
               }
           }
           else
           {
               txtMachineNum.Text ="";
           }
       }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMachineNum.Text))
            {
                MessageBox.Show("机器编号不能为空");
                return;
            }

            MachineManageBll bll = new MachineManageBll();
            int result = bll.CreateMachine(txtMachineNum.Text, txtName.Text, txtRemark.Text, txtMachineName.Text);
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
