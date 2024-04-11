namespace Wj.Bizlogic.Caching
{
    public interface IDistributedCacheKeyNormalizer
    {
        string NormalizeKey(DistributedCacheKeyNormalizeArgs args);
    }
}

