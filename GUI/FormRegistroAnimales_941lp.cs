using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormRegistroAnimales_941lp : Form
    {
        bllRegistroAnimales_941lp bllRegistroAnimales_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormRegistroAnimales_941lp()
        {
            InitializeComponent();
            modo_941lp = ModoOperacion_941lp.Consulta;
            bllRegistroAnimales_941lp = new bllRegistroAnimales_941lp();
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
            Reingreso,
            Baja
        }

        private void FormRegistroAnimales_941lp_Load(object sender, EventArgs e)
        {
            dataAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnimales.MultiSelect = false;
            dataAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarDataAnimales_941lp(bllRegistroAnimales_941lp.RetornarAnimales_941lp());
            HabilitarControlesDeIngresoDeDatos_941lp(false);
            HabilitarBotones_941lp();
        }

        private void MostrarDataAnimales_941lp(List<Animal_941lp> animalLista_941lp)
        {
            dataAnimales.Rows.Clear();
            IEnumerable<Animal_941lp> animalesFiltrados_941lp;

            if (rbEnEvaluacionAdopcion.Checked)
            {
                animalesFiltrados_941lp = animalLista_941lp.Where(a => a.estadoAdopcion_941lp == "En evaluación" && a.vivo_941lp != false);
            }
            else if (rbDisponibleAdopcion.Checked)
            {
                animalesFiltrados_941lp = animalLista_941lp.Where(a => a.estadoAdopcion_941lp == "Disponible" && a.vivo_941lp != false);
            }
            else if (rbAdoptado.Checked)
            {
                animalesFiltrados_941lp = animalLista_941lp.Where(a => a.estadoAdopcion_941lp == "Adoptado");
            }
            else // Si está seleccionado "Todos"
            {
                animalesFiltrados_941lp = animalLista_941lp;
            }

            // Mostrar en la grilla
            foreach (Animal_941lp a_941lp in animalesFiltrados_941lp)
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            this.Close();
        }

        private void btnAltaAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Alta;
                HabilitarControlesDeIngresoDeDatos_941lp(true);
                HabilitarBotones_941lp();
                LimpiarTxt_941lp();
                comboBoxEstado.SelectedIndex = 0;
                comboBoxVivo.SelectedIndex = 0;
                comboBoxEstado.Enabled = false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool ValidarCargaDeDatos_941lp()
        {
            if (modo_941lp == ModoOperacion_941lp.Reingreso)
                return !string.IsNullOrWhiteSpace(txtCodigo.Text) && comboBoxEstado.SelectedItem != null;

            return !string.IsNullOrWhiteSpace(txtEspecie.Text)
                && !string.IsNullOrWhiteSpace(txtRaza.Text)
                && !string.IsNullOrWhiteSpace(txtNombre.Text)
                && comboBoxTamaño.SelectedItem != null
                && comboBoxSexo.SelectedItem != null;
        }

        private void ControlDeIngresoDeDatos_941lp(string codigo_941lp = null,string especie_941lp = null, string raza_941lp = null, string nombre_941lp = null)
        {
            try
            {
                //Regex para el código
                if (codigo_941lp != null)
                {
                    var regexCodigo_941lp = new Regex(@"^\d{5}$");
                    if (!regexCodigo_941lp.IsMatch(codigo_941lp))
                        throw new ArgumentException("El código ingresado es inválido.Solo se permiten cinco números.");
                }
                // Regex reutilizables
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s]+$");
                if(especie_941lp!=null && raza_941lp != null && nombre_941lp != null)
                {
                    if (!regexTexto_941lp.IsMatch(especie_941lp))
                        throw new ArgumentException("La especie ingresada es inválida. Solo se permiten letras.");
                    if (!regexTexto_941lp.IsMatch(raza_941lp))
                        throw new ArgumentException("La raza ingresada es inválida. Solo se permiten letras.");
                    if (!regexTexto_941lp.IsMatch(nombre_941lp))
                        throw new ArgumentException("El nombre ingresado es inválido. Solo se permiten letras.");
                }
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Error de validación: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error inesperado durante la validación de datos.", ex);
            }
        }

        private void HabilitarControlesDeIngresoDeDatos_941lp(bool habilitar_941lp)
        {
            txtEspecie.Enabled = habilitar_941lp;
            txtNombre.Enabled = habilitar_941lp;
            txtRaza.Enabled = habilitar_941lp;
            comboBoxTamaño.Enabled = habilitar_941lp;
            comboBoxSexo.Enabled = habilitar_941lp;
            if(modo_941lp == ModoOperacion_941lp.Consulta)
            {
                txtCodigo.Enabled = habilitar_941lp;
                comboBoxEstado.Enabled = habilitar_941lp;
                comboBoxVivo.Enabled = habilitar_941lp;
            }
            else if (modo_941lp == ModoOperacion_941lp.Baja)
            {
                txtCodigo.Enabled = habilitar_941lp;
                comboBoxEstado.Enabled = habilitar_941lp;
                comboBoxVivo.Enabled = !habilitar_941lp;
            }
            else if (modo_941lp == ModoOperacion_941lp.Reingreso)
            {
                txtCodigo.Enabled = !habilitar_941lp;
                comboBoxEstado.Enabled = !habilitar_941lp;
                comboBoxVivo.Enabled = !habilitar_941lp;
            }
            else
            {
                comboBoxEstado.Enabled = habilitar_941lp;
                comboBoxVivo.Enabled = !habilitar_941lp;
                txtCodigo.Enabled = !habilitar_941lp;
            }
            AplicarColorControles_941lp();
        }

        private void HabilitarBotones_941lp()
        {
            bool modoDeOperacion_941lp = modo_941lp == ModoOperacion_941lp.Alta || modo_941lp == ModoOperacion_941lp.Modificar || modo_941lp == ModoOperacion_941lp.Reingreso || modo_941lp == ModoOperacion_941lp.Baja;
            btnAltaAnimal.Enabled = !modoDeOperacion_941lp;
            btnModificarAnimal.Enabled = !modoDeOperacion_941lp;
            btnReingreso.Enabled = !modoDeOperacion_941lp;
            btnBaja.Enabled = !modoDeOperacion_941lp;
            btnAplicar.Enabled = modoDeOperacion_941lp;
            btnCancelar.Enabled = modoDeOperacion_941lp;
            AplicarColorControles_941lp();
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                btnAltaAnimal, btnModificarAnimal, btnBaja, btnAplicar, btnCancelar, btnReingreso,
                txtEspecie, txtRaza, txtNombre, txtCodigo,
                comboBoxTamaño, comboBoxSexo, comboBoxEstado
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

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidarCargaDeDatos_941lp()==false) throw new Exception("Debe de ingresar todos los datos obligatorios");
                string codigoIngresado_941lp = " ";
                string especieIngresada_941lp = " ";
                string razaIngresada_941lp= " ";
                string nombreIngresado_941lp= " ";
                string tamañoIngresado_941lp = " ";
                string sexoIngresado_941lp = " ";
                string estadoDeAdopcionIngresado_941lp = " ";
                bool vivoIngresado_941lp = true;
                if(modo_941lp == ModoOperacion_941lp.Reingreso)
                {
                    estadoDeAdopcionIngresado_941lp = comboBoxEstado.SelectedItem.ToString();
                }
                else
                {
                    especieIngresada_941lp = txtEspecie.Text;
                    razaIngresada_941lp = txtRaza.Text;
                    nombreIngresado_941lp = txtNombre.Text;
                    tamañoIngresado_941lp = comboBoxTamaño.SelectedItem.ToString();
                    sexoIngresado_941lp = comboBoxSexo.SelectedItem.ToString();
                    estadoDeAdopcionIngresado_941lp = comboBoxEstado.SelectedItem.ToString();
                }
                    ControlDeIngresoDeDatos_941lp(especie_941lp: especieIngresada_941lp, raza_941lp: razaIngresada_941lp, nombre_941lp: nombreIngresado_941lp);
                HabilitarBotones_941lp();
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:
                        bllRegistroAnimales_941lp.AltaAnimal_941lp(especieIngresada_941lp, razaIngresada_941lp, nombreIngresado_941lp, tamañoIngresado_941lp, sexoIngresado_941lp, estadoDeAdopcionIngresado_941lp, vivoIngresado_941lp);
                        break;
                    case ModoOperacion_941lp.Modificar:
                        bllRegistroAnimales_941lp.Modificar_941lp(dataAnimales.SelectedRows[0].Cells[0].Value.ToString(),especieIngresada_941lp, razaIngresada_941lp, nombreIngresado_941lp, tamañoIngresado_941lp, sexoIngresado_941lp, estadoDeAdopcionIngresado_941lp);
                        break;
                    case ModoOperacion_941lp.Reingreso:
                        codigoIngresado_941lp = txtCodigo.Text;
                        ControlDeIngresoDeDatos_941lp(codigo_941lp : codigoIngresado_941lp);
                        if (bllRegistroAnimales_941lp.ValidarExistenciaAnimal_941lp(txtCodigo.Text) == false) throw new Exception("El animal no se encuentra registrado");
                        bllRegistroAnimales_941lp.Modificar_941lp(codigo_941lp : codigoIngresado_941lp,estadoDeAdopcion_941lp : estadoDeAdopcionIngresado_941lp);
                        break;
                    case ModoOperacion_941lp.Baja:
                        codigoIngresado_941lp = txtCodigo.Text;
                        if (comboBoxVivo.Text == "No")
                        {
                            vivoIngresado_941lp = false;
                        }
                        bllRegistroAnimales_941lp.Modificar_941lp(codigo_941lp: codigoIngresado_941lp, vivo_941lp :  vivoIngresado_941lp);
                        break;
                    default:
                        MessageBox.Show("Error");
                        break;
                }
                modo_941lp = ModoOperacion_941lp.Consulta;
                LimpiarTxt_941lp();
                MostrarDataAnimales_941lp(bllRegistroAnimales_941lp.RetornarAnimales_941lp());
                HabilitarControlesDeIngresoDeDatos_941lp(false);
                HabilitarBotones_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
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
            comboBoxTamaño.SelectedItem = null;
            comboBoxSexo.SelectedItem = null;
            comboBoxEstado.SelectedItem = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Consulta;
                HabilitarBotones_941lp();
                HabilitarControlesDeIngresoDeDatos_941lp(false);
                comboBoxVivo.SelectedItem = null;
                comboBoxEstado.SelectedItem = null;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarAnimal_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                HabilitarControlesDeIngresoDeDatos_941lp(true);
                HabilitarBotones_941lp();
                comboBoxEstado.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataAnimales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (modo_941lp != ModoOperacion_941lp.Alta)
                {
                    txtCodigo.Text = dataAnimales.SelectedRows[0].Cells[0].Value.ToString();
                    txtEspecie.Text = dataAnimales.SelectedRows[0].Cells[1].Value.ToString();
                    txtRaza.Text = dataAnimales.SelectedRows[0].Cells[2].Value.ToString();
                    txtNombre.Text = dataAnimales.SelectedRows[0].Cells[3].Value.ToString();
                    comboBoxTamaño.SelectedItem = dataAnimales.SelectedRows[0].Cells[4].Value.ToString();
                    comboBoxSexo.SelectedItem = dataAnimales.SelectedRows[0].Cells[5].Value.ToString();
                    comboBoxEstado.SelectedItem = dataAnimales.SelectedRows[0].Cells[6].Value.ToString();
                    if (dataAnimales.SelectedRows[0].Cells[7].Value.ToString()=="True")
                    {
                        comboBoxVivo.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxVivo.SelectedIndex = 1;
                    }
                } 
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RadioButtonFiltro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarDataAnimales_941lp(bllRegistroAnimales_941lp.RetornarAnimales_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnReingreso_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Reingreso;
                HabilitarControlesDeIngresoDeDatos_941lp(false);
                HabilitarBotones_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr_941lp = MessageBox.Show("¿Está seguro que desea dar de baja al animal?", "FALLECIMIENTO", MessageBoxButtons.YesNo);
                if(dr_941lp == DialogResult.Yes)
                {
                    modo_941lp = ModoOperacion_941lp.Baja;
                    HabilitarControlesDeIngresoDeDatos_941lp(false);
                    HabilitarBotones_941lp();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
