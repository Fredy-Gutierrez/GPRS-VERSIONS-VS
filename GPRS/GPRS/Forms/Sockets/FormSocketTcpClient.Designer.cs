namespace GPRS.Forms.Sockets
{
    partial class FormSocketTcpClient
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSockets = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnCerrar = new FontAwesome.Sharp.IconPictureBox();
            this.btnMinimizar = new FontAwesome.Sharp.IconPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSwitchOnOff = new GPRS.CeLearningToggle();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelSockets.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.flowLayoutPanel1.Controls.Add(this.panelSockets);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(201, 446);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panelSockets
            // 
            this.panelSockets.Controls.Add(this.label1);
            this.panelSockets.Location = new System.Drawing.Point(3, 3);
            this.panelSockets.Name = "panelSockets";
            this.panelSockets.Size = new System.Drawing.Size(178, 490);
            this.panelSockets.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(56, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sockets";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panelTitleBar.Controls.Add(this.btnCerrar);
            this.panelTitleBar.Controls.Add(this.btnMinimizar);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(201, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(615, 58);
            this.panelTitleBar.TabIndex = 4;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnCerrar.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnCerrar.IconColor = System.Drawing.Color.Firebrick;
            this.btnCerrar.IconSize = 25;
            this.btnCerrar.Location = new System.Drawing.Point(580, 9);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(25, 25);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnMinimizar.ForeColor = System.Drawing.Color.Gray;
            this.btnMinimizar.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimizar.IconColor = System.Drawing.Color.Gray;
            this.btnMinimizar.IconSize = 23;
            this.btnMinimizar.Location = new System.Drawing.Point(543, 9);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(31, 23);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.btnSwitchOnOff);
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Controls.Add(this.txtMsg);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtIp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(201, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 388);
            this.panel1.TabIndex = 5;
            // 
            // btnSwitchOnOff
            // 
            this.btnSwitchOnOff.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSwitchOnOff.BorderColor = System.Drawing.Color.Gray;
            this.btnSwitchOnOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSwitchOnOff.ForeColor = System.Drawing.Color.White;
            this.btnSwitchOnOff.IsOn = false;
            this.btnSwitchOnOff.Location = new System.Drawing.Point(468, 95);
            this.btnSwitchOnOff.Name = "btnSwitchOnOff";
            this.btnSwitchOnOff.OffColor = System.Drawing.Color.Gray;
            this.btnSwitchOnOff.OffText = "OFF";
            this.btnSwitchOnOff.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(255)))));
            this.btnSwitchOnOff.OnText = "ON";
            this.btnSwitchOnOff.Size = new System.Drawing.Size(52, 28);
            this.btnSwitchOnOff.TabIndex = 50;
            this.btnSwitchOnOff.Text = "ceLearningToggle1";
            this.btnSwitchOnOff.TextEnabled = true;
            this.btnSwitchOnOff.Click += new System.EventHandler(this.btnSwitchOnOff_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(371, 44);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 19);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Estado";
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMsg.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsg.Location = new System.Drawing.Point(3, 247);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(609, 129);
            this.txtMsg.TabIndex = 18;
            this.txtMsg.Text = "";
            this.txtMsg.VScroll += new System.EventHandler(this.txtMsg_VScroll);
            this.txtMsg.MouseLeave += new System.EventHandler(this.txtMsg_MouseLeave);
            this.txtMsg.MouseHover += new System.EventHandler(this.txtMsg_MouseHover);
            // 
            // txtPort
            // 
            this.txtPort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtPort.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(259, 138);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(88, 26);
            this.txtPort.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(133, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Puerto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIp
            // 
            this.txtIp.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Location = new System.Drawing.Point(259, 97);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(181, 26);
            this.txtIp.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Dirección IP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.lblName.Location = new System.Drawing.Point(242, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(85, 23);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Nombre";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::GPRS.Properties.Resources.torre_pc;
            this.pictureBox1.Location = new System.Drawing.Point(134, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FormSocketTcpClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 446);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.flowLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(990, 534);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "FormSocketTcpClient";
            this.Text = "FormSocketTcpClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSocketTcpClient_FormClosing);
            this.Load += new System.EventHandler(this.FormSocketTcpClient_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelSockets.ResumeLayout(false);
            this.panelSockets.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelSockets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox btnCerrar;
        private FontAwesome.Sharp.IconPictureBox btnMinimizar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CeLearningToggle btnSwitchOnOff;
    }
}