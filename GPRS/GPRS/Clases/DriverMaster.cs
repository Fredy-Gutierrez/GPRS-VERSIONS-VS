using GPRS.Clases.Xml.SocketsMessages;
using GPRS.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GPRS.Clases
{
    public class DriverMaster
    {
        public static DriverMaster myDriverMasterClass = null;
        public FormServidor formServer = null;

        public static List<Udp> listUdpConnectors = new List<Udp>();
        public static List<UdpClients> listUdpClientsConnectors = new List<UdpClients>();
        public static List<Tcp> listTcpConnectors = new List<Tcp>();
        public static List<TcpClients> listTcpClientsConnectors = new List<TcpClients>();

        public static List<Udp> listUdpConnectorsModem = new List<Udp>();
        public static List<UdpClients> listUdpClientsConnectorsModem = new List<UdpClients>();
        public static List<Tcp> listTcpConnectorsModem = new List<Tcp>();
        public static List<TcpClients> listTcpClientsConnectorsModem = new List<TcpClients>();

        private const string nodoPrincipalServer= "Servers";
        private const string nodoPrincipalModem = "Modems";

        private List<RouteList> routeList = new List<RouteList>();

        public Configurations c = new Configurations();

        Routing r;

        public void  setFormServidor(FormServidor formServer)
        {
            this.formServer = formServer;
        }

        public DriverMaster()
        {
            r = new Routing();
            setRouting();
            myDriverMasterClass = this;
            c._createXml();
        }

        private void setRouting()
        {
            XmlNodeList route = r._ReadXml();

            XmlNode list;

            for (int i = 0; i < route.Count; i++)
            {
                list = route.Item(i);

                string sname = list.SelectSingleNode("ServerName").InnerText;
                string stype = list.SelectSingleNode("ServerType").InnerText;
                string mname = list.SelectSingleNode("ModemName").InnerText;
                string mtype = list.SelectSingleNode("ModemType").InnerText;
                string idserver = list.SelectSingleNode("IdServer").InnerText;
                string idmodem = list.SelectSingleNode("IdModem").InnerText;

                RouteList routeL = new RouteList(sname,stype,mname,mtype,idserver,idmodem);
                routeList.Add(routeL);
                
            }
        }

        #region BeginServers And Modems

        public Boolean beginTaskServer(string serverProcess)
        {
            Boolean taskTcp = false;
            /*Task.Run(() =>
            {*/
            switch (serverProcess)
            {
                case "UdpClient":
                    beginUdpClient();
                    break;
                case "UdpServer":
                    beginUdpServer();
                    break;
                case "TcpClient":
                    if (beginTcpClient())
                    {
                        taskTcp = true;
                    }
                    break;
                case "TcpServer":
                    beginTcpServer();
                    break;
            }
            //}

            return taskTcp;
        }

        public Boolean beginTaskModem(string modemProcess)
        {
            /*Task.Run(() =>
            {*/
            Boolean taskTcp = false;
            switch (modemProcess)
            {
                case "UdpClient":
                    beginUdpClientModem();
                    break;
                case "UdpServer":
                    beginUdpServerModem();
                    break;
                case "TcpClient":
                    if (beginTcpClientModem())
                    {
                        taskTcp = true;
                    }
                    break;
                case "TcpServer":
                    beginTcpServerModem();
                    break;
            }
            return taskTcp;
            //});
        }

        public void beginAllSockets()
        {
            /******************************Begin Sockets Server****************************/
            beginUdpClient();
            beginUdpServer();
            beginTcpClient();
            beginTcpServer();

            /******************************Begin Sockets Modems****************************/
            beginUdpClientModem();
            beginUdpServerModem();
            beginTcpClientModem();
            beginTcpServerModem();
        }

        private void beginUdpServer()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalServer , "Udp", "UdpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                Udp udp = new Udp(this, name, enlaceport, port, nodoPrincipalServer, c);
                c._UpdateUdpServer(name, enlaceport, port, nodoPrincipalServer, "En espera");

                listUdpConnectors.Add(udp);
                udp.beginServer();

                
            }
        }

        private void beginUdpClient()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalServer, "Udp", "UdpClient", "Client");

            XmlNode client;

            // udpClient;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string enlaceport = client.SelectSingleNode("EnlacePort").InnerText;
                string port = client.SelectSingleNode("DestinationPort").InnerText;

                UdpClients udpClient = new UdpClients(this, name, ip, enlaceport, port, nodoPrincipalServer, c);
                listUdpClientsConnectors.Add(udpClient);
                c._UpdateUdpClient(name, ip, enlaceport, port, nodoPrincipalServer, "En espera");
                udpClient.beginClient();
                
            }
        }

        Boolean tcpClientS=false;

        private Boolean beginTcpClient()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalServer, "Tcp", "TcpClient", "Client");

            XmlNode client;

            tcpClientS = false;

            // udpClient;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string port = client.SelectSingleNode("Port").InnerText;

                TcpClients tcpClients = new TcpClients(this, name, ip, port, nodoPrincipalServer, c);
                c._UpdateTcpClient(name, ip, port, nodoPrincipalServer, "Conectado");
                
                if (tcpClients.beginTcp())
                {
                    listTcpClientsConnectors.Add(tcpClients);
                    tcpClientS = true;
                    //c._UpdateTcpClient(name, ip, port, nodoPrincipalServer, "Conectado");
                }
                else
                {
                    c._UpdateTcpClient(name, ip, port, nodoPrincipalServer, "Inactivo");
                }
            }
            if (!tcpClientS)
            {
                setColorOff();
            }

            return tcpClientS;
        }

        private void beginTcpServer()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalServer, "Tcp", "TcpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                Tcp tcp = new Tcp(this, name, port, nodoPrincipalServer, c);
                c._UpdateTcpServer(name, port, nodoPrincipalServer, "En espera");
                listTcpConnectors.Add(tcp);
                tcp.cargarTcpServer();
                
            }
        }

        /*******************************************************INICIO DE LOS SERVIDORES Y CLIENTES DEL LADO MODEM*****************************************************/
        private void beginUdpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalModem, "Udp", "UdpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                Udp udp = new Udp(this, name, enlaceport, port, nodoPrincipalModem, c);
                c._UpdateUdpServer(name, enlaceport, port, nodoPrincipalModem, "En espera");
                listUdpConnectorsModem.Add(udp);
                udp.beginServer();
                
            }
        }

        private void beginUdpClientModem()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalModem, "Udp", "UdpClient", "Client");

            XmlNode client;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string enlaceport = client.SelectSingleNode("EnlacePort").InnerText;
                string port = client.SelectSingleNode("DestinationPort").InnerText;

                UdpClients udpClient = new UdpClients(this, name, ip, enlaceport, port, nodoPrincipalModem, c);
                c._UpdateUdpClient(name, ip, enlaceport, port, nodoPrincipalModem, "En espera");
                listUdpClientsConnectorsModem.Add(udpClient);
                udpClient.beginClient();
                
            }
        }

        Boolean tcpClientM= false;
        private Boolean beginTcpClientModem()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalModem, "Tcp", "TcpClient", "Client");

            XmlNode client;

            tcpClientM = false;

            // udpClient;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string port = client.SelectSingleNode("Port").InnerText;

                TcpClients tcpClients = new TcpClients(this, name, ip, port, nodoPrincipalModem, c);
                c._UpdateTcpClient(name, ip, port, nodoPrincipalModem, "Conectado");
                if (tcpClients.beginTcp())
                {
                    listTcpClientsConnectorsModem.Add(tcpClients);
                    tcpClientM = true;

                }
                else
                {
                    c._UpdateTcpClient(name, ip, port, nodoPrincipalModem, "Inactivo");
                }
            }

            if (!tcpClientM)
            {
                setColorOffM();
            }

            return tcpClientM;
        }

        private void beginTcpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalModem, "Tcp", "TcpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                Tcp tcp = new Tcp(this, name, port, nodoPrincipalModem, c);
                c._UpdateTcpServer(name, port, nodoPrincipalModem, "En espera");
                listTcpConnectorsModem.Add(tcp);
                tcp.cargarTcpServer();
                
            }
        }

        public void beginOneUdpClientServer(string name,string ip,string enlaceport,string port)
        {
            UdpClients udpClient = new UdpClients(this, name, ip, enlaceport, port, nodoPrincipalServer, c);
            c._UpdateUdpClient(name, ip, enlaceport, port, nodoPrincipalServer, "En espera");
            listUdpClientsConnectors.Add(udpClient);
            udpClient.beginClient();
            
        }

        public void beginOneUdpServerServer(string name, string enlaceport, string port)
        {
            Udp udp = new Udp(this, name, enlaceport, port, nodoPrincipalServer, c);
            c._UpdateUdpServer(name, enlaceport, port, nodoPrincipalServer, "En espera");
            listUdpConnectors.Add(udp);
            udp.beginServer();
            
        }

        public void beginOneTcpClientServer(string name, string ip, string port)
        {
            TcpClients tcpClients = new TcpClients(this, name, ip, port, nodoPrincipalServer, c);
            c._UpdateTcpClient(name, ip, port, nodoPrincipalServer, "Conectado");
            listTcpClientsConnectors.Add(tcpClients);
            if (tcpClients.beginTcp())
            {
                c._UpdateTcpClient(name, ip, port, nodoPrincipalServer, "Conectado");
            }
            else
            {
                c._UpdateTcpClient(name, ip, port, nodoPrincipalServer, "Inactivo");
            }
        }

        public void beginOneTcpServerServer(string name, string port)
        {
            
            Tcp tcp = new Tcp(this, name, port, nodoPrincipalServer, c);
            c._UpdateTcpServer(name, port, nodoPrincipalServer, "En espera");
            listTcpConnectors.Add(tcp);
            tcp.cargarTcpServer();
            
            
        }

        public void beginOneUdpClientModem(string name, string ip, string enlaceport, string port)
        {
            UdpClients udpClient = new UdpClients(this, name, ip, enlaceport, port, nodoPrincipalModem, c);
            c._UpdateUdpClient(name, ip, enlaceport, port, nodoPrincipalModem, "En espera");
            listUdpClientsConnectorsModem.Add(udpClient);
            udpClient.beginClient();
            
        }

        public void beginOneUdpServerModem(string name, string enlaceport, string port)
        {
            Udp udp = new Udp(this, name, enlaceport, port, nodoPrincipalModem, c);
            c._UpdateUdpServer(name, enlaceport, port, nodoPrincipalModem, "En espera");
            listUdpConnectorsModem.Add(udp);
            udp.beginServer();
            
        }

        public void beginOneTcpClientModem(string name, string ip, string port)
        {
            TcpClients tcpClients = new TcpClients(this, name, ip, port, nodoPrincipalModem, c);
            c._UpdateTcpClient(name, ip, port, nodoPrincipalModem, "Conectado");
            listTcpClientsConnectorsModem.Add(tcpClients);
            if (tcpClients.beginTcp())
            {
                c._UpdateTcpClient(name, ip, port, nodoPrincipalModem, "Conectado");
            }
            else
            {
                c._UpdateTcpClient(name, ip, port, nodoPrincipalModem, "Inactivo");
            }
        }

        public void beginOneTcpServerModem(string name, string port)
        {

            Tcp tcp = new Tcp(this, name, port, nodoPrincipalModem, c);
            c._UpdateTcpServer(name, port, nodoPrincipalModem, "En espera");
            listTcpConnectorsModem.Add(tcp);
            tcp.cargarTcpServer();
            

        }

        #endregion

        public void reciveToSendServer(Byte[] msg, string name,string type,string fecha)
        {
            string mensaje = type + " " + name + ": " + BitConverter.ToString(msg).Replace("-", " ") + "    "+ fecha;

            if (formServer != null)
            {
                this.formServer.Mensajes(mensaje,"Server",type,name);
            }

            for (int i = 0; i < routeList.Count; i++)
            {
                string sname = routeList[i].getServerName();
                string stype = routeList[i].getServerType();
                

                if (sname.Equals(name) && stype.Equals(type))
                {
                    string mname = routeList[i].getModemName();
                    string mtype = routeList[i].getModemType();
                    string idserver = routeList[i].getIdServer();
                    string idmodem = routeList[i].getIdModem();

                    switch (mtype)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsConnectorsModem.Count; x++)
                            {
                                if (listUdpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listUdpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectorsModem.Count; x++)
                            {
                                if (listUdpConnectorsModem[x].getName().Equals(mname))
                                {
                                    if (listUdpConnectorsModem[x].getDireccion())
                                    {
                                        listUdpConnectorsModem[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectorsModem.Count; x++)
                            {
                                if (listTcpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listTcpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectorsModem.Count; x++)
                            {
                                if (listTcpConnectorsModem[x].getName().Equals(mname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectorsModem[x].sendToClient(msg, idmodem);
                                }
                            }
                            break;

                    }
                }
            }

            #region coments

            /*XmlNodeList route = r._ReadXml();

            XmlNode list;

            for (int i = 0; i < route.Count; i++)
            {
                list = route.Item(i);

                string sname = list.SelectSingleNode("ServerName").InnerText;
                string stype = list.SelectSingleNode("ServerType").InnerText;
                string mname = list.SelectSingleNode("ModemName").InnerText;
                string mtype = list.SelectSingleNode("ModemType").InnerText;
                string idserver = list.SelectSingleNode("IdServer").InnerText;
                string idmodem = list.SelectSingleNode("IdModem").InnerText;

                if (sname.Equals(name) && stype.Equals(type))
                {
                    switch (mtype)
                    {
                        case "UdpClient":
                            for (int x =0; x<listUdpClientsConnectorsModem.Count; x++)
                            {
                                if (listUdpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listUdpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectorsModem.Count; x++)
                            {
                                if (listUdpConnectorsModem[x].getName().Equals(mname))
                                {
                                    if (listUdpConnectorsModem[x].getDireccion())
                                    {
                                        listUdpConnectorsModem[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectorsModem.Count; x++)
                            {
                                if (listTcpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listTcpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectorsModem.Count; x++)
                            {
                                if (listTcpConnectorsModem[x].getName().Equals(mname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectorsModem[x].sendToClient(msg,idmodem);
                                }
                            }
                            break;

                    }
                }
            }*/

            #endregion
        }

        public void reciveToSendModem(Byte[] msg, string name, string type,string fecha)
        {
            string mensaje = type + " " + name + ": " + BitConverter.ToString(msg).Replace("-", " ") + "    " + fecha;
            if (formServer != null)
            {
                this.formServer.Mensajes(mensaje, "Modem", type, name);
            }

            for (int i = 0; i < routeList.Count; i++)
            {
                string mname = routeList[i].getModemName();
                string mtype = routeList[i].getModemType();

                if (mname.Equals(name) && mtype.Equals(type))
                {

                    string sname = routeList[i].getServerName();
                    string stype = routeList[i].getServerType();
                    string idserver = routeList[i].getIdServer();
                    string idmodem = routeList[i].getIdModem();

                    switch (stype)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsConnectors.Count; x++)
                            {
                                if (listUdpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listUdpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectors.Count; x++)
                            {
                                if (listUdpConnectors[x].getName().Equals(sname))
                                {
                                    if (listUdpConnectors[x].getDireccion())
                                    {
                                        listUdpConnectors[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectors.Count; x++)
                            {
                                if (listTcpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listTcpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectors.Count; x++)
                            {
                                if (listTcpConnectors[x].getName().Equals(sname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectors[x].sendToClient(msg, idserver);
                                }
                            }
                            break;

                    }
                }
            }
            #region coments
            /*
            XmlNodeList route = r._ReadXml();

            XmlNode list;

            for (int i = 0; i < route.Count; i++)
            {
                list = route.Item(i);

                string sname = list.SelectSingleNode("ServerName").InnerText;
                string stype = list.SelectSingleNode("ServerType").InnerText;
                string mname = list.SelectSingleNode("ModemName").InnerText;
                string mtype = list.SelectSingleNode("ModemType").InnerText;
                string idserver = list.SelectSingleNode("IdServer").InnerText;
                string idmodem = list.SelectSingleNode("IdModem").InnerText;

                if (mname.Equals(name) && mtype.Equals(type))
                {
                    switch (stype)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsConnectors.Count; x++)
                            {
                                if (listUdpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listUdpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectors.Count; x++)
                            {
                                if (listUdpConnectors[x].getName().Equals(sname))
                                {
                                    if (listUdpConnectors[x].getDireccion())
                                    {
                                        listUdpConnectors[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectors.Count; x++)
                            {
                                if (listTcpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listTcpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectors.Count; x++)
                            {
                                if (listTcpConnectors[x].getName().Equals(sname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectors[x].sendToClient(msg, idserver);
                                }
                            }
                            break;

                    }
                }
            }*/
            #endregion
        }

        public void reciveToSendTcpServer(Byte[] msg, string name, string type,string id, string fecha)
        {

            //string mensaje = "\n"+type + " " + name + ": " + BitConverter.ToString(msg).Remove(74) + "\n";
            string mensaje = type + " " + name + ": " + BitConverter.ToString(msg).Replace("-", " ") + "    " + fecha;
            if (formServer != null)
            {
                this.formServer.Mensajes(mensaje, "Server", type, name);
            }

            for (int i = 0; i < routeList.Count; i++)
            {
                string sname = routeList[i].getServerName();
                string stype = routeList[i].getServerType();
                string idserver = routeList[i].getIdServer();

                if (sname.Equals(name) && stype.Equals(type) && idserver.Equals(id))
                {
                    string mname = routeList[i].getModemName();
                    string mtype = routeList[i].getModemType();
                    string idmodem = routeList[i].getIdModem();

                    Console.WriteLine("Encontrado");
                    switch (mtype)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsConnectorsModem.Count; x++)
                            {
                                if (listUdpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listUdpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectorsModem.Count; x++)
                            {
                                if (listUdpConnectorsModem[x].getName().Equals(mname))
                                {
                                    if (listUdpConnectorsModem[x].getDireccion())
                                    {

                                        listUdpConnectorsModem[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectorsModem.Count; x++)
                            {
                                if (listTcpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listTcpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectorsModem.Count; x++)
                            {
                                if (listTcpConnectorsModem[x].getName().Equals(mname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectorsModem[x].sendToClient(msg, idmodem);
                                }
                            }
                            break;

                    }
                }
            }

            #region coments
            /*
            XmlNodeList route = r._ReadXml();

            XmlNode list;

            for (int i = 0; i < route.Count; i++)
            {
                list = route.Item(i);

                string sname = list.SelectSingleNode("ServerName").InnerText;
                string stype = list.SelectSingleNode("ServerType").InnerText;
                string mname = list.SelectSingleNode("ModemName").InnerText;
                string mtype = list.SelectSingleNode("ModemType").InnerText;
                string idserver = list.SelectSingleNode("IdServer").InnerText;
                string idmodem = list.SelectSingleNode("IdModem").InnerText;

                if (sname.Equals(name) && stype.Equals(type) && idserver.Equals(id))
                {
                    Console.WriteLine("Encontrado");
                    switch (mtype)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsConnectorsModem.Count; x++)
                            {
                                if (listUdpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listUdpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectorsModem.Count; x++)
                            {
                                if (listUdpConnectorsModem[x].getName().Equals(mname))
                                {
                                    if (listUdpConnectorsModem[x].getDireccion())
                                    {

                                        listUdpConnectorsModem[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectorsModem.Count; x++)
                            {
                                if (listTcpClientsConnectorsModem[x].getName().Equals(mname))
                                {
                                    listTcpClientsConnectorsModem[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectorsModem.Count; x++)
                            {
                                if (listTcpConnectorsModem[x].getName().Equals(mname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectorsModem[x].sendToClient(msg, idmodem);
                                }
                            }
                            break;

                    }
                }
            }*/
            #endregion
        }

        public void reciveToSendTcpModem(Byte[] msg, string name, string type,string id,string fecha)
        {

            //string mensaje = type + " " + name + ": " + BitConverter.ToString(msg).Remove(74) + "\n";
            string mensaje = type + " " + name + ": " + BitConverter.ToString(msg).Replace("-"," ") + "    " + fecha;
            
            if (formServer != null)
            {
                this.formServer.Mensajes(mensaje, "Modem", type, name);
            }

            for (int i = 0; i < routeList.Count; i++)
            {
                string mname = routeList[i].getModemName();
                string mtype = routeList[i].getModemType();
                string idmodem = routeList[i].getIdModem();

                if (mname.Equals(name) && mtype.Equals(type) && idmodem.Equals(id))
                {
                    string sname = routeList[i].getServerName();
                    string stype = routeList[i].getServerType();
                    string idserver = routeList[i].getIdServer();

                    switch (stype)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsConnectors.Count; x++)
                            {
                                if (listUdpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listUdpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectors.Count; x++)
                            {
                                if (listUdpConnectors[x].getName().Equals(sname))
                                {
                                    if (listUdpConnectors[x].getDireccion())
                                    {
                                        listUdpConnectors[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectors.Count; x++)
                            {
                                if (listTcpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listTcpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectors.Count; x++)
                            {
                                if (listTcpConnectors[x].getName().Equals(sname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectors[x].sendToClient(msg, idserver);
                                }
                            }
                            break;

                    }
                }
            }
            #region coments
            /*
            XmlNodeList route = r._ReadXml();

            XmlNode list;

            for (int i = 0; i < route.Count; i++)
            {
                list = route.Item(i);

                string sname = list.SelectSingleNode("ServerName").InnerText;
                string stype = list.SelectSingleNode("ServerType").InnerText;
                string mname = list.SelectSingleNode("ModemName").InnerText;
                string mtype = list.SelectSingleNode("ModemType").InnerText;
                string idserver = list.SelectSingleNode("IdServer").InnerText;
                string idmodem = list.SelectSingleNode("IdModem").InnerText;

                if (mname.Equals(name) && mtype.Equals(type) && idmodem.Equals(id))
                {
                    switch (stype)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsConnectors.Count; x++)
                            {
                                if (listUdpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listUdpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpConnectors.Count; x++)
                            {
                                if (listUdpConnectors[x].getName().Equals(sname))
                                {
                                    if (listUdpConnectors[x].getDireccion())
                                    {
                                        listUdpConnectors[x].send(msg);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encuentra conectado el cliente");
                                    }
                                }
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsConnectors.Count; x++)
                            {
                                if (listTcpClientsConnectors[x].getName().Equals(sname))
                                {
                                    listTcpClientsConnectors[x].send(msg);
                                }
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpConnectors.Count; x++)
                            {
                                if (listTcpConnectors[x].getName().Equals(sname))
                                {
                                    //Console.WriteLine("Enviado by tcpSever");
                                    listTcpConnectors[x].sendToClient(msg, idserver);
                                }
                            }
                            break;

                    }
                }
            }*/

            #endregion
        }

        #region Close Coneccion
        public void closeUdpClientS()
        {
            for (int x = 0; x< listUdpClientsConnectors.Count; x++)
            {
                listUdpClientsConnectors[x].CloseUdp();
            }
            listUdpClientsConnectors.Clear();
        }

        public void closeUdpServerS()
        {
            for (int x = 0; x < listUdpConnectors.Count; x++)
            {
                listUdpConnectors[x].CloseUdp();
            }
            listUdpConnectors.Clear();
        }

        public void closeTcpClientS()
        {
            for (int x = 0; x < listTcpClientsConnectors.Count; x++)
            {
                listTcpClientsConnectors[x].CloseTcp();
            }
            listTcpClientsConnectors.Clear();
        }

        public void closeTcpServerS()
        {
            for (int x = 0; x < listTcpConnectors.Count; x++)
            {
                listTcpConnectors[x].CloseTcp();
            }
            listTcpConnectors.Clear();
        }


        public void closeUdpClientM()
        {
            for (int x = 0; x < listUdpClientsConnectorsModem.Count; x++)
            {
                listUdpClientsConnectorsModem[x].CloseUdp();
            }
            listUdpClientsConnectorsModem.Clear();
        }

        public void closeUdpServerM()
        {
            for (int x = 0; x < listUdpConnectorsModem.Count; x++)
            {
                listUdpConnectorsModem[x].CloseUdp();
            }
            listUdpConnectorsModem.Clear();
        }

        public void closeTcpClientM()
        {
            for (int x = 0; x < listTcpClientsConnectorsModem.Count; x++)
            {
                listTcpClientsConnectorsModem[x].CloseTcp();
            }
            listTcpClientsConnectorsModem.Clear();
        }

        public void closeTcpServerM()
        {
            for (int x = 0; x < listTcpConnectorsModem.Count; x++)
            {
                listTcpConnectorsModem[x].CloseTcp();
            }
            listTcpConnectorsModem.Clear();
        }

        /***************************************************CLOSE JUST ONE*****************************************************/
        public void closeOneUdpClientS(string name)
        {
            for (int x = 0; x < listUdpClientsConnectors.Count; x++)
            {
                if (listUdpClientsConnectors[x].getName().Equals(name))
                {
                    listUdpClientsConnectors[x].CloseUdp();
                    listUdpClientsConnectors.RemoveAt(x);
                }
                
            }
        }

        public void closeOneUdpServerS(string name)
        {
            for (int x = 0; x < listUdpConnectors.Count; x++)
            {
                if (listUdpConnectors[x].getName().Equals(name))
                {
                    listUdpConnectors[x].CloseUdp();
                    listUdpConnectors.RemoveAt(x);
                }

            }
        }

        public void closeOneTcpClientS(string name)
        {
            for (int x = 0; x < listTcpClientsConnectors.Count; x++)
            {
                if (listTcpClientsConnectors[x].getName().Equals(name))
                {
                    listTcpClientsConnectors[x].CloseTcp();
                    listTcpClientsConnectors.RemoveAt(x);
                }

            }
        }

        public void closeOneTcpServerS(string name)
        {
            for (int x = 0; x < listTcpConnectors.Count; x++)
            {
                if (listTcpConnectors[x].getName().Equals(name))
                {
                    listTcpConnectors[x].CloseTcp();
                    listTcpConnectors.RemoveAt(x);
                }

            }
        }


        public void closeOneUdpClientM(string name)
        {
            for (int x = 0; x < listUdpClientsConnectorsModem.Count; x++)
            {
                if (listUdpClientsConnectorsModem[x].getName().Equals(name))
                {
                    listUdpClientsConnectorsModem[x].CloseUdp();
                    listUdpClientsConnectorsModem.RemoveAt(x);
                }

            }
        }

        public void closeOneUdpServerM(string name)
        {
            for (int x = 0; x < listUdpConnectorsModem.Count; x++)
            {
                if (listUdpConnectorsModem[x].getName().Equals(name))
                {
                    listUdpConnectorsModem[x].CloseUdp();
                    listUdpConnectorsModem.RemoveAt(x);
                }

            }
        }

        public void closeOneTcpClientM(string name)
        {
            for (int x = 0; x < listTcpClientsConnectorsModem.Count; x++)
            {
                if (listTcpClientsConnectorsModem[x].getName().Equals(name))
                {
                    listTcpClientsConnectorsModem[x].CloseTcp();
                    listTcpClientsConnectorsModem.RemoveAt(x);
                }

            }
        }

        public void closeOneTcpServerM(string name)
        {
            for (int x = 0; x < listTcpConnectorsModem.Count; x++)
            {
                if (listTcpConnectorsModem[x].getName().Equals(name))
                {
                    listTcpConnectorsModem[x].CloseTcp();
                    listTcpConnectorsModem.RemoveAt(x);
                }

            }
        }

        #endregion

        private void setColorOff()
        {
            if (formServer != null)
            {
                //formServer.setColorOff(formServer.btnTcpClientServer, formServer.lblTitleServer, formServer.lblTcpClientServer);
                //formServer.onbtnTcpClientServer = false;
            }
        }

        private void setColorOffM()
        {
            if (formServer != null)
            {
                //formServer.setColorOff(formServer.btnTcpClientModem, formServer.lblTitleModem, formServer.lblTcpClientModem);
                //formServer.onbtnTcpClientModem = false;
            }
        }

        #region Inactive Sockets

        public void setInactive()
        {
            setInactiveUdpServer();
            setInactiveUdpClient();
            setInactiveTcpClient();
            setInactiveTcpServer();
            setInactiveUdpServerModem();
            setInactiveUdpClientModem();
            setInactiveTcpClientModem();
            setInactiveTcpServerModem();
        }

        private void setInactiveUdpServer()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalServer, "Udp", "UdpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                c._UpdateUdpServer(name, enlaceport, port, nodoPrincipalServer, "Inactivo");

            }
        }

        private void setInactiveUdpClient()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalServer, "Udp", "UdpClient", "Client");

            XmlNode client;

            // udpClient;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string enlaceport = client.SelectSingleNode("EnlacePort").InnerText;
                string port = client.SelectSingleNode("DestinationPort").InnerText;

                c._UpdateUdpClient(name, ip, enlaceport, port, nodoPrincipalServer, "Inactivo");
            }
        }

        private void setInactiveTcpClient()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalServer, "Tcp", "TcpClient", "Client");

            XmlNode client;

            // udpClient;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string port = client.SelectSingleNode("Port").InnerText;

                
                c._UpdateTcpClient(name, ip, port, nodoPrincipalServer, "Inactivo");
                
            }
        }

        private void setInactiveTcpServer()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalServer, "Tcp", "TcpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                c._UpdateTcpServer(name, port, nodoPrincipalServer, "Inactivo");
            }
        }

        /*******************************************************INICIO DE LOS SERVIDORES Y CLIENTES DEL LADO MODEM*****************************************************/
        private void setInactiveUdpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalModem, "Udp", "UdpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                c._UpdateUdpServer(name, enlaceport, port, nodoPrincipalModem, "Inactivo");
            }
        }

        private void setInactiveUdpClientModem()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalModem, "Udp", "UdpClient", "Client");

            XmlNode client;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string enlaceport = client.SelectSingleNode("EnlacePort").InnerText;
                string port = client.SelectSingleNode("DestinationPort").InnerText;

                c._UpdateUdpClient(name, ip, enlaceport, port, nodoPrincipalModem, "Inactivo");
            }
        }

        private void setInactiveTcpClientModem()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalModem, "Tcp", "TcpClient", "Client");

            XmlNode client;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string port = client.SelectSingleNode("Port").InnerText;

                
                c._UpdateTcpClient(name, ip, port, nodoPrincipalModem, "Inactivo");
                
            }
        }

        private void setInactiveTcpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalModem, "Tcp", "TcpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                c._UpdateTcpServer(name, port, nodoPrincipalModem, "Inactivo");
            }
        }

        #endregion
    }
}
