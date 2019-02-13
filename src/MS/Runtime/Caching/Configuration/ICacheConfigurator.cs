using System;

namespace MS.Runtime.Caching.Configuration
{
    /// <summary>
    /// ��ע��Ļ���������
    /// </summary>
    public interface ICacheConfigurator
    {
        /// <summary>
        /// Name of the cache.
        /// It will be null if this configurator configures all caches.
        /// </summary>
        string CacheName { get; }

        /// <summary>
        /// Configuration action. ���汻���������
        /// </summary>
        Action<ICache> InitAction { get; }
    }
}