using Castle.Core.Internal;
using MS.Extension;
using MS.Web;
using MS.WebApi.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic.Selectors
{
    internal static class DynamicApiDescriptorHelper
    {
        internal static ReadOnlyCollection<T> FilterType<T>(object[] objects) where T : class
        {
            int max = objects.Length;
            List<T> list = new List<T>(max);
            int idx = 0;
            for (int i = 0; i < max; i++)
            {
                T attr = objects[i] as T;
                if (attr != null)
                {
                    list.Add(attr);
                    idx++;
                }
            }
            list.Capacity = idx;

            return new ReadOnlyCollection<T>(list);
        }
    }

    public class DynamicHttpActionDescriptor : ReflectedHttpActionDescriptor
    {
        public override Collection<HttpMethod> SupportedHttpMethods { get; }

        private readonly DynamicApiActionInfo _actionInfo;
        private readonly Lazy<Collection<IFilter>> _filters;
        private readonly Lazy<Collection<HttpParameterDescriptor>> _parameters;

        private readonly object[] _attributes;
        private readonly object[] _declareOnlyAttributes;

        public DynamicHttpActionDescriptor(IMSWebApiConfiguration configuration,
            HttpControllerDescriptor controllerDescriptor,
            DynamicApiActionInfo actionInfo)
            :base(controllerDescriptor,actionInfo.Method)
        {
            _actionInfo = actionInfo;
            SupportedHttpMethods = new Collection<HttpMethod> { actionInfo.Verb.ToHttpMethod()};

            Properties["__MSDynamicApiActionInfo"] = actionInfo;

            _filters = new Lazy<Collection<IFilter>>(GetFiltersInternal, true);
            _parameters = new Lazy<Collection<HttpParameterDescriptor>>(GetParametersInternal, true);

            _attributes = _actionInfo.Method.GetCustomAttributes(inherit: true);
            _declareOnlyAttributes = _actionInfo.Method.GetCustomAttributes(inherit: false);
        }

        public override Collection<IFilter> GetFilters()
        {
            return _filters.Value;
        }

        public override Collection<HttpParameterDescriptor> GetParameters()
        {
            return _parameters.Value;
        }

        public override Collection<T> GetCustomAttributes<T>(bool inherit)
        {
            object[] attributes = inherit ? _attributes : _declareOnlyAttributes;
            return new Collection<T>(DynamicApiDescriptorHelper.FilterType<T>(attributes));
        }

        private Collection<IFilter> GetFiltersInternal()
        {
            if (_actionInfo.Filters.IsNullOrEmpty())
            {
                return base.GetFilters();
            }

            var actionFilters = new Collection<IFilter>();

            foreach (var filter in _actionInfo.Filters)
            {
                actionFilters.Add(filter);
            }

            foreach (var baseFilter in base.GetFilters())
            {
                actionFilters.Add(baseFilter);
            }

            return actionFilters;
        }

        private Collection<HttpParameterDescriptor> GetParametersInternal()
        {
            var parameters = base.GetParameters();

            if (_actionInfo.Verb.IsIn(HttpVerb.Get, HttpVerb.Head))
            {
                foreach (var parameter in parameters)
                {
                    if (parameter.ParameterBinderAttribute == null)
                    {
                        parameter.ParameterBinderAttribute = new FromUriAttribute();
                    }
                }
            }

            return parameters;
        }
    }
}
