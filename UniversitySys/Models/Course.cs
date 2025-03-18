using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversitySys.Validators;

namespace UniversitySys.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        [MaxLength(20, ErrorMessage = "MaxLength Is 20 Chars")]
        [MinLength(3, ErrorMessage = "MinLength Is 3 Chars")]
        [Unique]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Degree Is Required")]
        [Range(50,100, ErrorMessage = "Degree Has Min Value:50 , Max Value:100")]
        public int Degree { get; set; }
        [Required(ErrorMessage = "MinDegree Is Required")]
        [Remote(action: "TestLessThanMinDegree", controller:"Course", 
            AdditionalFields = "Degree", ErrorMessage ="Minimum Degree Must Be Less than Degree" )]
        public int MinDegree { get; set; }

        [Required(ErrorMessage = "Hours Is Required")]
        [MultipleOfThree(ErrorMessage = "Hours must be a multiple of 3.")]
        public int Hours { get; set; }

        [Required(ErrorMessage = "Department Is Required")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<Instructor>? Instructor { get; set; }
        public List<CrsResult>? CrsResult { get; set; }
    }
}
