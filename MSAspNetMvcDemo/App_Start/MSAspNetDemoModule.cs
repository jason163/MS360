using MS.Module;
using MSDynamicWebApiDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MSAspNetMvcDemo
{
    [DependsOn(dependedModuleTypes: typeof(MSDynamicWebApiDemoModule))]
    public class MSAspNetDemoModule : MSModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(),new MS.Dependency.ConventionalRegistrationConfig());

        }
    }
}