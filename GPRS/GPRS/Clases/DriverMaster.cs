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
        public FormServidor formServer;

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

        public Configurations c = new Configurations();

        Routing r = new Routing();

        public DriverMaster(FormServidor formServer)
        {
            this.formServer = formServer;
        }


        #region BeginServers And Modems

        public void beginTaskServer(string serverProcess)
        {
            Task.Run(() =>
            {
                switch (serverProcess)
                {
                    case "UdpClient":
                        beginUdpClient();
                        break;
                    case "UdpServer":
                        beginUdpServer();
                        break;
                    case "TcpClient":
                        beginTcpClient();
                        break;
                    case "TcpServer":
                        beginTcpServer();
                        break;

                }
            });
        }

        public void beginTaskModem(string modemProcess)
        {
            Task.Run(() =>
            {
                switch (modemProcess)
                {
                    case "UdpClient":
                        beginUdpClientModem();
                        break;
                    case "UdpServer":
                        beginUdpServerModem();
                        break;
                    case "TcpClient":
                        beginTcpClientModem();
                        break;
                    case "TcpServer":
                        beginTcpServerModem();
                        break;

                }
            });
        }

        public void beginUdpServer()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalServer , "Udp", "UdpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                Udp udp = new Udp(this,name,enlaceport,port, nodoPrincipalServer);
                listUdpConnectors.Add(udp);
                udp.beginServer();
            }
        }

        public void beginUdpClient()
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

                UdpClients udpClient = new UdpClients(this, name,ip, enlaceport, port, nodoPrincipalServer);
                listUdpClientsConnectors.Add(udpClient);
                udpClient.beginClient();
            }
        }

        Boolean tcpClientS=false;

        public void beginTcpClient()
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

                TcpClients tcpClients = new TcpClients(this,name,ip,port, nodoPrincipalServer);
                listTcpClientsConnectors.Add(tcpClients);
                if (tcpClients.beginTcp())
                {
                    tcpClientS = true;
                }
            }
            if (!tcpClientS)
            {
                setColorOff();
            }
        }

        public void beginTcpServer()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalServer, "Tcp", "TcpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                Tcp tcp = new Tcp(this, name, port, nodoPrincipalServer);
                listTcpConnectors.Add(tcp);
                tcp.cargarTcpServer();
            }
        }

        /*******************************************************INICIO DE LOS SERVIDORES Y CLIENTES DEL LADO MODEM*****************************************************/
        public void beginUdpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalModem, "Udp", "UdpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                Udp udp = new Udp(this, name, enlaceport, port, nodoPrincipalModem);
                listUdpConnectorsModem.Add(udp);
                udp.beginServer();
            }
        }

        public void beginUdpClientModem()
        {
            XmlNodeList listaClients = c._ReadXml(nodoPrincipalModem, "Udp", "UdpClient", "Client");

            XmlNode client;

            // udpClient;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                string ip = client.SelectSingleNode("IpAdress").InnerText;
                string enlaceport = client.SelectSingleNode("EnlacePort").InnerText;
                string port = client.SelectSingleNode("DestinationPort").InnerText;

                UdpClients udpClient = new UdpClients(this, name, ip, enlaceport, port, nodoPrincipalModem);
                listUdpClientsConnectorsModem.Add(udpClient);
                udpClient.beginClient();
            }
        }

        Boolean tcpClientM= false;
        public void beginTcpClientModem()
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

                TcpClients tcpClients = new TcpClients(this, name, ip, port, nodoPrincipalModem);
                listTcpClientsConnectorsModem.Add(tcpClients);
                if (tcpClients.beginTcp())
                {
                    tcpClientM = true;
                }
            }

            if (!tcpClientM)
            {
                setColorOffM();
            }
        }

        public void beginTcpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml(nodoPrincipalModem, "Tcp", "TcpServer", "Server");

            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                Tcp tcp = new Tcp(this, name, port, nodoPrincipalModem);
                listTcpConnectorsModem.Add(tcp);
                tcp.cargarTcpServer();
            }
        }

        #endregion


        public void reciveToSendServer(Byte[] msg, string name,string type)
        {
            string mensaje = "\n"+type + " " + name + ": " + BitConverter.ToString(msg) + "\n";

            this.formServer.Mensajes(mensaje);

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
            }
        }

        public void reciveToSendModem(Byte[] msg, string name, string type)
        {
            string mensaje = type + " " + name + ": " + BitConverter.ToString(msg) + "\n";
            formServer.Mensajes(mensaje);

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
            }
        }

        public void reciveToSendTcpServer(Byte[] msg, string name, string type,string id)
        {

            string mensaje = "\n"+type + " " + name + ": " + BitConverter.ToString(msg).Remove(75) + "\n";
            formServer.Mensajes(mensaje);

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
            }
        }

        public void reciveToSendTcpModem(Byte[] msg, string name, string type,string id)
        {

            string mensaje = type + " " + name + ": " + BitConverter.ToString(msg).Remove(75) + "\n";
            formServer.Mensajes(mensaje);

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
            }
        }

        #region Close Coneccion
        public void closeUdpClientS()
        {
            for (int x = 0; x< listUdpClientsConnectors.Count; x++)
            {
                listUdpClientsConnectors[x].CloseUdp();
            }
        }

        public void closeUdpServerS()
        {
            for (int x = 0; x < listUdpConnectors.Count; x++)
            {
                listUdpConnectors[x].CloseUdp();
            }
        }

        public void closeTcpClientS()
        {
            for (int x = 0; x < listTcpClientsConnectors.Count; x++)
            {
                listTcpClientsConnectors[x].CloseTcp();
            }
        }

        public void closeTcpServerS()
        {
            for (int x = 0; x < listTcpConnectors.Count; x++)
            {
                listTcpConnectors[x].CloseTcp();
            }
        }


        public void closeUdpClientM()
        {
            for (int x = 0; x < listUdpClientsConnectorsModem.Count; x++)
            {
                listUdpClientsConnectorsModem[x].CloseUdp();
            }
        }

        public void closeUdpServerM()
        {
            for (int x = 0; x < listUdpConnectorsModem.Count; x++)
            {
                listUdpConnectorsModem[x].CloseUdp();
            }
        }

        public void closeTcpClientM()
        {
            for (int x = 0; x < listTcpClientsConnectorsModem.Count; x++)
            {
                listTcpClientsConnectorsModem[x].CloseTcp();
            }
        }

        public void closeTcpServerM()
        {
            for (int x = 0; x < listTcpConnectorsModem.Count; x++)
            {
                listTcpConnectorsModem[x].CloseTcp();
            }
        }

        #endregion

        public void setColorOff()
        {
            formServer.setColorOff(formServer.btnTcpClientServer);
            formServer.onbtnTcpClientServer = false;
        }

        public void setColorOffM()
        {
            formServer.setColorOff(formServer.btnTcpClientModem);
            formServer.onbtnTcpClientModem = false;
        }
    }
}
