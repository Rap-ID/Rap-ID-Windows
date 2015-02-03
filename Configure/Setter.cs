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
    public partial class Setter : Form
    {
        private PickerItem pi;
        public Setter()
        {
            InitializeComponent();
        }
        public Setter(PickerItem pi)
            : this()
        {
            this.pi = pi;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            CheckPair();
        }

        private void WriteConfig()
        {
            var sWriter = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/pair");
            sWriter.WriteLine(this.pi.Identifier);
            sWriter.Write(this.passBox.Text);
            sWriter.Close();
            sWriter.Dispose();
            Application.ExitThread();
        }

        private void CheckPair()
        {
            this.passBox.Enabled = false;
            this.statusLabel.Text = "正在等待手机端回应";
            var tcpClient = new TCP(this.pi.IPAddress, NetworkPorts.Pair);
            tcpClient.OnMessage += tcpClient_OnMessage;
            tcpClient.Connect();
            tcpClient.Send("PAIR" + this.passBox.Text);
        }

        void tcpClient_OnMessage(object sender, string message)
        {
            if (message == "PAIROK" + this.passBox.Text)
            {
                this.statusLabel.Text = "配对成功！";
                WriteConfig();
            }
            else if (message == "PAIRFAIL" + this.passBox.Text)
            {
                this.statusLabel.Text = "配对失败，请检查密钥";
                this.passBox.Enabled = true;
            }
        }
    }
}
