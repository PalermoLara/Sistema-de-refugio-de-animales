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

        private void EliminarPermisosRepetidosDePadres(List<Perfil_941lp> contenedores_941lp, List<Perfil_941lp> permisosAsignados_941lp)
        {
            foreach (var contenedor_941lp in contenedores_941lp)
            {
                foreach (var permiso_941lp in permisosAsignados_941lp)
                {
                    QuitarPermisoRecursivoDesdePerfil_941lp((Familia_941lp)contenedor_941lp, permiso_941lp);
                }
            }
        }

        private void QuitarPermisoRecursivoDesdePerfil_941lp(Familia_941lp perfil_941lp, Perfil_941lp permisoABuscar_941lp)
        {
            var contenidos_941lp = perfil_941lp.ObtenerPermisos_941lp().ToList(); // Copia segura para iterar

            foreach (var contenido_941lp in contenidos_941lp)
            {
                if (contenido_941lp.nombrePermiso_941lp == permisoABuscar_941lp.nombrePermiso_941lp)
                {
                    perfil_941lp.EliminarPermiso_941lp(contenido_941lp);

                    // Eliminar de la BD según tipo
                    if (contenido_941lp is PermisoSimple_941lp)
                    {
                        if(ormPerfil_941Lp.RetornarPerfiles_941lp().Find(x=>x.nombrePermiso_941lp == perfil_941lp.nombrePermiso_941lp)!=null)
                        {
                            ormPerfilPermiso_941Lp.EliminarDeIntermedia_941lp(perfil_941lp.nombrePermiso_941lp, contenido_941lp.nombrePermiso_941lp);
                        }
                        if(orm_941lp.RetornarFamilias_941lp().Find(x=>x.nombrePermiso_941lp == perfil_941lp.nombrePermiso_941lp)!=null)
                        {
                            ormFamiliaPermiso_941Lp.EliminarDeIntermedia_941lp(perfil_941lp.nombrePermiso_941lp, contenido_941lp.nombrePermiso_941lp);
                            OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(perfil_941lp.nombrePermiso_941lp, contenido_941lp.nombrePermiso_941lp);
                        }
                    }
                    else if (contenido_941lp is Familia_941lp)
                    {
                        if (ormPerfil_941Lp.RetornarPerfiles_941lp().Find(x => x.nombrePermiso_941lp == perfil_941lp.nombrePermiso_941lp) != null)
                        {
                            ormPerfilFamilia_941Lp.EliminarDeIntermedia_941lp(perfil_941lp.nombrePermiso_941lp, contenido_941lp.nombrePermiso_941lp);
                        }
                        if (orm_941lp.RetornarFamilias_941lp().Find(x => x.nombrePermiso_941lp == perfil_941lp.nombrePermiso_941lp) != null)
                        {
                            OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(perfil_941lp.nombrePermiso_941lp, contenido_941lp.nombrePermiso_941lp);
                        }
                    }

                    return; // Ya lo eliminamos
                }

                // Si es una familia, seguir buscando
                if (contenido_941lp is Familia_941lp subFamilia_941lp)
                {
                    QuitarPermisoRecursivoDesdePerfil_941lp(subFamilia_941lp, permisoABuscar_941lp);
                }
            }
        }


        private List<Perfil_941lp> BuscarContenedoresDeFamilia_941lp(string nombreFamiliaBuscada_941lp)
        {
            var contenedores_941lp = new List<Perfil_941lp>();

            var familias_941lp = orm_941lp.ObtenerCompositeFamilias_941lp(); // Diccionario<string, Familia_941lp>
            var perfiles_941lp = ormPerfil_941Lp.ObtenerCompositePerfiles_941lp(); // Diccionario<string, Perfil_941lp>

            var estructuras_941lp = familias_941lp.Values.Cast<Perfil_941lp>()
                              .Concat(perfiles_941lp.Values); // Unificamos ambas listas

            foreach (var estructura_941lp in estructuras_941lp)
            {
                if(estructura_941lp.GetType() != typeof(PermisoSimple_941lp))
                if (ContieneComoHijaRecursivo_941lp((Familia_941lp)estructura_941lp, nombreFamiliaBuscada_941lp))
                {
                    contenedores_941lp.Add(estructura_941lp);
                }
            }

            return contenedores_941lp;
        }

        private bool ContieneComoHijaRecursivo_941lp(Familia_941lp perfil_941lp, string nombreContenidaBuscada_941lp)
        {
            foreach (var permiso_941lp in perfil_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp is Familia_941lp familia_941lp)
                {
                    if (familia_941lp.nombrePermiso_941lp == nombreContenidaBuscada_941lp)
                        return true;

                    if (ContieneComoHijaRecursivo_941lp(familia_941lp, nombreContenidaBuscada_941lp))
                        return true;
                }
            }

            return false;
        }

        private bool PermisoYaExisteEnHermanosOHijos_941lp(Familia_941lp familiaNueva_941lp, Perfil_941lp permiso_941lp)
        {
            string nombrePermiso_941lp = permiso_941lp.nombrePermiso_941lp;

            // Buscar todos los perfiles (familias y perfiles) que contienen a la nueva familia como hija
            var contenedores_941lp = BuscarContenedoresDeFamilia_941lp(familiaNueva_941lp.nombrePermiso_941lp);

            foreach (var c_941lp in contenedores_941lp)
            {
                var hijos = ((Familia_941lp)c_941lp).ObtenerPermisos_941lp();

                foreach (var hermano in hijos)
                {
                    if (hermano is Familia_941lp famHermano &&
                        famHermano.nombrePermiso_941lp != familiaNueva_941lp.nombrePermiso_941lp)
                    {
                        // El permiso está directo en el hermano
                        if (famHermano.ObtenerPermisos_941lp().Any(p => p.nombrePermiso_941lp == nombrePermiso_941lp))
                            return true;

                        // El permiso está en los descendientes del hermano
                        if (ContieneComoHijaRecursivo_941lp(famHermano, nombrePermiso_941lp))
                            return true;
                    }
                }
            }

            // También revisamos hijos propios (evita que lo tenga un subrol)
            if (familiaNueva_941lp.ObtenerPermisos_941lp().Any(p => p.nombrePermiso_941lp == nombrePermiso_941lp))
                return true;

            if (ContieneComoHijaRecursivo_941lp(familiaNueva_941lp, nombrePermiso_941lp))
                return true;

            return false;
        }


        public void AltaFamiliaIntermedia_941lp(string nombreFamilia_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombreFamilia_941lp);
            List<PermisoSimple_941lp> listaSimples_941lp = new List<PermisoSimple_941lp>();
            List<Familia_941lp> listaFamilia_941lp = new List<Familia_941lp>();
            var permisosYaAsignados_941lp = new HashSet<string>();
            var familiasYaIncluidas_941lp = new HashSet<string>();

            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura_941lp = orm_941lp.RetornarFamilias_941lp()
                .ToDictionary(f => f.nombrePermiso_941lp);

            var familiasEstructuradas_941lp = orm_941lp.ObtenerCompositeFamilias_941lp();

            foreach (string nombre_941lp in permisosAñadir_941lp)
            {
                if (permisosSimples_941lp.TryGetValue(nombre_941lp, out var simple_941lp))
                {
                    listaSimples_941lp.Add(simple_941lp);
                }
                else if (familiasSinEstructura_941lp.ContainsKey(nombre_941lp))
                {
                    if (familiasEstructuradas_941lp.TryGetValue(nombre_941lp, out var familiaCompuesta_941lp))
                    {
                        var familia_941lp = (Familia_941lp)familiaCompuesta_941lp;
                        listaFamilia_941lp.Add(familia_941lp);

                        // Expandir permisos simples
                        ExpandirPermisos_941lp(familia_941lp, permisosYaAsignados_941lp);

                        // Registrar familias hijas para evitar duplicación
                        ExpandirFamiliasInternas_941lp(familia_941lp, familiasYaIncluidas_941lp);
                    }
                }
            }

            // Eliminar permisos simples duplicados
            listaSimples_941lp.RemoveAll(p => permisosYaAsignados_941lp.Contains(p.nombrePermiso_941lp));

            // Eliminar familias hijas ya incluidas en otras
            listaFamilia_941lp.RemoveAll(f => familiasYaIncluidas_941lp.Contains(f.nombrePermiso_941lp));

            var contenedoresDeLaFamilia_941lp = BuscarContenedoresDeFamilia_941lp(f_941lp.nombrePermiso_941lp);



            var permisosAAsignar_941lp = new List<Perfil_941lp>();
            permisosAAsignar_941lp.AddRange(listaSimples_941lp);
            permisosAAsignar_941lp.AddRange(listaFamilia_941lp);

            foreach (var permiso_941lp in permisosAAsignar_941lp)
            {
                if (PermisoYaExisteEnHermanosOHijos_941lp(f_941lp, permiso_941lp))
                {
                    throw new InvalidOperationException($"No se puede agregar el permiso '{permiso_941lp.nombrePermiso_941lp}' porque ya existe en un hermano o hijo de la familia '{f_941lp.nombrePermiso_941lp}'.");
                }
            }

            EliminarPermisosRepetidosDePadres(contenedoresDeLaFamilia_941lp, permisosAAsignar_941lp);

            // Agregar simples
            foreach (var simple_941lp in listaSimples_941lp)
            {
                f_941lp.AgregarPermiso_941lp(simple_941lp);
                ormFamiliaPermiso_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
                OrmIntemedia_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia_941lp in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso_941lp(familia_941lp);
                OrmIntemedia_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia_941lp.nombrePermiso_941lp);
            }
            ormPerfil_941Lp.ReconstruirComposite_941lp();
        }

        // Método auxiliar
        private void ExpandirFamiliasInternas_941lp(Familia_941lp familia_941lp, HashSet<string> acumulador_941lp)
        {
            foreach (var permiso_941lp in familia_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp is Familia_941lp fContenida_941lp)
                {
                    if (acumulador_941lp.Add(fContenida_941lp.nombrePermiso_941lp))
                    {
                        ExpandirFamiliasInternas_941lp(fContenida_941lp, acumulador_941lp);
                    }
                }
            }
        }

        private void ExpandirPermisos_941lp(Familia_941lp familia_941lp, HashSet<string> acumulador_941lp)
        {
            foreach (var hijo_941lp in familia_941lp.ObtenerPermisos_941lp())
            {
                if (hijo_941lp is PermisoSimple_941lp simple_941lp)
                {
                    acumulador_941lp.Add(simple_941lp.nombrePermiso_941lp);
                }
                else if (hijo_941lp is Familia_941lp subFamilia_941lp)
                {
                    if (acumulador_941lp.Add(subFamilia_941lp.nombrePermiso_941lp))
                    {
                        ExpandirPermisos_941lp(subFamilia_941lp, acumulador_941lp);
                    }
                }
            }
        }

        public void EliminarFamiliaIntermedia_941lp(string nombreFamilia_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombreFamilia_941lp);
            List<PermisoSimple_941lp> listaSimples_941lp = new List<PermisoSimple_941lp>();
            List<Familia_941lp> listaFamilia_941lp = new List<Familia_941lp>();
            var permisosYaAsignados_941lp = new HashSet<string>();
            var familiasYaIncluidas_941lp = new HashSet<string>();

            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura_941lp = orm_941lp.RetornarFamilias_941lp()
                .ToDictionary(f => f.nombrePermiso_941lp);

            var familiasEstructuradas_941lp = orm_941lp.ObtenerCompositeFamilias_941lp();

            foreach (string nombre_941lp in permisosAñadir_941lp)
            {
                if (permisosSimples_941lp.TryGetValue(nombre_941lp, out var simple_941lp))
                {
                    listaSimples_941lp.Add(simple_941lp);
                }
                else if (familiasSinEstructura_941lp.ContainsKey(nombre_941lp))
                {
                    if (familiasEstructuradas_941lp.TryGetValue(nombre_941lp, out var familiaCompuesta_941lp))
                    {
                        var familia_941lp = (Familia_941lp)familiaCompuesta_941lp;
                        listaFamilia_941lp.Add(familia_941lp);

                        // Expandir permisos simples
                        ExpandirPermisos_941lp(familia_941lp, permisosYaAsignados_941lp);

                        // Registrar familias hijas para evitar duplicación
                        ExpandirFamiliasInternas_941lp(familia_941lp, familiasYaIncluidas_941lp);
                    }
                }
            }

            // Eliminar permisos simples duplicados
            listaSimples_941lp.RemoveAll(p_941lp => permisosYaAsignados_941lp.Contains(p_941lp.nombrePermiso_941lp));

            // Eliminar familias hijas ya incluidas en otras
            listaFamilia_941lp.RemoveAll(fam_941lp => familiasYaIncluidas_941lp.Contains(fam_941lp.nombrePermiso_941lp));

            // Agregar simples
            foreach (var simple_941lp in listaSimples_941lp)
            {
                f_941lp.EliminarPermiso_941lp(simple_941lp);
                ormFamiliaPermiso_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
                OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia_941lp in listaFamilia_941lp)
            {
                f_941lp.EliminarPermiso_941lp(familia_941lp);
                OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia_941lp.nombrePermiso_941lp);
            }
        }
    }
}
