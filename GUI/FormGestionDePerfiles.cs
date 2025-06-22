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
        bllFamilia_941lp bllFamilia_941lp;
        bllPerfil_941lp bllPerfil_941Lp;
        bllPerfilTablasIntermedias_941lp bllPerfilTablasIntermedias_941lp;
        bllFamiliaTablasIntermedias_941lp bllFamiliaTablasIntermedias_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormGestionDePerfiles_941lp()
        {
            InitializeComponent();
            bllPermisos_941lp = new bllPermisos_941lp();
            bllFamilia_941lp = new bllFamilia_941lp();
            bllPerfil_941Lp = new bllPerfil_941lp();
            bllPerfilTablasIntermedias_941lp = new bllPerfilTablasIntermedias_941lp();
            bllFamiliaTablasIntermedias_941lp = new bllFamiliaTablasIntermedias_941lp();
            modo_941lp = ModoOperacion_941lp.Consulta;
            HabilitarControles_941lp();
        }
        enum ModoOperacion_941lp
        {
            Consulta, 
            Crear,
            Quitar,
            Asignar,
            Modificar
        }

        private void FormGestionDePerfiles_Load(object sender, EventArgs e)
        {
            treeViewFamiliaRol.CheckBoxes = true;
            treeViewFamilia.CheckBoxes = true;
            treeViewPermisos.CheckBoxes = true;
            MostrarPermisosTreePermisos_941lp(bllPermisos_941lp.RetornarPermisos_941lp());
            if (comboBoxRolFamilia.Items.Count > 0)
            {
                comboBoxRolFamilia.SelectedIndex = 0;
            }
            if(rbFamilias.Checked)
            {
                LlenarComboBoxCompuestos_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
                MostrarTreeViewPerfil_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
            }
            else
            {
                LlenarComboBoxCompuestos_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
                MostrarTreeViewPerfil_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
            }
            MostrarPermisosTreeFamilia_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
        }

        private void MostrarPermisosTreeFamilia_941lp(List<Perfil_941lp> listaFamilias_941lp)
        {
            treeViewFamilia.Nodes.Clear();
            if (listaFamilias_941lp == null || listaFamilias_941lp.Count == 0)
                return;
            foreach (var perfil_941lp in listaFamilias_941lp)
            {
                if (perfil_941lp is Familia_941lp familia)
                {
                    TreeNode nodoRaiz = CrearNodoDesdePermiso(familia);
                    treeViewFamilia.Nodes.Add(nodoRaiz);
                }
            }
        }

        private void MostrarTreeViewPerfil_941lp(List<Perfil_941lp> listaFamilias_941lp)
        {
            treeViewFamiliaRol.Nodes.Clear();
            if (listaFamilias_941lp == null || listaFamilias_941lp.Count == 0)
                return;
            foreach (var perfil_941lp in listaFamilias_941lp)
            {
                if (perfil_941lp is Familia_941lp familia)
                {
                    TreeNode nodoRaiz = CrearNodoDesdePermiso(familia);
                    treeViewFamiliaRol.Nodes.Add(nodoRaiz);
                }
            }
        }

        private void MostrarTreeViewPerfilUnico_941lp(Perfil_941lp perfil_941lp)
        {
            treeViewFamiliaRol.Nodes.Clear();
            if (perfil_941lp is Familia_941lp familia)
            {
                TreeNode nodoRaiz = CrearNodoDesdePermiso(familia);
                treeViewFamiliaRol.Nodes.Add(nodoRaiz);
            }
            
        }

        private void MostrarPermisosTreePermisos_941lp(List<PermisoSimple_941lp> listaPermisos_941lp)
        {
            treeViewPermisos.Nodes.Clear();
            foreach (var permiso_941lp in listaPermisos_941lp)
            {
                treeViewPermisos.Nodes.Add(permiso_941lp.nombrePermiso_941lp);
            }
        }

        private void LlenarComboBoxCompuestos_941lp(List<Perfil_941lp> listaPermisos_941lp)
        {
            comboBoxRolFamilia.Items.Clear();
            foreach (var permiso_941lp in listaPermisos_941lp)
            {
                if(permiso_941lp.GetType() == typeof(Familia_941lp))
                comboBoxRolFamilia.Items.Add(permiso_941lp.nombrePermiso_941lp);
            }
        }

        private TreeNode CrearNodoDesdePermiso(Perfil_941lp permiso_941lp)
        {
            TreeNode nodo_941lp = new TreeNode(permiso_941lp.nombrePermiso_941lp); 

            if (permiso_941lp is Familia_941lp compuesto_941lp)
            {
                foreach (var hijo_941lp in compuesto_941lp.ObtenerPermisos_941lp())
                {
                    nodo_941lp.Nodes.Add(CrearNodoDesdePermiso(hijo_941lp)); 
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
            txtCrear.Clear();
            if (modo_941lp == ModoOperacion_941lp.Crear)
            {
                btnAplicar.Enabled = true;
                btnCancelar.Enabled = true;
                txtCrear.Enabled = true;
                comboBoxRolFamilia.Enabled = false;
                btnSalir.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnAsignar.Enabled = false;
                btnCrearRolFamilia.Enabled=false;
            }
            else if(modo_941lp == ModoOperacion_941lp.Asignar || modo_941lp == ModoOperacion_941lp.Quitar || modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtCrear.Enabled = false;
                btnCrearRolFamilia.Enabled = false;
                btnAsignar.Enabled=false;
                btnEliminar.Enabled=false;
                comboBoxRolFamilia.Enabled = true;
                btnAplicar.Enabled = true;
                btnCancelar.Enabled = true;
                btnSalir.Enabled=false;
                btnModificar.Enabled=false;
                if (modo_941lp == ModoOperacion_941lp.Quitar)
                {
                    treeViewPermisos.Enabled = false;
                }
                if (modo_941lp == ModoOperacion_941lp.Modificar)
                {
                    treeViewPermisos.Enabled = false;
                    treeViewFamilia.Enabled = false;
                }
            }
            else
            {
                btnAsignar.Enabled = true;
                btnAplicar.Enabled = false;
                btnCancelar.Enabled = false;
                txtCrear.Enabled = false;
                comboBoxRolFamilia.Enabled = true;
                btnSalir.Enabled = true;
                btnEliminar.Enabled = true;
                btnCrearRolFamilia.Enabled = true;
                btnModificar.Enabled = true;
                treeViewPermisos.Enabled = true;
                treeViewFamilia.Enabled = true;
            }
            AplicarColorControles_941lp();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> seleccionados_941lp = ObtenerPermisosSeleccionadosDelTreeView();
                if(bllPerfil_941Lp.VerificarNombreDePerfil_941lp(txtCrear.Text)) throw new Exception("Nombre igual al nombre de un perfil");
                if (bllFamilia_941lp.VerificarNombreDeFamilia_941lp(txtCrear.Text)) throw new Exception("Nombre igual al nombre de una familia");
                if(bllPermisos_941lp.VerificarNombreDePatente_941lp(txtCrear.Text)) throw new Exception("Nombre igual al nombre de una patente");
                bllPerfil_941Lp.VerificarDuplicados_941lp(seleccionados_941lp);
                string nombrePermisoDestino_941lp = comboBoxRolFamilia.Text;
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Crear:
                        if (rbPerfiles.Checked)
                        {
                            bllPerfil_941Lp.AltaPerfil_941lp(txtCrear.Text, seleccionados_941lp);
                            LlenarComboBoxCompuestos_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
                        }
                        if (rbFamilias.Checked)
                        {
                            if (seleccionados_941lp.Count == 0) throw new Exception("No puede crear una familia vacia");
                            bllFamilia_941lp.AltaFamilia_941lp(txtCrear.Text, seleccionados_941lp);
                            LlenarComboBoxCompuestos_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
                        }
                        break;
                    case ModoOperacion_941lp.Asignar:
                        if (bllPerfil_941Lp.ValidarContraEstructuraEnMemoria_941lp(comboBoxRolFamilia.Text, seleccionados_941lp) == false) throw new Exception("Permisos repetidos");
                        if (rbPerfiles.Checked)
                        {
                            bllPerfilTablasIntermedias_941lp.AltaPerfilIntermedias_941lp(nombrePermisoDestino_941lp, seleccionados_941lp);
                        }
                        if (rbFamilias.Checked)
                        {
                            bllFamiliaTablasIntermedias_941lp.AltaFamiliaIntermedia_941lp(nombrePermisoDestino_941lp, seleccionados_941lp);
                        }
                        break;
                    case ModoOperacion_941lp.Quitar:
                        if (rbPerfiles.Checked)
                        {
                            bllPerfil_941Lp.EliminarPerfil_941lp(nombrePermisoDestino_941lp);
                        }
                        if (rbFamilias.Checked)
                        {
                            bllFamilia_941lp.EliminarFamilia_941lp(nombrePermisoDestino_941lp);
                        }
                        break;
                    case ModoOperacion_941lp.Modificar:
                        List<string> listaModificar_941lp = ObtenerPermisosSeleccionadosDelTreeViewParaModificar();
                        if (rbPerfiles.Checked)
                        {
                            MostrarTreeViewPerfilUnico_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp().Find(x => x.nombrePermiso_941lp == nombrePermisoDestino_941lp));
                            bllPerfilTablasIntermedias_941lp.EliminarPerfilIntermedia_941lp(nombrePermisoDestino_941lp, listaModificar_941lp);
                        }
                        if (rbFamilias.Checked)
                        {
                            MostrarTreeViewPerfilUnico_941lp(bllFamilia_941lp.RetornarFamilias_941lp().Find(x => x.nombrePermiso_941lp == nombrePermisoDestino_941lp));
                            bllFamiliaTablasIntermedias_941lp.EliminarFamiliaIntermedia_941lp(nombrePermisoDestino_941lp, listaModificar_941lp);
                        }
                        break;
                }
                modo_941lp = ModoOperacion_941lp.Consulta;
                HabilitarControles_941lp();
                MostrarPermisosTreeFamilia_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
                MostrarTreeViewPerfil_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private List<string> ObtenerPermisosSeleccionadosDelTreeView()
        {
            List<string> seleccionados_941lp = new List<string>();

            foreach (TreeNode nodo in treeViewFamilia.Nodes)
            {
                if(nodo.Checked)
                ObtenerSeleccionadosRecursivo(nodo, seleccionados_941lp);
            }

            foreach (TreeNode nodo in treeViewPermisos.Nodes)
            {
                if (nodo.Checked)
                seleccionados_941lp.Add(nodo.Text);
            }

            return seleccionados_941lp;
        }

        private List<string> ObtenerPermisosSeleccionadosDelTreeViewParaModificar()
        {
            List<string> seleccionados_941lp = new List<string>();

            foreach (TreeNode nodo in treeViewFamiliaRol.Nodes)
            {
                ProcesarNodoSeleccionado(nodo, seleccionados_941lp, esRaiz: true);
            }

            return seleccionados_941lp;
        }

        private void ProcesarNodoSeleccionado(TreeNode nodo, List<string> lista, bool esRaiz)
        {
            if (nodo.Checked)
            {
                if (esRaiz)
                {
                    throw new InvalidOperationException("No se puede seleccionar el nodo raíz.");
                }

                if (nodo.Nodes.Count > 0)
                {
                    lista.Add(nodo.Text);
                    // Agregar todos los hijos
                    foreach (TreeNode hijo in nodo.Nodes)
                    {
                        lista.Add(hijo.Text);
                    }
                }
                else
                {
                    lista.Add(nodo.Text);
                }
            }

            // Recorrer los hijos igualmente
            foreach (TreeNode hijo in nodo.Nodes)
            {
                // Ya no es raíz
                ProcesarNodoSeleccionado(hijo, lista, esRaiz: false);
            }
        }


        private void ObtenerSeleccionadosRecursivo(TreeNode nodo, List<string> lista)
        {
            lista.Add(nodo.Text);
            foreach (TreeNode hijo in nodo.Nodes)
            {
                ObtenerSeleccionadosRecursivo(hijo, lista); // recursión
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Asignar;
                HabilitarControles_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                txtCrear, btnCancelar, btnCrearRolFamilia, btnAplicar, btnSalir, btnEliminar, btnAsignar,  btnCrearRolFamilia, btnModificar
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
                if(modo_941lp == ModoOperacion_941lp.Modificar)
                {
                    if (rbPerfiles.Checked)
                    {
                        MostrarTreeViewPerfilUnico_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp().Find(x => x.nombrePermiso_941lp == comboBoxRolFamilia.Text));
                    }
                    if (rbFamilias.Checked)
                    {
                        MostrarTreeViewPerfilUnico_941lp(bllFamilia_941lp.RetornarFamilias_941lp().Find(x => x.nombrePermiso_941lp == comboBoxRolFamilia.Text));
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Quitar;
                HabilitarControles_941lp();
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

        private void rbVerPerfiles_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarComboBoxCompuestos_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
                MostrarTreeViewPerfil_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbVerFamilias_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarComboBoxCompuestos_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
                MostrarTreeViewPerfil_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                HabilitarControles_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
