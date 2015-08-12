using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RapID.ClassLibrary;
using MaterialSkin;
using MaterialSkin.Controls;

namespace RapID.Configure
{
    public partial class Picker : MaterialForm
    {
        private UDPServer udpClient;
        private List<Device> piList = new List<Device>();
        public Picker()
        {
            InitializeComponent();
            this.udpClient = new UDPServer(NetworkPorts.Boradcast);
            this.udpClient.OnMessage += udpClient_OnMessage;
            this.udpClient.StartListen();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.Green900, Primary.Green500, Accent.Green200, TextShade.WHITE);
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
