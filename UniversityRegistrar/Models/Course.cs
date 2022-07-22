using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Course
    {
        public Course()
        {
            this.CourseStudents = new HashSet<CourseStudent>();
            this.CourseDepartments = new HashSet<CourseDepartment>();
        }
        public int CourseId {get; set;}
        public string Name {get; set;}
        public string CourseNo {get; set;}
        public virtual ICollection<CourseStudent> CourseStudents{get; set;}
        public virtual ICollection<CourseDepartment> CourseDepartments{get; set;}
    }
}