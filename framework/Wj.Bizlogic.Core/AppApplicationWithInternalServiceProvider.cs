using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Wj.Bizlogic
{
    internal class AppApplicationWithInternalServiceProvider : AppApplicationBase, IAppApplicationWithInternalServiceProvider
    {
        public IServiceScope? ServiceScope { get; private set; }

        public AppApplicationWithInternalServiceProvider(
            [NotNull] Type startupModuleType,
            Action<AppApplicationCreationOptions>? optionsAction
            ) : this(
            startupModuleType,
            new ServiceCollection(),
            optionsAction)
        {

        }

        private AppApplicationWithInternalServiceProvider(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            Action<AppApplicationCreationOptions>? optionsAction
            ) : base(
                startupModuleType,
                services,
                optionsAction)
        {
            Services.AddSingleton<IAppApplicationWithInternalServiceProvider>(this);
        }

        public IServiceProvider CreateServiceProvider()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (ServiceProvider != null)
            {
                return ServiceProvider;
            }

            ServiceScope = Services.BuildServiceProviderFromFactory().CreateScope();
            SetServiceProvider(ServiceScope.ServiceProvider);

            return ServiceProvider!;
        }

        public async Task InitializeAsync()
        {
            CreateServiceProvider();
            await InitializeModulesAsync();
        }

        public void Initialize()
        {
            CreateServiceProvider();
            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();
            ServiceScope?.Dispose();
        }
    }
}

