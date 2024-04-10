using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public interface IAppModule
    {
        Task ConfigureServicesAsync(ServiceConfigurationContext context);

        void ConfigureServices(ServiceConfigurationContext context);
    }
}
