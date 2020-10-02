namespace GPRS.Forms
{
    partial class FormCliente
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
            this.btnCambiar = new System.Windows.Forms.Button();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtPuerto = new System.Windows.Forms.TextBox();
            this.txtMensajes = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnCambiar
            // 
            this.btnCambiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCambiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.btnCambiar.FlatAppearance.BorderSize = 0;
            this.btnCambiar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnCambiar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiar.ForeColor = System.Drawing.Color.Coral;
            this.btnCambiar.Location = new System.Drawing.Point(628, 31);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new System.Drawing.Size(85, 30);
            this.btnCambiar.TabIndex = 18;
            this.btnCambiar.Text = "CAMBIAR";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new System.EventHandler(this.btnCambiar_Click);
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.Color.Turquoise;
            this.btnEnviar.Location = new System.Drawing.Point(191, 131);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 30);
            this.btnEnviar.TabIndex = 17;
            this.btnEnviar.Text = "ENVIAR";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMensaje.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensaje.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.DarkGray;
            this.txtMensaje.Location = new System.Drawing.Point(191, 85);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(522, 16);
            this.txtMensaje.TabIndex = 16;
            this.txtMensaje.Text = "Escribe un mensaje";
            this.txtMensaje.Enter += new System.EventHandler(this.txtMensaje_Enter);
            this.txtMensaje.Leave += new System.EventHandler(this.txtMensaje_Leave);
            // 
            // txtIP
            // 
            this.txtIP.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.txtIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIP.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.ForeColor = System.Drawing.Color.DarkGray;
            this.txtIP.Location = new System.Drawing.Point(191, 33);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(115, 19);
            this.txtIP.TabIndex = 15;
            this.txtIP.Text = "Direccion IP";
            this.txtIP.Enter += new System.EventHandler(this.txtIP_Enter);
            this.txtIP.Leave += new System.EventHandler(this.txtIP_Leave);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnIniciar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.btnIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ForeColor = System.Drawing.Color.LightGreen;
            this.btnIniciar.Location = new System.Drawing.Point(474, 31);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 30);
            this.btnIniciar.TabIndex = 13;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = false;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtPuerto
            // 
            this.txtPuerto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPuerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.txtPuerto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPuerto.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPuerto.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPuerto.Location = new System.Drawing.Point(342, 33);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(76, 19);
            this.txtPuerto.TabIndex = 12;
            this.txtPuerto.Text = "Puerto";
            this.txtPuerto.Enter += new System.EventHandler(this.txtPuerto_Enter);
            this.txtPuerto.Leave += new System.EventHandler(this.txtPuerto_Leave);
            // 
            // txtMensajes
            // 
            this.txtMensajes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(110)))), ((int)(((byte)(110)))));
            this.txtMensajes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensajes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtMensajes.Location = new System.Drawing.Point(1, 256);
            this.txtMensajes.Name = "txtMensajes";
            this.txtMensajes.ReadOnly = true;
            this.txtMensajes.Size = new System.Drawing.Size(894, 186);
            this.txtMensajes.TabIndex = 20;
            this.txtMensajes.Text = "";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(426, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "MENSAJES";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Location = new System.Drawing.Point(191, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(113, 1);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(342, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 1);
            this.panel2.TabIndex = 22;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(191, 104);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(522, 1);
            this.panel3.TabIndex = 23;
            // 
            // FormCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.ClientSize = new System.Drawing.Size(896, 495);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMensajes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCambiar);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.txtPuerto);
            this.Name = "FormCliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.FormCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambiar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtPuerto;
        private System.Windows.Forms.RichTextBox txtMensajes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}