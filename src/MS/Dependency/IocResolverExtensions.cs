using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 接口扩展方法 <see cref="IIocResolver"/>.
    /// </summary>
    public static class IocResolverExtensions
    {
        /// <summary>
        /// 获取一个 <see cref="ScopedIocResolver"/> 对象
        /// </summary>
        /// <param name="iocResolver"></param>
        /// <returns>被 <see cref="ScopedIocResolver"/>包装的实例</returns>
        public static IScopedIocResolver CreateScope(this IIocResolver iocResolver)
        {
            return new ScopedIocResolver(iocResolver);
        }

        /// <summary>
        /// 返回 <see cref="DisposableDependencyObjectWrapper{T}"/> 对象
        /// </summary> 
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="iocResolver">IIocResolver object</param>
        /// <param name="type">Type of the object to resolve. This type must be convertible <typeparamref name="T"/>.</param>
        /// <returns>对象实例用 <see cref="DisposableDependencyObjectWrapper{T}"/>包装</returns>
        public static IDisposableDependencyObjectWrapper<T> ResolveAsDisposable<T>(this IIocResolver iocResolver, Type type)
        {
            return new DisposableDependencyObjectWrapper<T>(iocResolver, (T)iocResolver.Resolve(type));
        }
    }
}
