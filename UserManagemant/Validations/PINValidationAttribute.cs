using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UserManagemant.Validations
{
    public class PINValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null) { return new ValidationResult($"{validationContext.DisplayName} cant be null"); }

            string pin = value.ToString();

            if (pin.Length != 7)
                return new ValidationResult($"{validationContext.DisplayName} length mus be 7 chars");

            if(!Regex.IsMatch(pin, "^[a-zA-Z0-9]*$"))
                return new ValidationResult($"{validationContext.DisplayName} only digits and chars allowed");

            return ValidationResult.Success;

        }
    }
}
