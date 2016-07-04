using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VYMSolucion.Comun
{
    public class Parametros
    {
        #region Parámetros para catálogos

        public static long IdCatalogoGenero = 16;
        public static long IdCatalogoProfesional = 53;
        public static long IdCatalogoEstadoCivil = 19;
        public static long IdCatalogoPerfil = 61;
        public static long IdCatalogoTipoSangre = 129;
        public static long IdCatalogoParentesco = 72;

        #endregion

        #region Parámetros para Tipos de Perfil

        public static long IdPerfilProfesional = 62;
        public static long IdPerfilOperador = 63;
        public static long IdPerfilTitularFactura = 64;
        public static long IdPerfilPaciente = 65;
        public static long IdPerfilProveedor = 66;
        public static long IdPerfilOtro = 67;
        
        #endregion

        #region Parámetros para tipos de acciones de usuario

        public static int TipoActivacionUsuario = 1;
        public static int TipoRestablecerPassword = 2;

        #endregion

        #region Parámetros identificación de perfiles

        public const string PerfilProfesional = "Profesional";
        public const string PerfilOperador = "Operador";
        public const string PerfilTitularFactura = "Titular Factura";
        public const string PerfilPaciente = "Paciente";
        public const string PerfilProveedor = "Proveedor";

        #endregion

    }
}
