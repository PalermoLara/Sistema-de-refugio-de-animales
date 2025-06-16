using ORM;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPermisos_941lp
    {
        ormPermisos_941lp orm_941lp;

        public bllPermisos_941lp()
        {
            orm_941lp = new ormPermisos_941lp();
        }

        public void AltaPermiso_941lp(string nombrePermiso_941lp, bool esRol_941lp)
        {
            Familia_941lp familia_941lp = new Familia_941lp(nombrePermiso_941lp, esRol_941lp);
            orm_941lp.AltaPermiso_941lp(familia_941lp);
        }

        public bool VerificarDuplicados_941lp(List<string> listaPermisos_941lp)
        {
            HashSet<string> permisosSimples = new HashSet<string>(); // Para detectar duplicados

            foreach (string nombre_941lp in listaPermisos_941lp)
            {
                Permiso_941lp permiso = RetornarPermisos_941lp().Find(x=>x.nombrePermiso_941lp == nombre_941lp); // Busca en memoria o BD

                if (permiso is PermisoSimple_941lp simple)
                {
                    if (!permisosSimples.Add(simple.nombrePermiso_941lp))
                        throw new Exception($"Permiso duplicado: '{simple.nombrePermiso_941lp}' ya está asignado.");
                }
                else if (permiso is Familia_941lp compuesto)
                {
                    AgregarHijosSimples_941lp(compuesto, permisosSimples);
                }
            }
            return true;
        }

        public bool VerificarSiEsCompuesto(string nombrePermiso_941lp)
        {
            return ObtenerPermiso_941lp(nombrePermiso_941lp).esCompuesto_941lp;
        }

        public bool VerificarNombreDeRolFamlia_941lp(string nombrePermiso_941lp)
        {
            return orm_941lp.VerificarNombreDeRolFamilia_941lp(nombrePermiso_941lp);
        }

        public void EliminarFamiliar_941lp(string nombrePermiso_941lp)
        {
            Permiso_941lp p_941lp = RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == nombrePermiso_941lp);
            orm_941lp.EliminarDeIntermedia_941lp(p_941lp);
            orm_941lp.Eliminar_941lp(p_941lp);
        }

        private void AgregarHijosSimples_941lp(Familia_941lp compuesto, HashSet<string> permisosSimples)
        {
            foreach (var hijo in compuesto.ObtenerPermisos())
            {
                if (hijo is PermisoSimple_941lp simple)
                {
                    if (!permisosSimples.Add(simple.nombrePermiso_941lp))
                        throw new Exception($"Permiso duplicado: '{simple.nombrePermiso_941lp}' ya está asignado por otro permiso o familia.");
                }
                else if (hijo is Familia_941lp subCompuesto)
                {
                    AgregarHijosSimples_941lp(subCompuesto, permisosSimples); // recursión
                }
            }
        }

        public Permiso_941lp ObtenerPermiso_941lp(string nombre_941lp)
        {
            return orm_941lp.ObtenerPermiso_941lp(nombre_941lp);
        }

        public void AltaIntermedia_941lp(string nombrePermiso_941lp, List<string> permisosAñadidos_941lp)
        {
            Familia_941lp f_941lp = (Familia_941lp)ObtenerPermiso_941lp(nombrePermiso_941lp);
            foreach(string p_941lp in permisosAñadidos_941lp)
            {
                permisoIntermedio_941lp pIntermedio_941lp = new permisoIntermedio_941lp(nombrePermiso_941lp, p_941lp);
                orm_941lp.AltaIntermedia_941lp(pIntermedio_941lp);
            }
        }

        public List<Permiso_941lp> RetornarPermisos_941lp()
        {
            return orm_941lp.RetornarPermisos_941lp();
        }
    }
}
