using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormEstadoDeAdopcion_941lp : Form, IObserver_941lp
    {
        public FormEstadoDeAdopcion_941lp()
        {
            InitializeComponent();
        }

        private void AplicarTraduccion_941lp()
        {
            string idioma = sessionManager941lp.Gestor_941lp.Idioma_941lp;
            RecorrerControlesParaTraducir_941lp.TraducirControles_941lp(this, this.Name, idioma);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            TraductorSubject_941lp.Instancia_941lp.Desuscribir_941lp(this);
            base.OnFormClosed(e);
        }

        private void FormEstadoDeAdopcion_941lp_Load(object sender, EventArgs e)
        {

            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            AplicarTraduccion_941lp();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            string url = "https://docs.google.com/document/d/1j5AR3nS1CD2I-xyaW_7rPCf6-4WdFzHvhaq5q_U_rDQ/edit?tab=t.0#heading=h.ji2d5gnsovgn";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}
