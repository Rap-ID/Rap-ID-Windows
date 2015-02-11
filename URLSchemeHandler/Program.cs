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
                    var proccess = "\"\"" + AppDomain.CurrentDomain.BaseDirectory + "auth.exe\" \"" + cb + "\"\"";
                    Console.WriteLine("Call: {0}", proccess);
                    Process.Start("\"" + AppDomain.CurrentDomain.BaseDirectory + "auth.exe\"", cb);
                    return;
                }
            }
            Invaid();
        }

        private static void Invaid()
        {
            Console.WriteLine("Invaid Call");
        }
    }
}
