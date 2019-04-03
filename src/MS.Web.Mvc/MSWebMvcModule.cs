using MS.Module;
using MS.Web.Mvc.Controllers;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace MS.Web.Mvc
{
    [DependsOn(typeof(MSKernelModule))]
    public class MSWebMvcModule : MSModule
    {
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new ControllerConventionalRegistrar());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(),new Dependency.ConventionalRegistrationConfig());

            // 使用自定义 ControllerFactory来创建Controller实例
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(IocManager));
        }

        public override void PostInitialize()
        {
            base.PostInitialize(); 
        }
    }
}
