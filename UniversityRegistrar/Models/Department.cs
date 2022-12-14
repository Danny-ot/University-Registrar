using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
    public class Department
    {
        public Department()
        {
            this.CourseDepartments = new HashSet<CourseDepartment>();
            this.Students = new HashSet<Student>();
        }
        public int DepartmentId{get; set;}
        public string Name{get; set;}

        public virtual ICollection<CourseDepartment> CourseDepartments{get; set;}
        public virtual ICollection<Student> Students{get; set;}
    }
}