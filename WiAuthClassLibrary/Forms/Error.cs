using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiAuth.ClassLibrary.Forms
{
    public partial class Error : Form
    {
        private static readonly string logPath = AppDomain.CurrentDomain.BaseDirectory + "wiauth.log";
        private string message;
        public Error()
        {
            InitializeComponent();
        }

        public Error(string message)
            : this()
        {
            this.message = message;
        }

        public Error(Exception ex)
            : this(ex.Message)
        {
        }

        private void Error_Load(object sender, EventArgs e)
        {
            this.Text = AppDomain.CurrentDomain.FriendlyName;
            this.messageBox.Text += logPath;
            Log.log(message, logPath);
            this.messageBox.Text += "\n" + message;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
