using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Uow
{
    public class AppUnitOfWorkModule : AppModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.OnRegistered(UnitOfWorkInterceptorRegistrar.RegisterIfNeeded);
        }
    }
}

