namespace WiAuth.ClassLibrary
{
    public interface INetworkListener
    {
        bool listening { get; }
        void StartListen();
        void StopListen();
    }
    public interface INetworkSender
    {
        bool Connected { get; }
        void Connect();
        void Send(string msg);
        void Close();
    }
}
