using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCRUD.Models; //引用要使用的Model

namespace prjCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        CompanyEntities db = new CompanyEntities();

        public ActionResult Index()
        {
            var employee = db.Employee.ToList();
            return View(employee);
        }

    }
}