using MS;
using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MSAspNetMvcDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static MSBootStrapper MSBootStrapper { get; } = MSBootStrapper.Create<MSAspNetDemoModule>();
        protected void Application_Start()
        {

            //IocManager.Instance.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MSBootStrapper.Initialize();
        }

        protected virtual void Application_End(object sender, EventArgs e)
        {
            MSBootStrapper.Dispose();
        }
    }
}
