namespace GUI
{
    partial class FormCambioDeIdioma_941lp
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
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.labelCambioDeIdioma = new System.Windows.Forms.Label();
            this.comboBoxIdiomas = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(163, 239);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(171, 64);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(384, 239);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(171, 64);
            this.btnSalir.TabIndex = 16;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // labelCambioDeIdioma
            // 
            this.labelCambioDeIdioma.AutoSize = true;
            this.labelCambioDeIdioma.Location = new System.Drawing.Point(264, 76);
            this.labelCambioDeIdioma.Name = "labelCambioDeIdioma";
            this.labelCambioDeIdioma.Size = new System.Drawing.Size(184, 25);
            this.labelCambioDeIdioma.TabIndex = 18;
            this.labelCambioDeIdioma.Text = "Cambio de idioma";
            // 
            // comboBoxIdiomas
            // 
            this.comboBoxIdiomas.FormattingEnabled = true;
            this.comboBoxIdiomas.Items.AddRange(new object[] {
            "en",
            "es"});
            this.comboBoxIdiomas.Location = new System.Drawing.Point(218, 146);
            this.comboBoxIdiomas.Name = "comboBoxIdiomas";
            this.comboBoxIdiomas.Size = new System.Drawing.Size(283, 33);
            this.comboBoxIdiomas.TabIndex = 19;
            this.comboBoxIdiomas.SelectedIndexChanged += new System.EventHandler(this.comboBoxIdiomas_SelectedIndexChanged);
            // 
            // FormCambioDeIdioma_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(802, 601);
            this.Controls.Add(this.comboBoxIdiomas);
            this.Controls.Add(this.labelCambioDeIdioma);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnSalir);
            this.Name = "FormCambioDeIdioma_941lp";
            this.Text = "FormCambioDeIdioma_941lp";
            this.Load += new System.EventHandler(this.FormCambioDeIdioma_941lp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label labelCambioDeIdioma;
        private System.Windows.Forms.ComboBox comboBoxIdiomas;
    }
}