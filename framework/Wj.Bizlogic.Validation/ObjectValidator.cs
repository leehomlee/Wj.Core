﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Validation
{
    public class ObjectValidator : IObjectValidator, ITransientDependency
    {
        protected IServiceScopeFactory ServiceScopeFactory { get; }
        protected AppValidationOptions Options { get; }

        public ObjectValidator(IOptions<AppValidationOptions> options, IServiceScopeFactory serviceScopeFactory)
        {
            ServiceScopeFactory = serviceScopeFactory;
            Options = options.Value;
        }

        public virtual async Task ValidateAsync(object validatingObject, string? name = null, bool allowNull = false)
        {
            var errors = await GetErrorsAsync(validatingObject, name, allowNull);

            if (errors.Any())
            {
                throw new AppValidationException(
                    "Object state is not valid! See ValidationErrors for details.",
                    errors
                );
            }
        }

        public virtual async Task<List<ValidationResult>> GetErrorsAsync(object validatingObject, string? name = null, bool allowNull = false)
        {
            if (validatingObject == null)
            {
                if (allowNull)
                {
                    return new List<ValidationResult>(); //TODO: Returning an array would be more performent
                }
                else
                {
                    return new List<ValidationResult>
                    {
                        name == null
                            ? new ValidationResult("Given object is null!")
                            : new ValidationResult(name + " is null!", new[] {name})
                    };
                }
            }

            var context = new ObjectValidationContext(validatingObject);

            using (var scope = ServiceScopeFactory.CreateScope())
            {
                foreach (var contributorType in Options.ObjectValidationContributors)
                {
                    var contributor = (IObjectValidationContributor)
                        scope.ServiceProvider.GetRequiredService(contributorType);
                    await contributor.AddErrorsAsync(context);
                }
            }

            return context.Errors;
        }
    }
}

