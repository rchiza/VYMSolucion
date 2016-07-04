using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYMSolucion.Comun;
using VYMSolucion.Data;
using VYMSolucion.Model;

namespace VYMSolucion.Logic
{
    public class LogicaIniciarSesion
    {

        /// <summary>
        /// Valida cuenta de usuario
        /// para acceder a su perfil
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool ValidarCuentaUsuario(IniciarSesionModel model)
        {
            try
            {
                //instancia de entity
                using (var db = new VYMCoreEntities())
                {
                    //encriptación de contraseña
                    var passwordCrypto = Utilitarios.Crypto.Encriptar(model.Contrasena, model.Contrasena, model.Usuario,
                        model.Usuario.Length);
                    //búsqueda de usuario
                    var consulta =
                        db.EntidadPersonas.Any(
                            a => a.EsActivo && a.NombreUsuario == model.Usuario && a.Contrasena == passwordCrypto);

                    var consultaActivacionCuenta =
                        db.ActivacionUsuarios.Any(a => a.EsActivo && a.Usuario == model.Usuario);
                    //retornar respuesta de consulta
                    if (consultaActivacionCuenta && consulta)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
    }
}
