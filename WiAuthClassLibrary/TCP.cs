using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WiAuth.ClassLibrary
{
    public class TCP : INetworkSender
    {
        private TcpClient tcpClient { get; set; }
        private IPEndPoint remote { get; set; }
        private NetworkStream stream
        {
            get
            {
                return this.tcpClient.GetStream();
            }
        }
        private StreamReader reader;
        private StreamWriter writer;
        public bool listening { get; private set; }
        public bool Connected
        {
            get
            {
                return this.tcpClient.Connected;
            }
        }
        public TCP(IPEndPoint remote)
        {
            this.remote = remote;
            this.tcpClient = new TcpClient();
        }
        public TCP(IPAddress IP, int Port)
            : this(new IPEndPoint(IP, Port))
        {
        }
        public TCP(string IP, int Port)
            : this(new IPEndPoint(IPAddress.Parse(IP), Port))
        {
        }
        public void Connect()
        {
            this.tcpClient.Connect(this.remote.Address, this.remote.Port);
            this.reader = new StreamReader(this.stream, Encoding.UTF8);
            this.writer = new StreamWriter(this.stream, Encoding.UTF8);
            this.listening = true;
            Read();
        }
        public async void Send(string msg)
        {
            await this.writer.WriteLineAsync(msg);
        }
        public void SendSync(string msg)
        {
            this.writer.WriteLine(msg);
        }
        public delegate void OnMessageEventHandler(object sender, string message);
        public event OnMessageEventHandler OnMessage;
        private async void Read()
        {
            while (listening)
            {
                var msg = await this.reader.ReadLineAsync();
                if (msg != String.Empty)
                {
                    OnMessage.Invoke(this, msg);
                }
            }
        }
        public void Close()
        {
            this.listening = false;
            this.tcpClient.Close();
        }
    }
}
