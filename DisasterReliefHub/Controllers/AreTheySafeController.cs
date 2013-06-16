using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;

using DisasterReliefHub.App_Start;
using DisasterReliefHub.Code;
using DisasterReliefHub.Domain;
using DisasterReliefHub.Domain.Models;
using DisasterReliefHub.Domain.Repository;
using DisasterReliefHub.Models;

namespace DisasterReliefHub.Controllers
{
    public class AreTheySafeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repo = DependencyInjection.Container.Resolve<IRepository>();
            var user = SecurityHelper.CurrentUser();
            var all = repo.Get<MissingPerson>().ToList();
            var list = repo.Query<MissingPerson>().Where(p => p.UserFk == user.Id);
            return View(list != null ? list.ToList() : new List<MissingPerson>());
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(AreTheSafeModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = DependencyInjection.Container.Resolve<IRepository>();
                MissingPerson missing = new MissingPerson();
                missing.FirstName = model.FirstName;
                missing.LastName = model.LastName;
                missing.Email = model.Email;
                missing.UserFk = SecurityHelper.CurrentUser().Id;
                repo.Save(missing);

                var user = SecurityHelper.CurrentUser();
                user.SendEmailNotification = model.SendEmailNotification;
                user.SendPhoneNotification = model.SendEmailNotification;
                user.Phone = model.Phone;


                repo.Save(user);
                return this.Redirect(Url.Action("Index"));
            }

            return View(model);
        }

    }
}

