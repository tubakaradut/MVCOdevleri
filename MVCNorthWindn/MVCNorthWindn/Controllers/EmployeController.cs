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
    public class EmployeController : Controller
    {
        NORTHWNDEntities db = new NORTHWNDEntities();
        public ActionResult Index()
        {
            List<Employee> employees = db.Employees.ToList();
            return View(employees);
        }
        //Çalısan Ekleme
        public ActionResult AddEmploye()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmploye(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}