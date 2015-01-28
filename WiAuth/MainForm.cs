using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WiAuth.Debug
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void broadcastingButton_Click(object sender, EventArgs e)
        {
            var frm = new DebugBroadcasting();
            frm.Show();
        }
    }
}
