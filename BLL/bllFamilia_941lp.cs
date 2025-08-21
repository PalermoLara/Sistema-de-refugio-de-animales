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
    public class bllFamilia_941lp
    {
        ormFamilia_941lp orm_941lp;
        ormPermiso_941lp ormPermiso_941Lp;
        ormIntemedia_941lp OrmIntemedia_941Lp;
        ormPerfil_941lp OrmPerfil_941lp;
        ormFamiliaPermiso_941lp ormFamiliaPermiso_941Lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;

        public bllFamilia_941lp()
        {
            OrmPerfil_941lp = new ormPerfil_941lp();
            orm_941lp = new ormFamilia_941lp();
            ormPermiso_941Lp = new ormPermiso_941lp();
            OrmIntemedia_941Lp = new ormIntemedia_941lp();
            ormFamiliaPermiso_941Lp = new ormFamiliaPermiso_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void AltaFamilia_941lp(string nombreFamilia_941lp, List<string> permisosAñadir_941lp)
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
                        ExpandirPermisos(familia_941lp, permisosYaAsignados_941lp);

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

            orm_941lp.AltaFamilia_941lp(f_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion familia", "Familia dada de alta", 1);
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

        private void ExpandirPermisos(Familia_941lp familia_941lp, HashSet<string> acumulador_941lp)
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
                        ExpandirPermisos(subFamilia_941lp, acumulador_941lp);
                    }
                }
            }
        }

        private bool EstaContenidaEnOtraEstructura_941lp(string nombreFamiliaBuscada_941lp)
        {
            var familias_941lp = orm_941lp.ObtenerCompositeFamilias_941lp(); 
            var perfiles_941lp = OrmPerfil_941lp.ObtenerCompositePerfiles_941lp();

            var estructuras_941lp = familias_941lp.Values.Cast<Perfil_941lp>()
                                  .Concat(perfiles_941lp.Values);

            foreach (var estructura_941lp in estructuras_941lp)
            {
                // Evitar que se analice a sí misma
                if (estructura_941lp is Familia_941lp familiaEstructura_941lp &&
                    familiaEstructura_941lp.nombrePermiso_941lp != nombreFamiliaBuscada_941lp)
                {
                    if (ContieneComoHijaRecursivo_941lp(familiaEstructura_941lp, nombreFamiliaBuscada_941lp))
                    {
                        return true;
                    }
                }
            }

            return false;
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


        public void EliminarFamilia_941lp(string nombreFamilia_941lp)
        {
            if (EstaContenidaEnOtraEstructura_941lp(nombreFamilia_941lp))
            {
                string excepcion_941lp = TraductorHelper_941lp.TraducirMensaje_941lp("FormGeneracionDePerfiles_941lp", "MSG_FAMILIA_CONTENIDA", $"La familia  no puede eliminarse porque está contenida dentro de otra familia o perfil.");
                throw new InvalidOperationException(excepcion_941lp);
            }
            // 1. Obtener la familia compuesta desde la estructura en memoria
            var familiasEstructuradas_941lp = orm_941lp.ObtenerCompositeFamilias_941lp();

            if (!familiasEstructuradas_941lp.TryGetValue(nombreFamilia_941lp, out var familiaBase_941lp))
                return; // o lanzar excepción si no existe

            var f_941lp = (Familia_941lp)familiaBase_941lp;

            // 2. Recorrer su estructura interna para eliminar relaciones
            foreach (var permiso_941lp in f_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp is PermisoSimple_941lp simple_941lp)
                {
                    ormFamiliaPermiso_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
                    OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple_941lp.nombrePermiso_941lp);
                }
                else if (permiso_941lp is Familia_941lp subFamilia_941lp)
                {
                    OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, subFamilia_941lp.nombrePermiso_941lp);
                }
            }

            // 3. Eliminar la familia de la base de datos
            orm_941lp.Eliminar_941lp(f_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().dni_941lp, "Gestion familia", "Familia eliminada", 1);
        }


        public bool VerificarNombreDeFamilia_941lp(string nombreFamilia_941lp)
        {
            return orm_941lp.VerificarNombreDeFamilia_941lp(nombreFamilia_941lp);
        }

        public List<Perfil_941lp> RetornarFamilias_941lp()
        {
            return orm_941lp.ObtenerCompositeFamilias_941lp().Values.ToList();
        }
    }
}
