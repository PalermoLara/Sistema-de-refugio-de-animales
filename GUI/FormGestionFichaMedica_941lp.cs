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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace GUI
{
    public partial class FormGestionFichaMedica_941lp : Form
    {
        bllRegistroAnimales_941lp bllRegistroAnimales_941Lp;
        ModoOperacion_941lp modo_941lp;
        public FormGestionFichaMedica_941lp()
        {
            InitializeComponent();
            bllRegistroAnimales_941Lp = new bllRegistroAnimales_941lp();
            modo_941lp = ModoOperacion_941lp.Consulta;
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void FormGestionFichaMedica_941lp_Load(object sender, EventArgs e)
        {
            dataAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnimales.MultiSelect = false;
            dataAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarDataAnimales_941lp(bllRegistroAnimales_941Lp.RetornarAnimales_941lp());
        }

        private void MostrarDataAnimales_941lp(List<Animal_941lp> animalLista_941lp)
        {
            dataAnimales.Rows.Clear();
            // Mostrar en la grilla
            foreach (Animal_941lp a_941lp in animalLista_941lp)
            {
                dataAnimales.Rows.Add(
                    a_941lp.codigoAnimal_941lp,
                    a_941lp.especie_941lp,
                    a_941lp.raza_941lp,
                    a_941lp.nombre_941lp,
                    a_941lp.tamaño_941lp,
                    a_941lp.sexo_941lp,
                    a_941lp.estadoAdopcion_941lp,
                    a_941lp.vivo_941lp
                );
            }
        }

        private void btnCrearFichaMedica_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Alta;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarFichaMedica_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:
                        ValidarCargaDeTxt_941lp();
                        MessageBox.Show("Cedente dado de alta exitosamente");
                        break;
                    case ModoOperacion_941lp.Modificar:
                        ValidarCargaDeTxt_941lp();
                        MessageBox.Show("Cedente modificado exitosamente");
                        break;
                    default:
                        MessageBox.Show("Error en la operación");
                        break;
                }
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ValidarCargaDeTxt_941lp()
        {
            bool radioSeleccionado = groupBoxCastrado.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            if (string.IsNullOrWhiteSpace(txtDieta.Text) ||
                string.IsNullOrWhiteSpace(txtObservaciones.Text) ||
                string.IsNullOrWhiteSpace(txtMedicamentos.Text) ||
                !radioSeleccionado)
            {
                throw new Exception("Debe completar todos los campos obligatorios.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                btnAplicar, btnModificarFichaMedica,btnCrearFichaMedica, btnSalir, txtMedicamentos, txtDieta, txtObservaciones, groupBoxCastrado
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

        private void LimpiarTxt_941lp()
        {
            foreach (Control c_941lp in this.Controls)
            {
                if (c_941lp is TextBox t_941lp)
                {
                    t_941lp.Text = "";
                }
            }
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if (modo_941lp == ModoOperacion_941lp.Alta || modo_941lp == ModoOperacion_941lp.Modificar)
            {
                btnCancelar.Enabled = habilitar_941lp;
                btnAplicar.Enabled = habilitar_941lp;
                btnCrearFichaMedica.Enabled = !habilitar_941lp;
                btnModificarFichaMedica.Enabled = !habilitar_941lp;
                btnSalir.Enabled = !habilitar_941lp;
                groupBoxCastrado.Enabled = !habilitar_941lp;
            }
            else
            {
                btnCancelar.Enabled = !habilitar_941lp;
                btnAplicar.Enabled = !habilitar_941lp;
                btnCrearFichaMedica.Enabled = habilitar_941lp;
                btnModificarFichaMedica.Enabled = habilitar_941lp;
                btnSalir.Enabled = habilitar_941lp;
                groupBoxCastrado.Enabled = habilitar_941lp;
            }
            AplicarColorControles_941lp();
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            btnCrearFichaMedica.Enabled = true;
            btnModificarFichaMedica.Enabled = true;
            btnSalir.Enabled = true;
            AplicarColorControles_941lp();
            HabilitarTxt_941lp(false);
            LimpiarTxt_941lp();
        }
    }
}
