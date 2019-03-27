using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using MS.Dependency;
using MS.Web;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    internal class ApiControllerActionBuilder<T> : IApiControllerActionBuilder<T>
    {
        public string ActionName { get; }

        public MethodInfo Method { get; }

        public HttpVerb? Verb { get; set; }
        public bool IsApiExplorerEnabled { get; set; }
        public IFilter[] Filters { get; set ; }
        public bool DontCreate { get; set; }

        private readonly ApiControllerBuilder<T> _controller;
        private readonly IIocResolver _iocResolver;

        public IApiControllerBuilder Controller
        {
            get { return _controller; }
        }

        public void Build()
        {
            throw new NotImplementedException();
        }

        public IApiControllerBuilder<T> DontCreateAction()
        {
            throw new NotImplementedException();
        }

        public IApiControllerActionBuilder<T> ForMethod(string methodName)
        {
            throw new NotImplementedException();
        }

        public IApiControllerActionBuilder<T> WithApiExplorer(bool isEnabled)
        {
            throw new NotImplementedException();
        }

        public IApiControllerActionBuilder<T> WithFilters(params IFilter[] filters)
        {
            throw new NotImplementedException();
        }

        public IApiControllerActionBuilder<T> WithVerb(HttpVerb verb)
        {
            throw new NotImplementedException();
        }
    }
}
