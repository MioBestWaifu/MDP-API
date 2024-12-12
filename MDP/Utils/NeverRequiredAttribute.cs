using System.ComponentModel.DataAnnotations;

namespace MDP.Utils
{
    public class NeverRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }
}
