using System.ComponentModel.DataAnnotations.Schema;
using UniversitySys.Models;

namespace UniversitySys.ViewModel
{
    public class InstructorDeptCrsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double Salary { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public List<Department>? DepartmentList { get; set; }
        public List<Course>? CourseList { get; set; }
    }
}
