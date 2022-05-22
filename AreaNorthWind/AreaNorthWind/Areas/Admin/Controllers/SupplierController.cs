using AreaNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaNorthWind.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            List<Supplier> suppliers = db.Suppliers.ToList();
            return View(suppliers);
        }
        //Tedarikçi Ekleme
        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplier(Supplier s)
        {
            db.Suppliers.Add(s);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}