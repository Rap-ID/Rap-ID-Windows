using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WiAuth.ClassLibrary;
using System.Text.RegularExpressions;

namespace WiAuth.URLSchemeHandler
{
    class Program
    {
        const string scheme_name = "wiauth";
        const string uri_host = "authorize";
        static void Main(string[] args)
        {
            if (args.Count() == 1)
            {
                var uri = new Uri(args[0]);
                if (uri.Scheme != scheme_name)
                {
                    Invaid();
                }
                switch (uri.Host)
                {
                    case uri_host:
                        {
                            var query = uri.Fragment;
                            Process.Start(AppDomain.CurrentDomain.BaseDirectory + "auth.exe", query);
                            break;
                        }
                    default:
                        {
                            Invaid();
                            break;
                        }
                }
                return;
            }
            Invaid();
        }

        private static void Invaid()
        {
            Error.ThrowError(new Exception("Invaid parameters."));
        }

        private static string GetParam(string query, string paramName)
        {
            Regex urlRegex = new Regex(@"(?:^|/?|&)" + paramName + "=([^&]*)(?:&|$)");
            Match m = urlRegex.Match(query.ToLower());
            if (m.Success)
            {
                return m.Groups[1].Value;
            }
            throw new KeyNotFoundException();
        }
    }
}
