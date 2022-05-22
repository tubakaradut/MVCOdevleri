using AreaNorthWind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaNorthWind.Areas.Admin.Controllers
{
    public class OrderDetailsController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            ViewBag.OrderDetails = db.Order_Details.ToList();

            return View();
        }
    }
}