using System;

namespace Wj.Bizlogic.DependencyInjection
{
    public interface IClientScopeServiceProviderAccessor
    {
        IServiceProvider ServiceProvider { get; }
    }
}

