using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class FormGestionDePerfiles_941lp : Form
    {
        bllPermisos_941lp bllPermisos_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormGestionDePerfiles_941lp()
        {
            InitializeComponent();
            bllPermisos_941lp = new bllPermisos_941lp();
            modo_941lp = ModoOperacion_941lp.Consulta;
            HabilitarControles_941lp();
        }
        enum ModoOperacion_941lp
        {
            Consulta, 
            Crear
        }

        private void FormGestionDePerfiles_Load(object sender, EventArgs e)
        {
            treeViewFamiliaRol.CheckBoxes = true;
            treeViewPermisos.CheckBoxes = true;
            bllPermisos_941lp.CargarEstructura();
            MostrarPermisosTreePermisos_941lp(bllPermisos_941lp.RetornarPermisos_941lp());
            LlenarComboBoxCompuestos_941lp(comboBoxRolFamilia, bllPermisos_941lp.RetornarPermisos_941lp());
            // Mostrar árbol del permiso seleccionado (si existe)
            if (comboBoxRolFamilia.Items.Count > 0)
            {
                comboBoxRolFamilia.SelectedIndex = 0; 
                MostrarPermisosTreeRolFamilia_941lp(bllPermisos_941lp.ObtenerPermiso_941lp(comboBoxRolFamilia.Text));
            }
        }

        private void MostrarPermisosTreeRolFamilia_941lp(Permiso_941lp f_941lp)
        {
            treeViewFamiliaRol.Nodes.Clear();
            if (f_941lp != null && f_941lp is Familia_941lp)
            {
                TreeNode nodoRaiz = CrearNodoDesdePermiso(f_941lp);
                treeViewFamiliaRol.Nodes.Add(nodoRaiz);
            }
        }

        private void LlenarComboBoxCompuestos_941lp(System.Windows.Forms.ComboBox comboBox_941lp, List<Permiso_941lp> listaPermisos_941lp)
        {
            comboBox_941lp.Items.Clear();
            foreach (var permiso_941lp in listaPermisos_941lp)
            {
                if (permiso_941lp is Familia_941lp)
                {
                    comboBox_941lp.Items.Add(permiso_941lp.nombrePermiso_941lp);
                }
            }
        }

        private void MostrarPermisosTreePermisos_941lp(List<Permiso_941lp> listaPermisos_941lp)
        {
            treeViewPermisos.Nodes.Clear();
            foreach (var permiso_941lp in listaPermisos_941lp)
            {
                TreeNode nodo_941lp = CrearNodoDesdePermiso(permiso_941lp);
                treeViewPermisos.Nodes.Add(nodo_941lp);
            }
        }

        private TreeNode CrearNodoDesdePermiso(Permiso_941lp permiso_941lp)
        {
            TreeNode nodo_941lp = new TreeNode(permiso_941lp.nombrePermiso_941lp); // siempre muestra el nombre

            if (permiso_941lp is Familia_941lp compuesto_941lp)
            {
                foreach (var hijo_941lp in compuesto_941lp.ObtenerPermisos())
                {
                    nodo_941lp.Nodes.Add(CrearNodoDesdePermiso(hijo_941lp)); // recursión
                }
            }
            return nodo_941lp;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            HabilitarControles_941lp();
            this.Close();
        }

        private void btnCrearRolFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Crear;
                HabilitarControles_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void HabilitarControles_941lp()
        {
            if (modo_941lp == ModoOperacion_941lp.Crear)
            {
                rbFamilia.Enabled = true;
                rbRol.Enabled = true;
                btnAplicar.Enabled = true;
                btnCancelar.Enabled = true;
                txRolFamiliaNombre.Enabled = true;
                comboBoxRolFamilia.Enabled = false;
                btnSalir.Enabled = false;
                btnEliminar.Enabled = false;
                btnAsignar.Enabled = false;
                btnCrearRolFamilia.Enabled=false;
            }
            else
            {
                btnAsignar.Enabled = true;
                rbFamilia.Enabled = false;
                rbRol.Enabled = false;
                btnAplicar.Enabled = false;
                btnCancelar.Enabled = false;
                txRolFamiliaNombre.Enabled = false;
                comboBoxRolFamilia.Enabled = true;
                btnSalir.Enabled = true;
                btnEliminar.Enabled = true;
                btnCrearRolFamilia.Enabled = true;
            }
            AplicarColorControles_941lp();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllPermisos_941lp.VerificarNombreDeRolFamlia_941lp(txRolFamiliaNombre.Text)) throw new Exception("Nombre repetido");
                HabilitarControles_941lp();
                List<string> seleccionados_941lp = ObtenerPermisosSeleccionadosDelTreeView(treeViewPermisos);
                string nombrePermiso_941lp = ObtenerNombreFamiliaRol();
                bllPermisos_941lp.AltaPermiso_941lp(nombrePermiso_941lp, rbRol.Checked);
                modo_941lp = ModoOperacion_941lp.Consulta;
                HabilitarControles_941lp();
                MostrarPermisosTreePermisos_941lp(bllPermisos_941lp.RetornarPermisos_941lp());
                LlenarComboBoxCompuestos_941lp(comboBoxRolFamilia, bllPermisos_941lp.RetornarPermisos_941lp());
                MostrarPermisosTreeRolFamilia_941lp((Familia_941lp)bllPermisos_941lp.ObtenerPermiso_941lp(comboBoxRolFamilia.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string ObtenerNombreFamiliaRol()
        {
            string nombrePermiso_941lp;
            if (modo_941lp == ModoOperacion_941lp.Crear)
            {
                nombrePermiso_941lp = txRolFamiliaNombre.Text;
            }
            else
            {
                nombrePermiso_941lp = comboBoxRolFamilia.Text;
            }
            return nombrePermiso_941lp;
        }

        private List<string> ObtenerPermisosSeleccionadosDelTreeView(System.Windows.Forms.TreeView tview_941lp)
        {
            List<string> seleccionados_941lp = new List<string>();

            foreach (TreeNode nodo in tview_941lp.Nodes)
            {
                ObtenerSeleccionadosRecursivo(nodo, seleccionados_941lp);
            }

            return seleccionados_941lp;
        }

        private void ObtenerSeleccionadosRecursivo(TreeNode nodo, List<string> lista)
        {
            if (nodo.Checked)
            {
                lista.Add(nodo.Text);
            }

            foreach (TreeNode hijo in nodo.Nodes)
            {
                ObtenerSeleccionadosRecursivo(hijo, lista); // recursión
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> seleccionados_941lp = ObtenerPermisosSeleccionadosDelTreeView(treeViewPermisos);
                string nombrePermiso_941lp = ObtenerNombreFamiliaRol();
                bllPermisos_941lp.AltaIntermedia_941lp(nombrePermiso_941lp, seleccionados_941lp);
                MostrarPermisosTreeRolFamilia_941lp((Familia_941lp)bllPermisos_941lp.ObtenerPermiso_941lp(comboBoxRolFamilia.Text));
                MostrarPermisosTreePermisos_941lp(bllPermisos_941lp.RetornarPermisos_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                txRolFamiliaNombre, btnCancelar, btnCrearRolFamilia, btnAplicar, btnSalir, btnEliminar, btnAsignar,  btnCrearRolFamilia
            };

            foreach (var control_941lp in controles_941lp)
            {
                if (control_941lp.Enabled == false)
                {

                    control_941lp.BackColor = Color.LightSteelBlue;
                }
                else
                {
                    control_941lp.BackColor = Color.White;
                }
            }
        }

        private void comboBoxRolFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarPermisosTreeRolFamilia_941lp((Familia_941lp)bllPermisos_941lp.ObtenerPermiso_941lp(comboBoxRolFamilia.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> noEliminados_941lp = new List<string>();
                RadioButton seleccionado_941lp = groupBoxQuitar.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
                System.Windows.Forms.TreeView treeView_941lp = rbTablaPermisos.Checked ? treeViewPermisos : treeViewFamiliaRol;
                foreach (string s_941lp in ObtenerPermisosSeleccionadosDelTreeView(treeView_941lp))
                {
                    if (rbTablaPermisos.Checked)
                    {
                        if (!bllPermisos_941lp.VerificarSiEsCompuesto(s_941lp))
                        {
                            noEliminados_941lp.Add(s_941lp); continue;
                        }
                        bllPermisos_941lp.EliminarDeIntermediaPermanente_941lp(comboBoxRolFamilia.Text, s_941lp);
                        bllPermisos_941lp.EliminarPermiso_941lp(s_941lp);
                    }
                    else
                    {
                        bllPermisos_941lp.EliminarIntermedia_941lp(comboBoxRolFamilia.Text, s_941lp);
                    }
                }
                if (noEliminados_941lp.Any())
                {
                    MessageBox.Show("No se pudieron eliminar los siguientes permisos simples:\n" +
                                     string.Join("\n", noEliminados_941lp),
                                    "Permisos simples", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                comboBoxRolFamilia.SelectedIndex = 0;
                MostrarPermisosTreePermisos_941lp(bllPermisos_941lp.RetornarPermisos_941lp());
                LlenarComboBoxCompuestos_941lp(comboBoxRolFamilia, bllPermisos_941lp.RetornarPermisos_941lp());
                MostrarPermisosTreeRolFamilia_941lp(bllPermisos_941lp.ObtenerPermiso_941lp(comboBoxRolFamilia.Text));
                treeViewFamiliaRol.Nodes.Clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Consulta;
                HabilitarControles_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
