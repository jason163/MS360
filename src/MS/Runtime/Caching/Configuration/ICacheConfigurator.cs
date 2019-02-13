using System;

namespace MS.Runtime.Caching.Configuration
{
    /// <summary>
    /// 已注册的缓存配置器
    /// </summary>
    public interface ICacheConfigurator
    {
        /// <summary>
        /// Name of the cache.
        /// It will be null if this configurator configures all caches.
        /// </summary>
        string CacheName { get; }

        /// <summary>
        /// Configuration action. 缓存被创建后调用
        /// </summary>
        Action<ICache> InitAction { get; }
    }
}