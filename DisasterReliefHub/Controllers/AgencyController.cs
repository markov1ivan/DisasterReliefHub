using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Code;
using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;

namespace DisasterReliefHub.Controllers
{
    public class AgencyController : Controller
    {
        //
        // GET: /Agency/

        public ActionResult Index()
        {
            var test = SecurityHelper.CurrentUser();
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            
            return View(repo.Get<Agency>().ToList());
        }

        [HttpGet]
        public ActionResult Edit(int agencyId = -1)
        {
            var model = new Agency();
            if (agencyId > 0)
            {
                var repo = DependencyInjection.Container.Resolve<IRepository>();
                model = repo.Get<Agency>(agencyId);
            }
            return View(model); 
        }

        [HttpPost]
        public ActionResult Edit(Agency model)
        {
            if (ModelState.IsValid)
            {
                var repo = DependencyInjection.Container.Resolve<IRepository>();
                repo.Save<Agency>(model);
            }

            return Redirect(Url.Action("Index"));
        }

        public ActionResult DonateTo(int agencyId)
        {
            return View();
        }

    }
}
