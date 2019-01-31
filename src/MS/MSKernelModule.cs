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
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MSKernelModule).GetAssembly(),
                new ConventionalRegistrationConfig
                {
                    InstallInstallers = false
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
