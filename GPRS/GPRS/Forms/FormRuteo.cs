using GPRS.Clases;
using GPRS.Forms.Messages;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GPRS.Forms
{
    public partial class FormRuteo : Form
    {
        Routing r;
        public FormRuteo()
        {
            InitializeComponent();
        }

        private void FormRuteo_Load(object sender, EventArgs e)
        {
            r = new Routing();
            r._CreateXml();

            chargeTable();
        }

        private void chargeTable()
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

                tablaRuteo.Rows.Add(sname, stype, mname, mtype,idserver,idmodem);
            }
        }

        private void FormRuteo_Resize(object sender, EventArgs e)
        {
            int ancho = Size.Width;

            double nancho = ancho - 190;

            tablaRuteo.Width = (int)nancho;
            tablaRuteo.Height = Size.Height / 2;

            int x = tablaRuteo.Location.X;

            int rutaboton = x + (int)nancho + 5;

            int y = btnDelete.Location.Y;

            btnDelete.Location = new Point(rutaboton,y) ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string idserver = string.Empty;
            string idmodem = string.Empty;
            if (cbNameS.SelectedItem == null || cbConeccionS.SelectedItem == null || cbNameS.SelectedItem == null ||
                cbNameM.SelectedItem == null || cbConeccionM.SelectedItem == null || cbNameM.SelectedItem == null)
            {
                Alerts.ShowInformation("Debe seleccionar todos los campos,\n son necesarios");
            }
            else
            {
                string sname = cbNameS.SelectedItem.ToString();
                string stype = convertNodoName(cbConeccionS.SelectedItem.ToString()) + convertNodoName(cbTypeS.SelectedItem.ToString());
                string mname = cbNameM.SelectedItem.ToString();
                string mtype = convertNodoName(cbConeccionM.SelectedItem.ToString()) + convertNodoName(cbTypeM.SelectedItem.ToString());
                
                idserver = txtIdServer.Text;
                idmodem = txtIdModem.Text; 
                
                r._Add(sname, stype, mname, mtype,idserver,idmodem);
                tablaRuteo.Rows.Add(sname, stype, mname, mtype, idserver, idmodem);

                txtIdServer.Text = "";
                txtIdModem.Text = "";
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tablaRuteo.CurrentRow.Selected)
            {
                try
                {
                    if (Alerts.ShowWarning("¿Seguro deseas eliminar esta fila?"))
                    {
                        
                        string serverName = tablaRuteo.Rows[tablaRuteo.CurrentRow.Index].Cells["ServerName"].Value.ToString();
                        string serverType = tablaRuteo.Rows[tablaRuteo.CurrentRow.Index].Cells["ServerType"].Value.ToString();
                        string modemName = tablaRuteo.Rows[tablaRuteo.CurrentRow.Index].Cells["ModemName"].Value.ToString();
                        string modemType = tablaRuteo.Rows[tablaRuteo.CurrentRow.Index].Cells["ModemType"].Value.ToString();

                        string serverid = tablaRuteo.Rows[tablaRuteo.CurrentRow.Index].Cells["IdServer"].Value.ToString();
                        string modemid = tablaRuteo.Rows[tablaRuteo.CurrentRow.Index].Cells["IdModem"].Value.ToString();


                        if (r._FindNodoBeforeDelete(serverName,serverType,modemName,modemType,serverid,modemid))
                        {
                            r._DeleteNodo(serverName, serverType, modemName, modemType, serverid, modemid);
                            Alerts.ShowSuccess("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar");
                        }

                        tablaRuteo.Rows.Remove(tablaRuteo.CurrentRow);
                    }

                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                    Alerts.ShowError("Esta fila no se puede eliminar");
                }
            }
            else
            {
                Alerts.ShowInformation("Seleccione la fila que desea eliminar");
            }
        }

        private void cbTypeS_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblIdServer.Visible = false;
            txtIdServer.Visible = false;

            if (cbConeccionS.SelectedItem != null)
            {
                Configurations c = new Configurations();
                XmlNodeList listxml = null;

                if (cbConeccionS.SelectedItem.ToString().Equals("UDP") && cbTypeS.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Servers", "Udp", "UdpClient", "Client");
                }
                else if (cbConeccionS.SelectedItem.ToString().Equals("UDP") && cbTypeS.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Servers", "Udp", "UdpServer", "Server");
                }
                else if (cbConeccionS.SelectedItem.ToString().Equals("TCP") && cbTypeS.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Servers", "Tcp", "TcpClient", "Client");
                }
                else if (cbConeccionS.SelectedItem.ToString().Equals("TCP") && cbTypeS.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Servers", "Tcp", "TcpServer", "Server");

                    lblIdServer.Visible = true;
                    txtIdServer.Visible = true;
                }

                XmlNode list;

                // udpClient;
                cbNameS.Items.Clear();

                for (int i = 0; i < listxml.Count; i++)
                {
                    list = listxml.Item(i);

                    string name = list.SelectSingleNode("Name").InnerText;

                    cbNameS.Items.Add(name);
                }
            }
        }

        private void cbConeccionS_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdServer.Visible = false;
            txtIdServer.Visible = false;
            if (cbTypeS.SelectedItem != null)
            {
                Configurations c = new Configurations();
                XmlNodeList listxml = null;

                if (cbConeccionS.SelectedItem.ToString().Equals("UDP") && cbTypeS.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Servers", "Udp", "UdpClient", "Client");
                }
                else if (cbConeccionS.SelectedItem.ToString().Equals("UDP") && cbTypeS.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Servers", "Udp", "UdpServer", "Server");
                }
                else if (cbConeccionS.SelectedItem.ToString().Equals("TCP") && cbTypeS.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Servers", "Tcp", "TcpClient", "Client");
                }
                else if (cbConeccionS.SelectedItem.ToString().Equals("TCP") && cbTypeS.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Servers", "Tcp", "TcpServer", "Server");

                    lblIdServer.Visible = true;
                    txtIdServer.Visible = true;
                }

                XmlNode list;

                cbNameS.Items.Clear();
                // udpClient;

                for (int i = 0; i < listxml.Count; i++)
                {
                    list = listxml.Item(i);

                    string name = list.SelectSingleNode("Name").InnerText;

                    cbNameS.Items.Add(name);
                }
            }
            
        }


        private void cbConeccionM_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdModem.Visible = false;
            txtIdModem.Visible = false;
            if (cbTypeM.SelectedItem != null)
            {
                Configurations c = new Configurations();
                XmlNodeList listxml = null;

                if (cbConeccionM.SelectedItem.ToString().Equals("UDP") && cbTypeM.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Modems", "Udp", "UdpClient", "Client");
                }
                else if (cbConeccionM.SelectedItem.ToString().Equals("UDP") && cbTypeM.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Modems", "Udp", "UdpServer", "Server");
                }
                else if (cbConeccionM.SelectedItem.ToString().Equals("TCP") && cbTypeM.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Modems", "Tcp", "TcpClient", "Client");
                }
                else if (cbConeccionM.SelectedItem.ToString().Equals("TCP") && cbTypeM.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Modems", "Tcp", "TcpServer", "Server");
                    lblIdModem.Visible = true;
                    txtIdModem.Visible = true;
                }

                XmlNode list;

                cbNameM.Items.Clear();
                // udpClient;

                for (int i = 0; i < listxml.Count; i++)
                {
                    list = listxml.Item(i);

                    string name = list.SelectSingleNode("Name").InnerText;

                    cbNameM.Items.Add(name);
                }
            }
        }

        private void cbTypeM_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIdModem.Visible = false;
            txtIdModem.Visible = false;
            if (cbConeccionM.SelectedItem != null)
            {
                Configurations c = new Configurations();
                XmlNodeList listxml = null;

                if (cbConeccionM.SelectedItem.ToString().Equals("UDP") && cbTypeM.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Modems", "Udp", "UdpClient", "Client");
                }
                else if (cbConeccionM.SelectedItem.ToString().Equals("UDP") && cbTypeM.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Modems", "Udp", "UdpServer", "Server");
                }
                else if (cbConeccionM.SelectedItem.ToString().Equals("TCP") && cbTypeM.SelectedItem.ToString().Equals("CLIENTE"))
                {
                    listxml = c._ReadXml("Modems", "Tcp", "TcpClient", "Client");
                }
                else if (cbConeccionM.SelectedItem.ToString().Equals("TCP") && cbTypeM.SelectedItem.ToString().Equals("SERVIDOR"))
                {
                    listxml = c._ReadXml("Modems", "Tcp", "TcpServer", "Server");
                    lblIdModem.Visible = true;
                    txtIdModem.Visible = true;                    
                }

                XmlNode list;

                cbNameM.Items.Clear();
                // udpClient;

                for (int i = 0; i < listxml.Count; i++)
                {
                    list = listxml.Item(i);

                    string name = list.SelectSingleNode("Name").InnerText;

                    cbNameM.Items.Add(name);
                }
            }
        }

        private string convertNodoName(string str)
        {
            switch (str)
            {
                case "UDP":
                    return "Udp";
                case "TCP":
                    return "Tcp";
                case "CLIENTE":
                    return "Client";
                case "SERVIDOR":
                    return "Server";
            }
            return "";
        }
    }
}
