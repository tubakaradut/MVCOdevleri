using MVCKarısık.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCKarısık.Controllers
{
    public class KullaniciController : Controller
    {
      
        public ActionResult Index()
        {
            return View(new Kullanici());
        }
    }
}