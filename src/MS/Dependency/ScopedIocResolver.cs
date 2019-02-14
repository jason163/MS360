﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Dependency
{
    public class ScopedIocResolver : IScopedIocResolver
    {
        private readonly IIocResolver _iocResolver;
        private readonly List<object> _resolvedObjects;

        public ScopedIocResolver(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
            _resolvedObjects = new List<object>();
        }

        public void Dispose()
        {
            _resolvedObjects.ForEach(_iocResolver.Release);
        }

        public bool IsRegistered<T>()
        {
            return IsRegistered(typeof(T));
        }

        public bool IsRegistered(Type type)
        {
            return _iocResolver.IsRegistered(type);
        }

        public void Release(object obj)
        {
            _resolvedObjects.Remove(obj);
            _iocResolver.Release(obj);
        }

        public T Resolve<T>()
        {
            return Resolve<T>(typeof(T));
        }

        public T Resolve<T>(Type type)
        {
            return (T)Resolve(type);
        }

        public object Resolve(Type type)
        {
            return Resolve(type, null);
        }
        public object Resolve(Type type, object argumentsAsAnonymousType)
        {
            var resolvedObject = argumentsAsAnonymousType != null
                ? _iocResolver.Resolve(type, argumentsAsAnonymousType)
                : _iocResolver.Resolve(type);

            _resolvedObjects.Add(resolvedObject);
            return resolvedObject;
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            return (T)Resolve(typeof(T), argumentsAsAnonymousType);
        }

        public T[] ResolveAll<T>()
        {
            return ResolveAll(typeof(T)).OfType<T>().ToArray();
        }

        public T[] ResolveAll<T>(object argumentAsAnonymousType)
        {
            return ResolveAll(typeof(T), argumentAsAnonymousType).OfType<T>().ToArray();
        }

        public object[] ResolveAll(Type type)
        {
            return ResolveAll(type, null);
        }

        public object[] ResolveAll(Type type, object argumentAsAnonymousType)
        {
            var resolvedObjects = argumentAsAnonymousType != null
                   ? _iocResolver.ResolveAll(type, argumentAsAnonymousType)
                   : _iocResolver.ResolveAll(type);

            _resolvedObjects.AddRange(resolvedObjects);
            return resolvedObjects;
        }
    }
}
