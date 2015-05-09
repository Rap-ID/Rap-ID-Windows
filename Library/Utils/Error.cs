using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapID.ClassLibrary
{
    public static class Error
    {
        public static void ThrowError(Exception ex)
        {
            ThrowError(ex.Message);
        }

        public static void ThrowError(string msg)
        {
            var frm = new Forms.Error(msg);
            frm.ShowDialog();
        }
    }
}
