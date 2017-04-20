using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testvswinform.Bll;
using testvswinform.Model;
using testvswinform.Utility;

namespace testvswinform.View
{
    public partial class Create : Form
    {
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdbeep", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern byte pcdbeep(Int32 xms); //设备发出声音

        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccrequest")]
        private static extern byte piccrequest(byte[] serial); //寻卡并返回该卡的序列号

        private Main f1;  
        public Create(Main main)
        {
            InitializeComponent();
            f1 = main;
            InitializeData();
        }

        private void InitializeData()
        {
            if (!Common.IsNew)
            {
                PeopleManageBll bll = new PeopleManageBll();
                DataTable dt = bll.GetItemById(Common.Id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtCardNum.Text = Common.Id;
                    txtName.Text = dt.Rows[0]["name"].ToString();
                    txtTeam.Text = dt.Rows[0]["team"].ToString();
                    txtRemark.Text = dt.Rows[0]["remark"].ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCardNum.Text))
            {
                MessageBox.Show("卡号不能为空");
                return;
            }
           
            PeopleManageBll bll = new PeopleManageBll();
            int result = bll.CreatePeople(txtCardNum.Text, txtName.Text, txtTeam.Text, txtRemark.Text);
            if (result > 0)
            {
                this.Hide();
                f1.callBack();
            }

            
           
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //pcdbeep(50);
            byte[] serial = new byte[4];
            byte result = piccrequest(serial);
            if (result == 29)
            {
                MessageBox.Show("串口读取失败");
            }
            else if (result == 8)
            {
                MessageBox.Show("无卡在感应区");
            }
            else if (result == 9)
            {
                MessageBox.Show("多张卡在感应区");
            }

            if (result == 0)
            {
                txtCardNum.Text = UtilityOperator.ByteToHexStr(serial);
            }
        }
    }
}
