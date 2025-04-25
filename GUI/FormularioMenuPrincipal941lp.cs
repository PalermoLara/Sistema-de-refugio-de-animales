using BE;
using BLL;
using Microsoft.VisualBasic;
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

namespace GUI
{
    public partial class FormularioMenuPrincipal941lp : Form
    {
        bllUsuario_941lp bllUsuario_941lp;
        private readonly FormAdministradorUsuario941lp formularioAdministradorUsuario_941lp;
        private readonly FormCambiarContraseña formularioCambiarContraseña_941lp;
        private List<Panel> submenus_941lp;

        public FormularioMenuPrincipal941lp()
        {
            InitializeComponent();
            InicializarSubmenus_941lp();
            bllUsuario_941lp = new bllUsuario_941lp();
            formularioAdministradorUsuario_941lp = new FormAdministradorUsuario941lp();
            formularioCambiarContraseña_941lp = new FormCambiarContraseña();
        }

        private void InicializarSubmenus_941lp()
        {
            submenus_941lp = new List<Panel>
            {
                panelSubMenuAdministrador,
                panelSubMenuMaestro,
                panelSubMenuUsuario,
                panelSubMenuAdopcion,
                panelSubMenuReportes
            };
            OcultarSubmenus_941lp();
        }

        private void OcultarSubmenus_941lp()
        {
            foreach (var panel_941lp in submenus_941lp)
                panel_941lp.Visible = false;
        }

        private void MostrarSubMenu_941lp(Panel submenu_941lp)
        {
            bool estabaVisible_941lp = submenu_941lp.Visible;
            OcultarSubmenus_941lp();
            submenu_941lp.Visible = !estabaVisible_941lp;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr_941lp = MessageBox.Show("¿Desea cerrar la sesión?", "CERRAR SESIÓN...", MessageBoxButtons.OKCancel);
                if(dr_941lp == DialogResult.OK)
                {
                    sessionManager941lp.Gestor_941lp.LogOut_941lp();
                    GestorFormulario941lp.gestorFormSG_941lp.DefinirEstado_941lp(new EstadoLogIn941lp());
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnGestionDeUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                formularioAdministradorUsuario_941lp.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                formularioCambiarContraseña_941lp.ShowDialog();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FormularioMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void btnUsuarioMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuUsuario);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAdministradorMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuAdministrador);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnMaestroMenuPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuMaestro);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuReportes);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAdopcion_Click(object sender, EventArgs e)
        {
            try
            {
                MostrarSubMenu_941lp(panelSubMenuAdopcion);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarSubmenus_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void panelMenuPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
