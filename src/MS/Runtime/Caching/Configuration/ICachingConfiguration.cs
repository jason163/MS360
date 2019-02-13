using MS.Configuration.Startup;
using System;
using System.Collections.Generic;

namespace MS.Runtime.Caching.Configuration
{
    /// <summary>
    /// 用于配置缓存系统
    /// </summary>
    public interface ICachingConfiguration
    {
        /// <summary>
        /// 用于获取 MS 框架配置对象
        /// </summary>
        IMSStartupConfiguration MSConfiguration { get; }

        /// <summary>
        /// 已注册的配置器
        /// </summary>
        IReadOnlyList<ICacheConfigurator> Configurators { get; }

        /// <summary>
        /// 用于配置所有缓存
        /// </summary>
        /// <param name="initAction">
        /// An action to configure caches
        /// This action is called for each cache just after created.
        /// </param>
        void ConfigureAll(Action<ICache> initAction);

        /// <summary>
        /// 用于配置指定缓存 
        /// </summary>
        /// <param name="cacheName">Cache name</param>
        /// <param name="initAction">
        /// An action to configure the cache.
        /// This action is called just after the cache is created.
        /// </param>
        void Configure(string cacheName, Action<ICache> initAction);
    }
}
