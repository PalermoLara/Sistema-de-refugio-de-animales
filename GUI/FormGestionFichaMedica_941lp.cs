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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using RadioButton = System.Windows.Forms.RadioButton;

namespace GUI
{
    public partial class FormGestionFichaMedica_941lp : Form
    {
        private FormBitocoraFichaMedica_941lp FormBitocoraFichaMedica_941lp; 
        bllRegistroAnimales_941lp bllRegistroAnimales_941Lp;
        bllMedicamento_941lp bllMedicamento_941lp;
        bllFichaMedica_941lp bllFichaMedica_941lp;
        bllBitacoraFichaMedica_941lp bllBitacora_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormGestionFichaMedica_941lp()
        {
            InitializeComponent();
            bllRegistroAnimales_941Lp = new bllRegistroAnimales_941lp();
            bllMedicamento_941lp = new bllMedicamento_941lp();
            bllFichaMedica_941lp = new bllFichaMedica_941lp();
            bllBitacora_941lp = new bllBitacoraFichaMedica_941lp ();
            FormBitocoraFichaMedica_941lp = new FormBitocoraFichaMedica_941lp();
        }

        private void FormGestionFichaMedica_941lp_Load(object sender, EventArgs e)
        {
            dataAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnimales.MultiSelect = false;
            dataAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarDataAnimales_941lp(bllRegistroAnimales_941Lp.RetornarAnimales_941lp());
            dataMedicamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataMedicamentos.MultiSelect = false;
            dataMedicamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaMedicamentos_941lp(bllMedicamento_941lp.RetornarMedicamento_941lp());
            dataFichaMedica.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataFichaMedica.MultiSelect = false;
            dataFichaMedica.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaFicha_941lp(bllFichaMedica_941lp.RetornarFichas_941lp());
            modo_941lp = ModoOperacion_941lp.Consulta;
            HabilitarTxt_941lp(true);
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            AplicarColorControles_941lp();
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
            DefinirEstado
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            this.Close();
        }

        private void MostrarGrillaMedicamentos_941lp(List<Medicamento_941lp> medicamentosLista_941lp)
        {
            dataMedicamentos.Rows.Clear();
            if (medicamentosLista_941lp != null)
            {
                foreach (Medicamento_941lp m_941lp in medicamentosLista_941lp)
                {
                    dataMedicamentos.Rows.Add(m_941lp.numeroOficial_941lp, m_941lp.nombreComercial_941lp, m_941lp.nombreGenerico_941lp, m_941lp.forma_941lp,  m_941lp.caducidad_941lp);
                    dataMedicamentos.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
        }

        private void MostrarGrillaFicha_941lp(List<FichaMedica_941lp> fichas_941lp)
        {
            dataFichaMedica.Rows.Clear();
            if (fichas_941lp != null)
            {
                foreach (FichaMedica_941lp f_941lp in fichas_941lp)
                {
                    dataFichaMedica.Rows.Add(f_941lp.codigo_941lp, f_941lp.codigoAnimal_941lp, f_941lp.fecha_941lp, f_941lp.castrado_941lp, f_941lp.dieta_941lp, f_941lp.medicamento_941lp, f_941lp.observaciones_941lp);
                    dataFichaMedica.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
        }

        private void MostrarDataAnimales_941lp(List<Animal_941lp> animalLista_941lp)
        {
            dataAnimales.Rows.Clear();
            // Mostrar en la grilla
            foreach (Animal_941lp a_941lp in animalLista_941lp)
            {
                if(a_941lp.estadoAdopcion_941lp != "Adoptado")
                {
                    int rowIndex_941lp = dataAnimales.Rows.Add(a_941lp.codigoAnimal_941lp,a_941lp.especie_941lp,a_941lp.raza_941lp,a_941lp.nombre_941lp,a_941lp.tamaño_941lp,a_941lp.sexo_941lp,a_941lp.estadoAdopcion_941lp, a_941lp.vivo_941lp);
                    if(a_941lp.vivo_941lp == false)
                    {
                        dataAnimales.Rows[rowIndex_941lp].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void btnCrearFichaMedica_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Alta;
                HabilitarTxt_941lp(true);
                VisibilidadDeBotones_941lp();
                LimpiarTxt_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarFichaMedica_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                HabilitarTxt_941lp(true);
                VisibilidadDeBotones_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ControlDeIngresoDeDatos_941lp(string dieta_941lp ="", string observaciones_941lp = "")
        {
            try
            {
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s.,]+$");
                if(dieta_941lp!="")
                {
                    if (!regexTexto_941lp.IsMatch(dieta_941lp))
                        throw new ArgumentException("La dieta ingresada es inválida. Solo se permiten letras y espacios.");
                }
                if(observaciones_941lp!="")
                {
                    if (!regexTexto_941lp.IsMatch(observaciones_941lp))
                        throw new ArgumentException("La observación ingresada es inválida. Solo se permiten letras y espacios.");
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

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCargaDeTxt_941lp();
                ControlDeIngresoDeDatos_941lp(txtDieta.Text, txtObservaciones.Text);
                RadioButton seleccionado_941lp = groupBoxCastrado.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:
                        if (bllFichaMedica_941lp.VerificarAnimalVivo_941lp(Convert.ToBoolean(dataAnimales.SelectedRows[0].Cells[7].Value)) == false) throw new Exception("El animal debe estar vivo para realizar la revisión médica");
                        MessageBox.Show("Debe selecionar un estado al animal", "ESTADO DE ADOPCIÓN", MessageBoxButtons.OK);
                        break;
                    case ModoOperacion_941lp.Modificar:
                        if (bllBitacora_941lp.VerificarCambioValor_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value),"Medicamento", checkBoxMedicamentos.Checked ? "" : dataMedicamentos.SelectedRows[0].Cells[2].Value.ToString())) 
                        {
                            bllBitacora_941lp.Alta_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value), DateTime.Now, ModoOperacion_941lp.Modificar.ToString(), "Medicamento", dataFichaMedica.SelectedRows[0].Cells[5].Value.ToString(), txtDieta.Text);
                        }
                        if (bllBitacora_941lp.VerificarCambioValor_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value),"Castrado", seleccionado_941lp.Text))
                        {
                            bllBitacora_941lp.Alta_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value), DateTime.Now, ModoOperacion_941lp.Modificar.ToString(), "Castrado", dataFichaMedica.SelectedRows[0].Cells[3].Value.ToString(), seleccionado_941lp.Text);
                        }
                        if (bllBitacora_941lp.VerificarCambioValor_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value),"Dieta", txtDieta.Text))
                        {
                            bllBitacora_941lp.Alta_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value), DateTime.Now, ModoOperacion_941lp.Modificar.ToString(), "Dieta", dataFichaMedica.SelectedRows[0].Cells[4].Value.ToString(), txtDieta.Text);
                        }
                        if (bllBitacora_941lp.VerificarCambioValor_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value),"Observaciones", txtObservaciones.Text))
                        {
                            bllBitacora_941lp.Alta_941lp(Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value), DateTime.Now, ModoOperacion_941lp.Modificar.ToString(), "Observaciones", dataFichaMedica.SelectedRows[0].Cells[6].Value.ToString(), txtObservaciones.Text);
                        }
                        bllFichaMedica_941lp.Modificar_941lp(codigo_941lp: Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value), castrado_941lp: seleccionado_941lp.Text == "Si", dieta_941lp: txtDieta.Text, medicamento_941lp: checkBoxMedicamentos.Checked ? null : dataMedicamentos.SelectedRows[0].Cells[2].Value.ToString(), observaciones_941lp: txtObservaciones.Text);
                        MessageBox.Show("Ficha médica modificada exitosamente");
                        break;
                    case ModoOperacion_941lp.DefinirEstado:
                        RadioButton estado_941lp = groupBoxEstadoAdopcion.Controls.OfType<RadioButton>().FirstOrDefault(rb => rb.Checked);
                        if (estado_941lp == null) throw new Exception("Debe seleccionar un estado");
                        bllRegistroAnimales_941Lp.Modificar_941lp(codigo_941lp: dataAnimales.SelectedRows[0].Cells[0].Value.ToString(), estadoDeAdopcion_941lp: estado_941lp.Text);
                        MostrarDataAnimales_941lp(bllRegistroAnimales_941Lp.RetornarAnimales_941lp());
                        bllFichaMedica_941lp.Alta_941lp(codigoAnimal_941lp : Convert.ToInt32(dataAnimales.SelectedRows[0].Cells[0].Value),fecha_941lp : DateTime.Now,castrado_941lp : seleccionado_941lp.Text == "Si",dieta_941lp : txtDieta.Text,medicamento_941lp : checkBoxMedicamentos.Checked ? null : dataMedicamentos.SelectedRows[0].Cells[2].Value.ToString(),observaciones_941lp : txtObservaciones.Text);
                        bllBitacora_941lp.Alta_941lp(codigoFicha_941lp: Convert.ToInt32(dataFichaMedica.SelectedRows[0].Cells[0].Value), fecha_941lp: DateTime.Now, operacion_941lp: ModoOperacion_941lp.Alta.ToString());
                        MessageBox.Show("Ficha médica dada de alta exitosamente");
                        break;
                    default:
                        MessageBox.Show("Error en la operación");
                        break;
                }
                if(modo_941lp != ModoOperacion_941lp.Alta)
                {
                    ModoAceptarCancelar_941lp();
                    MostrarGrillaFicha_941lp(bllFichaMedica_941lp.RetornarFichas_941lp());
                }
                else
                {
                    modo_941lp = ModoOperacion_941lp.DefinirEstado;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ValidarCargaDeTxt_941lp()
        {
            bool radioSeleccionado = groupBoxCastrado.Controls.OfType<RadioButton>().Any(rb => rb.Checked);
            if (!radioSeleccionado)
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
                btnAplicar, btnModificarFichaMedica,btnCancelar,btnCrearFichaMedica, btnSalir, txtDieta, txtObservaciones, groupBoxCastrado
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
            rbNoCastrado.Checked = false;
            rbSiCastrado.Checked = false;
        }

        private void VisibilidadDeBotones_941lp()
        {
            btnCrearFichaMedica.Enabled = false;
            btnModificarFichaMedica.Enabled = false;
            btnSalir.Enabled = false;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
            AplicarColorControles_941lp();
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if (modo_941lp == ModoOperacion_941lp.Alta || modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtDieta.Enabled = habilitar_941lp;
                txtObservaciones.Enabled = habilitar_941lp;
                groupBoxCastrado.Enabled = habilitar_941lp;
                if(modo_941lp == ModoOperacion_941lp.Alta)
                {
                    groupBoxEstadoAdopcion.Enabled = habilitar_941lp;
                }
                else
                {
                    groupBoxEstadoAdopcion.Enabled = !habilitar_941lp;
                }
            }
            else
            {
                txtDieta.Enabled = !habilitar_941lp;
                txtObservaciones.Enabled = !habilitar_941lp;
                groupBoxCastrado.Enabled = !habilitar_941lp;
                groupBoxEstadoAdopcion.Enabled = !habilitar_941lp;
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

        private void dataFichaMedica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (modo_941lp != ModoOperacion_941lp.Alta)
                {
                    if (dataFichaMedica.SelectedRows[0].Cells[3].Value.ToString() == "Si")
                    {
                        rbSiCastrado.Checked = true;
                        rbNoCastrado.Checked = false;
                    }
                    else
                    {
                        rbSiCastrado.Checked = false;
                        rbNoCastrado.Checked = true;
                    }
                    txtDieta.Text = dataFichaMedica.SelectedRows[0].Cells[4].Value.ToString();
                    txtObservaciones.Text = dataFichaMedica.SelectedRows[0].Cells[6].Value.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBitacoraFichaMedica_Click(object sender, EventArgs e)
        {
            FormBitocoraFichaMedica_941lp.ShowDialog();
        }
    }
}
