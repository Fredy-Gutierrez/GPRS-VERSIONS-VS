﻿using FontAwesome.Sharp;
using GPRS.Clases;
using GPRS.Clases.Models;
using GPRS.Clases.Xml.SocketsMessages;
using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GPRS.Forms.Sockets
{
    public partial class FormModemUdpClient : Form
    {
        readonly Configurations c;
        readonly FormServidor formServidor;
        private readonly DriverMaster driverMaster;

        //EventWaitHandle waitHandle = new ManualResetEvent(initialState: true);
        readonly ManualResetEvent waitHandle = new ManualResetEvent(false);
        bool writting = false;

        readonly UdpClientMessagesModel udpClientMessagesModel = new UdpClientMessagesModel();

        public FormModemUdpClient(FormServidor formServidor)
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            c = new Configurations();
            this.formServidor = formServidor;
            this.driverMaster = formServidor.d;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void setMessage(string name, string msg)
        {
            writting = true;
            try
            {
                if (lblName.Text.Equals(name))
                {
                    this.Invoke(new MethodInvoker(delegate
                    {
                        if (!lblStatus.Text.Equals("En comunicación"))
                        {
                            lblStatus.Text = "En comunicación";
                            lblStatus.ForeColor = Color.FromArgb(0, 166, 255);
                        }

                        string x = "\n";
                        char[] charArr = x.ToCharArray();

                        string[] lines = txtMsg.Text.Split(charArr);

                        if (lines.Length >= 50)
                        {
                            if (txtMsg.Text.IndexOfAny(charArr) > 0)
                            {
                                txtMsg.Text = txtMsg.Text.Remove(0, txtMsg.Text.IndexOfAny(charArr) + 1);
                            }
                        }

                        if (txtMsg.Text.Equals(""))
                        {
                            txtMsg.Text += msg;
                        }
                        else
                        {
                            txtMsg.Text += "\n" + msg;
                        }
                        txtMsg.SelectionStart = txtMsg.Text.Length;
                        txtMsg.ScrollToCaret();
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            writting = false;
            waitHandle.Set();
        }

        private void FormModemUdpClient_Load(object sender, EventArgs e)
        {
            XmlNodeList listaClients = c._ReadXml("Modems", "Udp", "UdpClient", "Client");

            XmlNode client;

            int xp = 10;

            int yp = 60;

            IconButton btn;

            int h = 490;

            if (listaClients.Count > 12)
            {
                int a = listaClients.Count % 2;



                if (a == 0)
                {
                    h = listaClients.Count / 2 * 75;
                }
                else
                {
                    h = (listaClients.Count + 1) / 2 * 75;
                }
            }

            panelSockets.Size = new Size(panelSockets.Size.Width, h);

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;

                ///Creacion de los botones de 

                btn = new IconButton
                {
                    Location = new Point(xp, yp),

                    Size = new Size(70, 55),

                    IconChar = IconChar.Desktop,

                    Text = name,

                    TextImageRelation = TextImageRelation.ImageAboveText
                };

                btn.FlatAppearance.BorderSize = 0;

                btn.FlatStyle = FlatStyle.Flat;

                btn.BackColor = Color.FromArgb(60, 59, 59);

                btn.IconSize = 30;

                btn.IconColor = Color.FromArgb(63, 201, 31);

                btn.ForeColor = Color.Gainsboro;

                btn.Font = new Font("Century Gothic", 10, FontStyle.Bold); ;

                btn.Click += new EventHandler(this.btn_Click);

                panelSockets.Controls.Add(btn);

                if (xp > 10)
                {
                    xp = 10;
                    yp += 70;
                }
                else
                {
                    xp += 85;
                }


            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;


            string btnName = btn.Text;

            XmlNodeList listaClients = c._ReadXml("Modems", "Udp", "UdpClient", "Client");

            XmlNode client;

            for (int i = 0; i < listaClients.Count; i++)
            {
                client = listaClients.Item(i);

                string name = client.SelectSingleNode("Name").InnerText;
                if (btnName.Equals(name))
                {
                    string status = client.SelectSingleNode("Status").InnerText;

                    if (writting)
                    {
                        waitHandle.WaitOne();
                    }
                    string ip = client.SelectSingleNode("IpAdress").InnerText;
                    string enlaceport = client.SelectSingleNode("EnlacePort").InnerText;
                    string destinationport = client.SelectSingleNode("DestinationPort").InnerText;

                    this.Invoke(new MethodInvoker(delegate
                    {
                        lblName.Text = name;
                        lblStatus.Location = new Point(lblName.Location.X + lblName.Size.Width + 10, lblStatus.Location.Y);
                        lblStatus.Text = status;
                        txtIp.Text = ip;
                        txtEnlacePort.Text = enlaceport;
                        txtDestinationPort.Text = destinationport;
                    }));

                    switch (status)
                    {
                        case "Inactivo":
                            btnSwitchOnOff.IsOn = false;
                            lblStatus.ForeColor = Color.FromArgb(193, 114, 1);
                            break;
                        case "En espera":
                            btnSwitchOnOff.IsOn = true;
                            lblStatus.ForeColor = Color.FromArgb(216, 255, 0);
                            break;
                        case "En comunicación":
                            btnSwitchOnOff.IsOn = true;
                            lblStatus.ForeColor = Color.FromArgb(0, 166, 255);
                            break;
                        default:
                            btnSwitchOnOff.IsOn = true;
                            break;
                    }

                    Task.Run(() =>
                    {
                        chargeBeforeMessage();
                    });
                }
            }
        }
        
        private void txtMsg_MouseHover(object sender, EventArgs e)
        {
            //taskMessage = false;
        }

        private void txtMsg_MouseLeave(object sender, EventArgs e)
        {
            //taskMessage = true;
        }

        private void txtMsg_VScroll(object sender, EventArgs e)
        {
            //taskMessage = false;
        }

        private void btnSwitchOnOff_Click(object sender, EventArgs e)
        {
            if (!lblName.Text.Equals("Nombre"))
            {
                if (!Session.user.Equals(string.Empty))
                {
                    if (btnSwitchOnOff.IsOn)
                    {
                        btnSwitchOnOff.BorderColor = btnSwitchOnOff.OnColor;
                        driverMaster.beginOneUdpClientModem(lblName.Text, txtIp.Text, txtEnlacePort.Text, txtDestinationPort.Text);
                        lblStatus.Text = "En espera";
                        lblStatus.ForeColor = Color.FromArgb(216, 255, 0);
                    }
                    else
                    {
                        btnSwitchOnOff.BorderColor = btnSwitchOnOff.OffColor;
                        driverMaster.closeOneUdpClientM(lblName.Text);
                        lblStatus.Text = "Inactivo";
                        lblStatus.ForeColor = Color.FromArgb(193, 114, 1);
                    }
                }
                else
                {
                    if (btnSwitchOnOff.IsOn)
                    {
                        btnSwitchOnOff.IsOn = false;
                    }
                    else
                    {
                        btnSwitchOnOff.IsOn = true;
                    }
                    Alerts.ShowError("Necesita iniciar sesión para detener los servidores");
                }
            }
            else
            {
                btnSwitchOnOff.IsOn = false;
                Alerts.ShowInformation("Primero seleccione un socket");
            }
        }

        private void FormModemUdpClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            formServidor.listUdpClientsFormModem.Remove(this);
            formServidor.countWindows -= 1;
        }

        private void chargeBeforeMessage()
        {
            try
            {
                string msg = string.Empty;

                DataTable t = udpClientMessagesModel.readMessages(lblName.Text, "Modems");

                for (int i = 0; i < t.Rows.Count; i++)
                {
                    //t.Rows[i]["Numero"].ToString();
                    if (msg.Equals(string.Empty))
                    {
                        msg = "UdpClient " + t.Rows[i][2].ToString() + ": " + t.Rows[i][1].ToString() + "    [" + t.Rows[i][4].ToString() + "   " + t.Rows[i][5].ToString() + "]";
                    }
                    else
                    {
                        msg += "\n" + "UdpClient "+ t.Rows[i][2].ToString() + ": " + t.Rows[i][1].ToString() + "    [" + t.Rows[i][4].ToString() + "   " + t.Rows[i][5].ToString() + "]";
                    }
                }
                if (!msg.Equals(string.Empty))
                {
                    if (writting)
                    {
                        waitHandle.WaitOne();
                    }
                    this.Invoke(new MethodInvoker(delegate
                    {
                        txtMsg.Text = String.Empty;
                        txtMsg.Text = msg;
                        txtMsg.SelectionStart = txtMsg.Text.Length + 1;
                        txtMsg.ScrollToCaret();
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
        }
    }
}
