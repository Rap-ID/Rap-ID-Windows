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
        const string pair_prefix = "PAIR";
        const string pairok_prefix = "PAIROK";
        const string pairfail_prefix = "PAIRFAIL";
        private TCP tcpClient;
        public TCPClient()
        {
            InitializeComponent();
            this.upsbd = UPSBHandler;
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

        private void pairButton_Click(object sender, EventArgs e)
        {
            this.tcpClient = new TCP(this.ipBox.Text, Network.Ports.Pair);
            this.tcpClient.OnMessage += tcpClient_OnMessage2;
            this.tcpClient.Connect();
            this.pairStateBox.Text = "wait for server";
            this.passBox.Enabled = false;
            while (this.tcpClient.etcp.ConnectionState != EventDrivenTCPClient.ConnectionStatus.Connected)
            {
            }
            this.tcpClient.Send(pair_prefix + this.passBox.Text);
        }

        void tcpClient_OnMessage2(object sender, string message)
        {
            MessageBox.Show(message);
            if (message.StartsWith(pairok_prefix))
            {
                var pass = message.Replace(pairok_prefix, "");
                if ( pass == this.passBox.Text)
                {
                    this.Invoke(upsbd, new Object[] { "pair okay" });
                }
            }
            else if(message.StartsWith(pairfail_prefix))
            {
                var pass = message.Replace(pairfail_prefix, "");
                if (pass == this.passBox.Text)
                {
                    this.Invoke(upsbd, new Object[] { "pair fail" });
                }
            }
        }
        private delegate void UpdatePairStateBox(string text);
        private UpdatePairStateBox upsbd;
        void UPSBHandler(string text)
        {
            this.pairStateBox.Text = text;
        }
    }
}
