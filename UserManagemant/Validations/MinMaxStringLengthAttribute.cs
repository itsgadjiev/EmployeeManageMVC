using System.ComponentModel.DataAnnotations;

namespace UserManagemant.Validations
{
    public class MinMaxStringLengthAttribute : ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public MinMaxStringLengthAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult($"The field {validationContext.DisplayName} cannot be null.");
            
            string stringvalue = value.ToString();

            if (stringvalue.Length < _minLength || stringvalue.Length > _maxLength)
            {
                return new ValidationResult($"{validationContext.DisplayName} must have a length between {_minLength} and {_maxLength} .");
            }

            return ValidationResult.Success;
        }

    }
}
