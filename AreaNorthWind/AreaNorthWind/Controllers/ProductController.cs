using AreaNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaNorthWind.Controllers
{
    public class ProductController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            ViewBag.Products = db.Products.Where(x=>x.CategoryID!=null).ToList();
            return View();
        }
    }
}