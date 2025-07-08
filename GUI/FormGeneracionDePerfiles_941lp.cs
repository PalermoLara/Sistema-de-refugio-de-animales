using BE;
using BLL;
using SERVICIOS;
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
using ComboBox = System.Windows.Forms.ComboBox;

namespace GUI
{
    public partial class FormGestionDePerfiles_941lp : Form, IObserver_941lp
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
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }

        private void AplicarTraduccion_941lp()
        {
            string idioma_941lp = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            TraductorHelper_941lp.TraducirControles_941lp(this, this.Name, idioma_941lp);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Desuscribir_941lp(this);
            base.OnFormClosed(e);
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
            modo_941lp = ModoOperacion_941lp.Consulta;
            treeViewFamiliaRol.CheckBoxes = true;
            treeViewFamilia.CheckBoxes = true;
            treeViewPermisos.CheckBoxes = true;
            MostrarPermisosTreePermisos_941lp(bllPermisos_941lp.RetornarPermisos_941lp());
            LlenarComboBoxCompuestos_941lp(comboBoxFamilia, bllFamilia_941lp.RetornarFamilias_941lp());
            LlenarComboBoxCompuestos_941lp(comboBoxPerfiles, bllPerfil_941Lp.RetornarPerfiles_941lp());
            MostrarTreeViewPerfil_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
            MostrarPermisosTreeFamilia_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
        }

        private void MostrarPermisosTreeFamilia_941lp(List<Perfil_941lp> listaFamilias_941lp)
        {
            treeViewFamilia.Nodes.Clear();
            if (listaFamilias_941lp == null || listaFamilias_941lp.Count == 0)
                return;
            foreach (var perfil_941lp in listaFamilias_941lp)
            {
                if (perfil_941lp is Familia_941lp familia_941lp)
                {
                    TreeNode nodoRaiz = CrearNodoDesdePermiso(familia_941lp);
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
                if (perfil_941lp is Familia_941lp familia_941lp)
                {
                    TreeNode nodoRaiz_941lp = CrearNodoDesdePermiso(familia_941lp);
                    treeViewFamiliaRol.Nodes.Add(nodoRaiz_941lp);
                }
            }
        }

        private void MostrarTreeViewPerfilUnico_941lp(Perfil_941lp perfil_941lp)
        {
            treeViewFamiliaRol.Nodes.Clear();
            if (perfil_941lp is Familia_941lp familia_941lp)
            {
                TreeNode nodoRaiz_941lp = CrearNodoDesdePermiso(familia_941lp);
                treeViewFamiliaRol.Nodes.Add(nodoRaiz_941lp);
            }
        }

        private void MostrarTreeViewFamiliaUnico_941lp(Perfil_941lp perfil_941lp)
        {
            treeViewFamilia.Nodes.Clear();
            if (perfil_941lp is Familia_941lp familia_941lp)
            {
                TreeNode nodoRaiz_941lp = CrearNodoDesdePermiso(familia_941lp);
                treeViewFamilia.Nodes.Add(nodoRaiz_941lp);
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

        private void LlenarComboBoxCompuestos_941lp(ComboBox comboBox_941lp,List<Perfil_941lp> listaPermisos_941lp)
        {
            comboBox_941lp.Items.Clear();
            foreach (var permiso_941lp in listaPermisos_941lp)
            {
                if(permiso_941lp.GetType() == typeof(Familia_941lp))
                comboBox_941lp.Items.Add(permiso_941lp.nombrePermiso_941lp);
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

            if (this.Owner is FormularioMenuPrincipal941lp menuForm_941lp)
            {
                menuForm_941lp.RefrescarPermisos_941lp();
            }
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
                comboBoxPerfiles.Enabled = false;
                comboBoxFamilia.Enabled = false;
                btnSalir.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnAsignar.Enabled = false;
                btnCrearRolFamilia.Enabled=false;
                treeViewFamiliaRol.Enabled = false;
            }
            else if(modo_941lp == ModoOperacion_941lp.Asignar || modo_941lp == ModoOperacion_941lp.Quitar || modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtCrear.Enabled = false;
                btnCrearRolFamilia.Enabled = false;
                btnAsignar.Enabled=false;
                btnEliminar.Enabled=false;
                comboBoxPerfiles.Enabled = true;
                comboBoxFamilia.Enabled = true;
                btnAplicar.Enabled = true;
                btnCancelar.Enabled = true;
                btnSalir.Enabled=false;
                btnModificar.Enabled=false;
                treeViewPermisos.Enabled = true;
                treeViewFamilia.Enabled = true;
                if(modo_941lp == ModoOperacion_941lp.Asignar)
                {
                    treeViewFamiliaRol.Enabled=true;
                }
                if (modo_941lp == ModoOperacion_941lp.Quitar)
                {
                    treeViewPermisos.Enabled = false;
                    treeViewFamilia.Enabled = false;
                    treeViewFamiliaRol.Enabled = false;
                }
                if (modo_941lp == ModoOperacion_941lp.Modificar)
                {
                    treeViewPermisos.Enabled = false;
                    treeViewFamilia.Enabled = true;
                    treeViewFamiliaRol.Enabled = true;
                }
            }
            else
            {
                btnAsignar.Enabled = true;
                btnAplicar.Enabled = false;
                btnCancelar.Enabled = false;
                txtCrear.Enabled = false;
                comboBoxPerfiles.Enabled = false;
                comboBoxFamilia.Enabled = false;
                btnSalir.Enabled = true;
                btnEliminar.Enabled = true;
                btnCrearRolFamilia.Enabled = true;
                btnModificar.Enabled = true;
                treeViewPermisos.Enabled = true;
                treeViewFamilia.Enabled = true;
                treeViewFamiliaRol.Enabled = true;
            }
            AplicarColorControles_941lp();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> seleccionados_941lp = ObtenerPermisosSeleccionadosDelTreeView();
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_NOMBRE_IGUAL_PERFIL", "Nombre igual al nombre de un perfil");
                if (bllPerfil_941Lp.VerificarNombreDePerfil_941lp(txtCrear.Text)) throw new Exception(exception_941lp);
                string exception1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_NOMBRE_IGUAL_FAMILIA", "Nombre igual al nombre de una familia");
                if (bllFamilia_941lp.VerificarNombreDeFamilia_941lp(txtCrear.Text)) throw new Exception(exception1_941lp);
                string exception2_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_NOMBRE_IGUAL_PERMISO", "Nombre igual al nombre de una patente");
                if (bllPermisos_941lp.VerificarNombreDePatente_941lp(txtCrear.Text)) throw new Exception(exception2_941lp);
                bllPerfil_941Lp.VerificarDuplicados_941lp(seleccionados_941lp);
                string nombrePerfilDestino_941lp = comboBoxPerfiles.Text;
                string nombreFamiliaDestino_941lp = comboBoxFamilia.Text;
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Crear:
                        string exception3_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_DATOS_FALTANTES", "Error. Debe ingresar todos los datos");
                        if (txtCrear.Text == "") throw new Exception(exception3_941lp);
                        if (rbPerfiles.Checked)
                        {
                            bllPerfil_941Lp.AltaPerfil_941lp(txtCrear.Text, seleccionados_941lp);
                        }
                        if (rbFamilias.Checked)
                        {
                            string exception4_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_FAMILIA_VACIA", "No puede crear una familia vacia");
                            if (seleccionados_941lp.Count == 0) throw new Exception(exception4_941lp);
                            bllFamilia_941lp.AltaFamilia_941lp(txtCrear.Text, seleccionados_941lp);
                        }
                        break;
                    case ModoOperacion_941lp.Asignar:
                        if (rbPerfiles.Checked)
                        {
                            string exception5_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_PERMISOS_REPETIDOS", "Permisos repetidos");
                            if (bllPerfil_941Lp.ValidarContraEstructuraEnMemoria_941lp(nombrePerfilDestino_941lp, seleccionados_941lp) == false) throw new Exception(exception5_941lp);
                            bllPerfilTablasIntermedias_941lp.AltaPerfilIntermedias_941lp(nombrePerfilDestino_941lp, seleccionados_941lp);
                        }
                        if (rbFamilias.Checked)
                        {
                            string exception6_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_PERMISOS_REPETIDOS", "Permisos repetidos");
                            if (bllPerfil_941Lp.ValidarContraEstructuraEnMemoria_941lp(nombreFamiliaDestino_941lp, seleccionados_941lp) == false) throw new Exception(exception6_941lp);
                            bllFamiliaTablasIntermedias_941lp.AltaFamiliaIntermedia_941lp(nombreFamiliaDestino_941lp, seleccionados_941lp);
                        }
                        break;
                    case ModoOperacion_941lp.Quitar:
                        if (rbPerfiles.Checked)
                        {
                            bllPerfil_941Lp.EliminarPerfil_941lp(nombrePerfilDestino_941lp);
                        }
                        if (rbFamilias.Checked)
                        {
                            bllFamilia_941lp.EliminarFamilia_941lp(nombreFamiliaDestino_941lp);
                        }
                        break;
                    case ModoOperacion_941lp.Modificar:
                        if (rbPerfiles.Checked)
                        {
                            List<string> listaModificarPerfil_941lp = ObtenerPermisosSeleccionadosDelTreeViewPerfilesParaModificar();
                            bllPerfilTablasIntermedias_941lp.EliminarPerfilIntermedia_941lp(nombrePerfilDestino_941lp, listaModificarPerfil_941lp);
                        }
                        if (rbFamilias.Checked)
                        {
                            List<string> listaModificarFamilia_941lp = ObtenerPermisosSeleccionadosDelTreeViewFamiliaParaModificar();
                            bllFamiliaTablasIntermedias_941lp.EliminarFamiliaIntermedia_941lp(nombreFamiliaDestino_941lp, listaModificarFamilia_941lp);
                        }
                        break;
                }
                modo_941lp = ModoOperacion_941lp.Consulta;
                HabilitarControles_941lp();
                comboBoxPerfiles.SelectedItem = null;
                comboBoxFamilia.SelectedItem = null;
                if (rbPerfiles.Checked)
                LlenarComboBoxCompuestos_941lp(comboBoxPerfiles,bllPerfil_941Lp.RetornarPerfiles_941lp());
                LlenarComboBoxCompuestos_941lp(comboBoxFamilia, bllFamilia_941lp.RetornarFamilias_941lp());
                MostrarPermisosTreeFamilia_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
                MostrarTreeViewPerfil_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
                DescheckearTodosLosNodos_941lp(treeViewPermisos);
                DescheckearTodosLosNodos_941lp(treeViewFamilia);
                DescheckearTodosLosNodos_941lp(treeViewFamiliaRol);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void DescheckearTodosLosNodos_941lp(System.Windows.Forms.TreeView treeView_941lp)
        {
            foreach (TreeNode nodo_941lp in treeView_941lp.Nodes)
            {
                DescheckearNodoRecursivo(nodo_941lp);
            }
        }

        private void DescheckearNodoRecursivo(TreeNode nodo_941lp)
        {
            nodo_941lp.Checked = false;

            foreach (TreeNode hijo_941lp in nodo_941lp.Nodes)
            {
                DescheckearNodoRecursivo(hijo_941lp);
            }
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

        private List<string> ObtenerPermisosSeleccionadosDelTreeViewPerfilesParaModificar()
        {
            List<string> seleccionados_941lp = new List<string>();

            foreach (TreeNode nodo in treeViewFamiliaRol.Nodes)
            {
                ProcesarNodoSeleccionado(nodo, seleccionados_941lp, esRaiz_941lp: true);
            }
            return seleccionados_941lp;
        }

        private List<string> ObtenerPermisosSeleccionadosDelTreeViewFamiliaParaModificar()
        {
            List<string> seleccionados_941lp = new List<string>();

            foreach (TreeNode nodo in treeViewFamilia.Nodes)
            {
                ProcesarNodoSeleccionado(nodo, seleccionados_941lp, esRaiz_941lp: true);
            }
            return seleccionados_941lp;
        }

        private void ProcesarNodoSeleccionado(TreeNode nodo_941lp, List<string> lista_941lp, bool esRaiz_941lp)
        {
            if (nodo_941lp.Checked)
            {
                if (esRaiz_941lp)
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormFichaDeIngreso_941lp", "MSG_NODO_RAIZ_SELECCIONADO", "No se puede seleccionar el nodo raíz.");
                    throw new InvalidOperationException(exception_941lp);
                }

                if (nodo_941lp.Nodes.Count > 0)
                {
                    lista_941lp.Add(nodo_941lp.Text);
                    // Agregar todos los hijos
                    foreach (TreeNode hijo_941lp in nodo_941lp.Nodes)
                    {
                        lista_941lp.Add(hijo_941lp.Text);
                    }
                }
                else
                {
                    lista_941lp.Add(nodo_941lp.Text);
                }
            }

            // Recorrer los hijos igualmente
            foreach (TreeNode hijo_941lp in nodo_941lp.Nodes)
            {
                // Ya no es raíz
                ProcesarNodoSeleccionado(hijo_941lp, lista_941lp, esRaiz_941lp: false);
            }
        }


        private void ObtenerSeleccionadosRecursivo(TreeNode nodo_941lp, List<string> lista_941lp)
        {
            lista_941lp.Add(nodo_941lp.Text);
            foreach (TreeNode hijo_941lp in nodo_941lp.Nodes)
            {
                ObtenerSeleccionadosRecursivo(hijo_941lp, lista_941lp); 
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
                    MostrarTreeViewPerfilUnico_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp().Find(x => x.nombrePermiso_941lp == comboBoxPerfiles.Text));
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
                comboBoxPerfiles.SelectedItem = null;
                comboBoxFamilia.SelectedItem = null;
                HabilitarControles_941lp();
                MostrarPermisosTreeFamilia_941lp(bllFamilia_941lp.RetornarFamilias_941lp());
                MostrarTreeViewPerfil_941lp(bllPerfil_941Lp.RetornarPerfiles_941lp());
                DescheckearTodosLosNodos_941lp(treeViewPermisos);
                DescheckearTodosLosNodos_941lp(treeViewFamilia);
                DescheckearTodosLosNodos_941lp(treeViewFamiliaRol);
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

        private void comboBoxFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(modo_941lp == ModoOperacion_941lp.Modificar)
                {
                    MostrarTreeViewFamiliaUnico_941lp(bllFamilia_941lp.RetornarFamilias_941lp().Find(x => x.nombrePermiso_941lp == comboBoxFamilia.Text));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbPerfiles_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxFamilia.Enabled = false;
                comboBoxPerfiles.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbFamilias_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                comboBoxPerfiles.Enabled = false;
                comboBoxFamilia.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }
    }
}
