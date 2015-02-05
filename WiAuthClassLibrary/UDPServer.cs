using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WiAuth.ClassLibrary
{
    public class UDPServer : INetworkListener
    {
        /// <summary>
        /// 底层UDP
        /// </summary>
        private UdpClient udpClient { get; set; }
        /// <summary>
        /// 监听的范围
        /// </summary>
        private IPEndPoint objIEP;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="port">端口</param>
        public UDPServer(int port)
        {
            this.objIEP = new IPEndPoint(IPAddress.Any, port);
            this.udpClient = new UdpClient(this.objIEP);
        }
        /// <summary>
        /// 表示监听状态
        /// </summary>
        public bool listening { get; private set; }
        /// <summary>
        /// 接收消息
        /// </summary>
        private async void Receive()
        {
            var result = await this.udpClient.ReceiveAsync();
            var msg = Encodes.UTF8NoBOM.GetString(result.Buffer);
            var iep = result.RemoteEndPoint;
            OnMessage.Invoke(this, msg, iep);
            if (listening)
                Receive();
        }
        /// <summary>
        /// 开始监听
        /// </summary>
        public void StartListen()
        {
            this.listening = true;
            this.Receive();
        }
        /// <summary>
        /// 停止监听
        /// </summary>
        public void StopListen()
        {
            this.listening = false;
        }
        /// <summary>
        /// 消息事件处理程序委托
        /// </summary>
        /// <param name="sender">事件触发者</param>
        /// <param name="message">消息</param>
        /// <param name="remote">远程IP和端口</param>
        public delegate void OnMessageEventHandler(object sender, string message, IPEndPoint remote);
        /// <summary>
        /// 消息事件
        /// </summary>
        public event OnMessageEventHandler OnMessage;
        /// <summary>
        /// 关闭服务端
        /// </summary>
        public void Close()
        {
            this.udpClient.Close();
        }
    }
}
