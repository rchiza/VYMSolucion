using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Resources;
using VYMSolucion.Comun;
using VYMSolucion.Model;

namespace VYMSolucion.Web.Controllers
{
    [Authorize(Roles = Parametros.PerfilTitularFactura)]
    public class PacienteController : BaseController
    {
        // GET: Paciente
        public ActionResult Index()
        {
            return View();
        }

        #region Vistas para registro de paciente

        /// <summary>
        /// Vista para formulario de registro de paciente
        /// </summary>
        /// <returns></returns>
        public ActionResult NuevoPaciente()
        {

            var model = new PacienteTitularModel
            {
                Nuevo = true
            };
            return View("Paciente", model);
        }

        /// <summary>
        /// Vista para realziar busquedas de los pacientes del titular de la factura
        /// </summary>
        /// <returns></returns>
        public ActionResult BuscarPaciente()
        {
            return View();
        }

        /// <summary>
        /// Vista para error registro paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult ErrorPaciente(PacienteTitularModel model)
        {
            return View("Paciente", model);
        }

        /// <summary>
        /// Vista para ver registro paciente
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult VerPaciente(string idEntidadPersona)
        {
            var model = Services._ServiceGeneral.LeerPaciente(long.Parse(idEntidadPersona));
            model.Ver = true;
            return View("Paciente", model);
        }

        /// <summary>
        /// Vista para editar registro paciente
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult EditarPaciente(string idEntidadPersona)
        {
            var model = Services._ServiceGeneral.LeerPaciente(long.Parse(idEntidadPersona));
            model.Editar = true;
            return View("Paciente", model);
        }

        /// <summary>
        /// Vista para Activar/Desactivar registro paciente
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult ActivarDesactivarPaciente(string idEntidadPersona)
        {
            var model = Services._ServiceGeneral.LeerPaciente(long.Parse(idEntidadPersona));
            model.ActivarDesactivar = true;
            return View("Paciente", model);
        }

        #endregion

        #region Acciones para registro de paciente

        /// <summary>
        /// Leer registros de pacientes de titular de factura
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult LeerPacientesEntidadPersonaPadre([DataSourceRequest] DataSourceRequest request)
        {
            var respuesta = Services._ServiceGeneral.LeerPacientesEntidadPersonaPadre(Usuario);

            //respuesta tipo json
            return Json(respuesta.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Crear, Editar y Activar / Desactivar el registro del paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Paciente(PacienteTitularModel model)
        {
            //setea el identificador de la entidad padre
            model.IdEntidadPersonaPadre = Usuario;
            model.UsuarioAccion = Usuario;
            //Validar si el se realiza la acción de Activar / Desactivar
            if (model.ActivarDesactivar)
            {
                //llamar a función Activar/Desactivar registro de paciente
                var respuesta = Services._ServiceGeneral.ActivarDesactivarPaciente(model);
                //Validar si la respuesta es erronea
                if (!respuesta)
                    return ErrorPaciente(model);
                //redirige hacia vista del paciente
                return RedirectToAction("Index", "Paciente");
            }

            //validar si el formulario es correcto
            if (ModelState.IsValid)
            {
                //consulta si la cedula/Ruc es verdadera 
                var validarCedulaRucCorrecta = Validaciones.ValidadorDeCedula(model.CedulaRuc);

                if (!validarCedulaRucCorrecta)
                {
                    //Agrega error personalizado al modelo para mostrar
                    ModelState.AddModelError("CedulaRuc", ResourceMensajes.ErrorCedulaRucIncorrecto);
                    //muestra la vista con el error del modelo
                    return ErrorPaciente(model);
                }

                //valida si la fecha seleccionada en partes tiene el formato correcto
                var consultaFormatoFecha = Validaciones.ValidacionFormatoFecha(model.FechaAnio, model.FechaMes,
                    model.FechaDia);

                if (!consultaFormatoFecha)
                {
                    
                    //Agrega error personalizado al modelo para mostrar
                    ModelState.AddModelError("FechaNacimiento", ResourceMensajes.ErrorFormatoFechaNacimiento);
                    //muestra la vista con el error del modelo
                    return ErrorPaciente(model);
                }

                if (model.IdEntidadPersona == 0)
                    //Validar si el identificador es cero entra por la función crear registro paciente
                {
                    //llamar a función Crear registro de paciente
                    var respuesta = Services._ServiceGeneral.CrearPaciente(model);
                    //Validar si la respuesta es erronea
                    if (!respuesta)
                        return ErrorPaciente(model);
                    //redirige hacia vista del paciente
                    return RedirectToAction("Index", "Paciente");
                }
                else // Si el identificador no es cero entra por la función editar registro paciente
                {
                    //llamar a función Editar registro de paciente
                    var respuesta = Services._ServiceGeneral.EditarPaciente(model);
                    //Validar si la respuesta es erronea
                    if (!respuesta)
                        return ErrorPaciente(model);
                    //redirige hacia vista del paciente
                    return RedirectToAction("Index", "Paciente");
                }
            }

            //redirige hacia la vista de error
            return ErrorPaciente(model);
        }

        #endregion



    }

    
}