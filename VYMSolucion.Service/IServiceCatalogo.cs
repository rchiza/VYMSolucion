using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VYMSolucion.Model;

namespace VYMSolucion.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCatalogo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCatalogo
    {
        #region Catálogos

        [OperationContract]
        IList<ComboModel> ListaGenero();

        [OperationContract]
        IList<ComboModel> ListaEstadoCivil();

        [OperationContract]
        IList<ComboModel> ListaPerfiles();

        [OperationContract]
        IList<ComboModel> ListaTipoSangre();

        [OperationContract]
        IList<ComboModel> ListaParentesco();

        #region Fechas

        [OperationContract]
        IList<ComboModel> ListaFechaDias();

        [OperationContract]
        IList<ComboModel> ListaFechaMeses();

        [OperationContract]
        IList<ComboModel> ListaFechaAnios();

        [OperationContract]
        IList<ComboModel> ListaFechaAniosMenorEdad();

        #endregion

        #endregion
    }
}
