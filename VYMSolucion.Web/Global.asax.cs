using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using VYMSolucion.Model;

namespace VYMSolucion.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "ResourceMensajes";
            DefaultModelBinder.ResourceClassKey = "ResourceMensajes";
        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //leemos el usuario actual
                        string username = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
                        
                        //llamada al metodos necesario del proxy
                        var resp = Services._ServiceCatalogo.ListaPerfiles();

                        long idPerfil = long.Parse(username.Split(';')[2]);
                        string perfilNombre = null;
                        var perfil = resp.FirstOrDefault(fod => fod.Id == idPerfil);
                        if (perfil != null)
                        {
                            perfilNombre = perfil.Nombre;
                        }

                        string[] lista = new[] { perfilNombre };

                        //Creamos el usuario Principal
                        e.User = new System.Security.Principal.GenericPrincipal(
                                new System.Security.Principal.GenericIdentity(username, "Forms"),
                                lista);


                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }


        protected void Application_BeginRequest()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //Crea un cultureInfo del idioma que tiene el cookie,
            //si no encuentra el cookie (null) crea con el idioma 'es'
            var cultureInfo = new CultureInfo("es");

            //asigno al hilo de ejecución el lenguaje creado
            //siempre debe ir sobre CurrentUICulture y CurrentCulture
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
        }
    }
}
