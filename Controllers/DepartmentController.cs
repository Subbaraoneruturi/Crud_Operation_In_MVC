using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_Operation_In_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        Tutorials_CS _context = new Tutorials_CS();
        public ActionResult Index()
        {
            var listofData = _context.Departments.ToList();

            return View(listofData);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department model)
        {
            _context.Departments.Add(model);
            _context.SaveChanges();
            var listofData = _context.Departments.ToList();
            ViewBag.Message = "Data Insert Successfully";
            return View("Index", listofData);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Departments.Where(x => x.DeptId == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Department Model)
        {
            var data = _context.Departments.Where(x => x.DeptId == Model.DeptId).FirstOrDefault();
            if (data != null)
            {
                data.DeptCode = Model.DeptCode;
                data.DeptName = Model.DeptName;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }




    }
}