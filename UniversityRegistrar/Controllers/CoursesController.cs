using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
    public class CoursesController : Controller
    {
        public readonly UniversityRegistrarContext _db;

        public CoursesController(UniversityRegistrarContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Course> model = _db.Courses.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_db.Departments , "DepartmentId" , "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course , int DepartmentId)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            if(DepartmentId != 0)
            {
                _db.CourseDepartments.Add(new CourseDepartment{DepartmentId = DepartmentId , CourseId =  course.CourseId});
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var course = _db.Courses
                        .Include(course => course.CourseDepartments)
                        .ThenInclude(coursedepart => coursedepart.Department)
                        .Include(course => course.CourseStudents)
                        .ThenInclude(stucourse => stucourse.Student)
                        .FirstOrDefault(course => course.CourseId == id);
            return View(course);
        }

        public ActionResult AddStudent(int id)
        {
            var course = _db.Courses.FirstOrDefault(course => course.CourseId == id);
            ViewBag.StudentId = new SelectList(_db.Students , "StudentId" , "Name");
            return View(course); 
        }

        [HttpPost] 
        public ActionResult AddStudent(Course course , int StudentId)
        {
            if(StudentId != 0)
            {
                _db.CourseStudents.Add(new CourseStudent {CourseId = course.CourseId , StudentId = StudentId});
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var course = _db.Courses.FirstOrDefault(course => course.CourseId == id);
            _db.Courses.Remove(course);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteStudent(int courseStudentId)
        {
            var courseStudent = _db.CourseStudents.FirstOrDefault(courseStu => courseStu.CourseStudentId == courseStudentId);
            _db.CourseStudents.Remove(courseStudent);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Course course = _db.Courses.FirstOrDefault(cours => cours.CourseId == id);
            ViewBag.DepartmentId = new SelectList(_db.Departments , "DepartmentId" , "Name");
            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(Course course , int DepartmentId)
        {
            if(DepartmentId != 0 )
            {
                _db.CourseDepartments.Add(new CourseDepartment {CourseId = course.CourseId , DepartmentId = DepartmentId});
            }
            _db.Entry(course).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}