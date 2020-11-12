using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GPRS.Clases
{
    public class Configurations
    {
        XmlDocument doc = new XmlDocument();

        string rutaXml = @"C:\GPRS\Data\Configuration.xml";

        string rutaDir = @"C:\GPRS\Data\";

        private String nodoPrincipal = "Configuration";

        XmlNode configuration;
 

        public void _createXml()
        {

            if (!Directory.Exists(rutaDir))
            {
                Directory.CreateDirectory(rutaDir);
            }

            if (!File.Exists(rutaXml))
            {
                XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);

                XmlNode root = doc.DocumentElement;
                doc.InsertBefore(xmlDeclaration, root);


                configuration = doc.CreateElement(nodoPrincipal);
                doc.AppendChild(configuration);

                XmlElement servers = doc.CreateElement(String.Empty, "Servers", String.Empty);
                configuration.AppendChild(servers);

                XmlElement modems = doc.CreateElement(String.Empty, "Modems", String.Empty);
                configuration.AppendChild(modems);

                XmlElement udp = doc.CreateElement(String.Empty, "Udp", String.Empty);
                servers.AppendChild(udp);

                XmlElement tcp = doc.CreateElement(String.Empty, "Tcp", String.Empty);
                servers.AppendChild(tcp);


                XmlElement udpm = doc.CreateElement(String.Empty, "Udp", String.Empty);
                modems.AppendChild(udpm);

                XmlElement tcpm = doc.CreateElement(String.Empty, "Tcp", String.Empty);
                modems.AppendChild(tcpm);


                XmlElement udpClient = doc.CreateElement(String.Empty, "UdpClient", String.Empty);
                servers.SelectSingleNode("Udp").AppendChild(udpClient);
                XmlElement udpClientm = doc.CreateElement(String.Empty, "UdpClient", String.Empty);
                modems.SelectSingleNode("Udp").AppendChild(udpClientm);


                XmlElement udpServer = doc.CreateElement(String.Empty, "UdpServer", String.Empty);
                servers.SelectSingleNode("Udp").AppendChild(udpServer);
                XmlElement udpServerm = doc.CreateElement(String.Empty, "UdpServer", String.Empty);
                modems.SelectSingleNode("Udp").AppendChild(udpServerm);



                XmlElement tcpClient = doc.CreateElement(String.Empty, "TcpClient", String.Empty);
                servers.SelectSingleNode("Tcp").AppendChild(tcpClient);
                XmlElement tcpClientm = doc.CreateElement(String.Empty, "TcpClient", String.Empty);
                modems.SelectSingleNode("Tcp").AppendChild(tcpClientm);

                XmlElement tcpServer = doc.CreateElement(String.Empty, "TcpServer", String.Empty);
                servers.SelectSingleNode("Tcp").AppendChild(tcpServer);
                XmlElement tcpServerm = doc.CreateElement(String.Empty, "TcpServer", String.Empty);
                modems.SelectSingleNode("Tcp").AppendChild(tcpServerm);

                doc.Save(rutaXml);
            }
        }

        public void _Add(string name, string ip, string port,string enlaceport,string destinationport,String nodoP,String nodoS, String nodoT)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);

                    XmlNode newNodo = null;
                    XmlNode nodoRaiz = null;

                    switch (nodoP)
                    {
                        case "Servers":
                            switch (nodoS)
                            {
                                case "Udp":
                                    switch (nodoT)
                                    {
                                        case "UdpClient":
                                            if (_FindUdpClient(name, nodoP))
                                            {
                                                _UpdateUdpClient(name, ip, enlaceport, destinationport, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Udp_Client(name, ip, enlaceport, destinationport, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }

                                            break;
                                        case "UdpServer":
                                            if (_FindUdpServer(name, nodoP))
                                            {
                                                _UpdateUdpServer(name, enlaceport, destinationport, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Udp_Server(name, enlaceport, destinationport, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }
                                            break;
                                    }
                                    break;
                                case "Tcp":
                                    switch (nodoT)
                                    {
                                        case "TcpClient":
                                            if (_FindTcpClient(name, nodoP))
                                            {
                                                _UpdateTcpClient(name, ip, port, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Tcp_Client(name, ip, port, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }

                                            break;
                                        case "TcpServer":
                                            if (_FindTcpServer(name, nodoP))
                                            {
                                                _UpdateTcpServer(name, port, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Tcp_Server(name, port, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }

                                            break;
                                    }
                                    break;
                            }
                            break;
                        case "Modems":
                            switch (nodoS)
                            {
                                case "Udp":
                                    switch (nodoT)
                                    {
                                        case "UdpClient":
                                            if (_FindUdpClient(name, nodoP))
                                            {
                                                _UpdateUdpClient(name, ip, enlaceport, destinationport, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Udp_Client(name, ip, enlaceport, destinationport, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }
                                            break;
                                        case "UdpServer":
                                            if (_FindUdpServer(name, nodoP))
                                            {
                                                _UpdateUdpServer(name, enlaceport, destinationport, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Udp_Server(name, enlaceport, destinationport, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }
                                            break;
                                    }
                                    break;
                                case "Tcp":
                                    switch (nodoT)
                                    {
                                        case "TcpClient":
                                            if (_FindTcpClient(name, nodoP))
                                            {
                                                _UpdateTcpClient(name, ip, port, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Tcp_Client(name, ip, port, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }
                                            break;
                                        case "TcpServer":
                                            if (_FindTcpServer(name, nodoP))
                                            {
                                                _UpdateTcpServer(name, port, nodoP, "Inactivo");
                                            }
                                            else
                                            {
                                                newNodo = _Create_Tcp_Server(name, port, "Inactivo");
                                                nodoRaiz = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode(nodoS).SelectSingleNode(nodoT);
                                                nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                                                doc.Save(rutaXml);
                                            }

                                            break;
                                    }
                                    break;
                            }
                            break;

                    }
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            //XmlNode newNodo = _Create_Udp_Client(name,ip,port);


        }

        /// <summary>
        /// ¡No borrar!, estas son regiones de codigos escenciales para la creacion de nodos del archivo xml de configuraciones, cualquier cambio o eliminacion de estos
        /// se verá reflejado en todo el apartado de comunicaciones del sistema, por lo que no es recomendable hacer cambio del codigo a menos que se tenga un conocimiento
        /// previo de todo el sistema, así mismo conocer que se deberá modificar en la aplicacion una vez hechos los cambios en esta clase.
        /// Nota: Futuro programador, al momento de la creación de este código, solo Dios y Yo sabíamos como funcionaba, al momento que estes leyendo esto es muy probable
        /// que solo Dios sepa como funciona XD...
        /// </summary>

        #region create
        private XmlNode _Create_Udp_Client( string name, string ip, string port,string destinationport,string status)
        {

            XmlNode client = doc.CreateElement("Client");


            XmlElement xname = doc.CreateElement("Name");
            xname.InnerText = name;
            client.AppendChild(xname);


            XmlElement xip = doc.CreateElement("IpAdress");
            xip.InnerText = ip;
            client.AppendChild(xip);


            XmlElement xport = doc.CreateElement("EnlacePort");
            xport.InnerText = port;
            client.AppendChild(xport);

            XmlElement xdestinationport = doc.CreateElement("DestinationPort");
            xdestinationport.InnerText = destinationport;
            client.AppendChild(xdestinationport);

            XmlElement xestado = doc.CreateElement("Status");
            xestado.InnerText = status;
            client.AppendChild(xestado);

            return client;
        }

        private XmlNode _Create_Udp_Server(string name, string enlaceport, string destinationport, string status)
        {

            XmlNode server = doc.CreateElement("Server");


            XmlElement xname = doc.CreateElement("Name");
            xname.InnerText = name;
            server.AppendChild(xname);


            XmlElement xenlaceport = doc.CreateElement("EnlacePort");
            xenlaceport.InnerText = enlaceport;
            server.AppendChild(xenlaceport);


            XmlElement xdestinationport = doc.CreateElement("DestinationPort");
            xdestinationport.InnerText = destinationport;
            server.AppendChild(xdestinationport);

            XmlElement xestado = doc.CreateElement("Status");
            xestado.InnerText = status;
            server.AppendChild(xestado);

            return server;
        }

        private XmlNode _Create_Tcp_Client(string name, string ip, string port,string status)
        {

            XmlNode client = doc.CreateElement("Client");


            XmlElement xname = doc.CreateElement("Name");
            xname.InnerText = name;
            client.AppendChild(xname);


            XmlElement xip = doc.CreateElement("IpAdress");
            xip.InnerText = ip;
            client.AppendChild(xip);


            XmlElement xport = doc.CreateElement("Port");
            xport.InnerText = port;
            client.AppendChild(xport);

            XmlElement xestado = doc.CreateElement("Status");
            xestado.InnerText = status;
            client.AppendChild(xestado);

            return client;
        }

        private XmlNode _Create_Tcp_Server(string name, string port, string status)
        {

            XmlNode server = doc.CreateElement("Server");


            XmlElement xname = doc.CreateElement("Name");
            xname.InnerText = name;
            server.AppendChild(xname);


            XmlElement xport = doc.CreateElement("Port");
            xport.InnerText = port;
            server.AppendChild(xport);

            XmlElement xestado = doc.CreateElement("Status");
            xestado.InnerText = status;
            server.AppendChild(xestado);

            return server;
        }
        #endregion

        #region Update
        public void _UpdateUdpClient(string name, string ip, string port,string destinationport,string nodoP,string status)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNode udpclient = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode("Udp").SelectSingleNode("UdpClient");

                    XmlNodeList listClientUdp = doc.SelectNodes(nodoPrincipal+"/"+nodoP+"/Udp/UdpClient/Client");
                    XmlNode nuevo_ClientUdp = _Create_Udp_Client(name,ip,port,destinationport, status);

                    foreach (XmlNode item in listClientUdp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            XmlNode nodoOld = item;
                            udpclient.ReplaceChild(nuevo_ClientUdp, nodoOld);
                        }
                    }
                    doc.Save(rutaXml);
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }

        }

        public void _UpdateUdpServer(string name, string enlaceport, string destinationport, string nodoP,string status)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNode udpserver = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode("Udp").SelectSingleNode("UdpServer");
                    XmlNodeList listServerUdp = doc.SelectNodes(nodoPrincipal + "/" + nodoP + "/Udp/UdpServer/Server");
                    XmlNode nuevo_ServerUdp = _Create_Udp_Server(name, enlaceport, destinationport, status);

                    foreach (XmlNode item in listServerUdp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            XmlNode nodoOld = item;
                            udpserver.ReplaceChild(nuevo_ServerUdp, nodoOld);
                        }
                    }

                    doc.Save(rutaXml);
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        public void _UpdateTcpClient(string name, string ip, string port, string nodoP,string status)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNode tcpclient = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode("Tcp").SelectSingleNode("TcpClient");
                    XmlNodeList listClientTcp = doc.SelectNodes(nodoPrincipal + "/" + nodoP + "/Tcp/TcpClient/Client");
                    XmlNode nuevo_ClientTcp = _Create_Tcp_Client(name, ip, port,status);

                    foreach (XmlNode item in listClientTcp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            XmlNode nodoOld = item;
                            tcpclient.ReplaceChild(nuevo_ClientTcp, nodoOld);
                        }
                    }
                    doc.Save(rutaXml);
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        public void _UpdateTcpServer(string name, string port,string nodoP, string status)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNode tcpserver = doc.DocumentElement.SelectSingleNode(nodoP).SelectSingleNode("Tcp").SelectSingleNode("TcpServer"); ;
            
                    XmlNodeList listServerUdp = doc.SelectNodes(nodoPrincipal + "/" + nodoP + "/Tcp/TcpServer/Server");
            
                    XmlNode nuevo_ServerTcp = _Create_Tcp_Server(name, port,status);

                    foreach (XmlNode item in listServerUdp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            XmlNode nodoOld = item;
                            tcpserver.ReplaceChild(nuevo_ServerTcp, nodoOld);
                        }
                    }
                    doc.Save(rutaXml);
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }
        #endregion

        #region Find
        public Boolean _FindUdpClient(string name, string nodoP)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNodeList listClientUdp = doc.SelectNodes(nodoPrincipal + "/" + nodoP + "/Udp/UdpClient/Client");
            
                    foreach (XmlNode item in listClientUdp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            return true;
                        }
                    }
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return false;
        }

        public Boolean _FindUdpServer(string name, string nodoP)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNodeList listServerUdp = doc.SelectNodes(nodoPrincipal + "/" + nodoP + "/Udp/UdpServer/Server");

                    foreach (XmlNode item in listServerUdp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            return true;
                        }
                    }
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            return false;
        }

        public Boolean _FindTcpClient(string name, string nodoP)
        {

            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNodeList listClientTcp = doc.SelectNodes(nodoPrincipal + "/" + nodoP + "/Tcp/TcpClient/Client");

                    foreach (XmlNode item in listClientTcp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            return true;
                        }
                    }
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            
            return false;
        }

        public Boolean _FindTcpServer(string name, string nodoP)
        {
            int intent = 0;
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNodeList listServerTcp = doc.SelectNodes(nodoPrincipal + "/" + nodoP + "/Tcp/TcpServer/Server");

                    foreach (XmlNode item in listServerTcp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            return true;
                        }
                    }
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            return false;
        }
        #endregion

        public XmlNodeList _ReadXml(string nodop, string nodos, string nodot, string nodoc)
        {
            int intent = 0;
            bool action = false;
            XmlNodeList listNodos = null;

            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);

                    listNodos = doc.SelectNodes(nodoPrincipal+"/"+nodop+"/"+nodos+"/"+nodot+"/"+nodoc);

                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            return listNodos;

        }


        public void _DeleteNodo(string name,string nodop, string nodos, string nodot,string nodoc)
        {
            int intent = 0;
            bool action = false;
            XmlNodeList listNodos = null;

            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);

                    XmlNode nododel = doc.DocumentElement.SelectSingleNode(nodop).SelectSingleNode(nodos).SelectSingleNode(nodot);

                    listNodos = doc.SelectNodes(nodoPrincipal+"/"+nodop+"/"+nodos+"/"+nodot+"/"+nodoc);

                    foreach (XmlNode item in listNodos)
                    {

                        if (item.SelectSingleNode("Name").InnerText == name)
                        {

                            XmlNode nodoOld = item;

                            nododel.RemoveChild(nodoOld);
                        }
                    }

                    doc.Save(rutaXml);
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        public Boolean _FindNodoBeforeDelete(string name,string nodop,string nodos,string nodot,string nodoc)
        {
            int intent = 0;
            bool action = false;

            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNodeList listServerTcp = doc.SelectNodes(nodoPrincipal + "/" + nodop + "/"+nodos+"/"+nodot+"/"+nodoc);

                    foreach (XmlNode item in listServerTcp)
                    {
                        if (item.FirstChild.InnerText == name)
                        {
                            return true;
                        }
                    }
                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 3)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            return false;
        }
    }
}
