namespace GUI
{
    partial class FormEstadoDeAdopcion_941lp
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.checkBoxDisponible = new System.Windows.Forms.CheckBox();
            this.checkBoxEnEvaluacion = new System.Windows.Forms.CheckBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.checkBoxAdoptado = new System.Windows.Forms.CheckBox();
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
            this.dtAnimales.Size = new System.Drawing.Size(1486, 329);
            this.dtAnimales.TabIndex = 0;
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
            // btnAceptar
            // 
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(12, 367);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(255, 76);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisponible
            // 
            this.checkBoxDisponible.AutoSize = true;
            this.checkBoxDisponible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDisponible.Location = new System.Drawing.Point(23, 490);
            this.checkBoxDisponible.Name = "checkBoxDisponible";
            this.checkBoxDisponible.Size = new System.Drawing.Size(198, 41);
            this.checkBoxDisponible.TabIndex = 2;
            this.checkBoxDisponible.Text = "Disponible";
            this.checkBoxDisponible.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnEvaluacion
            // 
            this.checkBoxEnEvaluacion.AutoSize = true;
            this.checkBoxEnEvaluacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnEvaluacion.Location = new System.Drawing.Point(23, 566);
            this.checkBoxEnEvaluacion.Name = "checkBoxEnEvaluacion";
            this.checkBoxEnEvaluacion.Size = new System.Drawing.Size(249, 41);
            this.checkBoxEnEvaluacion.TabIndex = 3;
            this.checkBoxEnEvaluacion.Text = "En evaluación";
            this.checkBoxEnEvaluacion.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(292, 367);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(255, 76);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // checkBoxAdoptado
            // 
            this.checkBoxAdoptado.AutoSize = true;
            this.checkBoxAdoptado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAdoptado.Location = new System.Drawing.Point(18, 644);
            this.checkBoxAdoptado.Name = "checkBoxAdoptado";
            this.checkBoxAdoptado.Size = new System.Drawing.Size(188, 41);
            this.checkBoxAdoptado.TabIndex = 5;
            this.checkBoxAdoptado.Text = "Adoptado";
            this.checkBoxAdoptado.UseVisualStyleBackColor = true;
            // 
            // FormEstadoDeAdopcion_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1510, 750);
            this.Controls.Add(this.checkBoxAdoptado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.checkBoxEnEvaluacion);
            this.Controls.Add(this.checkBoxDisponible);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtAnimales);
            this.Name = "FormEstadoDeAdopcion_941lp";
            this.Text = "FormEstadoDeAdopcion";
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
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox checkBoxDisponible;
        private System.Windows.Forms.CheckBox checkBoxEnEvaluacion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.CheckBox checkBoxAdoptado;
    }
}