using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisasterReliefHub.Controllers
{
    public class DisasterController : Controller
    {
        public ActionResult Index(int disasterId = 0)
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

    }
}
