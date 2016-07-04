using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYMSolucion.Model
{
    public class DatosUsuarioModel
    {
        public long IdUsuario { get; set; }
        public string Nombres { get; set; }
        public long IdPerfil { get; set; }
        public string NombrePerfil { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }

    }
}
