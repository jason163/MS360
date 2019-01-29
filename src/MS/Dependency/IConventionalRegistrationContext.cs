using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 协议注册上下文
    /// </summary>
    public interface IConventionalRegistrationContext
    {
        /// <summary>
        /// 注册的程序集
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// 对Ioc 容器的引用
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// 配置信息
        /// </summary>
        ConventionalRegistrationConfig Config { get; }
    }
}
