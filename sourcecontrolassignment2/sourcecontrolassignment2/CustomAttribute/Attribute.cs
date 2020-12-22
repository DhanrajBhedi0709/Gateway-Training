using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace sourcecontrolassignment2.CustomAttribute
{
    public class MinNameAttribute : ValidationAttribute
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
                    return new ValidationResult("Length of Name should be greather than 2.");
                }

            }
            return ValidationResult.Success;
        }
    }
}