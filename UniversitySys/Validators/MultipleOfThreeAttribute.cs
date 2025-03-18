using System.ComponentModel.DataAnnotations;

namespace UniversitySys.Validators
{
    public class MultipleOfThreeAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int intValue)
            {
                return intValue % 3 == 0; // Ensures the value is a multiple of 3
            }
            return false; // Invalid if not an integer
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be a multiple of 3.";
        }
    }
}
