using DocomSDK.Ticket.Data;
using FengjingSDK461.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtaWinFrom
{
    public partial class 闸机模拟器 : Form
    {
        public 闸机模拟器()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(CheckTicket)
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void CheckTicket()
        {
            CheckTicket_Object obj = new CheckTicket_Object
            {
                SensorSource = "number30",
                Number = "2145215236",
                Device = new DeviceStatus
                {
                    DeviceName = "dd3f2a00-5ecb-4a76-8388-8eba15c62471",
                    Startup = DateTime.Now
                }
            };

            var result = 闸机类.Post(obj, "Ticket_CheckTicket").Result;



            textBox2.Text = JsonHelper.ObjectToJson(result);
        }
    }
}
