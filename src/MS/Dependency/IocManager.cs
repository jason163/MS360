using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Castle.Windsor.Proxy;

namespace MS.Dependency
{
    /// <summary>
    /// 依赖管理类
    /// </summary>
    public class IocManager : IIocManager
    {
        /// <summary>
        /// 单例实例
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        /// Singletone instance for Castle ProxyGenerator.
        /// From Castle.Core documentation it is highly recomended to use single instance of ProxyGenerator to avoid memoryleaks and performance issues
        /// Follow next links for more details:
        /// <a href="https://github.com/castleproject/Core/blob/master/docs/dynamicproxy.md">Castle.Core documentation</a>,
        /// <a href="http://kozmic.net/2009/07/05/castle-dynamic-proxy-tutorial-part-xii-caching/">Article</a>
        /// </summary>
        private static readonly ProxyGenerator ProxyGeneratorInstance = new ProxyGenerator();

        /// <summary>
        ///  Castle Windsor Container 引用
        /// </summary>
        public IWindsorContainer IocContainer { get; private set; }

        /// <summary>
        /// 所有协议注册器列表
        /// </summary>
        private readonly List<IConventionalDependencyRegistrar> _conventionalRegistrars;

        static IocManager()
        {
            Instance = new IocManager();
        }
        public IocManager()
        {
            IocContainer = CreateContainer();
            _conventionalRegistrars = new List<IConventionalDependencyRegistrar>();

            //Register self!
            IocContainer.Register(
                Component
                    .For<IocManager, IIocManager, IIocRegistrar, IIocResolver>()
                    .Instance(this)
            );
        }

        protected virtual IWindsorContainer CreateContainer()
        {
            return new WindsorContainer(new DefaultProxyFactory(ProxyGeneratorInstance));
        }

        /// <summary>
        /// 增加协议注册器
        /// </summary>
        /// <param name="registrar"></param>
        public void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar)
        {
            _conventionalRegistrars.Add(registrar);
        }

        /// <summary>
        /// 通过协议注册器注册给定程序集的类型. See <see cref="AddConventionalRegistrar"/> method.
        /// </summary>
        /// <param name="assembly">注册程序集</param>
        public void RegisterAssemblyByConvention(Assembly assembly)
        {
            RegisterAssemblyByConvention(assembly, new ConventionalRegistrationConfig());
        }

        /// <summary>
        /// 通过协议注册器注册给定程序集的类型. See <see cref="AddConventionalRegistrar"/> method.
        /// </summary>
        /// <param name="assembly">注册程序集</param>
        /// <param name="config">其他配置信息</param>
        public void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config)
        {
            var context = new ConventionalRegistrationContext(assembly, this, config);

            foreach (var registerer in _conventionalRegistrars)
            {
                registerer.RegisterAssembly(context);
            }

            if (config.InstallInstallers)
            {
                IocContainer.Install(FromAssembly.Instance(assembly));
            }
        }

        /// <summary>
        /// 用自身注册一个类型
        /// </summary>
        /// <typeparam name="T">注册类型</typeparam>
        /// <param name="lifeStyle">生命周期</param>
        public void Register<TType>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton) where TType : class
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType>(), lifeStyle));
        }

        public void Register(Type type,DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            IocContainer.Register(ApplyLifestyle(Component.For(type), lifeStyle));
        }

        /// <summary>
        /// 用实现类注册一个类型
        /// </summary>
        /// <typeparam name="TType">注册类型</typeparam>
        /// <typeparam name="TImpl">注册类型的实现类 <see cref="TType"/></typeparam>
        /// <param name="lifeStyle">生命周期</param>
        public void Register<TType, TImpl>(DependencyLifeStyle lifeStyle)
            where TType : class
            where TImpl : class, TType
        {
            IocContainer.Register(ApplyLifestyle(Component.For<TType, TImpl>().ImplementedBy<TImpl>(), lifeStyle));
        }

        

        /// <summary>
        /// 判断给定的类型是否已经注册过
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool IsRegistered<T>()
        {
            return IocContainer.Kernel.HasComponent(typeof(T));
        }

        public bool IsRegistered(Type type)
        {
            return IocContainer.Kernel.HasComponent(type);
        }

        public bool RegisterIfNot(Type type,DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
        {
            if (this.IsRegistered(type))
            {
                return false;
            }
            this.Register(type,lifeStyle);
            return true;
        }

        public bool RegisterIfNot<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T:class
        {
            if (this.IsRegistered<T>())
            {
                return false;
            }

            this.Register<T>(lifeStyle);
            return true;
        }

        public T Resolve<T>()
        {
            return IocContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return IocContainer.Resolve(type);
        }

        public T Resolve<T>(Type type)
        {
            return (T)IocContainer.Resolve(type);
        }

        public T Resolve<T>(object argumentsAsAnonymousType)
        {
            return IocContainer.Resolve<T>(argumentsAsAnonymousType);
        }

        public void Release(object obj)
        {
            IocContainer.Release(obj);
        }

        /// <summary>
        /// 继承
        /// </summary>
        public void Dispose()
        {
            IocContainer.Dispose();
        }

        /// <summary>
        /// 构造组件注册
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <param name="registration">组件注册</param>
        /// <param name="lifeStyle">生命周期</param>
        /// <returns></returns>
        private static ComponentRegistration<T> ApplyLifestyle<T>(ComponentRegistration<T> registration, DependencyLifeStyle lifeStyle)
            where T : class
        {
            switch (lifeStyle)
            {
                case DependencyLifeStyle.Transient:
                    return registration.LifestyleTransient();
                case DependencyLifeStyle.Singleton:
                    return registration.LifestyleSingleton();
                default:
                    return registration;
            }
        }

    }
}
