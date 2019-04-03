using MS.Dependency;
using MS.WebApi.Controllers.Dynamic.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic.Builders
{
    /// <summary>
    /// 创建<see cref="DynamicApiControllerInfo"/> 实例
    /// </summary>
    /// <typeparam name="T">被代理对象</typeparam>
    public class ApiControllerBuilder<T> : IApiControllerBuilder<T>
    {
        /// <summary>
        /// Controller 名称即服务名称
        /// </summary>
        public string ServiceName { get; }

        /// <summary>
        /// 服务接口类型
        /// </summary>
        public Type ServiceInterfaceType { get; }

        /// <summary>
        /// 过滤列表
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        /// API 是否可探测
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
            if (string.IsNullOrWhiteSpace(serviceName))
            {
                throw new ArgumentException("serviceName null or empty","serviceName");
            }

            if (!DynamicApiServiceNameHelper.IsValidServiceName(serviceName))
            {
                throw new ArgumentException("serviceName is not properly formatted! It must contain a single-depth namespace at least! For example: 'myapplication/myservice'.", "serviceName");
            }

            _iocResolver = iocResolver;

            ServiceName = serviceName;
            ServiceInterfaceType = typeof(T);

            _actionBuilders = new Dictionary<string, ApiControllerActionBuilder<T>>();

            foreach(var methodInfo in DynamicApiControllerActionHelper.GetMethodsOfType(typeof(T)))
            {
                var actionBuilder = new ApiControllerActionBuilder<T>(this, methodInfo, iocResolver);

                _actionBuilders[methodInfo.Name] = actionBuilder;
            }
        }

        public void Build()
        {
            var controllerInfo = new DynamicApiControllerInfo(ServiceName, ServiceInterfaceType,
                typeof(DynamicApiController<T>), typeof(MSDynamicApiControllerInterceptor<T>)
                , Filters, IsApiExplorerEnabled);

            foreach(var actionBuilder in _actionBuilders.Values)
            {
                if (actionBuilder.DontCreate)
                {
                    continue;
                }
                controllerInfo.Actions[actionBuilder.ActionName] = actionBuilder.BuildActionInfo(ConventionalVerbs);
            }

            _iocResolver.Resolve<DynamicApiControllerManager>().Register(controllerInfo);
        }
        

        public IApiControllerActionBuilder<T> ForMethod(string methodName)
        {
            if (!_actionBuilders.ContainsKey(methodName))
            {
                throw new MSException("There is no method with name "+ methodName + " in type "+typeof(T).Name);
            }

            return _actionBuilders[methodName];
        }

        public IApiControllerBuilder<T> ForMethods(Action<IApiControllerActionBuilder> action)
        {
            foreach (var actionBuilder in _actionBuilders.Values)
            {
                action(actionBuilder);
            }

            return this;
        }

        public IApiControllerBuilder<T> WithApiExplorer(bool isEnabled)
        {
            IsApiExploreEnabled = isEnabled;
            return this;
        }

        public IApiControllerBuilder<T> WithConventionalVerbs()
        {
            ConventionalVerbs = true;
            return this;
        }

        public IApiControllerBuilder<T> WithFilters(params IFilter[] filters)
        {
            Filters = filters;
            return this;
        }

        
    }
}
