using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class dao_941lp
    {
        private readonly string connectionString_941lp;

        public dao_941lp()
        {
            connectionString_941lp = "Data Source=.;Initial Catalog=sistAdopcion941lp;Integrated Security=True;";
        }

        public List<T> RetornarLista_941lp<T>(string query_941lp, Func<SqlDataReader, T> mapFunc, Dictionary<string, object> parametros_941lp = null)
        {
            List<T> lista = new List<T>();
            using (SqlConnection connection = new SqlConnection(connectionString_941lp))
            using (SqlCommand cmd = new SqlCommand(query_941lp, connection))
            {
                AsignarParametros_941lp(cmd, parametros_941lp);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(mapFunc(reader));
                    }
                }
            }
            return lista;
        }

        // Ejecuta comandos como INSERT, UPDATE, DELETE
        public void Query_941lp(string query_941lp, Dictionary<string, object> parametros_941lp = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString_941lp))
            using (SqlCommand cmd = new SqlCommand(query_941lp, connection))
            {
                AsignarParametros_941lp(cmd, parametros_941lp);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Ejecuta una consulta y devuelve un solo valor
        public object EjecutarEscalar_941lp(string query_941lp, Dictionary<string, object> parametros_941lp = null)
        {
            using (SqlConnection connection = new SqlConnection(connectionString_941lp))
            using (SqlCommand cmd = new SqlCommand(query_941lp, connection))
            {
                AsignarParametros_941lp(cmd, parametros_941lp);
                connection.Open();
                return cmd.ExecuteScalar();
            }
        }

        private void AsignarParametros_941lp(SqlCommand cmd, Dictionary<string, object> parametros_941lp)
        {
            cmd.Parameters.Clear();
            if (parametros_941lp != null)
            {
                foreach (var parametro in parametros_941lp)
                {
                    cmd.Parameters.AddWithValue(parametro.Key, parametro.Value ?? DBNull.Value);
                }
            }
        }
    }
}