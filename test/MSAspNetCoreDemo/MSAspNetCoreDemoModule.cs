using MS.Configuration.Startup;
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
            // 设置MSDataAccess的配置信息
            // Configuration.Modules.MSDataAccess().ConfigPath = @"Configuration\Data";

            base.PreInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MSAspNetCoreDemoModule).GetTypeInfo().Assembly,new MS.Dependency.ConventionalRegistrationConfig());
        }
    }
}
