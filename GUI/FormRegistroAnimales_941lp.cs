using BE;
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
    public partial class FormRegistroAnimales_941lp : Form
    {
        ModoOperacion_941lp modo_941lp;
        public FormRegistroAnimales_941lp()
        {
            InitializeComponent();
            modo_941lp = ModoOperacion_941lp.Consulta;
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
        }

        private void FormRegistroAnimales_941lp_Load(object sender, EventArgs e)
        {
            dataAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnimales.MultiSelect = false;
            dataAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HabilitarTxt_941lp(false);
        }

        private void MostrarDataAnimales_941lp(List<Animal_941lp> lista_941lp)
        {
            dataAnimales.Rows.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Alta;
                HabilitarTxt_941lp(true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ValidarCargaDeDatos_941lp()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEspecie.Text) ||
                        string.IsNullOrWhiteSpace(txtRaza.Text) ||
                        string.IsNullOrWhiteSpace(txtNombre.Text) ||
                        comboBoxTamaño.SelectedItem == null ||
                        comboBoxSexo.SelectedItem == null)
                {
                    throw new Exception("Debe completar todos los campos obligatorios.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            txtEspecie.Enabled = habilitar_941lp;
            txtNombre.Enabled = habilitar_941lp;
            txtRaza.Enabled = habilitar_941lp;
            comboBoxTamaño.Enabled = habilitar_941lp;
            comboBoxSexo.Enabled = habilitar_941lp;
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string especie_941lp = txtEspecie.Text;
                string raza_941lp = txtRaza.Text;
                string nombre_941lp = txtNombre.Text;
                string tamaño_941lp = comboBoxTamaño.SelectedItem.ToString(); 
                string sexo_941lp = comboBoxSexo.SelectedItem.ToString();
                bool estadoDeAdopcion_941lp = false;
                ValidarCargaDeDatos_941lp();
                switch(modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:

                        break;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                HabilitarTxt_941lp(false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
