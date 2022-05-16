using MVCHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHelpers.Controllers
{
    public class Home3Controller : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserModel u)
        {
            ViewBag.TeaType = u.TeaTypee.ToString();
            ViewBag.HotelType = u.HotelType.ToString();
            return View();
        }
    }
}