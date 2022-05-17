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