using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GPRS.Clases
{
    public class UsersXml
    {
        readonly XmlDocument doc = new XmlDocument();

        readonly string rutaXml = @"C:\GPRS\Data\Users.xml";

        readonly string rutaDir = @"C:\GPRS\Data\";

        private readonly string nodoPrincipal = "Users";

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

        public void _Add(string name, string email, string user, string password)
        {
            doc.Load(rutaXml);
            XmlNode newNodo = _Create(name,email,user,password);
            XmlNode nodoRaiz = doc.DocumentElement;
            nodoRaiz.InsertAfter(newNodo, nodoRaiz.LastChild);
            doc.Save(rutaXml);
        }

        private XmlNode _Create(string name, string email, string user, string password)
        {

            XmlNode route = doc.CreateElement("User");


            XmlElement sname = doc.CreateElement("Name");
            sname.InnerText = name;
            route.AppendChild(sname);


            XmlElement semail = doc.CreateElement("Email");
            semail.InnerText = email;
            route.AppendChild(semail);


            XmlElement suser = doc.CreateElement("UserName");
            suser.InnerText = user;
            route.AppendChild(suser);

            XmlElement spassword = doc.CreateElement("Password");
            spassword.InnerText = password;
            route.AppendChild(spassword);

            return route;
        }

        public bool _FindNodo(string sname)
        {
            doc.Load(rutaXml);
            XmlNodeList list = doc.SelectNodes(nodoPrincipal + "/User");

            foreach (XmlNode item in list)
            {
                if (item.SelectSingleNode("UserName").InnerText == sname)
                {
                    return true;
                }
            }
            return false;
        }

        public void _DeleteNodo(string sname)
        {
            doc.Load(rutaXml);

            XmlNode nododel = doc.DocumentElement;

            XmlNodeList listNodos = doc.SelectNodes(nodoPrincipal + "/User");

            foreach (XmlNode item in listNodos)
            {
                if (item.SelectSingleNode("UserName").InnerText == sname)
                {
                    XmlNode nodoOld = item;

                    nododel.RemoveChild(nodoOld);
                }
            }
            doc.Save(rutaXml);
        }

        public XmlNodeList _ReadXml()
        {

            doc.Load(rutaXml);

            XmlNodeList listNodos = doc.SelectNodes(nodoPrincipal + "/User");

            return listNodos;

        }

        public void _Update(string name, string email, string user, string password)
        {
            XmlNode users = doc.DocumentElement;

            XmlNodeList listUsers = doc.SelectNodes(nodoPrincipal + "/User");
            
            XmlNode nuevo_user = _Create(name, email, user, password);

            foreach (XmlNode item in listUsers)
            {
                if (item.SelectSingleNode("UserName").InnerText == user)
                {
                    XmlNode nodoOld = item;
                    users.ReplaceChild(nuevo_user, nodoOld);
                }
            }

            doc.Save(rutaXml);
        }
    }
}
