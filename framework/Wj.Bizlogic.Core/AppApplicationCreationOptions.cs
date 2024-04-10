using JetBrains.Annotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.Modularity.PlugIns;

namespace Wj.Bizlogic
{
    public class AppApplicationCreationOptions
    {
        [NotNull]
        public IServiceCollection Services { get; }

        [NotNull]
        public PlugInSourceList PlugInSources { get; }

        /// <summary>
        /// The options in this property only take effect when IConfiguration not registered.
        /// </summary>
        [NotNull]
        public AppConfigurationBuilderOptions Configuration { get; }

        public bool SkipConfigureServices { get; set; }

        public string? ApplicationName { get; set; }

        public string? Environment { get; set; }

        public AppApplicationCreationOptions([NotNull] IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            PlugInSources = new PlugInSourceList();
            Configuration = new AppConfigurationBuilderOptions();
        }
    }
}

