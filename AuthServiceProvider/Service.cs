using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiAuth.ClassLibrary;

namespace AuthServiceProvider
{
    public partial class Service : Form
    {
        private Pipe pipe;
        public Service()
        {
            InitializeComponent();
#if DEBUG
            var frm = new DebugPipeSender();
            frm.Show();
#endif
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

        private void startButton_Click(object sender, EventArgs e)
        {
            const string PipeName = "WiAuth-AuthPipe";
            this.pipe = new Pipe(PipeName);
            this.pipe.OnMessage += pipe_OnMessage;
            log("<SRVSRT>");
        }

        void pipe_OnMessage(object sender, string message)
        {
            logMessage(message);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            this.pipe.Close();
            log("<SRVEND>");
        }
    }
}
