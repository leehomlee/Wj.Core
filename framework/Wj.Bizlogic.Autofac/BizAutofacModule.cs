using Wj.Bizlogic.Castle;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Autofac
{
    [DependsOn(typeof(BizCastleModule))]
    public class BizAutofacModule : AppModule
    {
    }
}

