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

namespace testvswinform.View
{
    public partial class TestCard : Form
    {
        [DllImport("OUR_MIFARE.dll", EntryPoint = "pcdbeep",CharSet=CharSet.Auto,CallingConvention=CallingConvention.StdCall)]
        private static extern byte pcdbeep(Int32 xms); //设备发出声音

        [DllImport("OUR_MIFARE.dll", EntryPoint = "piccrequest")]
        private static extern byte piccrequest(byte[] serial); //寻卡并返回该卡的序列号
        public TestCard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pcdbeep(50);
            byte[] serial = new byte[4];
            byte result = piccrequest(serial);
        }
    }
}
