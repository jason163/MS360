using System;
using System.Collections.Generic;
using System.Reflection;
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
        void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="config"></param>
        void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config);

        /// <summary>
        /// 用自身注册一个类型
        /// </summary>
        /// <typeparam name="T">注册类型</typeparam>
        /// <param name="lifeStyle">生命周期</param>
        void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class;

        void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        /// <summary>
        /// 用实现类注册一个类型
        /// </summary>
        /// <typeparam name="TType">注册类型</typeparam>
        /// <typeparam name="TImpl">注册类型的实现类 <see cref="TType"/></typeparam>
        /// <param name="lifeStyle">生命周期</param>
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// 判断类型是否已注册
        /// </summary>
        /// <typeparam name="T">需要判断类型</typeparam>
        bool IsRegistered(Type type);

        bool RegisterIfNot(Type type,DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        /// <summary>
        /// 判断类型是否已注册
        /// </summary>
        /// <typeparam name="T">需要判断类型</typeparam>
        bool IsRegistered<TType>();

        bool RegisterIfNot<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class;
    }
}
