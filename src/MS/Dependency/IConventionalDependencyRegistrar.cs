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

        /// <summary>
        /// 通过所有常规注册器注册给定程序集的类型. 
        /// </summary>
        /// <param name="assembly">需要注册的程序集</param>
        void RegisterAssemblyByConvention(Assembly assembly);

        /// <summary>
        /// 将类型注册为自注册
        /// </summary>
        /// <typeparam name="T">注册类型</typeparam>
        /// <param name="lifeStyle">生命周期类型</param>
        void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class;

        /// <summary>
        /// 用实现类注册一个类型
        /// </summary>
        /// <typeparam name="TType">注册类</typeparam>
        /// <typeparam name="TImpl">实现类<see cref="TType"/></typeparam>
        /// <param name="lifeStyle">生命周期</param>
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// 判断类型是否注册
        /// </summary>
        /// <typeparam name="TType">需要判断的类型</typeparam>
        bool IsRegistered<TType>();
    }
}
