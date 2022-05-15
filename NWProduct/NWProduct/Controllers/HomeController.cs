using NWProduct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace NWProduct.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {
            List<Product> products = db.Products.OrderByDescending(x => x.ProductID).Take(8).ToList();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var detay = db.Products.FirstOrDefault(x => x.ProductID == id);
            return View(detay);
        }

    }
}