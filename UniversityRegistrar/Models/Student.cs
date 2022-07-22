using System;
using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Student
    {
        public Student()
        {
            this.CourseStudents = new HashSet<CourseStudent>();
        }
        public int StudentId{get; set;}
        public string Name { get; set; }
        public DateTime DateOfEnroll { get; set; }
        public int DepartmentId{get; set;}
        public virtual Department Department{get; set;}
        public virtual ICollection<CourseStudent> CourseStudents {get; set;}
    }
}