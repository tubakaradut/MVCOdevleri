using MVCMail.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCMail.Controllers
{
    public class ActivationController : Controller
    {
        ProjeContext db = new ProjeContext();
      
        public ActionResult Index()
        {

            var activationKey = Request.QueryString["activationKey"]; //linkin içindeki parametreyi almak için kullanılır.


            var result = db.Registers.FirstOrDefault(x => x.ActivationCode.ToString() == activationKey);
            if (result != null)
            {
                result.IsActive = true;
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Login");
        }
    }
}