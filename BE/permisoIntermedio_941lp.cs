using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class permisoIntermedio_941lp
    {
        public permisoIntermedio_941lp(string PnombrePermisoCompuesto_941lp, string PpermisoAñadido_941lp)
        {
            nombrePermisoCompuesto941lp = PnombrePermisoCompuesto_941lp;
            permisoAñadido941lp = PpermisoAñadido_941lp;
        }

        public string nombrePermisoCompuesto941lp { get; set; }
        public string permisoAñadido941lp { get; set; }
    }
}
