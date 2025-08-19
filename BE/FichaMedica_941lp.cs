using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class FichaMedica_941lp
    {
        public FichaMedica_941lp(int pCodigo_941lp, int pCodigoAnimal_941lp, DateTime pFecha_941lp, bool pCastrado_941lp, string pDieta_941lp, string pMedicamentos_941lp, string pObservaciones_941lp)
        : this(pCodigoAnimal_941lp, pFecha_941lp,  pCastrado_941lp,  pDieta_941lp,  pMedicamentos_941lp,  pObservaciones_941lp)
        {
            codigo_941lp = pCodigo_941lp;
        }

        public FichaMedica_941lp(int pCodigoAnimal_941lp, DateTime pFecha_941lp, bool pCastrado_941lp, string pDieta_941lp, string pMedicamentos_941lp, string pObservaciones_941lp)
        {
            codigoAnimal_941lp = pCodigoAnimal_941lp;
            fecha_941lp = pFecha_941lp;
            castrado_941lp = pCastrado_941lp;
            dieta_941lp = pDieta_941lp;
            medicamento_941lp = pMedicamentos_941lp;
            observaciones_941lp = pObservaciones_941lp;
        }

        public int codigo_941lp { get; set; }
        public int codigoAnimal_941lp { get; set; }
        public DateTime fecha_941lp { get; set; }
        public bool castrado_941lp { get; set; }
        public string dieta_941lp { get; set; }
        public string medicamento_941lp { get; set; }
        public string observaciones_941lp { get; set; }
    }
}
