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
    public partial class FormBitocoraFichaMedica_941lp : Form
    {
        bllBitacoraFichaMedica_941lp bllBitacora_941lp;
        public FormBitocoraFichaMedica_941lp()
        {
            InitializeComponent();
            bllBitacora_941lp = new bllBitacoraFichaMedica_941lp();
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
    }
}
