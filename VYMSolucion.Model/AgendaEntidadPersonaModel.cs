using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYMSolucion.Model
{
    public class AgendaEntidadPersonaModel
    {
        public long IdAgendaEntidadPersona { get; set; }
        public long IdEntidadPersonaProf { get; set; }
        public long IdEntidadPersonaCliente { get; set; }
        public long IdCentroAdministrativo { get; set; }
        public DateTime FechaTurnoDesde { get; set; }
        public DateTime FechaTurnoHasta { get; set; }
        public long EstadoTurno { get; set; }
        public bool EsConfirmadaCita { get; set; }
        public int? TiempoViajeMinsProf { get; set; }
        public int? TiempoViajeMinsCliente { get; set; }
        public long? EstadoCita { get; set; }
        public string Observacion { get; set; }
        public int? TiempoEstimadaCitaMins { get; set; }
        public long TipoEvento { get; set; }
        public bool? AlertaRecordatorioProf { get; set; }
        public int? TiempoAlertaProf { get; set; }
        public bool? AlertaRecordatotioCliente { get; set; }
        public int? TiempoAlertaCliente { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public System.DateTime FechaUltModificacion { get; set; }
        public long IdUsuarioCreacion { get; set; }
        public long? IdUsuarioModificacion { get; set; }
        public bool EsActiva { get; set; }

        #region Datos para acciones y vista

        public long UsuarioAccion { get; set; }

        #endregion
    }
}
