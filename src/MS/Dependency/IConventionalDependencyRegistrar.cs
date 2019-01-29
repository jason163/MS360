using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 协议注册器接口
    /// </summary>
    public interface IConventionalDependencyRegistrar
    {
        /// <summary>
        /// 通过约定注册给定程序集的类型。
        /// </summary>
        /// <param name="context">注册上下文</param>
        void RegisterAssembly(IConventionalRegistrationContext context);

    }
}
