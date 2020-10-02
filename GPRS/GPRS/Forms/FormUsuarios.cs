using GPRS.Clases;
using GPRS.Forms.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GPRS.Forms
{
    public partial class FormUsuarios : Form
    {
        UsersXml user;
        public FormUsuarios()
        {
            InitializeComponent();
            user = new UsersXml();
            user._CreateXml();
        }

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            
            Font font = new Font("Century Gothic", 14.25f, FontStyle.Bold);
            

            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(label1.ClientRectangle, Color.FromArgb(4, 162, 247), Color.FromArgb(36, 236, 162), 45F);

            e.Graphics.DrawString("Usuarios",font,linearGradientBrush, label1.ClientRectangle);

        }

        private void FormUsuarios_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
            int x = this.Width;

            tablaUsuarios.Width =  x-430;
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            txtPassConfirm.UseSystemPasswordChar = true;
            chargeTable();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string user = txtUser.Text;
            string pass = txtPass.Text;
            string confirmpass = txtPassConfirm.Text;


            if (pass.Equals(confirmpass))
            {

                if (this.user._FindNodo(Seguridad.Encriptar(user)))
                {
                    new Information("¡Este usuario ya esta registrado!").ShowDialog();
                }
                else
                {

                    this.user._Add(Seguridad.Encriptar(name), Seguridad.Encriptar(email), Seguridad.Encriptar(user), Seguridad.Encriptar(pass));

                    new Success("Guardado correctamente").ShowDialog();


                    txtName.Text = String.Empty;
                    txtEmail.Text = String.Empty;
                    txtUser.Text = String.Empty;
                    txtPass.Text = String.Empty;
                    txtPassConfirm.Text = String.Empty;

                    tablaUsuarios.Rows.Clear();
                    chargeTable();
                }
            }
            else
            {
                new Information("La contraseña y confirmacion no concuerdan").ShowDialog();
            }
        }

        private void chargeTable()
        {
            XmlNodeList route = this.user._ReadXml();

            XmlNode list;

            for (int i = 0; i < route.Count; i++)
            {
                list = route.Item(i);

                string sname = list.SelectSingleNode("Name").InnerText;
                string suser = list.SelectSingleNode("UserName").InnerText;

                tablaUsuarios.Rows.Add(Seguridad.DesEncriptar(sname), Seguridad.DesEncriptar(suser));
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tablaUsuarios.CurrentRow.Selected)
            {
                try
                {
                    //if (MessageBox.Show("¿Seguro deseas eliminar esta fila?, ¡se eliminará completamente!", "Eliminar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (new Warning("¿Seguro deseas eliminar esta fila ?").ShowDialog() == DialogResult.OK)
                    {
                        string name = tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells["Nombre"].Value.ToString();
                        string user = tablaUsuarios.Rows[tablaUsuarios.CurrentRow.Index].Cells["Usuario"].Value.ToString();

                        if (this.user._FindNodo(Seguridad.Encriptar(user)))
                        {
                            this.user._DeleteNodo(Seguridad.Encriptar(user));
                            new Success("Se ha borrado correctamente").ShowDialog();
                        }
                        tablaUsuarios.Rows.Remove(tablaUsuarios.CurrentRow);
                    }
                }
                catch (XmlException xe)
                {
                    Console.WriteLine(xe.Message.ToString());
                    new Error("Esta fila no se puede eliminar").ShowDialog();
                }
            }
            else
            {
                new Information("Seleccione la fila que desea eliminar").ShowDialog();
            }
        }


    }
}
