namespace WiAuth.ClassLibrary
{
    public interface INetworkListener
    {
        bool listening { get; }
        void StartListen();
        void StopListen();
        event OnMessageEventArgs.OnMessageEventHandler OnMessage;
    }
}
