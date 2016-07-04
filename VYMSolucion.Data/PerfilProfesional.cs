//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VYMSolucion.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PerfilProfesional
    {
        public long IdPerfilProfesional { get; set; }
        public long IdEntidadPersona { get; set; }
        public long NivelEstudio { get; set; }
        public string EntidadEducativa { get; set; }
        public long IdUbicacionGeograficaEntidad { get; set; }
        public Nullable<int> AnioGraduacion { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaUltModificacion { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public Nullable<long> IdUsuarioModificacion { get; set; }
        public bool EsActiva { get; set; }
    
        public virtual UbicacionGeografica UbicacionGeografica { get; set; }
        public virtual EntidadPersona EntidadPersona { get; set; }
    }
}
