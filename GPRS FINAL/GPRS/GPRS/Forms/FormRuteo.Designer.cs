namespace GPRS.Forms
{
    partial class FormRuteo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRuteo));
            this.tablaRuteo = new System.Windows.Forms.DataGridView();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModemType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdServer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdModem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbConeccionS = new System.Windows.Forms.ComboBox();
            this.cbTypeS = new System.Windows.Forms.ComboBox();
            this.cbNameS = new System.Windows.Forms.ComboBox();
            this.cbNameM = new System.Windows.Forms.ComboBox();
            this.cbTypeM = new System.Windows.Forms.ComboBox();
            this.cbConeccionM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdModem = new System.Windows.Forms.TextBox();
            this.txtIdServer = new System.Windows.Forms.TextBox();
            this.lblIdServer = new System.Windows.Forms.Label();
            this.lblIdModem = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnDelete = new FontAwesome.Sharp.IconButton();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaRuteo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaRuteo
            // 
            this.tablaRuteo.AllowUserToAddRows = false;
            this.tablaRuteo.AllowUserToDeleteRows = false;
            this.tablaRuteo.AllowUserToOrderColumns = true;
            this.tablaRuteo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaRuteo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.tablaRuteo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tablaRuteo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.tablaRuteo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(83)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaRuteo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tablaRuteo.ColumnHeadersHeight = 66;
            this.tablaRuteo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ServerName,
            this.ServerType,
            this.ModemName,
            this.ModemType,
            this.IdServer,
            this.IdModem});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(180)))), ((int)(((byte)(216)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tablaRuteo.DefaultCellStyle = dataGridViewCellStyle6;
            this.tablaRuteo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tablaRuteo.EnableHeadersVisualStyles = false;
            this.tablaRuteo.Location = new System.Drawing.Point(88, 239);
            this.tablaRuteo.Name = "tablaRuteo";
            this.tablaRuteo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(117)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tablaRuteo.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablaRuteo.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.tablaRuteo.Size = new System.Drawing.Size(664, 227);
            this.tablaRuteo.TabIndex = 1;
            // 
            // ServerName
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ServerName.HeaderText = "Nombre del Remitente";
            this.ServerName.Name = "ServerName";
            this.ServerName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ServerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ServerType
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerType.DefaultCellStyle = dataGridViewCellStyle3;
            this.ServerType.HeaderText = "Conexión del Remitente";
            this.ServerType.Name = "ServerType";
            // 
            // ModemName
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModemName.DefaultCellStyle = dataGridViewCellStyle4;
            this.ModemName.HeaderText = "Nombre del Destino";
            this.ModemName.Name = "ModemName";
            // 
            // ModemType
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModemType.DefaultCellStyle = dataGridViewCellStyle5;
            this.ModemType.HeaderText = "Tipo de Conexión del Destino";
            this.ModemType.Name = "ModemType";
            this.ModemType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ModemType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IdServer
            // 
            this.IdServer.HeaderText = "Id Servidor";
            this.IdServer.Name = "IdServer";
            this.IdServer.Visible = false;
            // 
            // IdModem
            // 
            this.IdModem.HeaderText = "Id Modem";
            this.IdModem.Name = "IdModem";
            this.IdModem.Visible = false;
            // 
            // cbConeccionS
            // 
            this.cbConeccionS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbConeccionS.BackColor = System.Drawing.Color.White;
            this.cbConeccionS.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbConeccionS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConeccionS.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConeccionS.FormattingEnabled = true;
            this.cbConeccionS.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.cbConeccionS.Location = new System.Drawing.Point(257, 49);
            this.cbConeccionS.Name = "cbConeccionS";
            this.cbConeccionS.Size = new System.Drawing.Size(119, 24);
            this.cbConeccionS.TabIndex = 2;
            this.cbConeccionS.SelectedIndexChanged += new System.EventHandler(this.cbConeccionS_SelectedIndexChanged);
            // 
            // cbTypeS
            // 
            this.cbTypeS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTypeS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeS.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTypeS.FormattingEnabled = true;
            this.cbTypeS.Items.AddRange(new object[] {
            "CLIENTE",
            "SERVIDOR"});
            this.cbTypeS.Location = new System.Drawing.Point(406, 48);
            this.cbTypeS.Name = "cbTypeS";
            this.cbTypeS.Size = new System.Drawing.Size(86, 24);
            this.cbTypeS.TabIndex = 3;
            this.cbTypeS.SelectedIndexChanged += new System.EventHandler(this.cbTypeS_SelectedIndexChanged);
            // 
            // cbNameS
            // 
            this.cbNameS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbNameS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNameS.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNameS.FormattingEnabled = true;
            this.cbNameS.Location = new System.Drawing.Point(521, 48);
            this.cbNameS.Name = "cbNameS";
            this.cbNameS.Size = new System.Drawing.Size(86, 24);
            this.cbNameS.TabIndex = 4;
            // 
            // cbNameM
            // 
            this.cbNameM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbNameM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNameM.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNameM.FormattingEnabled = true;
            this.cbNameM.Location = new System.Drawing.Point(521, 140);
            this.cbNameM.Name = "cbNameM";
            this.cbNameM.Size = new System.Drawing.Size(86, 24);
            this.cbNameM.TabIndex = 7;
            // 
            // cbTypeM
            // 
            this.cbTypeM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbTypeM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeM.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTypeM.FormattingEnabled = true;
            this.cbTypeM.Items.AddRange(new object[] {
            "CLIENTE",
            "SERVIDOR"});
            this.cbTypeM.Location = new System.Drawing.Point(406, 140);
            this.cbTypeM.Name = "cbTypeM";
            this.cbTypeM.Size = new System.Drawing.Size(86, 24);
            this.cbTypeM.TabIndex = 6;
            this.cbTypeM.SelectedIndexChanged += new System.EventHandler(this.cbTypeM_SelectedIndexChanged);
            // 
            // cbConeccionM
            // 
            this.cbConeccionM.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbConeccionM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConeccionM.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConeccionM.FormattingEnabled = true;
            this.cbConeccionM.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.cbConeccionM.Location = new System.Drawing.Point(257, 140);
            this.cbConeccionM.Name = "cbConeccionM";
            this.cbConeccionM.Size = new System.Drawing.Size(119, 24);
            this.cbConeccionM.TabIndex = 5;
            this.cbConeccionM.SelectedIndexChanged += new System.EventHandler(this.cbConeccionM_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(246, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Conexión del Módem";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(246, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Conexión del servidor";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(432, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(432, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(535, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(535, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nombre";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(255)))), ((int)(((byte)(152)))));
            this.label7.Location = new System.Drawing.Point(369, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 18);
            this.label7.TabIndex = 20;
            this.label7.Text = "Conectar a Módem:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(165)))), ((int)(((byte)(113)))));
            this.label8.Location = new System.Drawing.Point(318, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "De la conexión del servidor:";
            // 
            // txtIdModem
            // 
            this.txtIdModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIdModem.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdModem.Location = new System.Drawing.Point(628, 140);
            this.txtIdModem.Name = "txtIdModem";
            this.txtIdModem.Size = new System.Drawing.Size(100, 26);
            this.txtIdModem.TabIndex = 22;
            this.txtIdModem.Visible = false;
            // 
            // txtIdServer
            // 
            this.txtIdServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtIdServer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdServer.Location = new System.Drawing.Point(631, 48);
            this.txtIdServer.Name = "txtIdServer";
            this.txtIdServer.Size = new System.Drawing.Size(100, 26);
            this.txtIdServer.TabIndex = 23;
            this.txtIdServer.Visible = false;
            // 
            // lblIdServer
            // 
            this.lblIdServer.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIdServer.AutoSize = true;
            this.lblIdServer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdServer.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblIdServer.Location = new System.Drawing.Point(636, 28);
            this.lblIdServer.Name = "lblIdServer";
            this.lblIdServer.Size = new System.Drawing.Size(92, 16);
            this.lblIdServer.TabIndex = 24;
            this.lblIdServer.Text = "Identificador";
            this.lblIdServer.Visible = false;
            // 
            // lblIdModem
            // 
            this.lblIdModem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblIdModem.AutoSize = true;
            this.lblIdModem.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdModem.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblIdModem.Location = new System.Drawing.Point(629, 121);
            this.lblIdModem.Name = "lblIdModem";
            this.lblIdModem.Size = new System.Drawing.Size(99, 16);
            this.lblIdModem.TabIndex = 25;
            this.lblIdModem.Text = "Id del Módem";
            this.lblIdModem.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(164, 73);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(76, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnDelete.IconColor = System.Drawing.Color.Black;
            this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnDelete.IconSize = 20;
            this.btnDelete.Location = new System.Drawing.Point(758, 239);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 35);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Borrar";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(134)))), ((int)(((byte)(225)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAdd.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(19)))));
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 22;
            this.btnAdd.Location = new System.Drawing.Point(398, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(103, 38);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::GPRS.Properties.Resources.enrutador;
            this.pictureBox2.Location = new System.Drawing.Point(164, 110);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 55);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(164, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // FormRuteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(873, 491);
            this.Controls.Add(this.lblIdModem);
            this.Controls.Add(this.lblIdServer);
            this.Controls.Add(this.txtIdServer);
            this.Controls.Add(this.txtIdModem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbNameM);
            this.Controls.Add(this.cbTypeM);
            this.Controls.Add(this.cbConeccionM);
            this.Controls.Add(this.cbNameS);
            this.Controls.Add(this.cbTypeS);
            this.Controls.Add(this.cbConeccionS);
            this.Controls.Add(this.tablaRuteo);
            this.Name = "FormRuteo";
            this.Text = "Ruteo";
            this.Load += new System.EventHandler(this.FormRuteo_Load);
            this.Resize += new System.EventHandler(this.FormRuteo_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tablaRuteo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaRuteo;
        private System.Windows.Forms.ComboBox cbConeccionS;
        private System.Windows.Forms.ComboBox cbTypeS;
        private System.Windows.Forms.ComboBox cbNameS;
        private System.Windows.Forms.ComboBox cbNameM;
        private System.Windows.Forms.ComboBox cbTypeM;
        private System.Windows.Forms.ComboBox cbConeccionM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnDelete;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdModem;
        private System.Windows.Forms.TextBox txtIdServer;
        private System.Windows.Forms.Label lblIdServer;
        private System.Windows.Forms.Label lblIdModem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModemType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdServer;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdModem;
    }
}