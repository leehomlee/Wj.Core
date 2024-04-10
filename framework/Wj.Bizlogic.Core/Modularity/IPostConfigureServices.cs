using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public interface IPostConfigureServices
    {
        Task PostConfigureServicesAsync(ServiceConfigurationContext context);

        void PostConfigureServices(ServiceConfigurationContext context);
    }
}
