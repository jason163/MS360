using MS.Dependency;
using MS.Module;
using MS.WebApi.Configuration;
using MS.WebApi.Controllers;
using MS.WebApi.Controllers.Dynamic;
using MS.WebApi.Controllers.Dynamic.Builders;
using MS.WebApi.Controllers.Dynamic.Selectors;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace MS.WebApi
{
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

            base.PostInitialize();
        }

        private void InitializeAspNetServices(HttpConfiguration httpConfiguration)
        {
            httpConfiguration.Services.Replace(typeof(IHttpControllerSelector), new MSHttpControllerSelector(httpConfiguration, IocManager.Resolve<DynamicApiControllerManager>()));
            
        }
    }
}
