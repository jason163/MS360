using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using MS.Extension;

namespace MS.WebApi.Controllers.Dynamic.Selectors
{
    /// <summary>
    /// 继承默认Controller描述器并对Action动态增加过滤器
    /// </summary>
    public class DynamicHttpControllerDescriptor : HttpControllerDescriptor
    {
        private readonly DynamicApiControllerInfo _controllerInfo;

        private readonly object[] _attributes;
        private readonly object[] _declareOnlyAttributes;

        public DynamicHttpControllerDescriptor(HttpConfiguration configuration,DynamicApiControllerInfo controllerInfo)
            : base(configuration, controllerInfo.ServiceName, controllerInfo.ApiControllerType)
        {
            _controllerInfo = controllerInfo;

            _attributes = controllerInfo.ServiceInterfaceType.GetCustomAttributes(true);
            _declareOnlyAttributes = controllerInfo.ServiceInterfaceType.GetCustomAttributes(false);
        }

        public override Collection<IFilter> GetFilters()
        {
            if (_controllerInfo.Filters.IsNullOrEmpty())
            {
                return base.GetFilters();
            }
            var actionFilters = new Collection<IFilter>();
            foreach (var filter in _controllerInfo.Filters)
            {
                actionFilters.Add(filter);
            }

            foreach (var baseFilter in base.GetFilters())
            {
                actionFilters.Add(baseFilter);
            }

            return actionFilters;
        }

        public override Collection<T> GetCustomAttributes<T>(bool inherit)
        {
            var attributes = inherit ? _attributes : _declareOnlyAttributes;
            return new Collection<T>(DynamicApiDescriptorHelper.FilterType<T>(attributes));
        }
    }
}
