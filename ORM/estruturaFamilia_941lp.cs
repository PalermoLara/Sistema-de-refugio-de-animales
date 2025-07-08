using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using SERVICIOS;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class estruturaFamilia_941lp
    {
        public static Dictionary<string, Perfil_941lp> ObtenerCompositeFamilias_941lp(List<Familia_941lp> listaFamilia_941lp, List<PermisoSimple_941lp> listaPSimple_941lp, List<(string, string)> relaciones_941lp)
        {
            Dictionary<string, Perfil_941lp> permisos_941lp = new Dictionary<string, Perfil_941lp>();
            foreach (var p in listaPSimple_941lp)
                permisos_941lp[p.nombrePermiso_941lp] = p;

            foreach (var f in listaFamilia_941lp)
                permisos_941lp[f.nombrePermiso_941lp] = f;

            foreach (var (familia_941lp, permiso_941lp) in relaciones_941lp)
            {
                if (permisos_941lp.TryGetValue(familia_941lp, out Perfil_941lp nodoFamilia_941lp) &&
                    nodoFamilia_941lp is Familia_941lp padreFamilia &&
                    permisos_941lp.TryGetValue(permiso_941lp, out Perfil_941lp nodoAñadido_941lp))
                {
                    padreFamilia.AgregarPermiso_941lp(nodoAñadido_941lp);
                }
            }
            return permisos_941lp;
        }
    }
}
