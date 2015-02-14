using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WiAuth.ClassLibrary
{
    public static class Log
    {
        public static void log(string message, string filePath)
        {
            try
            {
                var sw = new StreamWriter(filePath, true, Encodes.UTF8NoBOM);
                sw.WriteLine(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss UTCzzz]") + "<" + AppDomain.CurrentDomain.FriendlyName + ">" + message);
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
#if DEBUG
                System.Windows.Forms.MessageBox.Show(ex.Message);
#else
                System.Diagnostics.Debug.WriteLine(ex);
#endif
            }
        }

        public static void log(string message)
        {
            log(message, AppDomain.CurrentDomain.BaseDirectory + "wiauth.log");
        }
    }
}
