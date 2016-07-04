using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using VYMSolucion.Model.Properties;
using System.ComponentModel.DataAnnotations;
namespace VYMSolucion.Model
{
    public class CentroAdministrativoModel
    {
        /// <summary>
        /// ErrorMessageResourceType -> invoca nombre archivo de recurso que se encuetrna en la misma capa 
        /// ErrorMessageResourceName -> invoca nombre de recurso
        /// </summary>

        public long IdCentroAdministrativo { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(ResourceType = typeof(ResourcesModel), Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "IdUbicacionGeografica")]
        public long IdUbicacionGeografica { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Direccion")]
        public string Direccion { get; set; }
        
        [Display(ResourceType = typeof(ResourcesModel), Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(ResourceType = typeof(ResourcesModel), Name = "UrlMapa")]
        public string UrlMapa { get; set; }
        public long? IdCentroAdministrativoPadre { get; set; }
        public bool EsActivo { get; set; }

        #region Solo para lectura de UI

        public string UbicacionGeograficaNombre { get; set; }
        public long? IdPais { get; set; }
        public long? IdProvincia { get; set; }

        public bool EsEliminar { get; set; }

        #endregion
    }
}
