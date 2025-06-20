using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPerfil_941lp
    {
        ormPerfil_941lp orm_941lp;
        ormPermiso_941lp ormPermiso_941Lp;
        ormFamilia_941lp ormFamilia_941Lp;
        public bllPerfil_941lp()
        {
            orm_941lp = new ormPerfil_941lp();
            ormPermiso_941Lp = new ormPermiso_941lp();
            ormFamilia_941Lp = new ormFamilia_941lp();
        }

        public void AltaPerfil_941lp(string nombrePerfil_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombrePerfil_941lp);
            orm_941lp.AltaPerfil_941lp(f_941lp);
        }

        public bool VerificarDuplicados_941lp(List<string> listaSeleccionados_941lp)
        {
            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp();
            var familias_941lp = ormFamilia_941Lp.RetornarFamilias_941lp();
            var familiasDict_941lp = familias_941lp.ToDictionary(f => f.nombrePermiso_941lp);

            var permisosVisitados = new HashSet<string>();
            var familiasVisitadas = new HashSet<string>();

            foreach (string nombre in listaSeleccionados_941lp)
            {
                // 1. ¿Es permiso simple?
                var permisoSimple = permisosSimples_941lp.FirstOrDefault(p => p.nombrePermiso_941lp == nombre);
                if (permisoSimple != null)
                {
                    if (!permisosVisitados.Add(permisoSimple.nombrePermiso_941lp))
                        throw new Exception($"Permiso simple duplicado: '{nombre}'");
                    continue;
                }

                // 2. ¿Es familia?
                if (familiasDict_941lp.TryGetValue(nombre, out Familia_941lp familia))
                {
                    if (!familiasVisitadas.Add(familia.nombrePermiso_941lp))
                        throw new Exception($"Familia duplicada: '{nombre}'");

                    VerificarHijosRecursivos(familia, permisosVisitados, familiasVisitadas);
                    continue;
                }

                // 3. No existe
                throw new Exception($"Elemento no reconocido: '{nombre}'");
            }

            return true;
        }

        private void VerificarHijosRecursivos(Familia_941lp familia, HashSet<string> permisosVisitados, HashSet<string> familiasVisitadas)
        {
            foreach (var hijo in familia.ObtenerPermisos())
            {
                if (hijo is PermisoSimple_941lp simple)
                {
                    if (!permisosVisitados.Add(simple.nombrePermiso_941lp))
                        throw new Exception($"Permiso simple duplicado dentro de familia: '{simple.nombrePermiso_941lp}'");
                }
                else if (hijo is Familia_941lp subFamilia)
                {
                    if (!familiasVisitadas.Add(subFamilia.nombrePermiso_941lp))
                        throw new Exception($"Familia duplicada dentro de otra familia: '{subFamilia.nombrePermiso_941lp}'");

                    VerificarHijosRecursivos(subFamilia, permisosVisitados, familiasVisitadas);
                }
            }
        }


        public bool VerificarNombreDePerfil_941lp(string nombrePerfil_941lp)
        {
            return orm_941lp.VerificarNombreDePerfil_941lp(nombrePerfil_941lp);
        }

        public List<Perfil_941lp> RetornarPerfiles_941lp()
        {
            return orm_941lp.ObtenerCompositePerfiles_941lp().Values.ToList();
        }
    }
}
