using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    public interface IDisposableDependencyObjectWrapper<T> : IDisposable
    {
        /// <summary>
        /// 需要被释放的对象
        /// </summary>
        T Object { get; }
    }
}
