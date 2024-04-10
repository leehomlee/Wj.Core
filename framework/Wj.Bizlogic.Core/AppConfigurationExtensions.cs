using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.Configuration
{
    public static class AppConfigurationExtensions
    {
        public static IConfigurationBuilder AddAppSettingsSecretsJson(this IConfigurationBuilder builder, bool optional = true, 
            bool reloadOnChange = true, string path = HostBuilderExtensions.AppSettingsSecretJsonPath)
        {
            return builder.AddJsonFile(path: path, optional: optional, reloadOnChange: reloadOnChange);
        }
    }
}

