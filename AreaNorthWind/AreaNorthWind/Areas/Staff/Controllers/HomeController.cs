using AreaNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaNorthWind.Areas.Staff.Controllers
{
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            var result1 = db.Products.Count(); //Toplam ürün sayısı
            ViewBag.ProductCount = result1;

            var result2 = db.Employees.Count(); //Toplam Çalışan sayısı
            ViewBag.EmployeeCount = result2;

            var result3 = db.Orders.Count(); //Toplam Sipariş sayısı
            ViewBag.OrderCount = result3;

            var result4 = db.Customers.Count(); //Toplam Müşteri sayısı
            ViewBag.CustomerCount = result4;

            var result5 = db.Shippers.Count(); //Toplam Nakliyeci sayısı
            ViewBag.ShipperCount = result4;

            var result6 = db.Suppliers.Count(); //Toplam Tedarikçi sayısı
            ViewBag.SupplierCount = result4;

            ViewBag.Product = db.Products.Where(x=>x.CategoryID!=null).ToList();

            return View();
        }
    }
}