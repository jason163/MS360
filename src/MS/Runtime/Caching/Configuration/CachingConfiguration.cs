using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MS.Configuration.Startup;

namespace MS.Runtime.Caching.Configuration
{
    // <summary>
    /// 用于配置缓存系统
    /// </summary>
    public class CachingConfiguration : ICachingConfiguration
    {
        /// <summary>
        /// 用于获取 MS 框架配置对象
        /// </summary>
        public IMSStartupConfiguration MSConfiguration { get; private set; }

        public IReadOnlyList<ICacheConfigurator> Configurators
        {
            get { return _configurators.ToImmutableList(); }
        }
        private readonly List<ICacheConfigurator> _configurators;

        public CachingConfiguration(IMSStartupConfiguration msConfiguration)
        {
            MSConfiguration = msConfiguration;

            _configurators = new List<ICacheConfigurator>();
        }

        public void ConfigureAll(Action<ICache> initAction)
        {
            _configurators.Add(new CacheConfigurator(initAction));
        }

        public void Configure(string cacheName, Action<ICache> initAction)
        {
            _configurators.Add(new CacheConfigurator(cacheName, initAction));
        }
    }
}