using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using VYMSolucion.Data;
using VYMSolucion.Model;

namespace VYMSolucion.Logic
{
    public class LogicaCentroAdministrativo
    {
        /// <summary>
        /// Lee todos los centros administrativos
        /// </summary>
        /// <returns>estructura Iqueriable tipo CentroAdministrativoModel</returns>
        public static IQueryable<CentroAdministrativoModel> LeerTodosCentroAdministrativo()
        {
            try
            {
                //instancia hacia la bd
                var db = new VYMCoreEntities();

                //consulta linq
                //solo los centros administrativos padres
                var consulta = from c in db.CentroAdministrativoes
                               join ug in db.UbicacionGeograficas on c.IdUbicacionGeografica equals ug.IdUbicacionGeografica
                    where c.IdCentroAdministrativoPadre == null
                    select new CentroAdministrativoModel()
                    {
                        IdCentroAdministrativo = c.IdCentroAdministrativo,
                        Nombre = c.Nombre,
                        Descripcion = c.Descripcion,
                        IdUbicacionGeografica = c.IdUbicacionGeografica,
                        UbicacionGeograficaNombre = ug.Nombre,
                        Direccion = c.Direccion,
                        Telefono = c.Telefono,
                        UrlMapa = c.UrlMapa,
                        IdCentroAdministrativoPadre = c.IdCentroAdministrativoPadre,
                        EsActivo = c.EsActivo
                    };
                //retorna la consulta
                return consulta;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        #region Operaciones CRUD

        /// <summary>
        /// Lee registro de centro administrativo
        /// </summary>
        /// <param name="idCentroAdministrativo"></param>
        /// <returns></returns>
        public static CentroAdministrativoModel LeerCentroAdministrativo(int idCentroAdministrativo)
        {
            try
            {
                //instancia de db
                using (var db = new VYMCoreEntities())
                {
                    //busca datos del registro
                    var datos =
                        db.CentroAdministrativoes.FirstOrDefault(
                            fod => fod.IdCentroAdministrativo == idCentroAdministrativo);
                    //si no encuentra envía valores null
                    if(datos == null)
                        return new CentroAdministrativoModel();
                    //asigna a entidad model la consulta
                    var respuesta = new CentroAdministrativoModel
                    {
                        IdCentroAdministrativo = datos.IdCentroAdministrativo,
                        Descripcion = datos.Descripcion,
                        Nombre = datos.Nombre,
                        UrlMapa = datos .UrlMapa,
                        Telefono = datos.Telefono,
                        IdUbicacionGeografica = datos.IdUbicacionGeografica,
                        IdCentroAdministrativoPadre = datos.IdCentroAdministrativoPadre,
                        Direccion = datos.Direccion,
                        EsActivo = datos.EsActivo,
                        
                    };
                    //busca datos de ubicación geográfica 
                    var datosProvincia =
                        db.UbicacionGeograficas.FirstOrDefault(
                            fod => fod.IdUbicacionGeografica == datos.IdUbicacionGeografica);
                    //asigna identificador para provincia
                    respuesta.IdProvincia = datosProvincia == null ? 0 : datosProvincia.IdUbicacionGeograficaPadre;
                    //busca datos de ubicación geográfica
                    var datosPais =
                        db.UbicacionGeograficas.FirstOrDefault(
                            fod => fod.IdUbicacionGeografica == respuesta.IdProvincia);
                    //asigna identificador para país
                    respuesta.IdPais = datosPais == null ? 0 : datosPais.IdUbicacionGeograficaPadre;

                    //retorna respuesta
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Crea registro de centro administrativo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool CrearCentroAdministrativo(CentroAdministrativoModel model)
        {
            try
            {
                //comienso de transacción
                using (var ts = new TransactionScope())
                {
                    //instancia a bd
                    var db = new VYMCoreEntities();
                    //asignación de datos a entidad de db
                    var centroAdministrativo = new CentroAdministrativo
                    {
                        Descripcion = model.Descripcion,
                        Nombre = model.Nombre,
                        UrlMapa = model.UrlMapa,
                        Telefono = model.Telefono,
                        IdUbicacionGeografica = model.IdUbicacionGeografica,
                        IdCentroAdministrativoPadre = model.IdCentroAdministrativoPadre,
                        Direccion = model.Direccion,
                        EsActivo = true,
                    };
                    //agrega entidad a db
                    db.CentroAdministrativoes.Add(centroAdministrativo);
                    //guarda cambios
                    db.SaveChanges();
                    //transacción completada
                    ts.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Edita un registro de centro administrativo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool EditarCentroAdministrativo(CentroAdministrativoModel model)
        {
            try
            {
                //comienso de transacción
                using (var ts = new TransactionScope())
                {
                    //asignación de datos a entidad de db
                    var db = new VYMCoreEntities();
                    //busca registro
                    var datos = db.CentroAdministrativoes.Find(model.IdCentroAdministrativo);
                    //asigna nuevos datos
                    datos.Descripcion = model.Descripcion;
                    datos.Nombre = model.Nombre;
                    datos.UrlMapa = model.UrlMapa;
                    datos.Telefono = model.Telefono;
                    datos.IdUbicacionGeografica = model.IdUbicacionGeografica;
                    datos.IdCentroAdministrativoPadre = model.IdCentroAdministrativoPadre;
                    datos.Direccion = model.Direccion;

                    //guarda cambios
                    db.SaveChanges();
                    //transacción completada
                    ts.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        /// <summary>
        /// Elimina un registro de centro administrativo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool EliminarCentroAdministrativo(CentroAdministrativoModel model)
        {
            try
            {
                //comienso de transacción
                using (var ts = new TransactionScope())
                {
                    //asignación de datos a entidad de db
                    var db = new VYMCoreEntities();
                    //busca registro
                    var datos = db.CentroAdministrativoes.Find(model.IdCentroAdministrativo);
                    //asigna nuevos datos
                    datos.EsActivo = false;
                    
                    //guarda cambios
                    db.SaveChanges();
                    //transacción completada
                    ts.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        #endregion
    }
}
