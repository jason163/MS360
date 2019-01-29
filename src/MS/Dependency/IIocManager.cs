using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 依赖管理接口.
    /// </summary>
    public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
    {
        /// <summary>
        /// 引用Castle Windsor Container.
        /// </summary>
        IWindsorContainer IocContainer { get; }

        /// <summary>
        /// 判断给定的类型是否已注册
        /// </summary>
        /// <param name="type">判断类型</param>
        new bool IsRegistered<T>();

        /// <summary>
        /// 判断给定的类型是否已注册
        /// </summary>
        /// <param name="type">判断类型</param>
        new bool IsRegistered(Type type);

    }
}
