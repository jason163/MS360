using Castle.MicroKernel.Registration;
using MS.Configuration.Startup;
using MS.Dependency;
using MS.Module;
using MS.WebApi.Configuration;
using MS.WebApi.Controllers;
using MS.WebApi.Controllers.ApiExplorer;
using MS.WebApi.Controllers.Dynamic;
using MS.WebApi.Controllers.Dynamic.Builders;
using MS.WebApi.Controllers.Dynamic.Selectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Http.Dispatcher;
using System.Web.Http.ModelBinding;

namespace MS.WebApi
{
    [DependsOn(typeof(MSKernelModule))]
    public class MSWebApiModule : MSModule
    {
        public override void PreInitialize()
        {
            IocManager.AddConventionalRegistrar(new ApiControllerConventionalRegistrar());

            IocManager.Register<IDynamicApiControllerBuilder, DynamicApiControllerBuilder>();
            IocManager.Register<IMSWebApiConfiguration, MSWebApiConfiguration>();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(), new ConventionalRegistrationConfig());
        }

        public override void PostInitialize()
        {
            var httpConfiguration = IocManager.Resolve<IMSWebApiConfiguration>().HttpConfiguration;
            InitializeAspNetServices(httpConfiguration);
            InitializeFilters(httpConfiguration);
            InitializeFormatters(httpConfiguration);
            InitializeRoutes(httpConfiguration);
            InitializeModelBinders(httpConfiguration);

            foreach(var controllerInfo in IocManager.Resolve<DynamicApiControllerManager>().GetAll())
            {
                IocManager.IocContainer.Register(
                    Component.For(controllerInfo.InterceptorType).LifestyleTransient(),
                    Component.For(controllerInfo.ApiControllerType)
                    .Proxy.AdditionalInterfaces(controllerInfo.ServiceInterfaceType)
                    .Interceptors(controllerInfo.InterceptorType)
                    .LifestyleTransient()
                    );

                Logger.DebugFormat("Dynamic web api controller is created for type '{0}' with service name '{1}'.", controllerInfo.ServiceInterfaceType.FullName, controllerInfo.ServiceName);
            }
            Configuration.Modules.MSWebApi().HttpConfiguration.EnsureInitialized();

            base.PostInitialize();
        }

        private void InitializeAspNetServices(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Services.Replace(typeof(IHttpControllerSelector), new MSHttpControllerSelector(httpConfiguration, IocManager.Resolve<DynamicApiControllerManager>()));
            httpConfiguration.Services.Replace(typeof(IHttpActionSelector), new MSApiControllerActionSelector(IocManager.Resolve<IMSWebApiConfiguration>()));
            httpConfiguration.Services.Replace(typeof(IHttpControllerActivator), new MSApiControllerActivator(IocManager));
            httpConfiguration.Services.Replace(typeof(IApiExplorer), IocManager.Resolve<MSApiExplorer>());
        }

        private void InitializeFilters(HttpConfiguration httpConfiguration)
        {

        }

        private void InitializeFormatters(HttpConfiguration httpConfiguration)
        {
            foreach(var currentFormatter in httpConfiguration.Formatters.ToList())
            {
                if(!(currentFormatter is JsonMediaTypeFormatter ||
                    currentFormatter is JQueryMvcFormUrlEncodedFormatter))
                {
                    httpConfiguration.Formatters.Remove(currentFormatter);
                }
            }

            //httpConfiguration.Formatters.JsonFormatter.SerializerSettings
            //httpConfiguration.Formatters.Add(new PlainTextFormatter());
        }

        private static void InitializeRoutes(HttpConfiguration httpConfiguration)
        {
            // Dynamic Web APIs
            httpConfiguration.Routes.MapHttpRoute(
                name: "DynamicWebApi",
                routeTemplate: "api/services/{*serviceNameWithAction}"
                );

            // Other Routes
            httpConfiguration.Routes.MapHttpRoute(
                name: "MSCacheController_Clear",
                routeTemplate: "api/MSCache/Clear",
                defaults: new { controller = "MSCache", action = "Clear" }
                );
            httpConfiguration.Routes.MapHttpRoute(
                name: "MSCacheController_ClearAll",
                routeTemplate: "api/MSCache/ClearAll",
                defaults: new { controller = "MSCache", action = "ClearAll" }
                );
        }

        private static void InitializeModelBinders(HttpConfiguration httpConfiguration)
        {

        }
    }
}
