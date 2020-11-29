using System.ComponentModel.DataAnnotations;

namespace sourcecontrolassignment1.CustomAttribute
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private int _minAge;
        public MinAgeAttribute(int value)
        {
            _minAge = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is int)
                {
                    int minimumage = (int)value;
                    if (minimumage < _minAge)
                    {
                        return new ValidationResult("Minimum age must be " + _minAge);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }

    public class MinNameAttribute: ValidationAttribute
    {
        private int _minLength;

        public MinNameAttribute(int value)
        {
            _minLength = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                
                    int minimumlen = value.ToString().Length;
                    if (minimumlen < _minLength)
                    {
                        return new ValidationResult("Length of Name should be greather than 3.");
                    }
                
            }
            return ValidationResult.Success;
        }
    }
}