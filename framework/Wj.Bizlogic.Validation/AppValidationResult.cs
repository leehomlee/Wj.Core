using System.ComponentModel.DataAnnotations;

namespace Wj.Bizlogic.Validation
{
    public class AppValidationResult : IAppValidationResult
    {
        public List<ValidationResult> Errors { get; }

        public AppValidationResult()
        {
            Errors = new List<ValidationResult>();
        }
    }
}

