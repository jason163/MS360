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
    }
}
