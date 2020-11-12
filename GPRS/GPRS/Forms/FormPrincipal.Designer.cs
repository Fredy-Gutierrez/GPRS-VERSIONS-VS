namespace GPRS
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);

            
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnRuteo = new FontAwesome.Sharp.IconButton();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.btnConfiguracion = new FontAwesome.Sharp.IconButton();
            this.btnUsuario = new FontAwesome.Sharp.IconButton();
            this.btnServidor = new FontAwesome.Sharp.IconButton();
            this.btnInicio = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMaximizar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.brnUserDA = new FontAwesome.Sharp.IconButton();
            this.btnConfigDA = new FontAwesome.Sharp.IconButton();
            this.btnRouteDA = new FontAwesome.Sharp.IconButton();
            this.btnAccountDA = new FontAwesome.Sharp.IconButton();
            this.btnServerDA = new FontAwesome.Sharp.IconButton();
            this.btnBeginDA = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panelMenu.Controls.Add(this.btnRuteo);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.btnConfiguracion);
            this.panelMenu.Controls.Add(this.btnUsuario);
            this.panelMenu.Controls.Add(this.btnServidor);
            this.panelMenu.Controls.Add(this.btnInicio);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(190, 613);
            this.panelMenu.TabIndex = 0;
            // 
            // btnRuteo
            // 
            this.btnRuteo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRuteo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRuteo.FlatAppearance.BorderSize = 0;
            this.btnRuteo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRuteo.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRuteo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.btnRuteo.IconChar = FontAwesome.Sharp.IconChar.NetworkWired;
            this.btnRuteo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(170)))), ((int)(((byte)(115)))));
            this.btnRuteo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRuteo.IconSize = 35;
            this.btnRuteo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRuteo.Location = new System.Drawing.Point(0, 338);
            this.btnRuteo.Name = "btnRuteo";
            this.btnRuteo.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnRuteo.Size = new System.Drawing.Size(190, 66);
            this.btnRuteo.TabIndex = 6;
            this.btnRuteo.Text = " Ruteo";
            this.btnRuteo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRuteo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRuteo.UseVisualStyleBackColor = true;
            this.btnRuteo.Click += new System.EventHandler(this.btnRuteo_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnCerrarSesion.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(170)))), ((int)(((byte)(115)))));
            this.btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrarSesion.IconSize = 35;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 547);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(190, 66);
            this.btnCerrarSesion.TabIndex = 5;
            this.btnCerrarSesion.Text = " Cuenta";
            this.btnCerrarSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.btnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnConfiguracion.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(170)))), ((int)(((byte)(115)))));
            this.btnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfiguracion.IconSize = 35;
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.Location = new System.Drawing.Point(-3, 414);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnConfiguracion.Size = new System.Drawing.Size(190, 66);
            this.btnConfiguracion.TabIndex = 4;
            this.btnConfiguracion.Text = "Configuraciones";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuario.FlatAppearance.BorderSize = 0;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.btnUsuario.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnUsuario.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(170)))), ((int)(((byte)(115)))));
            this.btnUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuario.IconSize = 35;
            this.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuario.Location = new System.Drawing.Point(0, 272);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnUsuario.Size = new System.Drawing.Size(190, 66);
            this.btnUsuario.TabIndex = 3;
            this.btnUsuario.Text = "Usuarios";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnServidor
            // 
            this.btnServidor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServidor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnServidor.FlatAppearance.BorderSize = 0;
            this.btnServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServidor.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServidor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.btnServidor.IconChar = FontAwesome.Sharp.IconChar.LaptopCode;
            this.btnServidor.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(170)))), ((int)(((byte)(115)))));
            this.btnServidor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnServidor.IconSize = 35;
            this.btnServidor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServidor.Location = new System.Drawing.Point(0, 206);
            this.btnServidor.Name = "btnServidor";
            this.btnServidor.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnServidor.Size = new System.Drawing.Size(190, 66);
            this.btnServidor.TabIndex = 2;
            this.btnServidor.Text = "Servidores";
            this.btnServidor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnServidor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnServidor.UseVisualStyleBackColor = true;
            this.btnServidor.Click += new System.EventHandler(this.btnServidor_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.btnInicio.IconChar = FontAwesome.Sharp.IconChar.HouseUser;
            this.btnInicio.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(170)))), ((int)(((byte)(115)))));
            this.btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInicio.IconSize = 35;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(0, 140);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.btnInicio.Size = new System.Drawing.Size(190, 66);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(190, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(12, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(169, 122);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panelTitleBar.Controls.Add(this.btnCerrar);
            this.panelTitleBar.Controls.Add(this.btnMaximizar);
            this.panelTitleBar.Controls.Add(this.btnMinimizar);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(190, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(912, 70);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnCerrar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnCerrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 25;
            this.btnCerrar.Location = new System.Drawing.Point(877, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnMaximizar.ForeColor = System.Drawing.Color.DarkGray;
            this.btnMaximizar.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximizar.IconColor = System.Drawing.Color.DarkGray;
            this.btnMaximizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximizar.IconSize = 23;
            this.btnMaximizar.Location = new System.Drawing.Point(840, 9);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(31, 23);
            this.btnMaximizar.TabIndex = 3;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnMinimizar.ForeColor = System.Drawing.Color.Gray;
            this.btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimizar.IconColor = System.Drawing.Color.Gray;
            this.btnMinimizar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimizar.IconSize = 23;
            this.btnMinimizar.Location = new System.Drawing.Point(803, 11);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(31, 23);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(255)))), ((int)(((byte)(227)))));
            this.lblTitleChildForm.Location = new System.Drawing.Point(59, 32);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(44, 16);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Inicio";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.Cyan;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.Cyan;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(26, 22);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(32, 32);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(190, 70);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(912, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.panelDesktop.Controls.Add(this.brnUserDA);
            this.panelDesktop.Controls.Add(this.btnConfigDA);
            this.panelDesktop.Controls.Add(this.btnRouteDA);
            this.panelDesktop.Controls.Add(this.btnAccountDA);
            this.panelDesktop.Controls.Add(this.btnServerDA);
            this.panelDesktop.Controls.Add(this.btnBeginDA);
            this.panelDesktop.Controls.Add(this.pictureBox1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(190, 79);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(912, 534);
            this.panelDesktop.TabIndex = 3;
            this.panelDesktop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktop_Paint);
            // 
            // brnUserDA
            // 
            this.brnUserDA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.brnUserDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.brnUserDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.brnUserDA.FlatAppearance.BorderSize = 0;
            this.brnUserDA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.brnUserDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnUserDA.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.brnUserDA.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brnUserDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.brnUserDA.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.brnUserDA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(127)))), ((int)(((byte)(230)))));
            this.brnUserDA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.brnUserDA.IconSize = 35;
            this.brnUserDA.Location = new System.Drawing.Point(600, 265);
            this.brnUserDA.MaximumSize = new System.Drawing.Size(181, 95);
            this.brnUserDA.MinimumSize = new System.Drawing.Size(141, 55);
            this.brnUserDA.Name = "brnUserDA";
            this.brnUserDA.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.brnUserDA.Size = new System.Drawing.Size(141, 55);
            this.brnUserDA.TabIndex = 7;
            this.brnUserDA.Text = "Usuarios";
            this.brnUserDA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.brnUserDA.UseVisualStyleBackColor = false;
            this.brnUserDA.Click += new System.EventHandler(this.brnUserDA_Click);
            // 
            // btnConfigDA
            // 
            this.btnConfigDA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfigDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.btnConfigDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfigDA.FlatAppearance.BorderSize = 0;
            this.btnConfigDA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnConfigDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigDA.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnConfigDA.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(131)))), ((int)(((byte)(193)))));
            this.btnConfigDA.IconChar = FontAwesome.Sharp.IconChar.Toolbox;
            this.btnConfigDA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(39)))), ((int)(((byte)(116)))));
            this.btnConfigDA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfigDA.IconSize = 35;
            this.btnConfigDA.Location = new System.Drawing.Point(366, 381);
            this.btnConfigDA.MaximumSize = new System.Drawing.Size(231, 95);
            this.btnConfigDA.MinimumSize = new System.Drawing.Size(191, 55);
            this.btnConfigDA.Name = "btnConfigDA";
            this.btnConfigDA.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnConfigDA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnConfigDA.Size = new System.Drawing.Size(191, 55);
            this.btnConfigDA.TabIndex = 6;
            this.btnConfigDA.Text = "Configuraciones";
            this.btnConfigDA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfigDA.UseVisualStyleBackColor = false;
            this.btnConfigDA.Click += new System.EventHandler(this.btnConfigDA_Click);
            // 
            // btnRouteDA
            // 
            this.btnRouteDA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRouteDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.btnRouteDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRouteDA.FlatAppearance.BorderSize = 0;
            this.btnRouteDA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnRouteDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRouteDA.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnRouteDA.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRouteDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(255)))), ((int)(((byte)(154)))));
            this.btnRouteDA.IconChar = FontAwesome.Sharp.IconChar.Wifi;
            this.btnRouteDA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(201)))), ((int)(((byte)(31)))));
            this.btnRouteDA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRouteDA.IconSize = 35;
            this.btnRouteDA.Location = new System.Drawing.Point(175, 380);
            this.btnRouteDA.MaximumSize = new System.Drawing.Size(177, 95);
            this.btnRouteDA.MinimumSize = new System.Drawing.Size(137, 55);
            this.btnRouteDA.Name = "btnRouteDA";
            this.btnRouteDA.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnRouteDA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRouteDA.Size = new System.Drawing.Size(137, 55);
            this.btnRouteDA.TabIndex = 5;
            this.btnRouteDA.Text = "Ruteo";
            this.btnRouteDA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRouteDA.UseVisualStyleBackColor = false;
            this.btnRouteDA.Click += new System.EventHandler(this.btnRouteDA_Click);
            // 
            // btnAccountDA
            // 
            this.btnAccountDA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAccountDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.btnAccountDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountDA.FlatAppearance.BorderSize = 0;
            this.btnAccountDA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnAccountDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountDA.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnAccountDA.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(250)))), ((int)(((byte)(191)))));
            this.btnAccountDA.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnAccountDA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(201)))), ((int)(((byte)(52)))));
            this.btnAccountDA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAccountDA.IconSize = 35;
            this.btnAccountDA.Location = new System.Drawing.Point(600, 381);
            this.btnAccountDA.MaximumSize = new System.Drawing.Size(181, 95);
            this.btnAccountDA.MinimumSize = new System.Drawing.Size(141, 55);
            this.btnAccountDA.Name = "btnAccountDA";
            this.btnAccountDA.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnAccountDA.Size = new System.Drawing.Size(141, 55);
            this.btnAccountDA.TabIndex = 4;
            this.btnAccountDA.Text = "Cuenta";
            this.btnAccountDA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAccountDA.UseVisualStyleBackColor = false;
            this.btnAccountDA.Click += new System.EventHandler(this.btnAccountDA_Click);
            // 
            // btnServerDA
            // 
            this.btnServerDA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnServerDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.btnServerDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnServerDA.FlatAppearance.BorderSize = 0;
            this.btnServerDA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnServerDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerDA.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnServerDA.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServerDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(216)))), ((int)(((byte)(212)))));
            this.btnServerDA.IconChar = FontAwesome.Sharp.IconChar.Server;
            this.btnServerDA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(139)))));
            this.btnServerDA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnServerDA.IconSize = 35;
            this.btnServerDA.Location = new System.Drawing.Point(366, 267);
            this.btnServerDA.MaximumSize = new System.Drawing.Size(231, 95);
            this.btnServerDA.MinimumSize = new System.Drawing.Size(191, 55);
            this.btnServerDA.Name = "btnServerDA";
            this.btnServerDA.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnServerDA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnServerDA.Size = new System.Drawing.Size(191, 55);
            this.btnServerDA.TabIndex = 3;
            this.btnServerDA.Text = "Servidores";
            this.btnServerDA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnServerDA.UseVisualStyleBackColor = false;
            this.btnServerDA.Click += new System.EventHandler(this.btnServerDA_Click);
            // 
            // btnBeginDA
            // 
            this.btnBeginDA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBeginDA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.btnBeginDA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBeginDA.FlatAppearance.BorderSize = 0;
            this.btnBeginDA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnBeginDA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeginDA.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.btnBeginDA.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeginDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(202)))), ((int)(((byte)(255)))));
            this.btnBeginDA.IconChar = FontAwesome.Sharp.IconChar.HouseUser;
            this.btnBeginDA.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(120)))), ((int)(((byte)(231)))));
            this.btnBeginDA.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBeginDA.IconSize = 35;
            this.btnBeginDA.Location = new System.Drawing.Point(175, 267);
            this.btnBeginDA.MaximumSize = new System.Drawing.Size(177, 95);
            this.btnBeginDA.MinimumSize = new System.Drawing.Size(137, 55);
            this.btnBeginDA.Name = "btnBeginDA";
            this.btnBeginDA.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnBeginDA.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBeginDA.Size = new System.Drawing.Size(137, 55);
            this.btnBeginDA.TabIndex = 2;
            this.btnBeginDA.Text = "Inicio";
            this.btnBeginDA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBeginDA.UseVisualStyleBackColor = false;
            this.btnBeginDA.Click += new System.EventHandler(this.btnBeginDA_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(291, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 192);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1102, 613);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 562);
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private FontAwesome.Sharp.IconPictureBox btnMaximizar;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton brnUserDA;
        private FontAwesome.Sharp.IconButton btnConfigDA;
        private FontAwesome.Sharp.IconButton btnRouteDA;
        private FontAwesome.Sharp.IconButton btnAccountDA;
        private FontAwesome.Sharp.IconButton btnServerDA;
        private FontAwesome.Sharp.IconButton btnBeginDA;
        public FontAwesome.Sharp.IconButton btnCerrarSesion;
        public FontAwesome.Sharp.IconButton btnConfiguracion;
        public FontAwesome.Sharp.IconButton btnUsuario;
        public FontAwesome.Sharp.IconButton btnServidor;
        public FontAwesome.Sharp.IconButton btnInicio;
        public FontAwesome.Sharp.IconButton btnRuteo;
        public System.Windows.Forms.Panel panelDesktop;
    }
}

