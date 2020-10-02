using GPRS.Clases;
using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GPRS.Forms
{
    public partial class FormCuenta : Form
    {
        UsersXml usersXml;

        public FormCuenta()
        {
            InitializeComponent();
        }

        private void btnCloseSession_Click(object sender, EventArgs e)
        {
            if (new Warning("¿Seguro desea Cerra la Sesión?").ShowDialog() == DialogResult.OK)
            {
                closeAllServers();

                FormLogIn formLogin = new FormLogIn();
                formLogin.Show();
                FormPrincipal.formPrincipal.Hide();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtActualPass.Text.Equals(Session.pass))
            {
                if (txtPass.Text.Equals(txtPassConfirm.Text))
                {
                    string name = Seguridad.Encriptar(txtName.Text);
                    string email = Seguridad.Encriptar(txtEmail.Text);
                    string user = Seguridad.Encriptar(txtUser.Text);
                    string password = Seguridad.Encriptar(txtPass.Text);

                    usersXml._Update(name,email,user,password);

                    new Success("Modificaciones Guardadas").ShowDialog();

                    clean();
                }
                else
                {
                    new Information("La nueva contraseña y la confirmación no coinciden").ShowDialog();
                }
            }
            else
            {
                new Error("La contraseña actual no coincide").ShowDialog();
            }
        }

        private void FormCuenta_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session.user;

            string username = Session.user;

            usersXml = new UsersXml();

            XmlNodeList route = usersXml._ReadXml();

            XmlNode list;


            for (int i = 0; i < route.Count; i++)
            {
                list = route.Item(i);

                if (username.Equals(Seguridad.DesEncriptar(list.SelectSingleNode("UserName").InnerText)))
                {
                    
                    string suser = Seguridad.DesEncriptar(list.SelectSingleNode("UserName").InnerText);

                    string name =  Seguridad.DesEncriptar(list.SelectSingleNode("Name").InnerText);

                    string spass = Seguridad.DesEncriptar(list.SelectSingleNode("Password").InnerText);

                    string email = Seguridad.DesEncriptar(list.SelectSingleNode("Email").InnerText);

                    txtName.Text = name;
                    txtEmail.Text = email;
                    txtUser.Text = suser;
                }

            }

            txtPass.UseSystemPasswordChar = true;
            txtPassConfirm.UseSystemPasswordChar = true;
            txtActualPass.UseSystemPasswordChar = true;

        }
        Boolean activePassActual = false;
        private void btnShowPassActual_Click(object sender, EventArgs e)
        {
            if (activePassActual)
            {
                activePassActual = false;
                txtActualPass.UseSystemPasswordChar = true;
                btnShowPassActual.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                activePassActual = true;
                txtActualPass.UseSystemPasswordChar = false;
                btnShowPassActual.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }
        Boolean activePass = false;
        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (activePass)
            {
                activePass = false;
                txtPass.UseSystemPasswordChar = true;
                btnShowPass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                activePass = true;
                txtPass.UseSystemPasswordChar = false;
                btnShowPass.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }
        Boolean activePassConfirm = false;
        private void btnShowConfirmPass_Click(object sender, EventArgs e)
        {
            if (activePassConfirm)
            {
                activePassConfirm = false;
                txtPassConfirm.UseSystemPasswordChar = true;
                btnShowConfirmPass.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            }
            else
            {
                activePassConfirm = true;
                txtPassConfirm.UseSystemPasswordChar = false;
                btnShowConfirmPass.IconChar = FontAwesome.Sharp.IconChar.Eye;
            }
        }

        private void clean()
        {
            txtActualPass.Text = String.Empty;
            txtPass.Text = String.Empty;
            txtPassConfirm.Text = String.Empty;
        }

        private void closeAllServers()
        {
            closeUdpClientS();
            closeUdpServerS();
            closeTcpClientS();
            closeTcpServerS();

            closeUdpClientM();
            closeUdpServerM();
            closeTcpClientM();
            closeTcpServerM();
        }
        public void closeUdpClientS()
        {
            for (int x = 0; x < DriverMaster.listUdpClientsConnectors.Count; x++)
            {
                DriverMaster.listUdpClientsConnectors[x].CloseUdp();
            }
        }

        public void closeUdpServerS()
        {
            for (int x = 0; x < DriverMaster.listUdpConnectors.Count; x++)
            {
                DriverMaster.listUdpConnectors[x].CloseUdp();
            }
        }

        public void closeTcpClientS()
        {
            for (int x = 0; x < DriverMaster.listTcpClientsConnectors.Count; x++)
            {
                DriverMaster.listTcpClientsConnectors[x].CloseTcp();
            }
        }

        public void closeTcpServerS()
        {
            for (int x = 0; x < DriverMaster.listTcpConnectors.Count; x++)
            {
                DriverMaster.listTcpConnectors[x].CloseTcp();
            }
        }


        public void closeUdpClientM()
        {
            for (int x = 0; x < DriverMaster.listUdpClientsConnectorsModem.Count; x++)
            {
                DriverMaster.listUdpClientsConnectorsModem[x].CloseUdp();
            }
        }

        public void closeUdpServerM()
        {
            for (int x = 0; x < DriverMaster.listUdpConnectorsModem.Count; x++)
            {
                DriverMaster.listUdpConnectorsModem[x].CloseUdp();
            }
        }

        public void closeTcpClientM()
        {
            for (int x = 0; x < DriverMaster.listTcpClientsConnectorsModem.Count; x++)
            {
                DriverMaster.listTcpClientsConnectorsModem[x].CloseTcp();
            }
        }

        public void closeTcpServerM()
        {
            for (int x = 0; x < DriverMaster.listTcpConnectorsModem.Count; x++)
            {
                DriverMaster.listTcpConnectorsModem[x].CloseTcp();
            }
        }
    }
}
