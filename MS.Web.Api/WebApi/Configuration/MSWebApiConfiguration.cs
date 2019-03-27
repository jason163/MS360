using MS.WebApi.Controllers.Dynamic.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MS.WebApi.Configuration
{
    public class MSWebApiConfiguration : IMSWebApiConfiguration
    {
        public HttpConfiguration HttpConfiguration { get; set; }

        public IDynamicApiControllerBuilder DynamicApiControllerBuilder { get; }

        public MSWebApiConfiguration(IDynamicApiControllerBuilder dynamicApiControllerBuilder)
        {
            HttpConfiguration = GlobalConfiguration.Configuration;
            DynamicApiControllerBuilder = dynamicApiControllerBuilder;
        }
    }
}
