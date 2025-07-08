using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Familia_941lp : Perfil_941lp
    {
        private List<Perfil_941lp> listaPermisos_941lp;

        public Familia_941lp(string pNombrePermiso_941lp) : base(pNombrePermiso_941lp)
        {
            listaPermisos_941lp = new List<Perfil_941lp>();
        }

        public List<Perfil_941lp> ObtenerPermisos_941lp() => listaPermisos_941lp;

        public void AgregarPermiso_941lp(Perfil_941lp permiso_941lp) => listaPermisos_941lp.Add(permiso_941lp);
        public void EliminarPermiso_941lp(Perfil_941lp permiso_941lp) => listaPermisos_941lp.Remove(permiso_941lp);
    }
}
