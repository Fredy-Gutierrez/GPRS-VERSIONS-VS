using GPRS.Clases;
using GPRS.Clases.Models;
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
        //UsersXml usersXml;
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(0, 210, 210);
            public static Color color2 = Color.FromArgb(196, 145, 235);
            public static Color color3 = Color.FromArgb(249, 118, 176);
            public static Color color4 = Color.FromArgb(253, 138, 114);
            public static Color color5 = Color.FromArgb(187, 236, 72);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }


        public FormCuenta()
        {
            InitializeComponent();
        }

        private void btnCloseSession_Click(object sender, EventArgs e)
        {
            if (Alerts.ShowWarning("¿Seguro desea Cerra la Sesión?"))
            {
                Session.closeSesion();

                FormPrincipal formPrincipal = FormPrincipal.formPrincipal;

                formPrincipal.Reset();

                formPrincipal.ActivateButton(formPrincipal.btnInicio, FormPrincipal.RGBColors.color1);
                formPrincipal.OpenChildForm(new FormInicio());

                this.Hide();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtActualPass.Text.Equals(Session.pass))
            {
                if (txtPass.Text.Equals(txtPassConfirm.Text))
                {
                    /*string name = Seguridad.Encriptar(txtName.Text);
                    string email = Seguridad.Encriptar(txtEmail.Text);
                    string user = Seguridad.Encriptar(txtUser.Text);
                    string password = Seguridad.Encriptar(txtPass.Text);

                    usersXml._Update(name,email,user,password);*/

                    string id = lblId.Text;
                    string name = txtName.Text;
                    string email = txtEmail.Text;
                    //string user = txtUser.Text;
                    string password = Seguridad.Encriptar(txtPass.Text);

                    UsersModel usersModel = new UsersModel();
                    if (usersModel.UpdateUser(id, name, email, password))
                    {
                        Alerts.ShowSuccess("Modificaciones Guardadas");
                        txtActualPass.Text = string.Empty;
                        txtPass.Text = string.Empty;
                        txtPassConfirm.Text = string.Empty;
                    }
                    else
                    {
                        Alerts.ShowError("No se pudo actualizar la información");
                    }

                }
                else
                {
                    Alerts.ShowInformation("La nueva contraseña y la confirmación no coinciden");
                }
            }
            else
            {
                Alerts.ShowError("La contraseña actual no coincide");
            }
        }

        private void FormCuenta_Load(object sender, EventArgs e)
        {
            lblUser.Text = Session.user;

            string username = Session.user;

            /*usersXml = new UsersXml();

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

            }*/

            UsersModel usersModel = new UsersModel();
            usersModel.getSesionUser(username);

            txtName.Text = Session.name;
            txtEmail.Text = Session.email;
            txtUser.Text = Session.user;
            lblId.Text = Convert.ToString(Session.id);

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
    }
}
