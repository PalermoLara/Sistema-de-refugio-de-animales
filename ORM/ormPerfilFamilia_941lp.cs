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

        public void AltaIntermedia_941lp(string perfil_941lp, string nombreAñadido_941lp)
        {
            string query_941lp = "INSERT INTO Perfil_Familia_941lp (nombrePerfil_941lp, nombreFamilia_941lp) " +
                        "VALUES (@nombrePerfil_941lp, @nombreFamilia_941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePerfil_941lp", perfil_941lp},
                { "@nombreFamilia_941lp", nombreAñadido_941lp }
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void EliminarDeIntermedia_941lp(string nombrePerfil_941lp, string nombreFamilia_941lp)
        {
            string queryIntermedia_941lp = "DELETE FROM Perfil_Familia_941lp WHERE nombrePerfil_941lp = @nombrePerfil_941lp AND nombreFamilia_941lp = @nombreFamilia_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePerfil_941lp", nombrePerfil_941lp},
                { "@nombreFamilia_941lp", nombreFamilia_941lp }
            };
            dao_941lp.Query_941lp(queryIntermedia_941lp, parametros_941lp);
        }
    }
}
