using GPRS.Clases;
using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GPRS.Forms
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
            txtPass.UseSystemPasswordChar = false;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (new Warning("¿Seguro desea cerrar el Programa?").ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.FromArgb(90, 90, 90);
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.UseSystemPasswordChar = true;
                txtPass.ForeColor = Color.Black;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.UseSystemPasswordChar = false;
                txtPass.ForeColor = Color.FromArgb(90, 90, 90);
            }
        }

        private void btnForgotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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

        private void btnSesion_Click(object sender, EventArgs e)
        {
            Boolean user = false;

            string username = Seguridad.Encriptar(txtUser.Text);
            string password = Seguridad.Encriptar(txtPass.Text);

            UsersXml usersXml = new UsersXml();

            usersXml._CreateXml();

            
            XmlNodeList route = usersXml._ReadXml();

            XmlNode list;

            if (route.Count < 1)
            {
                user = true;
            }
            else
            {
                for (int i = 0; i < route.Count; i++)
                {
                    list = route.Item(i);

                    string suser = list.SelectSingleNode("UserName").InnerText;
                    string spass = list.SelectSingleNode("Password").InnerText;

                    if (username.Equals(suser) && password.Equals(spass))
                    {
                        user = true;
                    }

                }
            }

            if (user)
            {
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();

                Session.user = txtUser.Text;
                Session.pass = txtPass.Text;
                this.Hide();
            }
            else
            {
                new Information("El usuario y/o contraseña son incorrectos").ShowDialog();
            }
            
        }
    }
}
