using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using Wj.Bizlogic.Modularity.PlugIns;

namespace Wj.Bizlogic.Modularity
{
    public interface IModuleLoader
    {
        [NotNull]
        IAppModuleDescriptor[] LoadModules([NotNull] IServiceCollection services, [NotNull] Type startupModuleType, 
            [NotNull] PlugInSourceList plugInSources);
    }
}

