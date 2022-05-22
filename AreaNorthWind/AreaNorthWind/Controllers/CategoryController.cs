using AreaNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaNorthWind.Controllers
{
    public class CategoryController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }
    }
}