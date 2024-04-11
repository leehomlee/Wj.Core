using System;
using System.Collections.Generic;
using System.Text;

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

