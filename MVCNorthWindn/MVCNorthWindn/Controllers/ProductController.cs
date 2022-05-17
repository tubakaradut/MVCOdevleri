
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
    public class ProductController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public List<Product> productslist = new List<Product>();

        public ActionResult Index()
        {
            //List<Product> products = db.Products.OrderByDescending(x => x.ProductID).Take(8).ToList();
            foreach (var product in db.Products)
            { productslist.Add(product); }

            return View(productslist);
        }

        //Ürün Ekleme
        public ActionResult AddProduct()
        {
            ViewBag.Kategori = db.Categories.ToList();
            ViewBag.Tedarikci = db.Suppliers.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}