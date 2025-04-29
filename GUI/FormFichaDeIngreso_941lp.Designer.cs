namespace GUI
{
    partial class FormFichaDeIngreso_941lp
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
            this.btnModificarFichaMedica = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.labelMedicamento = new System.Windows.Forms.Label();
            this.txtRaza = new System.Windows.Forms.TextBox();
            this.labelDieta = new System.Windows.Forms.Label();
            this.btnCrearFichaDeIngreso = new System.Windows.Forms.Button();
            this.listBoxFichaIngreso = new System.Windows.Forms.ListBox();
            this.dtAnimales = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnModificarFichaMedica
            // 
            this.btnModificarFichaMedica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarFichaMedica.Location = new System.Drawing.Point(1141, 593);
            this.btnModificarFichaMedica.Name = "btnModificarFichaMedica";
            this.btnModificarFichaMedica.Size = new System.Drawing.Size(437, 82);
            this.btnModificarFichaMedica.TabIndex = 28;
            this.btnModificarFichaMedica.Text = "Modificar ficha de ingreso";
            this.btnModificarFichaMedica.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(1214, 317);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(376, 31);
            this.txtNombre.TabIndex = 24;
            // 
            // labelMedicamento
            // 
            this.labelMedicamento.AutoSize = true;
            this.labelMedicamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMedicamento.Location = new System.Drawing.Point(1148, 271);
            this.labelMedicamento.Name = "labelMedicamento";
            this.labelMedicamento.Size = new System.Drawing.Size(76, 31);
            this.labelMedicamento.TabIndex = 23;
            this.labelMedicamento.Text = "Zona";
            // 
            // txtRaza
            // 
            this.txtRaza.Location = new System.Drawing.Point(1214, 192);
            this.txtRaza.Name = "txtRaza";
            this.txtRaza.Size = new System.Drawing.Size(376, 31);
            this.txtRaza.TabIndex = 22;
            // 
            // labelDieta
            // 
            this.labelDieta.AutoSize = true;
            this.labelDieta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDieta.Location = new System.Drawing.Point(1148, 146);
            this.labelDieta.Name = "labelDieta";
            this.labelDieta.Size = new System.Drawing.Size(229, 31);
            this.labelDieta.TabIndex = 21;
            this.labelDieta.Text = "Razón de entrega";
            // 
            // btnCrearFichaDeIngreso
            // 
            this.btnCrearFichaDeIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearFichaDeIngreso.Location = new System.Drawing.Point(1141, 24);
            this.btnCrearFichaDeIngreso.Name = "btnCrearFichaDeIngreso";
            this.btnCrearFichaDeIngreso.Size = new System.Drawing.Size(437, 82);
            this.btnCrearFichaDeIngreso.TabIndex = 19;
            this.btnCrearFichaDeIngreso.Text = "Crear ficha de ingreso";
            this.btnCrearFichaDeIngreso.UseVisualStyleBackColor = true;
            // 
            // listBoxFichaIngreso
            // 
            this.listBoxFichaIngreso.FormattingEnabled = true;
            this.listBoxFichaIngreso.ItemHeight = 25;
            this.listBoxFichaIngreso.Location = new System.Drawing.Point(12, 359);
            this.listBoxFichaIngreso.Name = "listBoxFichaIngreso";
            this.listBoxFichaIngreso.Size = new System.Drawing.Size(1114, 404);
            this.listBoxFichaIngreso.TabIndex = 18;
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
            this.dtAnimales.Location = new System.Drawing.Point(12, 24);
            this.dtAnimales.Name = "dtAnimales";
            this.dtAnimales.ReadOnly = true;
            this.dtAnimales.RowHeadersWidth = 82;
            this.dtAnimales.RowTemplate.Height = 33;
            this.dtAnimales.Size = new System.Drawing.Size(1114, 329);
            this.dtAnimales.TabIndex = 17;
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
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(1141, 681);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(437, 82);
            this.btnSalir.TabIndex = 29;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // FormFichaDeIngreso_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1680, 815);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnModificarFichaMedica);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.labelMedicamento);
            this.Controls.Add(this.txtRaza);
            this.Controls.Add(this.labelDieta);
            this.Controls.Add(this.btnCrearFichaDeIngreso);
            this.Controls.Add(this.listBoxFichaIngreso);
            this.Controls.Add(this.dtAnimales);
            this.Name = "FormFichaDeIngreso_941lp";
            this.Text = "FormFichaDeIngreso_941lp";
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificarFichaMedica;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label labelMedicamento;
        private System.Windows.Forms.TextBox txtRaza;
        private System.Windows.Forms.Label labelDieta;
        private System.Windows.Forms.Button btnCrearFichaDeIngreso;
        private System.Windows.Forms.ListBox listBoxFichaIngreso;
        private System.Windows.Forms.DataGridView dtAnimales;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btnSalir;
    }
}