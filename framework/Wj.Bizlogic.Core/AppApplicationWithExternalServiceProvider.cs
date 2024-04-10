using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Wj.Bizlogic
{
    internal class AppApplicationWithExternalServiceProvider : AppApplicationBase, IAppApplicationWithExternalServiceProvider
    {
        public AppApplicationWithExternalServiceProvider([NotNull] Type startupModuleType, [NotNull] IServiceCollection services, 
            Action<AppApplicationCreationOptions>? optionsAction
        ) : base(
            startupModuleType,
            services,
            optionsAction)
        {
            services.AddSingleton<IAppApplicationWithExternalServiceProvider>(this);
        }

        void IAppApplicationWithExternalServiceProvider.SetServiceProvider([NotNull] IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (ServiceProvider != null)
            {
                if (ServiceProvider != serviceProvider)
                {
                    throw new AppException("Service provider was already set before to another service provider instance.");
                }

                return;
            }

            SetServiceProvider(serviceProvider);
        }

        public async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            SetServiceProvider(serviceProvider);

            await InitializeModulesAsync();
        }

        public void Initialize([NotNull] IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            SetServiceProvider(serviceProvider);

            InitializeModules();
        }

        public override void Dispose()
        {
            base.Dispose();

            if (ServiceProvider is IDisposable disposableServiceProvider)
            {
                disposableServiceProvider.Dispose();
            }
        }
    }
}

