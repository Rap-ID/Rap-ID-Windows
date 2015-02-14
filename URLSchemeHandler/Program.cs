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
#if DEBUG
                    Console.WriteLine("Authorize");
#endif
                    var cb = args[0].Replace(auth_prefix, "");
                    try
                    {
                        cb = cb.Substring(0, cb.Length - 1);
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                    }
                    catch (Exception ex)
                    {
                        WiAuth.ClassLibrary.Error.ThrowError(ex);
                    }
#if DEBUG
                    Console.WriteLine("Callback: {0}", cb);
#endif
                    var proccess = "\"" + AppDomain.CurrentDomain.BaseDirectory + "auth.exe\"";
#if DEBUG
                    Console.WriteLine("Call: {0}", proccess);
#endif
                    try
                    {
                        Process.Start(proccess, cb);
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        WiAuth.ClassLibrary.Error.ThrowError(ex.Message + " >>> " + proccess);
                    }
                    catch (Exception ex)
                    {
                        WiAuth.ClassLibrary.Error.ThrowError(ex);
                    }
                    return;
                }
            }
            Invaid(args);
        }

        private static void Invaid(string[] args)
        {
            WiAuth.ClassLibrary.Error.ThrowError(new Exception("Invaid parameters."));
        }
    }
}
