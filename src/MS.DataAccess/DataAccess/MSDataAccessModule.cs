
using System;
using System.Collections.Generic;
using System.Text;
using MS.DataAccess.Configuration;
using MS.DataAccess.DbProvider;
using MS.Dependency;
using MS.Extension;
using MS.Module;
using MS.Runtime.Caching;
using MS.Runtime.Caching.Memory;

namespace MS.DataAccess
{
    [DependsOn(typeof(MSKernelModule))]
    public class MSDataAccessModule : MSModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IMSDataAccessModuleConfiguration, MSDataAccessModuleConfiguration>();

            // 注册SQL Server
            IocManager.Register<IDbFactory, SqlServerFactory>();
            IocManager.Register<IDbConfigProvider, DefaultDbConfigProvider>();
            IocManager.Register<ISQLConfigHelper, SQLConfigHelper>();
            IocManager.Register<IDbHelper, DbHelper>();
            IocManager.Register<IDataCommand, DataCommand>();

            Configuration.Caching.Configure("MS360_DataAccess", cache => {
                cache.DefaultSlidingExpireTime = TimeSpan.FromHours(1);
            });
        }

        public override void Initialize()
        {
            // 注册当前程序集
            IocManager.RegisterAssemblyByConvention(typeof(MSDataAccessModule).GetAssembly(), new ConventionalRegistrationConfig());
        }

    }
}
