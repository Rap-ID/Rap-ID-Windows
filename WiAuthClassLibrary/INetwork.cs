namespace WiAuth.ClassLibrary
{
    public interface INetworkListener
    {
        bool listening { get; }
        void StartListen();
        void StopListen();
        event OnMessageEventArgs.OnMessageEventHandler OnMessage;
    }
    public interface INetworkSender
    {
        bool Connected { get; }
        void Connect();
        void Send(string msg);
        void Close();
        event OnMessageEventArgs.OnMessageEventHandler OnMessage;
    }
}
