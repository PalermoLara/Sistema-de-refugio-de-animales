namespace GUI
{
    partial class formDigitoVerificadorError_941lp
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
            this.btnRecalcular = new System.Windows.Forms.Button();
            this.btnRestore_941lp = new System.Windows.Forms.Button();
            this.btnSalir_941lp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRecalcular
            // 
            this.btnRecalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecalcular.Location = new System.Drawing.Point(358, 70);
            this.btnRecalcular.Name = "btnRecalcular";
            this.btnRecalcular.Size = new System.Drawing.Size(623, 119);
            this.btnRecalcular.TabIndex = 0;
            this.btnRecalcular.Text = "Recalcular";
            this.btnRecalcular.UseVisualStyleBackColor = true;
            this.btnRecalcular.Click += new System.EventHandler(this.btnRecalcular_Click);
            // 
            // btnRestore_941lp
            // 
            this.btnRestore_941lp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore_941lp.Location = new System.Drawing.Point(358, 209);
            this.btnRestore_941lp.Name = "btnRestore_941lp";
            this.btnRestore_941lp.Size = new System.Drawing.Size(623, 121);
            this.btnRestore_941lp.TabIndex = 1;
            this.btnRestore_941lp.Text = "Restore";
            this.btnRestore_941lp.UseVisualStyleBackColor = true;
            this.btnRestore_941lp.Click += new System.EventHandler(this.btnRestore_941lp_Click);
            // 
            // btnSalir_941lp
            // 
            this.btnSalir_941lp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir_941lp.Location = new System.Drawing.Point(358, 567);
            this.btnSalir_941lp.Name = "btnSalir_941lp";
            this.btnSalir_941lp.Size = new System.Drawing.Size(623, 121);
            this.btnSalir_941lp.TabIndex = 2;
            this.btnSalir_941lp.Text = "Salir";
            this.btnSalir_941lp.UseVisualStyleBackColor = true;
            this.btnSalir_941lp.Click += new System.EventHandler(this.btnSalir_941lp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "INCONSISTENCIA EN LA BASE DE DATOS";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(358, 387);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(623, 143);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 359);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tablas con incosistencias:";
            // 
            // formDigitoVerificadorError_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1443, 715);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir_941lp);
            this.Controls.Add(this.btnRestore_941lp);
            this.Controls.Add(this.btnRecalcular);
            this.Name = "formDigitoVerificadorError_941lp";
            this.Text = "DigitoVerificadorError_941lp";
            this.Load += new System.EventHandler(this.formDigitoVerificadorError_941lp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecalcular;
        private System.Windows.Forms.Button btnRestore_941lp;
        private System.Windows.Forms.Button btnSalir_941lp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}