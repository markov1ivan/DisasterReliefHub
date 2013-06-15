using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;

using DisasterReliefHub.Domain.Repository;

namespace DisasterReliefHub.App_Start
{
    public class DependencyInjection
    {
        public static IContainer Container { get; internal set; }
         public static void Setup()
         {
             var builder = new ContainerBuilder();

             builder.Register(c => new DataContext(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
             builder.RegisterType<Repository>().As<IRepository>();
             Container = builder.Build();
             DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
         }
    }
}