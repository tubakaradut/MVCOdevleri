using MVCMail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMail.Controllers
{
    public class LoginController : Controller
    {
        ProjeContext db = new ProjeContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                Register register = db.Registers.Where(x => x.Username == appUserVM.Username && x.Password == appUserVM.Password && x.IsActive).FirstOrDefault();
                if (register != null)
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    TempData["error"] = "Kullanıcı Bilgileri Hatalı veya Hesabınızı Aktive Değil!";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}