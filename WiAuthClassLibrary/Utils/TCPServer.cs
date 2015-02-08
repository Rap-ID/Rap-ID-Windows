using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WiAuth.ClassLibrary
{
    public class TCPServer
    {
        private TcpListener tcpServer { get; set; }
        public bool looping { get; private set; }
        public TCPServer(int port)
        {
            this.tcpServer = new TcpListener(IPAddress.Any, port);
            this.tcpServer.Start();
            Loop();
        }

        private async void Loop()
        {
            var tcpClient = await this.tcpServer.AcceptTcpClientAsync();
            if (tcpClient.Connected == true)
            {
                OnConnection.Invoke(new TCPClient(tcpClient));
            }
            if (looping)
            {
                Loop();
            }
        }

        public void Stop()
        {
            this.looping = false;
            this.tcpServer.Stop();
        }

        public delegate void OnConnectionEventHandler(TCPClient client);
        public event OnConnectionEventHandler OnConnection;
    }
}
