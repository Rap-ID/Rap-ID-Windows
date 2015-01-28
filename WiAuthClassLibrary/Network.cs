using System.Net;

namespace WiAuth.ClassLibrary
{
    public class Network
    {
        public enum Ports
        {
            Boradcast = 49160,
            Pair = 49161,
            Auth = 49161
        }
    }
    public class OnMessageEventArgs
    {
        public OnMessageEventArgs(string msg, IPEndPoint ipe)
        {
            this.message = msg;
            this.iep = ipe;
        }
        public string message { get; set; }
        public IPEndPoint iep { get; set; }
        public delegate void OnMessageEventHandler(object sender, OnMessageEventArgs args);
    }
}
