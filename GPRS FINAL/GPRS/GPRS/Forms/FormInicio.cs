using GPRS.Clases;
using GPRS.Forms.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPRS.Forms
{
    public partial class FormInicio : Form
    {
        readonly FormPrincipal formPrincipal;

        public FormInicio()
        {
            InitializeComponent();
            this.formPrincipal = FormPrincipal.formPrincipal;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnBeginDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnInicio, FormPrincipal.RGBColors.color1);
            formPrincipal.OpenChildForm(new FormInicio());
        }

        private void btnServerDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnServidor, FormPrincipal.RGBColors.color3);
            formPrincipal.OpenChildForm(formPrincipal.formServidor);
        }

        private void brnUserDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnUsuario, FormPrincipal.RGBColors.color3);
            formPrincipal.OpenChildForm(new FormUsuarios());
        }

        private void btnRouteDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnRuteo, FormPrincipal.RGBColors.color3);
            formPrincipal.OpenChildForm(new FormRuteo());
        }

        private void btnConfigDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnConfiguracion, FormPrincipal.RGBColors.color3);
            formPrincipal.OpenChildForm(new FormConfiguraciones());
        }

        private void btnAccountDA_Click(object sender, EventArgs e)
        {
            if (!Session.user.Equals(""))
            {
                formPrincipal.ActivateButton(formPrincipal.btnCerrarSesion, FormPrincipal.RGBColors.color3);
                formPrincipal.OpenChildForm(new FormCuenta());
            }
            else
            {
                FormLogIn formLogIn = formPrincipal.formLogIn;
                formLogIn.Show();
            }
        }

    }
}
