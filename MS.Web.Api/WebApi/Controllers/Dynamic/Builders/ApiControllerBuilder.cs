using MS.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    internal class ApiControllerBuilder<T> : IApiControllerBuilder<T>
    {
        /// <summary>
        /// Name of the controller.
        /// </summary>
        public string ServiceName { get; }

        /// <summary>
        /// Gets type of the service interface for this dynamic controller.
        /// </summary>
        public Type ServiceInterfaceType { get; }

        /// <summary>
        /// Action Filters to apply to this dynamic controller.
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        /// Is API Explorer enabled.
        /// </summary>
        public bool? IsApiExplorerEnabled { get; set; }

        /// <summary>
        /// True, if using conventional verbs for this dynamic controller.
        /// </summary>
        public bool ConventionalVerbs { get; set; }
        public bool IsApiExploreEnabled { get; set; }

        /// <summary>
        /// List of all action builders for this controller.
        /// </summary>
        private readonly IDictionary<string, ApiControllerActionBuilder<T>> _actionBuilders;

        private readonly IIocResolver _iocResolver;

        public ApiControllerBuilder(string serviceName, IIocResolver iocResolver)
        {

        }
        public void Build()
        {
            throw new NotImplementedException();
        }

        public IApiControllerBuilder<T> ForMethod(string methodName)
        {
            throw new NotImplementedException();
        }

        public IApiControllerBuilder<T> ForMethods(Action<IApiControllerActionBuilder> action)
        {
            throw new NotImplementedException();
        }

        public IApiControllerBuilder<T> WithApiExplorer(bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public IApiControllerBuilder<T> WithConventionalVerbs()
        {
            throw new NotImplementedException();
        }

        public IApiControllerBuilder<T> WithFilters(params IFilter[] filters)
        {
            throw new NotImplementedException();
        }
    }
}
