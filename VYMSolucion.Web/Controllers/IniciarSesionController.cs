using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Resources;
using VYMSolucion.Model;

namespace VYMSolucion.Web.Controllers
{
    [AllowAnonymous]
    public class IniciarSesionController : Controller
    {
        // GET: IniciarSesion
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Inicio de sesión
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(IniciarSesionModel model, string returnUrl)
        {
            //llamada a validación de la cuenta
            var accion = Services._ServiceGeneral.ValidarCuentaUsuario(model);

            if (accion)
            {
                //llamada a obtener datos de la cuenta validada
                var datos = Services._ServiceGeneral.ObtenerDatosUsuario(model.Usuario);

                if (datos != null)
                {
                    //guarda en una cookie la validez de la autenticacion con datos del usuario
                    FormsAuthentication.SetAuthCookie(
                        datos.IdUsuario + ";" + // Id entidad persona
                        datos.Nombres + ";" + // Nombres y apellidos
                        datos.IdPerfil + ";" + // Id perfil usuario
                        datos.NombrePerfil + ";" + // Nombre perfil
                        datos.Correo + ";" + // Correo entidad persona
                        datos.Usuario, false); // Usuario entidad persona
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }

            ModelState.AddModelError("ValidarUsuario", ResourceLayout.CredencialesInvalidas);
            return View(model);
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        public ActionResult LogOff()
        {
            
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.SetAuthCookie(null, true);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}