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

        private void QuitarPermisoDeOtrasFamilias(Perfil_941lp permiso,List<Familia_941lp> familiasIncluidas)
        {
            foreach (var familia in familiasIncluidas)
            {
                QuitarPermisoRecursivo_941lp(familia, permiso);
            }
        }

        private void QuitarPermisoRecursivo_941lp(Familia_941lp familia, Perfil_941lp permisoABuscar)
        {
            var hijos = familia.ObtenerPermisos_941lp().ToList(); // Evitamos modificar mientras iteramos

            foreach (var hijo in hijos)
            {
                // Comparar por nombre (ya que todos los permisos tienen nombre único)
                if (hijo.nombrePermiso_941lp == permisoABuscar.nombrePermiso_941lp)
                {
                    familia.EliminarPermiso_941lp(hijo);

                    // Remover de la BD según tipo
                    if (hijo is PermisoSimple_941lp)
                    {
                        ormPerfilPermiso_941lp.EliminarDeIntermedia_941lp(familia.nombrePermiso_941lp, hijo.nombrePermiso_941lp);
                    }
                    else if (hijo is Familia_941lp)
                    {
                        ormPerfilFamilia_941lp.EliminarDeIntermedia_941lp(familia.nombrePermiso_941lp, hijo.nombrePermiso_941lp);
                    }

                    return; // Ya lo eliminamos, no seguimos recorriendo
                }

                // Si es otra familia, seguir buscando recursivamente
                if (hijo is Familia_941lp subFamilia)
                {
                    QuitarPermisoRecursivo_941lp(subFamilia, permisoABuscar);
                }
            }
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


            // Agregar simples
            foreach (var simple in listaSimples_941lp)
            {
                QuitarPermisoDeOtrasFamilias(simple, listaFamilia_941lp);
                f_941lp.AgregarPermiso_941lp(simple);
                ormPerfilPermiso_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                QuitarPermisoDeOtrasFamilias(familia, listaFamilia_941lp);
                f_941lp.AgregarPermiso_941lp(familia);
                ormPerfilFamilia_941lp.AltaIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }
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
            var permisosYaAsignados = new HashSet<string>();
            var familiasYaIncluidas = new HashSet<string>();

            var permisosSimples = ormPermiso_941Lp.RetornarPermisos_941lp()
                .ToDictionary(p => p.nombrePermiso_941lp);

            var familiasSinEstructura = orm_941lp.ObtenerCompositeFamilias_941lp();

            var familiasEstructuradas = orm_941lp.ObtenerCompositePerfiles_941lp();

            foreach (string nombre in permisosAñadir_941lp)
            {
                if (permisosSimples.TryGetValue(nombre, out var simple))
                {
                    listaSimples_941lp.Add(simple);
                }
                else if (familiasSinEstructura.ContainsKey(nombre))
                {
                    if (familiasSinEstructura.TryGetValue(nombre, out var familiaCompuesta))
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

            // Agregar simples
            foreach (var simple in listaSimples_941lp)
            {
                f_941lp.EliminarPermiso_941lp(simple);
                ormPerfilPermiso_941lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, simple.nombrePermiso_941lp);
            }

            // Agregar familias
            foreach (var familia in listaFamilia_941lp)
            {
                f_941lp.EliminarPermiso_941lp(familia);
                ormPerfilFamilia_941lp.EliminarDeIntermedia_941lp(f_941lp.nombrePermiso_941lp, familia.nombrePermiso_941lp);
            }
        }
    }
}
