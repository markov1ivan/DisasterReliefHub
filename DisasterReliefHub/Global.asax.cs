using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac;

using Devtalk.EF.CodeFirst;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Domain.Repository;
using DisasterReliefHub.Utilities;

namespace DisasterReliefHub
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            DependencyInjection.Setup();
            DependencyInjection.Container.Resolve<DataContext>().InitializeDatabase();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            DataEvents.Setup();
            MockData.Setup();
            NotificationTimer timer = new NotificationTimer();
        }
    }
}