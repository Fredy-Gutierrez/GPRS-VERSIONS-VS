using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;
using GPRS.Forms;
using GPRS.Forms.Messages;

namespace GPRS
{
    public partial class FormPrincipal : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public Form currentChildForm;

        public static FormPrincipal formPrincipal;

        public FormPrincipal()
        {

            InitializeComponent();
            formPrincipal = this;
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 66);
            panelMenu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private struct RGBColors{
            public static Color color1 = Color.FromArgb(0, 210, 210);
            public static Color color2 = Color.FromArgb(196, 145, 235);
            public static Color color3 = Color.FromArgb(249, 118, 176);
            public static Color color4 = Color.FromArgb(253, 138, 114);
            public static Color color5 = Color.FromArgb(187, 236, 72);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        public void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(97,97,97);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                lblTitleChildForm.Text = currentBtn.Text;
            }
        }

        public void DisableButton()
        {
            if(currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(50, 50, 50);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                //25, 170, 115
                currentBtn.IconColor = Color.FromArgb(25, 170, 115);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void OpenChildForm<MiForm>() where MiForm : Form, new()
        {

            currentChildForm = panelDesktop.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
                                                                                     //si el formulario/instancia no existe
            if (currentChildForm == null)
            {
                currentChildForm = new MiForm();
                currentChildForm.TopLevel = false;
                currentChildForm.FormBorderStyle = FormBorderStyle.None;
                currentChildForm.Dock = DockStyle.Fill;
                panelDesktop.Controls.Add(currentChildForm);
                panelDesktop.Tag = currentChildForm;
                currentChildForm.Show();
                currentChildForm.BringToFront();
            }
            else
            {
                currentChildForm.BringToFront();
            }

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            currentChildForm = new FormInicio(this);
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(currentChildForm);
            panelDesktop.Tag = currentChildForm;
            currentChildForm.Show();
            currentChildForm.BringToFront();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.Cyan;
            lblTitleChildForm.Text = "Inicio";
        }


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            //OpenChildForm(new FormInicio());

            currentChildForm = new FormInicio(this);
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(currentChildForm);
            panelDesktop.Tag = currentChildForm;
            currentChildForm.Show();
            currentChildForm.BringToFront();

            //OpenChildForm<FormInicio>();
        }

        private void btnServidor_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm<FormServidor>();
        }

        /**/

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm<FormUsuarios>();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm<FormConfiguraciones>();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm<FormCuenta>();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (new Warning("¿Seguro desea cerrar el Programa?").ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRuteo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm<FormRuteo>();
        }

        private void btnBeginDA_Click(object sender, EventArgs e)
        {
            ActivateButton(btnInicio, RGBColors.color1);
            //OpenChildForm(new FormInicio());
            currentChildForm = new FormInicio(this);
            currentChildForm.TopLevel = false;
            currentChildForm.FormBorderStyle = FormBorderStyle.None;
            currentChildForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(currentChildForm);
            panelDesktop.Tag = currentChildForm;
            currentChildForm.Show();
            currentChildForm.BringToFront();
        }

        private void btnServerDA_Click(object sender, EventArgs e)
        {
            ActivateButton(btnServidor, RGBColors.color2);
            OpenChildForm<FormServidor>();
        }

        private void brnUserDA_Click(object sender, EventArgs e)
        {
            ActivateButton(btnUsuario, RGBColors.color3);
            OpenChildForm<FormUsuarios>();
        }

        private void btnRouteDA_Click(object sender, EventArgs e)
        {
            ActivateButton(btnRuteo, RGBColors.color6);
            OpenChildForm<FormRuteo>();
        }

        private void btnConfigDA_Click(object sender, EventArgs e)
        {
            ActivateButton(btnConfiguracion, RGBColors.color4);
            OpenChildForm<FormConfiguraciones>();
        }

        private void btnAccountDA_Click(object sender, EventArgs e)
        {
            ActivateButton(btnCerrarSesion, RGBColors.color5);
            OpenChildForm<FormCuenta>();
        }
    }
}
