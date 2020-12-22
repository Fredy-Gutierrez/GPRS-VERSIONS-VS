using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GPRS.Clases
{
    public class XmlConnection
    {
        readonly XmlDocument doc = new XmlDocument();

        readonly string rutaXml = @"C:\GPRS\Data\XmlConnections.xml";

        readonly string rutaDir = @"C:\GPRS\Data\";

        private readonly string nodoPrincipal = "Connections";

        private XmlNode configuration;

        public void _CreateXml()
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

                doc.Save(rutaXml);
            }
        }

        public void _Add(string ip, string hour)
        {
            doc.Load(rutaXml);
            XmlNode newNodo = _Create(ip,hour);
            XmlNode nodoRaiz = doc.DocumentElement;
            nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
            doc.Save(rutaXml);
        }

        private XmlNode _Create(string ip, string hour)
        {

            XmlNode route = doc.CreateElement("Connection");


            XmlElement sip = doc.CreateElement("IpAdress");
            sip.InnerText = ip;
            route.AppendChild(sip);


            XmlElement shour = doc.CreateElement("Hour");
            shour.InnerText = hour;
            route.AppendChild(shour);

            return route;
        }

        public XmlNodeList _ReadXml()
        {

            doc.Load(rutaXml);

            XmlNodeList listNodos = doc.SelectNodes(nodoPrincipal + "/Connection");

            return listNodos;

        }

    }
}
