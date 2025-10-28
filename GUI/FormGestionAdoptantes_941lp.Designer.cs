namespace GUI
{
    partial class FormGestionAdoptantes_941lp
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
            this.btnActDesact = new System.Windows.Forms.Button();
            this.dataAdoptantes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.labelDNI = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.btnApellido = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAlta = new System.Windows.Forms.Button();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.labelDniAdop = new System.Windows.Forms.Label();
            this.labelNombreAdop = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelEdad = new System.Windows.Forms.Label();
            this.labelTelAdop = new System.Windows.Forms.Label();
            this.labelDomicilio = new System.Windows.Forms.Label();
            this.labelMascotas = new System.Windows.Forms.Label();
            this.comboBoxMascota = new System.Windows.Forms.ComboBox();
            this.comboBoxActivo = new System.Windows.Forms.ComboBox();
            this.labelActiva = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdoptantes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActDesact
            // 
            this.btnActDesact.Location = new System.Drawing.Point(1056, 549);
            this.btnActDesact.Margin = new System.Windows.Forms.Padding(4);
            this.btnActDesact.Name = "btnActDesact";
            this.btnActDesact.Size = new System.Drawing.Size(410, 81);
            this.btnActDesact.TabIndex = 83;
            this.btnActDesact.Text = "ACTIVAR/DESACTIVAR";
            this.btnActDesact.UseVisualStyleBackColor = true;
            this.btnActDesact.Click += new System.EventHandler(this.btnActDesact_Click);
            // 
            // dataAdoptantes
            // 
            this.dataAdoptantes.AllowUserToAddRows = false;
            this.dataAdoptantes.AllowUserToDeleteRows = false;
            this.dataAdoptantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAdoptantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.Column3,
            this.Column2});
            this.dataAdoptantes.Location = new System.Drawing.Point(73, 12);
            this.dataAdoptantes.Name = "dataAdoptantes";
            this.dataAdoptantes.ReadOnly = true;
            this.dataAdoptantes.RowHeadersWidth = 82;
            this.dataAdoptantes.RowTemplate.Height = 33;
            this.dataAdoptantes.Size = new System.Drawing.Size(1454, 329);
            this.dataAdoptantes.TabIndex = 82;
            this.dataAdoptantes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAdoptantes_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "DNI";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Apellido";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Telefono";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Edad";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Domicilio";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Mascotas";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Activo";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(251, 385);
            this.txtDni.Margin = new System.Windows.Forms.Padding(4);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(316, 31);
            this.txtDni.TabIndex = 67;
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(251, 596);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(4);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(316, 31);
            this.txtEdad.TabIndex = 71;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(596, 370);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(258, 81);
            this.btnAplicar.TabIndex = 73;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(596, 459);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(258, 81);
            this.btnCancelar.TabIndex = 74;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(251, 436);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(316, 31);
            this.txtNombre.TabIndex = 68;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(-320, 324);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(133, 31);
            this.labelNombre.TabIndex = 81;
            this.labelNombre.Text = "NOMBRE";
            this.labelNombre.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(596, 549);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(258, 81);
            this.btnSalir.TabIndex = 79;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNI.Location = new System.Drawing.Point(-318, 273);
            this.labelDNI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(62, 31);
            this.labelDNI.TabIndex = 80;
            this.labelDNI.Text = "DNI";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(251, 540);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(316, 31);
            this.txtTelefono.TabIndex = 70;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(251, 486);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(316, 31);
            this.txtApellido.TabIndex = 69;
            // 
            // btnApellido
            // 
            this.btnApellido.AutoSize = true;
            this.btnApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApellido.Location = new System.Drawing.Point(-318, 374);
            this.btnApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnApellido.Name = "btnApellido";
            this.btnApellido.Size = new System.Drawing.Size(147, 31);
            this.btnApellido.TabIndex = 78;
            this.btnApellido.Text = "APELLIDO";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccion.Location = new System.Drawing.Point(-320, 482);
            this.labelDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(169, 31);
            this.labelDireccion.TabIndex = 75;
            this.labelDireccion.Text = "DIRECCIÓN";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTelefono.Location = new System.Drawing.Point(-318, 426);
            this.labelTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(161, 31);
            this.labelTelefono.TabIndex = 72;
            this.labelTelefono.Text = "TELEFONO";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(1056, 459);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(410, 81);
            this.btnModificar.TabIndex = 77;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(1056, 370);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(410, 81);
            this.btnAlta.TabIndex = 76;
            this.btnAlta.Text = "ALTA";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(251, 644);
            this.txtDomicilio.Margin = new System.Windows.Forms.Padding(4);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(316, 31);
            this.txtDomicilio.TabIndex = 84;
            // 
            // labelDniAdop
            // 
            this.labelDniAdop.AutoSize = true;
            this.labelDniAdop.Location = new System.Drawing.Point(68, 391);
            this.labelDniAdop.Name = "labelDniAdop";
            this.labelDniAdop.Size = new System.Drawing.Size(47, 25);
            this.labelDniAdop.TabIndex = 86;
            this.labelDniAdop.Text = "DNI";
            // 
            // labelNombreAdop
            // 
            this.labelNombreAdop.AutoSize = true;
            this.labelNombreAdop.Location = new System.Drawing.Point(68, 439);
            this.labelNombreAdop.Name = "labelNombreAdop";
            this.labelNombreAdop.Size = new System.Drawing.Size(87, 25);
            this.labelNombreAdop.TabIndex = 87;
            this.labelNombreAdop.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(68, 492);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(89, 25);
            this.labelApellido.TabIndex = 88;
            this.labelApellido.Text = "Apellido";
            // 
            // labelEdad
            // 
            this.labelEdad.AutoSize = true;
            this.labelEdad.Location = new System.Drawing.Point(68, 605);
            this.labelEdad.Name = "labelEdad";
            this.labelEdad.Size = new System.Drawing.Size(62, 25);
            this.labelEdad.TabIndex = 89;
            this.labelEdad.Text = "Edad";
            // 
            // labelTelAdop
            // 
            this.labelTelAdop.AutoSize = true;
            this.labelTelAdop.Location = new System.Drawing.Point(68, 549);
            this.labelTelAdop.Name = "labelTelAdop";
            this.labelTelAdop.Size = new System.Drawing.Size(96, 25);
            this.labelTelAdop.TabIndex = 90;
            this.labelTelAdop.Text = "Telefono";
            // 
            // labelDomicilio
            // 
            this.labelDomicilio.AutoSize = true;
            this.labelDomicilio.Location = new System.Drawing.Point(68, 650);
            this.labelDomicilio.Name = "labelDomicilio";
            this.labelDomicilio.Size = new System.Drawing.Size(99, 25);
            this.labelDomicilio.TabIndex = 91;
            this.labelDomicilio.Text = "Domicilio";
            // 
            // labelMascotas
            // 
            this.labelMascotas.AutoSize = true;
            this.labelMascotas.Location = new System.Drawing.Point(68, 706);
            this.labelMascotas.Name = "labelMascotas";
            this.labelMascotas.Size = new System.Drawing.Size(105, 25);
            this.labelMascotas.TabIndex = 92;
            this.labelMascotas.Text = "Mascotas";
            // 
            // comboBoxMascota
            // 
            this.comboBoxMascota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMascota.FormattingEnabled = true;
            this.comboBoxMascota.Items.AddRange(new object[] {
            "si",
            "no"});
            this.comboBoxMascota.Location = new System.Drawing.Point(251, 698);
            this.comboBoxMascota.Name = "comboBoxMascota";
            this.comboBoxMascota.Size = new System.Drawing.Size(316, 33);
            this.comboBoxMascota.TabIndex = 93;
            // 
            // comboBoxActivo
            // 
            this.comboBoxActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxActivo.FormattingEnabled = true;
            this.comboBoxActivo.Items.AddRange(new object[] {
            "si",
            "no"});
            this.comboBoxActivo.Location = new System.Drawing.Point(251, 748);
            this.comboBoxActivo.Name = "comboBoxActivo";
            this.comboBoxActivo.Size = new System.Drawing.Size(316, 33);
            this.comboBoxActivo.TabIndex = 95;
            // 
            // labelActiva
            // 
            this.labelActiva.AutoSize = true;
            this.labelActiva.Location = new System.Drawing.Point(68, 756);
            this.labelActiva.Name = "labelActiva";
            this.labelActiva.Size = new System.Drawing.Size(71, 25);
            this.labelActiva.TabIndex = 94;
            this.labelActiva.Text = "Activa";
            // 
            // FormGestionAdoptantes_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1635, 821);
            this.Controls.Add(this.comboBoxActivo);
            this.Controls.Add(this.labelActiva);
            this.Controls.Add(this.comboBoxMascota);
            this.Controls.Add(this.labelMascotas);
            this.Controls.Add(this.labelDomicilio);
            this.Controls.Add(this.labelTelAdop);
            this.Controls.Add(this.labelEdad);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombreAdop);
            this.Controls.Add(this.labelDniAdop);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.btnActDesact);
            this.Controls.Add(this.dataAdoptantes);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.btnApellido);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAlta);
            this.Name = "FormGestionAdoptantes_941lp";
            this.Text = "FormGestionAdoptantes_941lp";
            this.Load += new System.EventHandler(this.FormGestionAdoptantes_941lp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAdoptantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnActDesact;
        private System.Windows.Forms.DataGridView dataAdoptantes;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label btnApellido;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.Label labelDniAdop;
        private System.Windows.Forms.Label labelNombreAdop;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelEdad;
        private System.Windows.Forms.Label labelTelAdop;
        private System.Windows.Forms.Label labelDomicilio;
        private System.Windows.Forms.Label labelMascotas;
        private System.Windows.Forms.ComboBox comboBoxMascota;
        private System.Windows.Forms.ComboBox comboBoxActivo;
        private System.Windows.Forms.Label labelActiva;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}