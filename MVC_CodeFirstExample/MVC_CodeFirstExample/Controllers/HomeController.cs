using MVC_CodeFirstExample.Models.Context;
using MVC_CodeFirstExample.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CodeFirstExample.Controllers
{
    public class HomeController : Controller
    {
        ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public PartialViewResult _CategoryPartial()
        {
            return PartialView("_CategoryPartial", db.Categories.ToList());
        }

        public ActionResult GetProductsByCategoryId(int categoryId)
        {
            List<Product> products = db.Products.Where(x => x.CategoryId == categoryId).ToList();
            return View("Index", products);
        }

    }
}