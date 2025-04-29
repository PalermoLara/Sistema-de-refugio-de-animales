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
            this.dtAnimales = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listBoxFichaMedica = new System.Windows.Forms.ListBox();
            this.btnCrearFichaMedica = new System.Windows.Forms.Button();
            this.labelCastrado = new System.Windows.Forms.Label();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.labelDieta = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelMedicamento = new System.Windows.Forms.Label();
            this.txtTamaño = new System.Windows.Forms.TextBox();
            this.labelObservaciones = new System.Windows.Forms.Label();
            this.checkBoxCastradoSi = new System.Windows.Forms.CheckBox();
            this.checkBoxCastradoNo = new System.Windows.Forms.CheckBox();
            this.btnModificarFichaMedica = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).BeginInit();
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
            this.dtAnimales.Location = new System.Drawing.Point(12, 12);
            this.dtAnimales.Name = "dtAnimales";
            this.dtAnimales.ReadOnly = true;
            this.dtAnimales.RowHeadersWidth = 82;
            this.dtAnimales.RowTemplate.Height = 33;
            this.dtAnimales.Size = new System.Drawing.Size(1114, 329);
            this.dtAnimales.TabIndex = 1;
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
            // listBoxFichaMedica
            // 
            this.listBoxFichaMedica.FormattingEnabled = true;
            this.listBoxFichaMedica.ItemHeight = 25;
            this.listBoxFichaMedica.Location = new System.Drawing.Point(12, 347);
            this.listBoxFichaMedica.Name = "listBoxFichaMedica";
            this.listBoxFichaMedica.Size = new System.Drawing.Size(1114, 404);
            this.listBoxFichaMedica.TabIndex = 2;
            // 
            // btnCrearFichaMedica
            // 
            this.btnCrearFichaMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFichaMedica.Location = new System.Drawing.Point(1154, 12);
            this.btnCrearFichaMedica.Name = "btnCrearFichaMedica";
            this.btnCrearFichaMedica.Size = new System.Drawing.Size(437, 82);
            this.btnCrearFichaMedica.TabIndex = 3;
            this.btnCrearFichaMedica.Text = "Crear ficha médica";
            this.btnCrearFichaMedica.UseVisualStyleBackColor = true;
            // 
            // labelCastrado
            // 
            this.labelCastrado.AutoSize = true;
            this.labelCastrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCastrado.Location = new System.Drawing.Point(1148, 143);
            this.labelCastrado.Name = "labelCastrado";
            this.labelCastrado.Size = new System.Drawing.Size(125, 31);
            this.labelCastrado.TabIndex = 4;
            this.labelCastrado.Text = "Castrado";
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(1215, 274);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(376, 31);
            this.txtRaza.TabIndex = 7;
            // 
            // labelDieta
            // 
            this.labelDieta.AutoSize = true;
            this.labelDieta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDieta.Location = new System.Drawing.Point(1149, 228);
            this.labelDieta.Name = "labelDieta";
            this.labelDieta.Size = new System.Drawing.Size(78, 31);
            this.labelDieta.TabIndex = 6;
            this.labelDieta.Text = "Dieta";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(1214, 382);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(376, 31);
            this.txtNombre.TabIndex = 9;
            // 
            // labelMedicamento
            // 
            this.labelMedicamento.AutoSize = true;
            this.labelMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedicamento.Location = new System.Drawing.Point(1148, 336);
            this.labelMedicamento.Name = "labelMedicamento";
            this.labelMedicamento.Size = new System.Drawing.Size(190, 31);
            this.labelMedicamento.TabIndex = 8;
            this.labelMedicamento.Text = "Medicamentos";
            // 
            // txtTamaño
            // 
            this.txtTamaño.Location = new System.Drawing.Point(1214, 500);
            this.txtTamaño.Name = "txtTamaño";
            this.txtTamaño.Size = new System.Drawing.Size(376, 31);
            this.txtTamaño.TabIndex = 11;
            // 
            // labelObservaciones
            // 
            this.labelObservaciones.AutoSize = true;
            this.labelObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelObservaciones.Location = new System.Drawing.Point(1148, 454);
            this.labelObservaciones.Name = "labelObservaciones";
            this.labelObservaciones.Size = new System.Drawing.Size(196, 31);
            this.labelObservaciones.TabIndex = 10;
            this.labelObservaciones.Text = "Observaciones";
            // 
            // checkBoxCastradoSi
            // 
            this.checkBoxCastradoSi.AutoSize = true;
            this.checkBoxCastradoSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCastradoSi.Location = new System.Drawing.Point(1317, 177);
            this.checkBoxCastradoSi.Name = "checkBoxCastradoSi";
            this.checkBoxCastradoSi.Size = new System.Drawing.Size(78, 41);
            this.checkBoxCastradoSi.TabIndex = 14;
            this.checkBoxCastradoSi.Text = "SI";
            this.checkBoxCastradoSi.UseVisualStyleBackColor = true;
            // 
            // checkBoxCastradoNo
            // 
            this.checkBoxCastradoNo.AutoSize = true;
            this.checkBoxCastradoNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCastradoNo.Location = new System.Drawing.Point(1492, 177);
            this.checkBoxCastradoNo.Name = "checkBoxCastradoNo";
            this.checkBoxCastradoNo.Size = new System.Drawing.Size(98, 41);
            this.checkBoxCastradoNo.TabIndex = 15;
            this.checkBoxCastradoNo.Text = "NO";
            this.checkBoxCastradoNo.UseVisualStyleBackColor = true;
            // 
            // btnModificarFichaMedica
            // 
            this.btnModificarFichaMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarFichaMedica.Location = new System.Drawing.Point(1153, 581);
            this.btnModificarFichaMedica.Name = "btnModificarFichaMedica";
            this.btnModificarFichaMedica.Size = new System.Drawing.Size(437, 82);
            this.btnModificarFichaMedica.TabIndex = 16;
            this.btnModificarFichaMedica.Text = "Modificar ficha médica";
            this.btnModificarFichaMedica.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1155, 669);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(437, 82);
            this.btnSalir.TabIndex = 17;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormGestionFichaMedica_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1651, 780);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificarFichaMedica);
            this.Controls.Add(this.checkBoxCastradoNo);
            this.Controls.Add(this.checkBoxCastradoSi);
            this.Controls.Add(this.txtTamaño);
            this.Controls.Add(this.labelObservaciones);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelMedicamento);
            this.Controls.Add(this.txtRaza);
            this.Controls.Add(this.labelDieta);
            this.Controls.Add(this.labelCastrado);
            this.Controls.Add(this.btnCrearFichaMedica);
            this.Controls.Add(this.listBoxFichaMedica);
            this.Controls.Add(this.dtAnimales);
            this.Name = "FormGestionFichaMedica_941lp";
            this.Text = "FormFichaMedica_941lp";
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).EndInit();
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
        private System.Windows.Forms.ListBox listBoxFichaMedica;
        private System.Windows.Forms.Button btnCrearFichaMedica;
        private System.Windows.Forms.Label labelCastrado;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.Label labelDieta;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelMedicamento;
        private System.Windows.Forms.TextBox txtTamaño;
        private System.Windows.Forms.Label labelObservaciones;
        private System.Windows.Forms.CheckBox checkBoxCastradoSi;
        private System.Windows.Forms.CheckBox checkBoxCastradoNo;
        private System.Windows.Forms.Button btnModificarFichaMedica;
        private System.Windows.Forms.Button btnSalir;
    }
}