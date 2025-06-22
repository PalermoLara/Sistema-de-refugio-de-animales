using BE;
using DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ormPerfil_941lp
    {
        dao_941lp dao_941lp;

        public ormPerfil_941lp()
        {
            dao_941lp = new dao_941lp();
        }

        public void AltaPerfil_941lp(Familia_941lp perfil_941lp)
        {
            string query_941lp = "INSERT INTO Perfil_941lp (nombrePerfil_941lp) VALUES ( @nombrePerfil_941lp)";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePerfil_941lp", perfil_941lp.nombrePermiso_941lp}
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public void Eliminar_941lp(Familia_941lp perfil_941lp)
        {
            string query_941lp = "DELETE FROM Perfil_941lp WHERE nombrePerfil_941lp = @nombrePerfil_941lp";
            var parametros_941lp = new Dictionary<string, object>
            {
                { "@nombrePerfil_941lp", perfil_941lp.nombrePermiso_941lp}
            };
            dao_941lp.Query_941lp(query_941lp, parametros_941lp);
        }

        public bool VerificarNombreDePerfil_941lp(string nombrePerfil_941lp)
        {
            string query_941lp = "SELECT COUNT (*) FROM Perfil_941lp WHERE nombrePerfil_941lp = @nombrePerfil_941lp";
            var prop_941lp = new Dictionary<string, object>
            {
                {"@nombrePerfil_941lp" , nombrePerfil_941lp }
            };
            int count_941lp = Convert.ToInt32(dao_941lp.EjecutarEscalar_941lp(query_941lp, prop_941lp));
            return count_941lp > 0;
        }

        public List<Familia_941lp> RetornarPerfiles_941lp()
        {
            return dao_941lp.RetornarLista_941lp("SELECT nombrePerfil_941lp FROM Perfil_941lp", reader => new Familia_941lp(reader.GetString(0)));
        }

        public List<Familia_941lp> RetornarFamilias_941lp()
        {
            return dao_941lp.RetornarLista_941lp("SELECT nombreFamilia_941lp FROM Familia_941lp", reader => new Familia_941lp(reader.GetString(0)));
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

        public void ReconstruirComposite_941lp()
        {
            ObtenerCompositeFamilias_941lp();
            ObtenerCompositePerfiles_941lp();
        }

        public Dictionary<string, Perfil_941lp> ObtenerCompositePerfiles_941lp()
        {
            // 1. Obtener los perfiles reales (roles) desde la tabla Perfil_941lp
            var perfilesDesdeBD = dao_941lp.RetornarLista_941lp(
                "SELECT nombrePerfil_941lp FROM Perfil_941lp WHERE nombrePerfil_941lp IS NOT NULL",
                reader => reader.GetString(0)
            );

            // 2. Inicializar los perfiles como objetos Familia_941lp
            var perfilesCompuestos = new Dictionary<string, Perfil_941lp>();
            foreach (var nombrePerfil in perfilesDesdeBD)
            {
                perfilesCompuestos[nombrePerfil] = new Familia_941lp(nombrePerfil);
            }

            // 3. Obtener los permisos simples (tabla Permiso_941lp)
            var permisosSimples = RetornarPermisosSimple_941lp();
            var dicPermisosSimples = permisosSimples.ToDictionary(p => p.nombrePermiso_941lp, p => (Perfil_941lp)p);

            // 4. Relacionar perfil <-> permiso simple (tabla Perfil_Permiso_941lp)
            var relacionesPerfilPermiso = dao_941lp.RetornarLista_941lp(
                "SELECT nombrePerfil_941lp, nombrePermiso_941lp FROM Perfil_Permiso_941lp",
                reader => (reader.GetString(0), reader.GetString(1))
            );

            foreach (var (nombrePerfil, nombrePermiso) in relacionesPerfilPermiso)
            {
                if (perfilesCompuestos.TryGetValue(nombrePerfil, out var perfil) &&
                    dicPermisosSimples.TryGetValue(nombrePermiso, out var permisoSimple))
                {
                    if(perfil is Familia_941lp familia_941lp)
                        familia_941lp.AgregarPermiso_941lp(permisoSimple);
                }
            }

            // 5. Obtener estructura completa de familias
            var dicFamilias = ObtenerCompositeFamilias_941lp(); // Ej: {"GestionUsuarios": Familia_941lp armada}

            // 6. Relacionar perfil <-> familia (tabla Perfil_Familia_941lp)
            var relacionesPerfilFamilia = dao_941lp.RetornarLista_941lp(
                "SELECT nombrePerfil_941lp, nombreFamilia_941lp FROM Perfil_Familia_941lp",
                reader => (reader.GetString(0), reader.GetString(1))
            );

            foreach (var (nombrePerfil, nombreFamilia) in relacionesPerfilFamilia)
            {
                if (perfilesCompuestos.TryGetValue(nombrePerfil, out var perfil) &&
                    dicFamilias.TryGetValue(nombreFamilia, out var familiaArmada))
                {
                    if (perfil is Familia_941lp familia_941lp)
                        familia_941lp.AgregarPermiso_941lp(familiaArmada);
                }
            }

            return perfilesCompuestos;
        }



    }
}
