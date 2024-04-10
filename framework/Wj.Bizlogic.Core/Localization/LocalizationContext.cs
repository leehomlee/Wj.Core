using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Localization
{
    public class LocalizationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; }

        public IStringLocalizerFactory LocalizerFactory { get; }

        public LocalizationContext(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            LocalizerFactory = ServiceProvider.GetRequiredService<IStringLocalizerFactory>();
        }
    }
}

