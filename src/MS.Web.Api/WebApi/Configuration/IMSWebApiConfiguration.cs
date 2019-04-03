using MS.WebApi.Controllers.Dynamic.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MS.WebApi.Configuration
{
    public interface IMSWebApiConfiguration
    {
        HttpConfiguration HttpConfiguration { get; set; }

        IDynamicApiControllerBuilder DynamicApiControllerBuilder { get; }
    }
}
