using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Familia_941lp : Perfil_941lp
    {
        private List<Perfil_941lp> listaPermisos_941lp;

        public Familia_941lp(string pNombrePermiso_941lp) : base(pNombrePermiso_941lp)
        {
            listaPermisos_941lp = new List<Perfil_941lp>();
        }

        public List<Perfil_941lp> ObtenerPermisos() => listaPermisos_941lp;

        public void AgregarPermiso(Perfil_941lp permiso) => listaPermisos_941lp.Add(permiso);
        public void EliminarPermiso(Perfil_941lp permiso) => listaPermisos_941lp.Remove(permiso);
    }
}
