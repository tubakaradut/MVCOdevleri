
using MVCNorthWindn.CustomFilters;
using MVCNorthWindn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthWindn.Controllers
{
    [AuthFilter]
    public class CategoryController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {
            //List<Product> products = db.Products.OrderByDescending(x => x.ProductID).Take(8).ToList();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
        //Kategori Ekleme
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}