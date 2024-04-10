using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.Castle.DynamicProxy;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Castle
{
    public class BizCastleModule : AppModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient(typeof(AppAsyncDeterminationInterceptor<>));
        }
    }
}

