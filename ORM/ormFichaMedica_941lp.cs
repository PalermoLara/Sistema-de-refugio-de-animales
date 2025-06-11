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
    public class ormFichaMedica_941lp
    {
        dao_941lp dao_941lp;

        public ormFichaMedica_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(FichaMedica_941lp ficha_941lp)
        {
            string query_941lp = "INSERT INTO FichaMedica_941lp " +
                         "(codigoAnimal_941lp, fecha_941lp, castrado_941lp, dieta_941lp, medicamento_941lp, observaciones_941lp) " +
                         "VALUES (@codigoAnimal_941lp,@fecha_941lp, @castrado_941lp, @dieta_941lp, @medicamento_941lp, @observaciones_941lp)";
            var propiedadesIncluir_941lp = new List<string>
            {
                 "codigoAnimal_941lp", "fecha_941lp", "castrado_941lp", "dieta_941lp", "medicamento_941lp", "observaciones_941lp", "codigo_941lp"
            };
            EjecutarQueryConEntidad_941lp(ficha_941lp, query_941lp, propiedadesIncluir_941lp);
        }

        public void Modificar_941lp(FichaMedica_941lp ficha_941lp)
        {
            string query_941lp = "UPDATE FichaMedica_941lp SET castrado_941lp = @castrado_941lp, dieta_941lp = @dieta_941lp, medicamento_941lp = @medicamento_941lp, observaciones_941lp = @observaciones_941lp WHERE codigo_941lp = @codigo_941lp";
            // Lista de propiedades usadas en la consulta 
            var props = new List<string>
            {
                "castrado_941lp", "dieta_941lp", "medicamento_941lp", "observaciones_941lp", "codigo_941lp"
            };
            EjecutarQueryConEntidad_941lp(ficha_941lp, query_941lp, props);
        }

        private void EjecutarQueryConEntidad_941lp(FichaMedica_941lp ficha_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(ficha_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public List<FichaMedica_941lp> RetornarFichaMedica_941lp()
        {
            List<FichaMedica_941lp> ficha_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM FichaMedica_941lp", MapearFicha_941lp);
            return ficha_941lp;
        }

        private FichaMedica_941lp MapearFicha_941lp(SqlDataReader reader)
        {

            return new FichaMedica_941lp(
                Convert.ToInt32(reader["codigo_941lp"]),
                Convert.ToInt32(reader["codigoAnimal_941lp"]),
                Convert.ToDateTime(reader["fecha_941lp"]),
                Convert.ToBoolean(reader["castrado_941lp"]),
                reader["dieta_941lp"].ToString(),
                reader["medicamento_941lp"].ToString(),
                reader["observaciones_941lp"].ToString()
            );
        }
    }
}
