using BE;
using ORM;
using SERVICIOS;
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
        ormUsuario_941lp ormUsuario_941lp;
        ormPermiso_941lp ormPermiso_941Lp;
        ormFamilia_941lp ormFamilia_941Lp;
        ormPerfilFamilia_941lp ormPerfilFamilia_941lp;
        ormPerfilPermiso_941lp ormPerfilPermiso_941lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;
        public bllPerfil_941lp()
        {
            orm_941lp = new ormPerfil_941lp();
            ormPermiso_941Lp = new ormPermiso_941lp();
            ormFamilia_941Lp = new ormFamilia_941lp();
            ormPerfilFamilia_941lp = new ormPerfilFamilia_941lp();
            ormPerfilPermiso_941lp = new ormPerfilPermiso_941lp();
            ormUsuario_941lp = new ormUsuario_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void AltaPerfil_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
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

            var familiasEstructuradas = ormFamilia_941Lp.ObtenerCompositeFamilias_941lp();

            foreach (string nombre_941lp in permisosAñadir_941lp)
            {
                if (permisosSimples_941lp.TryGetValue(nombre_941lp, out var simple_941lp))
                {
                    listaSimples_941lp.Add(simple_941lp);
                }
                else if (familiasSinEstructura_941lp.ContainsKey(nombre_941lp))
                {
                    if (familiasEstructuradas.TryGetValue(nombre_941lp, out var familiaCompuesta_941lp))
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

            // Agregar simples
            foreach (var simple_941lp in listaSimples_941lp)
            {
                f_941lp.AgregarPermiso_941lp(simple_941lp);
                ormPerfilPermiso_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia_941lp in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso_941lp(familia_941lp);
                ormPerfilFamilia_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia_941lp.nombrePermiso_941lp);
            }

            orm_941lp.AltaPerfil_941lp(f_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion perfiles", "Perfil dada de alta", 1);
        }

        // Método auxiliar
        private void ExpandirFamiliasInternas_941lp(Familia_941lp familia_941lp, HashSet<string> acumulador_941lp)
        {
            foreach (var permiso_941lp in familia_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp is Familia_941lp fHija_941lp)
                {
                    if (acumulador_941lp.Add(fHija_941lp.nombrePermiso_941lp))
                    {
                        ExpandirFamiliasInternas_941lp(fHija_941lp, acumulador_941lp);
                    }
                }
            }
        }

        public bool VerificarDuplicados_941lp(List<string> listaSeleccionados_941lp)
        {
            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp();
            var familias_941lp = ormFamilia_941Lp.RetornarFamilias_941lp();
            var familiasDict_941lp = familias_941lp.ToDictionary(f => f.nombrePermiso_941lp);

            var permisosVisitados_941lp = new HashSet<string>();
            var familiasVisitadas_941lp = new HashSet<string>();

            foreach (string nombre_941lp in listaSeleccionados_941lp)
            {
                // 1. ¿Es permiso simple?
                var permisoSimple_941lp = permisosSimples_941lp.FirstOrDefault(p => p.nombrePermiso_941lp == nombre_941lp);
                if (permisoSimple_941lp != null)
                {
                    if (!permisosVisitados_941lp.Add(permisoSimple_941lp.nombrePermiso_941lp))
                    {
                        string excepcion1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_PERMISO_DUPLICADO", $"Permiso simple duplicado");
                        throw new Exception(excepcion1_941lp);
                    }
                    continue;
                }

                // 2. ¿Es familia?
                if (familiasDict_941lp.TryGetValue(nombre_941lp, out Familia_941lp familia_941lp))
                {
                    if (!familiasVisitadas_941lp.Add(familia_941lp.nombrePermiso_941lp))
                    {
                        string excepcion1_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_FAMILIA_DUPLICADA", $"Familia duplicada");
                        throw new Exception(excepcion1_941lp);
                    }
                    VerificarHijosRecursivos(familia_941lp, permisosVisitados_941lp, familiasVisitadas_941lp);
                    continue;
                }

                // 3. No existe
                string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_ELEMENTO_NO_RECONOCIDO", $"Elemento no reconocido");
                throw new Exception(excepcion_941lp);
            }

            return true;
        }

        private void EliminarPermisosRepetidosDePadres_941lp(List<Perfil_941lp> contenedores_941lp, List<Perfil_941lp> permisosAsignados_941lp)
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

        private List<Perfil_941lp> BuscarContenedoresQueIncluyen_941lp(string nombreElemento_941lp)
        {
            var contenedores_941lp = new List<Perfil_941lp>();

            var familias_941lp = orm_941lp.ObtenerCompositeFamilias_941lp(); 
            var perfiles_941lp = orm_941lp.ObtenerCompositePerfiles_941lp(); 

            var estructuras_941lp = familias_941lp.Values.Cast<Perfil_941lp>()
                .Concat(perfiles_941lp.Values); 

            foreach (var estructura_941lp in estructuras_941lp)
            {
                if (estructura_941lp is Familia_941lp familia_941lp)
                {
                    if (ContieneComoHijaRecursivo_941lp(familia_941lp, nombreElemento_941lp))
                    {
                        contenedores_941lp.Add(familia_941lp);
                    }
                }
            }

            return contenedores_941lp;
        }

        private void VerificarContraContenedores_941lp(string nombreDestino_941lp, List<string> nuevosSeleccionados_941lp)
        {
            var contenedores_941lp = BuscarContenedoresQueIncluyen_941lp(nombreDestino_941lp);

            if (!contenedores_941lp.Any()) return;

            var familias_941lp = ormFamilia_941Lp.ObtenerCompositeFamilias_941lp();
            var perfiles_941lp = orm_941lp.ObtenerCompositePerfiles_941lp();
            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp().ToDictionary(p => p.nombrePermiso_941lp);

            foreach (var nombreNuevo_941lp in nuevosSeleccionados_941lp)
            {
                foreach (var contenedor_941lp in contenedores_941lp)
                {
                    if (ContieneComoHijaRecursivo_941lp((Familia_941lp)contenedor_941lp, nombreNuevo_941lp))
                    {
                        string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_PERMISO_CONTENIDAO_EN_EL_MISMO_CONTENEDOR", $"Un permiso  ya existe en la estructura del contenedor");
                        throw new Exception(excepcion_941lp);
                    }
                }
            }
        }


        private bool ContieneComoHijaRecursivo_941lp(Familia_941lp perfil_941lp, string nombreContenidaBuscada_941lp)
        {
            foreach (var permiso_941lp in perfil_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp.nombrePermiso_941lp == nombreContenidaBuscada_941lp)
                    return true;
                if (permiso_941lp is Familia_941lp familia_941lp)
                {
                    if (ContieneComoHijaRecursivo_941lp(familia_941lp, nombreContenidaBuscada_941lp))
                        return true;
                }
            }

            return false;
        }

        private void VerificarHijosRecursivos(Familia_941lp familia, HashSet<string> permisosVisitados_941LP, HashSet<string> familiasVisitadas_941lp)
        {
            foreach (var hijo_941LP in familia.ObtenerPermisos_941lp())
            {
                if (hijo_941LP is PermisoSimple_941lp simple_941lp)
                {
                    if (!permisosVisitados_941LP.Add(simple_941lp.nombrePermiso_941lp))
                    {
                        string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_PERMISO_DUPLICADA_DENTRO_DE_OTRA_FAMILIA", $"Permiso simple duplicado dentro de familia");
                        throw new Exception(excepcion_941lp);
                    }
                }
                else if (hijo_941LP is Familia_941lp subFamilia_941lp)
                {
                    if (!familiasVisitadas_941lp.Add(subFamilia_941lp.nombrePermiso_941lp))
                    {
                        string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_FAMILIA_DUPLICADA_DENTRO_DE_OTRA_FAMILIA", $"Familia duplicada dentro de otra familia");
                        throw new Exception(excepcion_941lp);
                    }
                    VerificarHijosRecursivos(subFamilia_941lp, permisosVisitados_941LP, familiasVisitadas_941lp);
                }
            }
        }

        #region Validar no repeticion de permisos preexistentes
        public bool ValidarContraEstructuraEnMemoria_941lp(string nombreDestino_941lp, List<string> nuevosSeleccionados_941lp)
        {
            var perfiles_941lp = orm_941lp.ObtenerCompositePerfiles_941lp();
            var familias_941lp = ormFamilia_941Lp.ObtenerCompositeFamilias_941lp();

            Familia_941lp estructuraBase_941lp = null;

            if (familias_941lp.TryGetValue(nombreDestino_941lp, out var familia_941lp))
            {
                estructuraBase_941lp = (Familia_941lp)familia_941lp;
            }
            else if (perfiles_941lp.TryGetValue(nombreDestino_941lp, out var perfil_941lp))
            {
                estructuraBase_941lp = (Familia_941lp)perfil_941lp;
            }
            else
            {
                string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_PERFIL_NO_ENCONTRADO", $"No se encontró el perfil");
                throw new Exception(excepcion_941lp);
            }

            var permisosSimples_941lp = ormPermiso_941Lp.RetornarPermisos_941lp().ToDictionary(p => p.nombrePermiso_941lp);
            var permisosAAsignar_941lp = new List<Perfil_941lp>();

            foreach (var nombre_941lp in nuevosSeleccionados_941lp)
            {
                if (permisosSimples_941lp.TryGetValue(nombre_941lp, out var simple_941lp))
                {
                    permisosAAsignar_941lp.Add(simple_941lp);
                }
                else if (familias_941lp.TryGetValue(nombre_941lp, out var fam_941lp))
                {
                    permisosAAsignar_941lp.Add(fam_941lp);
                }
            }

            // Verificación 1: en el propio contenedor
            foreach (var permiso_941lp in permisosAAsignar_941lp)
            {
                if (PermisoYaExisteEnContenedor_941lp(estructuraBase_941lp, permiso_941lp))
                {
                    string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_PERMISO_CONTENIDAO_EN_EL_MISMO_CONTENEDOR_PERFIL", $"Un permiso ya existe en la estructura del contenedor");
                    throw new InvalidOperationException(excepcion_941lp);
                }
            }

            // Verificación 2: en los contenedores ascendentes
            VerificarContraContenedores_941lp(nombreDestino_941lp, nuevosSeleccionados_941lp);

            return true;
        }


        private bool PermisoYaExisteEnContenedor_941lp(Familia_941lp contenedor_941lp, Perfil_941lp permisoAValidar_941lp)
        {
            string nombrePermiso_941lp = permisoAValidar_941lp.nombrePermiso_941lp;

            return ContieneComoHijaRecursivo_941lp(contenedor_941lp, nombrePermiso_941lp)
                   || contenedor_941lp.ObtenerPermisos_941lp().Any(p => p.nombrePermiso_941lp == nombrePermiso_941lp);
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
            if (ormUsuario_941lp.PerfilAsignadoAUsuario_941lp(nombreFamilia_941lp))
            {
                string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_PERFIL_CONTENIDO_EN_FAMILIA", "No se puede eliminar el perfil porque está asignado a uno o más usuarios.");
                throw new InvalidOperationException(excepcion_941lp);
            }
            // 1. Obtener la familia compuesta desde la estructura en memoria
            var familiasEstructuradas_941lp = orm_941lp.ObtenerCompositePerfiles_941lp();

            if (!familiasEstructuradas_941lp.TryGetValue(nombreFamilia_941lp, out var familiaBase_941lp))
                return; // o lanzar excepción si no existe

            var f_941lp = (Familia_941lp)familiaBase_941lp;

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
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion perfiles", "Perfil eliminado", 1);
        }
    }
}
