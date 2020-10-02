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
            this.txtMensajes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnTcpServerModem = new FontAwesome.Sharp.IconButton();
            this.btnTcpServerServer = new FontAwesome.Sharp.IconButton();
            this.btnTcpClientModem = new FontAwesome.Sharp.IconButton();
            this.btnUdpServerModem = new FontAwesome.Sharp.IconButton();
            this.btnUdpClientModem = new FontAwesome.Sharp.IconButton();
            this.btnTcpClientServer = new FontAwesome.Sharp.IconButton();
            this.btnUdpServerServer = new FontAwesome.Sharp.IconButton();
            this.btnUdpClientServer = new FontAwesome.Sharp.IconButton();
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
            this.txtMensajes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMensajes.HideSelection = false;
            this.txtMensajes.Location = new System.Drawing.Point(1, 193);
            this.txtMensajes.Name = "txtMensajes";
            this.txtMensajes.ReadOnly = true;
            this.txtMensajes.Size = new System.Drawing.Size(892, 186);
            this.txtMensajes.TabIndex = 10;
            this.txtMensajes.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(425, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "MENSAJES";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(247, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Udp Cliente";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(247, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "Udp Servidor";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(247, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tcp Cliente";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(247, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 19);
            this.label5.TabIndex = 25;
            this.label5.Text = "Tcp Servidor";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(578, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 19);
            this.label6.TabIndex = 29;
            this.label6.Text = "Tcp Servidor";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(578, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tcp Cliente";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(578, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 19);
            this.label8.TabIndex = 27;
            this.label8.Text = "Udp Servidor";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(578, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 19);
            this.label9.TabIndex = 26;
            this.label9.Text = "Udp Cliente";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(255)))), ((int)(((byte)(113)))));
            this.label10.Location = new System.Drawing.Point(156, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 18);
            this.label10.TabIndex = 32;
            this.label10.Text = "Servidores";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.label11.Location = new System.Drawing.Point(688, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 18);
            this.label11.TabIndex = 33;
            this.label11.Text = "Módems";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GPRS.Properties.Resources.wifi;
            this.pictureBox1.Location = new System.Drawing.Point(691, 63);
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
            this.pictureBox3.Location = new System.Drawing.Point(162, 56);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(70, 76);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 30;
            this.pictureBox3.TabStop = false;
            // 
            // btnTcpServerModem
            // 
            this.btnTcpServerModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTcpServerModem.BackColor = System.Drawing.Color.Red;
            this.btnTcpServerModem.FlatAppearance.BorderSize = 0;
            this.btnTcpServerModem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnTcpServerModem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnTcpServerModem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTcpServerModem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTcpServerModem.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTcpServerModem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTcpServerModem.IconColor = System.Drawing.Color.Black;
            this.btnTcpServerModem.IconSize = 16;
            this.btnTcpServerModem.Location = new System.Drawing.Point(535, 145);
            this.btnTcpServerModem.Name = "btnTcpServerModem";
            this.btnTcpServerModem.Rotation = 0D;
            this.btnTcpServerModem.Size = new System.Drawing.Size(37, 23);
            this.btnTcpServerModem.TabIndex = 21;
            this.btnTcpServerModem.Text = "OFF";
            this.btnTcpServerModem.UseVisualStyleBackColor = false;
            this.btnTcpServerModem.Click += new System.EventHandler(this.btnTcpServerModem_Click);
            // 
            // btnTcpServerServer
            // 
            this.btnTcpServerServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTcpServerServer.BackColor = System.Drawing.Color.Red;
            this.btnTcpServerServer.FlatAppearance.BorderSize = 0;
            this.btnTcpServerServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnTcpServerServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnTcpServerServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTcpServerServer.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTcpServerServer.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTcpServerServer.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTcpServerServer.IconColor = System.Drawing.Color.Black;
            this.btnTcpServerServer.IconSize = 16;
            this.btnTcpServerServer.Location = new System.Drawing.Point(363, 144);
            this.btnTcpServerServer.Name = "btnTcpServerServer";
            this.btnTcpServerServer.Rotation = 0D;
            this.btnTcpServerServer.Size = new System.Drawing.Size(37, 23);
            this.btnTcpServerServer.TabIndex = 20;
            this.btnTcpServerServer.Text = "OFF";
            this.btnTcpServerServer.UseVisualStyleBackColor = false;
            this.btnTcpServerServer.Click += new System.EventHandler(this.btnTcpServerServer_Click);
            // 
            // btnTcpClientModem
            // 
            this.btnTcpClientModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTcpClientModem.BackColor = System.Drawing.Color.Red;
            this.btnTcpClientModem.FlatAppearance.BorderSize = 0;
            this.btnTcpClientModem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnTcpClientModem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnTcpClientModem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTcpClientModem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTcpClientModem.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTcpClientModem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTcpClientModem.IconColor = System.Drawing.Color.Black;
            this.btnTcpClientModem.IconSize = 16;
            this.btnTcpClientModem.Location = new System.Drawing.Point(535, 113);
            this.btnTcpClientModem.Name = "btnTcpClientModem";
            this.btnTcpClientModem.Rotation = 0D;
            this.btnTcpClientModem.Size = new System.Drawing.Size(37, 23);
            this.btnTcpClientModem.TabIndex = 19;
            this.btnTcpClientModem.Text = "OFF";
            this.btnTcpClientModem.UseVisualStyleBackColor = false;
            this.btnTcpClientModem.Click += new System.EventHandler(this.btnTcpClientModem_Click);
            // 
            // btnUdpServerModem
            // 
            this.btnUdpServerModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUdpServerModem.BackColor = System.Drawing.Color.Red;
            this.btnUdpServerModem.FlatAppearance.BorderSize = 0;
            this.btnUdpServerModem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnUdpServerModem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnUdpServerModem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUdpServerModem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUdpServerModem.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUdpServerModem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUdpServerModem.IconColor = System.Drawing.Color.Black;
            this.btnUdpServerModem.IconSize = 16;
            this.btnUdpServerModem.Location = new System.Drawing.Point(535, 63);
            this.btnUdpServerModem.Name = "btnUdpServerModem";
            this.btnUdpServerModem.Rotation = 0D;
            this.btnUdpServerModem.Size = new System.Drawing.Size(37, 23);
            this.btnUdpServerModem.TabIndex = 18;
            this.btnUdpServerModem.Text = "OFF";
            this.btnUdpServerModem.UseVisualStyleBackColor = false;
            this.btnUdpServerModem.Click += new System.EventHandler(this.btnUdpServerModem_Click);
            // 
            // btnUdpClientModem
            // 
            this.btnUdpClientModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUdpClientModem.BackColor = System.Drawing.Color.Red;
            this.btnUdpClientModem.FlatAppearance.BorderSize = 0;
            this.btnUdpClientModem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnUdpClientModem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnUdpClientModem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUdpClientModem.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUdpClientModem.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUdpClientModem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUdpClientModem.IconColor = System.Drawing.Color.Black;
            this.btnUdpClientModem.IconSize = 16;
            this.btnUdpClientModem.Location = new System.Drawing.Point(535, 27);
            this.btnUdpClientModem.Name = "btnUdpClientModem";
            this.btnUdpClientModem.Rotation = 0D;
            this.btnUdpClientModem.Size = new System.Drawing.Size(37, 23);
            this.btnUdpClientModem.TabIndex = 17;
            this.btnUdpClientModem.Text = "OFF";
            this.btnUdpClientModem.UseVisualStyleBackColor = false;
            this.btnUdpClientModem.Click += new System.EventHandler(this.btnUdpClientModem_Click);
            // 
            // btnTcpClientServer
            // 
            this.btnTcpClientServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTcpClientServer.BackColor = System.Drawing.Color.Red;
            this.btnTcpClientServer.FlatAppearance.BorderSize = 0;
            this.btnTcpClientServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnTcpClientServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnTcpClientServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTcpClientServer.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTcpClientServer.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTcpClientServer.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnTcpClientServer.IconColor = System.Drawing.Color.Black;
            this.btnTcpClientServer.IconSize = 16;
            this.btnTcpClientServer.Location = new System.Drawing.Point(363, 113);
            this.btnTcpClientServer.Name = "btnTcpClientServer";
            this.btnTcpClientServer.Rotation = 0D;
            this.btnTcpClientServer.Size = new System.Drawing.Size(37, 23);
            this.btnTcpClientServer.TabIndex = 16;
            this.btnTcpClientServer.Text = "OFF";
            this.btnTcpClientServer.UseVisualStyleBackColor = false;
            this.btnTcpClientServer.Click += new System.EventHandler(this.btnTcpClientServer_Click);
            // 
            // btnUdpServerServer
            // 
            this.btnUdpServerServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUdpServerServer.BackColor = System.Drawing.Color.Red;
            this.btnUdpServerServer.FlatAppearance.BorderSize = 0;
            this.btnUdpServerServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnUdpServerServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnUdpServerServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUdpServerServer.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUdpServerServer.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUdpServerServer.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUdpServerServer.IconColor = System.Drawing.Color.Black;
            this.btnUdpServerServer.IconSize = 16;
            this.btnUdpServerServer.Location = new System.Drawing.Point(363, 63);
            this.btnUdpServerServer.Name = "btnUdpServerServer";
            this.btnUdpServerServer.Rotation = 0D;
            this.btnUdpServerServer.Size = new System.Drawing.Size(37, 23);
            this.btnUdpServerServer.TabIndex = 15;
            this.btnUdpServerServer.Text = "OFF";
            this.btnUdpServerServer.UseVisualStyleBackColor = false;
            this.btnUdpServerServer.Click += new System.EventHandler(this.btnUdpServerServer_Click);
            // 
            // btnUdpClientServer
            // 
            this.btnUdpClientServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUdpClientServer.BackColor = System.Drawing.Color.Red;
            this.btnUdpClientServer.FlatAppearance.BorderSize = 0;
            this.btnUdpClientServer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnUdpClientServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnUdpClientServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUdpClientServer.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUdpClientServer.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUdpClientServer.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUdpClientServer.IconColor = System.Drawing.Color.Black;
            this.btnUdpClientServer.IconSize = 16;
            this.btnUdpClientServer.Location = new System.Drawing.Point(363, 30);
            this.btnUdpClientServer.Name = "btnUdpClientServer";
            this.btnUdpClientServer.Rotation = 0D;
            this.btnUdpClientServer.Size = new System.Drawing.Size(37, 23);
            this.btnUdpClientServer.TabIndex = 14;
            this.btnUdpClientServer.Text = "OFF";
            this.btnUdpClientServer.UseVisualStyleBackColor = false;
            this.btnUdpClientServer.Click += new System.EventHandler(this.btnUdpClientServer_Click);
            // 
            // FormServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(896, 495);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTcpServerModem);
            this.Controls.Add(this.btnTcpServerServer);
            this.Controls.Add(this.btnTcpClientModem);
            this.Controls.Add(this.btnUdpServerModem);
            this.Controls.Add(this.btnUdpClientModem);
            this.Controls.Add(this.btnTcpClientServer);
            this.Controls.Add(this.btnUdpServerServer);
            this.Controls.Add(this.btnUdpClientServer);
            this.Controls.Add(this.txtMensajes);
            this.Controls.Add(this.label2);
            this.Name = "FormServidor";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.FormServidor_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormServidor_Paint);
            this.Resize += new System.EventHandler(this.FormServidor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtMensajes;
        private System.Windows.Forms.Label label2;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.ComponentModel.BackgroundWorker backgroundWorker2;
        private FontAwesome.Sharp.IconButton btnUdpClientServer;
        private FontAwesome.Sharp.IconButton btnUdpServerServer;
        private FontAwesome.Sharp.IconButton btnUdpServerModem;
        private FontAwesome.Sharp.IconButton btnUdpClientModem;
        private FontAwesome.Sharp.IconButton btnTcpServerServer;
        private FontAwesome.Sharp.IconButton btnTcpServerModem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public FontAwesome.Sharp.IconButton btnTcpClientServer;
        public FontAwesome.Sharp.IconButton btnTcpClientModem;
    }
}