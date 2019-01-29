using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 注册上下文
    /// </summary>
    public class ConventionalRegistrationContext : IConventionalRegistrationContext
    {
        /// <summary>
        /// 程序集
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// Ioc 引用
        /// </summary>
        public IIocManager IocManager { get; private set; }

        /// <summary>
        /// 额外配置信息
        /// </summary>
        public ConventionalRegistrationConfig Config { get; private set; }

        internal ConventionalRegistrationContext(Assembly assembly, IIocManager iocManager, ConventionalRegistrationConfig config)
        {
            Assembly = assembly;
            IocManager = iocManager;
            Config = config;
        }
    }
}
