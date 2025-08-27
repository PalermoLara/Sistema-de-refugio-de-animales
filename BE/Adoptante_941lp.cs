using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Adoptante_941lp
    {
        public Adoptante_941lp(string pDni_941lp, string pNombre_941lp, string pApellido_941lp,  string pTelefono_941lp, int pEdad_941lp, string pDomicilio_941lp, bool pMascotas_941lp, bool pActivo_941lp)
        {
            dni_941lp = pDni_941lp;
            nombre_941lp = pNombre_941lp;
            apellido_941lp = pApellido_941lp;
            telefono_941lp = pTelefono_941lp;
            edad_941lp = pEdad_941lp;
            domicilio_941lp = pDomicilio_941lp;
            mascotas_941lp = pMascotas_941lp;
            activo_941lp = pActivo_941lp;
        }

        public string dni_941lp { get; set; }
        public string nombre_941lp { get; set; }
        public string apellido_941lp { get; set; }
        public string telefono_941lp { get; set; }
        public int edad_941lp { get; set; }
        public string domicilio_941lp { get; set; }
        public bool mascotas_941lp { get; set; }
        public bool activo_941lp { get; set; }
    }
}
