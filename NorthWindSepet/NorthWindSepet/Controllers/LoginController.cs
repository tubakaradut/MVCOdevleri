using NorthWindSepet.Helpers;
using NorthWindSepet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthWindSepet.Controllers
{
    public class LoginController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.Where(x => x.Username == appUserVM.Username && x.Password == appUserVM.Password).FirstOrDefault();
                if (user != null)
                {
                    Session["user"] = user;

                    Cart cart = Session["scart"] as Cart;

                    if (cart != null)
                    {
                        return RedirectToAction("CompleteCart", "Home");
                    }else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    TempData["error"] = "Kullanıcı Bilgileri Hatalı ";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult UyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeOl(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Users.Any(x => x.Email == user.Email || x.Username == user.Username))
                    {
                        TempData["error"] = "Bu email/kullanıcı zaten kayıtlı!";
                        return View(user);
                    }
                    else
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                        
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            else
            {
                return View(user);
            }
        }




    }
}