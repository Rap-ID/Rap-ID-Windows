using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RapID.ClassLibrary;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace RapID.Configure
{
    public partial class Setter : Form
    {
        private Device pi;
        private string key;
        public Setter()
        {
            InitializeComponent();
        }
        public Setter(Device pi)
            : this()
        {
            this.pi = pi;
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            this.passBox.Enabled = false;
            this.statusLabel.Text = "正在等待手机端回应";
            using (var tcpClient = new TcpClient())
            {
                tcpClient.Connect(this.pi.IP, NetworkPorts.Pair);
                using (var tcpStreamWriter = new StreamWriter(tcpClient.GetStream(), Encodes.UTF8NoBOM))
                {
                    await tcpStreamWriter.WriteLineAsync(Encrypt("PAIR" + this.passBox.Text));
                    await tcpStreamWriter.FlushAsync();
                    using (var tcpStreamReader = new StreamReader(tcpClient.GetStream(), Encodes.UTF8NoBOM))
                    {
                        // handle result
                        string result = Decrypt(await tcpStreamReader.ReadLineAsync());
                        if (result == "PAIROK" + this.passBox.Text)
                        {
                            this.statusLabel.Text = "配对成功，正在等待密钥交换！";
                            // handle key
                            this.key = Decrypt(await tcpStreamReader.ReadLineAsync());
                            WriteConfig();
                        }
                        else if (result == "PAIRFAIL" + this.passBox.Text)
                        {
                            this.statusLabel.Text = "配对失败，请检查密钥";
                            this.passBox.Enabled = true;
                        }
                    }
                }
                tcpClient.Close();
            }
        }

        private void WriteConfig()
        {
            var sWriter = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/pair");
            sWriter.WriteLine(Crypt.Encrypt(this.pi.StorgeString));
            sWriter.WriteLine(Crypt.Encrypt(this.passBox.Text));
            sWriter.WriteLine(Crypt.Encrypt(this.key));
            sWriter.Close();
            sWriter.Dispose();
            Application.ExitThread();
        }

        private string Encrypt(string message)
        {
            return Crypt.Encrypt(message, Crypt.GeneratePairKey());
        }

        private string Decrypt(string cipherText)
        {
            return Crypt.Decrypt(cipherText, Crypt.GeneratePairKey());
        }
    }
}
