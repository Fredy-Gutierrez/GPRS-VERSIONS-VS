using GPRS.Clases;
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
    public partial class FormCliente : Form
    {
        UDPClientes udpClientes;
        public FormCliente()
        {
            InitializeComponent();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            btnCambiar.Enabled = false;
            txtMensaje.Enabled = false;
            btnEnviar.Enabled = false;
            udpClientes = new UDPClientes(this);
        }
        #region vista de textbox
        private void txtIP_Enter(object sender, EventArgs e)
        {
            if (txtIP.Text == "Direccion IP")
            {
                txtIP.Text = "";
                txtIP.ForeColor = Color.LightGray;
            }
        }

        private void txtIP_Leave(object sender, EventArgs e)
        {
            if (txtIP.Text == "")
            {
                txtIP.Text = "Direccion IP";
                txtIP.ForeColor = Color.DarkGray;
            }
        }

        private void txtPuerto_Enter(object sender, EventArgs e)
        {
            if (txtPuerto.Text == "Puerto")
            {
                txtPuerto.Text = "";
                txtPuerto.ForeColor = Color.LightGray;
            }
        }

        private void txtPuerto_Leave(object sender, EventArgs e)
        {
            if (txtPuerto.Text == "")
            {
                txtPuerto.Text = "Puerto";
                txtPuerto.ForeColor = Color.DarkGray;
            }
        }

        private void txtMensaje_Enter(object sender, EventArgs e)
        {
            if (txtMensaje.Text == "Escribe un mensaje")
            {
                txtMensaje.Text = "";
                txtMensaje.ForeColor = Color.LightGray;
            }
        }

        private void txtMensaje_Leave(object sender, EventArgs e)
        {
            //Escribe un mensaje
            if (txtMensaje.Text == "")
            {
                txtMensaje.Text = "Escribe un mensaje";
                txtMensaje.ForeColor = Color.DarkGray;
            }
        }
        #endregion

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtIP.Text != "" && txtPuerto.Text != "")
            {
                txtIP.Enabled = false;
                txtPuerto.Enabled = false;
                btnIniciar.Enabled = false;
                btnCambiar.Enabled = true;
                txtMensaje.Enabled = true;
                btnEnviar.Enabled = true;

                /*****************************CODIGO DE INICIO DEL CLIENTE UDP*********************************/

                udpClientes.iniciar(txtIP.Text, txtPuerto.Text);
                MessageBox.Show("Coneccion UDP exitosa");
            }
            else
            {
                MessageBox.Show("Necesarios el puerto y la IP del destino");
            }
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            txtIP.Enabled = true;
            txtPuerto.Enabled = true;
            btnIniciar.Enabled = true;
            btnCambiar.Enabled = false;
            txtMensaje.Enabled = false;
            btnEnviar.Enabled = false;
        }
        public void mensajes(String msg)
        {
            txtMensajes.Text += msg;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text != "" && txtMensaje.Text != "Escribe un mensaje")
            {
                udpClientes.enviar(txtMensaje.Text);
                txtMensaje.Text = "Escribe un mensaje";
            }
            else
            {
                MessageBox.Show("Nada para enviar");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
