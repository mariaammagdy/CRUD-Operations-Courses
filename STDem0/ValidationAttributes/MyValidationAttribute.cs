using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace STDem0.ValidationAttributes
{
    public class MyValidationAttribute : ValidationAttribute
    {
        private readonly string _passwordPropertyName;
        public MyValidationAttribute(string passwordPropertyName)
        {
            _passwordPropertyName = passwordPropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo passwordProperty = validationContext.ObjectType.GetProperty(_passwordPropertyName);
            if (passwordProperty == null)
            {
                return new ValidationResult($"Property '{_passwordPropertyName}' not found.");
            }

            var passwordValue = passwordProperty.GetValue(validationContext.ObjectInstance) as string;
            var confirmPasswordValue = value as string;

            if (passwordValue == confirmPasswordValue)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Password and Confirm Password do not match.");
        }
    }
}