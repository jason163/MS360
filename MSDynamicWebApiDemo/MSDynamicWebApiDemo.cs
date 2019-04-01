using MS.Application.Services;
using MS.Configuration.Startup;
using MS.Module;
using MS.WebApi;
using MS.WebApi.Controllers.Dynamic.Builders;
using MSDynamicWebApiDemo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSDynamicWebApiDemo
{
    [DependsOn(typeof(MSWebApiModule))]
    public class MSDynamicWebApiDemoModule : MSModule
    {
        public override void PreInitialize()
        {
            
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(),new MS.Dependency.ConventionalRegistrationConfig());

            Configuration.Modules.MSWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(Assembly.GetExecutingAssembly(), "myapp")
                .ForMethods(builder => {
                    if (builder.Method.IsDefined(typeof(IgnoreAttribute)))
                    {
                        builder.DontCreate = true;
                    }
                }).Build();
        }
    }
}
