using System.ComponentModel.DataAnnotations;

namespace Wj.Bizlogic.Validation
{
    public interface IAppValidationResult
    {
        List<ValidationResult> Errors { get; }
    }
}

