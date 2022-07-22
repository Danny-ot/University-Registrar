using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
    public class StudentsController : Controller
    {
        public readonly UniversityRegistrarContext _db;
        public StudentsController(UniversityRegistrarContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Student> model = _db.Students
                                  .Include(student => student.Department)
                                  .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_db.Departments , "DepartmentId" , "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Student student = _db.Students
            .Include(student => student.Department)
            .ThenInclude(department => department.CourseDepartments)
            .Include(student => student.CourseStudents)
            .ThenInclude(stucou => stucou.Course)
            .FirstOrDefault(stud => stud.StudentId == id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Student student = _db.Students.FirstOrDefault(student => student.StudentId == id);
            _db.Students.Remove(student);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Student student = _db.Students.FirstOrDefault(student => student.StudentId == id);
            ViewBag.DepartmentId = new SelectList(_db.Departments , "DepartmentId" , "Name");
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}