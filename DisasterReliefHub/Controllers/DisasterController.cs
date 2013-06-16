using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;

namespace DisasterReliefHub.Controllers
{
    public class DisasterController : Controller
    {
        public ActionResult Index(int disasterId = 0)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int disasterId = -1)
        {
            Disaster model = new Disaster();
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            if (disasterId > 0)
            {
                model = repo.Get<Disaster>(disasterId);
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Disaster model)
        {
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            if (ModelState.IsValid)
            {
                repo.Save(model);
                return this.Redirect(Url.Action("Index"));
            }
            return View(model);
        }
    }
}
