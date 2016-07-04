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
    public class LogicaGeneral
    {

        #region Acciones de activación de usuario
        
        /// <summary>
        /// Activa cuenta de usuario
        /// </summary>
        /// <param name="parametroActivacion"></param>
        public static DatosUsuarioModel ActivarCuenta(string parametroActivacion)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var model = new DatosUsuarioModel();

                    var db = new VYMCoreEntities();
                    //busca el registro para activar el usaurio
                    var datosActivacion =
                        db.ActivacionUsuarios.FirstOrDefault(fod => fod.ParametroActivar == parametroActivacion.Trim());

                    //busca el registro del usuario por el correo(Usuario)
                    var datosUsuario =
                        db.EntidadPersonas.FirstOrDefault(fod => fod.NombreUsuario == datosActivacion.Usuario);

                    //validación si existe registro de activación de usuario
                    if (datosActivacion != null && datosUsuario != null)
                    {
                        datosActivacion.FechaActivacion = DateTime.Now;
                        datosActivacion.EsActivo = true;
                        //actualiza la información
                        db.SaveChanges();
                        //agreda datos al modelo para vista
                        model = new DatosUsuarioModel
                        {
                            //nueva structura de string format
                            Nombres = $"{datosUsuario.Nombres} {datosUsuario.Apellidos}"
                        };
                    }
                    
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

        #region Validaciones

        /// <summary>
        /// Valida si el correo ya se encuetra registrado
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public static bool ValidarCorreoRepetido(string correo)
        {
            try
            {
                using (var db = new VYMCoreEntities())
                {
                    var consulta = db.EntidadPersonas.Any(a => a.EsActivo && a.Correo.Trim() == correo.Trim());

                    return consulta;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Valida si la cedula/RUC ya se encuetra registrado
        /// </summary>
        /// <param name="cedulaRuc"></param>
        /// <returns></returns>
        public static bool ValidarCedulaRuc(string cedulaRuc)
        {
            try
            {
                using (var db = new VYMCoreEntities())
                {
                    var consulta = db.EntidadPersonas.Any(a => a.EsActivo && a.CedulaRuc.Trim() == cedulaRuc.Trim());

                    return consulta;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion

        #region Datos de usuario

        /// <summary>
        /// Obtiene datos del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static DatosUsuarioModel ObtenerDatosUsuario(string usuario)
        {
            try
            {
                var modelo = new DatosUsuarioModel();
                using (var db = new VYMCoreEntities())
                {
                    //busca registro del usuario por el correo(usuario)
                    var consultaDatos = db.EntidadPersonas.FirstOrDefault(fod => fod.NombreUsuario == usuario);
                    
                    if (consultaDatos != null)
                    {
                        //busca registro de perfil por identificador de usuario
                        var consultaPerfil =
                        db.PerfilUsuarios.FirstOrDefault(fod => fod.IdEntidadPersona == consultaDatos.IdEntidadPersona);

                        //busca registro de catalogo por identificador de perfil
                        var catalogoPerfil =
                            db.Catalogoes.FirstOrDefault(fod => fod.IdCatalogo == consultaPerfil.TipoUsuario);
                        //asigna datos al modelo
                        modelo = new DatosUsuarioModel
                        {
                            Nombres = $"{consultaDatos.Nombres} {consultaDatos.Apellidos}",
                            Correo = consultaDatos.Correo,
                            Usuario = consultaDatos.NombreUsuario,
                            IdPerfil = consultaPerfil?.TipoUsuario ?? 0,
                            IdUsuario = consultaDatos.IdEntidadPersona,
                            NombrePerfil = catalogoPerfil?.Nombre ?? ""
                        };
                    }
                }
                return modelo;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #endregion
    }
}
