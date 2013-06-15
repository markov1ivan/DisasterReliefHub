using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DisasterReliefHub.Domain.Models;

namespace DisasterReliefHub.Controllers
{
    public class SafePersonController : Controller
    {
        //
        // GET: /SafePerson/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IAmSafe(SafePerson model)
        {
            return View();           
        }

    }
}
