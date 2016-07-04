using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.Attributes;
using Kendo.Mvc.Extensions;
using VYMSolucion.Comun;
using VYMSolucion.Model;

namespace VYMSolucion.Web.Controllers
{
    [AllowAnonymous]
    public class RegistrarseController : Controller
    {
        // GET: Registrarse
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Vista de registro correcto
        /// </summary>
        /// <returns></returns>
        public ActionResult RegistroCorrecto()
        {
            return View();
        }

        /// <summary>
        /// Vista para activar cuenta de usuario
        /// </summary>
        /// <param name="activarCuenta"></param>
        /// <returns></returns>
        public ActionResult ActivarCuenta(string activarCuenta)
        {
            var model = Services._ServiceGeneral.ActivarCuenta(activarCuenta);

            return View(model);
        }

        #region Paciente

        /// <summary>
        /// Genera vista
        /// </summary>
        /// <returns></returns>
        public ActionResult Paciente()
        {
            //asignación de modelo vacío
            var model = new PacienteModel();
            //envía modelo hacia la vista
            return View(model);
        }

        /// <summary>
        /// Genera vista de error que recibe parametro de modelo
        /// </summary>
        /// <param name="model">Estructura de modelo paciente</param>
        /// <returns></returns>
        public ActionResult PacienteError(PacienteModel model)
        {
            return View("Paciente", model);
        }

        /// <summary>
        /// Crea registro de paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, CaptchaVerify("El valor no coincide con la imagen")]
        public ActionResult PacienteCrear(PacienteModel model)
        {
            //consulta si la cedula/Ruc es verdadera 
            var validarCedulaRucCorrecta = Validaciones.ValidadorDeCedula(model.CedulaRuc);

            if (!validarCedulaRucCorrecta)
            {
                //Agrega error personalizado al modelo para mostrar
                ModelState.AddModelError("CedulaRuc", ResourceMensajes.ErrorCedulaRucIncorrecto);
                //muestra la vista con el error del modelo
                return PacienteError(model);
            }

            //consulta si la cédula / RUC ya se encuentra registrado
            var consulatCedulaRuc = Services._ServiceGeneral.ValidarCedulaRuc(model.CedulaRuc);

            if (consulatCedulaRuc)
            {
                //Agrega error personalizado al modelo para mostrar
                ModelState.AddModelError("CedulaRuc", ResourceMensajes.ErrorCedulaRucRepetido);
                //muestra la vista con el error del modelo
                return PacienteError(model);
            }

            //consulta si el correo ya se encuentra registrado
            var consultaCorreo = Services._ServiceGeneral.ValidarCorreoRepetido(model.Correo);

            if (consultaCorreo)
            {
                //Agrega error personalizado al modelo para mostrar
                ModelState.AddModelError("Correo", ResourceMensajes.ErrorCorreoRepetido);
                //muestra la vista con el error del modelo
                return PacienteError(model);
            }

            if (ModelState.IsValid)
            {
                //respuesta para creación de registro de paciente
                var profesional = Services._ServiceGeneral.CrearRegistroPaciente(model);

                //si es correcto se va a vista de registro correcto
                if (profesional)
                    return RedirectToAction("RegistroCorrecto", "Registrarse");
            }

            ModelState.AddModelError("CaptchaInputText", ResourceMensajes.ErrorCaptcha);
            return PacienteError(model);
        }

        #endregion

        #region Profesional

        /// <summary>
        /// Genera vista
        /// </summary>
        /// <returns></returns>
        public ActionResult Profesional()
        {
            //asignación de modelo vacío
            var model = new ProfesionalModel();
            //envía modelo hacia la vista
            return View(model);
        }

        /// <summary>
        /// Genera vista de error que recibe parametro de modelo
        /// </summary>
        /// <param name="model">Estructura de modelo profesional</param>
        /// <returns></returns>
        public ActionResult ProfesionalError(ProfesionalModel model)
        {
            return View("Profesional", model);
        }

        /// <summary>
        /// Crea para registro de profesional
        /// </summary>
        /// <param name="model">Estructura de modelo profesional</param>
        /// <returns></returns>
        [HttpPost, CaptchaVerify("El valor no coincide con la imagen")]
        public ActionResult ProfesionalCrear(ProfesionalModel model)
        {
            //consulta si la cedula/Ruc es verdadera 
            var validarCedulaRucCorrecta = Validaciones.ValidadorDeCedula(model.CedulaRuc);

            if (!validarCedulaRucCorrecta)
            {
                //Agrega error personalizado al modelo para mostrar
                ModelState.AddModelError("CedulaRuc", ResourceMensajes.ErrorCedulaRucIncorrecto);
                //muestra la vista con el error del modelo
                return ProfesionalError(model);
            }

            //consulta si la cédula / RUC ya se encuentra registrado
            var consulatCedulaRuc = Services._ServiceGeneral.ValidarCedulaRuc(model.CedulaRuc);

            if (consulatCedulaRuc)
            {
                //Agrega error personalizado al modelo para mostrar
                ModelState.AddModelError("CedulaRuc", ResourceMensajes.ErrorCedulaRucRepetido);
                //muestra la vista con el error del modelo
                return ProfesionalError(model);
            }

            //valida si la fecha seleccionada en partes tiene el formato correcto
            var consultaFormatoFecha = Validaciones.ValidacionFormatoFecha(model.FechaAnio, model.FechaMes,
                model.FechaDia);

            if (!consultaFormatoFecha)
            {
                //Agrega error personalizado al modelo para mostrar
                ModelState.AddModelError("FechaNacimiento", ResourceMensajes.ErrorFormatoFechaNacimiento);
                //muestra la vista con el error del modelo
                return ProfesionalError(model);
            }
            
            //consulta si el correo ya se encuentra registrado
            var consultaCorreo = Services._ServiceGeneral.ValidarCorreoRepetido(model.Correo);

            if (consultaCorreo)
            {
                //Agrega error personalizado al modelo para mostrar
                ModelState.AddModelError("Correo", ResourceMensajes.ErrorCorreoRepetido);
                //muestra la vista con el error del modelo
                return ProfesionalError(model);
            }

            if (ModelState.IsValid)
            {
                //respuesta para creación de registro de profesional
                var profesional = Services._ServiceGeneral.CrearRegistroProfesional(model);

                //si es correcto se va a vista de registro correcto
                if (profesional)
                    return RedirectToAction("RegistroCorrecto", "Registrarse");
            }

            ModelState.AddModelError("CaptchaInputText", ResourceMensajes.ErrorCaptcha);
            return ProfesionalError(model);
        }

        #endregion
    }
}