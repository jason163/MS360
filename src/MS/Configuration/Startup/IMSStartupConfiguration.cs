using MS.Dependency;
using MS.Runtime.Caching.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Configuration.Startup
{
    /// <summary>
    /// MS 和 各模块启动配置接口
    /// </summary>
    public  interface IMSStartupConfiguration : IDictionaryBasedConfig
    {
        /// <summary>
        /// Gets the IOC manager associated with this configuration.
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// Used to configure caching.
        /// </summary>
        ICachingConfiguration Caching { get; }

        /// <summary>
        /// 配置模块.
        /// 模块通过扩展方法<see cref="IModuleConfigurations"/>来提供模块配置信息
        /// </summary>
        IModuleConfigurations Modules { get; }


        /// <summary>
        /// Used to replace a service type.
        /// Given <see cref="replaceAction"/> should register an implementation for the <see cref="type"/>.
        /// </summary>
        /// <param name="type">The type to be replaced.</param>
        /// <param name="replaceAction">Replace action.</param>
        void ReplaceService(Type type, Action replaceAction);

        /// <summary>
        /// Gets a configuration object.
        /// </summary>
        T Get<T>();

        // 自定义模块配置信息
        IList<ICustomConfigProvider> CustomConfigProviders { get; }

        Dictionary<string, object> GetCustomConfig();
    }
}
