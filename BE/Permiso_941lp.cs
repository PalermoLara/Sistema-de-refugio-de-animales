using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso_941lp
    {
        public Permiso_941lp(string pNombrePermiso_941lp, bool pEsRol_941lp, bool pEsCompuesto_941lp)
        {
            nombrePermiso_941lp = pNombrePermiso_941lp;
            esRol_941lp = pEsRol_941lp;
            esCompuesto_941lp = pEsCompuesto_941lp;
        }

        public string nombrePermiso_941lp { get; set; }
        public bool esRol_941lp { get; set; }
        public bool esCompuesto_941lp { get; set; }
    }
}
