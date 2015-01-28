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
    internal class UidItem
    {
        public UidItem()
        {
        }
    }
    public partial class Picker : Form
    {
        private UDP udpClient;
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
                    this.Invoke(this.addListDelegate, new Object[] { args.iep.Address.ToString() });
                }
            }
            else
            {
            }
        }
        #region AddToList
        private delegate void DAddToList(string text);
        private DAddToList addListDelegate;
        private void p_AddToList(string text)
        {
            this.uidListBox.Items.Add(text);
        }
        #endregion
        private void exitMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pairButton_Click(object sender, EventArgs e)
        {

        }
    }
}
