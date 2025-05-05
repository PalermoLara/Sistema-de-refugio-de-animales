namespace GUI
{
    partial class FormGestionUsuario941lp
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
            this.dataUsuarios = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.btnActivarDesactivar = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.labelNombreAdministradorUsuarios = new System.Windows.Forms.Label();
            this.labelRolAdministradorUsuarios = new System.Windows.Forms.Label();
            this.labelApellidoAdministradorUsuarios = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtApellidoUsuario = new System.Windows.Forms.TextBox();
            this.txtEmailUsuario = new System.Windows.Forms.TextBox();
            this.labelEmailAdministradorUsuarios = new System.Windows.Forms.Label();
            this.btnDesbloquearUsuario = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.labelDniAdministrtadorUsuarios = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtModo = new System.Windows.Forms.TextBox();
            this.labelModo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbActivosConsulta = new System.Windows.Forms.RadioButton();
            this.rbTodosConsulta = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataUsuarios
            // 
            this.dataUsuarios.AllowUserToAddRows = false;
            this.dataUsuarios.AllowUserToDeleteRows = false;
            this.dataUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column3,
            this.Column4,
            this.nombreUsuario,
            this.Column5,
            this.Column1,
            this.Column2});
            this.dataUsuarios.Location = new System.Drawing.Point(12, 12);
            this.dataUsuarios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataUsuarios.Name = "dataUsuarios";
            this.dataUsuarios.ReadOnly = true;
            this.dataUsuarios.RowHeadersWidth = 82;
            this.dataUsuarios.RowTemplate.Height = 33;
            this.dataUsuarios.Size = new System.Drawing.Size(1582, 394);
            this.dataUsuarios.TabIndex = 0;
            this.dataUsuarios.TabStop = false;
            this.dataUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataUsuarios_CellClick);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "DNI";
            this.Column9.MinimumWidth = 10;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "nombre";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "apellido";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.HeaderText = "nombreUsuario";
            this.nombreUsuario.MinimumWidth = 10;
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.ReadOnly = true;
            this.nombreUsuario.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "rol";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mail";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Bloqueado";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.BackColor = System.Drawing.Color.White;
            this.btnAltaUsuario.Location = new System.Drawing.Point(1060, 415);
            this.btnAltaUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(258, 81);
            this.btnAltaUsuario.TabIndex = 7;
            this.btnAltaUsuario.Text = "ALTA";
            this.btnAltaUsuario.UseVisualStyleBackColor = false;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // btnActivarDesactivar
            // 
            this.btnActivarDesactivar.Location = new System.Drawing.Point(1336, 415);
            this.btnActivarDesactivar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnActivarDesactivar.Name = "btnActivarDesactivar";
            this.btnActivarDesactivar.Size = new System.Drawing.Size(258, 81);
            this.btnActivarDesactivar.TabIndex = 8;
            this.btnActivarDesactivar.Text = "ACT/DESACT";
            this.btnActivarDesactivar.UseVisualStyleBackColor = true;
            this.btnActivarDesactivar.Click += new System.EventHandler(this.btnActDesactUsuario_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Location = new System.Drawing.Point(1060, 502);
            this.btnModificarUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(258, 81);
            this.btnModificarUsuario.TabIndex = 9;
            this.btnModificarUsuario.Text = "MODIFICAR";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // labelNombreAdministradorUsuarios
            // 
            this.labelNombreAdministradorUsuarios.AutoSize = true;
            this.labelNombreAdministradorUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreAdministradorUsuarios.Location = new System.Drawing.Point(20, 492);
            this.labelNombreAdministradorUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombreAdministradorUsuarios.Name = "labelNombreAdministradorUsuarios";
            this.labelNombreAdministradorUsuarios.Size = new System.Drawing.Size(133, 31);
            this.labelNombreAdministradorUsuarios.TabIndex = 4;
            this.labelNombreAdministradorUsuarios.Text = "NOMBRE";
            // 
            // labelRolAdministradorUsuarios
            // 
            this.labelRolAdministradorUsuarios.AutoSize = true;
            this.labelRolAdministradorUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRolAdministradorUsuarios.Location = new System.Drawing.Point(20, 600);
            this.labelRolAdministradorUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRolAdministradorUsuarios.Name = "labelRolAdministradorUsuarios";
            this.labelRolAdministradorUsuarios.Size = new System.Drawing.Size(70, 31);
            this.labelRolAdministradorUsuarios.TabIndex = 7;
            this.labelRolAdministradorUsuarios.Text = "ROL";
            // 
            // labelApellidoAdministradorUsuarios
            // 
            this.labelApellidoAdministradorUsuarios.AutoSize = true;
            this.labelApellidoAdministradorUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellidoAdministradorUsuarios.Location = new System.Drawing.Point(20, 548);
            this.labelApellidoAdministradorUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelApellidoAdministradorUsuarios.Name = "labelApellidoAdministradorUsuarios";
            this.labelApellidoAdministradorUsuarios.Size = new System.Drawing.Size(147, 31);
            this.labelApellidoAdministradorUsuarios.TabIndex = 10;
            this.labelApellidoAdministradorUsuarios.Text = "APELLIDO";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(252, 492);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(316, 31);
            this.txtNombreUsuario.TabIndex = 1;
            // 
            // txtApellidoUsuario
            // 
            this.txtApellidoUsuario.Location = new System.Drawing.Point(252, 548);
            this.txtApellidoUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtApellidoUsuario.Name = "txtApellidoUsuario";
            this.txtApellidoUsuario.Size = new System.Drawing.Size(316, 31);
            this.txtApellidoUsuario.TabIndex = 2;
            // 
            // txtEmailUsuario
            // 
            this.txtEmailUsuario.Location = new System.Drawing.Point(252, 654);
            this.txtEmailUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmailUsuario.Name = "txtEmailUsuario";
            this.txtEmailUsuario.Size = new System.Drawing.Size(316, 31);
            this.txtEmailUsuario.TabIndex = 4;
            // 
            // labelEmailAdministradorUsuarios
            // 
            this.labelEmailAdministradorUsuarios.AutoSize = true;
            this.labelEmailAdministradorUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmailAdministradorUsuarios.Location = new System.Drawing.Point(20, 654);
            this.labelEmailAdministradorUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmailAdministradorUsuarios.Name = "labelEmailAdministradorUsuarios";
            this.labelEmailAdministradorUsuarios.Size = new System.Drawing.Size(95, 31);
            this.labelEmailAdministradorUsuarios.TabIndex = 16;
            this.labelEmailAdministradorUsuarios.Text = "EMAIL";
            // 
            // btnDesbloquearUsuario
            // 
            this.btnDesbloquearUsuario.Location = new System.Drawing.Point(1336, 502);
            this.btnDesbloquearUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDesbloquearUsuario.Name = "btnDesbloquearUsuario";
            this.btnDesbloquearUsuario.Size = new System.Drawing.Size(258, 81);
            this.btnDesbloquearUsuario.TabIndex = 10;
            this.btnDesbloquearUsuario.Text = "DESBLOQUEAR";
            this.btnDesbloquearUsuario.UseVisualStyleBackColor = true;
            this.btnDesbloquearUsuario.Click += new System.EventHandler(this.btnDesbloquearUsuario_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1060, 588);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(258, 81);
            this.btnSalir.TabIndex = 11;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Items.AddRange(new object[] {
            "Administrador",
            "Maestro"});
            this.comboBoxRoles.Location = new System.Drawing.Point(252, 600);
            this.comboBoxRoles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(316, 33);
            this.comboBoxRoles.TabIndex = 3;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(252, 442);
            this.txtDni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(316, 31);
            this.txtDni.TabIndex = 0;
            // 
            // labelDniAdministrtadorUsuarios
            // 
            this.labelDniAdministrtadorUsuarios.AutoSize = true;
            this.labelDniAdministrtadorUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDniAdministrtadorUsuarios.Location = new System.Drawing.Point(20, 442);
            this.labelDniAdministrtadorUsuarios.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDniAdministrtadorUsuarios.Name = "labelDniAdministrtadorUsuarios";
            this.labelDniAdministrtadorUsuarios.Size = new System.Drawing.Size(62, 31);
            this.labelDniAdministrtadorUsuarios.TabIndex = 21;
            this.labelDniAdministrtadorUsuarios.Text = "DNI";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(602, 531);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(258, 81);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(602, 437);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(258, 81);
            this.btnAplicar.TabIndex = 5;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtModo
            // 
            this.txtModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModo.Location = new System.Drawing.Point(1060, 762);
            this.txtModo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModo.Multiline = true;
            this.txtModo.Name = "txtModo";
            this.txtModo.Size = new System.Drawing.Size(532, 83);
            this.txtModo.TabIndex = 25;
            // 
            // labelModo
            // 
            this.labelModo.AutoSize = true;
            this.labelModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModo.Location = new System.Drawing.Point(1056, 710);
            this.labelModo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelModo.Name = "labelModo";
            this.labelModo.Size = new System.Drawing.Size(149, 44);
            this.labelModo.TabIndex = 26;
            this.labelModo.Text = "MODO:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbActivosConsulta);
            this.groupBox1.Controls.Add(this.rbTodosConsulta);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(602, 640);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(400, 192);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuarios en grilla";
            // 
            // rbActivosConsulta
            // 
            this.rbActivosConsulta.AutoSize = true;
            this.rbActivosConsulta.Checked = true;
            this.rbActivosConsulta.Location = new System.Drawing.Point(36, 121);
            this.rbActivosConsulta.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbActivosConsulta.Name = "rbActivosConsulta";
            this.rbActivosConsulta.Size = new System.Drawing.Size(151, 41);
            this.rbActivosConsulta.TabIndex = 1;
            this.rbActivosConsulta.TabStop = true;
            this.rbActivosConsulta.Text = "Activos";
            this.rbActivosConsulta.UseVisualStyleBackColor = true;
            this.rbActivosConsulta.CheckedChanged += new System.EventHandler(this.rbActivosConsulta_CheckedChanged);
            // 
            // rbTodosConsulta
            // 
            this.rbTodosConsulta.AutoSize = true;
            this.rbTodosConsulta.Location = new System.Drawing.Point(36, 58);
            this.rbTodosConsulta.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbTodosConsulta.Name = "rbTodosConsulta";
            this.rbTodosConsulta.Size = new System.Drawing.Size(138, 41);
            this.rbTodosConsulta.TabIndex = 0;
            this.rbTodosConsulta.Text = "Todos";
            this.rbTodosConsulta.UseVisualStyleBackColor = true;
            this.rbTodosConsulta.CheckedChanged += new System.EventHandler(this.rbTodosConsulta_CheckedChanged);
            // 
            // FormGestionUsuario941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1652, 856);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelModo);
            this.Controls.Add(this.txtModo);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.labelDniAdministrtadorUsuarios);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnDesbloquearUsuario);
            this.Controls.Add(this.txtEmailUsuario);
            this.Controls.Add(this.labelEmailAdministradorUsuarios);
            this.Controls.Add(this.txtApellidoUsuario);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.labelApellidoAdministradorUsuarios);
            this.Controls.Add(this.labelRolAdministradorUsuarios);
            this.Controls.Add(this.labelNombreAdministradorUsuarios);
            this.Controls.Add(this.btnModificarUsuario);
            this.Controls.Add(this.btnActivarDesactivar);
            this.Controls.Add(this.btnAltaUsuario);
            this.Controls.Add(this.dataUsuarios);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormGestionUsuario941lp";
            this.Text = "FormAdministradorUsuario";
            this.Load += new System.EventHandler(this.FormAdministradorUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataUsuarios;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Label labelNombreAdministradorUsuarios;
        private System.Windows.Forms.Label labelRolAdministradorUsuarios;
        private System.Windows.Forms.Label labelApellidoAdministradorUsuarios;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtApellidoUsuario;
        private System.Windows.Forms.TextBox txtEmailUsuario;
        private System.Windows.Forms.Label labelEmailAdministradorUsuarios;
        private System.Windows.Forms.Button btnDesbloquearUsuario;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label labelDniAdministrtadorUsuarios;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtModo;
        private System.Windows.Forms.Label labelModo;
        private System.Windows.Forms.Button btnActivarDesactivar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbActivosConsulta;
        private System.Windows.Forms.RadioButton rbTodosConsulta;
    }
}