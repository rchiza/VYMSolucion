using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VYMSolucion.Model;
using VYMSolucion.Logic;
namespace VYMSolucion.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCatalogo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceCatalogo.svc o ServiceCatalogo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceCatalogo : IServiceCatalogo
    {
        #region Catálogos

        /// <summary>
        /// Lista el catálogo de genero
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaGenero()
        {
            return LogicaCatalogo.ListaGenero();
        }

        /// <summary>
        /// Lista el catálogo de estado civil
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaEstadoCivil()
        {
            return LogicaCatalogo.ListaEstadoCivil();
        }

        /// <summary>
        /// Lista los perfiles de usuario
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaPerfiles()
        {
            return LogicaCatalogo.ListaPerfiles();
        }

        /// <summary>
        /// Lista los tipos de sangre
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaTipoSangre()
        {
            return LogicaCatalogo.ListaTipoSangre();
        }

        /// <summary>
        /// Lista los tipos de parentesco
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaParentesco()
        {
            return LogicaCatalogo.ListaParentesco();
        }

        #region Fechas

        /// <summary>
        /// Lista de días para fechas
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaFechaDias()
        {
            return LogicaCatalogo.ListaFechaDias();
        }

        /// <summary>
        /// Lista de meses para fechas
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaFechaMeses()
        {
            return LogicaCatalogo.ListaFechaMeses();
        }

        /// <summary>
        /// Lista de años para fechas
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaFechaAnios()
        {
            return LogicaCatalogo.ListaFechaAnios();
        }

        /// <summary>
        /// Lista de años para fecha menor de edad
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaFechaAniosMenorEdad()
        {
            return LogicaCatalogo.ListaFechaAniosMenorEdad();
        }

        #endregion

        #endregion
    }
}
