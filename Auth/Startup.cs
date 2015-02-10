using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiAuth.ClassLibrary;

namespace WiAuth.AuthUI
{
    public partial class Startup : Form
    {
        private string callback = String.Empty;
        Device device;
        string key;
        Waiting waitFrm = new Waiting();

        public Startup()
        {
            InitializeComponent();
        }

        public Startup(string callback)
            : this()
        {
            this.callback = callback;
        }

        private void Startup_Load(object sender, EventArgs e)
        {
            waitFrm.Show();
            new Task(() =>
            {
                const string auth_prefix = "AUTH";

                waitFrm.SetInfoText("正在读取配置文件...");

                using (var sr = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "pair"))
                {
                    var ss = sr.ReadLine();
#if DEBUG
                    device = new Device("name", System.Net.IPAddress.Parse("127.0.0.1"));
#else
                    device = new Device(ss);
#endif
                    key = sr.ReadLine();
                }
                waitFrm.SetInfoText("配置文件成功读取，正在建立连接...");

                var tcpClient = new TCPClient(device.IP, NetworkPorts.Auth);
                tcpClient.OnMessage += tcpClient_OnMessage;
                tcpClient.Connect();
                waitFrm.SetInfoText("连接已建立，正在发送消息...");

                tcpClient.Send(auth_prefix + key);
                waitFrm.SetInfoText("消息发送成功，正在等待手机端回应...");
            }).Start();
            new Task(() =>
            {
                this.OverThread = () =>
                {
                    this.Hide();
                };
                this.Invoke(OverThread);
            }).Start();
        }
        public delegate void DOverThread();
        public DOverThread OverThread;

        void tcpClient_OnMessage(object sender, string message)
        {
            const string authok_prefix = "AUTHOK";
            const string authfail_prefix = "AUTHFAIL";

#if DEBUG
            MessageBox.Show(message);
#endif

            if (message.StartsWith(authok_prefix))
            {
                waitFrm.SetInfoText("授权成功！");
                System.Threading.Thread.Sleep(1000);
                if (callback != String.Empty)
                {
                    this.OverThread = () =>
                    {
                        System.Diagnostics.Process.Start(this.DecodeUrlString(callback) + message.Replace(authok_prefix, String.Empty));
                        this.Close();
                    };
                    this.Invoke(OverThread);
                }
            }
            else if (message.StartsWith(authfail_prefix))
            {
                waitFrm.SetInfoText("授权失败！");
                System.Threading.Thread.Sleep(1000);
                this.OverThread = () =>
                {
                    this.Close();
                };
                this.Invoke(OverThread);
            }
        }

        private void Startup_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private string DecodeUrlString(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }
    }
}
