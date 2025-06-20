using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormFamiliaPermiso_941lp
    {
        dao_941lp dao_941lp;

        public ormFamiliaPermiso_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void AltaIntermedia_941lp(Perfil_941lp permisoIntermedio_941lp, string nombreAñadido_941lp)
        {
            string query_941lp = "INSERT INTO ermisosIntermedia_941lp " +
                        "(nombrePermisoCompuesto941lp, permisoAñadido941lp) " +
                        "VALUES (@nombrePermisoCompuesto941lp, @permisoAñadido941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePermisoCompuesto941lp", permisoIntermedio_941lp.nombrePermiso_941lp},
                { "@permisoAñadido941lp", nombreAñadido_941lp }
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void EliminarDeIntermediaPermanente_941lp(string permisoCompuesto941lp, string permisoAñadido941lp)
        {
            string queryIntermedia_941lp = "DELETE FROM PermisosIntermedia_941lp " +
                                      "WHERE nombrePermisoCompuesto941lp = @nombrePermisoCompuesto941lp " +
                                      "OR permisoAñadido941lp = @permisoAñadido941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePermisoCompuesto941lp", permisoCompuesto941lp},
                { "@permisoAñadido941lp", permisoAñadido941lp }
            };
            dao_941lp.Query_941lp(queryIntermedia_941lp, parametros_941lp);
        }

        public void EliminarDeIntermedia_941lp(string permisoCompuesto941lp, string permisoAñadido941lp)
        {
            string queryIntermedia_941lp = "DELETE FROM PermisosIntermedia_941lp " +
                                      "WHERE nombrePermisoCompuesto941lp = @nombrePermisoCompuesto941lp " +
                                      "AND permisoAñadido941lp = @permisoAñadido941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePermisoCompuesto941lp", permisoCompuesto941lp},
                { "@permisoAñadido941lp", permisoAñadido941lp }
            };
            dao_941lp.Query_941lp(queryIntermedia_941lp, parametros_941lp);
        }
    }
}
}
