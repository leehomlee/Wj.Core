using System.ComponentModel.DataAnnotations;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Validation
{
    public class DefaultAttributeValidationResultProvider : IAttributeValidationResultProvider, ITransientDependency
    {
        public virtual ValidationResult? GetOrDefault(ValidationAttribute validationAttribute, object? validatingObject, ValidationContext validationContext)
        {
            return validationAttribute.GetValidationResult(validatingObject, validationContext);
        }
    }
}

