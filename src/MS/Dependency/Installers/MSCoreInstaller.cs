using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MS.Module;
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
                Component.For<IMSModuleManager,MSModuleManager>().ImplementedBy<MSModuleManager>().LifestyleSingleton()
                );
        }
    }
}
