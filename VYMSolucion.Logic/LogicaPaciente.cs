using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VYMSolucion.Comun;
using VYMSolucion.Data;
using VYMSolucion.Model;

namespace VYMSolucion.Logic
{
    public class LogicaPaciente
    {
        /// <summary>
        /// Crea registro de paciente Titular Factura
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool CrearRegistroPaciente(PacienteModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    DateTime fechaActual = DateTime.Now;
                    
                    var passwordCrypto = Utilitarios.Crypto.Encriptar(model.Contrasena, model.Contrasena, model.Correo,
                        model.Correo.Length);

                    var db = new VYMCoreEntities();
                    //agrega datos a estructura desde el modelo
                    var profesional = new EntidadPersona
                    {
                        CedulaRuc = model.CedulaRuc,
                        Nombres = model.Nombres,
                        Apellidos = model.Apellidos,
                        TelefonoMovil = model.TelefonoMovil,
                        Direccion = model.Direccion,
                        IdUbicacionGeograficaResid = model.IdUbicacionGeograficaResid,
                        Correo = model.Correo,
                        NombreUsuario = model.Correo,
                        Contrasena = passwordCrypto,
                        FechaCreacion = fechaActual,
                        FechaUltModificacion = fechaActual,
                        IdUsuarioModificacion = model.UsuarioAccion,
                        IdUsuarioCreacion = model.UsuarioAccion,
                        IdUbicacionGeograficaNacim = 1,
                        EsActivo = true
                    };

                    db.EntidadPersonas.Add(profesional);
                    db.SaveChanges();

                    //agrega datos a estructura desde el modelo
                    var perfilUsuario = new PerfilUsuario
                    {
                        IdEntidadPersona = profesional.IdEntidadPersona,
                        FechaCreacion = fechaActual,
                        FechaUltModificacion = fechaActual,
                        IdUsuarioCreacion = model.UsuarioAccion,
                        IdUsuarioModificacion = model.UsuarioAccion,
                        TipoUsuario = Parametros.IdPerfilTitularFactura,
                        EsActivo = true
                    };

                    db.PerfilUsuarios.Add(perfilUsuario);
                    db.SaveChanges();

                    //agrega registro para activar usuario
                    var activacion = new ActivacionUsuario
                    {
                        FechaCreacion = fechaActual,
                        ParametroActivar = Guid.NewGuid().ToString(),
                        Tipo = Parametros.TipoActivacionUsuario,
                        Usuario = model.Correo,
                        EsActivo = false,

                    };

                    db.ActivacionUsuarios.Add(activacion);
                    db.SaveChanges();

                    ts.Complete();
                    db.Database.Connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Leer registros de pacienes por titular de factua
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        public static IQueryable<PacienteTitularModel> LeerPacientesEntidadPersonaPadre(long idEntidadPersona)
        {
            var db = new VYMCoreEntities();

            var consulta = from ep in db.EntidadPersonas.Where(w => w.EsActivo)
                           join ce in db.Catalogoes.Where(w => w.EsActivo) on ep.Genero equals ce.IdCatalogo
                           join pu in db.PerfilUsuarios.Where(w => w.EsActivo) on ep.IdEntidadPersona equals pu.IdEntidadPersona
                           where ep.IdEntidadPersonaPadre == idEntidadPersona
                           select new PacienteTitularModel()
                           {
                               IdEntidadPersona = ep.IdEntidadPersona,
                               NombresApellidos = ep.Nombres+" " +ep.Apellidos,
                               NombreGenero = ce.Nombre,
                               EsActivo = ep.EsActivo,
                           };

            var respuesta = consulta;
            db.Database.Connection.Close();
            return respuesta;
        }

        #region Operacioens CRUD paciente

        /// <summary>
        /// Crea registro de paciente del titula de la factura
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool CrearPaciente(PacienteTitularModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    //obtiene la fecha actual
                    DateTime fechaActual = DateTime.Now;
                    //convierte los campos de selección de fecha en fecha
                    DateTime fechaNacimiento = new DateTime(model.FechaAnio, model.FechaMes, model.FechaDia);

                    var db = new VYMCoreEntities();
                    //agrega datos a estructura desde el modelo
                    var paciente = new EntidadPersona
                    {
                        CedulaRuc = model.CedulaRuc,
                        Nombres = model.Nombres,
                        Apellidos = model.Apellidos,
                        IdUbicacionGeograficaResid = model.IdUbicacionGeograficaResid,
                        FechaCreacion = fechaActual,
                        FechaUltModificacion = fechaActual,
                        IdUsuarioModificacion = model.UsuarioAccion,
                        IdUsuarioCreacion = model.UsuarioAccion,
                        IdUbicacionGeograficaNacim = model.IdUbicacionGeograficaNacim,
                        EsActivo = true,
                        Genero = model.Genero,
                        FechaNacimiento = fechaNacimiento,
                        TipoSangre = model.TipoSangre,
                        Direccion = " "
                    };

                    //busca datos de entidad persona padre
                    var entidadPersonaPadre =
                        db.EntidadPersonas.FirstOrDefault(
                            fod => fod.IdEntidadPersona == model.IdEntidadPersonaPadre);
                    //verifica si no existe información
                    if (entidadPersonaPadre == null)
                        return false;

                    //agrego datos de entidad persona padre
                    paciente.IdEntidadPersonaPadre = entidadPersonaPadre.IdEntidadPersona;
                    //agrega registro a entidad de EntidadPersona
                    db.EntidadPersonas.Add(paciente);
                    db.SaveChanges();

                    //agrega datos a estructura desde el modelo
                    var perfilUsuario = new PerfilUsuario
                    {
                        IdEntidadPersona = paciente.IdEntidadPersona,
                        FechaCreacion = fechaActual,
                        FechaUltModificacion = fechaActual,
                        IdUsuarioCreacion = model.UsuarioAccion,
                        IdUsuarioModificacion = model.UsuarioAccion,
                        TipoUsuario = Parametros.IdPerfilPaciente,
                        EsActivo = true
                    };
                    //agrega registro hacie entidad perfil usuario
                    db.PerfilUsuarios.Add(perfilUsuario);
                    //guardar registro de paciente
                    db.SaveChanges();
                    //fin de transacción
                    ts.Complete();
                    db.Database.Connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Leer registro de paciente
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        public static PacienteTitularModel LeerPaciente(long idEntidadPersona)
        {
            try
            {
                using (var db = new VYMCoreEntities())
                {

                    var consulta = db.EntidadPersonas.Select(s => new PacienteTitularModel()
                    {
                        CedulaRuc = s.CedulaRuc,
                        Nombres = s.Nombres,
                        Apellidos = s.Apellidos,
                        IdUbicacionGeograficaResid = s.IdUbicacionGeograficaResid,
                        IdUbicacionGeograficaNacim = s.IdUbicacionGeograficaNacim,
                        Genero = s.Genero,
                        TipoSangre = s.TipoSangre,
                        FechaAnio = s.FechaNacimiento.Value.Year,
                        FechaMes = s.FechaNacimiento.Value.Month,
                        FechaDia = s.FechaNacimiento.Value.Day,
                        IdEntidadPersona = s.IdEntidadPersona,
                        EsActivo = s.EsActivo,
                    }).FirstOrDefault(fod => fod.IdEntidadPersona == idEntidadPersona);

                    if(consulta == null)
                        return new  PacienteTitularModel();

                    //busca datos de ubicación geográfica nacimiento
                    var datosProvinciaNac =
                        db.UbicacionGeograficas.FirstOrDefault(
                            fod => fod.IdUbicacionGeografica == consulta.IdUbicacionGeograficaNacim);
                    //asigna identificador para provincia nacimiento
                    consulta.ProvinciaNacim = (datosProvinciaNac == null ? 0 : datosProvinciaNac.IdUbicacionGeograficaPadre??0);
                    //busca datos de ubicación geográfica nacimiento
                    var datosPaisNac =
                        db.UbicacionGeograficas.FirstOrDefault(
                            fod => fod.IdUbicacionGeografica == consulta.ProvinciaNacim);
                    //asigna identificador para país nacimiento
                    consulta.PaisNacim = datosPaisNac == null ? 0 : datosPaisNac.IdUbicacionGeograficaPadre??0;

                    //busca datos de ubicación geográfica residencia
                    var datosProvinciaRe =
                        db.UbicacionGeograficas.FirstOrDefault(
                            fod => fod.IdUbicacionGeografica == consulta.IdUbicacionGeograficaResid);
                    //asigna identificador para provincia residencia
                    consulta.ProvinciaResid = (datosProvinciaRe == null ? 0 : datosProvinciaRe.IdUbicacionGeograficaPadre ?? 0);
                    //busca datos de ubicación geográfica residencia
                    var datosPaisRe =
                        db.UbicacionGeograficas.FirstOrDefault(
                            fod => fod.IdUbicacionGeografica == consulta.ProvinciaResid);
                    //asigna identificador para país residencia
                    consulta.PaisResid = datosPaisRe == null ? 0 : datosPaisRe.IdUbicacionGeograficaPadre ?? 0;

                    var respuesta = consulta;
                    db.Database.Connection.Close();

                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Editar registro de paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool EditarPaciente(PacienteTitularModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var db = new VYMCoreEntities();

                    //obtiene la fecha actual
                    DateTime fechaActual = DateTime.Now;
                    //convierte los campos de selección de fecha en fecha
                    DateTime fechaNacimiento = new DateTime(model.FechaAnio, model.FechaMes, model.FechaDia);
                    //busca datos del paciente
                    var paciente = db.EntidadPersonas.Find(model.IdEntidadPersona);
                    //agrega nuevos datos al registro de paciente
                    paciente.CedulaRuc = model.CedulaRuc;
                    paciente.Nombres = model.Nombres;
                    paciente.Apellidos = model.Apellidos;
                    paciente.IdUbicacionGeograficaResid = model.IdUbicacionGeograficaResid;
                    paciente.FechaUltModificacion = fechaActual;
                    paciente.IdUsuarioModificacion = model.UsuarioAccion;
                    paciente.IdUbicacionGeograficaNacim = model.IdUbicacionGeograficaNacim;
                    paciente.Genero = model.Genero;
                    paciente.FechaNacimiento = fechaNacimiento;
                    paciente.TipoSangre = model.TipoSangre;

                    //guarda los cambios
                    db.SaveChanges();
                    //fin de transacción
                    ts.Complete();
                    db.Database.Connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Activar o desactivar registro de paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool ActivarDesactivarPaciente(PacienteTitularModel model)
        {
            try
            {
                //inicio de transacción de consulta
                using (var ts = new TransactionScope())
                {
                    var db = new VYMCoreEntities();

                    //obtiene la fecha actual
                    DateTime fechaActual = DateTime.Now;

                    //busca datos del paciente
                    var paciente = db.EntidadPersonas.Find(model.IdEntidadPersona);
                    //agrega nuevos datos al registro de paciente
                    paciente.FechaUltModificacion = fechaActual;
                    paciente.IdUsuarioModificacion = model.UsuarioAccion;
                    paciente.EsActivo = model.EsActivo;

                    //guarda los cambios
                    db.SaveChanges();
                    //fin de transacción
                    ts.Complete();
                    db.Database.Connection.Close();
                    return true;
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
