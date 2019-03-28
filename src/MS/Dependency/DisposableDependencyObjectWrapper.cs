using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    public class DisposableDependencyObjectWrapper<T> : IDisposableDependencyObjectWrapper<T>
    {
        private readonly IIocResolver _iocResolver;

        public T Object { get; private set; }

        public DisposableDependencyObjectWrapper(IIocResolver iocResolver,T obj)
        {
            _iocResolver = iocResolver;
            Object = obj;
        }

        public void Dispose()
        {
            _iocResolver.Release(Object);
        }
    }
}
