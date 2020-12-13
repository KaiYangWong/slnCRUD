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

        //Create
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

        //Edit
        public ActionResult Edit(int Id)
        {
            var employee = db.Employee
                             .Where(m => m.EmpId == Id)
                             .FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(int Empid,string EmpName,string EmpPhone,string EmpMail)
        {
            var employee = db.Employee
                             .Where(m => m.EmpId == Empid)
                             .FirstOrDefault();
            employee.EmpName = EmpName;
            employee.EmpPhone = EmpPhone;
            employee.EmpMail = EmpMail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //Delete
        public ActionResult Delete(int EmpId)
        {
            var employee = db.Employee
                             .Where(m => m.EmpId == EmpId)
                             .FirstOrDefault();

            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}