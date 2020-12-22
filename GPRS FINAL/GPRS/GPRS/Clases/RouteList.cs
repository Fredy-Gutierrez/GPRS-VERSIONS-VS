using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRS.Clases
{
    public class RouteList
    {
        private readonly string ServerName = string.Empty;
        private readonly string ServerType = string.Empty;
        private readonly string ModemName = string.Empty;
        private readonly string ModemType = string.Empty;
        private readonly string IdServer = string.Empty;
        private readonly string IdModem = string.Empty;

        public RouteList(string serverName, string serverType, string modemName, string modemType, string idServer, string idModem)
        {
            ServerName = serverName;
            ServerType = serverType;
            ModemName = modemName;
            ModemType = modemType;
            IdServer = idServer;
            IdModem = idModem;
        }

        public string getServerName()
        {
            return ServerName;
        }

        public string getServerType()
        {
            return ServerType;
        }

        public string getModemName()
        {
            return ModemName;
        }

        public string getModemType()
        {
            return ModemType;
        }

        public string getIdServer()
        {
            return IdServer;
        }

        public string getIdModem()
        {
            return IdModem;
        }
    }
}
