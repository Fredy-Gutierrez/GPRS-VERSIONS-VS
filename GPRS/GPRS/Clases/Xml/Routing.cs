using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GPRS.Clases
{
    public class Routing
    {
        XmlDocument doc = new XmlDocument();

        string rutaXml = @"C:\GPRS\Data\Routing.xml";

        string rutaDir = @"C:\GPRS\Data\";

        private String nodoPrincipal = "Routing";

        XmlNode configuration;

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

        public void _Add(string servername, string servertype, string modemname, string modemtype, string idserver,string idmodem)
        {
            bool action = false;
            while (!action) {
                try
                {
                    doc.Load(rutaXml);

                    XmlNode newNodo = null;
                    XmlNode nodoRaiz = null;

                    newNodo = _Create(servername, servertype, modemname, modemtype, idserver, idmodem);
                    nodoRaiz = doc.DocumentElement;
                    nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
                    doc.Save(rutaXml);
                    action = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }
            Console.WriteLine("****************************AGREGADO");
        }

        private XmlNode _Create(string ServerName, string ServerType, string ModemName, string ModemType,string idServer, string idModem)
        {

            XmlNode route = doc.CreateElement("Route");


            XmlElement sname = doc.CreateElement("ServerName");
            sname.InnerText = ServerName;
            route.AppendChild(sname);


            XmlElement stype = doc.CreateElement("ServerType");
            stype.InnerText = ServerType;
            route.AppendChild(stype);


            XmlElement mname = doc.CreateElement("ModemName");
            mname.InnerText = ModemName;
            route.AppendChild(mname);

            XmlElement mtype = doc.CreateElement("ModemType");
            mtype.InnerText = ModemType;
            route.AppendChild(mtype);

            XmlElement idserver = doc.CreateElement("IdServer");
            idserver.InnerText = idServer;
            route.AppendChild(idserver);

            XmlElement idmodem = doc.CreateElement("IdModem");
            idmodem.InnerText = idModem;
            route.AppendChild(idmodem);

            return route;
        }

        public Boolean _FindNodoBeforeDelete(string sname, string stype, string mname,string mtype,string idserver,string idmodem )
        {
            bool action = false;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);
                    XmlNodeList list = doc.SelectNodes(nodoPrincipal + "/Route");

                    foreach (XmlNode item in list)
                    {
                        if (item.SelectSingleNode("ServerName").InnerText == sname && item.SelectSingleNode("ServerType").InnerText == stype &&
                            item.SelectSingleNode("ModemName").InnerText == mname && item.SelectSingleNode("ModemType").InnerText == mtype &&
                            item.SelectSingleNode("IdServer").InnerText == idserver && item.SelectSingleNode("IdModem").InnerText == idmodem)
                        {
                            return true;
                        }
                    }
                    action = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            return false;
        }

        public void _DeleteNodo(string sname, string stype, string mname, string mtype, string idserver, string idmodem)
        {
            bool action = false;
            int intent = 0;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);

                    XmlNode nododel = doc.DocumentElement;

                    XmlNodeList listNodos = doc.SelectNodes(nodoPrincipal + "/Route");

                    foreach (XmlNode item in listNodos)
                    {

                        if (item.SelectSingleNode("ServerName").InnerText == sname && item.SelectSingleNode("ServerType").InnerText == stype &&
                            item.SelectSingleNode("ModemName").InnerText == mname && item.SelectSingleNode("ModemType").InnerText == mtype &&
                            item.SelectSingleNode("IdServer").InnerText == idserver && item.SelectSingleNode("IdModem").InnerText == idmodem)
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
                    if (intent>5)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }
        }

        public XmlNodeList _ReadXml()
        {
            bool action = false;
            int intent = 0;
            XmlNodeList listNodos = null;
            while (!action)
            {
                try
                {
                    doc.Load(rutaXml);

                    listNodos = doc.SelectNodes(nodoPrincipal + "/Route");

                    action = true;
                }
                catch (Exception ex)
                {
                    if (intent > 5)
                    {
                        action = true;
                    }
                    intent++;
                    Console.WriteLine(ex.Message.ToString());
                }
            }

            return listNodos;
        }
    }
}
