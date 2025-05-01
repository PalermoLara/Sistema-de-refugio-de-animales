using BE;
using DAO;
using ORM;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ORM
{
    public class ormUsuario_941lp
    {
        dao_941lp dao_941lp;

        public ormUsuario_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void Alta_941lp(Usuario_941lp usuario_941lp)
        {
            string query_941lp = "INSERT INTO Usuario_941lp " +
                         "(dni_941lp, nombreUsuario_941lp, contraseña_941lp, nombre_941lp, apellido_941lp, rol_941lp, email_941lp, bloqueo_941lp, intentos_941lp, lenguaje_941lp, activo_941lp) " +
                         "VALUES (@dni_941lp, @nombreUsuario_941lp, @contraseña_941lp, @nombre_941lp, @apellido_941lp, @rol_941lp, @email_941lp, @bloqueo_941lp, @intentos_941lp, @lenguaje_941lp, @activo_941lp)";
            EjecutarQueryConEntidad_941lp(usuario_941lp, query_941lp);
        }

        public void Modificar_941lp(Usuario_941lp usuario_941lp)
        {
            string query_941lp = "UPDATE Usuario_941lp SET contraseña_941lp = @contraseña_941lp, nombre_941lp = @nombre_941lp, apellido_941lp = @apellido_941lp, rol_941lp = @rol_941lp, email_941lp = @email_941lp, bloqueo_941lp = @bloqueo_941lp, intentos_941lp = @intentos_941lp, " +
                         "lenguaje_941lp = @lenguaje_941lp, activo_941lp = @activo_941lp WHERE dni_941lp = @dni_941lp";
            EjecutarQueryConEntidad_941lp(usuario_941lp, query_941lp);
        }

        private void EjecutarQueryConEntidad_941lp(Usuario_941lp usuario_941lp, string query_941lp)
        {
            Dictionary<string, object> parametros_941lp = ParametroHelper_941lp.CrearParametros_941lp(usuario_941lp);
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public bool ValidarDni_941lp(string dni_941lp)
        {
            string query = "SELECT COUNT(*) FROM Usuario_941lp WHERE dni_941lp = @dni";
            var parametros = new Dictionary<string, object>
            {
                { "@dni", dni_941lp }
            };
            int count = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query, parametros));
            return count > 0;
        }

        public bool ValidarExistenciaNombreUsuario_941lp(string nombreUsuario_941lp)
        {
            string query = "SELECT COUNT(*) FROM Usuario_941lp WHERE nombreUsuario_941lp = @nombreusuario_941lp";
            var parametros = new Dictionary<string, object>
            {
                { "@nombreusuario_941lp", nombreUsuario_941lp }
            };
            int count = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query, parametros));
            return count > 0;
        }

        public bool ValidarContraseña_941lp(string usuario, string contraseña)
        {
            string query = "SELECT COUNT(*) FROM Usuario_941lp WHERE nombreUsuario_941lp = @usuario AND contraseña_941lp = @contraseña";
            var parametros = new Dictionary<string, object>
            {
                { "@usuario", usuario },
                { "@contraseña", contraseña }
            };
            int count = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query, parametros));
            return count > 0;
        }

        //si el usuario ingresa mal la contraseña, se le incrementa + 1 los intentos
        // intentos > 3 --> usuario bloqueado
        public int AumentarIntentos_941lp(Usuario_941lp usuario_941lp)
        {
            if (usuario_941lp.rol_941lp != "Administrador")
            {
                usuario_941lp.intentos_941lp++;
                if (usuario_941lp.intentos_941lp == 3)
                {
                    usuario_941lp.bloqueo_941lp = true;
                    dao_941lp.Query_941lp("UPDATE Usuario_941lp SET bloqueo_941lp = @bloqueo WHERE dni_941lp = @dni",
                        new Dictionary<string, object>
                        {
                            { "@bloqueo", usuario_941lp.bloqueo_941lp },
                            { "@dni", usuario_941lp.dni_941lp }
                        });
                }
                else
                {
                    dao_941lp.Query_941lp("UPDATE Usuario_941lp SET intentos_941lp = @intentos WHERE dni_941lp = @dni",
                        new Dictionary<string, object>
                        {
                            { "@intentos", usuario_941lp.intentos_941lp },
                            { "@dni", usuario_941lp.dni_941lp }
                        });
                }
            }
            return usuario_941lp.intentos_941lp;
        }

        public Usuario_941lp ObtenerUsuarioPorDni_941lp(string dni_941lp)
        {
            string query = "SELECT * FROM Usuario_941lp WHERE dni_941lp = @dni";
            var parametros = new Dictionary<string, object>
            {
                { "@dni", dni_941lp }
            };
            var usuarios = dao_941lp.RetornarLista_941lp(query,MapearUsuario,parametros);
            return usuarios.FirstOrDefault(); 
        }

        public List<Usuario_941lp> RetornarUsuarios_941lp()
        {
            List<Usuario_941lp> usuarios = dao_941lp.RetornarLista_941lp("SELECT * FROM Usuario_941lp",MapearUsuario);
            return usuarios;
        }

        private Usuario_941lp MapearUsuario(SqlDataReader reader)
        {
            return new Usuario_941lp(
                reader["dni_941lp"].ToString(),
                reader["nombreUsuario_941lp"].ToString(),
                reader["contraseña_941lp"].ToString(),
                reader["nombre_941lp"].ToString(),
                reader["apellido_941lp"].ToString(),
                reader["rol_941lp"].ToString(),
                reader["email_941lp"].ToString(),
                Convert.ToBoolean(reader["bloqueo_941lp"]),
                Convert.ToInt32(reader["intentos_941lp"]),
                reader["lenguaje_941lp"].ToString(),
                Convert.ToBoolean(reader["activo_941lp"])
            );
        }
    }
}
