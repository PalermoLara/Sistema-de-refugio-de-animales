namespace GUI
{
    partial class formBitacoraEventos_941lp
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
            this.dataEventos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.labelLogIn = new System.Windows.Forms.Label();
            this.comboBoxLogin = new System.Windows.Forms.ComboBox();
            this.comboBoxEvento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxModulo = new System.Windows.Forms.ComboBox();
            this.labelModulo = new System.Windows.Forms.Label();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.comboBoxCriticidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataEventos
            // 
            this.dataEventos.AllowUserToAddRows = false;
            this.dataEventos.AllowUserToDeleteRows = false;
            this.dataEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEventos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataEventos.Location = new System.Drawing.Point(84, 25);
            this.dataEventos.Name = "dataEventos";
            this.dataEventos.ReadOnly = true;
            this.dataEventos.RowHeadersWidth = 82;
            this.dataEventos.RowTemplate.Height = 33;
            this.dataEventos.Size = new System.Drawing.Size(1605, 575);
            this.dataEventos.TabIndex = 0;
            this.dataEventos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEventos_CellClick);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 10;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "LogIn";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Fecha";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Hora";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Modulo";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Evento";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Criticidad";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(258, 652);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(93, 25);
            this.labelNombre.TabIndex = 1;
            this.labelNombre.Text = "Nombre:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(809, 652);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(95, 25);
            this.labelApellido.TabIndex = 2;
            this.labelApellido.Text = "Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(383, 649);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(401, 31);
            this.txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(910, 646);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(401, 31);
            this.txtApellido.TabIndex = 4;
            // 
            // labelLogIn
            // 
            this.labelLogIn.AutoSize = true;
            this.labelLogIn.Location = new System.Drawing.Point(79, 734);
            this.labelLogIn.Name = "labelLogIn";
            this.labelLogIn.Size = new System.Drawing.Size(65, 25);
            this.labelLogIn.TabIndex = 5;
            this.labelLogIn.Text = "LogIn";
            // 
            // comboBoxLogin
            // 
            this.comboBoxLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLogin.FormattingEnabled = true;
            this.comboBoxLogin.Location = new System.Drawing.Point(168, 726);
            this.comboBoxLogin.Name = "comboBoxLogin";
            this.comboBoxLogin.Size = new System.Drawing.Size(401, 33);
            this.comboBoxLogin.TabIndex = 6;
            // 
            // comboBoxEvento
            // 
            this.comboBoxEvento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEvento.FormattingEnabled = true;
            this.comboBoxEvento.Location = new System.Drawing.Point(739, 810);
            this.comboBoxEvento.Name = "comboBoxEvento";
            this.comboBoxEvento.Size = new System.Drawing.Size(401, 33);
            this.comboBoxEvento.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(605, 818);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Evento";
            // 
            // comboBoxModulo
            // 
            this.comboBoxModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModulo.FormattingEnabled = true;
            this.comboBoxModulo.Location = new System.Drawing.Point(168, 810);
            this.comboBoxModulo.Name = "comboBoxModulo";
            this.comboBoxModulo.Size = new System.Drawing.Size(401, 33);
            this.comboBoxModulo.TabIndex = 10;
            this.comboBoxModulo.SelectedIndexChanged += new System.EventHandler(this.comboBoxModulo_SelectedIndexChanged);
            // 
            // labelModulo
            // 
            this.labelModulo.AutoSize = true;
            this.labelModulo.Location = new System.Drawing.Point(79, 818);
            this.labelModulo.Name = "labelModulo";
            this.labelModulo.Size = new System.Drawing.Size(83, 25);
            this.labelModulo.TabIndex = 9;
            this.labelModulo.Text = "Modulo";
            // 
            // labelFechaFin
            // 
            this.labelFechaFin.AutoSize = true;
            this.labelFechaFin.Location = new System.Drawing.Point(1178, 734);
            this.labelFechaFin.Name = "labelFechaFin";
            this.labelFechaFin.Size = new System.Drawing.Size(101, 25);
            this.labelFechaFin.TabIndex = 11;
            this.labelFechaFin.Text = "Fecha fin";
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Location = new System.Drawing.Point(605, 734);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(128, 25);
            this.labelFechaInicio.TabIndex = 13;
            this.labelFechaInicio.Text = "Fecha inicio";
            // 
            // comboBoxCriticidad
            // 
            this.comboBoxCriticidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCriticidad.FormattingEnabled = true;
            this.comboBoxCriticidad.Location = new System.Drawing.Point(1288, 810);
            this.comboBoxCriticidad.Name = "comboBoxCriticidad";
            this.comboBoxCriticidad.Size = new System.Drawing.Size(401, 33);
            this.comboBoxCriticidad.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1178, 818);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Criticidad";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(86, 899);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(276, 91);
            this.btnLimpiar.TabIndex = 17;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(650, 899);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(276, 91);
            this.btnSalir.TabIndex = 18;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(368, 899);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(276, 91);
            this.btnAplicar.TabIndex = 19;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Location = new System.Drawing.Point(739, 734);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(401, 31);
            this.dateTimePickerInicio.TabIndex = 21;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(1285, 729);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(401, 31);
            this.dateTimePickerFin.TabIndex = 22;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(932, 899);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(276, 91);
            this.btnImprimir.TabIndex = 24;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // formBitacoraEventos_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1865, 1061);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dateTimePickerFin);
            this.Controls.Add(this.dateTimePickerInicio);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.comboBoxCriticidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelFechaInicio);
            this.Controls.Add(this.labelFechaFin);
            this.Controls.Add(this.comboBoxModulo);
            this.Controls.Add(this.labelModulo);
            this.Controls.Add(this.comboBoxEvento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLogin);
            this.Controls.Add(this.labelLogIn);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.dataEventos);
            this.Name = "formBitacoraEventos_941lp";
            this.Text = "formBitacoraEventos_941lp";
            this.Load += new System.EventHandler(this.formBitacoraEventos_941lp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataEventos;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label labelLogIn;
        private System.Windows.Forms.ComboBox comboBoxLogin;
        private System.Windows.Forms.ComboBox comboBoxEvento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxModulo;
        private System.Windows.Forms.Label labelModulo;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.Label labelFechaInicio;
        private System.Windows.Forms.ComboBox comboBoxCriticidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}