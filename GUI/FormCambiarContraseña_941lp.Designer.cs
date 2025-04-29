namespace GUI
{
    partial class FormCambiarContraseña_941lp
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
            this.labelContraseñaActual = new System.Windows.Forms.Label();
            this.labelContraseñaConfirmacion = new System.Windows.Forms.Label();
            this.labelContraseñaNueva = new System.Windows.Forms.Label();
            this.btnAceptarCambioContraseña = new System.Windows.Forms.Button();
            this.txtContraseñaActual = new System.Windows.Forms.TextBox();
            this.txtContraseñaNueva = new System.Windows.Forms.TextBox();
            this.txtContraseñaConfirmacion = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelContraseñaActual
            // 
            this.labelContraseñaActual.AutoSize = true;
            this.labelContraseñaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseñaActual.Location = new System.Drawing.Point(26, 180);
            this.labelContraseñaActual.Name = "labelContraseñaActual";
            this.labelContraseñaActual.Size = new System.Drawing.Size(387, 37);
            this.labelContraseñaActual.TabIndex = 0;
            this.labelContraseñaActual.Text = "CONTRASEÑA ACTUAL:";
            // 
            // labelContraseñaConfirmacion
            // 
            this.labelContraseñaConfirmacion.AutoSize = true;
            this.labelContraseñaConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseñaConfirmacion.Location = new System.Drawing.Point(26, 400);
            this.labelContraseñaConfirmacion.Name = "labelContraseñaConfirmacion";
            this.labelContraseñaConfirmacion.Size = new System.Drawing.Size(451, 37);
            this.labelContraseñaConfirmacion.TabIndex = 1;
            this.labelContraseñaConfirmacion.Text = "CONFIRMAR CONTRASEÑA:";
            // 
            // labelContraseñaNueva
            // 
            this.labelContraseñaNueva.AutoSize = true;
            this.labelContraseñaNueva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContraseñaNueva.Location = new System.Drawing.Point(26, 290);
            this.labelContraseñaNueva.Name = "labelContraseñaNueva";
            this.labelContraseñaNueva.Size = new System.Drawing.Size(371, 37);
            this.labelContraseñaNueva.TabIndex = 2;
            this.labelContraseñaNueva.Text = "CONTRASEÑA NUEVA:";
            // 
            // btnAceptarCambioContraseña
            // 
            this.btnAceptarCambioContraseña.Location = new System.Drawing.Point(589, 566);
            this.btnAceptarCambioContraseña.Name = "btnAceptarCambioContraseña";
            this.btnAceptarCambioContraseña.Size = new System.Drawing.Size(285, 65);
            this.btnAceptarCambioContraseña.TabIndex = 3;
            this.btnAceptarCambioContraseña.Text = "ACEPTAR";
            this.btnAceptarCambioContraseña.UseVisualStyleBackColor = true;
            this.btnAceptarCambioContraseña.Click += new System.EventHandler(this.btnAceptarCambioContraseña_Click);
            // 
            // txtContraseñaActual
            // 
            this.txtContraseñaActual.Location = new System.Drawing.Point(504, 160);
            this.txtContraseñaActual.Multiline = true;
            this.txtContraseñaActual.Name = "txtContraseñaActual";
            this.txtContraseñaActual.Size = new System.Drawing.Size(434, 57);
            this.txtContraseñaActual.TabIndex = 4;
            // 
            // txtContraseñaNueva
            // 
            this.txtContraseñaNueva.Location = new System.Drawing.Point(504, 270);
            this.txtContraseñaNueva.Multiline = true;
            this.txtContraseñaNueva.Name = "txtContraseñaNueva";
            this.txtContraseñaNueva.Size = new System.Drawing.Size(434, 57);
            this.txtContraseñaNueva.TabIndex = 5;
            // 
            // txtContraseñaConfirmacion
            // 
            this.txtContraseñaConfirmacion.Location = new System.Drawing.Point(504, 380);
            this.txtContraseñaConfirmacion.Multiline = true;
            this.txtContraseñaConfirmacion.Name = "txtContraseñaConfirmacion";
            this.txtContraseñaConfirmacion.Size = new System.Drawing.Size(434, 57);
            this.txtContraseñaConfirmacion.TabIndex = 6;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(589, 651);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(285, 65);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "SALIR";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormCambiarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1522, 745);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtContraseñaConfirmacion);
            this.Controls.Add(this.txtContraseñaNueva);
            this.Controls.Add(this.txtContraseñaActual);
            this.Controls.Add(this.btnAceptarCambioContraseña);
            this.Controls.Add(this.labelContraseñaNueva);
            this.Controls.Add(this.labelContraseñaConfirmacion);
            this.Controls.Add(this.labelContraseñaActual);
            this.Name = "FormCambiarContraseña";
            this.Text = "FormCambiarContraseña";
            this.Load += new System.EventHandler(this.FormCambiarContraseña_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelContraseñaActual;
        private System.Windows.Forms.Label labelContraseñaConfirmacion;
        private System.Windows.Forms.Label labelContraseñaNueva;
        private System.Windows.Forms.Button btnAceptarCambioContraseña;
        private System.Windows.Forms.TextBox txtContraseñaActual;
        private System.Windows.Forms.TextBox txtContraseñaNueva;
        private System.Windows.Forms.TextBox txtContraseñaConfirmacion;
        private System.Windows.Forms.Button btnSalir;
    }
}