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

        private void EjecutarQueryConEntidad_941lp(Permiso_941lp familia_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(familia_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void AltaPermiso_941lp(Permiso_941lp familia_941lp)
        {
            string query_941lp = "INSERT INTO Permisos_941lp " +
                         "(nombrePermiso_941lp, compuesto_941lp, esRol_941lp) " +
                         "VALUES ( @nombrePermiso_941lp,@compuesto_941lp, @esRol_941lp)";
            var parametros_941lp = new List<string>
            {
                "nombrePermiso_941lp", "esRol_941lp","compuesto_941lp"  
            };
            EjecutarQueryConEntidad_941lp(familia_941lp, query_941lp, parametros_941lp);
        }

        public void AltaIntermedia_941lp(Permiso_941lp permisoIntermedio_941lp, string nombreAñadido)
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

        public void Eliminar_941lp(Permiso_941lp permiso_941lp)
        {
            string query_941lp = "DELETE FROM Permisos_941lp WHERE nombrePermiso_941lp = @nombrePermiso_941lp";
            var propiedadesIncluir_941lp = new List<string>
            {
                "nombrePermiso_941lp"  
            };
            EjecutarQueryConEntidad_941lp(permiso_941lp, query_941lp, propiedadesIncluir_941lp);
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

        public Dictionary<string, Permiso_941lp> ObtenerEstructuraCompletaComposite_941lp()
        {
            // Cargar todos los permisos
            var permisos_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM Permisos_941lp", MapearPermisoMixto_941lp).ToDictionary(p => p.nombrePermiso_941lp);
            // Cargar todas las relaciones
            string queryIntermedia_941lp = "SELECT nombrePermisoCompuesto941lp, permisoAñadido941lp FROM PermisosIntermedia_941lp";
            var relaciones_941lp = dao_941lp.RetornarLista_941lp(queryIntermedia_941lp, reader_941lp =>
            {
                string compuesto_941lp = reader_941lp.GetString(0);
                string hijo_941lp = reader_941lp.GetString(1);
                return (compuesto_941lp, hijo_941lp);
            });
            // Armar el árbol en memoria
            foreach (var (compuesto_941lp, hijo_941lp) in relaciones_941lp)
            {
                if (permisos_941lp[compuesto_941lp] is Familia_941lp familia_941lp && permisos_941lp.ContainsKey(hijo_941lp))
                {
                    familia_941lp.AgregarPermiso(permisos_941lp[hijo_941lp]);
                }
            }
            return permisos_941lp; 
        }

        public Permiso_941lp ObtenerPermisoDesdeComposite_941lp(Dictionary<string, Permiso_941lp> composite_941lp, string nombre_941lp)
        {
            // busca el nombre dentro del diccionario. Si lo encuentra, devuelve el permiso; si no, devuelve null.
            composite_941lp.TryGetValue(nombre_941lp, out var permiso_941lp);
            return permiso_941lp;
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
