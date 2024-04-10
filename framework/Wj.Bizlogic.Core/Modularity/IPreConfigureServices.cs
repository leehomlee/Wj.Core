using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public interface IPreConfigureServices
    {
        Task PreConfigureServicesAsync(ServiceConfigurationContext context);

        void PreConfigureServices(ServiceConfigurationContext context);
    }
}
