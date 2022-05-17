
using MVCNorthWindn.CustomFilters;
using MVCNorthWindn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthWindn.Controllers
{
    
    public class HomeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Login()
        {
            return View();
        }

        [AcFilter]
        [HttpPost]
        public ActionResult Login(Users user)
        {
            if (ModelState.IsValid)
            {
                bool sonuc = db.Employees.Any(x => x.UserName == user.UserName && x.Password == user.Password);

                if (sonuc)
                {
                    Employee users = db.Employees.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();

                    Session["login"] = users;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "kullanıcı bilgileri hatalı!";
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        [AuthFilter]
        [AcFilter]
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

            TempData["Orders"] = db.Orders.ToList(); //Bütün siparişler
            TempData.Keep();

            //herhangi bir listeki verilerin sadece 10 tane gelmesini istiyorsak;
            //var result7 = db.Order_Details.Take(10).ToList();

            //herhangi bir listeki verilerin (Id ye göre sıralayıp) sadece sondan 10 tanesini göremek istiyorsak;
            //var result8 = db.Order_Details.OrderByDescending(x => x.OrderID).Take(10).ToList();


            return View();
        }

        [AuthFilter]
        [AcFilter]
        public ActionResult Details(int id)
        {
            var detay = db.Order_Details.FirstOrDefault(x => x.OrderID == id);

            return View(detay);
        }


    }
}