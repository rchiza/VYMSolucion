using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYMSolucion.Model.Properties;

namespace VYMSolucion.Model
{
    public class PacienteTitularModel
    {
        public long IdEntidadPersona { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "CedulaRuc")]
        [RegularExpression(@"^[0-9]*$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorNumero")]
        [StringLength(13, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorLongitud")]
        public string CedulaRuc { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Nombres")]
        [StringLength(75, MinimumLength = 2, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorLongitud")]
        [RegularExpression("^([a-zA-ZñÑáéíóúÁÉÍÓÚÄËÏÖÜäëïöüÂÊÎÔÛâêîôû' ])+$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorCadena")]
        public string Nombres { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Apellidos")]
        [StringLength(75, MinimumLength = 2, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorLongitud")]
        [RegularExpression("^([a-zA-ZñÑáéíóúÁÉÍÓÚÄËÏÖÜäëïöüÂÊÎÔÛâêîôû' ])+$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorCadena")]
        public string Apellidos { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "IdUbicacionGeograficaResid")]
        public long IdUbicacionGeograficaResid { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Provincia")]
        public long ProvinciaResid { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Pais")]
        public long PaisResid { get; set; }

        [Display(ResourceType = typeof(ResourcesModel), Name = "EsActivo")]
        public bool EsActivo { get; set; }

        #region Datos para registro de paciente de titular de la factura

        [Display(ResourceType = typeof(ResourcesModel), Name = "TipoSangre")]
        public long? TipoSangre { get; set; }

        [Display(ResourceType = typeof(ResourcesModel), Name = "Parentesco")]
        public long? Parentesco { get; set; }

        [StringLength(185, MinimumLength = 5, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorLongitud")]
        [RegularExpression("^([a-zA-ZñÑáéíóúÁÉÍÓÚÄËÏÖÜäëïöüÂÊÎÔÛâêîôû' .-])+$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorCadena")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Observaciones")]
        public string Observaciones { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Dia")]
        public int FechaDia { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Mes")]
        public int FechaMes { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Anio")]
        public int FechaAnio { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "IdUbicacionGeograficaNacim")]
        public long IdUbicacionGeograficaNacim { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Provincia")]
        public long ProvinciaNacim { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Pais")]
        public long PaisNacim { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Genero")]
        public long Genero { get; set; }

        #endregion


        #region Campos de acción

        public long UsuarioAccion { get; set; }

        public long IdEntidadPersonaPadre { get; set; }

        public bool ActivarDesactivar { get; set; }

        public bool Nuevo { get; set; }
        public bool Ver { get; set; }
        public bool Editar { get; set; }


        #endregion

        #region Campos para presentación de información

        [Display(ResourceType = typeof(ResourcesModel), Name = "NombresApellidos")]
        public string NombresApellidos { get; set; }

        [Display(ResourceType = typeof(ResourcesModel), Name = "Genero")]
        public string NombreGenero { get; set; }

        public int Edad { get; set; }

        #endregion
    }
}
