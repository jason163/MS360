using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 为那些用于注册依赖项的类定义接口
    /// </summary>
    public interface IIocRegistrar
    {
        /// <summary>
        /// 为常规(协议)注册增加依赖注册器
        /// </summary>
        void AddConventionalRegistrar();

        /// <summary>
        /// 判断类型是否已注册
        /// </summary>
        /// <typeparam name="T">需要判断类型</typeparam>
        bool IsRegistered(Type type);

        /// <summary>
        /// 判断类型是否已注册
        /// </summary>
        /// <typeparam name="T">需要判断类型</typeparam>
        bool IsRegistered<TType>();
    }
}
