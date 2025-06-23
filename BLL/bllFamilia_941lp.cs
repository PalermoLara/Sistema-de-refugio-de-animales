using BE;
using ORM;
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

        public bllFamilia_941lp()
        {
            OrmPerfil_941lp = new ormPerfil_941lp();
            orm_941lp = new ormFamilia_941lp();
            ormPermiso_941Lp = new ormPermiso_941lp();
            OrmIntemedia_941Lp = new ormIntemedia_941lp();
            ormFamiliaPermiso_941Lp = new ormFamiliaPermiso_941lp();
        }

        public void AltaFamilia_941lp(string nombreFamilia_941lp, List<string> permisosAñadir_941lp)
        {
            Familia_941lp f_941lp = new Familia_941lp(nombreFamilia_941lp);
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
                ormFamiliaPermiso_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
                OrmIntemedia_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso_941lp(familia);
                OrmIntemedia_941Lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }

            orm_941lp.AltaFamilia_941lp(f_941lp);
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

        private bool EstaContenidaEnOtraEstructura_941lp(string nombreFamiliaBuscada_941lp)
        {
            var familias_941lp = orm_941lp.ObtenerCompositeFamilias_941lp(); // Diccionario<string, Familia_941lp>
            var perfiles_941lp = OrmPerfil_941lp.ObtenerCompositePerfiles_941lp(); // Diccionario<string, Perfil_941lp>

            var estructuras_941lp = familias_941lp.Values.Cast<Perfil_941lp>()
                                  .Concat(perfiles_941lp.Values);

            foreach (var estructura_941lp in estructuras_941lp)
            {
                // Evitar que se analice a sí misma
                if (estructura_941lp is Familia_941lp familiaEstructura &&
                    familiaEstructura.nombrePermiso_941lp != nombreFamiliaBuscada_941lp)
                {
                    if (ContieneComoHijaRecursivo_941lp(familiaEstructura, nombreFamiliaBuscada_941lp))
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
                throw new InvalidOperationException($"La familia '{nombreFamilia_941lp}' no puede eliminarse porque está contenida dentro de otra familia o perfil.");
            }
            // 1. Obtener la familia compuesta desde la estructura en memoria
            var familiasEstructuradas = orm_941lp.ObtenerCompositeFamilias_941lp();

            if (!familiasEstructuradas.TryGetValue(nombreFamilia_941lp, out var familiaBase))
                return; // o lanzar excepción si no existe

            var f_941lp = (Familia_941lp)familiaBase;

            // 2. Recorrer su estructura interna para eliminar relaciones
            foreach (var permiso_941lp in f_941lp.ObtenerPermisos_941lp())
            {
                if (permiso_941lp is PermisoSimple_941lp simple)
                {
                    ormFamiliaPermiso_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
                    OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
                }
                else if (permiso_941lp is Familia_941lp subFamilia)
                {
                    OrmIntemedia_941Lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, subFamilia.nombrePermiso_941lp);
                }
            }

            // 3. Eliminar la familia de la base de datos
            orm_941lp.Eliminar_941lp(f_941lp);
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
