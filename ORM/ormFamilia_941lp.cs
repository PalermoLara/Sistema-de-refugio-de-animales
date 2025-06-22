using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormFamilia_941lp
    {
        dao_941lp dao_941lp;

        public ormFamilia_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void AltaFamilia_941lp(Familia_941lp familia_941lp)
        {
            string query_941lp = "INSERT INTO Familia_941lp (nombreFamilia_941lp) VALUES ( @nombreFamilia_941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombreFamilia_941lp", familia_941lp.nombrePermiso_941lp}
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void Eliminar_941lp(Familia_941lp familia_941lp)
        {
            string query_941lp = "DELETE FROM Familia_941lp WHERE nombreFamilia_941lp = @nombreFamilia_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombreFamilia_941lp", familia_941lp.nombrePermiso_941lp}
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public bool VerificarNombreDeFamilia_941lp(string nombreFamilia_941lp)
        {
            string query_941lp = "SELECT COUNT (*) FROM Familia_941lp WHERE nombreFamilia_941lp = @nombreFamilia_941lp";
            var prop_941lp = new Dictionary<string, object>
            {
                {"@nombreFamilia_941lp" , nombreFamilia_941lp }
            };
            int count_941lp = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query_941lp, prop_941lp));
            return count_941lp > 0;
        }

        public List<Familia_941lp> RetornarFamilias_941lp()
        {
            return  dao_941lp.RetornarLista_941lp("SELECT nombreFamilia_941lp FROM Familia_941lp",reader => new Familia_941lp(reader.GetString(0)));
        }

        public List<PermisoSimple_941lp> RetornarPermisosSimple_941lp()
        {
            return dao_941lp.RetornarLista_941lp("SELECT nombrePermiso_941lp FROM Permiso_941lp", reader => new PermisoSimple_941lp(reader.GetString(0)));
        }

        public List<(string, string)> RetornarRelaciones_941lp()
        {
            return dao_941lp.RetornarLista_941lp("SELECT nombreFamilia_941lp, permiso_941lp FROM permisosIntermedia_941lp", reader => (reader.GetString(0), reader.GetString(1)));
        }

        public Dictionary<string, Perfil_941lp> ObtenerCompositeFamilias_941lp()
        {
            return estruturaFamilia_941lp.ObtenerCompositeFamilias_941lp(RetornarFamilias_941lp(), RetornarPermisosSimple_941lp(), RetornarRelaciones_941lp());
        }
    }
}
