using System.ComponentModel.DataAnnotations;

namespace Wj.Bizlogic.Validation
{
    public interface IHasValidationErrors
    {
        IList<ValidationResult> ValidationErrors { get; }
    }
}

