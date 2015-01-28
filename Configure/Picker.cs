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
            this.udpClient = new UDP(Network.Ports.Boradcast);
            this.udpClient.OnMessage += udpClient_OnMessage;
            this.udpClient.StartListen();
        }

        void udpClient_OnMessage(object sender, OnMessageEventArgs args)
        {
            const string BROADCAST = "ACTIVE";
            if (args.message == BROADCAST)
            {
                if (this.uidListBox.Items.IndexOf(args.iep.Address.ToString()) >= 0)
                {
                }
                else
                {
                    //this.Invoke(this.addListDelegate, new Object[] { args.iep.Address.ToString() });
                    //TODO: unique check
                    this.piList.Add(new PickerItem("test", "testMAC", args.iep.Address.ToString()));
                }
            }
            else
            {
            }
        }
        /*#region AddToList
        private delegate void DAddToList(string text);
        private DAddToList addListDelegate;
        private void p_AddToList(string text)
        {
            this.uidListBox.Items.Add(text);
        }
        #endregion*/
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
