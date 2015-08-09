using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RapID.Installer
{
    public partial class Install : Form
    {
        public Install()
        {
            InitializeComponent();
        }

        private void Install_Load(object sender, EventArgs e)
        {
            this.dirBox.Text = AppDomain.CurrentDomain.BaseDirectory;
        }

        public void RegURL(string name)
        {
            var surekamKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(name);
            var shellKey = surekamKey.CreateSubKey("shell");
            var openKey = shellKey.CreateSubKey("open");
            var commandKey = openKey.CreateSubKey("command");
            surekamKey.SetValue("URL Protocol", "");
            var exePath = this.dirBox.Text + "URLSchemeHandler.exe";
            commandKey.SetValue("", "\"" + exePath + "\"" + " \"%1\"");
        }

        public void UnReg(string name)
        {
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(name);
        }

        public void RegFilePos(string name)
        {
            var surekamKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(name);
            var dirKey = surekamKey.CreateSubKey("dir");
            var insPath = this.dirBox.Text;
            dirKey.SetValue("", insPath);
            var authPath = this.dirBox.Text + "auth.exe";
            dirKey.SetValue("auth", authPath);
        }

        private void insButton_Click(object sender, EventArgs e)
        {
            RegURL("rapid");
            RegFilePos("rapid");
            System.Diagnostics.Process.Start(this.dirBox.Text + "conf.exe");
        }

        private void uninsButton_Click(object sender, EventArgs e)
        {
            UnReg("rapid");
        }
    }
}
