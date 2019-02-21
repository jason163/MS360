using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Mvc;
using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS.AspNetCore
{
    /// <summary>
    /// AspNetCore 协议注册器
    /// </summary>
    public class MSAspNetCoreConventionalRegistrar : IConventionalDependencyRegistrar
    {
        public void RegisterAssembly(IConventionalRegistrationContext context)
        {
            // ViewComponent
            context.IocManager.IocContainer.Register(
                Classes.FromAssembly(context.Assembly)
                .BasedOn<ViewComponent>()
                .If(type => !type.GetTypeInfo().IsGenericTypeDefinition)
                .LifestyleTransient());
        }
    }
}
