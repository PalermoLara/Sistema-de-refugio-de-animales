using BE;
using DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        DataTable dtUsuario_941lp;

        public ormUsuario_941lp()
        {
            dao_941lp = new dao_941lp();
            CargarTabla_941lp();
        }

        private void CargarTabla_941lp()
        {
            dtUsuario_941lp = dao_941lp.RetornarTabla_941lp("Usuario_941lp", "select * from Usuario_941lp");
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

        //valida si existe la contraseña o el nombre de usuario ingresado para el alta de un usuario
        public bool ValidarExistenciaNombreUsuario_941lp( string nombreUsuario_941lp)
        {
            return dtUsuario_941lp.AsEnumerable()
            .Any(row => row["nombreUsuario_941lp"].ToString() == nombreUsuario_941lp);
        }

        //validacion para el cambio de contraseña, verifica que la contraseña actual del usuario
        //logueado sea correcta
        public bool ValidarContraseñaActual_941lp(string contraseña_941lp)
        {
            return dtUsuario_941lp.AsEnumerable()
            .Any(row => row["contraseña_941lp"].ToString() == contraseña_941lp);
        }

        //verifica si el dni ingresado ya se encuentra registrado
        public bool ValidarDni_941lp(string dni_941lp)
        {
            return dtUsuario_941lp.Rows.Find(dni_941lp) != null;
        }

        //si el usuario ingresa mal la contraseña, se le incrementa + 1 los intentos
        // intentos > 3 --> usuario bloqueado
        public void AumentarIntentos_941lp(Usuario_941lp usuario_941lp)
        {
            if (usuario_941lp.rol_941lp != "Administrador")
            {
                if (usuario_941lp.intentos_941lp >= 3)
                {
                    usuario_941lp.bloqueo_941lp = true;
                    dao_941lp.Query_941lp("UPDATE Usuario_941lp SET intentos_941lp = @intentos, bloqueo_941lp = @bloqueo WHERE dni_941lp = @dni",
                        new Dictionary<string, object>
                        {
                            { "@intentos", usuario_941lp.intentos_941lp },
                            { "@bloqueo", usuario_941lp.bloqueo_941lp },
                            { "@dni", usuario_941lp.dni_941lp }
                        });
                }
                else
                {
                    usuario_941lp.intentos_941lp++;
                    dao_941lp.Query_941lp("UPDATE Usuario_941lp SET intentos_941lp = @intentos WHERE dni_941lp = @dni",
                        new Dictionary<string, object>
                        {
                            { "@intentos", usuario_941lp.intentos_941lp },
                            { "@dni", usuario_941lp.dni_941lp }
                        });
                }
            }
        }

        //retorna una lista de usuarios
        public List<Usuario_941lp> RetornarUsuarios_941lp()
        {
            CargarTabla_941lp();
            return dtUsuario_941lp.AsEnumerable()
                .Select(row => new Usuario_941lp(row.ItemArray))
                .ToList();
        }
    }
}
