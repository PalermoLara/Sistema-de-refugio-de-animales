using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllFamiliaTablasIntermedias_941lp
    {
        ormFamilia_941lp orm_941lp;
        ormPermiso_941lp ormPermiso_941Lp;
        ormPerfil_941lp ormPerfil_941Lp;
        ormIntemedia_941lp OrmIntemedia_941Lp;
        ormFamiliaPermiso_941lp ormFamiliaPermiso_941Lp;
        ormPerfilPermiso_941lp ormPerfilPermiso_941Lp;
        ormPerfilFamilia_941lp ormPerfilFamilia_941Lp;

        public bllFamiliaTablasIntermedias_941lp()
        {
            orm_941lp = new ormFamilia_941lp();
            ormPermiso_941Lp = new ormPermiso_941lp();
            OrmIntemedia_941Lp = new ormIntemedia_941lp();
            ormPerfil_941Lp = new ormPerfil_941lp();
            ormFamiliaPermiso_941Lp = new ormFamiliaPermiso_941lp();
            ormPerfilFamilia_941Lp = new ormPerfilFamilia_941lp();
            ormPerfilPermiso_941Lp = new ormPerfilPermiso_941lp();
        }

        private void EliminarPermisosRepetidosDePadres(List<Perfil_941lp> padres, List<Perfil_941lp> permisosAsignados)
        {
            foreach (var padre in padres)
            {
                foreach (var permiso in permisosAsignados)
                {
                    QuitarPermisoRecursivoDesdePerfil((Familia_941lp)padre, permiso);
                }
            }
        }

        private void QuitarPermisoRecursivoDesdePerfil(Familia_941lp perfil, Perfil_941lp permisoABuscar)
        {
            var hijos = perfil.ObtenerPermisos_941lp().ToList(); // Copia segura para iterar

            foreach (var hijo in hijos)
            {
                if (hijo.nombrePermiso_941lp == permisoABuscar.nombrePermiso_941lp)
                {
                    perfil.EliminarPermiso_941lp(hijo);

                    // Eliminar de la BD según tipo
                    if (hijo is PermisoSimple_941lp)
                    {
                        if(ormPerfil_941Lp.RetornarPerfiles_941lp().Find(x=>x.nombrePermiso_941lp == perfil.nombrePermiso_941lp)!=null)
                        {
                            ormPerfilPermiso_941Lp.EliminarDeIntermedia_941lp(perfil.nombrePermiso_941lp, hijo.nombrePermiso_941lp);
                        }
                        if(orm_941lp.RetornarFamilias_941lp().Find(x=>x.nombrePermiso_941lp == perfil.nombrePermiso_941lp)!=null)
                        {
                            ormFamiliaPermiso_941Lp.EliminarDeIntermedia_941lp(perfil.nombrePermiso_941lp, hijo.nombrePermiso_941lp);
                            OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(perfil.nombrePermiso_941lp, hijo.nombrePermiso_941lp);
                        }
                    }
                    else if (hijo is Familia_941lp)
                    {
                        if (ormPerfil_941Lp.RetornarPerfiles_941lp().Find(x => x.nombrePermiso_941lp == perfil.nombrePermiso_941lp) != null)
                        {
                            ormPerfilFamilia_941Lp.EliminarDeIntermedia_941lp(perfil.nombrePermiso_941lp, hijo.nombrePermiso_941lp);
                        }
                        if (orm_941lp.RetornarFamilias_941lp().Find(x => x.nombrePermiso_941lp == perfil.nombrePermiso_941lp) != null)
                        {
                            OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(perfil.nombrePermiso_941lp, hijo.nombrePermiso_941lp);
                        }
                    }

                    return; // Ya lo eliminamos
                }

                // Si es una familia, seguir buscando
                if (hijo is Familia_941lp subFamilia)
                {
                    QuitarPermisoRecursivoDesdePerfil(subFamilia, permisoABuscar);
                }
            }
        }


        private List<Perfil_941lp> BuscarPadresDeFamilia(string nombreFamiliaBuscada)
        {
            var padres = new List<Perfil_941lp>();

            var familias = orm_941lp.ObtenerCompositeFamilias_941lp(); // Diccionario<string, Familia_941lp>
            var perfiles = ormPerfil_941Lp.ObtenerCompositePerfiles_941lp(); // Diccionario<string, Perfil_941lp>

            var estructuras = familias.Values.Cast<Perfil_941lp>()
                              .Concat(perfiles.Values); // Unificamos ambas listas

            foreach (var estructura in estructuras)
            {
                if(estructura.GetType() != typeof(PermisoSimple_941lp))
                if (ContieneComoHijaRecursivo((Familia_941lp)estructura, nombreFamiliaBuscada))
                {
                    padres.Add(estructura);
                }
            }

            return padres;
        }

        private bool ContieneComoHijaRecursivo(Familia_941lp perfil, string nombreHijaBuscada)
        {
            foreach (var permiso in perfil.ObtenerPermisos_941lp())
            {
                if (permiso is Familia_941lp familia)
                {
                    if (familia.nombrePermiso_941lp == nombreHijaBuscada)
                        return true;

                    if (ContieneComoHijaRecursivo(familia, nombreHijaBuscada))
                        return true;
                }
            }

            return false;
        }

        public void AltaFamiliaIntermedia_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombrePerfil_941lp);
            List<PermisoSimple_941lp> listaSimples_941lp = new List<PermisoSimple_941lp>();
            List<Familia_941lp> listaFamilia_941lp = new List<Familia_941lp>();
            var permisosYaAsignados = new HashSet<string>();
            var familiasYaIncluidas = new HashSet<string>();

            var permisosSimples = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura = orm_941lp.RetornarFamilias_941lp()
                .ToDictionary(f => f.nombrePermiso_941lp);

            var familiasEstructuradas = orm_941lp.ObtenerCompositeFamilias_941lp();

            foreach (string nombre in permisosAñadir_941lp)
            {
                if (permisosSimples.TryGetValue(nombre, out var simple))
                {
                    listaSimples_941lp.Add(simple);
                }
                else if (familiasSinEstructura.ContainsKey(nombre))
                {
                    if (familiasEstructuradas.TryGetValue(nombre, out var familiaCompuesta))
                    {
                        var familia = (Familia_941lp)familiaCompuesta;
                        listaFamilia_941lp.Add(familia);

                        // Expandir permisos simples
                        ExpandirPermisos(familia, permisosYaAsignados);

                        // Registrar familias hijas para evitar duplicación
                        ExpandirFamiliasInternas(familia, familiasYaIncluidas);
                    }
                }
            }

            // Eliminar permisos simples duplicados
            listaSimples_941lp.RemoveAll(p => permisosYaAsignados.Contains(p.nombrePermiso_941lp));

            // Eliminar familias hijas ya incluidas en otras
            listaFamilia_941lp.RemoveAll(f => familiasYaIncluidas.Contains(f.nombrePermiso_941lp));

            var padresDeLaFamilia = BuscarPadresDeFamilia(f_941lp.nombrePermiso_941lp);

            var permisosAAsignar = new List<Perfil_941lp>();
            permisosAAsignar.AddRange(listaSimples_941lp);
            permisosAAsignar.AddRange(listaFamilia_941lp);

            EliminarPermisosRepetidosDePadres(padresDeLaFamilia, permisosAAsignar);

            // Agregar simples
            foreach (var simple in listaSimples_941lp)
            {
                f_941lp.AgregarPermiso_941lp(simple);
                ormFamiliaPermiso_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
                OrmIntemedia_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso_941lp(familia);
                OrmIntemedia_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }
            ormPerfil_941Lp.ReconstruirComposite_941lp();
        }

        // Método auxiliar
        private void ExpandirFamiliasInternas(Familia_941lp familia, HashSet<string> acumulador)
        {
            foreach (var permiso in familia.ObtenerPermisos_941lp())
            {
                if (permiso is Familia_941lp fHija)
                {
                    if (acumulador.Add(fHija.nombrePermiso_941lp))
                    {
                        ExpandirFamiliasInternas(fHija, acumulador);
                    }
                }
            }
        }

        private void ExpandirPermisos(Familia_941lp familia, HashSet<string> acumulador)
        {
            foreach (var hijo in familia.ObtenerPermisos_941lp())
            {
                if (hijo is PermisoSimple_941lp simple)
                {
                    acumulador.Add(simple.nombrePermiso_941lp);
                }
                else if (hijo is Familia_941lp subFamilia)
                {
                    if (acumulador.Add(subFamilia.nombrePermiso_941lp))
                    {
                        ExpandirPermisos(subFamilia, acumulador);
                    }
                }
            }
        }

        public void EliminarFamiliaIntermedia_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombrePerfil_941lp);
            List<PermisoSimple_941lp> listaSimples_941lp = new List<PermisoSimple_941lp>();
            List<Familia_941lp> listaFamilia_941lp = new List<Familia_941lp>();
            var permisosYaAsignados = new HashSet<string>();
            var familiasYaIncluidas = new HashSet<string>();

            var permisosSimples = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura = orm_941lp.RetornarFamilias_941lp()
                .ToDictionary(f => f.nombrePermiso_941lp);

            var familiasEstructuradas = orm_941lp.ObtenerCompositeFamilias_941lp();

            foreach (string nombre in permisosAñadir_941lp)
            {
                if (permisosSimples.TryGetValue(nombre, out var simple))
                {
                    listaSimples_941lp.Add(simple);
                }
                else if (familiasSinEstructura.ContainsKey(nombre))
                {
                    if (familiasEstructuradas.TryGetValue(nombre, out var familiaCompuesta))
                    {
                        var familia = (Familia_941lp)familiaCompuesta;
                        listaFamilia_941lp.Add(familia);

                        // Expandir permisos simples
                        ExpandirPermisos(familia, permisosYaAsignados);

                        // Registrar familias hijas para evitar duplicación
                        ExpandirFamiliasInternas(familia, familiasYaIncluidas);
                    }
                }
            }

            // Eliminar permisos simples duplicados
            listaSimples_941lp.RemoveAll(p => permisosYaAsignados.Contains(p.nombrePermiso_941lp));

            // Eliminar familias hijas ya incluidas en otras
            listaFamilia_941lp.RemoveAll(f => familiasYaIncluidas.Contains(f.nombrePermiso_941lp));

            // Agregar simples
            foreach (var simple in listaSimples_941lp)
            {
                f_941lp.AgregarPermiso_941lp(simple);
                ormFamiliaPermiso_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
                OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso_941lp(familia);
                OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }
        }
    }
}
