using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormIntemedia_941lp
    {
        dao_941lp dao_941lp;

        public ormIntemedia_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void AltaIntermedia_941lp(string familia_941lp, string nombreAñadido_941lp)
        {
            string query_941lp = "INSERT INTO permisosIntermedia_941lp (nombreFamilia_941lp, permiso_941lp) " +
                        "VALUES (@nombreFamilia_941lp, @permiso_941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombreFamilia_941lp", familia_941lp},
                { "@permiso_941lp", nombreAñadido_941lp }
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void EliminarDeIntermedia_941lp(string nombreFamilia_941lp, string permiso_941lp)
        {
            string queryIntermedia_941lp = "DELETE FROM permisosIntermedia_941lp WHERE nombreFamilia_941lp = @nombreFamilia_941lp AND permiso_941lp = @permiso_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombreFamilia_941lp", nombreFamilia_941lp},
                { "@permiso_941lp", permiso_941lp }
            };
            dao_941lp.Query_941lp(queryIntermedia_941lp, parametros_941lp);
        }
    }
}
