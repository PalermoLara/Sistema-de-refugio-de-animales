using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class bllDigitoVerificador_941lp
    {
        ormDigitoVerificador_941lp orm_941lp;
        ormCedente_941lp ormCedente_941Lp;
        encriptador_941lp seguridad_941lp;
        ormMedicamento_941lp ormMedicamento_941Lp;
        ormRegistroAnimales_941lp ormRegistroAnimales_941Lp;
        ormAdoptantes_941lp ormAdoptantes_941lp;
        ormCertificado_941lp ormCertificado_941Lp;
        ormEvaluacion_941lp ormEvaluacion_941Lp;
        ormFichaIngreso_941lp ormFichaIngreso_941Lp;
        ormFichaMedica_941lp ormFichaMedica_941Lp;

        public bllDigitoVerificador_941lp()
        {
            orm_941lp = new ormDigitoVerificador_941lp();
            ormCedente_941Lp = new ormCedente_941lp();
            seguridad_941lp = new encriptador_941lp();
            ormMedicamento_941Lp = new ormMedicamento_941lp();
            ormRegistroAnimales_941Lp = new ormRegistroAnimales_941lp();
            ormAdoptantes_941lp = new ormAdoptantes_941lp();
            ormCertificado_941Lp = new ormCertificado_941lp();
            ormEvaluacion_941Lp = new ormEvaluacion_941lp();
            ormFichaIngreso_941Lp = new ormFichaIngreso_941lp();
            ormFichaMedica_941Lp = new ormFichaMedica_941lp();
        }

        public bool Deteccion_941lp()
        {
            List<DigitoVerificador_941lp> dvCalculados_941lp = Calcular_941lp();

            return orm_941lp.CompararDigitos_941lp(dvCalculados_941lp).Count > 0;
        }

        private List<DigitoVerificador_941lp> Calcular_941lp()
        {
            return new List<DigitoVerificador_941lp>
            {
                DVCedente_941lp(),
                DVAdoptante_941lp(),
                DVAnimales_941lp(),
                DVCertificadoAdopcion_941lp(),
                DVEvaluaciones_941lp(),
                DVFichaIngreso_941lp(),
                DVFichaMedica_941lp(),
                DVMedicamentos_941lp()
            };
        }

        public List<string> MostrarInconsistencias_941lp()
        {
            List<DigitoVerificador_941lp> dvCalculados_941lp = Calcular_941lp();

            List<string> tablasConInconsistencias_941lp = orm_941lp.CompararDigitos_941lp(dvCalculados_941lp);

            return tablasConInconsistencias_941lp;
        }


        public DigitoVerificador_941lp DVCedente_941lp()
        {
            var cedentes_941lp = ormCedente_941Lp.RetornarCedentes_941lp();

            string horizontal = string.Concat(cedentes_941lp.Select(x =>
                x.dni_941lp + x.nombre_941lp + x.apellido_941lp +
                x.telefono_941lp + x.direccion_941lp + x.activo_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(cedentes_941lp.Select(x => x.dni_941lp)) +
                             string.Concat(cedentes_941lp.Select(x => x.nombre_941lp)) +
                             string.Concat(cedentes_941lp.Select(x => x.apellido_941lp)) +
                             string.Concat(cedentes_941lp.Select(x => x.telefono_941lp)) +
                             string.Concat(cedentes_941lp.Select(x => x.direccion_941lp)) +
                             string.Concat(cedentes_941lp.Select(x => x.activo_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical);
            return new DigitoVerificador_941lp("Cedente_941lp", horizontalHash, verticalHash);
        }

        public void CalcularDVCedente_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVCedente_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }

        public DigitoVerificador_941lp DVMedicamentos_941lp()
        {
            var medicamento_941lp = ormMedicamento_941Lp.RetornarMedicamento_941lp();

            string horizontal = string.Concat(medicamento_941lp.Select(x =>
                x.numeroOficial_941lp + x.nombreComercial_941lp + x.nombreGenerico_941lp +
                x.forma_941lp + x.caducidad_941lp + x.activo_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(medicamento_941lp.Select(x => x.numeroOficial_941lp)) +
                             string.Concat(medicamento_941lp.Select(x => x.nombreComercial_941lp)) +
                             string.Concat(medicamento_941lp.Select(x => x.nombreGenerico_941lp)) +
                             string.Concat(medicamento_941lp.Select(x => x.forma_941lp)) +
                             string.Concat(medicamento_941lp.Select(x => x.caducidad_941lp)) +
                             string.Concat(medicamento_941lp.Select(x => x.activo_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical);
            return new DigitoVerificador_941lp("Medicamento_941lp", horizontalHash, verticalHash);
        }

        public void CalcularDVMedicamentos_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVMedicamentos_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }

        public DigitoVerificador_941lp DVAnimales_941lp()
        {
            var animal_941lp = ormRegistroAnimales_941Lp.RetornarAnimal_941lp();

            string horizontal = string.Concat(animal_941lp.Select(x =>
                x.codigoAnimal_941lp + x.especie_941lp + x.raza_941lp +
                x.nombre_941lp + x.tamaño_941lp + x.sexo_941lp + x.estadoAdopcion_941lp + x.vivo_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(animal_941lp.Select(x => x.codigoAnimal_941lp)) +
                             string.Concat(animal_941lp.Select(x => x.especie_941lp)) +
                             string.Concat(animal_941lp.Select(x => x.raza_941lp)) +
                             string.Concat(animal_941lp.Select(x => x.nombre_941lp)) +
                             string.Concat(animal_941lp.Select(x => x.tamaño_941lp)) +
                             string.Concat(animal_941lp.Select(x => x.sexo_941lp)) +
                             string.Concat(animal_941lp.Select(x => x.estadoAdopcion_941lp)) +
                             string.Concat(animal_941lp.Select(x => x.vivo_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical);
            return new DigitoVerificador_941lp("Animal_941lp", horizontalHash, verticalHash);
        }

        public void CalcularDVAnimales_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVAnimales_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }

        public void CalcularDVCertificadoAdopcion_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVCertificadoAdopcion_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }

        public DigitoVerificador_941lp DVCertificadoAdopcion_941lp()
        {
            var certificado_941lp = ormCertificado_941Lp.RetornarCertificados_941lp();

            string horizontal = string.Concat(certificado_941lp.Select(x =>
                x.codigo_941lp + x.dni_941lp + x.codigoAnimal_941lp +
                x.especie_941lp + x.raza_941lp + x.nombreAnimal_941lp + x.nombreAdoptante_941lp + x.apellidoAdoptante_941lp + x.fecha_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(certificado_941lp.Select(x => x.codigo_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.dni_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.codigoAnimal_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.especie_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.raza_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.nombreAnimal_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.nombreAdoptante_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.apellidoAdoptante_941lp)) +
                             string.Concat(certificado_941lp.Select(x => x.fecha_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical);
            return new DigitoVerificador_941lp("CertificadoAdopcion_941lp", horizontalHash, verticalHash);
        }

        public DigitoVerificador_941lp DVAdoptante_941lp()
        {
            var adoptante_941lp = ormAdoptantes_941lp.RetornarAdoptantes_941lp();

            string horizontal = string.Concat(adoptante_941lp.Select(x =>
                x.dni_941lp + x.nombre_941lp + x.apellido_941lp +
                x.telefono_941lp + x.edad_941lp + x.domicilio_941lp + x.mascotas_941lp + x.activo_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(adoptante_941lp.Select(x => x.dni_941lp)) +
                             string.Concat(adoptante_941lp.Select(x => x.nombre_941lp)) +
                             string.Concat(adoptante_941lp.Select(x => x.apellido_941lp)) +
                             string.Concat(adoptante_941lp.Select(x => x.telefono_941lp)) +
                             string.Concat(adoptante_941lp.Select(x => x.edad_941lp)) +
                             string.Concat(adoptante_941lp.Select(x => x.domicilio_941lp)) +
                             string.Concat(adoptante_941lp.Select(x => x.mascotas_941lp)) +
                             string.Concat(adoptante_941lp.Select(x => x.activo_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical);
            return new DigitoVerificador_941lp("Adoptante_941lp", horizontalHash, verticalHash);
        }

        public void CalcularDVAdoptante_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVAdoptante_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }

        public DigitoVerificador_941lp DVEvaluaciones_941lp()
        {
            var evaluacion_941lp = ormEvaluacion_941Lp.RetornarEvaluaciones_941lp();

            string horizontal = string.Concat(evaluacion_941lp.Select(x =>
                x.codigoEv_941lp + x.dni_941lp + x.motivo_941lp +
                x.condicionesEconomicas_941lp + x.vivienda_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(evaluacion_941lp.Select(x => x.codigoEv_941lp)) +
                             string.Concat(evaluacion_941lp.Select(x => x.dni_941lp)) +
                             string.Concat(evaluacion_941lp.Select(x => x.motivo_941lp)) +
                             string.Concat(evaluacion_941lp.Select(x => x.condicionesEconomicas_941lp)) +
                             string.Concat(evaluacion_941lp.Select(x => x.vivienda_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical); 
            return new DigitoVerificador_941lp("EvaluacionAdoptante_941lp", horizontalHash, verticalHash);
        }

        public void CalcularDVEvaluaciones_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVEvaluaciones_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }

        public DigitoVerificador_941lp DVFichaIngreso_941lp()
        {
            var fichaIngreso_941lp = ormFichaIngreso_941Lp.RetornarFichaIngreso_941lp();

            string horizontal = string.Concat(fichaIngreso_941lp.Select(x =>
                x.codigo_941lp + x.codigoAnimal_941lp + x.especie_941lp +
                x.fecha_941lp + x.hora_941lp + x.razon_941lp + x.zona_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(fichaIngreso_941lp.Select(x => x.codigo_941lp)) +
                             string.Concat(fichaIngreso_941lp.Select(x => x.codigoAnimal_941lp)) +
                             string.Concat(fichaIngreso_941lp.Select(x => x.especie_941lp)) +
                             string.Concat(fichaIngreso_941lp.Select(x => x.fecha_941lp)) +
                             string.Concat(fichaIngreso_941lp.Select(x => x.hora_941lp)) +
                             string.Concat(fichaIngreso_941lp.Select(x => x.razon_941lp)) +
                             string.Concat(fichaIngreso_941lp.Select(x => x.zona_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical);
            return new DigitoVerificador_941lp("FichaDeIngreso_941lp", horizontalHash, verticalHash);
        }

        public void CalcularDVFichaIngreso_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVFichaIngreso_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }

        public DigitoVerificador_941lp DVFichaMedica_941lp()
        {
            var fichaMedica_941lp = ormFichaMedica_941Lp.RetornarFichaMedica_941lp();

            string horizontal = string.Concat(fichaMedica_941lp.Select(x =>
                x.codigo_941lp + x.codigoAnimal_941lp + x.fecha_941lp.ToString() +
                x.castrado_941lp + x.dieta_941lp + x.medicamento_941lp + x.observaciones_941lp));
            string horizontalHash = seguridad_941lp.GetSHA256_941lp(horizontal);

            string vertical = string.Concat(fichaMedica_941lp.Select(x => x.codigo_941lp)) +
                             string.Concat(fichaMedica_941lp.Select(x => x.codigoAnimal_941lp)) +
                             string.Concat(fichaMedica_941lp.Select(x => x.fecha_941lp)) +
                             string.Concat(fichaMedica_941lp.Select(x => x.castrado_941lp)) +
                             string.Concat(fichaMedica_941lp.Select(x => x.dieta_941lp)) +
                             string.Concat(fichaMedica_941lp.Select(x => x.medicamento_941lp)) +
                             string.Concat(fichaMedica_941lp.Select(x => x.observaciones_941lp));
            string verticalHash = seguridad_941lp.GetSHA256_941lp(vertical); 
            return new DigitoVerificador_941lp("FichaMedica_941lp", horizontalHash, verticalHash);
        }

        public void CalcularDVFichaMedica_941lp()
        {
            DigitoVerificador_941lp d_941lp = DVFichaMedica_941lp();
            orm_941lp.Update_941lp(d_941lp);
        }
    }
}
