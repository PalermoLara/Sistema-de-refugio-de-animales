using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Animal_941lp
    {
        public Animal_941lp(int pCodigoAnimal_941lp,string pEspecie_941lp, string pRaza_941lp, string pNombre_941lp, string pTamaño_941lp, string pSexo_941lp, string pEstadoDeAdopcion_941lp)
        {
            codigoAnimal_941lp = pCodigoAnimal_941lp;
            especie_941lp = pEspecie_941lp;
            raza_941lp = pRaza_941lp;
            nombre_941lp = pNombre_941lp;
            tamaño_941lp = pTamaño_941lp;
            sexo_941lp  = pSexo_941lp;
            estadoAdopcion_941lp = pEstadoDeAdopcion_941lp;
        }

        public int codigoAnimal_941lp { get; set; }
        public string especie_941lp { get; set; }
        public string raza_941lp { get; set; }
        public string nombre_941lp { get; set; }
        public string tamaño_941lp { get; set; }
        public string sexo_941lp { get; set; }
        public string estadoAdopcion_941lp { get; set; }
    }
}
