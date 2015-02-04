using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace WiAuth.ClassLibrary
{
    public class Pipe
    {
        private NamedPipeServerStream pipe { get; set; }
        public bool listening { get; private set; }
        private StreamReader reader;
        private StreamWriter writer;
        public bool Connected
        {
            get
            {
                return this.pipe.IsConnected;
            }
        }
        public Pipe(string name)
        {
            this.pipe = new NamedPipeServerStream(name);
            this.reader = new StreamReader(this.pipe, Encoding.UTF8);
            this.writer = new StreamWriter(this.pipe, Encoding.UTF8);
            this.listening = true;
            new Task(() => { Read(); }).Start();
        }
        public async void Send(string msg)
        {
            await this.writer.WriteLineAsync(msg);
        }
        public void SendSync(string msg)
        {
            this.writer.WriteLine(msg);
        }
        public delegate void OnMessageEventHandler(object sender, string message);
        public event OnMessageEventHandler OnMessage;
        private async void Read()
        {
            while (listening)
            {
                if (this.Connected)
                {
                    var msg = await this.reader.ReadLineAsync();
                    if (msg != String.Empty)
                    {
                        OnMessage.Invoke(this, msg);
                    }
                }
            }
        }
        public void Close()
        {
            this.listening = false;
            this.pipe.Close();
        }
    }
}
