using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ticket.Infrastructure.KouDaiLingQian.Core;
using Ticket.Utility.Helpers;

namespace OtaWinFrom
{
    public partial class 支付 : Form
    {
        public 支付()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeviceActivation.Run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = MicroOrder.Run("测试商品", 0.01, textBox2.Text, OrderHelper.GenerateOrderNo());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login.Run();
        }
    }
}
