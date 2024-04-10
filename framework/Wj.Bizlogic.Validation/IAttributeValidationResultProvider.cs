using System.ComponentModel.DataAnnotations;

namespace Wj.Bizlogic.Validation
{
    public interface IAttributeValidationResultProvider
    {
        ValidationResult? GetOrDefault(ValidationAttribute validationAttribute, object? validatingObject, ValidationContext validationContext);
    }
}

