using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    internal class EstadoAdmin : IEstado
    {
        FormAdministradorUsuario formAdmin;

        public void CerrarEstado()
        {
            formAdmin?.Dispose();
        }

        public void EjecutarEstado()
        {
            formAdmin = new FormAdministradorUsuario();
            formAdmin.ShowDialog();
        }
    }
}
