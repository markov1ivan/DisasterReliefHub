using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;

using DisasterReliefHub.Domain.Repository;
using DisasterReliefHub.Libraries;
using DisasterReliefHub.Twilio;

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
             builder.Register(c => new Libraries.Dwolla("8zYtJBBRqqmDAT5tQ9ETEMaDbiRqZ/WvTmIz3Ua8dIZXIgB3jT", "r5mkf/PFY8xffmhSd87TVmFcf7+uz48U1Ad3yyXt+8DUqC8oHN"));

             builder.Register(c => new SendGrid("markov1ivan", "ZDKP9WJdTjMFY1cexJ5a"));
             builder.Register(c => new TwilioManager("AC33f67bc4a21659e0be9754b789d9da4d", "e4dd86b2fd560201834d943be00a1df5"));
             Container = builder.Build();
             DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
         }
    }
}