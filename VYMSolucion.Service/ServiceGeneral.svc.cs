using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using VYMSolucion.Logic;
using VYMSolucion.Model;

namespace VYMSolucion.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceGeneral : IServiceGeneral
    {

        #region General

        #region Ubicación Geográfica

        /// <summary>
        /// Lee todos los centros administrativos
        /// </summary>
        /// <returns>estructura Iqueriable tipo CentroAdministrativoModel</returns>
        public IQueryable<CentroAdministrativoModel> LeerTodosCentroAdministrativo()
        {
            //obteniene respuesta de lógica
            var respuesta = LogicaCentroAdministrativo.LeerTodosCentroAdministrativo();
            //retorna respuesta
            return respuesta;
        }

        #region Operacioens CRUD

        /// <summary>
        /// Lee registro de centro administrativo
        /// </summary>
        /// <param name="idCentroAdministrativo"></param>
        /// <returns></returns>
        public CentroAdministrativoModel LeerCentroAdministrativo(int idCentroAdministrativo)
        {
            return LogicaCentroAdministrativo.LeerCentroAdministrativo(idCentroAdministrativo);
        }

        /// <summary>
        /// Crea registro de centro administrativo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CrearCentroAdministrativo(CentroAdministrativoModel model)
        {
            return LogicaCentroAdministrativo.CrearCentroAdministrativo(model);
        }

        /// <summary>
        /// Edita un registro de centro administrativo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditarCentroAdministrativo(CentroAdministrativoModel model)
        {
            return LogicaCentroAdministrativo.EditarCentroAdministrativo(model);
        }

        /// <summary>
        /// Elimina un registro de centro administrativo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EliminarCentroAdministrativo(CentroAdministrativoModel model)
        {
            return LogicaCentroAdministrativo.EliminarCentroAdministrativo(model);
        }

        #endregion

        #endregion

        #endregion

        #region Catálogos

        /// <summary>
        /// Lee todas las ubicaciones geográficas
        /// </summary>
        /// <returns></returns>
        public IList<ComboModel> ListaTodasUbicacionGeografica()
        {
            //obteniene respuesta de lógica
            var respuesta = LogicaCatalogo.ListaTodasUbicacionGeografica();
            //retorna respuesta
            return respuesta;
        }

        /// <summary>
        /// Lee todas las ubicaciones geogáficas hijos
        /// </summary>
        /// <param name="idUbicacionGeograficaPadre"></param>
        /// <returns></returns>
        public IList<ComboModel> ListaTodasUbicacionGeograficaHijo(int idUbicacionGeograficaPadre)
        {
            //obteniene respuesta de lógica
            var respuesta = LogicaCatalogo.ListaTodasUbicacionGeograficaHijo(idUbicacionGeograficaPadre);
            //retorna respuesta
            return respuesta;
        }

        #endregion

        #region Iniciar Sesión

        /// <summary>
        /// Valida cuenta de usuario
        /// para acceder a su perfil
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ValidarCuentaUsuario(IniciarSesionModel model)
        {
            return LogicaIniciarSesion.ValidarCuentaUsuario(model);
        }

        #endregion

        #region Registrarse

        #region Paciente

        /// <summary>
        /// Crea registro de profesional
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CrearRegistroProfesional(ProfesionalModel model)
        {
            return LogicaProfesional.CrearRegistroProfesional(model);
        }

        #endregion

        #region Paciente

        /// <summary>
        /// Crea registro de paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CrearRegistroPaciente(PacienteModel model)
        {
            return LogicaPaciente.CrearRegistroPaciente(model);
        }

        #endregion

        #region Activar usuario

        /// <summary>
        /// Activar cuenta de usuario
        /// </summary>
        /// <param name="parametroActivacion"></param>
        public DatosUsuarioModel ActivarCuenta(string parametroActivacion)
        {
            return LogicaGeneral.ActivarCuenta(parametroActivacion);
        }

        /// <summary>
        /// Obtiene datos del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public DatosUsuarioModel ObtenerDatosUsuario(string usuario)
        {
            return LogicaGeneral.ObtenerDatosUsuario(usuario);
        }

        #endregion

        #region Validaciones

        /// <summary>
        /// Valida si el correo ya se encuetra registrado
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public bool ValidarCorreoRepetido(string correo)
        {
            return LogicaGeneral.ValidarCorreoRepetido(correo);
        }

        /// <summary>
        /// Valida si la cedula/RUC ya se encuetra registrado
        /// </summary>
        /// <param name="cedulaRuc"></param>
        /// <returns></returns>
        public bool ValidarCedulaRuc(string cedulaRuc)
        {
            return LogicaGeneral.ValidarCedulaRuc(cedulaRuc);
        }

        #endregion

        #endregion

        #region Paciente

        /// <summary>
        /// Crear registro de paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool CrearPaciente(PacienteTitularModel model)
        {
            return LogicaPaciente.CrearPaciente(model);
        }

        /// <summary>
        /// Leer registro del paciente
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        public PacienteTitularModel LeerPaciente(long idEntidadPersona)
        {
            return LogicaPaciente.LeerPaciente(idEntidadPersona);
        }

        /// <summary>
        /// Leer registros de pacienes por titular de la factura
        /// </summary>
        /// <param name="idEntidadPersona"></param>
        /// <returns></returns>
        public IQueryable<PacienteTitularModel> LeerPacientesEntidadPersonaPadre(long idEntidadPersona)
        {
            return LogicaPaciente.LeerPacientesEntidadPersonaPadre(idEntidadPersona);
        }

        /// <summary>
        /// Edtiar registro de paciente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditarPaciente(PacienteTitularModel model)
        {
            return LogicaPaciente.EditarPaciente(model);
        }

        public bool ActivarDesactivarPaciente(PacienteTitularModel model)
        {
            return LogicaPaciente.ActivarDesactivarPaciente(model);
        }

        #endregion
    }
}
