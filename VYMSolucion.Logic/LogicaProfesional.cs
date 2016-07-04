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
    public class LogicaProfesional
    {

        /// <summary>
        /// Crea registro de profesional
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool CrearRegistroProfesional(ProfesionalModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    DateTime fechaActual = DateTime.Now;

                    DateTime fechaNacimiento = new DateTime(model.FechaAnio, model.FechaMes, model.FechaDia);

                    var passwordCrypto = Utilitarios.Crypto.Encriptar(model.Contrasena, model.Contrasena, model.Correo,
                        model.Correo.Length);

                    var db = new VYMCoreEntities();

                    //agrega datos a estructura desde el modelo
                    var profesional = new EntidadPersona
                    {
                        CedulaRuc = model.CedulaRuc,
                        Nombres = model.Nombres,
                        Apellidos = model.Apellidos,
                        IdUbicacionGeograficaNacim = model.IdUbicacionGeograficaNacim,
                        Genero = model.Genero,
                        EstadoCivil = model.EstadoCivil,
                        TelefonoMovil = model.TelefonoMovil,
                        Direccion = model.Direccion,
                        IdUbicacionGeograficaResid = model.IdUbicacionGeograficaResid,
                        Correo = model.Correo,
                        NombreUsuario = model.Correo,
                        Contrasena = passwordCrypto,
                        FechaCreacion = fechaActual,
                        FechaNacimiento = fechaNacimiento,
                        FechaUltModificacion = fechaActual,
                        IdUsuarioModificacion = model.UsuarioAccion,
                        IdUsuarioCreacion = model.UsuarioAccion,
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
                        TipoUsuario = Parametros.IdPerfilProfesional,
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

    }
}
