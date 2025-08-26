namespace GUI
{
    partial class FormBackUpRestore_941lp
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
            this.btnRealizarRestore = new System.Windows.Forms.Button();
            this.btnRealizarBackUp_941lp = new System.Windows.Forms.Button();
            this.labelRestore = new System.Windows.Forms.Label();
            this.txtRestore_941lp = new System.Windows.Forms.TextBox();
            this.labelBackUp = new System.Windows.Forms.Label();
            this.buttonRestoreCarpeta = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRealizarRestore
            // 
            this.btnRealizarRestore.Location = new System.Drawing.Point(262, 445);
            this.btnRealizarRestore.Margin = new System.Windows.Forms.Padding(6);
            this.btnRealizarRestore.Name = "btnRealizarRestore";
            this.btnRealizarRestore.Size = new System.Drawing.Size(274, 44);
            this.btnRealizarRestore.TabIndex = 17;
            this.btnRealizarRestore.Text = "Realizar restore";
            this.btnRealizarRestore.UseVisualStyleBackColor = true;
            this.btnRealizarRestore.Click += new System.EventHandler(this.btnRealizarRestore_Click);
            // 
            // btnRealizarBackUp_941lp
            // 
            this.btnRealizarBackUp_941lp.Location = new System.Drawing.Point(261, 135);
            this.btnRealizarBackUp_941lp.Margin = new System.Windows.Forms.Padding(6);
            this.btnRealizarBackUp_941lp.Name = "btnRealizarBackUp_941lp";
            this.btnRealizarBackUp_941lp.Size = new System.Drawing.Size(280, 44);
            this.btnRealizarBackUp_941lp.TabIndex = 16;
            this.btnRealizarBackUp_941lp.Text = "Realizar backUp";
            this.btnRealizarBackUp_941lp.UseVisualStyleBackColor = true;
            this.btnRealizarBackUp_941lp.Click += new System.EventHandler(this.btnRealizarBackUp_941lp_Click);
            // 
            // labelRestore
            // 
            this.labelRestore.AutoSize = true;
            this.labelRestore.Location = new System.Drawing.Point(256, 315);
            this.labelRestore.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelRestore.Name = "labelRestore";
            this.labelRestore.Size = new System.Drawing.Size(93, 25);
            this.labelRestore.TabIndex = 15;
            this.labelRestore.Text = "Restore:";
            // 
            // txtRestore_941lp
            // 
            this.txtRestore_941lp.Location = new System.Drawing.Point(262, 361);
            this.txtRestore_941lp.Margin = new System.Windows.Forms.Padding(6);
            this.txtRestore_941lp.Name = "txtRestore_941lp";
            this.txtRestore_941lp.ReadOnly = true;
            this.txtRestore_941lp.Size = new System.Drawing.Size(550, 31);
            this.txtRestore_941lp.TabIndex = 14;
            // 
            // labelBackUp
            // 
            this.labelBackUp.AutoSize = true;
            this.labelBackUp.Location = new System.Drawing.Point(256, 93);
            this.labelBackUp.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelBackUp.Name = "labelBackUp";
            this.labelBackUp.Size = new System.Drawing.Size(99, 25);
            this.labelBackUp.TabIndex = 12;
            this.labelBackUp.Text = "Back Up:";
            // 
            // buttonRestoreCarpeta
            // 
            this.buttonRestoreCarpeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestoreCarpeta.Location = new System.Drawing.Point(858, 361);
            this.buttonRestoreCarpeta.Name = "buttonRestoreCarpeta";
            this.buttonRestoreCarpeta.Size = new System.Drawing.Size(132, 112);
            this.buttonRestoreCarpeta.TabIndex = 19;
            this.buttonRestoreCarpeta.Text = "📁";
            this.buttonRestoreCarpeta.UseVisualStyleBackColor = true;
            this.buttonRestoreCarpeta.Click += new System.EventHandler(this.buttonRestoreCarpeta_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(262, 564);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(274, 44);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormBackUpRestore_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1329, 731);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.buttonRestoreCarpeta);
            this.Controls.Add(this.btnRealizarRestore);
            this.Controls.Add(this.btnRealizarBackUp_941lp);
            this.Controls.Add(this.labelRestore);
            this.Controls.Add(this.txtRestore_941lp);
            this.Controls.Add(this.labelBackUp);
            this.Name = "FormBackUpRestore_941lp";
            this.Text = "FormBackUpRestore_941lp";
            this.Load += new System.EventHandler(this.FormBackUpRestore_941lp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRealizarRestore;
        private System.Windows.Forms.Button btnRealizarBackUp_941lp;
        private System.Windows.Forms.Label labelRestore;
        private System.Windows.Forms.TextBox txtRestore_941lp;
        private System.Windows.Forms.Label labelBackUp;
        private System.Windows.Forms.Button buttonRestoreCarpeta;
        private System.Windows.Forms.Button btnSalir;
    }
}