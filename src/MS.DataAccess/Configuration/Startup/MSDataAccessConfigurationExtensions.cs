using MS.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Configuration.Startup
{
    public static class MSDataAccessConfigurationExtensions
    {
        /// <summary>
        /// Configuration.Modules.AbpWeb.SendAllExceptionsToClients=True;
        /// </summary>
        /// <param name="configurations"></param>
        /// <returns></returns>
        public static IMSDataAccessModuleConfiguration MSDataAccess(this IModuleConfigurations configurations)
        {
            return configurations.MSConfiguration.Get<IMSDataAccessModuleConfiguration>();
        }

    }
}
