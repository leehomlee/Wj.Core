using System.Threading.Tasks;
using Wj.Bizlogic;
using Wj.Bizlogic.Options;

namespace Microsoft.Extensions.Options
{
    public static class AppDynamicOptionsManagerExtensions
    {
        public static Task SetAsync<T>(this IOptions<T> options) where T : class
        {
            return options.ToDynamicOptions().SetAsync();
        }

        public static Task SetAsync<T>(this IOptions<T> options, string name)
            where T : class
        {
            return options.ToDynamicOptions().SetAsync(name);
        }

        private static AppDynamicOptionsManager<T> ToDynamicOptions<T>(this IOptions<T> options)
            where T : class
        {
            if (options is AppDynamicOptionsManager<T> dynamicOptionsManager)
            {
                return dynamicOptionsManager;
            }

            throw new AppException($"Options must be derived from the {typeof(AppDynamicOptionsManager<>).FullName}!");
        }
    }
}

