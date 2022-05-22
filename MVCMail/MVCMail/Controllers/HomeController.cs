using MVCMail.Helper;
using MVCMail.Models;
using System;
using System.Linq;
using System.Web.Mvc;


namespace MVCMail.Controllers
{
    public class HomeController : Controller
    {
        ProjeContext db = new ProjeContext();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Register register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (db.Registers.Any(x => x.Email == register.Email || x.Username == register.Username))
                    {
                        TempData["error"] = "Bu email/kullanıcı zaten kayıtlı!";
                        return View(register);
                    }
                    else
                    {
                        var activationKey = Guid.NewGuid();
                        register.ActivationCode = activationKey;

                        db.Registers.Add(register);
                        int result = db.SaveChanges();
                        if (result == 1)
                        {
                            string link = $"Hoşgeldiniz üyeliğinizi aktif hale getirebilmek için <a href=\"https://localhost:44358/Activation/Index?activationKey={activationKey}\">tıklayın</a>";
                            MailHelper.SendEmail(register.Email, "Aktivasyon Maili", link);
                        }

                        return RedirectToAction("Index","Login");
                    }
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
            else
            {
                return View(register);
            }
        }

        public ActionResult Dashboard()
        {
            return View();
        }
    }
}