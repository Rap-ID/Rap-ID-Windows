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
        private IPEndPoint iep { get; set; }
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
        public TCP(IPEndPoint iep)
        {
            this.iep = iep;
            this.reader = new StreamReader(this.stream, Encoding.UTF8);
            this.writer = new StreamWriter(this.stream, Encoding.UTF8);
        }
        public TCP(IPAddress ip, int port)
            : this(new IPEndPoint(ip, port))
        {
        }
        public TCP(string ip, int port)
            : this(new IPEndPoint(IPAddress.Parse(ip), port))
        {
        }
        public async void Connect()
        {
            await this.tcpClient.ConnectAsync(this.iep.Address, this.iep.Port);
        }
        public async void Send(string msg)
        {
            await this.writer.WriteLineAsync(msg);
        }
        public delegate void OnMessageEventHandler(object sender, string message);
        public event OnMessageEventHandler OnMessage;
        private async void Read()
        {
            var msg = await this.reader.ReadLineAsync();
            if (msg != String.Empty)
            {
                OnMessage.Invoke(this, msg);
            }
            if (listening)
            {
                Read();
            }
        }
        public void Close()
        {
            this.listening = false;
            this.tcpClient.Close();
        }
    }
}
