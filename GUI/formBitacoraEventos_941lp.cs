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

namespace GUI
{
    public partial class formBitacoraEventos_941lp : Form
    {
        bllBitacoraEventos_941lp bllBitacora_941lp;
        public formBitacoraEventos_941lp()
        {
            InitializeComponent();
            bllBitacora_941lp = new bllBitacoraEventos_941lp();
            MostrarEventos_941lp(bllBitacora_941lp.RetornarEventos_941lp());
        }

        private void MostrarEventos_941lp(List<Evento_941lp> eventosLista_941lp)
        {
            dataEventos.Rows.Clear();
            if (eventosLista_941lp != null)
            {
                foreach (Evento_941lp e_941lp in eventosLista_941lp)
                {
                    dataEventos.Rows.Add(e_941lp.dni_941lp, e_941lp.fecha_941lp, e_941lp.hora_941lp, e_941lp.modulo_941lp, e_941lp.evento_941lp,e_941lp.criticidad_941lp);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void formBitacoraEventos_941lp_Load(object sender, EventArgs e)
        {
            MostrarEventos_941lp(bllBitacora_941lp.RetornarEventos_941lp());
        }
    }
}
