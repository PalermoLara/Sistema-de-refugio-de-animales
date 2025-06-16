using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia_941lp : Permiso_941lp
    {
        private List<Permiso_941lp> listaPermisos_941lp;

        public Familia_941lp(string pNombrePermiso_941lp, bool pEsRol_941lp) : base(pNombrePermiso_941lp, pEsRol_941lp, true)
        {
            listaPermisos_941lp = new List<Permiso_941lp>();
        }

        public List<Permiso_941lp> ObtenerPermisos() => listaPermisos_941lp;

        public void AgregarPermiso(Permiso_941lp permiso) => listaPermisos_941lp.Add(permiso);
        public void EliminarPermiso(Permiso_941lp permiso) => listaPermisos_941lp.Remove(permiso);
    }
}
