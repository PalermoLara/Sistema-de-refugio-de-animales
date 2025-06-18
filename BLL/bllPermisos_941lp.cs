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
        private Dictionary<string, Permiso_941lp> estructuraComposite_941lp;
        ormPermisos_941lp orm_941lp;

        public bllPermisos_941lp()
        {
            orm_941lp = new ormPermisos_941lp();
        }

        public void CargarEstructura()
        {
            estructuraComposite_941lp = orm_941lp.ObtenerEstructuraCompletaComposite_941lp();
        }

        public void AltaPermiso_941lp(string nombrePermiso_941lp, bool esRol_941lp)
        {
            Familia_941lp familia_941lp = new Familia_941lp(nombrePermiso_941lp, esRol_941lp);
            orm_941lp.AltaPermiso_941lp(familia_941lp);
            CargarEstructura();
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
            return estructuraComposite_941lp.TryGetValue(nombrePermiso_941lp, out var permiso) && permiso.compuesto_941lp;
        }

        public bool VerificarNombreDeRolFamlia_941lp(string nombrePermiso_941lp)
        {
            return orm_941lp.VerificarNombreDeRolFamilia_941lp(nombrePermiso_941lp);
        }

        public void EliminarPermiso_941lp(string nombrePermiso_941lp)
        {
            Permiso_941lp p_941lp = RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == nombrePermiso_941lp);
            orm_941lp.Eliminar_941lp(p_941lp);
            CargarEstructura();
        }

        public void EliminarDeIntermediaPermanente_941lp(string permisoCompuesto941lp, string permisoAñadido941lp)
        {
            orm_941lp.EliminarDeIntermediaPermanente_941lp(permisoCompuesto941lp, permisoAñadido941lp);
            Familia_941lp p_941lp = (Familia_941lp)RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == permisoCompuesto941lp);
            p_941lp.EliminarPermiso(RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == permisoAñadido941lp));
        }

        public void EliminarIntermedia_941lp(string nombreCompuesto_941lp, string permisoAñadido_941lp)
        {
            Familia_941lp p_941lp = (Familia_941lp)RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == nombreCompuesto_941lp);
            p_941lp.EliminarPermiso(RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == permisoAñadido_941lp));
            orm_941lp.EliminarDeIntermedia_941lp(nombreCompuesto_941lp, permisoAñadido_941lp);
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

        public Permiso_941lp ObtenerPermiso_941lp(string nombre)
        {
            estructuraComposite_941lp.TryGetValue(nombre, out var permiso);
            return permiso;
        }

        public List<Permiso_941lp> RetornarPermisos_941lp()
        {
            return estructuraComposite_941lp.Values.ToList();
        }

        public Permiso_941lp ObtenerPermisoDesdeComposite_941lp(Dictionary<string, Permiso_941lp> composite_941lp, string nombre_941lp)
        {
            return orm_941lp.ObtenerPermisoDesdeComposite_941lp(composite_941lp,nombre_941lp);
        }

        public void AltaIntermedia_941lp(string nombrePermiso_941lp, List<string> permisosAñadidos_941lp)
        {
            Familia_941lp f_941lp = (Familia_941lp)RetornarPermisos_941lp().Find(x=>x.nombrePermiso_941lp == nombrePermiso_941lp);
            foreach(string p_941lp in permisosAñadidos_941lp)
            {
                Permiso_941lp permiso_941Lp = RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == p_941lp);
                f_941lp.AgregarPermiso(permiso_941Lp);
                orm_941lp.AltaIntermedia_941lp(f_941lp, p_941lp);
            }
        }
    }
}
