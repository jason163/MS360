using Castle.MicroKernel.Registration;
using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MS.WebApi.Controllers
{
    /// <summary>
    /// 注册所有从<see cref="ApiController">Web API 控制器
    /// </summary>
    public class ApiControllerConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                .BasedOn<ApiController>()
                .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                .LifestyleTransient());
        }
    }
}
