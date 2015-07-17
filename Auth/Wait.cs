using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RapID.ClassLibrary;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace RapID.Auth
{
    public partial class Wait : Form
    {
        private string _callback;
        private string _app;
        public Wait(string callback, string app)
        {
            InitializeComponent();
            this._callback = callback;
            this._app = app;
        }

        public void SetInfoText(string text)
        {
            this.OverThread = () =>
            {
                this.infoLabel.Text = text;
                this.Refresh();
            };
            this.Invoke(this.OverThread);
        }

        public delegate void DOverThread();
        public DOverThread OverThread;

        private void cancelButton_Click(object sender, EventArgs e)
        {
            okButton.Enabled = false;
            cancelButton.Enabled = false;
            Application.Exit();
        }

        private void Wait_Load(object sender, EventArgs e)
        {
            this.infoLabel.Text = "应用" + this._app + "正在发起鉴权请求。";
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            okButton.Enabled = false;
            cancelButton.Enabled = false;

            const string auth_prefix = "AUTH";
            const string authok_prefix = "AUTHOK";
            const string authfail_prefix = "AUTHFAIL";

            this.SetInfoText("正在读取配置文件...");

            string cryptionKey, pairKey;
            Device device;
            using (var sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "pair"))
            {
                var name = Crypt.Decrypt(sr.ReadLine());
                pairKey = Crypt.Decrypt(sr.ReadLine());
                cryptionKey = Crypt.Decrypt(sr.ReadLine());
                device = await WaitForIP(name);
            }
            this.SetInfoText("配置文件成功读取，正在建立连接...");
            using (var tcpClient = new TcpClient())
            {
                tcpClient.Connect(device.IP, NetworkPorts.Auth);
                this.SetInfoText("连接已建立，正在发送消息...");

                using (var tcpStreamWriter = new StreamWriter(tcpClient.GetStream()))
                {
                    await tcpStreamWriter.WriteLineAsync(Crypt.Encrypt(auth_prefix + pairKey, Crypt.GenerateKey(cryptionKey)));
                    await tcpStreamWriter.FlushAsync();
                    this.SetInfoText("消息发送成功，正在等待手机端回应...");

                    using (var tcpStreamReader = new StreamReader(tcpClient.GetStream()))
                    {
                        var message = Crypt.Decrypt(await tcpStreamReader.ReadLineAsync(), Crypt.GenerateKey(cryptionKey));
#if DEBUG
                        MessageBox.Show(message);
#endif
                        if (message.StartsWith(authok_prefix))
                        {
                            this.SetInfoText("授权成功！");
                            System.Threading.Thread.Sleep(1000);
                            if (_callback != String.Empty)
                            {
                                System.Diagnostics.Process.Start(_callback + message.Replace(authok_prefix, String.Empty));
                            }
                        }
                        else if (message.StartsWith(authfail_prefix))
                        {
                            this.SetInfoText("授权失败！");
                            System.Threading.Thread.Sleep(1000);
                        }
                    }

                }
            }
            Application.Exit();
        }

        private async Task<Device> WaitForIP(string name)
        {
            IPAddress ip = IPAddress.Any;
            using (var udp = new UdpClient(new IPEndPoint(IPAddress.Any, NetworkPorts.Boradcast)))
            {
                string message = String.Empty;
                while (message != name)
                {
                    var result = await udp.ReceiveAsync();
                    message = Encodes.UTF8NoBOM.GetString(result.Buffer);
                    ip = result.RemoteEndPoint.Address;
                }
            }
            return new Device(name, ip);
        }
    }
}
