using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WiAuth.URLSchemeHandler
{
    class Program
    {
        const string auth_prefix = "wiauth://authorize&";
        const string scheme_name = "wiauth";
        static void Main(string[] args)
        {
            if (args.Count() == 1)
            {
                if (args[0].StartsWith(auth_prefix))
                {
                    Console.WriteLine("Authorize");
                    var cb = args[0].Replace(auth_prefix, "");
                    cb = cb.Substring(0, cb.Length - 1);
                    Console.WriteLine("Callback: {0}", cb);
                    var proccess = AppDomain.CurrentDomain.BaseDirectory + "\\auth.exe \"" + cb + "\"";
                    Console.WriteLine("Call: {0}", proccess);
                    Process.Start(proccess);
                    return;
                }
            }
            Invaid();
        }

        private static void Invaid()
        {
            Console.WriteLine("Invaid Call");
#if DEBUG
                Console.WriteLine("Debug: 1=Reg, 2=Unreg");
                var input = Console.ReadLine();
                switch (Convert.ToInt32(input))
                {
                    case 1:
                        {
                            Reg(scheme_name);
                            Console.WriteLine("Scheme {0} registered.", scheme_name);
                            break;
                        }
                    case 2:
                        {
                            UnReg(scheme_name);
                            Console.WriteLine("Scheme {0} unregistered.", scheme_name);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invaid operation!");
                            break;
                        }
                }
#endif
        }
        /// <summary>
        /// 注册启动项到注册表
        /// </summary>
        public static void Reg(string name)
        {
            //注册的协议头，即在地址栏中的路径 如QQ的：tencent://xxxxx/xxx 我注册的是jun 在地址栏中输入：jun:// 就能打开本程序
            var surekamKey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(name);
            //以下这些参数都是固定的，不需要更改，直接复制过去 
            var shellKey = surekamKey.CreateSubKey("shell");
            var openKey = shellKey.CreateSubKey("open");
            var commandKey = openKey.CreateSubKey("command");
            surekamKey.SetValue("URL Protocol", "");
            //这里可执行文件取当前程序全路径，可根据需要修改
            var exePath = Process.GetCurrentProcess().MainModule.FileName;
            commandKey.SetValue("", "\"" + exePath + "\"" + " \"%1\"");
        }

        /// <summary>
        /// 取消注册
        /// </summary>
        public static void UnReg(string name)
        {
            //直接删除节点
            Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(name);
        }
    }
}
