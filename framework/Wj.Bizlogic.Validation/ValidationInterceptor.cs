using Wj.Bizlogic.DependencyInjection;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.Validation
{
    public class ValidationInterceptor : AppInterceptor, ITransientDependency
    {
        private readonly IMethodInvocationValidator _methodInvocationValidator;

        public ValidationInterceptor(IMethodInvocationValidator methodInvocationValidator)
        {
            _methodInvocationValidator = methodInvocationValidator;
        }

        public override async Task InterceptAsync(IAppMethodInvocation invocation)
        {
            await ValidateAsync(invocation);
            await invocation.ProceedAsync();
        }

        protected virtual async Task ValidateAsync(IAppMethodInvocation invocation)
        {
            await _methodInvocationValidator.ValidateAsync(
                new MethodInvocationValidationContext(
                    invocation.TargetObject,
                    invocation.Method,
                    invocation.Arguments
                )
            );
        }
    }
}

