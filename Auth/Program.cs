using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using RapID.ClassLibrary;

namespace RapID.Auth
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // app
            var app = Crypt.Decrypt(Crypt.Decrypt(Crypt.Decrypt(args[0])));
            var waitFrm = new Wait(app);
            Application.Run(waitFrm);
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
