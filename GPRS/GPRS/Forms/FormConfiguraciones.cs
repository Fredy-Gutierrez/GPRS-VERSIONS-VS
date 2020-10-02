using GPRS.Clases;
using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GPRS.Forms
{
    public partial class FormConfiguraciones : Form
    {
        Configurations c;

        public FormConfiguraciones()
        {
            InitializeComponent();
        }

        private void FormConfiguraciones_Load(object sender, EventArgs e)
        {
            c = new Configurations();

            c._createXml();

            chargeAllTable();
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {    /*90F degradado vertical
             *45F degradado Horizontal*/
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(panelTitleBar.ClientRectangle, Color.FromArgb(20,20,20), Color.Gray, 90F);

            e.Graphics.FillRectangle(linearGradientBrush, panelTitleBar.ClientRectangle);
        }

        private void FormConfiguraciones_Resize(object sender, EventArgs e)
        {
            int ancho = Size.Width;
            panel1.Width =  ancho / 2;

            Rectangle r = panel1.ClientRectangle;

            int c = r.Width / 2;

            lblInfoConexion.Location = new Point(c - lblInfoConexion.Width / 2, lblInfoConexion.Location.Y);
        }

#region guardado de las configuraciones

        #region guardardo del lado de los servidores
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            /********************************************VEREIFICA SI EXISTE EL ARCHIVO XML Y SINO LO CREA***************************************************/


            Boolean validacionT = true;
            if (!validarTablas(tablaUdpClient, "UdpClient"))
            {
                validacionT = false;
            }else if (!validarTablas(tablaUDPServer, "UdpServer"))
            {
                validacionT = false;
            }
            else if (!validarTablas(tablaTcpClient, "TcpClient"))
            {
                validacionT = false;
            }
            else if (!validarTablas(tablaTcpServer, "TcpServer"))
            {
                validacionT = false;
            }

            if (!validacionT)
            {
                new Information("Existen tablas incompletas,\n ¡No se guardaran las configuraciones!").ShowDialog();
            }
            else
            {
                if (validarPuertosUdpServer(tablaUDPServer, tablaUdpServerModem, tablaUdpClientModem, tablaTcpServerModem, tablaTcpClientModem) || 
                    validarPuertosUdpClient(tablaUdpClient, tablaUdpServerModem, tablaUdpClientModem, tablaTcpServerModem, tablaTcpClientModem) ||
                    validarPuertosTcpServer(tablaTcpServer, tablaUdpServerModem, tablaUdpClientModem, tablaTcpServerModem, tablaTcpClientModem) ||
                    validarPuertosTcpClient(tablaTcpClient, tablaUdpServerModem, tablaUdpClientModem, tablaTcpServerModem, tablaTcpClientModem))
                {
                    new Information("¡Este puerto ya existe!").ShowDialog();
                }
                else
                {
                    Console.WriteLine("Guardado");
                    guardarTablaUdpClient();
                    guardarTablaUdpServer();
                    guardarTablaTcpClient();
                    guardarTablaTcpServer();
                    new Success("Guardado").ShowDialog();
                }
            }
        }

        private void guardarTablaUdpClient()
        {
            for (int fila = 0; fila < tablaUdpClient.Rows.Count - 1; fila++)
            {
                String name = tablaUdpClient.Rows[fila].Cells["udpClientName"].Value.ToString();
                String ip = tablaUdpClient.Rows[fila].Cells["udpClientIp"].Value.ToString();
                String port = tablaUdpClient.Rows[fila].Cells["udpClientPort"].Value.ToString();
                String destinationport = tablaUdpClient.Rows[fila].Cells["udpClientDestinationPort"].Value.ToString();
                //c._Add_Udp_Client_Server(name,ip,port);
                c._Add(name,ip,"",port,destinationport, "Servers", "Udp", "UdpClient");
            }
        }

        private void guardarTablaUdpServer()
        {
            for (int fila = 0; fila < tablaUDPServer.Rows.Count - 1; fila++)
            {
                String name = tablaUDPServer.Rows[fila].Cells["udpSeverName"].Value.ToString();
                String enlaceport = tablaUDPServer.Rows[fila].Cells["udpServerEnlacePort"].Value.ToString();
                String destinationport = tablaUDPServer.Rows[fila].Cells["udpServerDestinationPort"].Value.ToString();
                
                c._Add(name, "", "", enlaceport, destinationport, "Servers", "Udp", "UdpServer");
            }
        }

        private void guardarTablaTcpClient()
        {
            for (int fila = 0; fila < tablaTcpClient.Rows.Count - 1; fila++)
            {
                String name = tablaTcpClient.Rows[fila].Cells["tcpClientName"].Value.ToString();
                String ip = tablaTcpClient.Rows[fila].Cells["tcpClientIp"].Value.ToString();
                String port = tablaTcpClient.Rows[fila].Cells["tcpClientPort"].Value.ToString();

                c._Add(name, ip, port, "", "", "Servers", "Tcp", "TcpClient");
            }
        }

        private void guardarTablaTcpServer()
        {
            for (int fila = 0; fila < tablaTcpServer.Rows.Count - 1; fila++)
            {
                String name = tablaTcpServer.Rows[fila].Cells["tcpServerName"].Value.ToString();
                String port = tablaTcpServer.Rows[fila].Cells["tcpServerPort"].Value.ToString();
                c._Add(name, "", port, "", "", "Servers", "Tcp", "TcpServer");
            }
        }
        #endregion

        #region guardado de tablas de los modems
        private void btnGuardarModems_Click(object sender, EventArgs e)
        {
            /********************************************VEREIFICA SI EXISTE EL ARCHIVO XML Y SINO LO CREA***************************************************/

            Boolean validacionT = true;
            if (!validarTablas(tablaUdpClientModem, "UdpClientModem"))
            {
                validacionT = false;
            }
            else if (!validarTablas(tablaUdpServerModem, "UdpServerModem"))
            {
                validacionT = false;
            }
            else if (!validarTablas(tablaTcpClientModem, "TcpClientModem"))
            {
                validacionT = false;
            }
            else if (!validarTablas(tablaTcpServerModem, "TcpServerModem"))
            {
                validacionT = false;
            }

            if (!validacionT)
            {
                new Error("Existen tablas incompletas,\n ¡No se guardaran las configuraciones!").ShowDialog();
            }
            else
            {
                if (validarPuertosUdpClientModem(tablaUdpClientModem, tablaUDPServer, tablaUdpClient, tablaTcpServer, tablaTcpClient) ||
                    validarPuertosUdpServerModem(tablaUdpServerModem, tablaUDPServer, tablaUdpClient, tablaTcpServer, tablaTcpClient) ||
                    validarPuertosTcpServerModem(tablaTcpServerModem, tablaUDPServer, tablaUdpClient, tablaTcpServer, tablaTcpClient) ||
                    validarPuertosTcpClientModem(tablaTcpClientModem, tablaUDPServer, tablaUdpClient, tablaTcpServer, tablaTcpClient))
                {
                    new Information("¡Este puerto ya existe!").ShowDialog();
                }
                else
                {
                    Console.WriteLine("Guardado");
                    guardarTablaUdpClientModem();
                    guardarTablaUdpServerModem();
                    guardarTablaTcpClientModem();
                    guardarTablaTcpServerModem();
                    new Success("Guardado").ShowDialog();
                }
            }
        }

        private void guardarTablaUdpClientModem()
        {
            for (int fila = 0; fila < tablaUdpClientModem.Rows.Count - 1; fila++)
            {
                String name = tablaUdpClientModem.Rows[fila].Cells["udpClientNameModem"].Value.ToString();
                String ip = tablaUdpClientModem.Rows[fila].Cells["udpClientIpModem"].Value.ToString();
                String port = tablaUdpClientModem.Rows[fila].Cells["udpClientConexionPortModem"].Value.ToString();
                String destinationport = tablaUdpClientModem.Rows[fila].Cells["udpClientDestinationPortModem"].Value.ToString();
                c._Add(name, ip, "", port, destinationport, "Modems", "Udp", "UdpClient");
            }
        }

        private void guardarTablaUdpServerModem()
        {
            for (int fila = 0; fila < tablaUdpServerModem.Rows.Count - 1; fila++)
            {
                String name = tablaUdpServerModem.Rows[fila].Cells["udpSeverNameModem"].Value.ToString();
                String enlaceport = tablaUdpServerModem.Rows[fila].Cells["udpServerEnlacePortModem"].Value.ToString();
                String destinationport = tablaUdpServerModem.Rows[fila].Cells["udpServerDestinationPortModem"].Value.ToString();
                c._Add(name, "", "", enlaceport, destinationport, "Modems", "Udp", "UdpServer");
            }
        }

        private void guardarTablaTcpClientModem()
        {
            for (int fila = 0; fila < tablaTcpClientModem.Rows.Count - 1; fila++)
            {
                String name = tablaTcpClientModem.Rows[fila].Cells["tcpClientNameModem"].Value.ToString();
                String ip = tablaTcpClientModem.Rows[fila].Cells["tcpClientIpModem"].Value.ToString();
                String port = tablaTcpClientModem.Rows[fila].Cells["tcpClientPortModem"].Value.ToString();
                c._Add(name, ip, port, "", "", "Modems", "Tcp", "TcpClient");
            }
        }

        private void guardarTablaTcpServerModem()
        {
            for (int fila = 0; fila < tablaTcpServerModem.Rows.Count - 1; fila++)
            {
                String name = tablaTcpServerModem.Rows[fila].Cells["tcpServerNameModem"].Value.ToString();
                String port = tablaTcpServerModem.Rows[fila].Cells["tcpServerPortModem"].Value.ToString();
                c._Add(name, "", port, "", "", "Modems", "Tcp", "TcpServer");
            }
        }

        #endregion

        private Boolean validarTablas(DataGridView tabla, String nombre)
        {
            Boolean validaciontabla = true;

            for (int fila = 0; fila < tabla.Rows.Count - 1; fila++)
            {
                for (int col = 0; col < tabla.Rows[fila].Cells.Count; col++)
                {
                    if (tabla.Rows[fila].Cells[col].Value == null)
                    {
                        validaciontabla = false;
                    }
                }
            }

            if (!validaciontabla)
            {
                new Information("Existen datos de la tabla " + nombre + ",\n que estan incompletos").ShowDialog();
            }

            return validaciontabla;
        }

        private Boolean validarPuertosUdpServer(DataGridView tablaUdp,DataGridView tablaUdpServerModem, DataGridView tablaUdpClientModem, DataGridView tablaTcpModem, DataGridView tablaTcpClientModem)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaUdp.Rows.Count - 1; fila++)
            {
                String enlaceport = tablaUdp.Rows[fila].Cells["udpServerEnlacePort"].Value.ToString();
                String destinationport = tablaUdp.Rows[fila].Cells["udpServerDestinationPort"].Value.ToString();

                for (int x = 0; x < tablaUdp.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdp.Rows[x].Cells["udpServerEnlacePort"].Value.ToString()) && x != fila) || (enlaceport.Equals(tablaUdp.Rows[x].Cells["udpServerDestinationPort"].Value.ToString()) && x != fila) ||
                        (destinationport.Equals(tablaUdp.Rows[x].Cells["udpServerEnlacePort"].Value.ToString()) && x != fila) || (destinationport.Equals(tablaUdp.Rows[x].Cells["udpServerDestinationPort"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: "+tablaUdp.Name.ToString());
                    }
                }

                //String enlaceport = tablaUdpServerModem.Rows[fila].Cells["udpServerEnlacePortModem"].Value.ToString();
                //String destinationport = tablaUdpServerModem.Rows[fila].Cells["udpServerDestinationPortModem"].Value.ToString();
                for (int x = 0; x < tablaUdpServerModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString())) || (enlaceport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString())) || (destinationport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaUdpServerModem.Name.ToString());
                    }

                }

                /*String port = tablaUdpClientModem.Rows[fila].Cells["udpClientConexionPortModem"].Value.ToString();
                String destinationport = tablaUdpClientModem.Rows[fila].Cells["udpClientDestinationPortModem"].Value.ToString();*/
                for (int x = 0; x < tablaUdpClientModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString())) || (enlaceport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString())) || (destinationport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaUdpClientModem.Name.ToString());
                    }
                }
                //String port = tablaTcpServerModem.Rows[fila].Cells["tcpServerPortModem"].Value.ToString();
                for (int x = 0; x < tablaTcpModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcpModem.Rows[x].Cells["tcpServerPortModem"].Value.ToString())) || (destinationport.Equals(tablaTcpModem.Rows[x].Cells["tcpServerPortModem"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcpModem.Name.ToString());
                    }
                }

                // String port = tablaTcpClientModem.Rows[fila].Cells["tcpClientPortModem"].Value.ToString();

                for (int x = 0; x < tablaTcpClientModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcpClientModem.Rows[x].Cells["tcpClientPortModem"].Value.ToString())) || (destinationport.Equals(tablaTcpClientModem.Rows[x].Cells["tcpClientPortModem"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcpClientModem.Name.ToString());
                    }
                }

            }

            return puerto;

        }

        private Boolean validarPuertosUdpClient(DataGridView tablaUdpClient, DataGridView tablaUdpServerModem, DataGridView tablaUdpClientModem, DataGridView tablaTcpModem, DataGridView tablaTcpClientModem)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaUdpClient.Rows.Count - 1; fila++)
            {

                String enlaceport = tablaUdpClient.Rows[fila].Cells["udpClientPort"].Value.ToString();
                String destinationport = tablaUdpClient.Rows[fila].Cells["udpClientDestinationPort"].Value.ToString();

                for (int x = 0; x < tablaUdpClient.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString()) && x != fila) || (enlaceport.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString()) && x != fila) ||
                        (destinationport.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString()) && x != fila) || (destinationport.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaUdpServerModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString())) || (enlaceport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString())) || (destinationport.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                    }

                }

                for (int x = 0; x < tablaUdpClientModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString())) || (enlaceport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString())) || (destinationport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }
                for (int x = 0; x < tablaTcpModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcpModem.Rows[x].Cells["tcpServerPortModem"].Value.ToString())) || (destinationport.Equals(tablaTcpModem.Rows[x].Cells["tcpServerPortModem"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcpModem.Name.ToString());
                    }
                }


                for (int x = 0; x < tablaTcpClientModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcpClientModem.Rows[x].Cells["tcpClientPortModem"].Value.ToString())) || (destinationport.Equals(tablaTcpClientModem.Rows[x].Cells["tcpClientPortModem"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }

            }

            return puerto;

        }

        private Boolean validarPuertosTcpServer(DataGridView tablaTcpServer, DataGridView tablaUdpServerModem, DataGridView tablaUdpClientModem, DataGridView tablaTcpModem, DataGridView tablaTcpClientModem)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaTcpServer.Rows.Count - 1; fila++)
            {

                String port = tablaTcpServer.Rows[fila].Cells["tcpServerPort"].Value.ToString();

                for (int x = 0; x < tablaTcpServer.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaTcpServer.Rows[x].Cells["tcpServerPort"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaUdpServerModem.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString())) || (port.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                    }

                }

                for (int x = 0; x < tablaUdpClientModem.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString())) || (port.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaTcpModem.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcpModem.Rows[x].Cells["tcpServerPortModem"].Value.ToString()))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcpModem.Name.ToString());
                    }
                }


                for (int x = 0; x < tablaTcpClientModem.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcpClientModem.Rows[x].Cells["tcpClientPortModem"].Value.ToString()))
                    {
                        puerto = true;
                    }
                }

            }

            return puerto;

        }

        private Boolean validarPuertosTcpClient(DataGridView tablaTcpClient, DataGridView tablaUdpServerModem, DataGridView tablaUdpClientModem, DataGridView tablaTcpModem, DataGridView tablaTcpClientModem)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaTcpClient.Rows.Count - 1; fila++)
            {

                String port = tablaTcpClient.Rows[fila].Cells["tcpClientPort"].Value.ToString();

                for (int x = 0; x < tablaTcpClient.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaTcpClient.Rows[x].Cells["tcpClientPort"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaUdpServerModem.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString())) || (port.Equals(tablaUdpServerModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                    }

                }

                for (int x = 0; x < tablaUdpClientModem.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString())) || (port.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaTcpModem.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcpModem.Rows[x].Cells["tcpServerPortModem"].Value.ToString()))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcpModem.Name.ToString());
                    }
                }


                for (int x = 0; x < tablaTcpClientModem.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcpClientModem.Rows[x].Cells["tcpClientPortModem"].Value.ToString()))
                    {
                        puerto = true;
                    }
                }

            }

            return puerto;

        }


        private Boolean validarPuertosUdpClientModem(DataGridView tablaUdpClientModem, DataGridView tablaUdpServer, DataGridView tablaUdpClient, DataGridView tablaTcp, DataGridView tablaTcpClient)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaUdpClientModem.Rows.Count - 1; fila++)
            {

                String enlaceport = tablaUdpClientModem.Rows[fila].Cells["udpClientConexionPortModem"].Value.ToString();
                String destinationport = tablaUdpClientModem.Rows[fila].Cells["udpClientDestinationPortModem"].Value.ToString();

                for (int x = 0; x < tablaUdpClientModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString()) && x != fila) || (enlaceport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString()) && x != fila) ||
                        (destinationport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientConexionPortModem"].Value.ToString()) && x != fila) || (destinationport.Equals(tablaUdpClientModem.Rows[x].Cells["udpClientDestinationPortModem"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                    }
                }

                //String enlaceport = tablaUDPServer.Rows[fila].Cells["udpServerEnlacePort"].Value.ToString();
                //String destinationport = tablaUDPServer.Rows[fila].Cells["udpServerDestinationPort"].Value.ToString();

                for (int x = 0; x < tablaUdpServer.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpServer.Rows[x].Cells["udpServerEnlacePort"].Value.ToString())) || (enlaceport.Equals(tablaUdpServer.Rows[x].Cells["udpServerDestinationPort"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpServer.Rows[x].Cells["udpServerEnlacePort"].Value.ToString())) || (destinationport.Equals(tablaUdpServer.Rows[x].Cells["udpServerDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                    }

                }

                //String port = tablaUdpClient.Rows[fila].Cells["udpClientPort"].Value.ToString();
                //String destinationport = tablaUdpClient.Rows[fila].Cells["udpClientDestinationPort"].Value.ToString();
                for (int x = 0; x < tablaUdpClient.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString())) || (enlaceport.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString())) || (destinationport.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaTcp.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcp.Rows[x].Cells["tcpServerPort"].Value.ToString())) || (destinationport.Equals(tablaTcp.Rows[x].Cells["tcpServerPort"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcp.Name.ToString());
                    }
                }


                for (int x = 0; x < tablaTcpClient.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcpClient.Rows[x].Cells["tcpClientPort"].Value.ToString())) || (destinationport.Equals(tablaTcpClient.Rows[x].Cells["tcpClientPort"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }

            }

            return puerto;

        }

        private Boolean validarPuertosUdpServerModem(DataGridView tablaUdpModem, DataGridView tablaUdpServer, DataGridView tablaUdpClient, DataGridView tablaTcp, DataGridView tablaTcpClient)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaUdpModem.Rows.Count - 1; fila++)
            {
                String enlaceport = tablaUdpModem.Rows[fila].Cells["udpServerEnlacePortModem"].Value.ToString();
                String destinationport = tablaUdpModem.Rows[fila].Cells["udpServerDestinationPortModem"].Value.ToString();

                for (int x = 0; x < tablaUdpModem.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString()) && x != fila) || (enlaceport.Equals(tablaUdpModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString()) && x != fila) ||
                        (destinationport.Equals(tablaUdpModem.Rows[x].Cells["udpServerEnlacePortModem"].Value.ToString()) && x != fila) || (destinationport.Equals(tablaUdpModem.Rows[x].Cells["udpServerDestinationPortModem"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaUdpModem.Name.ToString());
                    }
                }

                for (int x = 0; x < tablaUdpServer.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpServer.Rows[x].Cells["udpServerEnlacePort"].Value.ToString())) || (enlaceport.Equals(tablaUdpServer.Rows[x].Cells["udpServerDestinationPort"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpServer.Rows[x].Cells["udpServerEnlacePort"].Value.ToString())) || (destinationport.Equals(tablaUdpServer.Rows[x].Cells["udpServerDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaUdpServer.Name.ToString());
                    }

                }

                for (int x = 0; x < tablaUdpClient.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString())) || (enlaceport.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString())) ||
                        (destinationport.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString())) || (destinationport.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaUdpClient.Name.ToString());
                    }
                }


                for (int x = 0; x < tablaTcp.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcp.Rows[x].Cells["tcpServerPort"].Value.ToString())) || (destinationport.Equals(tablaTcp.Rows[x].Cells["tcpServerPort"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcp.Name.ToString());
                    }
                }


                for (int x = 0; x < tablaTcpClient.Rows.Count - 1; x++)
                {
                    if ((enlaceport.Equals(tablaTcpClient.Rows[x].Cells["tcpClientPort"].Value.ToString())) || (destinationport.Equals(tablaTcpClient.Rows[x].Cells["tcpClientPort"].Value.ToString())))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcpClient.Name.ToString());
                    }
                }
            }

            return puerto;

        }

        private Boolean validarPuertosTcpServerModem(DataGridView tablaTcpServerModem, DataGridView tablaUdpServer, DataGridView tablaUdpClient, DataGridView tablaTcp, DataGridView tablaTcpClient)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaTcpServerModem.Rows.Count - 1; fila++)
            {

                String port = tablaTcpServerModem.Rows[fila].Cells["tcpServerPortModem"].Value.ToString();

                for (int x = 0; x < tablaTcpServerModem.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaTcpServerModem.Rows[x].Cells["tcpServerPortModem"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaUdpServer.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpServer.Rows[x].Cells["udpServerEnlacePort"].Value.ToString())) || (port.Equals(tablaUdpServer.Rows[x].Cells["udpServerDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                    }

                }


                for (int x = 0; x < tablaUdpClient.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString())) || (port.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }

                //String port = tablaTcpServer.Rows[fila].Cells["tcpServerPort"].Value.ToString();
                for (int x = 0; x < tablaTcp.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcp.Rows[x].Cells["tcpServerPort"].Value.ToString()))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcp.Name.ToString());
                    }
                }

                //String port = tablaTcpClient.Rows[fila].Cells["tcpClientPort"].Value.ToString();
                for (int x = 0; x < tablaTcpClient.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcpClient.Rows[x].Cells["tcpClientPort"].Value.ToString()))
                    {
                        puerto = true;
                    }
                }

            }

            return puerto;

        }

        private Boolean validarPuertosTcpClientModem(DataGridView tablaTcpClientModem, DataGridView tablaUdpServer, DataGridView tablaUdpClient, DataGridView tablaTcp, DataGridView tablaTcpClient)
        {
            Boolean puerto = false;

            for (int fila = 0; fila < tablaTcpClientModem.Rows.Count - 1; fila++)
            {

                String port = tablaTcpClientModem.Rows[fila].Cells["tcpClientPortModem"].Value.ToString();

                for (int x = 0; x < tablaTcpClientModem.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaTcpClientModem.Rows[x].Cells["tcpClientPortModem"].Value.ToString()) && x != fila))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaUdpServer.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpServer.Rows[x].Cells["udpServerEnlacePort"].Value.ToString())) || (port.Equals(tablaUdpServer.Rows[x].Cells["udpServerDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                    }

                }

                for (int x = 0; x < tablaUdpClient.Rows.Count - 1; x++)
                {
                    if ((port.Equals(tablaUdpClient.Rows[x].Cells["udpClientPort"].Value.ToString())) || (port.Equals(tablaUdpClient.Rows[x].Cells["udpClientDestinationPort"].Value.ToString())))
                    {
                        puerto = true;
                    }
                }

                for (int x = 0; x < tablaTcp.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcp.Rows[x].Cells["tcpServerPort"].Value.ToString()))
                    {
                        puerto = true;
                        Console.WriteLine("Tabla: " + tablaTcp.Name.ToString());
                    }
                }
                
                for (int x = 0; x < tablaTcpClient.Rows.Count - 1; x++)
                {
                    if (port.Equals(tablaTcpClient.Rows[x].Cells["tcpClientPort"].Value.ToString()) )
                    {
                        puerto = true;
                    }
                }
            }

            return puerto;
        }
        #endregion
        /************EL CODIGO DE ABAJO REMUEVE TODOS LOS CAMPOS DE LA TABLA**/
        //tablaUDP.Rows.Clear();*/

        #region vista del lado de los servidores
        private void btnDelUdpClient_Click_1(object sender, EventArgs e)
        {
            if (tablaUdpClient.CurrentRow.Selected)
            {
                try
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaUdpClient.Rows[tablaUdpClient.CurrentRow.Index].Cells["udpClientName"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Servers", "Udp", "UdpClient", "Client"))
                        {
                            c._DeleteNodo(name, "Servers", "Udp", "UdpClient", "Client");
                        }
                        tablaUdpClient.Rows.Remove(tablaUdpClient.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                    
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }

        private void btnDelUdpServer_Click(object sender, EventArgs e)
        {
            if (tablaUDPServer.CurrentRow.Selected)
            {
                try
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaUDPServer.Rows[tablaUDPServer.CurrentRow.Index].Cells["udpSeverName"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Servers", "Udp", "UdpServer", "Server"))
                        {
                            c._DeleteNodo(name, "Servers", "Udp", "UdpServer", "Server");
                        }
                        tablaUDPServer.Rows.Remove(tablaUDPServer.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                    
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }

        private void btnDelTcpServer_Click(object sender, EventArgs e)
        {
            if (tablaTcpServer.CurrentRow.Selected)
            {
                try 
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaTcpServer.Rows[tablaTcpServer.CurrentRow.Index].Cells["tcpServerName"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Servers", "Tcp", "TcpServer", "Server"))
                        {
                            c._DeleteNodo(name, "Servers", "Tcp", "TcpServer", "Server");
                        }
                        tablaTcpServer.Rows.Remove(tablaTcpServer.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }

        private void btnDelTcpClient_Click(object sender, EventArgs e)
        {
            if (tablaTcpClient.CurrentRow.Selected)
            {
                try
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaTcpClient.Rows[tablaTcpClient.CurrentRow.Index].Cells["tcpClientName"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Servers", "Tcp", "TcpClient", "Client"))
                        {
                            c._DeleteNodo(name, "Servers", "Tcp", "TcpClient", "Client");
                        }
                        tablaTcpClient.Rows.Remove(tablaTcpClient.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }

        private void cbSocket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbConexion.SelectedItem != null)
            {
                lblInfoConexion.Location = new System.Drawing.Point(100, 93);

                lblInfoConexion.Text = "Configuración" + cbSocket.SelectedItem.ToString() +" "+cbConexion.SelectedItem.ToString();
                switchPanel(cbSocket.SelectedItem.ToString(), cbConexion.SelectedItem.ToString());
            }
            else
            {
                lblInfoConexion.Location = new System.Drawing.Point(174, 93);
                lblInfoConexion.Text = "Configuración";
            }
        }

        private void cbConexion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSocket.SelectedItem != null)
            {
                lblInfoConexion.Location = new System.Drawing.Point(100, 93);
                lblInfoConexion.Text = "Configuración " + cbSocket.SelectedItem.ToString() + " " + cbConexion.SelectedItem.ToString();
                switchPanel(cbSocket.SelectedItem.ToString(), cbConexion.SelectedItem.ToString());
            }
            else
            {
                lblInfoConexion.Location = new System.Drawing.Point(174, 93);
                lblInfoConexion.Text = "Configuración";
            }
        }
        /*Cliente
Servidor*/
        private void switchPanel(String socket, String conexion)
        {
            switch (socket)
            {
                case "UDP":
                    switch (conexion)
                    {
                        case "Cliente":
                            Console.WriteLine("Mostrando: {0} -> {1}",socket,conexion);
                            showPanelUdpClient();
                            break;
                        case "Servidor":
                            Console.WriteLine("Mostrando: {0} -> {1}", socket, conexion);
                            showPanelUdpServer();
                            break;
                    }
                    break;
                case "TCP":
                    switch (conexion)
                    {
                        case "Cliente":
                            Console.WriteLine("Mostrando: {0} -> {1}", socket, conexion);
                            showPanelTcpClient();
                            break;
                        case "Servidor":
                            Console.WriteLine("Mostrando: {0} -> {1}", socket, conexion);
                            showPanelTcpServer();
                            break;
                    }
                    break;
            }
        }

        private void showPanelUdpServer()
        {
            panelUdpServer.Visible = true;
            panelUdpClient.Visible = false;
            panelTcpServer.Visible = false;
            panelTcpClient.Visible = false;
            
        }
        private void showPanelUdpClient()
        {
            panelUdpClient.Visible = true;
            panelUdpServer.Visible = false;
            panelTcpServer.Visible = false;
            panelTcpClient.Visible = false;
        }

        private void showPanelTcpServer()
        {
            panelTcpServer.Visible = true;
            panelUdpServer.Visible = false;
            panelUdpClient.Visible = false;
            panelTcpClient.Visible = false;
        }
        private void showPanelTcpClient()
        {
            panelUdpServer.Visible = false;
            panelUdpClient.Visible = false;
            panelTcpServer.Visible = false;
            panelTcpClient.Visible = true;
        }
#endregion

#region vista configuracion del lado del modem
        private void btnDelTcpServerModem_Click(object sender, EventArgs e)
        {
            if (tablaTcpServerModem.CurrentRow.Selected)
            {
                try
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaTcpServerModem.Rows[tablaTcpServerModem.CurrentRow.Index].Cells["tcpServerNameModem"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Modems", "Tcp", "TcpServer", "Server"))
                        {
                            c._DeleteNodo(name, "Modems", "Tcp", "TcpServer", "Server");
                        }
                        tablaTcpServerModem.Rows.Remove(tablaTcpServerModem.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }

        private void btnDelTcpClientModem_Click_1(object sender, EventArgs e)
        {
            if (tablaTcpClientModem.CurrentRow.Selected)
            {
                try
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaTcpClientModem.Rows[tablaTcpClientModem.CurrentRow.Index].Cells["tcpClientNameModem"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Modems", "Tcp", "TcpClient", "Client"))
                        {
                            c._DeleteNodo(name, "Modems", "Tcp", "TcpClient", "Client");
                        }
                        tablaTcpClientModem.Rows.Remove(tablaTcpClientModem.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }

        private void btnDelUdpClientModem_Click_1(object sender, EventArgs e)
        {
            if (tablaUdpClientModem.CurrentRow.Selected)
            {
                try
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaUdpClientModem.Rows[tablaUdpClientModem.CurrentRow.Index].Cells["udpClientNameModem"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Modems", "Udp", "UdpClient", "Client"))
                        {
                            c._DeleteNodo(name, "Modems", "Udp", "UdpClient", "Client");
                        }
                        tablaUdpClientModem.Rows.Remove(tablaUdpClientModem.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                    
                }
                catch (XmlException ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }

        private void btnDelUdpServerModem_Click_1(object sender, EventArgs e)
        {
            if (tablaUdpServerModem.CurrentRow.Selected)
            {
                try
                {
                    if (new Warning("¿Seguro deseas eliminar esta fila?,\n ¡Se eliminará completamente!").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaUdpServerModem.Rows[tablaUdpServerModem.CurrentRow.Index].Cells["udpSeverNameModem"].Value.ToString();
                        Console.WriteLine(name);
                        if (c._FindNodoBeforeDelete(name, "Modems", "Udp", "UdpServer", "Server"))
                        {
                            c._DeleteNodo(name, "Modems", "Udp", "UdpServer", "Server");
                        }
                        tablaUdpServerModem.Rows.Remove(tablaUdpServerModem.CurrentRow);
                        new Success("Se ha borrado corectamente,\n No se requiere guardar despues de eliminar").ShowDialog();
                    }
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }



        private void cbSocketModem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbConexionModem.SelectedItem != null)
            {
                switchPanelModem(cbSocketModem.SelectedItem.ToString(), cbConexionModem.SelectedItem.ToString());
            }
        }

        private void cbConexionModem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSocketModem.SelectedItem != null)
            {
                switchPanelModem(cbSocketModem.SelectedItem.ToString(), cbConexionModem.SelectedItem.ToString());
            }
        }

        private void switchPanelModem(String socket, String conexion)
        {
            switch (socket)
            {
                case "UDP":
                    switch (conexion)
                    {
                        case "Cliente":
                            Console.WriteLine("Mostrando: {0} -> {1}", socket, conexion);
                            showPanelUdpClientModem();
                            break;
                        case "Servidor":
                            Console.WriteLine("Mostrando: {0} -> {1}", socket, conexion);
                            showPanelUdpServerModem();
                            break;
                    }
                    break;
                case "TCP":
                    switch (conexion)
                    {
                        case "Cliente":
                            Console.WriteLine("Mostrando: {0} -> {1}", socket, conexion);
                            showPanelTcpClientModem();
                            break;
                        case "Servidor":
                            Console.WriteLine("Mostrando: {0} -> {1}", socket, conexion);
                            showPanelTcpServerModem();
                            break;
                    }
                    break;
            }
        }

        private void showPanelUdpServerModem()
        {
            panelUdpServerModem.Visible = true;
            panelUdpClientModem.Visible = false;
            panelTcpServerModem.Visible = false;
            panelTcpClientModem.Visible = false;

        }
        private void showPanelUdpClientModem()
        {
            panelUdpClientModem.Visible = true;
            panelUdpServerModem.Visible = false;
            panelTcpServerModem.Visible = false;
            panelTcpClientModem.Visible = false;
        }

        private void showPanelTcpServerModem()
        {
            panelTcpServerModem.Visible = true;
            panelUdpServerModem.Visible = false;
            panelUdpClientModem.Visible = false;
            panelTcpClientModem.Visible = false;
        }
        private void showPanelTcpClientModem()
        {
            panelUdpServerModem.Visible = false;
            panelUdpClientModem.Visible = false;
            panelTcpServerModem.Visible = false;
            panelTcpClientModem.Visible = true;
        }

        #endregion

        #region carga de datos en tablas
        public void chargeAllTable()
        {
            chargeUdpClient();
            chargeUdpServer();
            chargeTcpClient();
            chargeTcpServer();

            chargeUdpClientModem();
            chargeUdpServerModem();
            chargeTcpClientModem();
            chargeTcpServerModem();
        }

        public void chargeUdpClient()
        {
            XmlNodeList listaClientes = c._ReadXml("Servers", "Udp", "UdpClient", "Client");
            XmlNode cliente;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                cliente = listaClientes.Item(i);

                string name = cliente.SelectSingleNode("Name").InnerText;
                string ipadress = cliente.SelectSingleNode("IpAdress").InnerText;
                string port = cliente.SelectSingleNode("EnlacePort").InnerText;
                string destinationport = cliente.SelectSingleNode("DestinationPort").InnerText;

                tablaUdpClient.Rows.Add(name,ipadress,port,destinationport);
            }
        }

        public void chargeUdpServer()
        {
            XmlNodeList listaServers = c._ReadXml("Servers", "Udp", "UdpServer", "Server");
            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                tablaUDPServer.Rows.Add(name, enlaceport, port);
            }
        }

        public void chargeTcpClient()
        {
            XmlNodeList listaClientes = c._ReadXml("Servers", "Tcp", "TcpClient", "Client");
            XmlNode cliente;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                cliente = listaClientes.Item(i);

                string name = cliente.SelectSingleNode("Name").InnerText;
                string ipadress = cliente.SelectSingleNode("IpAdress").InnerText;
                string port = cliente.SelectSingleNode("Port").InnerText;

                tablaTcpClient.Rows.Add(name, ipadress, port);
            }
        }

        public void chargeTcpServer()
        {
            XmlNodeList listaServers = c._ReadXml("Servers", "Tcp", "TcpServer", "Server");
            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                tablaTcpServer.Rows.Add(name, port);
            }
        }

        public void chargeUdpClientModem()
        {
            XmlNodeList listaClientes = c._ReadXml("Modems", "Udp", "UdpClient", "Client");
            XmlNode cliente;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                cliente = listaClientes.Item(i);

                string name = cliente.SelectSingleNode("Name").InnerText;
                string ipadress = cliente.SelectSingleNode("IpAdress").InnerText;
                string port = cliente.SelectSingleNode("EnlacePort").InnerText;
                string destinationport = cliente.SelectSingleNode("DestinationPort").InnerText;

                tablaUdpClientModem.Rows.Add(name, ipadress, port,destinationport);
            }
        }

        public void chargeUdpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml("Modems", "Udp", "UdpServer", "Server");
            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string enlaceport = server.SelectSingleNode("EnlacePort").InnerText;
                string port = server.SelectSingleNode("DestinationPort").InnerText;

                tablaUdpServerModem.Rows.Add(name, enlaceport, port);
            }
        }

        public void chargeTcpClientModem()
        {
            XmlNodeList listaClientes = c._ReadXml("Modems", "Tcp", "TcpClient", "Client");
            XmlNode cliente;

            for (int i = 0; i < listaClientes.Count; i++)
            {
                cliente = listaClientes.Item(i);

                string name = cliente.SelectSingleNode("Name").InnerText;
                string ipadress = cliente.SelectSingleNode("IpAdress").InnerText;
                string port = cliente.SelectSingleNode("Port").InnerText;

                tablaTcpClientModem.Rows.Add(name, ipadress, port);
            }
        }
        public void chargeTcpServerModem()
        {
            XmlNodeList listaServers = c._ReadXml("Modems", "Tcp", "TcpServer", "Server");
            XmlNode server;

            for (int i = 0; i < listaServers.Count; i++)
            {
                server = listaServers.Item(i);

                string name = server.SelectSingleNode("Name").InnerText;
                string port = server.SelectSingleNode("Port").InnerText;

                tablaTcpServerModem.Rows.Add(name, port);
            }
        }
        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
