using Wj.Bizlogic.Castle;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Autofac
{
    [DependsOn(typeof(AppCastleModule))]
    public class AppAutofacModule : AppModule
    {
    }
}

