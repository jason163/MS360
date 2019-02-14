using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MS.Configuration.Startup;
using MS.Module;
using MS.Runtime.Caching;
using MS.Runtime.Caching.Configuration;
using MS.Runtime.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency.Installers
{
    /// <summary>
    /// MS Library Core 依赖注册
    /// </summary>
    internal class MSCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IModuleConfigurations, ModuleConfigurations>().ImplementedBy<ModuleConfigurations>().LifestyleSingleton(),
                Component.For<ICachingConfiguration, CachingConfiguration>().ImplementedBy<CachingConfiguration>().LifestyleSingleton(),
                Component.For<ICacheManager, MSMemoryCacheManager>().ImplementedBy<MSMemoryCacheManager>().LifestyleSingleton(),
                Component.For<IMSStartupConfiguration, MSStartupConfiguration>().ImplementedBy<MSStartupConfiguration>().LifestyleSingleton(),
                Component.For<IMSModuleManager,MSModuleManager>().ImplementedBy<MSModuleManager>().LifestyleSingleton()
                
                );
        }
    }
}
