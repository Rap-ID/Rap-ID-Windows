using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WiAuth.Configure
{
    public partial class Setter : Form
    {
        private PickerItem pi;
        public Setter()
        {
            InitializeComponent();
        }
        public Setter(PickerItem pi)
        {
            InitializeComponent();
            this.pi = pi;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var sWriter = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/pair");
            sWriter.WriteLine(this.pi.Identifier);
            //TODO: pair tcp
            sWriter.Write(this.passBox.Text);
            sWriter.Close();
            sWriter.Dispose();
            Application.ExitThread();
        }
    }
}
