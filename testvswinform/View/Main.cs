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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
           
        }

        private Dictionary<String, ToolStripItem> pList = new Dictionary<String, ToolStripItem>();
      

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            ((ToolStripLabel)this.pager.Items["pageIndex"]).Text = "1";
            pList = new Dictionary<String, ToolStripItem>();
            Common.NowMobule = e.Node.Name.ToLower();
            switch (Common.NowMobule)
            {
                case "peoplemanage":
                    ToolStripTextBox txt = new ToolStripTextBox();
                    txt.Name = "peopleName";
                    pList.Add("名称:", txt);
                    generateSearchCondition();
                    break;
                case "machinemanage":
                    generateSearchCondition();
                    break;
                case "materialmanage":
                     ToolStripTextBox txt1 = new ToolStripTextBox();
                     txt1.Name = "material_num";
                     pList.Add("物料号:", txt1);
                     ToolStripTextBox txt2 = new ToolStripTextBox();
                     txt2.Name = "material_name";
                     pList.Add("物料名称:", txt2);
                     generateSearchCondition();
                    break;
                case "tunnelmanage":
                    ToolStripTextBox txtMachine = new ToolStripTextBox();
                    txtMachine.Name = "machine_num";
                    pList.Add("机器编号:", txtMachine);
                    generateSearchCondition();
                    break;
                case "materialrecord":
                    ToolStripTextBox txtCardNum = new ToolStripTextBox();
                    txtCardNum.Name = "card_num";
                    pList.Add("领料人(姓名或卡号):", txtCardNum);
                     ToolStripTextBox txtMaterialNum = new ToolStripTextBox();
                     txtMaterialNum.Name = "material_num";
                     pList.Add("物料(名称或编号):", txtMaterialNum);
                   this.tools.Items.Clear();
                    foreach(var item in pList)
                    {
                        ToolStripLabel lbl = new ToolStripLabel();
                        lbl.Text = item.Key;
                        this.tools.Items.Add(lbl);
                        this.tools.Items.Add(item.Value);
                    }
                    AddDTPtoToolstrip(5);
                    if(pList.Count>0 )
                    {
                        ToolStripButton btnSearch = new ToolStripButton();
                        btnSearch.Name = "btnSearch";
                        btnSearch.Text = "搜索";
                
                        btnSearch.Click += new EventHandler(this.btnSearch_Click);
                        this.tools.Items.Add(btnSearch);
                    }
                    break;
            }
           
            bindPager();
            bindData();
        }

        

        private void generateSearchCondition()
        {
            this.tools.Items.Clear();
            foreach(var item in pList)
            {
                ToolStripLabel lbl = new ToolStripLabel();
                lbl.Text = item.Key;
                this.tools.Items.Add(lbl);
                this.tools.Items.Add(item.Value);
            }
            if(pList.Count>0 )
            {
                ToolStripButton btnSearch = new ToolStripButton();
                btnSearch.Name = "btnSearch";
                btnSearch.Text = "搜索";
                
                btnSearch.Click += new EventHandler(this.btnSearch_Click);
                this.tools.Items.Add(btnSearch);
            }
           

            ToolStripButton btnCreate = new ToolStripButton();
            btnCreate.Name = "btnCreate";
            btnCreate.Text = "创建";
            btnCreate.Click += new EventHandler(this.btnCreate_Click);
            this.tools.Items.Add(btnCreate);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ((ToolStripLabel)this.pager.Items["pageIndex"]).Text = "1";
            bindPager();
            bindData();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Common.IsNew = true;
            switch (Common.NowMobule)
            {
                case "peoplemanage":
                    Create create1 = new Create(this);
                    create1.ShowDialog();
                    break;
                case "machinemanage":
                    MachineManageDialog machineManageDialog = new MachineManageDialog(this);
                    machineManageDialog.ShowDialog();
                    break;
                case "materialmanage":
                    MaterialManageDialog materialManageDialog = new MaterialManageDialog(this);
                    materialManageDialog.ShowDialog();
                    break;
                case "tunnelmanage":
                    TunnelManageDialog tunnelManageDialog = new TunnelManageDialog(this);
                    tunnelManageDialog.ShowDialog();
                    break;
            }
        }

        //数据绑定
        private void bindData()
        {
            gv.Columns.Clear();
            DataTable dt = new DataTable();
            switch (Common.NowMobule)
            {
                case "peoplemanage":
                    PeopleManageBll bll = new PeopleManageBll();
                    dt = bll.GetAll(((ToolStripTextBox)this.tools.Items["peopleName"]).Text, Convert.ToInt32(((ToolStripLabel)this.pager.Items["pageIndex"]).Text), Convert.ToInt32(((ToolStripComboBox)this.pager.Items["pageSize"]).SelectedItem));
                    break;
                case "machinemanage":
                    MachineManageBll machineBll = new MachineManageBll();
                    dt = machineBll.GetAll(Convert.ToInt32(((ToolStripLabel)this.pager.Items["pageIndex"]).Text), Convert.ToInt32(((ToolStripComboBox)this.pager.Items["pageSize"]).SelectedItem));
                    break;
                case "materialmanage":
                    MaterialManageBll materialBll = new MaterialManageBll();
                    dt = materialBll.GetAll(((ToolStripTextBox)this.tools.Items["material_num"]).Text, ((ToolStripTextBox)this.tools.Items["material_name"]).Text, Convert.ToInt32(((ToolStripLabel)this.pager.Items["pageIndex"]).Text), Convert.ToInt32(((ToolStripComboBox)this.pager.Items["pageSize"]).SelectedItem));
                    break;
                case "tunnelmanage":
                    TunnelManageBll tunnelBll = new TunnelManageBll();
                    dt = tunnelBll.GetAll(((ToolStripTextBox)this.tools.Items["machine_num"]).Text, Convert.ToInt32(((ToolStripLabel)this.pager.Items["pageIndex"]).Text), Convert.ToInt32(((ToolStripComboBox)this.pager.Items["pageSize"]).SelectedItem));
                    break;
                case "materialrecord":
                    MaterialRecordBll materialRecordBll = new MaterialRecordBll();
                    dt = materialRecordBll.GetAll(((ToolStripTextBox)this.tools.Items["card_num"]).Text, ((ToolStripTextBox)this.tools.Items["material_num"]).Text, Convert.ToDateTime(this.tools.Items[5].Text), Convert.ToInt32(((ToolStripLabel)this.pager.Items["pageIndex"]).Text), Convert.ToInt32(((ToolStripComboBox)this.pager.Items["pageSize"]).SelectedItem));
                    break;
            }

            gv.DataSource = dt;
            gvGenerate();
        }

        //分布绑定
       private void bindPager()
       {
             int count = 0;
             switch (Common.NowMobule)
            {
                case "peoplemanage":
                    PeopleManageBll bll = new PeopleManageBll();
                    count = bll.GetTotalCount(((ToolStripTextBox)this.tools.Items["peopleName"]).Text);
                    break;
                case "machinemanage":
                    MachineManageBll machineBll = new MachineManageBll();
                    count = machineBll.GetTotalCount();
                   break;
                case "materialmanage":
                   MaterialManageBll materialBll = new MaterialManageBll();
                   count = materialBll.GetTotalCount(((ToolStripTextBox)this.tools.Items["material_num"]).Text, ((ToolStripTextBox)this.tools.Items["material_name"]).Text);
                   break;
                case "tunnelmanage":
                   TunnelManageBll tunnelBll = new TunnelManageBll();
                   count = tunnelBll.GetTotalCount(((ToolStripTextBox)this.tools.Items["machine_num"]).Text);
                   break;
                case "materialrecord":
                   MaterialRecordBll materialRecordBll = new MaterialRecordBll();
                   count = materialRecordBll.GetTotalCount(((ToolStripTextBox)this.tools.Items["card_num"]).Text, ((ToolStripTextBox)this.tools.Items["material_num"]).Text, Convert.ToDateTime(this.tools.Items[5].Text));
                   break;
            }


             ((ToolStripLabel)this.pager.Items["totalCount"]).Text = count.ToString();
             int nowPageSize = Convert.ToInt32(((ToolStripComboBox)this.pager.Items["pageSize"]).SelectedItem);
             int totalPage = 0;
             if (count % nowPageSize == 0)
             {
                 totalPage = count/nowPageSize;
             }
             else
             {
                 totalPage = (int)Math.Ceiling((double)count/nowPageSize);
             }

             ((ToolStripLabel)this.pager.Items["totalPage"]).Text = totalPage.ToString();
           
       }

        //gridview中文头
        private void gvGenerate()
       {

           switch (Common.NowMobule)
            {
                case "peoplemanage":
                    gv.Columns["card_num"].HeaderText = "卡号";
                    gv.Columns["name"].HeaderText = "名称";
                    gv.Columns["team"].HeaderText = "所在组";
                    gv.Columns["remark"].HeaderText = "备注";
                    editAndDelete();
                   break;
                case "machinemanage":
                   gv.Columns["id"].HeaderText = "机器编号";
                   gv.Columns["machine_type"].HeaderText = "机器类型";
                   gv.Columns["remark"].HeaderText = "描述";
                   gv.Columns["machine_name"].HeaderText = "机器名称";
                   editAndDelete();
                   break;
                case "materialmanage":
                   gv.Columns["serial_num"].HeaderText = "流水号";
                   gv.Columns["material_num"].HeaderText = "物料编号";
                   gv.Columns["material_name"].HeaderText = "物料名称";
                   gv.Columns["remark"].HeaderText = "描述";
                   editAndDelete();
                   break;
                case "tunnelmanage":
                   gv.Columns["id"].HeaderText = "流水号";
                   gv.Columns["id"].Visible = false;
                   gv.Columns["machine_num"].HeaderText = "机器编号";
                   gv.Columns["tunnel_num"].HeaderText = "货道编号";
                   gv.Columns["tunnel_max_stock"].HeaderText = "货道最大库存";
                   gv.Columns["min_stock_alert"].HeaderText = "报警库存数";
                   gv.Columns["cur_stock"].HeaderText = "当前库存";
                   gv.Columns["material_num"].HeaderText = "物料编号";
                   editAndDelete();
                   break;
                case "materialrecord":
                   gv.Columns["serial_num"].HeaderText = "流水号";
                   gv.Columns["card_num"].HeaderText = "卡号";
                   gv.Columns["name"].HeaderText = "领料人";
                   gv.Columns["material_num"].HeaderText = "物料编号";
                   gv.Columns["material_name"].HeaderText = "物料名称";
                   gv.Columns["sum"].HeaderText = "领料数量";
                   gv.Columns["machine_num"].HeaderText = "机器编号";
                   gv.Columns["tunnel_num"].HeaderText = "货道号";
                   gv.Columns["time"].HeaderText = "领料时间";
                   break;
            }

            
            
       }

        private void editAndDelete()
        {
            DataGridViewLinkColumn dbtEdit = new DataGridViewLinkColumn();
            dbtEdit.Text = "编辑";//添加的这列的显示文字，即每行最后一列显示的文字。
            dbtEdit.Name = "btnEdit";
            dbtEdit.HeaderText = "编辑";//列的标题
            dbtEdit.UseColumnTextForLinkValue = true;//上面设置的dlink.Text文字在列中显示
            dbtEdit.Width = 66;
            gv.Columns.Add(dbtEdit);
            gv.Columns["btnEdit"].Width = 150;

            DataGridViewLinkColumn btnDelete = new DataGridViewLinkColumn();
            btnDelete.Text = "删除";//添加的这列的显示文字，即每行最后一列显示的文字。
            btnDelete.Name = "btnDelete";
            btnDelete.HeaderText = "删除";//列的标题
            btnDelete.UseColumnTextForLinkValue = true;//上面设置的dlink.Text文字在列中显示
            btnDelete.Width = 66;
            gv.Columns.Add(btnDelete);
            gv.Columns["btnDelete"].Width = 150;
        }

        private void gv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gv.Columns[e.ColumnIndex].Name == "btnEdit")
 	        {
                Common.IsNew = false;
               
                switch (Common.NowMobule)
                {
                    case "peoplemanage":
                        Common.Id = gv.Rows[e.RowIndex].Cells["card_num"].Value.ToString();
                        Create create1 = new Create(this);
                        create1.ShowDialog();
                        break;
                    case "machinemanage":
                        Common.Id = gv.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        MachineManageDialog machineManageDialog = new MachineManageDialog(this);
                        machineManageDialog.ShowDialog();
                        break;
                    case "materialmanage":
                        Common.Id = gv.Rows[e.RowIndex].Cells["serial_num"].Value.ToString();
                        MaterialManageDialog materialManageDialog = new MaterialManageDialog(this);
                        materialManageDialog.ShowDialog();
                        break;
                    case "tunnelmanage":
                        Common.Id = gv.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        TunnelManageDialog tunnelManageDialog = new TunnelManageDialog(this);
                        tunnelManageDialog.ShowDialog();
                        break;
                }
 	        }
            else if (gv.Columns[e.ColumnIndex].Name == "btnDelete")
            {
               DialogResult result =
               MessageBox.Show(
                       "确实要删除吗？",
                       "确认",
                       MessageBoxButtons.OKCancel,
                       MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //确认处理
                    switch (Common.NowMobule)
                    {
                        case "peoplemanage":
                            new PeopleManageBll().DeletePeople(gv.Rows[e.RowIndex].Cells["card_num"].Value.ToString());
                            break;
                        case "machinemanage":
                            new MachineManageBll().DeleteMachine(gv.Rows[e.RowIndex].Cells["id"].Value.ToString());
                            break;
                        case "materialmanage":
                            new MaterialManageBll().DeleteMaterial(gv.Rows[e.RowIndex].Cells["serial_num"].Value.ToString());
                            break;
                        case "tunnelmanage":
                            new TunnelManageBll().DeleteTunnel(gv.Rows[e.RowIndex].Cells["id"].Value.ToString());
                            break;
                    }
                    callBack();
                }
            }

           
        }

        //给其他窗体的回调函数委托
       public  void callBack() //回调函数
        {
            bindPager();
            bindData();
        }

        //首页
       private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
       {
           ((ToolStripLabel)this.pager.Items["pageIndex"]).Text = "1";
           bindPager();
           bindData();
       }

        //尾页
       private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
       {
           ((ToolStripLabel)this.pager.Items["pageIndex"]).Text = ((ToolStripLabel)this.pager.Items["totalPage"]).Text;
           bindPager();
           bindData();
       }

       //上一页
       private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
       {
           int pageIndex = Convert.ToInt32(((ToolStripLabel)this.pager.Items["pageIndex"]).Text);
           if (pageIndex > 1)
           {
               ((ToolStripLabel)this.pager.Items["pageIndex"]).Text = (pageIndex - 1).ToString();
           }
           bindPager();
           bindData();
       }

        //下一页
       private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
       {
           int pageIndex = Convert.ToInt32(((ToolStripLabel)this.pager.Items["pageIndex"]).Text);
           int totalPage = Convert.ToInt32(((ToolStripLabel)this.pager.Items["totalPage"]).Text);
           if (pageIndex < totalPage)
           {
               ((ToolStripLabel)this.pager.Items["pageIndex"]).Text = (pageIndex + 1).ToString();
           }
           bindPager();
           bindData();
       }

       private void pageSize_TextChanged(object sender, EventArgs e)
       {
           bindPager();
           bindData();

       }

       private void gv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
       {
           switch (Common.NowMobule)
           {
               case "tunnelmanage":
                   int alertStock = Convert.ToInt32(gv.Rows[e.RowIndex].Cells["min_stock_alert"].Value);
                   int curStock = Convert.ToInt32(gv.Rows[e.RowIndex].Cells["cur_stock"].Value);
                   if(curStock<=alertStock)
                   {
                       gv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                   }
                   break;
           }
           
       }

       //密码修改
       private void btnUser_Click(object sender, EventArgs e)
       {
           User user = new User();
           user.ShowDialog();
       }

       private void btnOff_Click(object sender, EventArgs e)
       {
           this.Hide();
           login lgn = new login();
           lgn.Show();
       }

       private void btnSetting_Click(object sender, EventArgs e)
       {
           SystemSetting ss = new SystemSetting();
           ss.ShowDialog();
       }


        //向toolstrip里添加日期选择器
       private void AddDTPtoToolstrip(int n)
       {
           ToolStripLabel lbl = new ToolStripLabel();
           lbl.Text = "日期:";
           this.tools.Items.Add(lbl);

           DateTimePicker dtp = new DateTimePicker();
           dtp.Width = 110;
           dtp.Format = DateTimePickerFormat.Custom;
           dtp.Name = "time";
           ToolStripControlHost host1 = new ToolStripControlHost(dtp);
           tools.Items.Insert(n, host1);
       }

    

        


       
    }
}
