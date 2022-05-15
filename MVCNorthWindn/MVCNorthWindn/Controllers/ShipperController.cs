using MVCNorthWindn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthWindn.Controllers
{
    public class ShipperController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            List<Shipper> shippers = db.Shippers.ToList();
            return View(shippers);
        }
        public ActionResult AddShipper()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddShipper(Shipper shipper)
        {
            db.Shippers.Add(shipper);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}