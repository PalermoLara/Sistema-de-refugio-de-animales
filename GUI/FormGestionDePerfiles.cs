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
        public FormGestionDePerfiles_941lp()
        {
            InitializeComponent();
            bllPermisos_941lp = new bllPermisos_941lp();
        }

        private void FormGestionDePerfiles_Load(object sender, EventArgs e)
        {
            treeViewFamiliaRol.CheckBoxes = true;
            treeViewPermisos.CheckBoxes = true;
            MostrarPermisosTreePermisos_941lp(bllPermisos_941lp.RetornarPermisos_941lp());
            LlenarComboBoxCompuestos_941lp(comboBoxRolFamilia, bllPermisos_941lp.RetornarPermisos_941lp());
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
            TreeNode nodo_941lp = new TreeNode(permiso_941lp.nombrePermiso_941lp);
            if (permiso_941lp is Familia_941lp compuesto_941lp)
            {
                foreach (var hijo_941lp in compuesto_941lp.ObtenerPermisos())
                {
                    nodo_941lp.Nodes.Add(CrearNodoDesdePermiso(hijo_941lp));
                }
            }
            return nodo_941lp;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
