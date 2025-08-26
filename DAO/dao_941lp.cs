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

        public void RestaurarBaseDatos_941lp(string nombreBase_941lp, string rutaBackup_941lp)
        {
            string connectionStringMaster_941lp = "Data Source=.;Initial Catalog=master;Integrated Security=True;";

            using (SqlConnection connection_941lp = new SqlConnection(connectionStringMaster_941lp))
            {
                connection_941lp.Open();

                using (SqlCommand cmd_941lp = connection_941lp.CreateCommand())
                {
                    // Matar conexiones abiertas a la base
                    cmd_941lp.CommandText = $@"
                    DECLARE @kill varchar(8000) = '';
                    SELECT @kill = @kill + 'KILL ' + CONVERT(varchar(5), session_id) + ';'
                    FROM sys.dm_exec_sessions
                    WHERE database_id = DB_ID('{nombreBase_941lp}') AND session_id <> @@SPID;
                    EXEC(@kill);";
                    cmd_941lp.ExecuteNonQuery();

                    // Forzar single user
                    cmd_941lp.CommandText = $@"ALTER DATABASE [{nombreBase_941lp}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    cmd_941lp.ExecuteNonQuery();

                    // Restaurar
                    cmd_941lp.CommandText = $@"RESTORE DATABASE [{nombreBase_941lp}] 
                                 FROM DISK = @ruta 
                                 WITH REPLACE;";
                    cmd_941lp.Parameters.AddWithValue("@ruta", rutaBackup_941lp);
                    cmd_941lp.ExecuteNonQuery();

                    // Volver a multi user
                    cmd_941lp.Parameters.Clear();
                    cmd_941lp.CommandText = $@"ALTER DATABASE [{nombreBase_941lp}] SET MULTI_USER;";
                    cmd_941lp.ExecuteNonQuery();
                }
            }
        }

    }
}