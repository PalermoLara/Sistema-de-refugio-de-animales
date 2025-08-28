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
    public class ormAdoptantes_941lp
    {
        dao_941lp dao_941lp;

        public ormAdoptantes_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(Adoptante_941lp adoptante_941lp)
        {
            string query_941lp = "INSERT INTO Adoptante_941lp " +
                         "(dni_941lp, nombre_941lp, apellido_941lp, telefono_941lp, edad_941lp,domicilio_941lp,mascotas_941lp, activo_941lp ) " +
                         "VALUES (@dni_941lp, @nombre_941lp, @apellido_941lp, @telefono_941lp, @edad_941lp, @domicilio_941lp, @mascotas_941lp, @activo_941lp)";
            EjecutarQueryConEntidad_941lp(adoptante_941lp, query_941lp);
        }

        public void Modificar_941lp(Adoptante_941lp adoptante_941lp)
        {
            string query_941lp = "UPDATE Adoptante_941lp SET nombre_941lp = @nombre_941lp, apellido_941lp = @apellido_941lp,  telefono_941lp = @telefono_941lp,edad_941lp = @edad_941lp,domicilio_941lp = @domicilio_941lp, mascotas_941lp = @mascotas_941lp, activo_941lp = @activo_941lp WHERE dni_941lp = @dni_941lp";
            // Lista de propiedades usadas en la consulta
            var props = new List<string>
            {
                "nombre_941lp",
                "apellido_941lp",
                "telefono_941lp",
                "edad_941lp",
                "domicilio_941lp",
                "mascotas_941lp",
                "activo_941lp",
                "dni_941lp"
            };

            EjecutarQueryConEntidad_941lp(adoptante_941lp, query_941lp, props);
        }

        private void EjecutarQueryConEntidad_941lp(Adoptante_941lp adoptante_941lp, string query_941lp, List<string> propiedadesIncluir_941lp = null)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(adoptante_941lp, propiedadesIncluir_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public bool ValidarDni_941lp(string dni_941lp)
        {
            string query_941lp = "SELECT COUNT(*) FROM Adoptante_941lp WHERE dni_941lp = @dni";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@dni", dni_941lp }
            };
            int count = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query_941lp, parametros_941lp));
            return count > 0;
        }

        public Adoptante_941lp ObtenerAdoptantePorDni_941lp(string dni_941lp)
        {
            string query_941lp = "SELECT * FROM Adoptante_941lp WHERE dni_941lp = @dni";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@dni", dni_941lp }
            };
            var adoptante_941lp = dao_941lp.RetornarLista_941lp(query_941lp, MapearAdoptante_941lp, parametros_941lp);
            return adoptante_941lp.FirstOrDefault();
        }

        public List<Adoptante_941lp> RetornarAdoptantes_941lp()
        {
            List<Adoptante_941lp> adoptante_941lp = dao_941lp.RetornarLista_941lp("SELECT * FROM Adoptante_941lp", MapearAdoptante_941lp);
            return adoptante_941lp;
        }

        private Adoptante_941lp MapearAdoptante_941lp(SqlDataReader reader)
        {

            return new Adoptante_941lp(
                reader["dni_941lp"].ToString(),
                reader["nombre_941lp"].ToString(),
                reader["apellido_941lp"].ToString(),
                reader["telefono_941lp"].ToString(),
                Convert.ToInt32(reader["edad_941lp"]),
                reader["domicilio_941lp"].ToString(),
                Convert.ToBoolean(reader["mascotas_941lp"]),
                Convert.ToBoolean(reader["activo_941lp"])
            );
        }
    }
}
