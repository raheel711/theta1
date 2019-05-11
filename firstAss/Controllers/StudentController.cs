using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using firstAss.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstAss.Controllers
{
    public class StudentController : Controller
    {

        private thetaContext ORM = null;
        public StudentController(thetaContext _ORM) {
            ORM = _ORM;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddNewStudent() {

            return View();
        }

        [HttpPost]
        public IActionResult AddNewStudent(Student s) {
            try {
                ORM.Add(s);
                ORM.SaveChanges();
                ViewBag.Message("Added!!!!!");
            }
            catch (Exception ex) { ViewBag.Message("Not Added"); }

            return RedirectToAction(nameof(StudentController.ViewAllStudents));
        }

        [HttpGet]
        public IActionResult ViewAllStudents() {

            return View(ORM.Student.ToList());
        }


        [HttpGet]
        public IActionResult ViewDetail(int Sid) {
            
            
            return View(ORM.Student.Find(Sid));
        }

        [HttpGet]
        public IActionResult DeleteStudent(int Did) {

            Student s= ORM.Student.Find(Did);
            if (s != null)
            {
                ORM.Student.Remove(s);
                ORM.SaveChanges();
            }
            else {
                ViewBag.Message("USer not Exists");
            }

            return RedirectToAction("ViewAllStudents");
        }

        [HttpGet]
        public IActionResult EditDetail(int Eid) {

            return View();
        }


        [HttpPost]
        public IActionResult EditDetail(Student s)
        {
            ORM.Student.Update(s);
            ORM.SaveChanges();
            return View();
        }

    }
}