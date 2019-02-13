using MS.Dependency;
using Castle.Core.Logging;
using MS.Runtime.Caching;
using MS.Runtime.Caching.Configuration;

namespace MS.Runtime.Caching.Memory
{
    /// <summary>
    /// Implements <see cref="ICacheManager"/> to work with MemoryCache.
    /// </summary>
    public class MSMemoryCacheManager : CacheManagerBase
    {
        public ILogger Logger { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MSMemoryCacheManager(IIocManager iocManager, ICachingConfiguration configuration)
            : base(iocManager, configuration)
        {
            Logger = NullLogger.Instance;
        }

        protected override ICache CreateCacheImplementation(string name)
        {
            return new MSMemoryCache(name)
            {
                Logger = Logger
            };
        }

        protected override void DisposeCaches()
        {
            foreach (var cache in Caches.Values)
            {
                cache.Dispose();
            }
        }
    }
}
