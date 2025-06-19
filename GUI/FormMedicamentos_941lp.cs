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
    public partial class FormMedicamentos_941lp : Form
    {
        bllMedicamento_941lp bllMedicamento_941Lp;
        ModoOperacion_941lp modo_941lp;
        public FormMedicamentos_941lp()
        {
            InitializeComponent();
            bllMedicamento_941Lp = new bllMedicamento_941lp();
            modo_941lp = ModoOperacion_941lp.Consulta;
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
        }

        private void FormMedicamentos_941lp_Load(object sender, EventArgs e)
        {
            LimpiarTxt_941lp();
            dataMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataMedicamentos.MultiSelect = false;
            dataMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaMedicamentos_941lp(bllMedicamento_941Lp.RetornarMedicamento_941lp());
            HabilitarTxt_941lp(true);
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
            Baja
        }

        private void MostrarGrillaMedicamentos_941lp(List<Medicamento_941lp> medicamentosLista_941lp)
        {
            dataMedicamentos.Rows.Clear();
            if (medicamentosLista_941lp != null)
            {
                foreach (Medicamento_941lp m_941lp in medicamentosLista_941lp)
                {
                    int rowIndex = dataMedicamentos.Rows.Add(m_941lp.numeroOficial_941lp, m_941lp.nombreComercial_941lp, m_941lp.nombreGenerico_941lp, m_941lp.forma_941lp,  m_941lp.caducidad_941lp);
                    dataMedicamentos.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                    if (bllMedicamento_941Lp.VencimientoDeProducto_941lp(m_941lp.caducidad_941lp))
                    {
                        dataMedicamentos.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void VisibilidadDeBotones_941lp()
        {
            btnAltaMedicamento.Enabled = false;
            btnModificarMedicamento.Enabled = false;
            btnBaja.Enabled = false;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
            btnSalir.Enabled = false;
            AplicarColorControles_941lp();
        }

        private void ValidarCargaDeTxt_941lp()
        {
            bool camposObligatoriosIncompletos =
                string.IsNullOrWhiteSpace(txtNombreComercial.Text) ||
                string.IsNullOrWhiteSpace(txtNombreGenerico.Text) ||
                comboBoxForma.SelectedItem == null;
            if (modo_941lp == ModoOperacion_941lp.Alta)
            {
                //Si camposObligatoriosIncompletos ya era true, se queda en true. Si era false, toma el valor de la expresión de la derecha (string.IsNullOrWhiteSpace(...)).
                camposObligatoriosIncompletos |= string.IsNullOrWhiteSpace(txtNumero.Text);
            }
            if (camposObligatoriosIncompletos)
            {
                throw new Exception("Debe completar todos los campos obligatorios.");
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
            comboBoxForma.SelectedItem = null;
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            btnAltaMedicamento.Enabled = true;
            btnModificarMedicamento.Enabled = true;
            btnBaja.Enabled = true;
            btnSalir.Enabled = true;
            AplicarColorControles_941lp();
            HabilitarTxt_941lp(true);
            LimpiarTxt_941lp();
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if (modo_941lp == ModoOperacion_941lp.Alta)
            {
                txtNumero.Enabled = habilitar_941lp;
                txtNombreComercial.Enabled = habilitar_941lp;
                txtNombreGenerico.Enabled = habilitar_941lp;
                comboBoxForma.Enabled = habilitar_941lp;
                dateTimePickerVencimiento.Enabled = habilitar_941lp;
            }
            else if (modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtNumero.Enabled = !habilitar_941lp;
                txtNombreComercial.Enabled = habilitar_941lp;
                txtNombreGenerico.Enabled = habilitar_941lp;
                comboBoxForma.Enabled = habilitar_941lp;
                dateTimePickerVencimiento.Enabled = habilitar_941lp;
            }
            else
            {
                txtNumero.Enabled = !habilitar_941lp;
                txtNombreComercial.Enabled = !habilitar_941lp;
                txtNombreGenerico.Enabled = !habilitar_941lp;
                comboBoxForma.Enabled = !habilitar_941lp;
                dateTimePickerVencimiento.Enabled = !habilitar_941lp;
            }
            AplicarColorControles_941lp();
        }

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                btnAltaMedicamento, btnBaja, btnModificarMedicamento, btnSalir, btnCancelar,btnAplicar, txtNombreComercial, txtNumero, txtNombreGenerico
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

        private void ControlDeIngresoDeDatos_941lp(string numero_941lp, string nombreComercial_941lp, string nombreGenerico_941lp)
        {
            try
            {
                var regexNumero_941lp = new Regex(@"^\d{4,6}(\/\d{1,2})?$");
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s]+$");
                // Validaciones
                if (!regexNumero_941lp.IsMatch(numero_941lp))
                    throw new ArgumentException("El número ingresado es inválido. Solo se permiten números y barras.");
                if (!regexTexto_941lp.IsMatch(nombreComercial_941lp))
                    throw new ArgumentException("El nombre comercial ingresado es inválido. Solo se permiten letras y espacios.");
                if (!regexTexto_941lp.IsMatch(nombreGenerico_941lp))
                    throw new ArgumentException("El nombre genérico ingresado es inválido. Solo se permiten letras y espacios.");
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            this.Close();
        }

        private void btnAltaMedicamento_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Alta;
                LimpiarTxt_941lp();
                HabilitarTxt_941lp(true);
                VisibilidadDeBotones_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCargaDeTxt_941lp();
                ControlDeIngresoDeDatos_941lp(txtNumero.Text, txtNombreComercial.Text, txtNombreGenerico.Text);
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:
                        if(bllMedicamento_941Lp.VerificarExistenciaDeNumero_941lp(txtNumero.Text))throw new Exception("Número repetido");
                        if (bllMedicamento_941Lp.VencimientoDeProducto_941lp(dateTimePickerVencimiento.Value)) throw new Exception("Medicamento vencido");
                        bllMedicamento_941Lp.Alta_941lp(txtNumero.Text, txtNombreComercial.Text, txtNombreGenerico.Text, comboBoxForma.Text, dateTimePickerVencimiento.Value);
                        MessageBox.Show("Medicamento dado de alta exitosamente");
                        break;
                    case ModoOperacion_941lp.Modificar:
                        if (bllMedicamento_941Lp.VencimientoDeProducto_941lp(dateTimePickerVencimiento.Value)) throw new Exception("Medicamento vencido");
                        bllMedicamento_941Lp.Modificar_941lp(txtNumero.Text, txtNombreComercial.Text, txtNombreGenerico.Text, comboBoxForma.Text, dateTimePickerVencimiento.Value);
                        MessageBox.Show("Medicamento modificado exitosamente");
                        break;
                    case ModoOperacion_941lp.Baja:
                        bllMedicamento_941Lp.Baja_941lp(dataMedicamentos.SelectedRows[0].Cells[0].Value.ToString());
                        MessageBox.Show("Medicamento dado de baja con exito");
                        break;
                    default:
                        MessageBox.Show("Error en la operación");
                        break;
                }
                ModoAceptarCancelar_941lp();
                LimpiarTxt_941lp();
                MostrarGrillaMedicamentos_941lp(bllMedicamento_941Lp.RetornarMedicamento_941lp());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                ModoAceptarCancelar_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarMedicamento_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                CargarTxtConGrilla_941lp();
                VisibilidadDeBotones_941lp();
                HabilitarTxt_941lp(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Baja;
                HabilitarTxt_941lp(true);
                VisibilidadDeBotones_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataMedicamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CargarTxtConGrilla_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void CargarTxtConGrilla_941lp()
        {
            if (modo_941lp != ModoOperacion_941lp.Alta)
            {
                txtNumero.Text = dataMedicamentos.SelectedRows[0].Cells[0].Value.ToString();
                txtNombreComercial.Text = dataMedicamentos.SelectedRows[0].Cells[1].Value.ToString();
                txtNombreGenerico.Text = dataMedicamentos.SelectedRows[0].Cells[2].Value.ToString();
                comboBoxForma.SelectedItem = dataMedicamentos.SelectedRows[0].Cells[3].Value.ToString();
                dateTimePickerVencimiento.Value = Convert.ToDateTime(dataMedicamentos.SelectedRows[0].Cells[4].Value).Date;
            }
        }

        private void rbAscendente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarGrillaMedicamentos_941lp(bllMedicamento_941Lp.Ordenar_941lp("Ascendente"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void rbDescendente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarGrillaMedicamentos_941lp(bllMedicamento_941Lp.Ordenar_941lp("Descendente"));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
