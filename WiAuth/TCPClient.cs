using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WiAuth.ClassLibrary;

namespace WiAuth.Debug
{
    public partial class TCPClient : Form
    {
        private TCP tcpClient;
        public TCPClient()
        {
            InitializeComponent();
        }

        void tcpClient_OnMessage(object sender, string message)
        {
            MessageBox.Show("Msg recevied of \"" + message + "\"");
            this.tcpClient.OnMessage += tcpClient_OnMessage;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            this.tcpClient = new TCP(this.ipBox.Text, Network.Ports.Pair);
            this.tcpClient.OnMessage+=tcpClient_OnMessage;
            this.tcpClient.Connect();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            this.tcpClient.Send(this.msgBox.Text);
        }
    }
}
