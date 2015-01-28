using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WiAuth.ClassLibrary
{
    public class UDP : INetworkListener, IDisposable
    {
        private UdpClient udpClient { get; set; }
        private IPEndPoint objIEP;
        private bool disposed { get; set; }
        public UDP(int port)
        {
            this.objIEP = new IPEndPoint(IPAddress.Any, port);
            this.udpClient = new UdpClient(this.objIEP);
        }
        public UDP(Network.Ports port)
            : this((int)port)
        {
        }
        public bool listening { get; set; }
        private void Receive()
        {
            this.udpClient.BeginReceive(new AsyncCallback(ReceiveCallback), null);
        }
        private void ReceiveCallback(IAsyncResult res)
        {
            if (this.disposed)
            {
                return;
            }
            var msg = this.udpClient.EndReceive(res, ref this.objIEP);
            OnMessage(this, new OnMessageEventArgs(Encoding.UTF8.GetString(msg), this.objIEP));
            if (this.listening)
            {
                this.objIEP.Address = IPAddress.Any;
                this.objIEP.Port = (int)Network.Ports.Boradcast;
                this.Receive();
            }
        }
        public void StartListen()
        {
            this.listening = true;
            this.Receive();
        }
        public void StopListen()
        {
            this.listening = false;
        }
        public event OnMessageEventArgs.OnMessageEventHandler OnMessage;
        public void Dispose()
        {
            if (!this.disposed)
            {
                this.udpClient.Close();
                this.disposed = true;
            }
        }
        ~UDP()
        {
            this.Dispose();
        }
    }
}
