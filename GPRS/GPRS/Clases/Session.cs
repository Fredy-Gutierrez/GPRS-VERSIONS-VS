using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases
{
    public static class Session
    {
        public static int id = 0;
        public static string name = string.Empty;
        public static string email = string.Empty;
        public static string user = string.Empty;
        public static string role = string.Empty;
        public static string pass = string.Empty;

        public static void closeSesion()
        {
            id = 0;
            name = string.Empty;
            user = string.Empty;
            role = string.Empty;
            pass = string.Empty;
        }
    }
}
