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

namespace GUI
{
    public partial class FormFichaDeIngreso_941lp : Form
    {
        bllCedente_941lp bllCedente_941lp;
        bllRegistroAnimales_941lp bllAnimal_941lp;
        public FormFichaDeIngreso_941lp()
        {
            InitializeComponent();
            bllAnimal_941lp = new bllRegistroAnimales_941lp();
            bllCedente_941lp = new bllCedente_941lp();
        }

        private void FormFichaDeIngreso_941lp_Load(object sender, EventArgs e)
        {
            dataCedentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataCedentes.MultiSelect = false;
            dataCedentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaCedentes_941lp(bllCedente_941lp.RetornarCedentes_941lp()); 
            dataAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnimales.MultiSelect = false;
            dataAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarDataAnimales_941lp(bllAnimal_941lp.RetornarAnimales_941lp());
        }

        private void MostrarDataAnimales_941lp(List<Animal_941lp> animalLista_941lp)
        {
            dataAnimales.Rows.Clear();
            // Mostrar en la grilla
            foreach (Animal_941lp a_941lp in animalLista_941lp)
            {
                dataAnimales.Rows.Add(a_941lp.codigoAnimal_941lp,a_941lp.especie_941lp,a_941lp.raza_941lp,a_941lp.nombre_941lp,a_941lp.tamaño_941lp,a_941lp.sexo_941lp,a_941lp.estadoAdopcion_941lp,a_941lp.vivo_941lp);
            }
        }

        private void MostrarGrillaCedentes_941lp(List<Cedente_941lp> cedentesLista_941lp)
        {
            dataCedentes.Rows.Clear();
            if (cedentesLista_941lp != null)
            {
                foreach (Cedente_941lp c_941lp in cedentesLista_941lp)
                {
                    dataCedentes.Rows.Add(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp, c_941lp.direccion_941lp, c_941lp.telefono_941lp, c_941lp.activo_941lp);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
