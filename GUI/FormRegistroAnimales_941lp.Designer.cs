namespace GUI
{
    partial class FormRegistroAnimales_941lp
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
            this.dtAnimales = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtEspecie = new System.Windows.Forms.TextBox();
            this.labelEspecieRegistro = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.labelSexoAnimal = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.btnRazaRegistroAnimal = new System.Windows.Forms.Label();
            this.labelTamañoAnimal = new System.Windows.Forms.Label();
            this.labelNombreRegistroAnimal = new System.Windows.Forms.Label();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.txtTamaño = new System.Windows.Forms.TextBox();
            this.groupBoxEstadoAdopcion = new System.Windows.Forms.GroupBox();
            this.rbAdoptado = new System.Windows.Forms.RadioButton();
            this.rbDisponibleAdopcion = new System.Windows.Forms.RadioButton();
            this.rbEnEvaluacionAdopcion = new System.Windows.Forms.RadioButton();
            this.groupBoxCastrado = new System.Windows.Forms.GroupBox();
            this.rbHembraSexo = new System.Windows.Forms.RadioButton();
            this.rbMachoSexo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).BeginInit();
            this.groupBoxEstadoAdopcion.SuspendLayout();
            this.groupBoxCastrado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtAnimales
            // 
            this.dtAnimales.AllowUserToAddRows = false;
            this.dtAnimales.AllowUserToDeleteRows = false;
            this.dtAnimales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtAnimales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dtAnimales.Location = new System.Drawing.Point(6, 6);
            this.dtAnimales.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtAnimales.Name = "dtAnimales";
            this.dtAnimales.ReadOnly = true;
            this.dtAnimales.RowHeadersWidth = 82;
            this.dtAnimales.RowTemplate.Height = 33;
            this.dtAnimales.Size = new System.Drawing.Size(728, 171);
            this.dtAnimales.TabIndex = 2;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Codigo";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Especie";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Raza";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Nombre";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tamaño";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Sexo";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Estado";
            this.Column7.MinimumWidth = 10;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 200;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(298, 189);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(129, 42);
            this.btnAplicar.TabIndex = 32;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(298, 235);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 42);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // txtEspecie
            // 
            this.txtEspecie.Location = new System.Drawing.Point(122, 192);
            this.txtEspecie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEspecie.Name = "txtEspecie";
            this.txtEspecie.Size = new System.Drawing.Size(160, 20);
            this.txtEspecie.TabIndex = 27;
            // 
            // labelEspecieRegistro
            // 
            this.labelEspecieRegistro.AutoSize = true;
            this.labelEspecieRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEspecieRegistro.Location = new System.Drawing.Point(6, 192);
            this.labelEspecieRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEspecieRegistro.Name = "labelEspecieRegistro";
            this.labelEspecieRegistro.Size = new System.Drawing.Size(65, 17);
            this.labelEspecieRegistro.TabIndex = 41;
            this.labelEspecieRegistro.Text = "ESPECIE";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(298, 282);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 42);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // labelSexoAnimal
            // 
            this.labelSexoAnimal.AutoSize = true;
            this.labelSexoAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSexoAnimal.Location = new System.Drawing.Point(7, 321);
            this.labelSexoAnimal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSexoAnimal.Name = "labelSexoAnimal";
            this.labelSexoAnimal.Size = new System.Drawing.Size(46, 17);
            this.labelSexoAnimal.TabIndex = 40;
            this.labelSexoAnimal.Text = "SEXO";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(122, 246);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(160, 20);
            this.txtNombre.TabIndex = 29;
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(122, 218);
            this.txtRaza.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(160, 20);
            this.txtRaza.TabIndex = 28;
            // 
            // btnRazaRegistroAnimal
            // 
            this.btnRazaRegistroAnimal.AutoSize = true;
            this.btnRazaRegistroAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRazaRegistroAnimal.Location = new System.Drawing.Point(7, 218);
            this.btnRazaRegistroAnimal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btnRazaRegistroAnimal.Name = "btnRazaRegistroAnimal";
            this.btnRazaRegistroAnimal.Size = new System.Drawing.Size(45, 17);
            this.btnRazaRegistroAnimal.TabIndex = 38;
            this.btnRazaRegistroAnimal.Text = "RAZA";
            // 
            // labelTamañoAnimal
            // 
            this.labelTamañoAnimal.AutoSize = true;
            this.labelTamañoAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTamañoAnimal.Location = new System.Drawing.Point(6, 274);
            this.labelTamañoAnimal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTamañoAnimal.Name = "labelTamañoAnimal";
            this.labelTamañoAnimal.Size = new System.Drawing.Size(67, 17);
            this.labelTamañoAnimal.TabIndex = 35;
            this.labelTamañoAnimal.Text = "TAMAÑO";
            // 
            // labelNombreRegistroAnimal
            // 
            this.labelNombreRegistroAnimal.AutoSize = true;
            this.labelNombreRegistroAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreRegistroAnimal.Location = new System.Drawing.Point(7, 245);
            this.labelNombreRegistroAnimal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNombreRegistroAnimal.Name = "labelNombreRegistroAnimal";
            this.labelNombreRegistroAnimal.Size = new System.Drawing.Size(68, 17);
            this.labelNombreRegistroAnimal.TabIndex = 31;
            this.labelNombreRegistroAnimal.Text = "NOMBRE";
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Location = new System.Drawing.Point(528, 230);
            this.btnModificarUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(205, 42);
            this.btnModificarUsuario.TabIndex = 37;
            this.btnModificarUsuario.Text = "MODIFICAR";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.Location = new System.Drawing.Point(528, 185);
            this.btnAltaUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(205, 42);
            this.btnAltaUsuario.TabIndex = 36;
            this.btnAltaUsuario.Text = "ALTA";
            this.btnAltaUsuario.UseVisualStyleBackColor = true;
            // 
            // txtTamaño
            // 
            this.txtTamaño.Location = new System.Drawing.Point(122, 275);
            this.txtTamaño.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTamaño.Name = "txtTamaño";
            this.txtTamaño.Size = new System.Drawing.Size(160, 20);
            this.txtTamaño.TabIndex = 42;
            // 
            // groupBoxEstadoAdopcion
            // 
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbAdoptado);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbDisponibleAdopcion);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbEnEvaluacionAdopcion);
            this.groupBoxEstadoAdopcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEstadoAdopcion.Location = new System.Drawing.Point(464, 285);
            this.groupBoxEstadoAdopcion.Name = "groupBoxEstadoAdopcion";
            this.groupBoxEstadoAdopcion.Size = new System.Drawing.Size(264, 134);
            this.groupBoxEstadoAdopcion.TabIndex = 45;
            this.groupBoxEstadoAdopcion.TabStop = false;
            this.groupBoxEstadoAdopcion.Text = "Estado";
            // 
            // rbAdoptado
            // 
            this.rbAdoptado.AutoSize = true;
            this.rbAdoptado.Location = new System.Drawing.Point(40, 94);
            this.rbAdoptado.Name = "rbAdoptado";
            this.rbAdoptado.Size = new System.Drawing.Size(97, 24);
            this.rbAdoptado.TabIndex = 2;
            this.rbAdoptado.TabStop = true;
            this.rbAdoptado.Text = "Adoptado";
            this.rbAdoptado.UseVisualStyleBackColor = true;
            // 
            // rbDisponibleAdopcion
            // 
            this.rbDisponibleAdopcion.AutoSize = true;
            this.rbDisponibleAdopcion.Location = new System.Drawing.Point(40, 60);
            this.rbDisponibleAdopcion.Name = "rbDisponibleAdopcion";
            this.rbDisponibleAdopcion.Size = new System.Drawing.Size(101, 24);
            this.rbDisponibleAdopcion.TabIndex = 1;
            this.rbDisponibleAdopcion.TabStop = true;
            this.rbDisponibleAdopcion.Text = "Disponible";
            this.rbDisponibleAdopcion.UseVisualStyleBackColor = true;
            // 
            // rbEnEvaluacionAdopcion
            // 
            this.rbEnEvaluacionAdopcion.AutoSize = true;
            this.rbEnEvaluacionAdopcion.Location = new System.Drawing.Point(40, 26);
            this.rbEnEvaluacionAdopcion.Name = "rbEnEvaluacionAdopcion";
            this.rbEnEvaluacionAdopcion.Size = new System.Drawing.Size(126, 24);
            this.rbEnEvaluacionAdopcion.TabIndex = 0;
            this.rbEnEvaluacionAdopcion.TabStop = true;
            this.rbEnEvaluacionAdopcion.Text = "En evaluación";
            this.rbEnEvaluacionAdopcion.UseVisualStyleBackColor = true;
            // 
            // groupBoxCastrado
            // 
            this.groupBoxCastrado.Controls.Add(this.rbHembraSexo);
            this.groupBoxCastrado.Controls.Add(this.rbMachoSexo);
            this.groupBoxCastrado.Location = new System.Drawing.Point(122, 302);
            this.groupBoxCastrado.Name = "groupBoxCastrado";
            this.groupBoxCastrado.Size = new System.Drawing.Size(160, 47);
            this.groupBoxCastrado.TabIndex = 19;
            this.groupBoxCastrado.TabStop = false;
            // 
            // rbHembraSexo
            // 
            this.rbHembraSexo.AutoSize = true;
            this.rbHembraSexo.Location = new System.Drawing.Point(100, 19);
            this.rbHembraSexo.Name = "rbHembraSexo";
            this.rbHembraSexo.Size = new System.Drawing.Size(33, 17);
            this.rbHembraSexo.TabIndex = 1;
            this.rbHembraSexo.TabStop = true;
            this.rbHembraSexo.Text = "H";
            this.rbHembraSexo.UseVisualStyleBackColor = true;
            // 
            // rbMachoSexo
            // 
            this.rbMachoSexo.AutoSize = true;
            this.rbMachoSexo.Location = new System.Drawing.Point(29, 19);
            this.rbMachoSexo.Name = "rbMachoSexo";
            this.rbMachoSexo.Size = new System.Drawing.Size(34, 17);
            this.rbMachoSexo.TabIndex = 0;
            this.rbMachoSexo.TabStop = true;
            this.rbMachoSexo.Text = "M";
            this.rbMachoSexo.UseVisualStyleBackColor = true;
            // 
            // FormRegistroAnimales_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(740, 431);
            this.Controls.Add(this.groupBoxCastrado);
            this.Controls.Add(this.groupBoxEstadoAdopcion);
            this.Controls.Add(this.txtTamaño);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtEspecie);
            this.Controls.Add(this.labelEspecieRegistro);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.labelSexoAnimal);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtRaza);
            this.Controls.Add(this.btnRazaRegistroAnimal);
            this.Controls.Add(this.labelTamañoAnimal);
            this.Controls.Add(this.labelNombreRegistroAnimal);
            this.Controls.Add(this.btnModificarUsuario);
            this.Controls.Add(this.btnAltaUsuario);
            this.Controls.Add(this.dtAnimales);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormRegistroAnimales_941lp";
            this.Text = "FormRegistroAnimales";
            this.Load += new System.EventHandler(this.FormRegistroAnimales_941lp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).EndInit();
            this.groupBoxEstadoAdopcion.ResumeLayout(false);
            this.groupBoxEstadoAdopcion.PerformLayout();
            this.groupBoxCastrado.ResumeLayout(false);
            this.groupBoxCastrado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtAnimales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtEspecie;
        private System.Windows.Forms.Label labelEspecieRegistro;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label labelSexoAnimal;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.Label btnRazaRegistroAnimal;
        private System.Windows.Forms.Label labelTamañoAnimal;
        private System.Windows.Forms.Label labelNombreRegistroAnimal;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.TextBox txtTamaño;
        private System.Windows.Forms.GroupBox groupBoxEstadoAdopcion;
        private System.Windows.Forms.RadioButton rbAdoptado;
        private System.Windows.Forms.RadioButton rbDisponibleAdopcion;
        private System.Windows.Forms.RadioButton rbEnEvaluacionAdopcion;
        private System.Windows.Forms.GroupBox groupBoxCastrado;
        private System.Windows.Forms.RadioButton rbHembraSexo;
        private System.Windows.Forms.RadioButton rbMachoSexo;
    }
}