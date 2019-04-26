using MS.Module;
using System;
using MS.Extension;
using MS.Dependency;

namespace MS360.Web.DataAccess
{
    public class MS360WebDataAccessModule : MSModule
    {
        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MS360WebDataAccessModule).GetAssembly(), new ConventionalRegistrationConfig());
        }

        public override void PostInitialize()
        {
        }
    }
}
