using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BitacoraCambio_941lp
    {
        public string codMedicamento_941lp { get; set; }
        public DateTime fechaHora_941lp { get; set; }
        public string nombreComercial_941lp { get; set; }
        public string nombreGenerico_941lp { get; set; }
        public string forma_941lp { get; set; }
        public DateTime caducidad_941lp { get; set; }
        public bool activoMedicamento_941lp { get; set; }
        public bool activo_941lp { get; set; }

        public BitacoraCambio_941lp(string pCodMedicamento_941lp, DateTime pFechaHora_941lp, string pNombreComercial_941lp, string pNombreGenerico_941lp,string pForma_941lp, DateTime pCaducidad_941lp,bool pActivoMedic_941lp ,bool pActivo_941lp )
        {
            codMedicamento_941lp = pCodMedicamento_941lp;
            fechaHora_941lp = pFechaHora_941lp;
            nombreComercial_941lp = pNombreComercial_941lp;
            nombreGenerico_941lp = pNombreGenerico_941lp;
            forma_941lp = pForma_941lp;
            caducidad_941lp = pCaducidad_941lp;
            activoMedicamento_941lp = pActivoMedic_941lp;
            activo_941lp = pActivo_941lp;
        }
    }
}
