using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VYMSolucion.Comun;
using VYMSolucion.Data;
using VYMSolucion.Model;

namespace VYMSolucion.Logic
{
    public class LogicaCatalogo
    {
        #region Catálogos

        /// <summary>
        /// Lee todas las ubicaciones geográficas
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaTodasUbicacionGeografica()
        {
            try
            {
                //Instancia de db
                var db = new VYMCoreEntities();
                //consulta linq de todas las ubicaciones geográficas activas
                var consulta = (from ug in db.UbicacionGeograficas
                    where ug.EsActivo
                    && ug.IdUbicacionGeograficaPadre == null
                    select new ComboModel()
                    {
                        Id = ug.IdUbicacionGeografica,
                        Nombre = ug.Nombre
                    }).OrderBy(ob => ob.Nombre);
                //convirte la consulta Iqueryable a lista
                var resp = consulta.ToList();
                //retorna la consulta
                return resp;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Lee todas las ubicaciones geogáficas hijos
        /// </summary>
        /// <param name="idUbicacionGeograficaPadre"></param>
        /// <returns></returns>
        public static IList<ComboModel> ListaTodasUbicacionGeograficaHijo(int idUbicacionGeograficaPadre)
        {
            try
            {
                //Instancia de db
                var db = new VYMCoreEntities();
                //consulta linq de todas las ubicaciones geográficas activas
                var consulta = (from ug in db.UbicacionGeograficas
                                where ug.EsActivo
                                && ug.IdUbicacionGeograficaPadre == idUbicacionGeograficaPadre
                                select new ComboModel()
                                {
                                    Id = ug.IdUbicacionGeografica,
                                    Nombre = ug.Nombre
                                }).OrderBy(ob => ob.Nombre);
                //convirte la consulta Iqueryable a lista
                var resp = consulta.ToList();
                //retorna la consulta
                return resp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista el catálogo de genero
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaGenero()
        {
            try
            {
                //Instancia de db
                var db = new VYMCoreEntities();
                //consulta linq de todas las ubicaciones geográficas activas
                var consulta = (from c in db.Catalogoes.Where(w => w.EsActivo)
                                where c.IdCatalogoPadre == Parametros.IdCatalogoGenero
                                select new ComboModel()
                                {
                                    Id = c.IdCatalogo,
                                    Nombre = c.Nombre
                                }).OrderBy(ob => ob.Nombre);
                //convirte la consulta Iqueryable a lista
                var resp = consulta.ToList();
                //retorna la consulta
                return resp;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Lista el catálogo de estado civil
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaEstadoCivil()
        {
            try
            {
                //Instancia de db
                var db = new VYMCoreEntities();
                //consulta linq de todas las ubicaciones geográficas activas
                var consulta = (from c in db.Catalogoes.Where(w => w.EsActivo)
                                where c.IdCatalogoPadre == Parametros.IdCatalogoEstadoCivil
                                select new ComboModel()
                                {
                                    Id = c.IdCatalogo,
                                    Nombre = c.Nombre
                                }).OrderBy(ob => ob.Nombre);
                //convirte la consulta Iqueryable a lista
                var resp = consulta.ToList();
                //retorna la consulta
                return resp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        /// <summary>
        /// Lista los perfiles de usuario
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaPerfiles()
        {
            try
            {
                //instancia de entity
                using (var db = new VYMCoreEntities())
                {
                    //consulta de perfiles en linq
                    var consulta =
                        db.Catalogoes.Where(w => w.EsActivo && w.IdCatalogoPadre == Parametros.IdCatalogoPerfil)
                            .Select(s => new ComboModel //asignación a modelo
                            {
                                Id = s.IdCatalogo,
                                Nombre = s.Nombre
                            }).OrderBy(ob => ob.Nombre).ToList();//conversión en lista
                    //retorno de consulta
                    return consulta;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista los tipos de sangre
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaTipoSangre()
        {
            try
            {
                
                //instancia de entity
                using (var db = new VYMCoreEntities())
                {
                    //consulta de perfiles en linq
                    var consulta =
                        db.Catalogoes.Where(w => w.EsActivo && w.IdCatalogoPadre == Parametros.IdCatalogoTipoSangre)
                            .Select(s => new ComboModel //asignación a modelo
                            {
                                Id = s.IdCatalogo,
                                Nombre = s.Nombre
                            }).OrderBy(ob => ob.Nombre).ToList();//conversión en lista
                    //retorno de consulta
                    return consulta;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Lista los tipos de sangre
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaParentesco()
        {
            try
            {

                //instancia de entity
                using (var db = new VYMCoreEntities())
                {
                    //consulta de perfiles en linq
                    var consulta =
                        db.Catalogoes.Where(w => w.EsActivo && w.IdCatalogoPadre == Parametros.IdCatalogoParentesco)
                            .Select(s => new ComboModel //asignación a modelo
                            {
                                Id = s.IdCatalogo,
                                Nombre = s.Nombre
                            }).OrderBy(ob => ob.Nombre).ToList();//conversión en lista
                    //retorno de consulta
                    return consulta;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Fechas registro

        /// <summary>
        /// Lista de días para fechas
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaFechaDias()
        {
            try
            {
                var lista = new List<ComboModel>();
                for (int i = 1; i <= 31; i++)
                {
                    lista.Add(new ComboModel()
                    {
                        Id = i,
                        Nombre = i.ToString()
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        /// <summary>
        /// Lista de meses para fechas
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaFechaMeses()
        {
            try
            {
                var lista = new List<ComboModel>();
                for (int i = 1; i <= 12; i++)
                {
                    DateTime mes = new DateTime(2000,i,1);
                    lista.Add(new ComboModel()
                    {
                        Id = i,
                        Nombre = mes.ToString("MMMM")
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista de años para fechas
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaFechaAnios()
        {
            try
            {

                int anioMayorEdad = DateTime.Now.Year - 18;
                int anioLimiteEdad = anioMayorEdad - 70;
                var lista = new List<ComboModel>();
                for (int i = anioLimiteEdad; i <= anioMayorEdad; i++)
                {
                    lista.Add(new ComboModel()
                    {
                        Id = i,
                        Nombre = i.ToString()
                    });
                }

                return lista.OrderByDescending(obd => obd.Id).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Lista de años para fechas de menor de edad
        /// </summary>
        /// <returns></returns>
        public static IList<ComboModel> ListaFechaAniosMenorEdad()
        {
            try
            {

                int anioMayorEdad = DateTime.Now.Year;
                int anioLimiteEdad = anioMayorEdad - 18;
                var lista = new List<ComboModel>();
                for (int i = anioLimiteEdad; i <= anioMayorEdad; i++)
                {
                    lista.Add(new ComboModel()
                    {
                        Id = i,
                        Nombre = i.ToString()
                    });
                }

                return lista.OrderByDescending(obd => obd.Id).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #endregion
    }
}
