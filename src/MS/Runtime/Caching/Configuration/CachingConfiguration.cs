using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MS.Configuration.Startup;

namespace MS.Runtime.Caching.Configuration
{
    // <summary>
    /// �������û���ϵͳ
    /// </summary>
    public class CachingConfiguration : ICachingConfiguration
    {
        /// <summary>
        /// ���ڻ�ȡ MS ������ö���
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