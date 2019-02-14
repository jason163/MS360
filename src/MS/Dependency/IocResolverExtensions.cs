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
    }
}
