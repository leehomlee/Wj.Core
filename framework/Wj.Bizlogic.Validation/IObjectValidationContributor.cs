namespace Wj.Bizlogic.Validation
{
    public interface IObjectValidationContributor
    {
        Task AddErrorsAsync(ObjectValidationContext context);
    }
}

