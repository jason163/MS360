using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using MS.AspNetCore.Configuration;
using MS.Extension;
using MS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.AspNetCore
{
    public class MSAspNetCoreModule : MSModule
    {
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new MSAspNetCoreConventionalRegistrar());

            IocManager.Register<IMSAspNetCoreConfiguration, MSAspNetCoreConfiguration>();

            Configuration.Modules.MSAspNetCore().FormBodyBindingIgnoredTypes.Add(typeof(IFormFile));
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MSAspNetCoreModule).GetAssembly(),new Dependency.ConventionalRegistrationConfig());
        }

        public override void PostInitialize()
        {
            AddApplicatonParts();
        }

        private void AddApplicatonParts()
        {
            var configuration = IocManager.Resolve<MSAspNetCoreConfiguration>();
            var partManager = IocManager.Resolve<ApplicationPartManager>();
            var moduleManager = IocManager.Resolve<IMSModuleManager>();

            var controllerAssemblies = configuration.ControllerAssemblySettings.Select(s => s.Assembly).Distinct();
            foreach(var controllerAssembly in controllerAssemblies)
            {
                partManager.ApplicationParts.Add(new AssemblyPart(controllerAssembly));
            }
        }
    }
}
