using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Resources;
using VYMSolucion.Model;


namespace VYMSolucion.Web.Controllers
{
    public class CentroAdministrativoController : Controller
    {
        // GET: CentroAdministrativo
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Lee todos los centros administrativos
        /// </summary>
        /// <param name="request">Optiene solicitudes de la UI del elemento</param>
        /// <returns></returns>
        public ActionResult LeerTodosCentroAdministrativo([DataSourceRequest] DataSourceRequest request)
        {
            //Llamada al servicio y al método de la lógica
            var respuesta = Services._ServiceGeneral.LeerTodosCentroAdministrativo();
            //retorna respuesta con solicitudes de la UI
            return Json(respuesta.ToDataSourceResult(request));
        }

        #region Operaciones CRUD

        /// <summary>
        /// Genera vista para centro administrativo en modo ver
        /// </summary>
        /// <param name="idCentroAdministrativo"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult VerCentroAdministrativo(int idCentroAdministrativo)
        {
            //lee registro de centro administrativo
            var model = Services._ServiceGeneral.LeerCentroAdministrativo(idCentroAdministrativo);

            //seteo de la vista
            ViewData["action"] = "Ver";
            ViewData["ReadOnly"] = true;

            //muestro pantalla
            return View("CentroAdministrativo", model);
        }

        /// <summary>
        /// Genera vista para centro administrativo en modo Crear
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ViewResult CrearCentroAdministrativo()
        {
            //lee registro de centro administrativo
            var model = new CentroAdministrativoModel();

            //seteo de la vista
            ViewData["action"] = "Crear";
            ViewData["ReadOnly"] = false;

            //muestro pantalla
            return View("CentroAdministrativo", model);
        }

        /// <summary>
        /// Genera vista para centro administrativo en modo Editar
        /// </summary>
        /// <param name="idCentroAdministrativo"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult EditarCentroAdministrativo(int idCentroAdministrativo)
        {
            //lee registro de centro administrativo
            var model = Services._ServiceGeneral.LeerCentroAdministrativo(idCentroAdministrativo);

            //seteo de la vista
            ViewData["action"] = "Editar";
            ViewData["ReadOnly"] = false;

            //muestro pantalla
            return View("CentroAdministrativo", model);
        }

        /// <summary>
        /// Genera vista para centro administrativo en modo Eliminar
        /// </summary>
        /// <param name="idCentroAdministrativo"></param>
        /// <returns></returns>
        [HttpPost]
        public ViewResult EliminarCentroAdministrativo(int idCentroAdministrativo)
        {
            //lee registro de centro administrativo
            var model = Services._ServiceGeneral.LeerCentroAdministrativo(idCentroAdministrativo);

            //seteo de la vista
            ViewData["action"] = "Eliminar";
            ViewData["ReadOnly"] = true;
            model.EsEliminar = true;
            //muestro pantalla
            return View("CentroAdministrativo", model);
        }

        /// <summary>
        /// Aciones para Crear, Editar y Eliminar registro de centro administrativo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CentroAdministrativo(CentroAdministrativoModel model)
        {
            var respuesta = false;
            //verifica si tiene la bandera para eliminación
            if (model.EsEliminar)
            {
                //respuesta de servicio
                respuesta = Services._ServiceGeneral.EliminarCentroAdministrativo(model);

                //retorna a la vista principal
                if (respuesta)
                    return RedirectToAction("Index");
                else
                {
                    //prepara un error general
                    ModelState.AddModelError("",ResourceMensajes.ErrorAplicacion);
                    return EliminarCentroAdministrativo(Convert.ToInt32(model.IdCentroAdministrativo));
                }
                    
            }
            //verifica si las entidades estan correctas
            if (ModelState.IsValid)
            {
                //verifica si el id es 0 para crear registro
                if (model.IdCentroAdministrativo == 0)
                {
                    //respuesta de servicio
                    respuesta = Services._ServiceGeneral.CrearCentroAdministrativo(model);
                    //retorna a la vista principal
                    if (respuesta)
                        return RedirectToAction("Index");
                    else
                    {
                        //prepara un error general
                        ModelState.AddModelError("", ResourceMensajes.ErrorAplicacion);
                        return CrearCentroAdministrativo();
                    }
                }
                else//caso contrario edita registro
                {
                    //respuesta de servicio
                    respuesta = Services._ServiceGeneral.EditarCentroAdministrativo(model);
                    //retorna a la vista principal
                    if (respuesta)
                        return RedirectToAction("Index");
                    else
                    {
                        //prepara un error general
                        ModelState.AddModelError("", ResourceMensajes.ErrorAplicacion);
                        return EditarCentroAdministrativo(Convert.ToInt32(model.IdCentroAdministrativo));
                    }
                }
            }

            //prepara un error general
            ModelState.AddModelError("", ResourceMensajes.ErrorAplicacion);

            //envia a la vista de NuevoUsuario o EditarUsuario
            if (model.IdCentroAdministrativo == 0)
                return CrearCentroAdministrativo();
            else
                return EditarCentroAdministrativo(Convert.ToInt32(model.IdCentroAdministrativo));
        }

        #endregion
    }
}