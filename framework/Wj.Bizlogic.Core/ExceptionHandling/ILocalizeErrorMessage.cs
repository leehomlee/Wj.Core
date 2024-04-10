using Wj.Bizlogic.Localization;

namespace Wj.Bizlogic.ExceptionHandling
{
    public interface ILocalizeErrorMessage
    {
        string LocalizeMessage(LocalizationContext context);
    }
}