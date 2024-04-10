namespace Wj.Bizlogic.Validation
{
    public interface IMethodInvocationValidator
    {
        Task ValidateAsync(MethodInvocationValidationContext context);
    }
}

