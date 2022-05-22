using AreaNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaNorthWind.Areas.Staff.Controllers
{
    public class OrderController : Controller
    {
        // GET: Staff/Order
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {
            List<Order> orders = db.Orders.ToList();
            return View(orders);
        }
        public ActionResult AddOrder()
        {
            ViewBag.Customer = db.Customers.ToList();
            ViewBag.Employe = db.Employees.ToList();
            ViewBag.Shipper = db.Shippers.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(Order o)
        {
            db.Orders.Add(o);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}