using BE;
using DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormPermisos_941lp
    {
        dao_941lp dao_941lp;

        public ormPermisos_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void AltaPermiso_941lp(Familia_941lp familia_941lp)
        {
            string query_941lp = "INSERT INTO Permisos_941lp " +
                         "(nombrePermiso_941lp, compuesto_941lp, esRol_941lp) " +
                         "VALUES ( @nombrePermiso_941lp,@compuesto_941lp, @esRol_941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePermiso_941lp", familia_941lp.nombrePermiso_941lp },
                { "@esRol_941lp", familia_941lp.esRol_941lp },
                { "@compuesto_941lp", true } // o familia.compuesto_941lp si lo hereda y no es readonly
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void Eliminar_941lp(Permiso_941lp permiso_941lp)
        {
            string query_941lp = "DELETE FROM Permisos_941lp WHERE nombrePermiso_941lp = @nombrePermiso_941lp";
            var propiedadesIncluir_941lp = new List<string>
            {
                "nombrePermiso_941lp"  
            };
            EjecutarQueryConEntidad_941lp(permiso_941lp, query_941lp, propiedadesIncluir_941lp);
        }

        public void EliminarDeIntermedia_941lp(Permiso_941lp permiso_941lp)
        {
            string queryIntermedia = "DELETE FROM PermisosIntermedia_941lp " +
                                      "WHERE nombrePermisoCompuesto941lp = @nombrePermiso_941lp " +
                                      "OR permisoAñadido941lp = @nombrePermiso_941lp";
            var propiedadesIncluir_941lp = new List<string>
            {
                "nombrePermiso_941lp"
            };
            EjecutarQueryConEntidad_941lp(permiso_941lp, queryIntermedia, propiedadesIncluir_941lp);
        }

        public void AltaIntermedia_941lp(permisoIntermedio_941lp permisoIntermedio_941lp)
        {
            string query_941lp = "INSERT INTO PermisosIntermedia_941lp " +
                        "(nombrePermisoCompuesto941lp, permisoAñadido941lp) " +
                        "VALUES (@nombrePermisoCompuesto941lp, @permisoAñadido941lp)";
            EjecutarQueryConEntidadIntermedio_941lp(permisoIntermedio_941lp, query_941lp);
        }

        public bool VerificarNombreDeRolFamilia_941lp(string nombrePermiso_941lp)
        {
            string query_941lp = "SELECT COUNT (*) FROM Permisos_941lp WHERE nombrePermiso_941lp = @nombrePermiso_941lp";
            var prop_941lp = new Dictionary<string, object>
            {
                {"@nombrePermiso_941lp" , nombrePermiso_941lp }
            };
            int count_941lp = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query_941lp, prop_941lp));
            return count_941lp > 0;
        }

        public Permiso_941lp ObtenerPermiso_941lp(string nombrePermiso_941lp)
        {
            string query_941lp = "SELECT * FROM Permisos_941lp WHERE nombrePermiso_941lp = @nombrePermiso_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePermiso_941lp", nombrePermiso_941lp }
            };
            var permisos = dao_941lp.RetornarLista_941lp(query_941lp, MapearPermisoMixto_941lp, parametros_941lp);
            var permiso = permisos.FirstOrDefault();

            if (permiso is Familia_941lp familia)
            {
                CargarHijosRecursivos_941lp(familia, new HashSet<string>());
            }

            return permiso;
        }

        private void CargarHijosRecursivos_941lp(Familia_941lp familia, HashSet<string> yaCargados)
        {
            if (yaCargados.Contains(familia.nombrePermiso_941lp))
                return;

            yaCargados.Add(familia.nombrePermiso_941lp);

            string queryHijos = "SELECT P.* FROM Permisos_941lp P " +
                                "INNER JOIN PermisosIntermedia_941lp PI ON P.nombrePermiso_941lp = PI.permisoAñadido941lp " +
                                "WHERE PI.nombrePermisoCompuesto941lp = @nombrePermiso_Compuesto";

            var paramHijos = new Dictionary<string, object>
            {
                { "@nombrePermiso_Compuesto", familia.nombrePermiso_941lp }
            };

            var hijos = dao_941lp.RetornarLista_941lp(queryHijos, MapearPermisoMixto_941lp, paramHijos);

            foreach (var hijo in hijos)
            {
                if (hijo is Familia_941lp subFamilia)
                {
                    familia.AgregarPermiso(subFamilia);
                    CargarHijosRecursivos_941lp(subFamilia, yaCargados); // Recursivo
                }
                else
                {
                    familia.AgregarPermiso(hijo);
                }
            }
        }

        private void EjecutarQueryConEntidad_941lp(Permiso_941lp familia_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(familia_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        private void EjecutarQueryConEntidadIntermedio_941lp(permisoIntermedio_941lp intermedio_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(intermedio_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public List<Permiso_941lp> RetornarPermisos_941lp()
        {
            List<Permiso_941lp> listraPermisos_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM Permisos_941lp", MapearPermisoMixto_941lp);
            return listraPermisos_941lp;
        }

        public Permiso_941lp MapearPermisoMixto_941lp(SqlDataReader reader)
        {
            string nombre = reader["nombrePermiso_941lp"].ToString();
            bool esCompuesto = Convert.ToBoolean(reader["compuesto_941lp"]);
            bool esRol = Convert.ToBoolean(reader["esRol_941lp"]);

            if (esCompuesto)
            {
                return new Familia_941lp(nombre, esRol);
            }
            else
            {
                return new PermisoSimple_941lp(nombre);
            }
        }
    }
}
