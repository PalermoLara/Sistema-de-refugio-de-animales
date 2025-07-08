using BE;
using DAO;
using System;
using SERVICIOS;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormPermiso_941lp
    {
        dao_941lp dao_941lp;

        public ormPermiso_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public bool VerificarNombreDePatente_941lp(string nombrePatente_941lp)
        {
            string query_941lp = "SELECT COUNT (*) FROM Permiso_941lp WHERE nombrePermiso_941lp = @nombrePermiso_941lp";
            var prop_941lp = new Dictionary<string, object>
            {
                {"@nombrePermiso_941lp" , nombrePatente_941lp }
            };
            int count_941lp = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query_941lp, prop_941lp));
            return count_941lp > 0;
        }

        public List<PermisoSimple_941lp> RetornarPermisos_941lp()
        {
            return dao_941lp.RetornarLista_941lp("SELECT nombrePermiso_941lp FROM Permiso_941lp", MapearPermiso_941lp);
        }

        public PermisoSimple_941lp MapearPermiso_941lp(SqlDataReader reader)
        {
            return new PermisoSimple_941lp(
            reader["nombrePermiso_941lp"].ToString()
            );
        }
    }
}
