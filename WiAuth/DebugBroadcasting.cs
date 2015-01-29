using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using WiAuth.ClassLibrary;

namespace WiAuth.Debug
{
    public partial class DebugBroadcasting : Form
    {
        private UDP receiver;
        const string BROADCAST = "ACTIVE";
        public DebugBroadcasting()
        {
            InitializeComponent();
            this.receiver = new UDP(Network.Ports.Boradcast);
            this.receiver.OnMessage += receiver_OnMessage;
            this.addListDelegate = AddList;
        }

        void receiver_OnMessage(object sender, OnMessageEventArgs args)
        {
            if (args.message == BROADCAST)
            {
                if (this.ipListBox.Items.IndexOf(args.iep.Address.ToString()) >= 0)
                {
#if DEBUG
                    MessageBox.Show(args.iep.Address.ToString());
#endif
                }
                else
                {
                    this.Invoke(this.addListDelegate, new Object[] { args.iep.Address.ToString() });
                }
            }
            else
            {
#if DEBUG
                MessageBox.Show(args.message);
#endif
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.receiver.StartListen();
            this.startButton.Enabled = false;
            this.stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.receiver.StopListen();
            this.startButton.Enabled = true;
            this.stopButton.Enabled = false;
        }
        private delegate void DAddList(string str);
        private DAddList addListDelegate;
        private void AddList(string str)
        {
            this.ipListBox.Items.Add(str);
        }
    }
}
