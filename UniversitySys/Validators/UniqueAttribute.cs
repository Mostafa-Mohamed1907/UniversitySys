using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using UniversitySys.Models;
using UniversitySys.SystemContext;

namespace UniversitySys.Validators
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string name = value.ToString();
            UniversityContext context = new UniversityContext();
            Course course = context.Courses.FirstOrDefault(i => i.Name == name);
            if (course == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name is duplicated, Insert a valid name");
        }
    }
}
