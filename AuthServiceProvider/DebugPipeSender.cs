using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Pipes;

namespace AuthServiceProvider
{
    public partial class DebugPipeSender : Form
    {
        private NamedPipeClientStream client;
        private StreamReader reader;
        private StreamWriter writer;
        public DebugPipeSender()
        {
            InitializeComponent();
        }

        #region Log
        private void log(string message)
        {
            var time = new DateTime();
            this.logBox.Text += time.ToString("[ yyyy MM dd HH:mm:ss UTC zzz ]") + message + "\n\r";
        }
        private void logMessage(string message)
        {
            this.log("<MSGREC>" + message);
        }
        private void logSend(string message)
        {
            this.log("<MSGSND>" + message);
        }
        #endregion

        private void connectButton_Click(object sender, EventArgs e)
        {
            this.client = new NamedPipeClientStream("WiAuth-AuthPipe");
            this.client.Connect();
            this.reader = new StreamReader(client);
            this.writer = new StreamWriter(client);
            this.writer.AutoFlush = true;
            Read();
        }

        private async void Read()
        {
            var msg = await this.reader.ReadLineAsync();
            this.logMessage(msg);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debugger.Break();
            this.writer.WriteLine(this.msgBox.Text);
            this.logSend(this.msgBox.Text);
        }
    }
}
