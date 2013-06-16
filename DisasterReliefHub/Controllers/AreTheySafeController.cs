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
            return View();
        }

        [HttpPost]
        public ActionResult Index(AreTheSafeModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = DependencyInjection.Container.Resolve<IRepository>();
                MissingPerson missing = new MissingPerson();
                missing.FirstName = model.FirstName;
                missing.LastName = model.LastName;
                missing.Email = model.Email;
                repo.Save(missing);

                NotificationType notificationType = NotificationType.None;
                if (model.SendEmailNotification && model.SendSmsNotification)
                {
                    notificationType = NotificationType.Email & NotificationType.Phone;
                    SecurityHelper.CurrentUser().Phone = model.Phone;
                }
                else if (model.SendEmailNotification)
                {
                    notificationType = NotificationType.Email;
                }
                else if (model.SendSmsNotification)
                {
                    notificationType = NotificationType.Phone;
                }
                SecurityHelper.CurrentUser().NotificationType = notificationType;
                repo.Save(SecurityHelper.CurrentUser());
            }

            return View(model);
        }

    }
}
