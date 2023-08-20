using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UserManagemant.Validations
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        private static readonly Regex EmailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null) { return new ValidationResult($"{validationContext.DisplayName} cant be null"); }
            string email = value as string;

            if (!EmailRegex.IsMatch(email)) { return new ValidationResult($"{validationContext.DisplayName} not valid email"); }
         
            return ValidationResult.Success;
        }
    }
}
