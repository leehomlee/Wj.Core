using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Threading
{
    public class AppThreadingModule : AppModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<ICancellationTokenProvider>(NullCancellationTokenProvider.Instance);
            context.Services.AddSingleton(typeof(IAmbientScopeProvider<>), typeof(AmbientDataContextAmbientScopeProvider<>));
        }
    }
}

