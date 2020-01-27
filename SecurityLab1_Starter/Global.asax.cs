using SecurityLab1_Starter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolver.SetResolver(new Infrastructure.NinjectDependencyResolver());
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            Logger lu = new Logger();
            lu.eventLog(System.Diagnostics.EventLogEntryType.Error, ex.Message);
            lu.writeLog(ex);
            //log the error!
            /*Logger.eventLog(ex);
            Logger.writeLog(ex);*/

            Exception exception = Server.GetLastError();
            System.Diagnostics.Debug.WriteLine(exception);

            //REDIRECT
            HttpContext.Current.Response.Redirect("Home");
        }

    }
}
