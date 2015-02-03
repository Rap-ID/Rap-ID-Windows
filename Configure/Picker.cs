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
        private UDP udpClient;
        private List<PickerItem> piList = new List<PickerItem>();
        public Picker()
        {
            InitializeComponent();
            this.udpClient = new UDP(NetworkPorts.Boradcast);
            this.udpClient.OnMessage += udpClient_OnMessage;
            this.udpClient.StartListen();
        }

        void udpClient_OnMessage(object sender, string message, System.Net.IPEndPoint remote)
        {
            var item = new PickerItem(message, remote.Address);
            if (this.uidListBox.Items.IndexOf(item.ToString()) < 0)
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
            foreach (PickerItem i in this.piList)
            {
                this.uidListBox.Items.Add(i.ToString());
            }
        }
    }
}
