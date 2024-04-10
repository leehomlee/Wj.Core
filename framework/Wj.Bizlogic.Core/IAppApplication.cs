using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic
{
    public interface IAppApplication : IModuleContainer, IApplicationInfoAccessor, IDisposable
    {
        /// <summary>
        /// Type of the startup (entrance) module of the application.
        /// </summary>
        Type StartupModuleType { get; }

        /// <summary>
        /// List of all service registrations.
        /// Can not add new services to this collection after application initialize.
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Reference to the root service provider used by the application.
        /// This can not be used before initializing  the application.
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Calls the Pre/Post/ConfigureServicesAsync methods of the modules.
        /// If you use this method, you must have set the
        /// option to true before.
        /// </summary>
        Task ConfigureServicesAsync();

        /// <summary>
        /// Used to gracefully shutdown the application and all modules.
        /// </summary>
        Task ShutdownAsync();

        /// <summary>
        /// Used to gracefully shutdown the application and all modules.
        /// </summary>
        void Shutdown();
    }
}
