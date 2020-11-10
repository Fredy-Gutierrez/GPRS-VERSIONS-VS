using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GPRS.Clases.Xml.SocketsMessages
{
    public class TcpServerMessages
    {
        XmlDocument doc = new XmlDocument();

        string rutaXml = @"C:\GPRS\Data\Messages\TcpServer.xml";

        string rutaDir = @"C:\GPRS\Data\Messages\";

        private String nodoPrincipal = "Messages";

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

                doc.Save(rutaXml);
            }
        }

        public void _Add(string name, string msg, string ip, string date, string hour, string node)
        {
            doc.Load(rutaXml);
            XmlNode newNodo = _Create(name, msg, ip, date, hour);
            XmlNode nodoRaiz = doc.DocumentElement.SelectSingleNode(node);
            nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
            doc.Save(rutaXml);
        }

        private XmlNode _Create(string name, string msg, string ip, string date, string hour)
        {

            XmlNode route = doc.CreateElement("Message");

            XmlElement sname = doc.CreateElement("Name");
            sname.InnerText = name;
            route.AppendChild(sname);

            XmlElement smsg = doc.CreateElement("MessageRecived");
            smsg.InnerText = msg;
            route.AppendChild(smsg);

            XmlElement sip = doc.CreateElement("Ip");
            sip.InnerText = ip;
            route.AppendChild(sip);

            XmlElement sdate = doc.CreateElement("Date");
            sdate.InnerText = date;
            route.AppendChild(sdate);


            XmlElement shour = doc.CreateElement("Hour");
            shour.InnerText = hour;
            route.AppendChild(shour);

            return route;
        }

        public XmlNodeList _ReadXml(string node)
        {

            XmlNodeList listNodos = null;
            try
            {
                doc.Load(rutaXml);

                listNodos = doc.SelectNodes(nodoPrincipal + "/" + node + "/Message");
            }
            catch (IOException io)
            {
                Console.WriteLine(io.Message.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return listNodos;

        }
    }
}
