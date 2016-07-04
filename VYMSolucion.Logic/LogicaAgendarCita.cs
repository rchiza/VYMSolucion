using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VYMSolucion.Data;
using VYMSolucion.Model;

namespace VYMSolucion.Logic
{
    public class LogicaAgendarCita
    {
        /// <summary>
        /// Leer todas las citas agendadas por el profesional
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        public static IQueryable<AgendaEntidadPersonaModel> LeerCitasMedicasProfesional(long idEntidadPersona)
        {
            try
            {
                var db = new VYMCoreEntities();

                var consulata =
                    from a in
                        db.AgendaEntidadPersonas.Where(w => w.EsActiva && w.IdEntidadPersonaProf == idEntidadPersona)

                    select new AgendaEntidadPersonaModel()
                    {
                        IdAgendaEntidadPersona = a.IdAgendaEntidadPersona,
                        FechaTurnoDesde = a.FechaTurnoDesde,
                        FechaTurnoHasta = a.FechaTurnoHasta
                    };

                var respuesta = consulata;

                return consulata;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #region Operacioens CRUD

        /// <summary>
        /// Leer registro de Cita médica agendada
        /// </summary>
        /// <param name="idAgendaEntidadPersona"></param>
        /// <returns></returns>
        public static AgendaEntidadPersonaModel LeerCitaMedicaProfesional(long idAgendaEntidadPersona)
        {
            try
            {
                using (var db = new VYMCoreEntities())
                {
                    var consulta =
                        db.AgendaEntidadPersonas.FirstOrDefault(
                            fod => fod.IdAgendaEntidadPersona == idAgendaEntidadPersona);

                    if(consulta == null)
                        return new AgendaEntidadPersonaModel();

                    var modelo = new AgendaEntidadPersonaModel
                    {
                        IdAgendaEntidadPersona = consulta.IdAgendaEntidadPersona
                    };

                    return modelo;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public static AgendaEntidadPersonaModel CrearCitaMedicaProfesional(AgendaEntidadPersonaModel model)
        {
            try
            {
                DateTime fechaActual = DateTime.Now;

                using (var ts = new TransactionScope())
                {
                    var db = new VYMCoreEntities();

                    var agenda = new AgendaEntidadPersona()
                    {
                        IdCentroAdministrativo = model.IdCentroAdministrativo,
                        AlertaRecordatorioProf = model.AlertaRecordatorioProf,
                        AlertaRecordatotioCliente = false,
                        EsConfirmadaCita = false,
                        EstadoCita = 0,
                        EstadoTurno = 0,
                        FechaTurnoDesde = model.FechaTurnoDesde,
                        FechaTurnoHasta = model.FechaTurnoHasta,
                        IdEntidadPersonaCliente = 0,
                        IdEntidadPersonaProf = model.IdEntidadPersonaProf,
                        Observacion = model.Observacion,
                        TipoEvento = 0,
                        FechaCreacion = fechaActual,
                        FechaUltModificacion = fechaActual,
                        IdUsuarioCreacion = model.UsuarioAccion,
                        IdUsuarioModificacion = model.UsuarioAccion,
                        EsActiva = true,
                        
                    };

                    db.AgendaEntidadPersonas.Add(agenda);
                    db.SaveChanges();

                    model.IdAgendaEntidadPersona = agenda.IdAgendaEntidadPersona;

                    ts.Complete();
                    return model;

                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion

    }
}
