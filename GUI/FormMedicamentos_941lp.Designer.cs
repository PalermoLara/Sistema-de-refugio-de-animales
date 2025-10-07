namespace GUI
{
    partial class FormMedicamentos_941lp
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
            this.btnBaja = new System.Windows.Forms.Button();
            this.labelEstadoAnimal = new System.Windows.Forms.Label();
            this.comboBoxForma = new System.Windows.Forms.ComboBox();
            this.groupBoxOrdenamiento = new System.Windows.Forms.GroupBox();
            this.rbDescendente = new System.Windows.Forms.RadioButton();
            this.rbAscendente = new System.Windows.Forms.RadioButton();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.labelNumero = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.txtNombreGenerico = new System.Windows.Forms.TextBox();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.btnRazaRegistroAnimal = new System.Windows.Forms.Label();
            this.labelForma = new System.Windows.Forms.Label();
            this.labelNombreRegistroAnimal = new System.Windows.Forms.Label();
            this.btnModificarMedicamento = new System.Windows.Forms.Button();
            this.btnAltaMedicamento = new System.Windows.Forms.Button();
            this.dataMedicamentos = new System.Windows.Forms.DataGridView();
            this.dateTimePickerVencimiento = new System.Windows.Forms.DateTimePicker();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxOrdenamiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMedicamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(1118, 573);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(410, 81);
            this.btnBaja.TabIndex = 78;
            this.btnBaja.Text = "BAJA";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // labelEstadoAnimal
            // 
            this.labelEstadoAnimal.AutoSize = true;
            this.labelEstadoAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstadoAnimal.Location = new System.Drawing.Point(68, 671);
            this.labelEstadoAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEstadoAnimal.Name = "labelEstadoAnimal";
            this.labelEstadoAnimal.Size = new System.Drawing.Size(101, 17);
            this.labelEstadoAnimal.TabIndex = 73;
            this.labelEstadoAnimal.Text = "VENCIMIENTO";
            // 
            // comboBoxForma
            // 
            this.comboBoxForma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxForma.FormattingEnabled = true;
            this.comboBoxForma.Items.AddRange(new object[] {
            "Oral ",
            "Inyectable"});
            this.comboBoxForma.Location = new System.Drawing.Point(420, 556);
            this.comboBoxForma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxForma.Name = "comboBoxForma";
            this.comboBoxForma.Size = new System.Drawing.Size(316, 33);
            this.comboBoxForma.TabIndex = 72;
            // 
            // groupBoxOrdenamiento
            // 
            this.groupBoxOrdenamiento.Controls.Add(this.rbDescendente);
            this.groupBoxOrdenamiento.Controls.Add(this.rbAscendente);
            this.groupBoxOrdenamiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOrdenamiento.Location = new System.Drawing.Point(1564, 33);
            this.groupBoxOrdenamiento.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBoxOrdenamiento.Name = "groupBoxOrdenamiento";
            this.groupBoxOrdenamiento.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBoxOrdenamiento.Size = new System.Drawing.Size(528, 148);
            this.groupBoxOrdenamiento.TabIndex = 70;
            this.groupBoxOrdenamiento.TabStop = false;
            this.groupBoxOrdenamiento.Text = "Nombre generico:";
            // 
            // rbDescendente
            // 
            this.rbDescendente.AutoSize = true;
            this.rbDescendente.Location = new System.Drawing.Point(80, 102);
            this.rbDescendente.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbDescendente.Name = "rbDescendente";
            this.rbDescendente.Size = new System.Drawing.Size(168, 24);
            this.rbDescendente.TabIndex = 1;
            this.rbDescendente.Text = "Orden descendente";
            this.rbDescendente.UseVisualStyleBackColor = true;
            this.rbDescendente.CheckedChanged += new System.EventHandler(this.rbDescendente_CheckedChanged);
            // 
            // rbAscendente
            // 
            this.rbAscendente.AutoSize = true;
            this.rbAscendente.Checked = true;
            this.rbAscendente.Location = new System.Drawing.Point(80, 48);
            this.rbAscendente.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbAscendente.Name = "rbAscendente";
            this.rbAscendente.Size = new System.Drawing.Size(159, 24);
            this.rbAscendente.TabIndex = 0;
            this.rbAscendente.TabStop = true;
            this.rbAscendente.Text = "Orden ascendente";
            this.rbAscendente.UseVisualStyleBackColor = true;
            this.rbAscendente.CheckedChanged += new System.EventHandler(this.rbAscendente_CheckedChanged);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(772, 394);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(258, 81);
            this.btnAplicar.TabIndex = 61;
            this.btnAplicar.Text = "APLICAR";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(772, 483);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(258, 81);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(420, 400);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(316, 31);
            this.txtNumero.TabIndex = 0;
            // 
            // labelNumero
            // 
            this.labelNumero.AutoSize = true;
            this.labelNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumero.Location = new System.Drawing.Point(66, 406);
            this.labelNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumero.Name = "labelNumero";
            this.labelNumero.Size = new System.Drawing.Size(69, 17);
            this.labelNumero.TabIndex = 69;
            this.labelNumero.Text = "NÚMERO";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(772, 573);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(258, 81);
            this.btnSalir.TabIndex = 67;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // txtNombreGenerico
            // 
            this.txtNombreGenerico.Location = new System.Drawing.Point(420, 504);
            this.txtNombreGenerico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreGenerico.Name = "txtNombreGenerico";
            this.txtNombreGenerico.Size = new System.Drawing.Size(316, 31);
            this.txtNombreGenerico.TabIndex = 3;
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(420, 450);
            this.txtNombreComercial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(316, 31);
            this.txtNombreComercial.TabIndex = 1;
            // 
            // btnRazaRegistroAnimal
            // 
            this.btnRazaRegistroAnimal.AutoSize = true;
            this.btnRazaRegistroAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRazaRegistroAnimal.Location = new System.Drawing.Point(68, 456);
            this.btnRazaRegistroAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnRazaRegistroAnimal.Name = "btnRazaRegistroAnimal";
            this.btnRazaRegistroAnimal.Size = new System.Drawing.Size(151, 17);
            this.btnRazaRegistroAnimal.TabIndex = 66;
            this.btnRazaRegistroAnimal.Text = "NOMBRE COMERICAL";
            // 
            // labelForma
            // 
            this.labelForma.AutoSize = true;
            this.labelForma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForma.Location = new System.Drawing.Point(66, 563);
            this.labelForma.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelForma.Name = "labelForma";
            this.labelForma.Size = new System.Drawing.Size(57, 17);
            this.labelForma.TabIndex = 63;
            this.labelForma.Text = "FORMA";
            // 
            // labelNombreRegistroAnimal
            // 
            this.labelNombreRegistroAnimal.AutoSize = true;
            this.labelNombreRegistroAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreRegistroAnimal.Location = new System.Drawing.Point(68, 508);
            this.labelNombreRegistroAnimal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNombreRegistroAnimal.Name = "labelNombreRegistroAnimal";
            this.labelNombreRegistroAnimal.Size = new System.Drawing.Size(144, 17);
            this.labelNombreRegistroAnimal.TabIndex = 60;
            this.labelNombreRegistroAnimal.Text = "NOMBRE GENERICO";
            // 
            // btnModificarMedicamento
            // 
            this.btnModificarMedicamento.Location = new System.Drawing.Point(1118, 481);
            this.btnModificarMedicamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarMedicamento.Name = "btnModificarMedicamento";
            this.btnModificarMedicamento.Size = new System.Drawing.Size(410, 81);
            this.btnModificarMedicamento.TabIndex = 65;
            this.btnModificarMedicamento.Text = "MODIFICAR";
            this.btnModificarMedicamento.UseVisualStyleBackColor = true;
            this.btnModificarMedicamento.Click += new System.EventHandler(this.btnModificarMedicamento_Click);
            // 
            // btnAltaMedicamento
            // 
            this.btnAltaMedicamento.Location = new System.Drawing.Point(1118, 394);
            this.btnAltaMedicamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAltaMedicamento.Name = "btnAltaMedicamento";
            this.btnAltaMedicamento.Size = new System.Drawing.Size(410, 81);
            this.btnAltaMedicamento.TabIndex = 64;
            this.btnAltaMedicamento.Text = "ALTA";
            this.btnAltaMedicamento.UseVisualStyleBackColor = true;
            this.btnAltaMedicamento.Click += new System.EventHandler(this.btnAltaMedicamento_Click);
            // 
            // dataMedicamentos
            // 
            this.dataMedicamentos.AllowUserToAddRows = false;
            this.dataMedicamentos.AllowUserToDeleteRows = false;
            this.dataMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMedicamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5});
            this.dataMedicamentos.Location = new System.Drawing.Point(72, 33);
            this.dataMedicamentos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataMedicamentos.Name = "dataMedicamentos";
            this.dataMedicamentos.ReadOnly = true;
            this.dataMedicamentos.RowHeadersWidth = 82;
            this.dataMedicamentos.RowTemplate.Height = 33;
            this.dataMedicamentos.Size = new System.Drawing.Size(1456, 329);
            this.dataMedicamentos.TabIndex = 58;
            this.dataMedicamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataMedicamentos_CellClick);
            // 
            // dateTimePickerVencimiento
            // 
            this.dateTimePickerVencimiento.Location = new System.Drawing.Point(420, 665);
            this.dateTimePickerVencimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePickerVencimiento.Name = "dateTimePickerVencimiento";
            this.dateTimePickerVencimiento.Size = new System.Drawing.Size(610, 31);
            this.dateTimePickerVencimiento.TabIndex = 79;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Número";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre comercial";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Nombre genérico";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Forma";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Vencimiento";
            this.Column6.MinimumWidth = 10;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Activo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // FormMedicamentos_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(2164, 923);
            this.Controls.Add(this.dateTimePickerVencimiento);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.labelEstadoAnimal);
            this.Controls.Add(this.comboBoxForma);
            this.Controls.Add(this.groupBoxOrdenamiento);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.labelNumero);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtNombreGenerico);
            this.Controls.Add(this.txtNombreComercial);
            this.Controls.Add(this.btnRazaRegistroAnimal);
            this.Controls.Add(this.labelForma);
            this.Controls.Add(this.labelNombreRegistroAnimal);
            this.Controls.Add(this.btnModificarMedicamento);
            this.Controls.Add(this.btnAltaMedicamento);
            this.Controls.Add(this.dataMedicamentos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormMedicamentos_941lp";
            this.Text = "FormMedicamentos";
            this.Load += new System.EventHandler(this.FormMedicamentos_941lp_Load);
            this.groupBoxOrdenamiento.ResumeLayout(false);
            this.groupBoxOrdenamiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMedicamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Label labelEstadoAnimal;
        private System.Windows.Forms.ComboBox comboBoxForma;
        private System.Windows.Forms.GroupBox groupBoxOrdenamiento;
        private System.Windows.Forms.RadioButton rbDescendente;
        private System.Windows.Forms.RadioButton rbAscendente;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label labelNumero;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TextBox txtNombreGenerico;
        private System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.Label btnRazaRegistroAnimal;
        private System.Windows.Forms.Label labelForma;
        private System.Windows.Forms.Label labelNombreRegistroAnimal;
        private System.Windows.Forms.Button btnModificarMedicamento;
        private System.Windows.Forms.Button btnAltaMedicamento;
        private System.Windows.Forms.DataGridView dataMedicamentos;
        private System.Windows.Forms.DateTimePicker dateTimePickerVencimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}