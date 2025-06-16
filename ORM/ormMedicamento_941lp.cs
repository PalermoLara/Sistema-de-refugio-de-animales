using BE;
using DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ORM
{
    public class ormMedicamento_941lp
    {
        dao_941lp dao_941lp;

        public ormMedicamento_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(Medicamento_941lp medicamento_941lp)
        {
            string query_941lp = "INSERT INTO Medicamento_941lp " +
                         "(numeroOficial_941lp, nombreComercial_941lp, nombreGenerico_941lp, forma_941lp,  caducidad_941lp) " +
                         "VALUES (@numeroOficial_941lp, @nombreComercial_941lp, @nombreGenerico_941lp, @forma_941lp,  @caducidad_941lp)";
            EjecutarQueryConEntidad_941lp(medicamento_941lp, query_941lp);
        }

        public void Modificar_941lp(Medicamento_941lp medicamento_941lp)
        {
            string query_941lp = "UPDATE Medicamento_941lp SET nombreComercial_941lp = @nombreComercial_941lp, nombreGenerico_941lp = @nombreGenerico_941lp, forma_941lp = @forma_941lp,  caducidad_941lp = @caducidad_941lp WHERE numeroOficial_941lp = @numeroOficial_941lp";
            var props = new List<string>
            {
                "nombreComercial_941lp", "nombreGenerico_941lp", "forma_941lp",  "caducidad_941lp", "numeroOficial_941lp"
            };
            EjecutarQueryConEntidad_941lp(medicamento_941lp, query_941lp, props);
        }

        public void Eliminar_941lp(string numeroOficial_941lp)
        {
            string query_941lp = "DELETE FROM Medicamento_941lp WHERE numeroOficial_941lp = @numeroOficial_941lp";
            Dictionary<string, object> parametros_941lp = new Dictionary<string, object>
            {
                { "@numeroOficial_941lp", numeroOficial_941lp }
            };
            dao_941lp.EjecutarEscalar_941lp(query_941lp, parametros_941lp);
        }


        private void EjecutarQueryConEntidad_941lp(Medicamento_941lp medicamento_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(medicamento_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public Medicamento_941lp ObtenerMedicamentosPorNumero_941lp(string numero_941lp)
        {
            string query_941lp = "SELECT * FROM Medicamento_941lp WHERE numeroOficial_941lp = @numeroOficial_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@numeroOficial_941lp", numero_941lp }
            };
            var medicamento_941lp = dao_941lp.RetornarLista_941lp(query_941lp, MapearMedicamento_941lp, parametros_941lp);
            return medicamento_941lp.FirstOrDefault();
        }

        public bool VerificarExistenciaDeNumero_941lp(string numero_941lp)
        {
            string query_941lp = "SELECT COUNT (*) FROM Medicamento_941lp WHERE numeroOficial_941lp = @numeroOficial_941lp";
            var prop_941lp = new Dictionary<string, object>
            { 
                {"@numeroOficial_941lp" , numero_941lp } 
            };
            int count_941lp = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query_941lp, prop_941lp));
            return count_941lp > 0;
        }

        public List<Medicamento_941lp> RetornarMedicamento_941lp()
        {
            List<Medicamento_941lp> medicamento_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM Medicamento_941lp", MapearMedicamento_941lp);
            return medicamento_941lp;
        }

        private Medicamento_941lp MapearMedicamento_941lp(SqlDataReader reader)
        {

            return new Medicamento_941lp(
                reader["numeroOficial_941lp"].ToString(),
                reader["nombreComercial_941lp"].ToString(),
                reader["nombreGenerico_941lp"].ToString(),
                reader["forma_941lp"].ToString(),
                Convert.ToDateTime(reader["caducidad_941lp"])
            );
        }
    }
}
