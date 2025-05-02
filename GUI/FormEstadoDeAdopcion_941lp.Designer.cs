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
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBoxEstadoAdopcion = new System.Windows.Forms.GroupBox();
            this.rbEnEvaluacionAdopcion = new System.Windows.Forms.RadioButton();
            this.rbDisponibleAdopcion = new System.Windows.Forms.RadioButton();
            this.rbAdoptado = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).BeginInit();
            this.groupBoxEstadoAdopcion.SuspendLayout();
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
            this.dtAnimales.Size = new System.Drawing.Size(743, 171);
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
            this.btnAceptar.Location = new System.Drawing.Point(6, 191);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(128, 40);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(146, 191);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 40);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // groupBoxEstadoAdopcion
            // 
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbAdoptado);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbDisponibleAdopcion);
            this.groupBoxEstadoAdopcion.Controls.Add(this.rbEnEvaluacionAdopcion);
            this.groupBoxEstadoAdopcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEstadoAdopcion.Location = new System.Drawing.Point(10, 244);
            this.groupBoxEstadoAdopcion.Name = "groupBoxEstadoAdopcion";
            this.groupBoxEstadoAdopcion.Size = new System.Drawing.Size(264, 134);
            this.groupBoxEstadoAdopcion.TabIndex = 5;
            this.groupBoxEstadoAdopcion.TabStop = false;
            this.groupBoxEstadoAdopcion.Text = "Estado";
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
            // FormEstadoDeAdopcion_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(755, 390);
            this.Controls.Add(this.groupBoxEstadoAdopcion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtAnimales);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormEstadoDeAdopcion_941lp";
            this.Text = "FormEstadoDeAdopcion";
            ((System.ComponentModel.ISupportInitialize)(this.dtAnimales)).EndInit();
            this.groupBoxEstadoAdopcion.ResumeLayout(false);
            this.groupBoxEstadoAdopcion.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBoxEstadoAdopcion;
        private System.Windows.Forms.RadioButton rbAdoptado;
        private System.Windows.Forms.RadioButton rbDisponibleAdopcion;
        private System.Windows.Forms.RadioButton rbEnEvaluacionAdopcion;
    }
}