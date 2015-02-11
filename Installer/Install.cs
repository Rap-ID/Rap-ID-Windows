using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WiAuth.Installer
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

        /// <summary>
        /// 注册启动项到注册表
        /// </summary>
        public void RegURL(string name)
        {
            //注册的协议头，即在地址栏中的路径 如QQ的：tencent://xxxxx/xxx 我注册的是jun 在地址栏中输入：jun:// 就能打开本程序
            var surekamKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(name);
            //以下这些参数都是固定的，不需要更改，直接复制过去 
            var shellKey = surekamKey.CreateSubKey("shell");
            var openKey = shellKey.CreateSubKey("open");
            var commandKey = openKey.CreateSubKey("command");
            surekamKey.SetValue("URL Protocol", "");
            //这里可执行文件取当前程序全路径，可根据需要修改
            var exePath = this.dirBox.Text + "URLSchemeHandler.exe";
            commandKey.SetValue("", "\"" + exePath + "\"" + " \"%1\"");
        }

        /// <summary>
        /// 取消注册
        /// </summary>
        public void UnRegURL(string name)
        {
            //直接删除节点
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(name);
        }

        private void insButton_Click(object sender, EventArgs e)
        {
            RegURL("wiauth");
        }

        private void uninsButton_Click(object sender, EventArgs e)
        {
            UnRegURL("wiauth");
        }
    }
}
