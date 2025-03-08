using System.ComponentModel.DataAnnotations.Schema;

namespace UniversitySys.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int Hours { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Instructor>? Instructor { get; set; }
        public List<CrsResult>? CrsResult { get; set; }
    }
}
