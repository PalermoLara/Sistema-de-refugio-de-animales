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
            this.dataAnimales = new System.Windows.Forms.DataGridView();
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
            this.btnModificarAnimal = new System.Windows.Forms.Button();
            this.btnAltaAnimal = new System.Windows.Forms.Button();
            this.groupBoxEstadoAdopcion = new System.Windows.Forms.GroupBox();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbAdoptado = new System.Windows.Forms.RadioButton();
            this.rbDisponibleAdopcion = new System.Windows.Forms.RadioButton();
            this.rbEnEvaluacionAdopcion = new System.Windows.Forms.RadioButton();
            this.comboBoxSexo = new System.Windows.Forms.ComboBox();
            this.comboBoxTamaño = new System.Windows.Forms.ComboBox();
            this.comboBoxEstado = new System.Windows.Forms.ComboBox();
            this.labelEstadoAnimal = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnReingreso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnimales)).BeginInit();
            this.groupBoxEstadoAdopcion.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataAnimales
            // 
            this.dataAnimales.AllowUserToAddRows = false;
            this.dataAnimales.AllowUserToDeleteRows = false;
            this.dataAnimales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAnimales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dataAnimales.Location = new System.Drawing.Point(12, 12);
            this.dataAnimales.Margin = new System.Windows.Forms.Padding(4);
            this.dataAnimales.Name = "dataAnimales";
            this.dataAnimales.ReadOnly = true;
            this.dataAnimales.RowHeadersWidth = 82;
            this.dataAnimales.RowTemplate.Height = 33;
            this.dataAnimales.Size = new System.Drawing.Size(1456, 329);
            this.dataAnimales.TabIndex = 2;
            this.dataAnimales.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAnimales_CellClick);
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
            this.btnAplicar.Location = new System.Drawing.Point(596, 363);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(258, 81);
            this.btnAplicar.TabIndex = 32;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(596, 452);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(258, 81);
            this.btnCancelar.TabIndex = 34;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtEspecie
            // 
            this.txtEspecie.Location = new System.Drawing.Point(244, 369);
            this.txtEspecie.Margin = new System.Windows.Forms.Padding(4);
            this.txtEspecie.Name = "txtEspecie";
            this.txtEspecie.Size = new System.Drawing.Size(316, 31);
            this.txtEspecie.TabIndex = 0;
            // 
            // labelEspecieRegistro
            // 
            this.labelEspecieRegistro.AutoSize = true;
            this.labelEspecieRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEspecieRegistro.Location = new System.Drawing.Point(12, 369);
            this.labelEspecieRegistro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEspecieRegistro.Name = "labelEspecieRegistro";
            this.labelEspecieRegistro.Size = new System.Drawing.Size(132, 31);
            this.labelEspecieRegistro.TabIndex = 41;
            this.labelEspecieRegistro.Text = "ESPECIE";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(596, 542);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(258, 81);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // labelSexoAnimal
            // 
            this.labelSexoAnimal.AutoSize = true;
            this.labelSexoAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSexoAnimal.Location = new System.Drawing.Point(14, 581);
            this.labelSexoAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSexoAnimal.Name = "labelSexoAnimal";
            this.labelSexoAnimal.Size = new System.Drawing.Size(89, 31);
            this.labelSexoAnimal.TabIndex = 40;
            this.labelSexoAnimal.Text = "SEXO";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(244, 473);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(316, 31);
            this.txtNombre.TabIndex = 2;
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(244, 419);
            this.txtRaza.Margin = new System.Windows.Forms.Padding(4);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(316, 31);
            this.txtRaza.TabIndex = 1;
            // 
            // btnRazaRegistroAnimal
            // 
            this.btnRazaRegistroAnimal.AutoSize = true;
            this.btnRazaRegistroAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRazaRegistroAnimal.Location = new System.Drawing.Point(14, 419);
            this.btnRazaRegistroAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnRazaRegistroAnimal.Name = "btnRazaRegistroAnimal";
            this.btnRazaRegistroAnimal.Size = new System.Drawing.Size(87, 31);
            this.btnRazaRegistroAnimal.TabIndex = 38;
            this.btnRazaRegistroAnimal.Text = "RAZA";
            // 
            // labelTamañoAnimal
            // 
            this.labelTamañoAnimal.AutoSize = true;
            this.labelTamañoAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTamañoAnimal.Location = new System.Drawing.Point(12, 527);
            this.labelTamañoAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTamañoAnimal.Name = "labelTamañoAnimal";
            this.labelTamañoAnimal.Size = new System.Drawing.Size(130, 31);
            this.labelTamañoAnimal.TabIndex = 35;
            this.labelTamañoAnimal.Text = "TAMAÑO";
            // 
            // labelNombreRegistroAnimal
            // 
            this.labelNombreRegistroAnimal.AutoSize = true;
            this.labelNombreRegistroAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreRegistroAnimal.Location = new System.Drawing.Point(14, 471);
            this.labelNombreRegistroAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombreRegistroAnimal.Name = "labelNombreRegistroAnimal";
            this.labelNombreRegistroAnimal.Size = new System.Drawing.Size(133, 31);
            this.labelNombreRegistroAnimal.TabIndex = 31;
            this.labelNombreRegistroAnimal.Text = "NOMBRE";
            // 
            // btnModificarAnimal
            // 
            this.btnModificarAnimal.Location = new System.Drawing.Point(987, 449);
            this.btnModificarAnimal.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarAnimal.Name = "btnModificarAnimal";
            this.btnModificarAnimal.Size = new System.Drawing.Size(410, 81);
            this.btnModificarAnimal.TabIndex = 37;
            this.btnModificarAnimal.Text = "MODIFICAR";
            this.btnModificarAnimal.UseVisualStyleBackColor = true;
            this.btnModificarAnimal.Click += new System.EventHandler(this.btnModificarAnimal_Click);
            // 
            // btnAltaAnimal
            // 
            this.btnAltaAnimal.Location = new System.Drawing.Point(987, 363);
            this.btnAltaAnimal.Margin = new System.Windows.Forms.Padding(4);
            this.btnAltaAnimal.Name = "btnAltaAnimal";
            this.btnAltaAnimal.Size = new System.Drawing.Size(410, 81);
            this.btnAltaAnimal.TabIndex = 36;
            this.btnAltaAnimal.Text = "ALTA";
            this.btnAltaAnimal.UseVisualStyleBackColor = true;
            this.btnAltaAnimal.Click += new System.EventHandler(this.btnAltaAnimal_Click);
            // 
            // groupBoxEstadoAdopcion
            // 
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbTodos);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbAdoptado);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbDisponibleAdopcion);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbEnEvaluacionAdopcion);
            this.groupBoxEstadoAdopcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEstadoAdopcion.Location = new System.Drawing.Point(928, 548);
            this.groupBoxEstadoAdopcion.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxEstadoAdopcion.Name = "groupBoxEstadoAdopcion";
            this.groupBoxEstadoAdopcion.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxEstadoAdopcion.Size = new System.Drawing.Size(528, 310);
            this.groupBoxEstadoAdopcion.TabIndex = 45;
            this.groupBoxEstadoAdopcion.TabStop = false;
            this.groupBoxEstadoAdopcion.Text = "Estado";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(80, 244);
            this.rbTodos.Margin = new System.Windows.Forms.Padding(6);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(138, 41);
            this.rbTodos.TabIndex = 3;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            this.rbTodos.CheckedChanged += new System.EventHandler(this.rbTodos_CheckedChanged);
            // 
            // rbAdoptado
            // 
            this.rbAdoptado.AutoSize = true;
            this.rbAdoptado.Location = new System.Drawing.Point(80, 181);
            this.rbAdoptado.Margin = new System.Windows.Forms.Padding(6);
            this.rbAdoptado.Name = "rbAdoptado";
            this.rbAdoptado.Size = new System.Drawing.Size(187, 41);
            this.rbAdoptado.TabIndex = 2;
            this.rbAdoptado.Text = "Adoptado";
            this.rbAdoptado.UseVisualStyleBackColor = true;
            this.rbAdoptado.CheckedChanged += new System.EventHandler(this.rbAdoptado_CheckedChanged);
            // 
            // rbDisponibleAdopcion
            // 
            this.rbDisponibleAdopcion.AutoSize = true;
            this.rbDisponibleAdopcion.Location = new System.Drawing.Point(80, 115);
            this.rbDisponibleAdopcion.Margin = new System.Windows.Forms.Padding(6);
            this.rbDisponibleAdopcion.Name = "rbDisponibleAdopcion";
            this.rbDisponibleAdopcion.Size = new System.Drawing.Size(197, 41);
            this.rbDisponibleAdopcion.TabIndex = 1;
            this.rbDisponibleAdopcion.Text = "Disponible";
            this.rbDisponibleAdopcion.UseVisualStyleBackColor = true;
            this.rbDisponibleAdopcion.CheckedChanged += new System.EventHandler(this.rbDisponibleAdopcion_CheckedChanged);
            // 
            // rbEnEvaluacionAdopcion
            // 
            this.rbEnEvaluacionAdopcion.AutoSize = true;
            this.rbEnEvaluacionAdopcion.Location = new System.Drawing.Point(80, 50);
            this.rbEnEvaluacionAdopcion.Margin = new System.Windows.Forms.Padding(6);
            this.rbEnEvaluacionAdopcion.Name = "rbEnEvaluacionAdopcion";
            this.rbEnEvaluacionAdopcion.Size = new System.Drawing.Size(248, 41);
            this.rbEnEvaluacionAdopcion.TabIndex = 0;
            this.rbEnEvaluacionAdopcion.Text = "En evaluación";
            this.rbEnEvaluacionAdopcion.UseVisualStyleBackColor = true;
            this.rbEnEvaluacionAdopcion.CheckedChanged += new System.EventHandler(this.rbEnEvaluacionAdopcion_CheckedChanged);
            // 
            // comboBoxSexo
            // 
            this.comboBoxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSexo.FormattingEnabled = true;
            this.comboBoxSexo.Items.AddRange(new object[] {
            "Macho",
            "Hembra"});
            this.comboBoxSexo.Location = new System.Drawing.Point(244, 581);
            this.comboBoxSexo.Name = "comboBoxSexo";
            this.comboBoxSexo.Size = new System.Drawing.Size(316, 33);
            this.comboBoxSexo.TabIndex = 46;
            // 
            // comboBoxTamaño
            // 
            this.comboBoxTamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTamaño.FormattingEnabled = true;
            this.comboBoxTamaño.Items.AddRange(new object[] {
            "Grande",
            "Mediano",
            "Pequeño"});
            this.comboBoxTamaño.Location = new System.Drawing.Point(244, 525);
            this.comboBoxTamaño.Name = "comboBoxTamaño";
            this.comboBoxTamaño.Size = new System.Drawing.Size(316, 33);
            this.comboBoxTamaño.TabIndex = 47;
            // 
            // comboBoxEstado
            // 
            this.comboBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstado.FormattingEnabled = true;
            this.comboBoxEstado.Items.AddRange(new object[] {
            "En evaluación",
            "Disponible",
            "Adoptado"});
            this.comboBoxEstado.Location = new System.Drawing.Point(244, 635);
            this.comboBoxEstado.Name = "comboBoxEstado";
            this.comboBoxEstado.Size = new System.Drawing.Size(316, 33);
            this.comboBoxEstado.TabIndex = 49;
            // 
            // labelEstadoAnimal
            // 
            this.labelEstadoAnimal.AutoSize = true;
            this.labelEstadoAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoAnimal.Location = new System.Drawing.Point(14, 635);
            this.labelEstadoAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstadoAnimal.Name = "labelEstadoAnimal";
            this.labelEstadoAnimal.Size = new System.Drawing.Size(126, 31);
            this.labelEstadoAnimal.TabIndex = 48;
            this.labelEstadoAnimal.Text = "ESTADO";
            // 
            // labelCodigo
            // 
            this.labelCodigo.AutoSize = true;
            this.labelCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigo.Location = new System.Drawing.Point(18, 827);
            this.labelCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(125, 31);
            this.labelCodigo.TabIndex = 50;
            this.labelCodigo.Text = "CÓDIGO";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(244, 827);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(316, 31);
            this.txtCodigo.TabIndex = 51;
            // 
            // btnReingreso
            // 
            this.btnReingreso.Location = new System.Drawing.Point(24, 712);
            this.btnReingreso.Margin = new System.Windows.Forms.Padding(4);
            this.btnReingreso.Name = "btnReingreso";
            this.btnReingreso.Size = new System.Drawing.Size(410, 81);
            this.btnReingreso.TabIndex = 52;
            this.btnReingreso.Text = "REINGRESO";
            this.btnReingreso.UseVisualStyleBackColor = true;
            this.btnReingreso.Click += new System.EventHandler(this.btnReingreso_Click);
            // 
            // FormRegistroAnimales_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1480, 873);
            this.Controls.Add(this.btnReingreso);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.comboBoxEstado);
            this.Controls.Add(this.labelEstadoAnimal);
            this.Controls.Add(this.comboBoxTamaño);
            this.Controls.Add(this.comboBoxSexo);
            this.Controls.Add(this.groupBoxEstadoAdopcion);
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
            this.Controls.Add(this.btnModificarAnimal);
            this.Controls.Add(this.btnAltaAnimal);
            this.Controls.Add(this.dataAnimales);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormRegistroAnimales_941lp";
            this.Text = "FormRegistroAnimales";
            this.Load += new System.EventHandler(this.FormRegistroAnimales_941lp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAnimales)).EndInit();
            this.groupBoxEstadoAdopcion.ResumeLayout(false);
            this.groupBoxEstadoAdopcion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataAnimales;
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
        private System.Windows.Forms.Button btnModificarAnimal;
        private System.Windows.Forms.Button btnAltaAnimal;
        private System.Windows.Forms.GroupBox groupBoxEstadoAdopcion;
        private System.Windows.Forms.RadioButton rbAdoptado;
        private System.Windows.Forms.RadioButton rbDisponibleAdopcion;
        private System.Windows.Forms.RadioButton rbEnEvaluacionAdopcion;
        private System.Windows.Forms.ComboBox comboBoxSexo;
        private System.Windows.Forms.ComboBox comboBoxTamaño;
        private System.Windows.Forms.ComboBox comboBoxEstado;
        private System.Windows.Forms.Label labelEstadoAnimal;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnReingreso;
    }
}