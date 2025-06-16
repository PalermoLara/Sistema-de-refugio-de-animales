using DAO;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ORM
{
    public class ormPermisos_941lp
    {
        dao_941lp dao_941lp;

        public ormPermisos_941lp()
        {
            dao_941lp = new dao_941lp();
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
