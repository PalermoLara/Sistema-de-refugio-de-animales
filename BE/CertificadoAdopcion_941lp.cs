using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CertificadoAdopcion_941lp
    {
        public CertificadoAdopcion_941lp(string pCod_941lp, string pDni_941lp, int pCodAnimal_941lp, string pEspecie_941lp, string pRaza_941lp, string pNombreAn_941lp, string pNombreAdop_941lp, string pApellidoAdop, DateTime pFecha_941lp)
        {
            codigo_941lp = pCod_941lp;
            dni_941lp = pDni_941lp;
            codigoAnimal_941lp = pCodAnimal_941lp;
            especie_941lp = pEspecie_941lp;
            raza_941lp = pRaza_941lp;
            nombreAnimal_941lp = pNombreAn_941lp;
            nombreAdoptante_941lp = pNombreAdop_941lp;
            apellidoAdoptante_941lp = pApellidoAdop;
            fecha_941lp = pFecha_941lp;
        }

        public string codigo_941lp { get; set; }
        public string dni_941lp { get; set; }
        public int codigoAnimal_941lp { get; set; }
        public string especie_941lp { get; set; }
        public string raza_941lp { get; set; }
        public string nombreAnimal_941lp { get; set; }
        public string nombreAdoptante_941lp { get; set; }
        public string apellidoAdoptante_941lp { get; set; }
        public DateTime fecha_941lp { get; set; }
    }
}
