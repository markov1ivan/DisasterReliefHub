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
    public class SafePersonController : Controller
    {
        //
        // GET: /SafePerson/

        public ActionResult Index()
        {
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            return View(repo.Get<SafePerson>().ToList());
        }

        [HttpPost]
        public ActionResult IAmSafe(SafePerson model)
        {
            if (ModelState.IsValid)
            {
                var repo = DependencyInjection.Container.Resolve<IRepository>();
                repo.Save(model);
            }
            return Redirect(Url.Action("Index", "Home"));           
        }

    }
}
