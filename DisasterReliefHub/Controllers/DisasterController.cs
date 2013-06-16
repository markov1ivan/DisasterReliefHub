using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;
using DisasterReliefHub.Models;

namespace DisasterReliefHub.Controllers
{
    public class DisasterController : Controller
    {
        public ActionResult Index(int disasterId = -1)
        {
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            if (disasterId > 0)
            {
                if (disasterId == 1)
                {
                    SpecialDisaster model = new SpecialDisaster();
                    model.Agencies = repo.Get<Agency>().ToList();
                    model.SafePeople = repo.Get<SafePerson>().ToList();
                    model.Donation = new DwollaDonation();
                    model.Donation.Agency = model.Agencies.FirstOrDefault();
                    return View("SpecialDisaster", model);
                }
                else
                {

                    var disaster = repo.Get<Disaster>(disasterId);
                    return View("Details", disaster);
                }
            }
 
            return View("Index");
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
