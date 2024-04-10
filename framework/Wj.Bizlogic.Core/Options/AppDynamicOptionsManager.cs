using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Wj.Bizlogic.Options
{
    public abstract class AppDynamicOptionsManager<T> : OptionsManager<T> where T : class
    {
        protected AppDynamicOptionsManager(IOptionsFactory<T> factory) : base(factory)
        {

        }

        public Task SetAsync() => SetAsync(Microsoft.Extensions.Options.Options.DefaultName);

        public virtual Task SetAsync(string name)
        {
            return OverrideOptionsAsync(name, base.Get(name));
        }

        protected abstract Task OverrideOptionsAsync(string name, T options);
    }
}

