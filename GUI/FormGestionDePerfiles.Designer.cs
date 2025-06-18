namespace GUI
{
    partial class FormGestionDePerfiles_941lp
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
            this.treeViewPermisos = new System.Windows.Forms.TreeView();
            this.treeViewFamiliaRol = new System.Windows.Forms.TreeView();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.comboBoxRolFamilia = new System.Windows.Forms.ComboBox();
            this.labelRolFamilia = new System.Windows.Forms.Label();
            this.txRolFamiliaNombre = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.btnCrearRolFamilia = new System.Windows.Forms.Button();
            this.rbRol = new System.Windows.Forms.RadioButton();
            this.rbFamilia = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.groupBoxQuitar = new System.Windows.Forms.GroupBox();
            this.rbTablaRolFamilia = new System.Windows.Forms.RadioButton();
            this.rbTablaPermisos = new System.Windows.Forms.RadioButton();
            this.groupBoxQuitar.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewPermisos
            // 
            this.treeViewPermisos.Location = new System.Drawing.Point(112, 137);
            this.treeViewPermisos.Name = "treeViewPermisos";
            this.treeViewPermisos.Size = new System.Drawing.Size(386, 412);
            this.treeViewPermisos.TabIndex = 0;
            // 
            // treeViewFamiliaRol
            // 
            this.treeViewFamiliaRol.Location = new System.Drawing.Point(571, 137);
            this.treeViewFamiliaRol.Name = "treeViewFamiliaRol";
            this.treeViewFamiliaRol.Size = new System.Drawing.Size(453, 424);
            this.treeViewFamiliaRol.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(327, 600);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(171, 48);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(327, 83);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(171, 48);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // comboBoxRolFamilia
            // 
            this.comboBoxRolFamilia.FormattingEnabled = true;
            this.comboBoxRolFamilia.Location = new System.Drawing.Point(571, 90);
            this.comboBoxRolFamilia.Name = "comboBoxRolFamilia";
            this.comboBoxRolFamilia.Size = new System.Drawing.Size(453, 33);
            this.comboBoxRolFamilia.TabIndex = 4;
            this.comboBoxRolFamilia.SelectedIndexChanged += new System.EventHandler(this.comboBoxRolFamilia_SelectedIndexChanged);
            // 
            // labelRolFamilia
            // 
            this.labelRolFamilia.AutoSize = true;
            this.labelRolFamilia.Location = new System.Drawing.Point(566, 62);
            this.labelRolFamilia.Name = "labelRolFamilia";
            this.labelRolFamilia.Size = new System.Drawing.Size(136, 25);
            this.labelRolFamilia.TabIndex = 5;
            this.labelRolFamilia.Text = "Rol o familia:";
            // 
            // txRolFamiliaNombre
            // 
            this.txRolFamiliaNombre.Location = new System.Drawing.Point(571, 609);
            this.txRolFamiliaNombre.Name = "txRolFamiliaNombre";
            this.txRolFamiliaNombre.Size = new System.Drawing.Size(453, 31);
            this.txRolFamiliaNombre.TabIndex = 0;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(566, 581);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(239, 25);
            this.labelNombre.TabIndex = 7;
            this.labelNombre.Text = "Nombre de rol o familia:";
            // 
            // btnCrearRolFamilia
            // 
            this.btnCrearRolFamilia.Location = new System.Drawing.Point(571, 646);
            this.btnCrearRolFamilia.Name = "btnCrearRolFamilia";
            this.btnCrearRolFamilia.Size = new System.Drawing.Size(171, 65);
            this.btnCrearRolFamilia.TabIndex = 8;
            this.btnCrearRolFamilia.Text = "Crear";
            this.btnCrearRolFamilia.UseVisualStyleBackColor = true;
            this.btnCrearRolFamilia.Click += new System.EventHandler(this.btnCrearRolFamilia_Click);
            // 
            // rbRol
            // 
            this.rbRol.AutoSize = true;
            this.rbRol.Checked = true;
            this.rbRol.Location = new System.Drawing.Point(748, 646);
            this.rbRol.Name = "rbRol";
            this.rbRol.Size = new System.Drawing.Size(62, 29);
            this.rbRol.TabIndex = 9;
            this.rbRol.TabStop = true;
            this.rbRol.Text = "Rol";
            this.rbRol.UseVisualStyleBackColor = true;
            // 
            // rbFamilia
            // 
            this.rbFamilia.AutoSize = true;
            this.rbFamilia.Location = new System.Drawing.Point(748, 681);
            this.rbFamilia.Name = "rbFamilia";
            this.rbFamilia.Size = new System.Drawing.Size(99, 29);
            this.rbFamilia.TabIndex = 10;
            this.rbFamilia.Text = "Familia";
            this.rbFamilia.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Permisos:";
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(853, 646);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(171, 64);
            this.btnAplicar.TabIndex = 13;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(327, 663);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(171, 48);
            this.btnAsignar.TabIndex = 14;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(112, 600);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(171, 48);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Quitar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // groupBoxQuitar
            // 
            this.groupBoxQuitar.Controls.Add(this.rbTablaRolFamilia);
            this.groupBoxQuitar.Controls.Add(this.rbTablaPermisos);
            this.groupBoxQuitar.Location = new System.Drawing.Point(117, 657);
            this.groupBoxQuitar.Name = "groupBoxQuitar";
            this.groupBoxQuitar.Size = new System.Drawing.Size(200, 100);
            this.groupBoxQuitar.TabIndex = 16;
            this.groupBoxQuitar.TabStop = false;
            this.groupBoxQuitar.Text = "Tabla:";
            // 
            // rbTablaRolFamilia
            // 
            this.rbTablaRolFamilia.AutoSize = true;
            this.rbTablaRolFamilia.Location = new System.Drawing.Point(47, 65);
            this.rbTablaRolFamilia.Name = "rbTablaRolFamilia";
            this.rbTablaRolFamilia.Size = new System.Drawing.Size(137, 29);
            this.rbTablaRolFamilia.TabIndex = 18;
            this.rbTablaRolFamilia.Text = "Rol/Familia";
            this.rbTablaRolFamilia.UseVisualStyleBackColor = true;
            // 
            // rbTablaPermisos
            // 
            this.rbTablaPermisos.AutoSize = true;
            this.rbTablaPermisos.Checked = true;
            this.rbTablaPermisos.Location = new System.Drawing.Point(47, 30);
            this.rbTablaPermisos.Name = "rbTablaPermisos";
            this.rbTablaPermisos.Size = new System.Drawing.Size(119, 29);
            this.rbTablaPermisos.TabIndex = 17;
            this.rbTablaPermisos.TabStop = true;
            this.rbTablaPermisos.Text = "Permisos";
            this.rbTablaPermisos.UseVisualStyleBackColor = true;
            // 
            // FormGestionDePerfiles_941lp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(142)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(1642, 808);
            this.Controls.Add(this.groupBoxQuitar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbFamilia);
            this.Controls.Add(this.rbRol);
            this.Controls.Add(this.btnCrearRolFamilia);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.txRolFamiliaNombre);
            this.Controls.Add(this.labelRolFamilia);
            this.Controls.Add(this.comboBoxRolFamilia);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.treeViewFamiliaRol);
            this.Controls.Add(this.treeViewPermisos);
            this.Name = "FormGestionDePerfiles_941lp";
            this.Text = "FormGestionDePerfiles";
            this.Load += new System.EventHandler(this.FormGestionDePerfiles_Load);
            this.groupBoxQuitar.ResumeLayout(false);
            this.groupBoxQuitar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewPermisos;
        private System.Windows.Forms.TreeView treeViewFamiliaRol;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox comboBoxRolFamilia;
        private System.Windows.Forms.Label labelRolFamilia;
        private System.Windows.Forms.TextBox txRolFamiliaNombre;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Button btnCrearRolFamilia;
        private System.Windows.Forms.RadioButton rbRol;
        private System.Windows.Forms.RadioButton rbFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBoxQuitar;
        private System.Windows.Forms.RadioButton rbTablaRolFamilia;
        private System.Windows.Forms.RadioButton rbTablaPermisos;
    }
}