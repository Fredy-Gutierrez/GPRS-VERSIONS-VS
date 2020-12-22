using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases
{
    public static class Seguridad
    {
        public static string Encriptar(string _cadenaAencriptar)
        {
            byte[] encryted = Encoding.Unicode.GetBytes(_cadenaAencriptar);
            string result = Convert.ToBase64String(encryted);
            return result;
        }


        public static string DesEncriptar(string _cadenaAdesencriptar)
        {
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            string result = Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
