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
        ormPerfilFamilia_941lp ormPerfilFamilia_941lp;
        ormPerfilPermiso_941lp ormPerfilPermiso_941lp;
        public bllPerfil_941lp()
        {
            orm_941lp = new ormPerfil_941lp();
            ormPermiso_941Lp = new ormPermiso_941lp();
            ormFamilia_941Lp = new ormFamilia_941lp();
            ormPerfilFamilia_941lp = new ormPerfilFamilia_941lp();
            ormPerfilPermiso_941lp = new ormPerfilPermiso_941lp();
        }

        public void AltaPerfil_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombrePerfil_941lp);
            List<PermisoSimple_941lp> listaSimples_941lp = new List<PermisoSimple_941lp>();
            List<Familia_941lp> listaFamilia_941lp = new List<Familia_941lp>();
            var permisosYaAsignados = new HashSet<string>();
            var familiasYaIncluidas = new HashSet<string>();

            var permisosSimples = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura = ormFamilia_941Lp.RetornarFamilias_941lp()
                .ToDictionary(f => f.nombrePermiso_941lp);

            var familiasEstructuradas = ormFamilia_941Lp.ObtenerCompositeFamilias_941lp();

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
                        ExpandirPermisos_941lp(familia, permisosYaAsignados);

                        // Registrar familias hijas para evitar duplicación
                        ExpandirFamiliasInternas(familia, familiasYaIncluidas);
                    }
                }
            }

            // Eliminar permisos simples duplicados
            listaSimples_941lp.RemoveAll(p => permisosYaAsignados.Contains(p.nombrePermiso_941lp));

            // Eliminar familias hijas ya incluidas en otras
            listaFamilia_941lp.RemoveAll(f => familiasYaIncluidas.Contains(f.nombrePermiso_941lp));

            string[] permisosPorDefecto = { "Cambiar contraseña", "Cambiar idioma", "Cerrar sesion" };

            foreach (string permisoDefecto in permisosPorDefecto)
            {
                // Si no está ya heredado ni agregado directamente
                bool yaEsta = listaSimples_941lp.Any(p => p.nombrePermiso_941lp == permisoDefecto)
                           || permisosYaAsignados.Contains(permisoDefecto);

                if (!yaEsta)
                {
                    if (permisosSimples.TryGetValue(permisoDefecto, out var pDefecto))
                    {
                        listaSimples_941lp.Add(pDefecto);
                    }
                }
            }

            // Agregar simples
            foreach (var simple in listaSimples_941lp)
            {
                f_941lp.AgregarPermiso_941lp(simple);
                ormPerfilPermiso_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso_941lp(familia);
                ormPerfilFamilia_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }

            orm_941lp.AltaPerfil_941lp(f_941lp);
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
                        if (orm_941lp.RetornarPerfiles_941lp().Find(x => x.nombrePermiso_941lp == perfil_941lp.nombrePermiso_941lp) != null)
                        {
                            ormPerfilPermiso_941lp.EliminarDeIntermedia_941lp(perfil_941lp.nombrePermiso_941lp, contenido_941lp.nombrePermiso_941lp);
                        }
                    }
                    else if (contenido_941lp is Familia_941lp)
                    {
                        if (orm_941lp.RetornarPerfiles_941lp().Find(x => x.nombrePermiso_941lp == perfil_941lp.nombrePermiso_941lp) != null)
                        {
                            ormPerfilFamilia_941lp.EliminarDeIntermedia_941lp(perfil_941lp.nombrePermiso_941lp, contenido_941lp.nombrePermiso_941lp);
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
            var perfiles_941lp = orm_941lp.ObtenerCompositePerfiles_941lp(); // Diccionario<string, Perfil_941lp>

            var estructuras_941lp = familias_941lp.Values.Cast<Perfil_941lp>()
                              .Concat(perfiles_941lp.Values); // Unificamos ambas listas

            foreach (var estructura_941lp in estructuras_941lp)
            {
                if (estructura_941lp.GetType() != typeof(PermisoSimple_941lp))
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

        private void VerificarHijosRecursivos(Familia_941lp familia, HashSet<string> permisosVisitados, HashSet<string> familiasVisitadas)
        {
            foreach (var hijo in familia.ObtenerPermisos_941lp())
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

        #region Validar no repeticion de permisos preexistentes
        public bool ValidarContraEstructuraEnMemoria_941lp(string nombreDestino, List<string> nuevosSeleccionados)
        {
            var perfiles = orm_941lp.ObtenerCompositePerfiles_941lp();
            var familias = ormFamilia_941Lp.ObtenerCompositeFamilias_941lp();

            Familia_941lp estructuraBase = null;

            if (familias.TryGetValue(nombreDestino, out var familia))
            {
                estructuraBase = (Familia_941lp)familia;
            }
            else if (perfiles.TryGetValue(nombreDestino, out var perfil))
            {
                estructuraBase = (Familia_941lp)perfil;
            }
            else
            {
                throw new Exception($"No se encontró '{nombreDestino}' en memoria.");
            }

            // Construyo los objetos a asignar
            var permisosSimples = ormPermiso_941Lp.RetornarPermisos_941lp().ToDictionary(p => p.nombrePermiso_941lp);
            var familiasEstructuradas = orm_941lp.ObtenerCompositeFamilias_941lp();

            var permisosAAsignar = new List<Perfil_941lp>();
            foreach (var nombre in nuevosSeleccionados)
            {
                if (permisosSimples.TryGetValue(nombre, out var simple))
                {
                    permisosAAsignar.Add(simple);
                }
                else if (familiasEstructuradas.TryGetValue(nombre, out var fam))
                {
                    permisosAAsignar.Add(fam);
                }
            }

            // 1. Validar si algún permiso ya está en hermanos o hijos
            foreach (var permiso in permisosAAsignar)
            {
                if (PermisoYaExisteEnHermanosOHijos_941lp(estructuraBase, permiso))
                {
                    throw new InvalidOperationException($"El permiso '{permiso.nombrePermiso_941lp}' ya existe en un hermano o hijo de la familia '{estructuraBase.nombrePermiso_941lp}'.");
                }
            }

            // 2. Eliminar de los padres repetidos (si hay)
            var padres = BuscarContenedoresDeFamilia_941lp(nombreDestino);
            if (padres.Count > 0)
            {
                EliminarPermisosRepetidosDePadres(padres, permisosAAsignar);
            }

            return true;
        }


        private void ExpandirPermisos_941lp(Familia_941lp familia, HashSet<string> acumulador)
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
                        ExpandirPermisos_941lp(subFamilia, acumulador);
                    }
                }
            }
        }
        #endregion

        public bool VerificarNombreDePerfil_941lp(string nombrePerfil_941lp)
        {
            return orm_941lp.VerificarNombreDePerfil_941lp(nombrePerfil_941lp);
        }

        public List<Perfil_941lp> RetornarPerfiles_941lp()
        {
            return orm_941lp.ObtenerCompositePerfiles_941lp().Values.ToList();
        }

        public void EliminarPerfil_941lp(string nombreFamilia_941lp)
        {
            // 1. Obtener la familia compuesta desde la estructura en memoria
            var familiasEstructuradas = orm_941lp.ObtenerCompositePerfiles_941lp();

            if (!familiasEstructuradas.TryGetValue(nombreFamilia_941lp, out var familiaBase))
                return; // o lanzar excepción si no existe

            var f_941lp = (Familia_941lp)familiaBase;

            // 2. Recorrer su estructura interna para eliminar relaciones
            foreach (var permiso_941lp in f_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp is PermisoSimple_941lp simple_941lp)
                {
                    ormPerfilPermiso_941lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
                }
                else if (permiso_941lp is Familia_941lp subFamilia_941lp)
                {
                    ormPerfilFamilia_941lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, subFamilia_941lp.nombrePermiso_941lp);
                }
            }

            // 3. Eliminar la familia de la base de datos
            orm_941lp.Eliminar_941lp(f_941lp);
        }
    }
}
