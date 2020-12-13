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

        //新增
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string EmpName,string EmpPhone,string EmpMail)
        {
            Employee employee = new Employee();
            employee.EmpName = EmpName;
            employee.EmpPhone = EmpPhone;
            employee.EmpMail = EmpMail;
            db.Employee.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}