using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversitySys.Validators;

namespace UniversitySys.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MinLength(10, ErrorMessage ="Name must be more than 10 characters")]
        [MaxLength(20, ErrorMessage = "Name must be Less than 20 characters")]
        [UniqueName]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Image Is Required")]
        [RegularExpression(@"\w+\.(jpeg|png)", ErrorMessage = "Image should be .jpeg or .png")]
        public string? Image { get; set; }
        public double Salary { get; set; }
        [Required(ErrorMessage="Address Is Required")]
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }

    }
}
