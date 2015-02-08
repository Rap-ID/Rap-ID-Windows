using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiAuth.ClassLibrary;

namespace WiAuth.Configure
{
    public partial class Picker : Form
    {
        private UDPServer udpClient;
        private List<Device> piList = new List<Device>();
        public Picker()
        {
            InitializeComponent();
            this.udpClient = new UDPServer(NetworkPorts.Boradcast);
            this.udpClient.OnMessage += udpClient_OnMessage;
            this.udpClient.StartListen();
        }

        void udpClient_OnMessage(object sender, string message, System.Net.IPEndPoint remote)
        {
            var item = new Device(message, remote.Address);
            if (!this.piList.Contains(item))
            {
                this.piList.Add(item);
            }
        }
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void pairButton_Click(object sender, EventArgs e)
        {
            var id = this.uidListBox.SelectedIndex;
            var pi = this.piList[id];
            var frm = new Setter(pi);
            frm.ShowDialog();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.uidListBox.Items.Clear();
            foreach (Device i in this.piList)
            {
                this.uidListBox.Items.Add(i.ToString());
            }
            this.piList.Clear();
        }
    }
}
