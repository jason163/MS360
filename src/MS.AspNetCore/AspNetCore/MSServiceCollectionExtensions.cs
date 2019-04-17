using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MS.Dependency;
using MS.Module;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using MS.AspNetCore.Mvc;
using Castle.Windsor.MsDependencyInjection;
using MS.AspNetCore.Mvc.Providers;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MS.AspNetCore
{
    
    public static class MSServiceCollectionExtensions
    {
        /// <summary>
        /// AspNetCore 与 MS 框架集成
        /// </summary>
        /// <typeparam name="TStartupModule">运用程序的启动模块</typeparam>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceProvider AddMS<TStartupModule>(this IServiceCollection services,
            [CanBeNull]Action<MSBootstrapperOptions> optionsAction = null)
            where TStartupModule : MSModule
        {
            var msBootstrapper = AddMSBootstrapper<TStartupModule>(services,optionsAction);

            ConfigureAspNetCore(services, msBootstrapper.IocManager);

            return WindsorRegistrationHelper.CreateServiceProvider(msBootstrapper.IocManager.IocContainer, services);
        }

        private static void ConfigureAspNetCore(IServiceCollection services,IIocResolver resolver)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // 替换掉默认的控制器构造类，改用 DI 框架负责控制器的创建
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            // 替换掉默认的视图组件构造类，改用 DI 框架负责视图组件的创建
            services.Replace(ServiceDescriptor.Singleton<IViewComponentActivator, ServiceBasedViewComponentActivator>());

            //ApplicationService 成为 Controller 加入到 ApplicationPart.Controllers
            var partManager = services.GetSingletonServiceOrNull<ApplicationPartManager>();
            partManager?.FeatureProviders.Add(new MSAppServiceControllerFeatureProvider(resolver));

            // 替换默认的IActionDescriptorChangeProvider,使用ActionDescriptor缓存失效
            services.Replace(ServiceDescriptor.Singleton<IActionDescriptorChangeProvider, MSActionDescriptorChangeProvider>());

            // 可自定义协议解析器,继承DefaultContractResolver
            //services.Configure<MvcJsonOptions>(jsonOpts =>
            //{
            //    jsonOpts.SerializerSettings.ContractResolver = new DefaultContractResolver();
            //});

            // Configure MVC
            services.Configure<MvcOptions>(mvcOpts =>
            {
                mvcOpts.AddMS(services);
            });
            
        }

        private static MSBootStrapper AddMSBootstrapper<TStartupModule>(IServiceCollection services,
            Action<MSBootstrapperOptions> optionsAction)
            where TStartupModule : MSModule
        {
            var bootStrapper = MSBootStrapper.Create<TStartupModule>(optionsAction);
            services.AddSingleton(bootStrapper);

            return bootStrapper;
        }
    }
}
