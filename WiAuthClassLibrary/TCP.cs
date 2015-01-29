using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WiAuth.ClassLibrary
{
    public class TCP : INetworkSender, IDisposable
    {
        private EventDrivenTCPClient tcpClient;
        public TCP(IPAddress ip, int port)
        {
            this.tcpClient = new EventDrivenTCPClient(ip, port);
            this.tcpClient.DataEncoding = Encoding.UTF8;
            this.tcpClient.DataReceived += tcpClient_DataReceived;
            this.tcpClient.ConnectionStatusChanged += tcpClient_ConnectionStatusChanged;
        }

        void tcpClient_ConnectionStatusChanged(EventDrivenTCPClient sender, EventDrivenTCPClient.ConnectionStatus status)
        {
            ConnectionStatusChanged.Invoke(this, status);
        }

        void tcpClient_DataReceived(EventDrivenTCPClient sender, object data)
        {
            OnMessage.Invoke(this, (string)data);
        }
        public TCP(IPEndPoint ipep)
            : this(ipep.Address, ipep.Port)
        {
        }
        public TCP(string ip, int port)
            : this(IPAddress.Parse(ip), port)
        {
        }
        public TCP(IPAddress ip, Network.Ports port)
            : this(ip, (int)port)
        {
        }
        public TCP(string ip, Network.Ports port)
            : this(ip, (int)port)
        {
        }
        public bool Connected
        {
            get
            {
                return this.tcpClient.ConnectionState == EventDrivenTCPClient.ConnectionStatus.Connected;
            }
        }
        public void Connect()
        {
            this.tcpClient.Connect();
        }
        public void Send(string msg)
        {
            this.tcpClient.Send(msg);
        }
        public void Close()
        {
            this.tcpClient.Disconnect();
            this.tcpClient.Dispose();
        }
        public void Dispose()
        {
            this.Close();
        }
        public delegate void OnMessageEventHandler(object sender,string message);
        public event OnMessageEventHandler OnMessage;
        public delegate void ConnectStatusChangedHandler(object sender, EventDrivenTCPClient.ConnectionStatus status);
        public event ConnectStatusChangedHandler ConnectionStatusChanged;
    }
}
