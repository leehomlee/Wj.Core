using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Wj.Bizlogic;
using Wj.Bizlogic.Threading;

namespace Microsoft.Extensions.Hosting
{
    public static class AppHostExtensions
    {
        public static async Task InitializeAsync(this IHost host)
        {
            var application = host.Services.GetRequiredService<IAppApplicationWithExternalServiceProvider>();
            var applicationLifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

            applicationLifetime.ApplicationStopping.Register(() => AsyncHelper.RunSync(() => application.ShutdownAsync()));
            applicationLifetime.ApplicationStopped.Register(() => application.Dispose());

            await application.InitializeAsync(host.Services);
        }
    }
}

