using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VYMSolucion.Web.Controllers
{
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Index()
        {
            return View();
        }

        #region Catálogos

        /// <summary>
        /// Lee todas las ubicaciones geográficas
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaTodasUbicacionGeografica()
        {
            var respuesta = Services._ServiceGeneral.ListaTodasUbicacionGeografica();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lee todas las ubicaciones geográficas hijos
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaTodasUbicacionGeograficaHijo(int idPadre)
        {
            var respuesta = Services._ServiceGeneral.ListaTodasUbicacionGeograficaHijo(idPadre);

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de catálogo genero
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaGenero()
        {
            var respuesta = Services._ServiceCatalogo.ListaGenero();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de catálogo estado civil
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaEstadoCivil()
        {
            var respuesta = Services._ServiceCatalogo.ListaEstadoCivil();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de catálogo tipos de sangre
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaTipoSangre()
        {
            var respuesta = Services._ServiceCatalogo.ListaTipoSangre();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de catálogo tipos de parentesco
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaParentesco()
        {
            var respuesta = Services._ServiceCatalogo.ListaParentesco();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        #region Fechas

        /// <summary>
        /// Lista de días para fechas
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaFechaDias()
        {
            var respuesta = Services._ServiceCatalogo.ListaFechaDias();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de meses para fechas
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaFechaMeses()
        {
            var respuesta = Services._ServiceCatalogo.ListaFechaMeses();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de años para fechas
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaFechaAnios()
        {
            var respuesta = Services._ServiceCatalogo.ListaFechaAnios();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lista de años para fechas menor de edad
        /// </summary>
        /// <returns></returns>
        public JsonResult ListaFechaAniosMenorEdad()
        {
            var respuesta = Services._ServiceCatalogo.ListaFechaAniosMenorEdad();

            return Json(respuesta, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion
    }
}