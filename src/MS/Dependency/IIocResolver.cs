using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    // <summary>
    /// 定义接口用于解析依赖项的类。
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 获取对象实例从IOC container.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>对象实例</returns>
        T Resolve<T>();

        /// <summary>
        /// 获取对象实例从IOC container.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">被转换的对象类型</typeparam>
        /// <param name="type">被解析的对象类型</param>
        /// <returns>对象实例</returns>
        T Resolve<T>(Type type);

        object Resolve(Type type);

        /// <summary>
        /// 获取对象实例从IOC container.
        /// Returning object must be Released (see <see cref="Release"/>) after usage.
        /// </summary> 
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="argumentsAsAnonymousType">构造函数参数</param>
        /// <returns>对象实例</returns>
        T Resolve<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// 释放上一次解析对象
        /// </summary>
        /// <param name="obj">需要被释放的对象</param>
        void Release(object obj);

        /// <summary>
        /// 判断类型是否已注册
        /// </summary>
        /// <typeparam name="T">需要判断类型</typeparam>
        bool IsRegistered<T>();

        /// <summary>
        /// 判断类型是否已注册
        /// </summary>
        /// <typeparam name="T">需要判断类型</typeparam>
        bool IsRegistered(Type type);
    }
}
