
using Microsoft.AspNetCore.Builder;
using MS.AspNetCore;
using MS.AspNetCore.Configuration;
using MS.Configuration.Startup;
using MS.DataAccess;
using MS.Module;
using MS.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MSAspNetCoreDemo
{
    [DependsOn(
        typeof(MSDataAccessModule),
        typeof(MSAspNetCoreModule),
        typeof(MSWebCommonModule)
        )]
    public class MSAspNetCoreDemoModule : MSModule
    {
        public override void PreInitialize()
        {
            // 设置MSDataAccess的配置信息
             Configuration.Modules.MSDataAccess().ConfigPath = @"Configuration\Data";

            // 为AppServices创建Controller
            Configuration.Modules.MSAspNetCore()
                .CreateControllersForAppServices(typeof(MSAspNetCoreDemoModule).GetTypeInfo().Assembly);

            Configuration.Modules.MSAspNetCore().RouteConfiguration.Add(routes => {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MSAspNetCoreDemoModule).GetTypeInfo().Assembly,new MS.Dependency.ConventionalRegistrationConfig());
        }
    }
}
