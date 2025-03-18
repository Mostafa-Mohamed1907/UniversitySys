using System.ComponentModel.DataAnnotations;
using UniversitySys.SystemContext;

namespace UniversitySys.Validators
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        UniversityContext context = new UniversityContext();
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            if (value == null)
            {
                return null;
            }
            string name = value.ToString();
            var student = context.Instructors.FirstOrDefault(i => i.Name == name);
            if(student == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Is Already Taken");

        }
    }
}
