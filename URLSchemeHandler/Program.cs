using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLSchemeHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[1].StartsWith("authorize&"))
            {
                Console.WriteLine("Authorize");
                var cb = args[1].Replace("authorize&", "");
                Console.WriteLine("Callback: {0}", cb);
                System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "/auth.exe \"{0}\"", cb);
            }
            else
            {
                Console.WriteLine("Invaid Call");
            }
        }
    }
}
