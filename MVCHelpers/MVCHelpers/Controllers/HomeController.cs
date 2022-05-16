using MVCHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelpers.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserModel u)
        {
            ViewBag.Tea = u.Tea;
            ViewBag.Loundry = u.Loundry;
            ViewBag.Breakfast = u.Breakfast;
            return View();
        }

       
    }
}