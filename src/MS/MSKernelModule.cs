using MS.Dependency;
using MS.Extension;
using MS.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS
{
    /// <summary>
    /// MSModule 核心
    /// </summary>
    public sealed class MSKernelModule : MSModule
    {
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new BasicConventionalRegistrar());

            IocManager.Register<IScopedIocResolver, ScopedIocResolver>(DependencyLifeStyle.Transient);

            // 系统配置
            ConfigureCaches();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MSKernelModule).GetAssembly(),
                new ConventionalRegistrationConfig
                {
                    InstallInstallers = false
                });
        }

        /// <summary>
        /// 缓存配置信息
        /// </summary>
        private void ConfigureCaches()
        {
            Configuration.Caching.Configure("ApplicationSettingsCache", cache =>
            {
                cache.DefaultSlidingExpireTime = TimeSpan.FromHours(8);
            });
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
        }

        public override void Shutdown()
        {
            base.Shutdown();
        }
    }
}
