using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class EvaluacionAdoptante_941lp
    {
        public EvaluacionAdoptante_941lp(int pCod_941lp,string pDNI_941lp, string pMotivo_941lp, string pCondicionesEconomicas_941lp, string pVivienda_941lp)
        : this (pDNI_941lp,   pMotivo_941lp,  pCondicionesEconomicas_941lp,  pVivienda_941lp)
        {
            codigoEv_941lp = pCod_941lp;
        }

        public EvaluacionAdoptante_941lp(string pDNI_941lp,  string pMotivo_941lp,string pCondicionesEconomicas_941lp, string pVivienda_941lp)
        {
            dni_941lp = pDNI_941lp;
            motivo_941lp = pMotivo_941lp;
            condicionesEconomicas_941lp = pCondicionesEconomicas_941lp;
            vivienda_941lp = pVivienda_941lp;
        }
        public int codigoEv_941lp { get; set; }
        public string dni_941lp { get; set; }
        public string motivo_941lp { get; set; }
        public string condicionesEconomicas_941lp { get; set; }
        public string vivienda_941lp { get; set; }
    }
}
