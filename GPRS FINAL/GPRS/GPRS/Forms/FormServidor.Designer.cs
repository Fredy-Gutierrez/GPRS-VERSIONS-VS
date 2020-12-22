namespace GPRS.Forms
{
    partial class FormServidor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtMensajes = new System.Windows.Forms.RichTextBox();
            this.Menú = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyItem = new FontAwesome.Sharp.IconMenuItem();
            this.cleanItem = new FontAwesome.Sharp.IconMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUdpClientServer = new System.Windows.Forms.Label();
            this.lblUdpServerServer = new System.Windows.Forms.Label();
            this.lblTcpClientServer = new System.Windows.Forms.Label();
            this.lblTcpServerServer = new System.Windows.Forms.Label();
            this.lblTcpServerModem = new System.Windows.Forms.Label();
            this.lblTcpClientModem = new System.Windows.Forms.Label();
            this.lblUdpServerModem = new System.Windows.Forms.Label();
            this.lblUdpClientModem = new System.Windows.Forms.Label();
            this.lblTitleServer = new System.Windows.Forms.Label();
            this.lblTitleModem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtMaxWindows = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureInformation = new System.Windows.Forms.PictureBox();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.switchBtnTcpServerModem = new GPRS.CeLearningToggle();
            this.switchBtnTcpClientModem = new GPRS.CeLearningToggle();
            this.switchBtnUdpServerModem = new GPRS.CeLearningToggle();
            this.switchBtnUdpClientModem = new GPRS.CeLearningToggle();
            this.switchBtnTcpServerSock = new GPRS.CeLearningToggle();
            this.switchBtnTcpClientSock = new GPRS.CeLearningToggle();
            this.switchBtnUdpClientSock = new GPRS.CeLearningToggle();
            this.switchBtnUdpServerSock = new GPRS.CeLearningToggle();
            this.Menú.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMensajes
            // 
            this.txtMensajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(89)))), ((int)(((byte)(89)))));
            this.txtMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensajes.ContextMenuStrip = this.Menú;
            this.txtMensajes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMensajes.HideSelection = false;
            this.txtMensajes.Location = new System.Drawing.Point(3, 233);
            this.txtMensajes.Name = "txtMensajes";
            this.txtMensajes.ReadOnly = true;
            this.txtMensajes.Size = new System.Drawing.Size(892, 186);
            this.txtMensajes.TabIndex = 10;
            this.txtMensajes.Text = "";
            this.txtMensajes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMensajes_MouseClick);
            // 
            // Menú
            // 
            this.Menú.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyItem,
            this.cleanItem});
            this.Menú.Name = "Menú";
            this.Menú.Size = new System.Drawing.Size(118, 48);
            // 
            // copyItem
            // 
            this.copyItem.IconChar = FontAwesome.Sharp.IconChar.Copy;
            this.copyItem.IconColor = System.Drawing.Color.Black;
            this.copyItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.copyItem.IconSize = 16;
            this.copyItem.Name = "copyItem";
            this.copyItem.Size = new System.Drawing.Size(117, 22);
            this.copyItem.Text = "Copiar";
            this.copyItem.Click += new System.EventHandler(this.copyItem_Click);
            // 
            // cleanItem
            // 
            this.cleanItem.IconChar = FontAwesome.Sharp.IconChar.TrashRestoreAlt;
            this.cleanItem.IconColor = System.Drawing.Color.Black;
            this.cleanItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.cleanItem.IconSize = 16;
            this.cleanItem.Name = "cleanItem";
            this.cleanItem.Size = new System.Drawing.Size(117, 22);
            this.cleanItem.Text = "Eliminar";
            this.cleanItem.Click += new System.EventHandler(this.cleanItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(423, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "MENSAJES";
            // 
            // lblUdpClientServer
            // 
            this.lblUdpClientServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUdpClientServer.AutoSize = true;
            this.lblUdpClientServer.BackColor = System.Drawing.Color.Transparent;
            this.lblUdpClientServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUdpClientServer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUdpClientServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblUdpClientServer.Location = new System.Drawing.Point(247, 27);
            this.lblUdpClientServer.Name = "lblUdpClientServer";
            this.lblUdpClientServer.Size = new System.Drawing.Size(99, 19);
            this.lblUdpClientServer.TabIndex = 22;
            this.lblUdpClientServer.Text = "Udp Cliente";
            this.lblUdpClientServer.Click += new System.EventHandler(this.lblUdpClientServer_Click);
            // 
            // lblUdpServerServer
            // 
            this.lblUdpServerServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUdpServerServer.AutoSize = true;
            this.lblUdpServerServer.BackColor = System.Drawing.Color.Transparent;
            this.lblUdpServerServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUdpServerServer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUdpServerServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblUdpServerServer.Location = new System.Drawing.Point(247, 69);
            this.lblUdpServerServer.Name = "lblUdpServerServer";
            this.lblUdpServerServer.Size = new System.Drawing.Size(107, 19);
            this.lblUdpServerServer.TabIndex = 23;
            this.lblUdpServerServer.Text = "Udp Servidor";
            this.lblUdpServerServer.Click += new System.EventHandler(this.lblUdpServerServer_Click);
            // 
            // lblTcpClientServer
            // 
            this.lblTcpClientServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTcpClientServer.AutoSize = true;
            this.lblTcpClientServer.BackColor = System.Drawing.Color.Transparent;
            this.lblTcpClientServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTcpClientServer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTcpClientServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblTcpClientServer.Location = new System.Drawing.Point(247, 109);
            this.lblTcpClientServer.Name = "lblTcpClientServer";
            this.lblTcpClientServer.Size = new System.Drawing.Size(95, 19);
            this.lblTcpClientServer.TabIndex = 24;
            this.lblTcpClientServer.Text = "Tcp Cliente";
            this.lblTcpClientServer.Click += new System.EventHandler(this.lblTcpClientServer_Click);
            // 
            // lblTcpServerServer
            // 
            this.lblTcpServerServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTcpServerServer.AutoSize = true;
            this.lblTcpServerServer.BackColor = System.Drawing.Color.Transparent;
            this.lblTcpServerServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTcpServerServer.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTcpServerServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblTcpServerServer.Location = new System.Drawing.Point(247, 148);
            this.lblTcpServerServer.Name = "lblTcpServerServer";
            this.lblTcpServerServer.Size = new System.Drawing.Size(103, 19);
            this.lblTcpServerServer.TabIndex = 25;
            this.lblTcpServerServer.Text = "Tcp Servidor";
            this.lblTcpServerServer.Click += new System.EventHandler(this.lblTcpServerServer_Click);
            // 
            // lblTcpServerModem
            // 
            this.lblTcpServerModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTcpServerModem.AutoSize = true;
            this.lblTcpServerModem.BackColor = System.Drawing.Color.Transparent;
            this.lblTcpServerModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTcpServerModem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTcpServerModem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblTcpServerModem.Location = new System.Drawing.Point(579, 148);
            this.lblTcpServerModem.Name = "lblTcpServerModem";
            this.lblTcpServerModem.Size = new System.Drawing.Size(103, 19);
            this.lblTcpServerModem.TabIndex = 29;
            this.lblTcpServerModem.Text = "Tcp Servidor";
            this.lblTcpServerModem.Click += new System.EventHandler(this.lblTcpServerModem_Click);
            // 
            // lblTcpClientModem
            // 
            this.lblTcpClientModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTcpClientModem.AutoSize = true;
            this.lblTcpClientModem.BackColor = System.Drawing.Color.Transparent;
            this.lblTcpClientModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTcpClientModem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTcpClientModem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblTcpClientModem.Location = new System.Drawing.Point(579, 109);
            this.lblTcpClientModem.Name = "lblTcpClientModem";
            this.lblTcpClientModem.Size = new System.Drawing.Size(95, 19);
            this.lblTcpClientModem.TabIndex = 28;
            this.lblTcpClientModem.Text = "Tcp Cliente";
            this.lblTcpClientModem.Click += new System.EventHandler(this.lblTcpClientModem_Click);
            // 
            // lblUdpServerModem
            // 
            this.lblUdpServerModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUdpServerModem.AutoSize = true;
            this.lblUdpServerModem.BackColor = System.Drawing.Color.Transparent;
            this.lblUdpServerModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUdpServerModem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUdpServerModem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblUdpServerModem.Location = new System.Drawing.Point(579, 69);
            this.lblUdpServerModem.Name = "lblUdpServerModem";
            this.lblUdpServerModem.Size = new System.Drawing.Size(107, 19);
            this.lblUdpServerModem.TabIndex = 27;
            this.lblUdpServerModem.Text = "Udp Servidor";
            this.lblUdpServerModem.Click += new System.EventHandler(this.lblUdpServerModem_Click);
            // 
            // lblUdpClientModem
            // 
            this.lblUdpClientModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUdpClientModem.AutoSize = true;
            this.lblUdpClientModem.BackColor = System.Drawing.Color.Transparent;
            this.lblUdpClientModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUdpClientModem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUdpClientModem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(51)))));
            this.lblUdpClientModem.Location = new System.Drawing.Point(579, 27);
            this.lblUdpClientModem.Name = "lblUdpClientModem";
            this.lblUdpClientModem.Size = new System.Drawing.Size(99, 19);
            this.lblUdpClientModem.TabIndex = 26;
            this.lblUdpClientModem.Text = "Udp Cliente";
            this.lblUdpClientModem.Click += new System.EventHandler(this.lblUdpClientModem_Click);
            // 
            // lblTitleServer
            // 
            this.lblTitleServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitleServer.AutoSize = true;
            this.lblTitleServer.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleServer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(185)))), ((int)(((byte)(255)))));
            this.lblTitleServer.Location = new System.Drawing.Point(163, 30);
            this.lblTitleServer.Name = "lblTitleServer";
            this.lblTitleServer.Size = new System.Drawing.Size(65, 18);
            this.lblTitleServer.TabIndex = 32;
            this.lblTitleServer.Text = "Sockets";
            // 
            // lblTitleModem
            // 
            this.lblTitleModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitleModem.AutoSize = true;
            this.lblTitleModem.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleModem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleModem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(145)))), ((int)(((byte)(235)))));
            this.lblTitleModem.Location = new System.Drawing.Point(692, 35);
            this.lblTitleModem.Name = "lblTitleModem";
            this.lblTitleModem.Size = new System.Drawing.Size(72, 18);
            this.lblTitleModem.TabIndex = 33;
            this.lblTitleModem.Text = "Módems";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(287, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 38);
            this.label1.TabIndex = 34;
            this.label1.Text = "Ventanas\r\ntotales";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel4.Location = new System.Drawing.Point(389, 472);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(132, 2);
            this.panel4.TabIndex = 36;
            // 
            // txtMaxWindows
            // 
            this.txtMaxWindows.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtMaxWindows.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.txtMaxWindows.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMaxWindows.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaxWindows.ForeColor = System.Drawing.Color.Gainsboro;
            this.txtMaxWindows.Location = new System.Drawing.Point(389, 440);
            this.txtMaxWindows.Name = "txtMaxWindows";
            this.txtMaxWindows.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMaxWindows.Size = new System.Drawing.Size(132, 26);
            this.txtMaxWindows.TabIndex = 35;
            this.txtMaxWindows.DoubleClick += new System.EventHandler(this.txtMaxWindows_DoubleClick);
            this.txtMaxWindows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxWindows_KeyPress);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // pictureInformation
            // 
            this.pictureInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureInformation.BackColor = System.Drawing.Color.Transparent;
            this.pictureInformation.Image = global::GPRS.Properties.Resources.informacion;
            this.pictureInformation.Location = new System.Drawing.Point(866, 1);
            this.pictureInformation.Name = "pictureInformation";
            this.pictureInformation.Size = new System.Drawing.Size(29, 22);
            this.pictureInformation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureInformation.TabIndex = 60;
            this.pictureInformation.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(225)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnAdd.IconSize = 22;
            this.btnAdd.Location = new System.Drawing.Point(559, 440);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(99, 34);
            this.btnAdd.TabIndex = 47;
            this.btnAdd.Text = "  Guardar";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GPRS.Properties.Resources.wifi;
            this.pictureBox1.Location = new System.Drawing.Point(688, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::GPRS.Properties.Resources.servidores__1_;
            this.pictureBox3.Location = new System.Drawing.Point(159, 56);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(70, 76);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // switchBtnTcpServerModem
            // 
            this.switchBtnTcpServerModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnTcpServerModem.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnTcpServerModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnTcpServerModem.ForeColor = System.Drawing.Color.White;
            this.switchBtnTcpServerModem.IsOn = false;
            this.switchBtnTcpServerModem.Location = new System.Drawing.Point(527, 147);
            this.switchBtnTcpServerModem.Name = "switchBtnTcpServerModem";
            this.switchBtnTcpServerModem.OffColor = System.Drawing.Color.Gray;
            this.switchBtnTcpServerModem.OffText = "OFF";
            this.switchBtnTcpServerModem.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnTcpServerModem.OnText = "ON";
            this.switchBtnTcpServerModem.Size = new System.Drawing.Size(42, 23);
            this.switchBtnTcpServerModem.TabIndex = 59;
            this.switchBtnTcpServerModem.Text = "ceLearningToggle8";
            this.switchBtnTcpServerModem.TextEnabled = true;
            this.switchBtnTcpServerModem.Click += new System.EventHandler(this.switchBtnTcpServerModem_Click);
            // 
            // switchBtnTcpClientModem
            // 
            this.switchBtnTcpClientModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnTcpClientModem.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnTcpClientModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnTcpClientModem.ForeColor = System.Drawing.Color.White;
            this.switchBtnTcpClientModem.IsOn = false;
            this.switchBtnTcpClientModem.Location = new System.Drawing.Point(527, 108);
            this.switchBtnTcpClientModem.Name = "switchBtnTcpClientModem";
            this.switchBtnTcpClientModem.OffColor = System.Drawing.Color.Gray;
            this.switchBtnTcpClientModem.OffText = "OFF";
            this.switchBtnTcpClientModem.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnTcpClientModem.OnText = "ON";
            this.switchBtnTcpClientModem.Size = new System.Drawing.Size(42, 23);
            this.switchBtnTcpClientModem.TabIndex = 58;
            this.switchBtnTcpClientModem.Text = "ceLearningToggle7";
            this.switchBtnTcpClientModem.TextEnabled = true;
            this.switchBtnTcpClientModem.Click += new System.EventHandler(this.switchBtnTcpClientModem_Click);
            // 
            // switchBtnUdpServerModem
            // 
            this.switchBtnUdpServerModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnUdpServerModem.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnUdpServerModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnUdpServerModem.ForeColor = System.Drawing.Color.White;
            this.switchBtnUdpServerModem.IsOn = false;
            this.switchBtnUdpServerModem.Location = new System.Drawing.Point(527, 68);
            this.switchBtnUdpServerModem.Name = "switchBtnUdpServerModem";
            this.switchBtnUdpServerModem.OffColor = System.Drawing.Color.Gray;
            this.switchBtnUdpServerModem.OffText = "OFF";
            this.switchBtnUdpServerModem.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnUdpServerModem.OnText = "ON";
            this.switchBtnUdpServerModem.Size = new System.Drawing.Size(42, 23);
            this.switchBtnUdpServerModem.TabIndex = 57;
            this.switchBtnUdpServerModem.Text = "ceLearningToggle6";
            this.switchBtnUdpServerModem.TextEnabled = true;
            this.switchBtnUdpServerModem.Click += new System.EventHandler(this.switchBtnUdpServerModem_Click);
            // 
            // switchBtnUdpClientModem
            // 
            this.switchBtnUdpClientModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnUdpClientModem.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnUdpClientModem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnUdpClientModem.ForeColor = System.Drawing.Color.White;
            this.switchBtnUdpClientModem.IsOn = false;
            this.switchBtnUdpClientModem.Location = new System.Drawing.Point(527, 27);
            this.switchBtnUdpClientModem.Name = "switchBtnUdpClientModem";
            this.switchBtnUdpClientModem.OffColor = System.Drawing.Color.Gray;
            this.switchBtnUdpClientModem.OffText = "OFF";
            this.switchBtnUdpClientModem.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnUdpClientModem.OnText = "ON";
            this.switchBtnUdpClientModem.Size = new System.Drawing.Size(42, 23);
            this.switchBtnUdpClientModem.TabIndex = 56;
            this.switchBtnUdpClientModem.Text = "switchBtnUdpClientModem";
            this.switchBtnUdpClientModem.TextEnabled = true;
            this.switchBtnUdpClientModem.Click += new System.EventHandler(this.switchBtnUdpClientModem_Click);
            // 
            // switchBtnTcpServerSock
            // 
            this.switchBtnTcpServerSock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnTcpServerSock.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnTcpServerSock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnTcpServerSock.ForeColor = System.Drawing.Color.White;
            this.switchBtnTcpServerSock.IsOn = false;
            this.switchBtnTcpServerSock.Location = new System.Drawing.Point(360, 147);
            this.switchBtnTcpServerSock.Name = "switchBtnTcpServerSock";
            this.switchBtnTcpServerSock.OffColor = System.Drawing.Color.Gray;
            this.switchBtnTcpServerSock.OffText = "OFF";
            this.switchBtnTcpServerSock.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnTcpServerSock.OnText = "ON";
            this.switchBtnTcpServerSock.Size = new System.Drawing.Size(42, 23);
            this.switchBtnTcpServerSock.TabIndex = 55;
            this.switchBtnTcpServerSock.Text = "ceLearningToggle4";
            this.switchBtnTcpServerSock.TextEnabled = true;
            this.switchBtnTcpServerSock.Click += new System.EventHandler(this.switchBtnTcpServerSock_Click);
            // 
            // switchBtnTcpClientSock
            // 
            this.switchBtnTcpClientSock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnTcpClientSock.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnTcpClientSock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnTcpClientSock.ForeColor = System.Drawing.Color.White;
            this.switchBtnTcpClientSock.IsOn = false;
            this.switchBtnTcpClientSock.Location = new System.Drawing.Point(360, 108);
            this.switchBtnTcpClientSock.Name = "switchBtnTcpClientSock";
            this.switchBtnTcpClientSock.OffColor = System.Drawing.Color.Gray;
            this.switchBtnTcpClientSock.OffText = "OFF";
            this.switchBtnTcpClientSock.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnTcpClientSock.OnText = "ON";
            this.switchBtnTcpClientSock.Size = new System.Drawing.Size(42, 23);
            this.switchBtnTcpClientSock.TabIndex = 54;
            this.switchBtnTcpClientSock.Text = "ceLearningToggle3";
            this.switchBtnTcpClientSock.TextEnabled = true;
            this.switchBtnTcpClientSock.Click += new System.EventHandler(this.switchBtnTcpClientSock_Click);
            // 
            // switchBtnUdpClientSock
            // 
            this.switchBtnUdpClientSock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnUdpClientSock.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnUdpClientSock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnUdpClientSock.ForeColor = System.Drawing.Color.White;
            this.switchBtnUdpClientSock.IsOn = false;
            this.switchBtnUdpClientSock.Location = new System.Drawing.Point(360, 26);
            this.switchBtnUdpClientSock.Name = "switchBtnUdpClientSock";
            this.switchBtnUdpClientSock.OffColor = System.Drawing.Color.Gray;
            this.switchBtnUdpClientSock.OffText = "OFF";
            this.switchBtnUdpClientSock.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnUdpClientSock.OnText = "ON";
            this.switchBtnUdpClientSock.Size = new System.Drawing.Size(42, 23);
            this.switchBtnUdpClientSock.TabIndex = 53;
            this.switchBtnUdpClientSock.Text = "ceLearningToggle2";
            this.switchBtnUdpClientSock.TextEnabled = true;
            this.switchBtnUdpClientSock.Click += new System.EventHandler(this.switchBtnUdpClientSock_Click);
            // 
            // switchBtnUdpServerSock
            // 
            this.switchBtnUdpServerSock.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.switchBtnUdpServerSock.BorderColor = System.Drawing.Color.Gray;
            this.switchBtnUdpServerSock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.switchBtnUdpServerSock.ForeColor = System.Drawing.Color.White;
            this.switchBtnUdpServerSock.IsOn = false;
            this.switchBtnUdpServerSock.Location = new System.Drawing.Point(360, 68);
            this.switchBtnUdpServerSock.Name = "switchBtnUdpServerSock";
            this.switchBtnUdpServerSock.OffColor = System.Drawing.Color.Gray;
            this.switchBtnUdpServerSock.OffText = "OFF";
            this.switchBtnUdpServerSock.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.switchBtnUdpServerSock.OnText = "ON";
            this.switchBtnUdpServerSock.Size = new System.Drawing.Size(42, 23);
            this.switchBtnUdpServerSock.TabIndex = 52;
            this.switchBtnUdpServerSock.Text = "ceLearningToggle1";
            this.switchBtnUdpServerSock.TextEnabled = true;
            this.switchBtnUdpServerSock.Click += new System.EventHandler(this.switchBtnUdpServerSock_Click);
            // 
            // FormServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(896, 495);
            this.Controls.Add(this.pictureInformation);
            this.Controls.Add(this.switchBtnTcpServerModem);
            this.Controls.Add(this.switchBtnTcpClientModem);
            this.Controls.Add(this.switchBtnUdpServerModem);
            this.Controls.Add(this.switchBtnUdpClientModem);
            this.Controls.Add(this.switchBtnTcpServerSock);
            this.Controls.Add(this.switchBtnTcpClientSock);
            this.Controls.Add(this.switchBtnUdpClientSock);
            this.Controls.Add(this.switchBtnUdpServerSock);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txtMaxWindows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitleModem);
            this.Controls.Add(this.lblTitleServer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblTcpServerModem);
            this.Controls.Add(this.lblTcpClientModem);
            this.Controls.Add(this.lblUdpServerModem);
            this.Controls.Add(this.lblUdpClientModem);
            this.Controls.Add(this.lblTcpServerServer);
            this.Controls.Add(this.lblTcpClientServer);
            this.Controls.Add(this.lblUdpServerServer);
            this.Controls.Add(this.lblUdpClientServer);
            this.Controls.Add(this.txtMensajes);
            this.Controls.Add(this.label2);
            this.Name = "FormServidor";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.FormServidor_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormServidor_Paint);
            this.Resize += new System.EventHandler(this.FormServidor_Resize);
            this.Menú.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtMensajes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUdpClientServer;
        private System.Windows.Forms.Label lblUdpServerServer;
        private System.Windows.Forms.Label lblTcpServerServer;
        private System.Windows.Forms.Label lblTcpServerModem;
        private System.Windows.Forms.Label lblUdpServerModem;
        private System.Windows.Forms.Label lblUdpClientModem;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblTitleServer;
        public System.Windows.Forms.Label lblTitleModem;
        public System.Windows.Forms.Label lblTcpClientServer;
        public System.Windows.Forms.Label lblTcpClientModem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtMaxWindows;
        private CeLearningToggle switchBtnUdpServerSock;
        private CeLearningToggle switchBtnUdpClientSock;
        private CeLearningToggle switchBtnTcpClientSock;
        private CeLearningToggle switchBtnTcpServerSock;
        private CeLearningToggle switchBtnUdpClientModem;
        private CeLearningToggle switchBtnUdpServerModem;
        private CeLearningToggle switchBtnTcpClientModem;
        private CeLearningToggle switchBtnTcpServerModem;
        private System.Windows.Forms.PictureBox pictureInformation;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip Menú;
        private FontAwesome.Sharp.IconMenuItem copyItem;
        private FontAwesome.Sharp.IconMenuItem cleanItem;
        private FontAwesome.Sharp.IconButton btnAdd;
    }
}