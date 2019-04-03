using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using MS.Dependency;
using MS.Reflection;
using MS.Web;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    /// <summary>
    /// 产生<see cref="DynamicApiActionInfo"/> 对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiControllerActionBuilder<T> : IApiControllerActionBuilder<T>
    {
        public string ActionName { get; }

        public MethodInfo Method { get; }

        public HttpVerb? Verb { get; set; }

        public bool IsApiExplorerEnabled { get; set; }

        public IFilter[] Filters { get; set ; }

        public bool DontCreate { get; set; }

        public IApiControllerBuilder Controller
        {
            get { return _controller; }
        }

        private readonly ApiControllerBuilder<T> _controller;
        private readonly IIocResolver _iocResolver;

        public ApiControllerActionBuilder(ApiControllerBuilder<T> apiControllerBuilder,MethodInfo methodInfo,IIocResolver iocResolver)
        {
            _controller = apiControllerBuilder;
            _iocResolver = iocResolver;
            Method = methodInfo;
            ActionName = Method.Name;
        }

        public void Build()
        {
            _controller.Build();
        }

        

        public IApiControllerBuilder<T> DontCreateAction()
        {
            DontCreate = true;
            return _controller;
        }

        public IApiControllerActionBuilder<T> ForMethod(string methodName)
        {
            return _controller.ForMethod(methodName);
        }

        public IApiControllerActionBuilder<T> WithApiExplorer(bool isEnabled)
        {
            IsApiExplorerEnabled = isEnabled;
            return this;
        }

        public IApiControllerActionBuilder<T> WithFilters(params IFilter[] filters)
        {
            Filters = filters;
            return this;
        }

        public IApiControllerActionBuilder<T> WithVerb(HttpVerb verb)
        {
            Verb = verb;
            return this;
        }

        internal DynamicApiActionInfo BuildActionInfo(bool conventionalVerbs)
        {
            return new DynamicApiActionInfo(ActionName, GetNormalizedVerb(conventionalVerbs),
                Method, Filters, IsApiExplorerEnabled);
        }

        private HttpVerb GetNormalizedVerb(bool conventionalVerbs)
        {
            if (Verb != null)
            {
                return Verb.Value;
            }

            if (Method.IsDefined(typeof(HttpGetAttribute)))
            {
                return HttpVerb.Get;
            }

            if (Method.IsDefined(typeof(HttpPostAttribute)))
            {
                return HttpVerb.Post;
            }

            if (Method.IsDefined(typeof(HttpPutAttribute)))
            {
                return HttpVerb.Put;
            }

            if (Method.IsDefined(typeof(HttpDeleteAttribute)))
            {
                return HttpVerb.Delete;
            }

            if (Method.IsDefined(typeof(HttpPatchAttribute)))
            {
                return HttpVerb.Patch;
            }

            if (Method.IsDefined(typeof(HttpOptionsAttribute)))
            {
                return HttpVerb.Options;
            }

            if (Method.IsDefined(typeof(HttpHeadAttribute)))
            {
                return HttpVerb.Head;
            }

            if (conventionalVerbs)
            {
                var conventionalVerb = DynamicApiVerbHelper.GetConventionalVerbForMethodName(ActionName);
                if (conventionalVerb == HttpVerb.Get && !HasOnlyPrimitiveIncludingNullableTypeParameters(Method))
                {
                    conventionalVerb = DynamicApiVerbHelper.GetDefaultHttpVerb();
                }

                return conventionalVerb;
            }

            return DynamicApiVerbHelper.GetDefaultHttpVerb();
        }

        private static bool HasOnlyPrimitiveIncludingNullableTypeParameters(MethodInfo methodInfo)
        {
            return methodInfo.GetParameters().All(p => TypeHelper.IsPrimitiveExtendedIncludingNullable(p.ParameterType) || p.IsDefined(typeof(FromUriAttribute)));
        }
    }
}
