namespace GUI
{
    partial class FormGestionFichaMedica_941lp
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
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCrearFichaMedica = new System.Windows.Forms.Button();
            this.labelCastrado = new System.Windows.Forms.Label();
            this.txtDieta = new System.Windows.Forms.TextBox();
            this.labelDieta = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.labelObservaciones = new System.Windows.Forms.Label();
            this.btnModificarFichaMedica = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBoxCastrado = new System.Windows.Forms.GroupBox();
            this.rbNoCastrado = new System.Windows.Forms.RadioButton();
            this.rbSiCastrado = new System.Windows.Forms.RadioButton();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.dataFichaMedica = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dataMedicamentos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxEstadoAdopcion = new System.Windows.Forms.GroupBox();
            this.rbDisponibleAdopcion = new System.Windows.Forms.RadioButton();
            this.rbEnEvaluacionAdopcion = new System.Windows.Forms.RadioButton();
            this.labelAnimales = new System.Windows.Forms.Label();
            this.labelMedicamentos = new System.Windows.Forms.Label();
            this.labelFichaMedica = new System.Windows.Forms.Label();
            this.btnBitacoraFichaMedica = new System.Windows.Forms.Button();
            this.labelObligatorio = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOpcional = new System.Windows.Forms.Label();
            this.labelOpcional1 = new System.Windows.Forms.Label();
            this.checkBoxMedicamentos = new System.Windows.Forms.CheckBox();
            this.checkBoxBuscarFichaSegunAnimal = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataAnimales)).BeginInit();
            this.groupBoxCastrado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFichaMedica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMedicamentos)).BeginInit();
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
            this.Column7,
            this.Column8});
            this.dataAnimales.Location = new System.Drawing.Point(16, 90);
            this.dataAnimales.Margin = new System.Windows.Forms.Padding(4);
            this.dataAnimales.Name = "dataAnimales";
            this.dataAnimales.ReadOnly = true;
            this.dataAnimales.RowHeadersWidth = 82;
            this.dataAnimales.RowTemplate.Height = 33;
            this.dataAnimales.Size = new System.Drawing.Size(1114, 329);
            this.dataAnimales.TabIndex = 1;
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
            // Column8
            // 
            this.Column8.HeaderText = "Vivo";
            this.Column8.MinimumWidth = 10;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 200;
            // 
            // btnCrearFichaMedica
            // 
            this.btnCrearFichaMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFichaMedica.Location = new System.Drawing.Point(1156, 496);
            this.btnCrearFichaMedica.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrearFichaMedica.Name = "btnCrearFichaMedica";
            this.btnCrearFichaMedica.Size = new System.Drawing.Size(436, 67);
            this.btnCrearFichaMedica.TabIndex = 3;
            this.btnCrearFichaMedica.Text = "Generar ficha médica";
            this.btnCrearFichaMedica.UseVisualStyleBackColor = true;
            this.btnCrearFichaMedica.Click += new System.EventHandler(this.btnCrearFichaMedica_Click);
            // 
            // labelCastrado
            // 
            this.labelCastrado.AutoSize = true;
            this.labelCastrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCastrado.Location = new System.Drawing.Point(1652, 496);
            this.labelCastrado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCastrado.Name = "labelCastrado";
            this.labelCastrado.Size = new System.Drawing.Size(65, 17);
            this.labelCastrado.TabIndex = 4;
            this.labelCastrado.Text = "Castrado";
            // 
            // txtDieta
            // 
            this.txtDieta.Location = new System.Drawing.Point(1724, 615);
            this.txtDieta.Margin = new System.Windows.Forms.Padding(4);
            this.txtDieta.Name = "txtDieta";
            this.txtDieta.Size = new System.Drawing.Size(376, 31);
            this.txtDieta.TabIndex = 0;
            // 
            // labelDieta
            // 
            this.labelDieta.AutoSize = true;
            this.labelDieta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDieta.Location = new System.Drawing.Point(1662, 573);
            this.labelDieta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDieta.Name = "labelDieta";
            this.labelDieta.Size = new System.Drawing.Size(41, 17);
            this.labelDieta.TabIndex = 6;
            this.labelDieta.Text = "Dieta";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(1724, 708);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(376, 31);
            this.txtObservaciones.TabIndex = 1;
            // 
            // labelObservaciones
            // 
            this.labelObservaciones.AutoSize = true;
            this.labelObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObservaciones.Location = new System.Drawing.Point(1652, 656);
            this.labelObservaciones.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelObservaciones.Name = "labelObservaciones";
            this.labelObservaciones.Size = new System.Drawing.Size(103, 17);
            this.labelObservaciones.TabIndex = 10;
            this.labelObservaciones.Text = "Observaciones";
            // 
            // btnModificarFichaMedica
            // 
            this.btnModificarFichaMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarFichaMedica.Location = new System.Drawing.Point(1156, 573);
            this.btnModificarFichaMedica.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificarFichaMedica.Name = "btnModificarFichaMedica";
            this.btnModificarFichaMedica.Size = new System.Drawing.Size(436, 73);
            this.btnModificarFichaMedica.TabIndex = 16;
            this.btnModificarFichaMedica.Text = "Modificar ficha médica";
            this.btnModificarFichaMedica.UseVisualStyleBackColor = true;
            this.btnModificarFichaMedica.Click += new System.EventHandler(this.btnModificarFichaMedica_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1156, 833);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(436, 58);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBoxCastrado
            // 
            this.groupBoxCastrado.Controls.Add(this.rbNoCastrado);
            this.groupBoxCastrado.Controls.Add(this.rbSiCastrado);
            this.groupBoxCastrado.Location = new System.Drawing.Point(1804, 500);
            this.groupBoxCastrado.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxCastrado.Name = "groupBoxCastrado";
            this.groupBoxCastrado.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxCastrado.Size = new System.Drawing.Size(294, 65);
            this.groupBoxCastrado.TabIndex = 18;
            this.groupBoxCastrado.TabStop = false;
            // 
            // rbNoCastrado
            // 
            this.rbNoCastrado.AutoSize = true;
            this.rbNoCastrado.Location = new System.Drawing.Point(200, 27);
            this.rbNoCastrado.Margin = new System.Windows.Forms.Padding(6);
            this.rbNoCastrado.Name = "rbNoCastrado";
            this.rbNoCastrado.Size = new System.Drawing.Size(61, 29);
            this.rbNoCastrado.TabIndex = 1;
            this.rbNoCastrado.TabStop = true;
            this.rbNoCastrado.Text = "NO";
            this.rbNoCastrado.UseVisualStyleBackColor = true;
            // 
            // rbSiCastrado
            // 
            this.rbSiCastrado.AutoSize = true;
            this.rbSiCastrado.Location = new System.Drawing.Point(58, 27);
            this.rbSiCastrado.Margin = new System.Windows.Forms.Padding(6);
            this.rbSiCastrado.Name = "rbSiCastrado";
            this.rbSiCastrado.Size = new System.Drawing.Size(49, 29);
            this.rbSiCastrado.TabIndex = 0;
            this.rbSiCastrado.TabStop = true;
            this.rbSiCastrado.Text = "SI";
            this.rbSiCastrado.UseVisualStyleBackColor = true;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(1156, 656);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(436, 73);
            this.btnAplicar.TabIndex = 19;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // dataFichaMedica
            // 
            this.dataFichaMedica.AllowUserToAddRows = false;
            this.dataFichaMedica.AllowUserToDeleteRows = false;
            this.dataFichaMedica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFichaMedica.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataFichaMedica.Location = new System.Drawing.Point(12, 496);
            this.dataFichaMedica.Margin = new System.Windows.Forms.Padding(4);
            this.dataFichaMedica.Name = "dataFichaMedica";
            this.dataFichaMedica.ReadOnly = true;
            this.dataFichaMedica.RowHeadersWidth = 82;
            this.dataFichaMedica.RowTemplate.Height = 33;
            this.dataFichaMedica.Size = new System.Drawing.Size(1118, 392);
            this.dataFichaMedica.TabIndex = 20;
            this.dataFichaMedica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataFichaMedica_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Código animal";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Castrado";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Dieta";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Medicamento";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Observación";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(1156, 737);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(436, 73);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dataMedicamentos
            // 
            this.dataMedicamentos.AllowUserToAddRows = false;
            this.dataMedicamentos.AllowUserToDeleteRows = false;
            this.dataMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMedicamentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn13});
            this.dataMedicamentos.Location = new System.Drawing.Point(1156, 90);
            this.dataMedicamentos.Margin = new System.Windows.Forms.Padding(4);
            this.dataMedicamentos.Name = "dataMedicamentos";
            this.dataMedicamentos.ReadOnly = true;
            this.dataMedicamentos.RowHeadersWidth = 82;
            this.dataMedicamentos.RowTemplate.Height = 33;
            this.dataMedicamentos.Size = new System.Drawing.Size(1292, 329);
            this.dataMedicamentos.TabIndex = 59;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Número";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 200;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Nombre comercial";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Nombre genérico";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 200;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Forma";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 200;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "Vencimiento";
            this.dataGridViewTextBoxColumn13.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 200;
            // 
            // groupBoxEstadoAdopcion
            // 
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbDisponibleAdopcion);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbEnEvaluacionAdopcion);
            this.groupBoxEstadoAdopcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEstadoAdopcion.Location = new System.Drawing.Point(1628, 765);
            this.groupBoxEstadoAdopcion.Margin = new System.Windows.Forms.Padding(6);
            this.groupBoxEstadoAdopcion.Name = "groupBoxEstadoAdopcion";
            this.groupBoxEstadoAdopcion.Padding = new System.Windows.Forms.Padding(6);
            this.groupBoxEstadoAdopcion.Size = new System.Drawing.Size(528, 137);
            this.groupBoxEstadoAdopcion.TabIndex = 60;
            this.groupBoxEstadoAdopcion.TabStop = false;
            this.groupBoxEstadoAdopcion.Text = "Estado animal";
            // 
            // rbDisponibleAdopcion
            // 
            this.rbDisponibleAdopcion.AutoSize = true;
            this.rbDisponibleAdopcion.Location = new System.Drawing.Point(320, 67);
            this.rbDisponibleAdopcion.Margin = new System.Windows.Forms.Padding(6);
            this.rbDisponibleAdopcion.Name = "rbDisponibleAdopcion";
            this.rbDisponibleAdopcion.Size = new System.Drawing.Size(101, 24);
            this.rbDisponibleAdopcion.TabIndex = 1;
            this.rbDisponibleAdopcion.Text = "Disponible";
            this.rbDisponibleAdopcion.UseVisualStyleBackColor = true;
            // 
            // rbEnEvaluacionAdopcion
            // 
            this.rbEnEvaluacionAdopcion.AutoSize = true;
            this.rbEnEvaluacionAdopcion.Location = new System.Drawing.Point(40, 67);
            this.rbEnEvaluacionAdopcion.Margin = new System.Windows.Forms.Padding(6);
            this.rbEnEvaluacionAdopcion.Name = "rbEnEvaluacionAdopcion";
            this.rbEnEvaluacionAdopcion.Size = new System.Drawing.Size(126, 24);
            this.rbEnEvaluacionAdopcion.TabIndex = 0;
            this.rbEnEvaluacionAdopcion.Text = "En evaluación";
            this.rbEnEvaluacionAdopcion.UseVisualStyleBackColor = true;
            // 
            // labelAnimales
            // 
            this.labelAnimales.AutoSize = true;
            this.labelAnimales.Location = new System.Drawing.Point(12, 37);
            this.labelAnimales.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAnimales.Name = "labelAnimales";
            this.labelAnimales.Size = new System.Drawing.Size(124, 25);
            this.labelAnimales.TabIndex = 61;
            this.labelAnimales.Text = "ANIMALES:";
            // 
            // labelMedicamentos
            // 
            this.labelMedicamentos.AutoSize = true;
            this.labelMedicamentos.Location = new System.Drawing.Point(1152, 37);
            this.labelMedicamentos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMedicamentos.Name = "labelMedicamentos";
            this.labelMedicamentos.Size = new System.Drawing.Size(189, 25);
            this.labelMedicamentos.TabIndex = 62;
            this.labelMedicamentos.Text = "MEDICAMENTOS:";
            // 
            // labelFichaMedica
            // 
            this.labelFichaMedica.AutoSize = true;
            this.labelFichaMedica.Location = new System.Drawing.Point(12, 442);
            this.labelFichaMedica.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFichaMedica.Name = "labelFichaMedica";
            this.labelFichaMedica.Size = new System.Drawing.Size(195, 25);
            this.labelFichaMedica.TabIndex = 63;
            this.labelFichaMedica.Text = "FICHAS MÉDICAS:";
            // 
            // btnBitacoraFichaMedica
            // 
            this.btnBitacoraFichaMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBitacoraFichaMedica.Location = new System.Drawing.Point(12, 908);
            this.btnBitacoraFichaMedica.Margin = new System.Windows.Forms.Padding(4);
            this.btnBitacoraFichaMedica.Name = "btnBitacoraFichaMedica";
            this.btnBitacoraFichaMedica.Size = new System.Drawing.Size(436, 67);
            this.btnBitacoraFichaMedica.TabIndex = 64;
            this.btnBitacoraFichaMedica.Text = "Ver bitacora";
            this.btnBitacoraFichaMedica.UseVisualStyleBackColor = true;
            this.btnBitacoraFichaMedica.Click += new System.EventHandler(this.btnBitacoraFichaMedica_Click);
            // 
            // labelObligatorio
            // 
            this.labelObligatorio.AutoSize = true;
            this.labelObligatorio.Location = new System.Drawing.Point(2146, 521);
            this.labelObligatorio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelObligatorio.Name = "labelObligatorio";
            this.labelObligatorio.Size = new System.Drawing.Size(126, 25);
            this.labelObligatorio.TabIndex = 65;
            this.labelObligatorio.Text = "(obligatorio)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2188, 833);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "(obligatorio)";
            // 
            // labelOpcional
            // 
            this.labelOpcional.AutoSize = true;
            this.labelOpcional.Location = new System.Drawing.Point(2146, 615);
            this.labelOpcional.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOpcional.Name = "labelOpcional";
            this.labelOpcional.Size = new System.Drawing.Size(107, 25);
            this.labelOpcional.TabIndex = 67;
            this.labelOpcional.Text = "(opcional)";
            // 
            // labelOpcional1
            // 
            this.labelOpcional1.AutoSize = true;
            this.labelOpcional1.Location = new System.Drawing.Point(2146, 708);
            this.labelOpcional1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOpcional1.Name = "labelOpcional1";
            this.labelOpcional1.Size = new System.Drawing.Size(107, 25);
            this.labelOpcional1.TabIndex = 68;
            this.labelOpcional1.Text = "(opcional)";
            // 
            // checkBoxMedicamentos
            // 
            this.checkBoxMedicamentos.AutoSize = true;
            this.checkBoxMedicamentos.Location = new System.Drawing.Point(1156, 438);
            this.checkBoxMedicamentos.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMedicamentos.Name = "checkBoxMedicamentos";
            this.checkBoxMedicamentos.Size = new System.Drawing.Size(207, 29);
            this.checkBoxMedicamentos.TabIndex = 69;
            this.checkBoxMedicamentos.Text = "Sin medicamentos";
            this.checkBoxMedicamentos.UseVisualStyleBackColor = true;
            // 
            // checkBoxBuscarFichaSegunAnimal
            // 
            this.checkBoxBuscarFichaSegunAnimal.AutoSize = true;
            this.checkBoxBuscarFichaSegunAnimal.Location = new System.Drawing.Point(846, 442);
            this.checkBoxBuscarFichaSegunAnimal.Name = "checkBoxBuscarFichaSegunAnimal";
            this.checkBoxBuscarFichaSegunAnimal.Size = new System.Drawing.Size(284, 29);
            this.checkBoxBuscarFichaSegunAnimal.TabIndex = 71;
            this.checkBoxBuscarFichaSegunAnimal.Text = "Buscar ficha según animal";
            this.checkBoxBuscarFichaSegunAnimal.UseVisualStyleBackColor = true;
            this.checkBoxBuscarFichaSegunAnimal.CheckedChanged += new System.EventHandler(this.checkBoxBuscarFichaSegunAnimal_CheckedChanged);
            // 
            // FormGestionFichaMedica_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(2456, 954);
            this.Controls.Add(this.checkBoxBuscarFichaSegunAnimal);
            this.Controls.Add(this.checkBoxMedicamentos);
            this.Controls.Add(this.labelOpcional1);
            this.Controls.Add(this.labelOpcional);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelObligatorio);
            this.Controls.Add(this.btnBitacoraFichaMedica);
            this.Controls.Add(this.labelFichaMedica);
            this.Controls.Add(this.labelMedicamentos);
            this.Controls.Add(this.labelAnimales);
            this.Controls.Add(this.groupBoxEstadoAdopcion);
            this.Controls.Add(this.dataMedicamentos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dataFichaMedica);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.groupBoxCastrado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificarFichaMedica);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.labelObservaciones);
            this.Controls.Add(this.txtDieta);
            this.Controls.Add(this.labelDieta);
            this.Controls.Add(this.labelCastrado);
            this.Controls.Add(this.btnCrearFichaMedica);
            this.Controls.Add(this.dataAnimales);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGestionFichaMedica_941lp";
            this.Text = "FormFichaMedica_941lp";
            this.Load += new System.EventHandler(this.FormGestionFichaMedica_941lp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataAnimales)).EndInit();
            this.groupBoxCastrado.ResumeLayout(false);
            this.groupBoxCastrado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFichaMedica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataMedicamentos)).EndInit();
            this.groupBoxEstadoAdopcion.ResumeLayout(false);
            this.groupBoxEstadoAdopcion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataAnimales;
        private System.Windows.Forms.Button btnCrearFichaMedica;
        private System.Windows.Forms.Label labelCastrado;
        private System.Windows.Forms.TextBox txtDieta;
        private System.Windows.Forms.Label labelDieta;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label labelObservaciones;
        private System.Windows.Forms.Button btnModificarFichaMedica;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBoxCastrado;
        private System.Windows.Forms.RadioButton rbNoCastrado;
        private System.Windows.Forms.RadioButton rbSiCastrado;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.DataGridView dataFichaMedica;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridView dataMedicamentos;
        private System.Windows.Forms.GroupBox groupBoxEstadoAdopcion;
        private System.Windows.Forms.RadioButton rbDisponibleAdopcion;
        private System.Windows.Forms.RadioButton rbEnEvaluacionAdopcion;
        private System.Windows.Forms.Label labelAnimales;
        private System.Windows.Forms.Label labelMedicamentos;
        private System.Windows.Forms.Label labelFichaMedica;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnBitacoraFichaMedica;
        private System.Windows.Forms.Label labelObligatorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelOpcional;
        private System.Windows.Forms.Label labelOpcional1;
        private System.Windows.Forms.CheckBox checkBoxMedicamentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.CheckBox checkBoxBuscarFichaSegunAnimal;
    }
}