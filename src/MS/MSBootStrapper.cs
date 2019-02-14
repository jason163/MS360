using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using JetBrains.Annotations;
using MS.Configuration.Startup;
using MS.Dependency;
using MS.Dependency.Installers;
using MS.Module;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS
{
    /// <summary>
    /// MS 启动类
    /// </summary>
    public class MSBootStrapper : IDisposable
    {
        /// <summary>
        /// 启动模块类
        /// </summary>
        public Type StartupModule { get; }

        /// <summary>
        /// Ioc容器管理
        /// </summary>
        public IIocManager IocManager { get; }

        /// <summary>
        /// Is this object disposed before?
        /// </summary>
        protected bool IsDisposed;

        /// <summary>
        /// 模块管理类
        /// </summary>
        private MSModuleManager _moduleManager;
        /// <summary>
        /// 日志接口
        /// </summary>
        private ILogger _logger;

        private MSBootStrapper([NotNull] Type startupModule, [CanBeNull] Action<MSBootstrapperOptions> optionsAction = null)
        {
            var options = new MSBootstrapperOptions();
            optionsAction?.Invoke(options);

            if (!typeof(MSModule).GetTypeInfo().IsAssignableFrom(startupModule))
            {
                throw new ArgumentException($"{nameof(startupModule)} should be derived from {nameof(MSModule)}.");
            }

            StartupModule = startupModule;

            IocManager = options.IocManager;

            _logger = NullLogger.Instance;

            if (!options.DisableAllInterceptors)
            {
                AddInterceptorRegistrars();
            }
        }

        public static MSBootStrapper Create<TStartupModule>([CanBeNull] Action<MSBootstrapperOptions> optionsAction = null)
            where TStartupModule : MSModule
        {
            return new MSBootStrapper(typeof(TStartupModule), optionsAction);
        }

        public static MSBootStrapper Create([NotNull] Type startupModule, [CanBeNull] Action<MSBootstrapperOptions> optionsAction = null)
        {
            return new MSBootStrapper(startupModule, optionsAction);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Initialize()
        {
            ResolveLogger();

            try
            {
                // 注册启动类自身
                RegisterBootstrapper();

                // 注册MS 相关系统框架级基础依赖
                IocManager.IocContainer.Install(new MSCoreInstaller());
                //IocManager.Resolve<AbpPlugInManager>().PlugInSources.AddRange(PlugInSources);

                // 初始化配置,该方法最终调用容器生成他的小伙伴的各种实例（****Configuration）
                IocManager.Resolve<MSStartupConfiguration>().Initialize();

                _moduleManager = IocManager.Resolve<MSModuleManager>();
                _moduleManager.Initialize(StartupModule);

                _moduleManager.StartModules();
            }
            catch (System.Exception ex)
            {
                _logger.Fatal(ex.ToString(), ex);
                throw;
            }
        }

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            _moduleManager?.ShutdownModules();
        }

        /// <summary>
        /// 增加拦截器
        /// </summary>
        private void AddInterceptorRegistrars()
        {
            //ValidationInterceptorRegistrar.Initialize(IocManager);
            //AuditingInterceptorRegistrar.Initialize(IocManager);
            //EntityHistoryInterceptorRegistrar.Initialize(IocManager);
            //UnitOfWorkRegistrar.Initialize(IocManager);
            //AuthorizationInterceptorRegistrar.Initialize(IocManager);
        }

        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(MSBootStrapper));
            }
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<MSBootStrapper>())
            {
                IocManager.IocContainer.Register(
                    Component.For<MSBootStrapper>().Instance(this)
                    );
            }
        }
    }
}
