using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormPerfilFamilia_941lp
    {
        dao_941lp dao_941lp;

        public ormPerfilFamilia_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        private void EjecutarQueryConEntidad_941lp(Perfil_941lp perfil_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(perfil_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void AltaIntermedia_941lp(Perfil_941lp permisoIntermedio_941lp, string nombreAñadido)
        {
            string query_941lp = "INSERT INTO PermisosIntermedia_941lp " +
                        "(nombrePermisoCompuesto941lp, permisoAñadido941lp) " +
                        "VALUES (@nombrePermisoCompuesto941lp, @permisoAñadido941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePermisoCompuesto941lp", permisoIntermedio_941lp.nombrePermiso_941lp},
                { "@permisoAñadido941lp", nombreAñadido }
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
