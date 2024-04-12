using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Caching
{
    public class DistributedCacheKeyNormalizer : IDistributedCacheKeyNormalizer, ITransientDependency
    {
        public string NormalizeKey(DistributedCacheKeyNormalizeArgs args)
        {
            throw new NotImplementedException();
        }
    }
}

