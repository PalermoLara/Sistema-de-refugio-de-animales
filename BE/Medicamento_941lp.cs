using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Medicamento_941lp
    {
        public Medicamento_941lp(int pNumeroOficial_941lp, string pNombreComercial_941lp, string pNombreGenerico_941lp, float pDosis_941lp, string pForma_941lp, int pLote_941lp, DateTime pCaducidad_941lp)
        {
            numeroOficial_941lp = pNumeroOficial_941lp;
            nombreComercial_941lp = pNombreComercial_941lp;
            nombreGenerico_941lp = pNombreGenerico_941lp;
            dosis_941lp = pDosis_941lp;
            forma_941lp = pForma_941lp;
            lote_941lp = pLote_941lp;
            caducidad_941lp = pCaducidad_941lp;
        }

        public int numeroOficial_941lp { get; set; }
        public string nombreComercial_941lp { get; set; }
        public string nombreGenerico_941lp { get; set; }
        public float dosis_941lp { get; set; }
        public string forma_941lp { get; set; }
        public int lote_941lp { get; set; }
        public DateTime caducidad_941lp { get; set; }
    }
}
