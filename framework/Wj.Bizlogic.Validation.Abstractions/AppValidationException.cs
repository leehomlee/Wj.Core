using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Wj.Bizlogic.Logging;

namespace Wj.Bizlogic.Validation
{
    [Serializable]
    public class AppValidationException : AppException, IHasLogLevel, IHasValidationErrors, IExceptionWithSelfLogging
    {
        /// <summary>
        /// Detailed list of validation errors for this exception.
        /// </summary>
        public IList<ValidationResult> ValidationErrors { get; }

        /// <summary>
        /// Exception severity.
        /// Default: Warn.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AppValidationException()
        {
            ValidationErrors = new List<ValidationResult>();
            LogLevel = LogLevel.Warning;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="validationErrors">Validation errors</param>
        public AppValidationException(IList<ValidationResult> validationErrors)
        {
            ValidationErrors = validationErrors;
            LogLevel = LogLevel.Warning;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AppValidationException(string message) : base(message)
        {
            ValidationErrors = new List<ValidationResult>();
            LogLevel = LogLevel.Warning;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="validationErrors">Validation errors</param>
        public AppValidationException(string message, IList<ValidationResult> validationErrors) : base(message)
        {
            ValidationErrors = validationErrors;
            LogLevel = LogLevel.Warning;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AppValidationException(string message, Exception innerException) : base(message, innerException)
        {
            ValidationErrors = new List<ValidationResult>();
            LogLevel = LogLevel.Warning;
        }

        /// <summary>
        /// Constructor for serializing.
        /// </summary>
        public AppValidationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {
            ValidationErrors = new List<ValidationResult>();
            LogLevel = LogLevel.Warning;
        }

        public void Log(ILogger logger)
        {
            if (ValidationErrors.IsNullOrEmpty())
            {
                return;
            }
            var validationErrors = new StringBuilder();
            validationErrors.AppendLine("There are " + ValidationErrors.Count + " validation errors:");
            foreach (var validationResult in ValidationErrors)
            {
                var memberNames = "";
                if (validationResult.MemberNames != null && validationResult.MemberNames.Any())
                {
                    memberNames = " (" + string.Join(", ", validationResult.MemberNames) + ")";
                }

                validationErrors.AppendLine(validationResult.ErrorMessage + memberNames);
            }

            logger.LogWithLevel(LogLevel, validationErrors.ToString());
        }
    }
}

