using Castle.MicroKernel.Registration;
using MS.Module;
using MS.Web.Cookie;
using System;
using System.Reflection;

namespace MS.Web
{
    [DependsOn(typeof(MSKernelModule))]
    public class MSWebCommonModule : MSModule
    {
        public override void PreInitialize()
        {
            IocManager.IocContainer.Register(Component.For<CookieHelper>().LifestyleSingleton());
            IocManager.IocContainer.Register(Component.For<CookieConfigManager>().LifestyleSingleton());
            //
            //IocManager.IocContainer.Register(Component.For<ICookieEncryption>().Named("HighSecurity").ImplementedBy<HighSecurityCookie>());
            //IocManager.IocContainer.Register(Component.For<ICookieEncryption>().Named("NormalSecurity").ImplementedBy<NormalCookie>());
            //IocManager.IocContainer.Register(Component.For<ICookiePersist>().Named("MobilePersister").ImplementedBy<MobileCookiePersister>());
            //IocManager.IocContainer.Register(Component.For<ICookiePersist>().Named("WebPersister").ImplementedBy<WebCookiePersister>());
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly(), new Dependency.ConventionalRegistrationConfig());
        }


    }
}
