using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AltaPerfilIntermedias_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
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
                f_941lp.AgregarPermiso(simple);
                ormPerfilPermiso_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso(familia);
                ormPerfilFamilia_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }
        }

        // Método auxiliar
        private void ExpandirFamiliasInternas(Familia_941lp familia, HashSet<string> acumulador)
        {
            foreach (var permiso in familia.ObtenerPermisos())
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
            foreach (var hijo in familia.ObtenerPermisos())
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

        public void EliminarPerfilIntermedia_941lp(string nombrePerfil_941lp, List<string> permisosAñadir_941lp)
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

            var familiasEstructuradas = orm_941lp.ObtenerCompositePerfiles_941lp();

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
                f_941lp.AgregarPermiso(simple);
                ormPerfilPermiso_941lp.EliminarDeIntermediaPermanente_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                f_941lp.AgregarPermiso(familia);
                ormPerfilFamilia_941lp.EliminarDeIntermediaPermanente_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }
        }
    }
}
