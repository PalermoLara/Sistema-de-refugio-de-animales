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

        public void AltaIntermedia_941lp(string familia_941lp, string nombreAñadido_941lp)
        {
            string query_941lp = "INSERT INTO Familia_Permiso_941lp (nombreFamilia_941lp, nombrePermiso_941lp) " +
                        "VALUES (@nombreFamilia_941lp, @nombrePermiso_941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombreFamilia_941lp", familia_941lp},
                { "@nombrePermiso_941lp", nombreAñadido_941lp }
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void EliminarDeIntermedia_941lp(string nombreFamilia_941lp, string nombrePermiso_941lp)
        {
            string queryIntermedia_941lp = "DELETE FROM Familia_Permiso_941lp WHERE nombreFamilia_941lp = @nombreFamilia_941lp AND nombrePermiso_941lp = @nombrePermiso_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombreFamilia_941lp", nombreFamilia_941lp},
                { "@nombrePermiso_941lp", nombrePermiso_941lp }
            };
            dao_941lp.Query_941lp(queryIntermedia_941lp, parametros_941lp);
        }
    }

}
