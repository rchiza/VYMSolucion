using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYMSolucion.Web.ServiceReferenceGeneral;
using VYMSolucion.Web.ServiceReferenceCatalogo;
namespace VYMSolucion.Web
{
    public class Services
    {
        /// <summary>
        /// variable de servicio
        /// </summary>
        private static ServiceGeneralClient _serviceGeneral;

        private static ServiceCatalogoClient _serviceCatalogo;

        /// <summary>
        /// Método de solo lectura del servicio que proboca el singleton
        /// </summary>
        public static ServiceGeneralClient _ServiceGeneral
        {
            get { return _serviceGeneral ?? (new ServiceGeneralClient()); }
        }

        public static ServiceCatalogoClient _ServiceCatalogo
        {
            get { return _serviceCatalogo ?? (new ServiceCatalogoClient()); }
        }
    }
}
