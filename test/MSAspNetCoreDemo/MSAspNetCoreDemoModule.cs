using MS.DataAccess;
using MS.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MSAspNetCoreDemo
{
    [DependsOn(
        typeof(MSDataAccessModule)
        )]
    public class MSAspNetCoreDemoModule : MSModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MSAspNetCoreDemoModule).GetTypeInfo().Assembly,new MS.Dependency.ConventionalRegistrationConfig());
        }
    }
}
