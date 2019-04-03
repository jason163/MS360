using Castle.MicroKernel.Registration;
using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MS.Web.Mvc.Controllers
{
    public class ControllerConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                .BasedOn<Controller>()
                .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                .LifestyleTransient());


            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                .IncludeNonPublicTypes()
                .BasedOn<IPerWebRequestDependency>()
                .WithService.Self()
                .WithService.DefaultInterfaces()
                .LifestylePerWebRequest()
                );

        }

        
    }
}
