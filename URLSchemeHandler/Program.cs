using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using RapID.ClassLibrary;
using System.Text.RegularExpressions;

namespace RapID.URLSchemeHandler
{
    class Program
    {
        const string scheme_name = "rapid";
        const string uri_host = "authorize";
        const string c_cliTokenResultPrefix = "#Rap-ID-Windows/CLI/1.0d/Auth/result=ok;token=";
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
                            // Start the child process.
                            Process p = new Process();
                            // Redirect the output stream of the child process.
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.RedirectStandardOutput = true;
                            p.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "auth.exe";
                            p.StartInfo.Arguments = GetParam(uri.Query, "app");
                            p.Start();
                            var resultGot = false;
                            while(!resultGot)
                            {
                                var message = p.StandardOutput.ReadLine();
                                if (message.StartsWith(c_cliTokenResultPrefix))
                                {
                                    var token = message.Remove(message.IndexOf(c_cliTokenResultPrefix), c_cliTokenResultPrefix.Length);
                                    var callback = DecodeUrlString(GetParam(uri.Query, "callback"));
                                    Process.Start(callback + token);
                                    resultGot = true;
                                }
                            }
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


        /*
         * (C) 2015 @ogi from StackOverflow
         * Original Post: http://stackoverflow.com/questions/1405048/how-do-i-decode-a-url-parameter-using-c
         */
        private static string DecodeUrlString(string url)
        {
            string newUrl;
            while ((newUrl = Uri.UnescapeDataString(url)) != url)
                url = newUrl;
            return newUrl;
        }
    }
}
