using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BitacoraFichaMedica_941lp
    {
        public BitacoraFichaMedica_941lp() { }

        public BitacoraFichaMedica_941lp(int pCodigo_941lp, int pCodigoFicha_941lp, DateTime pFecha_941lp, string pOperacion_941lp, string pCampoModificado_941lp, string pValorPrevio_941lp, string pValorNuevo_941lp)
        : this(pCodigoFicha_941lp, pFecha_941lp, pOperacion_941lp, pCampoModificado_941lp, pValorPrevio_941lp, pValorNuevo_941lp)
        {
            codigo_941lp = pCodigo_941lp;
        }

        public BitacoraFichaMedica_941lp(int pCodigoFicha_941lp, DateTime pFecha_941lp, string pOperacion_941lp, string pCampoModificado_941lp, string pValorPrevio_941lp, string pValorNuevo_941lp)
        {
            codigoFicha_941lp = pCodigoFicha_941lp;
            fecha_941lp = pFecha_941lp;
            operacion_941lp = pOperacion_941lp;
            campoModificado_941lp = pCampoModificado_941lp;
            valorPrevio_941lp = pValorPrevio_941lp;
            valorNuevo_941lp = pValorNuevo_941lp;
        }

        public int codigo_941lp { get; set; }
        public int codigoFicha_941lp { get; set; }
        public DateTime fecha_941lp { get; set; }
        public string operacion_941lp { get; set; }
        public string campoModificado_941lp { get; set; }
        public string valorPrevio_941lp { get; set; }
        public string valorNuevo_941lp { get; set; }
    }
}
