using BE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace BLL
{
    public class bllSerializacion_941lp
    {
        public void SerializarCedentes_941lp(List<Cedente_941lp> cedentes_941lp, string ruta_941lp)
        {
            using (FileStream fs_941lp = new FileStream(ruta_941lp, FileMode.Create))
            {
                XmlSerializer serializer_941lp = new XmlSerializer(typeof(List<Cedente_941lp>));
                serializer_941lp.Serialize(fs_941lp, cedentes_941lp);
            }
        }

        public List<Cedente_941lp> DeserializarCedentes_941lp(string ruta_941lp)
        {
            using (FileStream fs_941lp = new FileStream(ruta_941lp, FileMode.Open))
            {
                XmlSerializer serializer_941lp = new XmlSerializer(typeof(List<Cedente_941lp>));
                return (List<Cedente_941lp>)serializer_941lp.Deserialize(fs_941lp);
            }
        }

        public string ObtenerXmlCrudo_941lp(string ruta_941lp)
        {
            using (StreamReader sr_941lp = new StreamReader(ruta_941lp))
            {
                return sr_941lp.ReadToEnd();
            }
        }

        public List<Cedente_941lp> MostrarCedentesDeserealizados_941lp(string ruta_941lp)
        {
            List<Cedente_941lp> cedentes_941lp = DeserializarCedentes_941lp(ruta_941lp);
            return cedentes_941lp;
        }
    }
}
