using AreaNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaNorthWind.Areas.Staff.Controllers
{
    public class CustomerController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {
            List<Customer> customers = db.Customers.ToList();
            return View(customers);
        }

        //Müşteri Ekleme
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}