using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPRS.Clases;
using GPRS.Clases.Xml.SocketsMessages;
using GPRS.Forms.Messages;
using GPRS.Forms.Sockets;

namespace GPRS.Forms
{
    public partial class FormServidor : Form
    {
        public DriverMaster d;

        int maxWindows = Properties.Settings.Default.maxWindows;
        
        public int countWindows = 0;

        public List<FormSocketUdpServer> listUdpServerForm = new List<FormSocketUdpServer>();
        public List<FormSocketUdpClient> listUdpClientsForm = new List<FormSocketUdpClient>();
        public List<FormSocketTcpServer> listTcpServerForm = new List<FormSocketTcpServer>();
        public List<FormSocketTcpClient> listTcpClientsForm = new List<FormSocketTcpClient>();

        public List<FormModemUdpServer> listUdpServerFormModem = new List<FormModemUdpServer>();
        public List<FormModemUdpClient> listUdpClientsFormModem = new List<FormModemUdpClient>();
        public List<FormModemTcpServer> listTcpServerFormModem = new List<FormModemTcpServer>();
        public List<FormModemTcpClient> listTcpClientsFormModem = new List<FormModemTcpClient>();

        public FormServidor()
        {
            InitializeComponent();
            d = DriverMaster.myDriverMasterClass;
            d.setFormServidor(this);
            toolTip.SetToolTip(pictureInformation,"Los botones switch sirven para cerrar todos\n" +
                                                  "los canales de comunicacion del socket, si desea \n" +
                                                  "cerrar uno en particular de clic al nombre del socket\n" +
                                                  "al cual pertenece el canal, ahi podrá encontrar\n" +
                                                  "la configuracion individual y podrá activar y desactivar\n" +
                                                  "el canal");
        }

        #region vista
        private void FormServidor_Load(object sender, EventArgs e)
        {
            /**********************************************INSTANCÍA AL DRIVER MASTER**************************************************/
            //d = new DriverMaster(this);

            txtMaxWindows.Text = Convert.ToString(maxWindows);

            chargeButtons();
        }

        private void chargeButtons()
        {
            if (DriverMaster.listUdpClientsConnectors.Count > 0)
            {
                switchBtnUdpClientSock.IsOn = true;
                switchBtnUdpClientSock.BorderColor = switchBtnUdpClientSock.OnColor;

                //lbTitle.ForeColor = Color.SpringGreen;

                lblUdpClientServer.ForeColor = Color.FromArgb(102, 255, 102);

            }

            if (DriverMaster.listUdpConnectors.Count > 0)
            {
                switchBtnUdpServerSock.IsOn = true;
                switchBtnUdpServerSock.BorderColor = switchBtnUdpServerSock.OnColor;
                lblUdpServerServer.ForeColor = Color.FromArgb(102, 255, 102);
            }

            if (DriverMaster.listTcpClientsConnectors.Count > 0)
            {
                switchBtnTcpClientSock.IsOn = true;
                switchBtnTcpClientSock.BorderColor = switchBtnTcpClientSock.OnColor;
                lblTcpClientServer.ForeColor = Color.FromArgb(102, 255, 102);
            }

            if (DriverMaster.listTcpConnectors.Count > 0)
            {
                switchBtnTcpServerSock.IsOn = true;
                switchBtnTcpServerSock.BorderColor = switchBtnTcpServerSock.OnColor;
                lblTcpServerServer.ForeColor = Color.FromArgb(102, 255, 102);
            }

            //********************************REGION MODEMS*************************************//

            if (DriverMaster.listUdpClientsConnectorsModem.Count > 0)
            {
                switchBtnUdpClientModem.IsOn = true;
                switchBtnUdpClientModem.BorderColor = switchBtnUdpClientModem.OnColor;
                lblUdpClientModem.ForeColor = Color.FromArgb(102, 255, 102);
            }

            if (DriverMaster.listUdpConnectorsModem.Count > 0)
            {
                switchBtnUdpServerModem.IsOn = true;
                switchBtnUdpServerModem.BorderColor = switchBtnUdpServerModem.OnColor;
                lblUdpServerModem.ForeColor = Color.FromArgb(102, 255, 102);
            }

            if (DriverMaster.listTcpClientsConnectorsModem.Count > 0)
            {
                switchBtnTcpClientModem.IsOn = true;
                switchBtnTcpClientModem.BorderColor = switchBtnTcpClientModem.OnColor;
                lblTcpClientModem.ForeColor = Color.FromArgb(102, 255, 102);
            }

            if (DriverMaster.listTcpConnectorsModem.Count > 0)
            {
                switchBtnTcpServerModem.IsOn = true;
                switchBtnTcpServerModem.BorderColor = switchBtnTcpServerModem.OnColor;
                lblTcpServerModem.ForeColor = Color.FromArgb(102, 255, 102);
            }

        }

        /*******************************MUESTRA LOS MENSAJES EN EL PANEL DE MENSAJES DE LA VISTA**************************************/
        public void Mensajes(String msg,string type,string typesocket,string name)
        {
            try
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    string x = "\n";
                    char[] charArr = x.ToCharArray();

                    string[] lines = txtMensajes.Text.Split(charArr);

                    if (lines.Length >= 50)
                    {
                        if (txtMensajes.Text.IndexOfAny(charArr) > 0)
                        {
                            txtMensajes.Text = txtMensajes.Text.Remove(0, txtMensajes.Text.IndexOfAny(charArr) + 1);
                        }
                    }

                    if (txtMensajes.Text.Equals(""))
                    {
                        txtMensajes.Text += msg;
                    }
                    else
                    {
                        txtMensajes.Text += "\n" + msg;
                    }
                    txtMensajes.SelectionStart = txtMensajes.Text.Length;
                    txtMensajes.ScrollToCaret();
                }));

                Task.Run(() =>
                {
                    redirectMessage( msg, type,  typesocket,  name);
                });
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message.ToString());
            }
        }

        private void redirectMessage(string msg, string type, string typesocket, string name)
        {
            switch (type)
            {
                case "Server":
                    switch (typesocket)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsForm.Count; x++)
                            {
                                listUdpClientsForm[x].setMessage(name, msg);
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpServerForm.Count; x++)
                            {
                                listUdpServerForm[x].setMessage(name, msg);
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsForm.Count; x++)
                            {
                                listTcpClientsForm[x].setMessage(name, msg);
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpServerForm.Count; x++)
                            {
                                listTcpServerForm[x].setMessage(name, msg);
                            }
                            break;
                    }
                    break;
                case "Modem":
                    switch (typesocket)
                    {
                        case "UdpClient":
                            for (int x = 0; x < listUdpClientsFormModem.Count; x++)
                            {
                                listUdpClientsFormModem[x].setMessage(name, msg);
                            }
                            break;
                        case "UdpServer":
                            for (int x = 0; x < listUdpServerFormModem.Count; x++)
                            {
                                listUdpServerFormModem[x].setMessage(name, msg);
                            }
                            break;
                        case "TcpClient":
                            for (int x = 0; x < listTcpClientsFormModem.Count; x++)
                            {
                                listTcpClientsFormModem[x].setMessage(name, msg);
                            }
                            break;
                        case "TcpServer":
                            for (int x = 0; x < listTcpServerFormModem.Count; x++)
                            {
                                listTcpServerFormModem[x].setMessage(name, msg);
                            }
                            break;
                    }
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Nuevo Proceso de creacion, conexiones con el driver master Ademas el proceso de creacion de los sockets se encuentran en esta region
        /// </summary>

        #region Driver Genysis v1.0
        /*
                private void setColorOn(FontAwesome.Sharp.IconButton btn, Label lbTitle, Label lbTitleSocket)
                {
                    btn.BackColor = Color.FromArgb(0, 227, 10);
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(143, 255, 148);
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 227, 10);

                    lbTitle.ForeColor = Color.SpringGreen;

                    lbTitleSocket.ForeColor = Color.FromArgb(102, 255, 102);
                }

                public void setColorOff(FontAwesome.Sharp.IconButton btn, Label lbTitle, Label lbTitleSocket)
                {
                    btn.BackColor = Color.Red;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 113, 113);
                    btn.FlatAppearance.MouseDownBackColor = Color.Red;

                    lbTitle.ForeColor = Color.FromArgb(255, 153, 0);

                    lbTitleSocket.ForeColor = Color.FromArgb(255, 153, 51);
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
                            setColorOff(btnUdpClientServer, lblTitleServer,lblUdpClientServer);
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
                            setColorOn(btnUdpClientServer, lblTitleServer, lblUdpClientServer);
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
                            setColorOff(btnUdpServerServer, lblTitleServer,lblUdpServerServer);
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
                            setColorOn(btnUdpServerServer, lblTitleServer, lblUdpServerServer);
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
                            setColorOff(btnTcpClientServer, lblTitleServer,lblTcpClientServer);
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
                            setColorOn(btnTcpClientServer, lblTitleServer, lblTcpClientServer);
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
                            setColorOff(btnTcpServerServer, lblTitleServer,lblTcpServerServer);
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
                            setColorOn(btnTcpServerServer, lblTitleServer, lblTcpServerServer);
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
                            setColorOff(btnUdpClientModem,lblTitleModem,lblUdpClientModem);
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
                            setColorOn(btnUdpClientModem, lblTitleModem, lblUdpClientModem);
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
                            setColorOff(btnUdpServerModem, lblTitleModem,lblUdpServerModem);
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
                            setColorOn(btnUdpServerModem, lblTitleModem, lblUdpServerModem);
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
                            setColorOff(btnTcpClientModem, lblTitleModem, lblTcpClientModem);
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
                            setColorOn(btnTcpClientModem, lblTitleModem, lblTcpClientModem);
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
                            setColorOff(btnTcpServerModem, lblTitleModem, lblTcpServerModem);
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
                            setColorOn(btnTcpServerModem, lblTitleModem, lblTcpServerModem);
                        }
                    }
                }
                */
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

        #region information windows view

        private void lblUdpServerServer_Click(object sender, EventArgs e)
        {
            if (countWindows < maxWindows)
            {
                FormSocketUdpServer f = new FormSocketUdpServer(this);
                f.Show();
                listUdpServerForm.Add(f);
                countWindows-=-1;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
            
        }

        private void lblUdpClientServer_Click(object sender, EventArgs e)
        {
            if (countWindows<maxWindows)
            {
                FormSocketUdpClient f = new FormSocketUdpClient(this);
                f.Show();
                listUdpClientsForm.Add(f);
                countWindows++;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
        }

        private void lblTcpClientServer_Click(object sender, EventArgs e)
        {
            if (countWindows < maxWindows)
            {
                FormSocketTcpClient f = new FormSocketTcpClient(this);
                f.Show();
                listTcpClientsForm.Add(f);
                countWindows++;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
        }

        private void lblTcpServerServer_Click(object sender, EventArgs e)
        {
            if (countWindows < maxWindows)
            {
                FormSocketTcpServer f = new FormSocketTcpServer(this);
                f.Show();
                listTcpServerForm.Add(f);
                countWindows++;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
            
        }

        private void lblUdpClientModem_Click(object sender, EventArgs e)
        {
            if (countWindows < maxWindows)
            {
                FormModemUdpClient f = new FormModemUdpClient(this);
                f.Show();
                listUdpClientsFormModem.Add(f);
                countWindows++;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
            
        }

        private void lblUdpServerModem_Click(object sender, EventArgs e)
        {
            if (countWindows < maxWindows)
            {
                FormModemUdpServer f = new FormModemUdpServer(this);
                f.Show();
                listUdpServerFormModem.Add(f);
                countWindows++;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
            
        }

        private void lblTcpClientModem_Click(object sender, EventArgs e)
        {
            if (countWindows < maxWindows)
            {
                FormModemTcpClient f = new FormModemTcpClient(this);
                f.Show();
                listTcpClientsFormModem.Add(f);
                countWindows++;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
            
        }

        private void lblTcpServerModem_Click(object sender, EventArgs e)
        {
            if (countWindows < maxWindows)
            {
                FormModemTcpServer f = new FormModemTcpServer(this);
                f.Show();
                listTcpServerFormModem.Add(f);
                countWindows++;
            }
            else
            {
                Alerts.ShowInformation("Se han alcanzado el limite de ventanas abiertas");
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Properties.Settings.Default
            if (!Session.user.Equals(string.Empty))
            {
                try
                {
                    int num = Int32.Parse(txtMaxWindows.Text);
                    if (num > 10)
                    {
                        Alerts.ShowInformation("No se pueden tener más de 10 ventanas abiertas");
                        txtMaxWindows.Text = Convert.ToString(maxWindows);
                    }
                    else
                    {
                        Properties.Settings.Default.maxWindows = num;
                        Properties.Settings.Default.Save();

                        maxWindows = Properties.Settings.Default.maxWindows;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    Alerts.ShowError("Imposible procesar el número");
                }
            }
            else
            {
                txtMaxWindows.Text = Convert.ToString(Properties.Settings.Default.maxWindows);
                Alerts.ShowError("Necesita iniciar sesión para cambiar estos valores");
            }
            
        }

        private void txtMaxWindows_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    e.Handled = true;
                }
            }
        }

        #endregion

        private void switchBtnUdpClientSock_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty)) {
                if (switchBtnUdpClientSock.IsOn)
                {
                    d.beginTaskServer("UdpClient");
                    switchBtnUdpClientSock.BorderColor = switchBtnUdpClientSock.OnColor;
                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeUdpClientS();
                        switchBtnUdpClientSock.BorderColor = switchBtnUdpClientSock.OffColor;
                    }
                    else
                    {
                        switchBtnUdpClientSock.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnUdpClientSock.IsOn)
                {
                    switchBtnUdpClientSock.IsOn = false;
                }
                else
                {
                    switchBtnUdpClientSock.IsOn = true;
                }
                
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void switchBtnUdpServerSock_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty))
            {
                if (switchBtnUdpServerSock.IsOn)
                {
                    d.beginTaskServer("UdpServer");
                    switchBtnUdpServerSock.BorderColor = switchBtnUdpServerSock.OnColor;

                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeUdpServerS();
                        switchBtnUdpServerSock.BorderColor = switchBtnUdpServerSock.OffColor;
                    }
                    else
                    {
                        switchBtnUdpServerSock.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnUdpServerSock.IsOn)
                {
                    switchBtnUdpServerSock.IsOn = false;
                }
                else
                {
                    switchBtnUdpServerSock.IsOn = true;
                }
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void switchBtnTcpClientSock_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty))
            {
                if (switchBtnTcpClientSock.IsOn)
                {
                    if (d.beginTaskServer("TcpClient"))
                    {
                        switchBtnTcpClientSock.BorderColor = switchBtnTcpClientSock.OnColor;
                    }
                    else
                    {
                        switchBtnTcpClientSock.BorderColor = switchBtnTcpClientSock.OffColor;
                        switchBtnTcpClientSock.IsOn = false;
                    }
                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeTcpClientS();
                        switchBtnTcpClientSock.BorderColor = switchBtnTcpClientSock.OffColor;
                    }
                    else
                    {
                        switchBtnTcpClientSock.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnTcpClientSock.IsOn)
                {
                    switchBtnTcpClientSock.IsOn = false;
                }
                else
                {
                    switchBtnTcpClientSock.IsOn = true;
                }
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void switchBtnTcpServerSock_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty))
            {
                if (switchBtnTcpServerSock.IsOn)
                {
                    d.beginTaskServer("TcpServer");
                    switchBtnTcpServerSock.BorderColor = switchBtnTcpServerSock.OnColor;
                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeTcpServerS();
                        switchBtnTcpServerSock.BorderColor = switchBtnTcpServerSock.OffColor;
                    }
                    else
                    {
                        switchBtnTcpServerSock.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnTcpServerSock.IsOn)
                {
                    switchBtnTcpServerSock.IsOn = false;
                }
                else
                {
                    switchBtnTcpServerSock.IsOn = true;
                }
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void switchBtnUdpClientModem_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty))
            {
                if (switchBtnUdpClientModem.IsOn)
                {
                    d.beginTaskModem("UdpClient");
                    switchBtnUdpClientModem.BorderColor = switchBtnUdpClientModem.OnColor;
                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeUdpClientM();
                        switchBtnUdpClientModem.BorderColor = switchBtnUdpClientModem.OffColor;
                    }
                    else
                    {
                        switchBtnUdpClientModem.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnUdpClientModem.IsOn)
                {
                    switchBtnUdpClientModem.IsOn = false;
                }
                else
                {
                    switchBtnUdpClientModem.IsOn = true;
                }
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void switchBtnUdpServerModem_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty))
            {
                if (switchBtnUdpServerModem.IsOn)
                {
                    d.beginTaskModem("UdpServer");
                    switchBtnUdpServerModem.BorderColor = switchBtnUdpServerModem.OnColor;
                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeUdpServerM();
                        switchBtnUdpServerModem.BorderColor = switchBtnUdpServerModem.OffColor;
                    }
                    else
                    {
                        switchBtnUdpServerModem.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnUdpServerModem.IsOn)
                {
                    switchBtnUdpServerModem.IsOn = false;
                }
                else
                {
                    switchBtnUdpServerModem.IsOn = true;
                }
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void switchBtnTcpClientModem_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty))
            {
                if (switchBtnTcpClientModem.IsOn)
                {

                    if (d.beginTaskModem("TcpClient"))
                    {
                        switchBtnTcpClientModem.BorderColor = switchBtnTcpClientModem.OnColor;
                    }
                    else
                    {
                        switchBtnTcpClientModem.BorderColor = switchBtnTcpClientModem.OffColor;
                        switchBtnTcpClientModem.IsOn = false;
                    }
                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeTcpClientM();
                        switchBtnTcpClientModem.BorderColor = switchBtnTcpClientModem.OffColor;

                    }
                    else
                    {
                        switchBtnTcpClientModem.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnTcpClientModem.IsOn)
                {
                    switchBtnTcpClientModem.IsOn = false;
                }
                else
                {
                    switchBtnTcpClientModem.IsOn = true;
                }
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void switchBtnTcpServerModem_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(string.Empty))
            {
                if (switchBtnTcpServerModem.IsOn)
                {
                    d.beginTaskModem("TcpServer");
                    switchBtnTcpServerModem.BorderColor = switchBtnTcpServerModem.OnColor;
                }
                else
                {
                    if (Alerts.ShowWarning("¿Seguro desea detener el Servidor?"))
                    {
                        d.closeTcpServerM();
                        switchBtnTcpServerModem.BorderColor = switchBtnTcpServerModem.OffColor;
                    }
                    else
                    {
                        switchBtnTcpServerModem.IsOn = true;
                    }
                }
            }
            else
            {
                if (switchBtnTcpServerModem.IsOn)
                {
                    switchBtnTcpServerModem.IsOn = false;
                }
                else
                {
                    switchBtnTcpServerModem.IsOn = true;
                }
                Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
            }
        }

        private void txtMaxWindows_DoubleClick(object sender, EventArgs e)
        {
            //txtMaxWindows.ReadOnly = false;
        }
    }









}
