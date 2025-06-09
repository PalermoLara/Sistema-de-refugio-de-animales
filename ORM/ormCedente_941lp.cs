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
    public class ormCedente_941lp
    {
        dao_941lp dao_941lp;

        public ormCedente_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(Cedente_941lp cedente_941lp)
        {
            string query_941lp = "INSERT INTO Cedente_941lp " +
                         "(dni_941lp, nombre_941lp, apellido_941lp, direccion_941lp, telefono_941lp, activo_941lp) " +
                         "VALUES (@dni_941lp, @nombre_941lp, @apellido_941lp, @direccion_941lp, @telefono_941lp, @activo_941lp)";
            EjecutarQueryConEntidad_941lp(cedente_941lp, query_941lp);
        }

        public void Modificar_941lp(Cedente_941lp cedente_941lp)
        {
            string query_941lp = "UPDATE Cedente_941lp SET nombre_941lp = @nombre_941lp, apellido_941lp = @apellido_941lp, direccion_941lp = @direccion_941lp, telefono_941lp = @telefono_941lp, activo_941lp = @activo_941lp WHERE dni_941lp = @dni_941lp";
            // Lista de propiedades usadas en la consulta
            var props = new List<string>
            {
                "nombre_941lp", 
                "apellido_941lp", 
                "direccion_941lp", 
                "telefono_941lp", 
                "activo_941lp",
                "dni_941lp"
            };

            EjecutarQueryConEntidad_941lp(cedente_941lp, query_941lp, props);
        }

        private void EjecutarQueryConEntidad_941lp(Cedente_941lp cedente_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(cedente_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public bool ValidarDni_941lp(string dni_941lp)
        {
            string query_941lp = "SELECT COUNT(*) FROM Cedente_941lp WHERE dni_941lp = @dni";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@dni", dni_941lp }
            };
            int count = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query_941lp, parametros_941lp));
            return count > 0;
        }

        public Cedente_941lp ObtenerCedentePorDni_941lp(string dni_941lp)
        {
            string query_941lp = "SELECT * FROM Cedente_941lp WHERE dni_941lp = @dni";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@dni", dni_941lp }
            };
            var cedente_941lp = dao_941lp.RetornarLista_941lp(query_941lp, MapearCedente_941lp, parametros_941lp);
            return cedente_941lp.FirstOrDefault();
        }

        public List<Cedente_941lp> RetornarCedentes_941lp()
        {
            List<Cedente_941lp> cedente_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM Cedente_941lp", MapearCedente_941lp);
            return cedente_941lp;
        }

        private Cedente_941lp MapearCedente_941lp(SqlDataReader reader)
        {

            return new Cedente_941lp(
                reader["dni_941lp"].ToString(),
                reader["nombre_941lp"].ToString(),
                reader["apellido_941lp"].ToString(),
                reader["direccion_941lp"].ToString(),
                reader["telefono_941lp"].ToString(),
                Convert.ToBoolean(reader["activo_941lp"])
            );
        }
    }
}

