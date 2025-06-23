using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormPerfilPermiso_941lp
    {
        dao_941lp dao_941lp;

        public ormPerfilPermiso_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void AltaIntermedia_941lp(string perfil_941lp, string nombreAñadido_941lp)
        {
            string query_941lp = "INSERT INTO Perfil_Permiso_941lp (nombrePerfil_941lp, nombrePermiso_941lp) " +
                        "VALUES (@nombrePerfil_941lp, @nombrePermiso_941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePerfil_941lp", perfil_941lp},
                { "@nombrePermiso_941lp", nombreAñadido_941lp }
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void EliminarDeIntermedia_941lp(string nombrePerfil_941lp, string nombrePermiso_941lp)
        {
            string queryIntermedia_941lp = "DELETE FROM Perfil_Permiso_941lp WHERE nombrePerfil_941lp = @nombrePerfil_941lp AND nombrePermiso_941lp = @nombrePermiso_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePerfil_941lp", nombrePerfil_941lp},
                { "@nombrePermiso_941lp", nombrePermiso_941lp }
            };
            dao_941lp.Query_941lp(queryIntermedia_941lp, parametros_941lp);
        }
    }
}
