using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
    public class DepartmentsController : Controller
    {
        public readonly UniversityRegistrarContext _db;
        public DepartmentsController(UniversityRegistrarContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Department> departments = _db.Departments.ToList();
            return View(departments);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            _db.Departments.Add(department);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var department = _db.Departments
                            .Include(depart => depart.CourseDepartments)
                            .ThenInclude(departCourse => departCourse.Course)
                            .Include(department => department.Students)
                            .FirstOrDefault(department => department.DepartmentId == id);
            return View(department);
        }

        public ActionResult Delete(int id)
        {
            var department = _db.Departments.FirstOrDefault(depart => depart.DepartmentId == id);
            _db.Departments.Remove(department);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

         public ActionResult Edit(int id)
        {
            Department department = _db.Departments.FirstOrDefault(depart => depart.DepartmentId == id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            _db.Entry(department).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}