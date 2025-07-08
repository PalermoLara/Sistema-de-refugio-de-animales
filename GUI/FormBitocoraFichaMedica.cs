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
    public partial class FormBitocoraFichaMedica_941lp : Form, IObserver_941lp
    {
        bllBitacoraFichaMedica_941lp bllBitacora_941lp;
        public FormBitocoraFichaMedica_941lp()
        {
            InitializeComponent();
            bllBitacora_941lp = new bllBitacoraFichaMedica_941lp();
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
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

        private void FormBitocoraFichaMedica_Load(object sender, EventArgs e)
        {
            dataBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataBitacora.MultiSelect = false;
            dataBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            MostrarBitacora_941lp(bllBitacora_941lp.RetornarBitacora_941lp());
        }

        private void MostrarBitacora_941lp(List<BitacoraFichaMedica_941lp> biracoraLista_941lp)
        {
            dataBitacora.Rows.Clear();
            if (biracoraLista_941lp != null)
            {
                foreach (BitacoraFichaMedica_941lp b_941lp in biracoraLista_941lp)
                {
                    dataBitacora.Rows.Add(b_941lp.codigo_941lp, b_941lp.codigoFicha_941lp, b_941lp.fecha_941lp, b_941lp.operacion_941lp, b_941lp.campoModificado_941lp, b_941lp.valorPrevio_941lp, b_941lp.valorNuevo_941lp);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }
    }
}
