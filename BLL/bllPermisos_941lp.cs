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
        ormPermiso_941lp orm_941lp;

        public bllPermisos_941lp()
        {
            orm_941lp = new ormPermiso_941lp();
        }

        public bool VerificarNombreDePatente_941lp(string nombrePatente_941lp)
        {
            return orm_941lp.VerificarNombreDePatente_941lp(nombrePatente_941lp);
        }

        //public void AltaPermiso_941lp(string nombrePermiso_941lp, bool esRol_941lp)
        //{
        //    Familia_941lp familia_941lp = new Familia_941lp(nombrePermiso_941lp, esRol_941lp);
        //    orm_941lp.AltaPerfil_941lp(familia_941lp);
        //    CargarEstructura();
        //}

        

        //public bool VerificarSiEsCompuesto(string nombrePermiso_941lp)
        //{
        //    return estructuraComposite_941lp.TryGetValue(nombrePermiso_941lp, out var permiso) && permiso.compuesto_941lp;
        //}

        //public bool VerificarNombreDeRolFamlia_941lp(string nombrePermiso_941lp)
        //{
        //    return orm_941lp.VerificarNombreDePerfil_941lp(nombrePermiso_941lp);
        //}

        //public void EliminarPermiso_941lp(string nombrePermiso_941lp)
        //{
        //    Perfil_941lp p_941lp = RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == nombrePermiso_941lp);
        //    orm_941lp.Eliminar_941lp(p_941lp);
        //    CargarEstructura();
        //}

        //public void EliminarDeIntermediaPermanente_941lp(string permisoCompuesto941lp, string permisoAñadido941lp)
        //{
        //    orm_941lp.EliminarDeIntermediaPermanente_941lp(permisoCompuesto941lp, permisoAñadido941lp);
        //    Familia_941lp p_941lp = (Familia_941lp)RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == permisoCompuesto941lp);
        //    p_941lp.EliminarPermiso(RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == permisoAñadido941lp));
        //}

        //public void EliminarIntermedia_941lp(string nombreCompuesto_941lp, string permisoAñadido_941lp)
        //{
        //    Familia_941lp p_941lp = (Familia_941lp)RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == nombreCompuesto_941lp);
        //    p_941lp.EliminarPermiso(RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == permisoAñadido_941lp));
        //    orm_941lp.EliminarDeIntermedia_941lp(nombreCompuesto_941lp, permisoAñadido_941lp);
        //}

        //public Perfil_941lp ObtenerPermiso_941lp(string nombre)
        //{
        //    estructuraComposite_941lp.TryGetValue(nombre, out var permiso);
        //    return permiso;
        //}

        public List<PermisoSimple_941lp> RetornarPermisos_941lp()
        {
            return orm_941lp.RetornarPermisos_941lp();
        }

        //public void AltaIntermedia_941lp(string nombrePermiso_941lp, List<string> permisosAñadidos_941lp)
        //{
        //    Familia_941lp f_941lp = (Familia_941lp)RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == nombrePermiso_941lp);
        //    foreach (string p_941lp in permisosAñadidos_941lp)
        //    {
        //        Perfil_941lp permiso_941Lp = RetornarPermisos_941lp().Find(x => x.nombrePermiso_941lp == p_941lp);
        //        f_941lp.AgregarPermiso(permiso_941Lp);
        //        orm_941lp.AltaIntermedia_941lp(f_941lp, p_941lp);
        //    }
        //}
    }
}
