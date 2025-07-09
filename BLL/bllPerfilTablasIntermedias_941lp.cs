using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using SERVICIOS;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllPerfilTablasIntermedias_941lp
    {
        ormPerfil_941lp orm_941lp;
        ormPermiso_941lp ormPermiso_941Lp;
        ormFamilia_941lp ormFamilia_941Lp;
        ormPerfilFamilia_941lp ormPerfilFamilia_941lp;
        ormPerfilPermiso_941lp ormPerfilPermiso_941lp;
        public bllPerfilTablasIntermedias_941lp()
        {
            orm_941lp = new ormPerfil_941lp();
            ormPermiso_941Lp = new ormPermiso_941lp();
            ormFamilia_941Lp = new ormFamilia_941lp();
            ormPerfilFamilia_941lp = new ormPerfilFamilia_941lp();
            ormPerfilPermiso_941lp = new ormPerfilPermiso_941lp();
        }

        private void QuitarPermisoDeOtrasFamilias(Perfil_941lp permiso_941lp,List<Familia_941lp> familiasIncluidas_941lp)
        {
            foreach (var familia_941lp in familiasIncluidas_941lp)
            {
                QuitarPermisoRecursivo_941lp(familia_941lp, permiso_941lp);
            }
        }

        private void QuitarPermisoRecursivo_941lp(Familia_941lp familia_941lp, Perfil_941lp permisoABuscar_941lp)
        {
            var hijos_941lp = familia_941lp.ObtenerPermisos_941lp().ToList();

            foreach (var hijo_941lp in hijos_941lp)
            {
                // Comparar por nombre 
                if (hijo_941lp.nombrePermiso_941lp == permisoABuscar_941lp.nombrePermiso_941lp)
                {
                    familia_941lp.EliminarPermiso_941lp(hijo_941lp);

                    // Remover de la BD según tipo
                    if (hijo_941lp is PermisoSimple_941lp)
                    {
                        ormPerfilPermiso_941lp.EliminarDeIntermedia_941lp(familia_941lp.nombrePermiso_941lp, hijo_941lp.nombrePermiso_941lp);
                    }
                    else if (hijo_941lp is Familia_941lp)
                    {
                        ormPerfilFamilia_941lp.EliminarDeIntermedia_941lp(familia_941lp.nombrePermiso_941lp, hijo_941lp.nombrePermiso_941lp);
                    }

                    return; // Ya lo eliminamos, no seguimos recorriendo
                }

                // Si es otra familia, seguir buscando recursivamente
                if (hijo_941lp is Familia_941lp subFamilia)
                {
                    QuitarPermisoRecursivo_941lp(subFamilia, permisoABuscar_941lp);
                }
            }
        }


        public void AltaPerfilIntermedias_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombrePerfil_941lp);
            List<PermisoSimple_941lp> listaSimples_941lp = new List<PermisoSimple_941lp>();
            List<Familia_941lp> listaFamilia_941lp = new List<Familia_941lp>();
            var permisosYaAsignados_941lp = new HashSet<string>();
            var familiasYaIncluidas_941lp = new HashSet<string>();

            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura_941lp = ormFamilia_941Lp.RetornarFamilias_941lp()
                .ToDictionary(f => f.nombrePermiso_941lp);

            var familiasEstructuradas_941lp = ormFamilia_941Lp.ObtenerCompositeFamilias_941lp();

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
                        ExpandirFamiliasInternas(familia_941lp, familiasYaIncluidas_941lp);
                    }
                }
            }

            // Eliminar permisos simples duplicados
            listaSimples_941lp.RemoveAll(p => permisosYaAsignados_941lp.Contains(p.nombrePermiso_941lp));

            // Eliminar familias hijas ya incluidas en otras
            listaFamilia_941lp.RemoveAll(f => familiasYaIncluidas_941lp.Contains(f.nombrePermiso_941lp));


            // Agregar simples
            foreach (var simple_941lp in listaSimples_941lp)
            {
                QuitarPermisoDeOtrasFamilias(simple_941lp, listaFamilia_941lp);
                f_941lp.AgregarPermiso_941lp(simple_941lp);
                ormPerfilPermiso_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia_941lp in listaFamilia_941lp)
            {
                QuitarPermisoDeOtrasFamilias(familia_941lp, listaFamilia_941lp);
                f_941lp.AgregarPermiso_941lp(familia_941lp);
                ormPerfilFamilia_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia_941lp.nombrePermiso_941lp);
            }
        }

        // Método auxiliar
        private void ExpandirFamiliasInternas(Familia_941lp familia_941lp, HashSet<string> acumulador_941lp)
        {
            foreach (var permiso_941lp in familia_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp is Familia_941lp fHija_941lp)
                {
                    if (acumulador_941lp.Add(fHija_941lp.nombrePermiso_941lp))
                    {
                        ExpandirFamiliasInternas(fHija_941lp, acumulador_941lp);
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

        public void EliminarPerfilIntermedia_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombrePerfil_941lp);
            List<PermisoSimple_941lp> listaSimples_941lp = new List<PermisoSimple_941lp>();
            List<Familia_941lp> listaFamilia_941lp = new List<Familia_941lp>();
            var permisosYaAsignados_941lp = new HashSet<string>();
            var familiasYaIncluidas_941lp = new HashSet<string>();

            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura_941lp = orm_941lp.ObtenerCompositeFamilias_941lp();

            var familiasEstructuradas_941lp = orm_941lp.ObtenerCompositePerfiles_941lp();

            foreach (string nombre_941lp in permisosAñadir_941lp)
            {
                if (permisosSimples_941lp.TryGetValue(nombre_941lp, out var simple_941lp))
                {
                    listaSimples_941lp.Add(simple_941lp);
                }
                else if (familiasSinEstructura_941lp.ContainsKey(nombre_941lp))
                {
                    if (familiasSinEstructura_941lp.TryGetValue(nombre_941lp, out var familiaCompuesta_941lp))
                    {
                        var familia_941lp = (Familia_941lp)familiaCompuesta_941lp;
                        listaFamilia_941lp.Add(familia_941lp);

                        // Expandir permisos simples
                        ExpandirPermisos_941lp(familia_941lp, permisosYaAsignados_941lp);

                        // Registrar familias hijas para evitar duplicación
                        ExpandirFamiliasInternas(familia_941lp, familiasYaIncluidas_941lp);
                    }
                }
            }

            // Primero contamos los permisos actuales del perfil
            int totalPermisosActuales_941lp = 0;
            var perfilActual_941lp = familiasEstructuradas_941lp.TryGetValue(nombrePerfil_941lp, out var perfil_941lp) ? perfil_941lp : null;

            if (perfilActual_941lp is Familia_941lp familiaDelPerfil)
            {
                // 1. Obtener los hijos directos del perfil
                var hijosDirectos_941lp = familiaDelPerfil.ObtenerPermisos_941lp()
                    .Select(p => p.nombrePermiso_941lp)
                    .ToHashSet();

                // 2. Simular eliminación
                foreach (var nombre_941lp in permisosAñadir_941lp)
                {
                    hijosDirectos_941lp.Remove(nombre_941lp);
                }

                // 3. Validar si quedó vacío (sin hijos directos)
                if (hijosDirectos_941lp.Count == 0)
                {
                    string exception_941lp = TraductorHelper_941lp.TraducirMensaje_941lp(
                        "FormGeneracionDePerfiles_941lp",
                        "MSG_PERFIL_VACIO",
                        "No se puede eliminar los permisos: el perfil quedaría vacío."
                    );
                    throw new InvalidOperationException(exception_941lp);
                }
            }

            // Eliminar permisos simples duplicados
            listaSimples_941lp.RemoveAll(p => permisosYaAsignados_941lp.Contains(p.nombrePermiso_941lp));

            // Eliminar familias hijas ya incluidas en otras
            listaFamilia_941lp.RemoveAll(f => familiasYaIncluidas_941lp.Contains(f.nombrePermiso_941lp));

            // Agregar simples
            foreach (var simple_941lp in listaSimples_941lp)
            {
                f_941lp.EliminarPermiso_941lp(simple_941lp);
                ormPerfilPermiso_941lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia_941lp in listaFamilia_941lp)
            {
                f_941lp.EliminarPermiso_941lp(familia_941lp);
                ormPerfilFamilia_941lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia_941lp.nombrePermiso_941lp);
            }
        }
    }
}
