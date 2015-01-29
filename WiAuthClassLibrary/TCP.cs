using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WiAuth.ClassLibrary
{
    public class TCP : INetworkSender
    {
        private TcpClient tcpClient { get; set; }
        private bool disposed { get; set; }
        private NetworkStream tnStream
        {
            get
            {
                return this.tcpClient.GetStream();
            }
        }
        private IPEndPoint objIEP;
        public bool Connected
        {
            get
            {
                return this.tcpClient.Connected;
            }
        }
        public TCP(IPEndPoint iep)
        {
            this.objIEP = iep;
            this.tcpClient = new TcpClient(this.objIEP);
        }
        public TCP(IPAddress IP, int port)
            : this(new IPEndPoint(IP, port))
        {
        }
        public TCP(string IP, int port)
            : this(IPAddress.Parse(IP), port)
        {
        }
        public TCP(string IP, Network.Ports port)
            : this(IP, (int)port)
        {
        }
        public TCP(IPAddress IP, Network.Ports port)
            : this(IP, (int)port)
        {
        }
        public void Connect()
        {
            this.tcpClient.Connect(this.objIEP);
            this.Receive();
        }
        public void Send(string msg)
        {
            var bmsg = Encoding.UTF8.GetBytes(msg);
            this.tnStream.Write(bmsg, 0, bmsg.Length);
        }
        public event OnMessageEventArgs.OnMessageEventHandler OnMessage;
        public void Close()
        {
            this.tcpClient.Close();
            this.disposed = true;
        }
        private void Receive()
        {
            var bmsg = new Byte[50];
            this.tnStream.BeginRead(bmsg,0,bmsg.Length,new AsyncCallback(Receive), null);
            OnMessage(this, new OnMessageEventArgs(Encoding.UTF8.GetString(bmsg), this.objIEP));
        }
        private void Receive(IAsyncResult ar)
        {
            this.Receive();
        }
    }
}
