using MVCNorthWindn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthWindn.CustomFilters
{
    public class AcFilter : FilterAttribute, IActionFilter
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log log = new Log();
            log.ActionName = filterContext.ActionDescriptor.ActionName;
            log.ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            log.LogDate = DateTime.Now;
            log.Username = "admin";
            log.Description = log.Username + " giriş başarılı bir şekilde gerçekleştirildi.";
            db.Logs.Add(log);
            db.SaveChanges();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log log = new Log();
            log.ActionName = filterContext.ActionDescriptor.ActionName;
            log.ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            log.LogDate = DateTime.Now;
            log.Username = "admin";
            log.Description = log.Username + " giriş isteğinde bulundu.";
            db.Logs.Add(log);
            db.SaveChanges();
        }
    }
}