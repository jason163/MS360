﻿
using System;
using System.Collections.Generic;
using System.Text;
using MS.DataAccess.DbProvider;
using MS.Extension;
using MS.Module;

namespace MS.DataAccess
{
    [DependsOn(typeof(MSKernelModule))]
    public class MSDataAccessModule : MSModule
    {
        public override void PreInitialize()
        {
            // 注册SQL Server
            IocManager.Register<IDbFactory, SqlServerFactory>();
            IocManager.Register<IDbConfigProvider, DefaultDbConfigProvider>();
            IocManager.Register<ISQLConfigHelper, SQLConfigHelper>();
            IocManager.Register<IDbHelper, DbHelper>();
            IocManager.Register<IDataCommand, DataCommand>();
        }

        public override void Initialize()
        {
            // 注册当前程序集
            IocManager.RegisterAssemblyByConvention(typeof(MSDataAccessModule).GetAssembly());
        }

    }
}
