using MS.WebApi.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Configuration.Startup
{
    /// <summary>
    /// 定义<see cref="IModuleConfigurations"/>扩展方法来配置MS.Web.Api
    /// </summary>
    public static class MSWebApiConfigurationExtensions
    {
        public static IMSWebApiConfiguration MSWebApi(this IModuleConfigurations configurations)
        {
            return configurations.MSConfiguration.Get<IMSWebApiConfiguration>();
        }
    }
}
