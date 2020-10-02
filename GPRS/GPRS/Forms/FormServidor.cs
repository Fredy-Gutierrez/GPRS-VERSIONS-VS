using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPRS.Clases;
using GPRS.Forms.Messages;

namespace GPRS.Forms
{
    public partial class FormServidor : Form
    {
        DriverMaster d;

        public FormServidor()
        {
            InitializeComponent();
        }

        #region vista
        private void FormServidor_Load(object sender, EventArgs e)
        {
            /**********************************************INSTANCÍA AL DRIVER MASTER**************************************************/
            d = new DriverMaster(this);
        }

        /*******************************MUESTRA LOS MENSAJES EN EL PANEL DE MENSAJES DE LA VISTA**************************************/
        public void Mensajes(String msg)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                txtMensajes.Text += msg;
                txtMensajes.SelectionStart = txtMensajes.Text.Length;
                txtMensajes.ScrollToCaret();
            }));
        }
        #endregion

        /// <summary>
        /// Nuevo Proceso de creacion, conexiones con el driver master Ademas el proceso de creacion de los sockets se encuentran en esta region
        /// </summary>

        #region Driver Genysis

        private void setColorOn(FontAwesome.Sharp.IconButton btn)
        {
            btn.BackColor = Color.FromArgb(0, 227, 10);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(143, 255, 148);
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 227, 10);
        }

        public void setColorOff(FontAwesome.Sharp.IconButton btn)
        {
            btn.BackColor = Color.Red;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 113, 113);
            btn.FlatAppearance.MouseDownBackColor = Color.Red;
        }
        Boolean onbtnUdpClientServer = false;
        Boolean onbtnUdpServerServer = false;
        public Boolean onbtnTcpClientServer = false;
        Boolean onbtnTcpServerServer = false;

        Boolean onbtnUdpClientModem = false;
        Boolean onbtnUdpServerModem = false;
        public Boolean onbtnTcpClientModem = false;
        Boolean onbtnTcpServerModem = false;
        private void btnUdpClientServer_Click(object sender, EventArgs e)
        {
            if (onbtnUdpClientServer)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    onbtnUdpClientServer = false;
                    setColorOff(btnUdpClientServer);
                    d.closeUdpClientS();
                }
                
            }
            else
            {
                if (onbtnTcpServerServer || onbtnUdpServerServer || onbtnTcpClientServer)
                {
                    new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    onbtnUdpClientServer = true;
                    setColorOn(btnUdpClientServer);
                    d.beginTaskServer("UdpClient");
                }
            }
        }

        private void btnUdpServerServer_Click(object sender, EventArgs e)
        {
            if (onbtnUdpServerServer)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    onbtnUdpServerServer = false;
                    setColorOff(btnUdpServerServer);
                    d.closeUdpServerS();
                }
            }
            else
            {
                if (onbtnUdpClientServer || onbtnTcpServerServer || onbtnTcpClientServer)
                {
                        new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    d.beginTaskServer("UdpServer");
                    onbtnUdpServerServer = true;
                    setColorOn(btnUdpServerServer);
                }
            }
        }

        private void btnTcpClientServer_Click(object sender, EventArgs e)
        {
            if (onbtnTcpClientServer)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    onbtnTcpClientServer = false;
                    setColorOff(btnTcpClientServer);
                    d.closeTcpClientS();
                }
            }
            else
            {
                if (onbtnUdpClientServer || onbtnUdpServerServer || onbtnTcpServerServer)
                {
                    new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    d.beginTaskServer("TcpClient");
                    onbtnTcpClientServer = true;
                    setColorOn(btnTcpClientServer);
                }
            }
        }



        private void btnTcpServerServer_Click(object sender, EventArgs e)
        {
            if (onbtnTcpServerServer)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    d.closeTcpServerS();
                    onbtnTcpServerServer = false;
                    setColorOff(btnTcpServerServer);
                }
            }
            else
            {
                if (onbtnUdpClientServer || onbtnUdpServerServer || onbtnTcpClientServer)
                {
                    new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    d.beginTaskServer("TcpServer");
                    onbtnTcpServerServer = true;
                    setColorOn(btnTcpServerServer);
                }
                
            }
        }

        private void btnUdpClientModem_Click(object sender, EventArgs e)
        {
            if (onbtnUdpClientModem)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    d.closeUdpClientM();
                    onbtnUdpClientModem = false;
                    setColorOff(btnUdpClientModem);
                }
            }
            else
            {
                if (onbtnTcpServerModem || onbtnUdpServerModem || onbtnTcpClientModem)
                {
                    new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    d.beginTaskModem("UdpClient");
                    onbtnUdpClientModem = true;
                    setColorOn(btnUdpClientModem);
                }
            }
        }

        private void btnUdpServerModem_Click(object sender, EventArgs e)
        {
            if (onbtnUdpServerModem)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    d.closeUdpServerM();
                    onbtnUdpServerModem = false;
                    setColorOff(btnUdpServerModem);
                }
            }
            else
            {
                if (onbtnUdpClientModem || onbtnTcpServerModem || onbtnTcpClientModem)
                {
                    new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    d.beginTaskModem("UdpServer");
                    onbtnUdpServerModem = true;
                    setColorOn(btnUdpServerModem);
                }
            }
        }

        private void btnTcpClientModem_Click(object sender, EventArgs e)
        {
            if (onbtnTcpClientModem)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    d.closeTcpClientM();
                    onbtnTcpClientModem = false;
                    setColorOff(btnTcpClientModem);
                }
            }
            else
            {
                if (onbtnUdpClientModem || onbtnUdpServerModem || onbtnTcpServerModem)
                {
                    new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    d.beginTaskModem("TcpClient");
                    onbtnTcpClientModem = true;
                    setColorOn(btnTcpClientModem);
                }
            }
        }

        private void btnTcpServerModem_Click(object sender, EventArgs e)
        {
            if (onbtnTcpServerModem)
            {
                if (new Warning("¿Seguro desea detener el Servidor?").ShowDialog() == DialogResult.OK)
                {
                    d.closeTcpServerM();
                    onbtnTcpServerModem = false;
                    setColorOff(btnTcpServerModem);
                }
            }
            else
            {
                if (onbtnUdpClientModem || onbtnUdpServerModem || onbtnTcpClientModem)
                {
                    new Error("Solo se puede habilitar un tipo de conexión").ShowDialog();
                }
                else
                {
                    d.beginTaskModem("TcpServer");
                    onbtnTcpServerModem = true;
                    setColorOn(btnTcpServerModem);
                }
            }
        }

        #endregion

        private void FormServidor_Paint(object sender, PaintEventArgs e)
        {
            //#667eea→#764ba2
            //LinearGradientBrush linearGradientBrush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(138, 70, 118), Color.FromArgb(95, 10, 135),90F);

            //e.Graphics.FillRectangle(linearGradientBrush, this.ClientRectangle);
        }

        private void FormServidor_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }









}
