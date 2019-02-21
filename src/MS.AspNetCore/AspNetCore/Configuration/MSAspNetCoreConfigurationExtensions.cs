using System;
using System.Collections.Generic;
using System.Text;
using MS.Configuration.Startup;

namespace MS.AspNetCore.Configuration
{
    /// <summary>
    /// 定义<see cref="IModuleConfigurations"/>接口的扩展方法，允许对AspNetCore 模块进行配置
    /// </summary>
    public static class MSAspNetCoreConfigurationExtensions
    {
        public static IMSAspNetCoreConfiguration MSAspNetCore(this IModuleConfigurations configurations)
        {
            return configurations.MSConfiguration.Get<IMSAspNetCoreConfiguration>();
        }
    }
}
