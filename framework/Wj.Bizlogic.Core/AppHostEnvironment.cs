using Microsoft.Extensions.Hosting;
using System;

namespace Wj.Bizlogic
{
    public class AppHostEnvironment : IAppHostEnvironment
    {
        public string? EnvironmentName { get; set; }
    }
    public static class AppHostEnvironmentExtensions
    {
        public static bool IsDevelopment(this IAppHostEnvironment hostEnvironment)
        {
            Check.NotNull(hostEnvironment, nameof(hostEnvironment));

            return hostEnvironment.IsEnvironment(Environments.Development);
        }

        public static bool IsStaging(this IAppHostEnvironment hostEnvironment)
        {
            Check.NotNull(hostEnvironment, nameof(hostEnvironment));

            return hostEnvironment.IsEnvironment(Environments.Staging);
        }

        public static bool IsProduction(this IAppHostEnvironment hostEnvironment)
        {
            Check.NotNull(hostEnvironment, nameof(hostEnvironment));

            return hostEnvironment.IsEnvironment(Environments.Production);
        }

        public static bool IsEnvironment(this IAppHostEnvironment hostEnvironment, string environmentName)
        {
            Check.NotNull(hostEnvironment, nameof(hostEnvironment));

            return string.Equals(
                hostEnvironment.EnvironmentName,
                environmentName,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}

