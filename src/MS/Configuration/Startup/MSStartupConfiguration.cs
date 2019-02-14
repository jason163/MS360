using System;
using System.Collections.Generic;
using System.Text;
using MS.Dependency;
using MS.Runtime.Caching.Configuration;

namespace MS.Configuration.Startup
{
    /// <summary>
    /// MS 和 模块启动配置类
    /// </summary>
    public class MSStartupConfiguration : DictionaryBasedConfig , IMSStartupConfiguration
    {
        public IIocManager IocManager { get; }

        public ICachingConfiguration Caching { get; private set; }

        public Dictionary<Type, Action> ServiceReplaceActions { get; private set; }

        public IList<ICustomConfigProvider> CustomConfigProviders { get; private set; }

        public IModuleConfigurations Modules { get; private set; }

        public MSStartupConfiguration(IIocManager iocManager)
        {
            IocManager = iocManager;
        }

        /// <summary>
        /// 配置类初始化,当启动时会被 <see cref="MSBootStrapper"/> 调用
        /// </summary>
        public void Initialize()
        {
            Caching = IocManager.Resolve<ICachingConfiguration>();
            Modules = IocManager.Resolve<IModuleConfigurations>();

            CustomConfigProviders = new List<ICustomConfigProvider>();
            ServiceReplaceActions = new Dictionary<Type, Action>();
        }

        public void ReplaceService(Type type, Action replaceAction)
        {
            ServiceReplaceActions[type] = replaceAction;
        }

        public T Get<T>()
        {
            return GetOrCreate(typeof(T).FullName, () => IocManager.Resolve<T>());
        }

        /// <summary>
        /// 获取自定义模块配置信息
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetCustomConfig()
        {
            var mergedConfig = new Dictionary<string, object>();

            using (var scope = IocManager.CreateScope())
            {
                foreach (var provider in CustomConfigProviders)
                {
                    var config = provider.GetConfig(new CustomConfigProviderContext(scope));
                    foreach (var keyValue in config)
                    {
                        mergedConfig[keyValue.Key] = keyValue.Value;
                    }
                }
            }

            return mergedConfig;
        }
    }
}
