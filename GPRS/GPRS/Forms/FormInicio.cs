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
        FormPrincipal formPrincipal;
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(0, 210, 210);
            public static Color color2 = Color.FromArgb(196, 145, 235);
            public static Color color3 = Color.FromArgb(249, 118, 176);
            public static Color color4 = Color.FromArgb(253, 138, 114);
            public static Color color5 = Color.FromArgb(187, 236, 72);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }
        public FormInicio(FormPrincipal formPrincipal)
        {
            InitializeComponent();
            this.formPrincipal = formPrincipal;
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnBeginDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnInicio, RGBColors.color1);
            //OpenChildForm(new FormInicio());
            formPrincipal.currentChildForm = new FormInicio(formPrincipal);
            formPrincipal.currentChildForm.TopLevel = false;
            formPrincipal.currentChildForm.FormBorderStyle = FormBorderStyle.None;
            formPrincipal.currentChildForm.Dock = DockStyle.Fill;
            formPrincipal.panelDesktop.Controls.Add(formPrincipal.currentChildForm);
            formPrincipal.panelDesktop.Tag = formPrincipal.currentChildForm;
            formPrincipal.currentChildForm.Show();
            formPrincipal.currentChildForm.BringToFront();
        }

        private void btnServerDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnServidor, RGBColors.color2);
            formPrincipal.OpenChildForm<FormServidor>();
        }

        private void brnUserDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnUsuario, RGBColors.color3);
            formPrincipal.OpenChildForm<FormUsuarios>();
        }

        private void btnRouteDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnRuteo, RGBColors.color6);
            formPrincipal.OpenChildForm<FormRuteo>();
        }

        private void btnConfigDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnConfiguracion, RGBColors.color4);
            formPrincipal.OpenChildForm<FormConfiguraciones>();
        }

        private void btnAccountDA_Click(object sender, EventArgs e)
        {
            formPrincipal.ActivateButton(formPrincipal.btnCerrarSesion, RGBColors.color5);
            formPrincipal.OpenChildForm<FormCuenta>();
        }
    }
}
