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
    public partial class FormEstadoDeAdopcion_941lp : Form, IObserver_941lp
    {
        public FormEstadoDeAdopcion_941lp()
        {
            InitializeComponent();
            TraductorSubject_941lp.Instancia_941lp.Suscribir_941lp(this);
            AplicarTraduccion_941lp();
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

        }

        public void ActualizarTraduccion_941lp(string idioma_941lp)
        {
            throw new NotImplementedException();
        }
    }
}
