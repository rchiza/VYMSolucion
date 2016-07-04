using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYMSolucion.Model.Properties;

namespace VYMSolucion.Model
{
    public class ProfesionalModel
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
        [Display(ResourceType = typeof(ResourcesModel), Name = "IdUbicacionGeograficaNacim")]
        public long IdUbicacionGeograficaNacim { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Provincia")]
        public long ProvinciaNacim { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Pais")]
        public long PaisNacim { get; set; }

        
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
        [Display(ResourceType = typeof(ResourcesModel), Name = "Genero")]
        public long Genero { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "EstadoCivil")]
        public long EstadoCivil { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "TelefonoMovil")]
        [RegularExpression(@"^[0-9]*$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorNumero")]
        [StringLength(15, MinimumLength = 10, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorLongitud")]
        public string TelefonoMovil { get; set; }
        public string TelefonoConvencional { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Direccion")]
        [StringLength(175, MinimumLength = 5, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorLongitud")]
        [RegularExpression("^([a-zA-ZñÑáéíóúÁÉÍÓÚÄËÏÖÜäëïöüÂÊÎÔÛâêîôû' .-])+$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorCadena")]
        public string Direccion { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "IdUbicacionGeograficaResid")]
        public long IdUbicacionGeograficaResid { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Provincia")]
        public long ProvinciaResid { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Pais")]
        public long PaisResid { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Correo")]
        [EmailAddress(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorCorreo")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorCorreo")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorCorreo")]
        [StringLength(150, MinimumLength = 5, ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorLongitud")]
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "Contrasena")]
        [RegularExpression(@"^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "PasswordError")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "Required")]
        [Display(ResourceType = typeof(ResourcesModel), Name = "ContrasenaRepetir")]
        [RegularExpression(@"^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,15})$", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "PasswordError")]
        [DataType(DataType.Password)]
        [Compare("Contrasena", ErrorMessageResourceType = typeof(ResourcesMensajes), ErrorMessageResourceName = "ErrorContrasenaNoIgual")]
        public string ContrasenaRepetir { get; set; }
        public bool EsActivo { get; set; }

        #region Campos de acción

        public long UsuarioAccion { get; set; }

        #endregion
    }
}
