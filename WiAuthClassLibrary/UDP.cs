using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WiAuth.ClassLibrary
{
    public class UDP : INetworkListener
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
        private async void Receive()
        {
            var result = await this.udpClient.ReceiveAsync();
            var msg = Encoding.UTF8.GetString(result.Buffer);
            var iep = result.RemoteEndPoint;
            OnMessage.Invoke(this, msg, iep);
            if (listening)
                Receive();
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
        public delegate void OnMessageEventHandler(object sender, string message, IPEndPoint remote);
        public event OnMessageEventHandler OnMessage;
        public void Close()
        {
            this.udpClient.Close();
        }
    }
}
