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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormEvaluacionDelAdoptante_941lp : Form, IObserver_941lp
    {
        bllEvaluacion_941lp bllEvaluacion_941lp;
        bllAdoptantes_941lp bllAdoptantes_941lp;
        bllDigitoVerificador_941lp bllDigitoVerificador_941Lp;
        ModoOperacion_941lp modo_941lp;
        public FormEvaluacionDelAdoptante_941lp()
        {
            InitializeComponent();
            bllEvaluacion_941lp = new bllEvaluacion_941lp();
            bllAdoptantes_941lp = new bllAdoptantes_941lp();
            bllDigitoVerificador_941Lp = new bllDigitoVerificador_941lp();
        }

        private void FormEvaluacionDelAdoptante_941lp_Load(object sender, EventArgs e)
        {
            dataAdoptantes.MultiSelect = false;
            dataAdoptantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAdoptantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataEvaluacion.MultiSelect = false;
            dataEvaluacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataEvaluacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            modo_941lp = ModoOperacion_941lp.Consulta;
            MostrarGrillaAdoptantes_941lp(bllAdoptantes_941lp.RetornarAdoptantes_941lp());
            MostrarGrillaEvaluaciones_941lp(bllEvaluacion_941lp.RetornarEvaluaciones_941lp());
            HabilitarTxt_941lp(true);
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            AplicarColorControles_941lp();
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }

        enum ModoOperacion_941lp
        {
            Consulta,
            Alta,
            Modificar,
            DefinirEstado
        }

        private void MostrarGrillaAdoptantes_941lp(List<Adoptante_941lp> adoptantesLista_941lp)
        {
            dataAdoptantes.Rows.Clear();
            if (adoptantesLista_941lp != null)
            {
                foreach (Adoptante_941lp c_941lp in adoptantesLista_941lp)
                {
                    if (c_941lp.activo_941lp == true)
                    {
                        int intIndex_941lp = dataAdoptantes.Rows.Add(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp, c_941lp.telefono_941lp, c_941lp.edad_941lp, c_941lp.domicilio_941lp, c_941lp.mascotas_941lp, c_941lp.activo_941lp);
                    }
                }
            }
        }

        private void MostrarGrillaEvaluaciones_941lp(List<EvaluacionAdoptante_941lp> evaluacionesLista_941lp)
        {
            dataEvaluacion.Rows.Clear();
            if (evaluacionesLista_941lp != null)
            {
                foreach (EvaluacionAdoptante_941lp c_941lp in evaluacionesLista_941lp)
                {
                    dataEvaluacion.Rows.Add(c_941lp.codigoEv_941lp, c_941lp.dni_941lp, c_941lp.motivo_941lp, c_941lp.condicionesEconomicas_941lp, c_941lp.vivienda_941lp);
                }
            }
        }

        private void AplicarTraduccion_941lp()
        {
            string idioma_941lp = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            RecorrerControlesParaTraducir_941lp.TraducirControles_941lp(this, this.Name, idioma_941lp);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Desuscribir_941lp(this);
            base.OnFormClosed(e);
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            ModoAceptarCancelar_941lp();
            this.Close();
        }

        private void btnGenerarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_ADOPTANTE_MUERTO", "El adoptante debe estar vivo para realizar la evaluación");
                if (bllAdoptantes_941lp.VerificarAdoptanteVivo_941lp(Convert.ToBoolean(dataAdoptantes.SelectedRows[0].Cells[7].Value)) == false) throw new Exception(exception_941lp);
                modo_941lp = ModoOperacion_941lp.Alta;
                HabilitarTxt_941lp(true);
                VisibilidadDeBotones_941lp();
                LimpiarTxt_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnModificarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                HabilitarTxt_941lp(true);
                VisibilidadDeBotones_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void ControlDeIngresoDeDatos_941lp(string motivo_941lp,string vivienda_941lp)
        {
            try
            {
                var regexTexto_941lp = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñÜü\s.,]+$");
                if (!regexTexto_941lp.IsMatch(motivo_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_MOTIVO_INVALIDO", "El motivo ingresado es inválida. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
                if (!regexTexto_941lp.IsMatch(vivienda_941lp))
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_VIVIENDA_INVALIDA", "La vivienda ingresada es inválida. Solo se permiten letras y espacios.");
                    throw new ArgumentException(exception_941lp);
                }
            }
            catch (ArgumentException ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_ERROR_VALIDACION", $"Error de validación");
                throw new Exception($"{exception_941lp}: {ex.Message}");
            }
            catch (Exception ex)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_ERROR_INNESPERADO", $"Ocurrió un error inesperado durante la validación de datos.");
                throw new Exception($"{exception_941lp}: {ex}");
            }
        }

        private void ValidarCargaDeTxt_941lp()
        {
            if (string.IsNullOrWhiteSpace(txtMotivo.Text) ||
                        string.IsNullOrWhiteSpace(txtVivienda.Text) ||
                        comboBoxCondicionEco.SelectedItem == null)
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_FALTA_COMPLETAR_CAMPOS", "Debe completar todos los campos obligatorios.");
                throw new Exception(exception_941lp);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCargaDeTxt_941lp();
                ControlDeIngresoDeDatos_941lp(txtMotivo.Text, txtVivienda.Text);
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:
                        bllEvaluacion_941lp.Alta_941lp(dataAdoptantes.SelectedRows[0].Cells[0].Value.ToString(), txtMotivo.Text, comboBoxCondicionEco.Text, txtVivienda.Text);
                        string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_EVALUACION_ALTA", "Evaluación dada de alta exitosamente");
                        MessageBox.Show(mensaje_941lp);
                        break;
                    case ModoOperacion_941lp.Modificar:
                        bllEvaluacion_941lp.Modificar_941lp(Convert.ToInt32(dataEvaluacion.SelectedRows[0].Cells[0].Value), dataAdoptantes.SelectedRows[0].Cells[0].Value.ToString(),txtMotivo.Text, comboBoxCondicionEco.Text, txtVivienda.Text);
                        string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_EVALUACION_MODIFICADA_EXITOSAMENTE", "Evaluación modificada exitosamente");
                        MessageBox.Show(mensaje1_941lp);
                        break;
                    default:
                        string mensaje2_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormEvaluacionDelAdoptante_941lp", "MSG_ERROR_EN_OPERACION", "Error en la operación");
                        MessageBox.Show(mensaje2_941lp);
                        break;
                }
                bllDigitoVerificador_941Lp.CalcularDVEvaluaciones_941lp();
                MostrarGrillaEvaluaciones_941lp(bllEvaluacion_941lp.RetornarEvaluaciones_941lp());
                ModoAceptarCancelar_941lp();
                CargarTxtConGrilla_941lp();
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

        private void AplicarColorControles_941lp()
        {
            var controles_941lp = new Control[]
            {
                btnAplicar, btnModificarEvaluacion,btnCancelar,btnGenerarEvaluacion, btnSalir, txtMotivo, txtVivienda, comboBoxCondicionEco
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

        private void VisibilidadDeBotones_941lp()
        {
            btnGenerarEvaluacion.Enabled = false;
            btnModificarEvaluacion.Enabled = false;
            btnSalir.Enabled = true;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
            AplicarColorControles_941lp();
        }

        private void HabilitarTxt_941lp(bool habilitar_941lp)
        {
            if (modo_941lp == ModoOperacion_941lp.Alta || modo_941lp == ModoOperacion_941lp.Modificar)
            {
                txtMotivo.Enabled = habilitar_941lp;
                txtVivienda.Enabled = habilitar_941lp;
                comboBoxCondicionEco.Enabled = habilitar_941lp;
            }
            else
            {
                txtMotivo.Enabled = !habilitar_941lp;
                txtVivienda.Enabled = !habilitar_941lp;
                comboBoxCondicionEco.Enabled = !habilitar_941lp;
            }
            AplicarColorControles_941lp();
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            btnGenerarEvaluacion.Enabled = true;
            btnModificarEvaluacion.Enabled = true;
            btnSalir.Enabled = true;
            AplicarColorControles_941lp();
            HabilitarTxt_941lp(true);
            LimpiarTxt_941lp();
        }

        private void dataEvaluacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarTxtConGrilla_941lp();
        }

        private void CargarTxtConGrilla_941lp()
        {
            if (modo_941lp != ModoOperacion_941lp.Alta)
            {
                txtMotivo.Text = dataEvaluacion.SelectedRows[0].Cells[2].Value.ToString();
                txtVivienda.Text = dataEvaluacion.SelectedRows[0].Cells[4].Value.ToString();
                comboBoxCondicionEco.SelectedItem = dataEvaluacion.SelectedRows[0].Cells[3].Value.ToString() == "Buena" ? comboBoxCondicionEco.SelectedIndex = 0 : comboBoxCondicionEco.SelectedIndex = 1;
            }
        }
    }
}
