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

namespace GUI
{
    public partial class FormCertificadoDeAdopcion_941lp : Form, IObserver_941lp
    {
        bllCertificado_941lp bllCertificado_941lp;
        bllRegistroAnimales_941lp bllRegistroAnimales_941lp;
        bllAdoptantes_941lp bllAdoptantes_941lp;
        ModoOperacion_941lp modo_941lp;
        public FormCertificadoDeAdopcion_941lp()
        {
            InitializeComponent();
            bllCertificado_941lp = new bllCertificado_941lp();
            bllRegistroAnimales_941lp = new bllRegistroAnimales_941lp();
            bllAdoptantes_941lp = new bllAdoptantes_941lp();
        }

        private void FormCertificadoDeAdopcion_941lp_Load(object sender, EventArgs e)
        {
            dataCertificado.MultiSelect = false;
            dataCertificado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataCertificado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataAdoptantes.MultiSelect = false;
            dataAdoptantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAdoptantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataAnimales.MultiSelect = false;
            dataAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarGrillaAdoptantes_941lp(bllAdoptantes_941lp.RetornarAdoptantes_941lp());
            MostrarGrillaCertificado_941lp(bllCertificado_941lp.RetornarCertificado_941lp());
            MostrarDataAnimales_941lp(bllRegistroAnimales_941lp.RetornarAnimales_941lp());
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

        private void MostrarDataAnimales_941lp(List<Animal_941lp> animalLista_941lp)
        {
            dataAnimales.Rows.Clear();
            foreach (Animal_941lp a_941lp in animalLista_941lp)
            {
                int rowIdex_941lp = dataAnimales.Rows.Add(a_941lp.codigoAnimal_941lp, a_941lp.especie_941lp, a_941lp.raza_941lp, a_941lp.nombre_941lp, a_941lp.tamaño_941lp, a_941lp.sexo_941lp, a_941lp.estadoAdopcion_941lp, a_941lp.vivo_941lp);
                if (a_941lp.vivo_941lp == false)
                {
                    dataAnimales.Rows[rowIdex_941lp].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void MostrarGrillaAdoptantes_941lp(List<Adoptante_941lp> adoptantesLista_941lp)
        {
            dataAdoptantes.Rows.Clear();
            if (adoptantesLista_941lp != null)
            {
                foreach (Adoptante_941lp c_941lp in adoptantesLista_941lp)
                {
                    int intIndex_941lp = dataAdoptantes.Rows.Add(c_941lp.dni_941lp, c_941lp.nombre_941lp, c_941lp.apellido_941lp, c_941lp.telefono_941lp, c_941lp.edad_941lp, c_941lp.domicilio_941lp, c_941lp.mascotas_941lp, c_941lp.activo_941lp);
                    if (c_941lp.activo_941lp == false)
                    {
                        dataAdoptantes.Rows[intIndex_941lp].DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }

        private void MostrarGrillaCertificado_941lp(List<CertificadoAdopcion_941lp> certificadosLista_941lp)
        {
            dataCertificado.Rows.Clear();
            if (certificadosLista_941lp != null)
            {
                foreach (CertificadoAdopcion_941lp c_941lp in certificadosLista_941lp)
                {
                    dataCertificado.Rows.Add(c_941lp.codigo_941lp, c_941lp.dni_941lp, c_941lp.codigoAnimal_941lp, c_941lp.especie_941lp, c_941lp.raza_941lp, c_941lp.nombreAnimal_941lp, c_941lp.nombreAdoptante_941lp, c_941lp.apellidoAdoptante_941lp, c_941lp.fecha_941lp);
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

        private void btnGenerarCertificado_Click(object sender, EventArgs e)
        {
            try
            {
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_ADOPTANTE_MUERTO", "El adoptante debe estar vivo para realizar el certificado");
                if (bllAdoptantes_941lp.VerificarAdoptanteVivo_941lp(Convert.ToBoolean(dataAdoptantes.SelectedRows[0].Cells[7].Value)) == false) throw new Exception(exception_941lp);
                string exception1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_ANIMAL_MUERTO", "El animal debe estar vivo para realizar el certificado");
                if (bllRegistroAnimales_941lp.VerificarAnimalVivo_941lp(dataAnimales.SelectedRows[0].Cells[7].Value.ToString()) == false) throw new Exception(exception1_941lp);
                modo_941lp = ModoOperacion_941lp.Alta;
                VisibilidadDeBotones_941lp();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            this.Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (modo_941lp)
                {
                    case ModoOperacion_941lp.Alta:
                        bllCertificado_941lp.Alta_941lp(dataAdoptantes.SelectedRows[0].Cells[0].Value.ToString(), Convert.ToInt32(dataAnimales.SelectedRows[0].Cells[0].Value), dataAnimales.SelectedRows[0].Cells[1].Value.ToString(), dataAnimales.SelectedRows[0].Cells[2].Value.ToString(), dataAnimales.SelectedRows[0].Cells[3].Value.ToString(), dataAdoptantes.SelectedRows[0].Cells[1].Value.ToString(), dataAdoptantes.SelectedRows[0].Cells[2].Value.ToString());
                        string mensaje_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_CERTIFICADO_ALTA", "Certificado de adopción dado de alta exitosamente");
                        MessageBox.Show(mensaje_941lp);
                        break;
                    case ModoOperacion_941lp.Modificar:
                        bllCertificado_941lp.Modificar_941lp(dataCertificado.SelectedRows[0].Cells[0].Value.ToString(), dataAdoptantes.SelectedRows[0].Cells[0].Value.ToString(), Convert.ToInt32(dataAnimales.SelectedRows[0].Cells[0].Value), dataAnimales.SelectedRows[0].Cells[1].Value.ToString(), dataAnimales.SelectedRows[0].Cells[2].Value.ToString(), dataAnimales.SelectedRows[0].Cells[3].Value.ToString(), dataAdoptantes.SelectedRows[0].Cells[1].Value.ToString(), dataAdoptantes.SelectedRows[0].Cells[2].Value.ToString());
                        string mensaje1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_CERTIFICADO_MODIFICADO_EXITOSAMENTE", "Certificado modificada exitosamente");
                        MessageBox.Show(mensaje1_941lp);
                        break;
                    default:
                        string mensaje2_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_ERROR_EN_OPERACION", "Error en la operación");
                        MessageBox.Show(mensaje2_941lp);
                        break;
                }
                MostrarGrillaCertificado_941lp(bllCertificado_941lp.RetornarCertificado_941lp());
                ModoAceptarCancelar_941lp();
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
                btnAplicar, btnModificarEvaluacion,btnCancelar,btnGenerarCertificado, btnSalir
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

        private void VisibilidadDeBotones_941lp()
        {
            btnGenerarCertificado.Enabled = false;
            btnModificarEvaluacion.Enabled = false;
            btnSalir.Enabled = true;
            btnCancelar.Enabled = true;
            btnAplicar.Enabled = true;
            AplicarColorControles_941lp();
        }

        private void ModoAceptarCancelar_941lp()
        {
            modo_941lp = ModoOperacion_941lp.Consulta;
            btnCancelar.Enabled = false;
            btnAplicar.Enabled = false;
            btnGenerarCertificado.Enabled = true;
            btnModificarEvaluacion.Enabled = true;
            btnSalir.Enabled = true;
            AplicarColorControles_941lp();
        }

        private void btnModificarEvaluacion_Click(object sender, EventArgs e)
        {
            try
            {
                modo_941lp = ModoOperacion_941lp.Modificar;
                VisibilidadDeBotones_941lp();
                string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_ADOPTANTE_MUERTO", "El adoptante debe estar vivo para realizar el certificado");
                if (bllAdoptantes_941lp.VerificarAdoptanteVivo_941lp(Convert.ToBoolean(dataAdoptantes.SelectedRows[0].Cells[7].Value)) == false) throw new Exception(exception_941lp);
                string exception1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormCertificadoDeAdopcion_941lp", "MSG_ANIMAL_MUERTO", "El animal debe estar vivo para realizar el certificado");
                if (bllAdoptantes_941lp.VerificarAdoptanteVivo_941lp(Convert.ToBoolean(dataAnimales.SelectedRows[0].Cells[7].Value)) == false) throw new Exception(exception1_941lp);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
