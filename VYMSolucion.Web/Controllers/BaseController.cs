using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VYMSolucion.Web.Controllers
{
    public class BaseController : Controller
    {

        /// <summary>
        /// Identificador del usuario
        /// </summary>
        public long Usuario => long.Parse(User.Identity.Name.Split(';')[0]);

        /// <summary>
        /// Nombres y Apellidos del usuario
        /// </summary>
        public string NombreUsuario => User.Identity.Name.Split(';')[1];

        /// <summary>
        /// Identificador del perfil
        /// </summary>
        public long Perfil => long.Parse(User.Identity.Name.Split(';')[2]);

        /// <summary>
        /// Nombre del perfil
        /// </summary>
        public string NombrePerfil => User.Identity.Name.Split(';')[3];

        /// <summary>
        /// Correo del usuario
        /// </summary>
        public string Correo => User.Identity.Name.Split(';')[4];

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string UsuarioNombre => User.Identity.Name.Split(';')[5];
    }
}