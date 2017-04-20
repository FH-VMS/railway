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
    public partial class TunnelManageDialog : Form
    {
        private Main f1;
        public TunnelManageDialog(Main main)
        {
            InitializeComponent();
            f1 = main;
            InitializeData();
        }

        private void InitializeData()
        {
            TunnelManageBll bll = new TunnelManageBll();
            cmbMachine.DataSource = bll.GetMachines();
            cmbMachine.DisplayMember = "machine_name";
            cmbMachine.ValueMember = "id";

            cmbMaterial.DataSource = bll.GetMaterials();
            cmbMaterial.DisplayMember = "material_name";
            cmbMaterial.ValueMember = "material_num";
            if (!Common.IsNew)
            {
                
                DataTable dt = bll.GetItemById(Common.Id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbMachine.SelectedValue = dt.Rows[0]["machine_num"].ToString();
                    txtNumber.Text = dt.Rows[0]["tunnel_num"].ToString();
                    txtMaxStock.Value = int.Parse(dt.Rows[0]["tunnel_max_stock"].ToString());
                    txtAlertStock.Value = int.Parse(dt.Rows[0]["min_stock_alert"].ToString());
                    txtCurStock.Value = int.Parse(dt.Rows[0]["cur_stock"].ToString());
                    cmbMaterial.SelectedValue = dt.Rows[0]["material_num"].ToString();
                }
            }
            else
            {
                Common.Id = Guid.NewGuid().ToString();
            }

            
        }

        private void txtMaxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
               
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbMachine.SelectedValue.ToString()))
            {
                MessageBox.Show("机器必选");
                return;
            }

            if (string.IsNullOrEmpty(txtNumber.Text))
            {
                MessageBox.Show("货道号必填");
                return;
            }

            TunnelManageBll bll = new TunnelManageBll();
            int result = bll.CreateTunnel(Common.Id, cmbMachine.SelectedValue.ToString(), txtNumber.Text, int.Parse(txtMaxStock.Value.ToString()),int.Parse(txtAlertStock.Value.ToString()),int.Parse(txtCurStock.Value.ToString()),cmbMaterial.SelectedValue.ToString());
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
