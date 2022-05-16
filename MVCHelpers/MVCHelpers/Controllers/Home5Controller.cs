using MVCHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelpers.Controllers
{
    public class Home5Controller : Controller
    {

        public ActionResult Index()
        {
            UserModel4 um = new UserModel4();
            um.UserId = 2;
            um.UserName = "Jack Martin";
            ViewBag.BasicHiddenName = "Jack Martin";
            return View(um);
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc, UserModel4 um)
        {
            ViewBag.basicname = fc["BasicHiddenName"];

            ViewBag.id = um.UserId;
            ViewBag.name = um.UserName;
            return View(um);
        }
    }
}