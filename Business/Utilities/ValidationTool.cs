using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities
{
    public static class ValidationTool
    {
        public static ValidationResult Validate(IValidator validator, object entity)
        {
            var result = validator.Validate((IValidationContext)entity);
            return result;
        }
    }
}
