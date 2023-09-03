using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goodsmart_Domain.Validation
{
    public class ExpiryDateValidation : ValidationAttribute
    {
        private readonly string _productionDate;

        public ExpiryDateValidation(string otherProperty)
        {
            _productionDate = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_productionDate);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {_productionDate}");
            }

            var otherPropertyValue = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance);

            var thisPropertyValue = (DateTime)value;

            if (thisPropertyValue <= otherPropertyValue)
            {
                return new ValidationResult($"{validationContext.DisplayName} must be greater than {_productionDate}");
            }

            return ValidationResult.Success;
        }
    }
}
