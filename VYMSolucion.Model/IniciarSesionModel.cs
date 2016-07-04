using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYMSolucion.Model.Properties;

namespace VYMSolucion.Model
{
    public class IniciarSesionModel
    {
        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Usuario")]
        public string Usuario { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Contrasena")]
        public string Contrasena { get; set; }
    }
}
