using BE;
using ORM;
using SERVICIOS;
using SERVICIOS.Reportes_941lp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class bllFichaIngreso_941lp
    {
        ormFichaIngreso_941lp orm_941lp;
        ormCedente_941lp ormCedente_941lp;
        ReporteFichaIngreso_941lp reporte_941lp;
        bllBitacoraEventos_941lp bllBitacoraEvento_941lp;

        public bllFichaIngreso_941lp()
        {
            orm_941lp = new ormFichaIngreso_941lp();
            ormCedente_941lp = new ormCedente_941lp();
            reporte_941lp = new ReporteFichaIngreso_941lp();
            bllBitacoraEvento_941lp = new bllBitacoraEventos_941lp();
        }

        public void Alta_941lp(int codigoAnimal_941lp, string dni_941lp, string nombreCedente_941lp, string apellidoCedente, string telefono_941lp, string especie_941lp,DateTime fecha_941lp, DateTime hora_941lp, string razon_941lp, string zona_941lp)
        {
            DateTime soloFecha_941lp = fecha_941lp.Date;
            TimeSpan soloHora_941lp = hora_941lp.TimeOfDay;
            FichaDeIngreso_941lp ficha_941lp = new FichaDeIngreso_941lp(codigoAnimal_941lp, dni_941lp, especie_941lp, soloFecha_941lp, soloHora_941lp, razon_941lp, zona_941lp);
            int codigo_941lp = orm_941lp.ObtenerUltimoCodigoInsertado_941lp();
            // Obtener ruta de Descargas
            string carpetaDescargas_941lp = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads"
            );

            // Subcarpeta "Reportes"
            string carpetaReportes_941lp = Path.Combine(carpetaDescargas_941lp, "Reportes");

            // Crear carpeta si no existe
            if (!Directory.Exists(carpetaReportes_941lp))
            {
                Directory.CreateDirectory(carpetaReportes_941lp);
            }

            // Nombre del archivo PDF
            string nombreArchivo_941lp = $"FichaIngreso_{dni_941lp}_Cod{codigo_941lp}.pdf";
            string pathSalida = Path.Combine(carpetaReportes_941lp, nombreArchivo_941lp);

            // Ruta del logo dentro de la misma carpeta (asegurate de tenerlo allí)
            string rutaLogo = Path.Combine(carpetaReportes_941lp, "logo.png");

            // Llamada al método
            reporte_941lp.GenerarFichaIngresoPDF(
                pathSalida: pathSalida,
                nombre: nombreCedente_941lp,
                apellido: apellidoCedente,
                telefono: telefono_941lp,
                dni: dni_941lp,
                especie: especie_941lp,
                fecha: fecha_941lp,
                hora: soloHora_941lp,
                razon: razon_941lp,
                zona: zona_941lp,
                rutaLogo: rutaLogo
            );

            orm_941lp.Alta_941lp(ficha_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion ficha de ingreso", "Ficha de ingreso dada de alta", 3);
        }

        public void Modificar_941lp(int codigo_941lp, string razon_941lp, string zona_941lp)
        {
            FichaDeIngreso_941lp ficha_941lp = RetornarFichas_941lp().Find(x=>x.codigo_941lp == codigo_941lp);
            ficha_941lp.razon_941lp = razon_941lp;
            ficha_941lp.zona_941lp = zona_941lp;
            orm_941lp.Modificar_941lp(ficha_941lp);
            bllBitacoraEvento_941lp.Alta_941lp(sessionManager941lp.Gestor_941lp.RetornarUsuarioSession_941lp().nombreUsuario_941lp, "Gestion ficha de ingreso", "Ficha de ingreso modificada", 4);
        }

        public bool VerificarAnimalVivo_941lp(bool vivo_941lp)
        {
            return vivo_941lp;
        }

        public List<FichaDeIngreso_941lp> RetornarFichas_941lp()
        {
            return orm_941lp.RetornarFichaIngreso_941lp();
        }

        private Cedente_941lp BuscarCedentePorDNI_941lp(string dni_941lp)
        {
            return ormCedente_941lp.ObtenerCedentePorDni_941lp(dni_941lp);
        }

        public bool VerificarCedenteActivo_941lp(string dni_941lp)
        {
            return BuscarCedentePorDNI_941lp(dni_941lp).activo_941lp;
        }
    }
}
