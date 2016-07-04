using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using VYMSolucion.Model;

namespace VYMSolucion.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceGeneral
    {

        #region General

        #region Ubicación Geográfica

        [OperationContract]
        IQueryable<CentroAdministrativoModel> LeerTodosCentroAdministrativo();

        #region Operaciones CRUD

        [OperationContract]
        CentroAdministrativoModel LeerCentroAdministrativo(int idCentroAdministrativo);

        [OperationContract]
        bool CrearCentroAdministrativo(CentroAdministrativoModel model);

        [OperationContract]
        bool EditarCentroAdministrativo(CentroAdministrativoModel model);

        [OperationContract]
        bool EliminarCentroAdministrativo(CentroAdministrativoModel model);

        #endregion

        #endregion


        #endregion

        #region Catálogos

        [OperationContract]
        IList<ComboModel> ListaTodasUbicacionGeografica();

        [OperationContract]
        IList<ComboModel> ListaTodasUbicacionGeograficaHijo(int idUbicacionGeograficaPadre);

        #endregion

        #region Iniciar sesión

        [OperationContract]
        bool ValidarCuentaUsuario(IniciarSesionModel model);

        [OperationContract]
        DatosUsuarioModel ObtenerDatosUsuario(string usuario);

        #endregion

        #region Registrarse

        #region Profesional

        [OperationContract]
        bool CrearRegistroProfesional(ProfesionalModel model);

        #endregion

        #region Paciente

        [OperationContract]
        bool CrearRegistroPaciente(PacienteModel model);

        #endregion

        #region Activar usaurio

        [OperationContract]
        DatosUsuarioModel ActivarCuenta(string parametroActivacion);

        #endregion

        #region Validaciones

        [OperationContract]
        bool ValidarCorreoRepetido(string correo);

        [OperationContract]
        bool ValidarCedulaRuc(string cedulaRuc);

        #endregion

        #endregion

        #region Paciente

        [OperationContract]
        bool CrearPaciente(PacienteTitularModel model);

        [OperationContract]
        PacienteTitularModel LeerPaciente(long idEntidadPersona);

        [OperationContract]
        IQueryable<PacienteTitularModel> LeerPacientesEntidadPersonaPadre(long idEntidadPersona);

        [OperationContract]
        bool EditarPaciente(PacienteTitularModel model);

        [OperationContract]
        bool ActivarDesactivarPaciente(PacienteTitularModel model);

        #endregion
    }
    
}
