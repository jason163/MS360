using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace MS.WebApi.Controllers.Dynamic
{
    /// <summary>
    /// 用于存储 动态ApiController 信息
    /// </summary>
    public class DynamicApiControllerInfo
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; private set; }

        /// <summary>
        /// 服务接口类型
        /// </summary>
        public Type ServiceInterfaceType { get; private set; }

        /// <summary>
        /// Controller 类型 即 <see cref="DynamicApiController{T}"/>类型,其中的T就是具体的ApplicationService接口的类型
        /// </summary>
        public Type ApiControllerType { get; private set; }

        /// <summary>
        /// 拦截器类型
        /// </summary>
        public Type InterceptorType { get; private set; }

        /// <summary>
        /// Is API Explorer enabled.
        /// </summary>
        public bool? IsApiExplorerEnabled { get; private set; }

        /// <summary>
        /// 过滤器列表
        /// </summary>
        public IFilter[] Filters { get; set; }

        /// <summary>
        /// Action列表
        /// </summary>
        public IDictionary<string, DynamicApiActionInfo> Actions { get; private set; }
        

        /// <summary>
        /// Creates a new <see cref="DynamicApiControllerInfo"/> instance.
        /// </summary>
        /// <param name="serviceName">服务名称</param>
        /// <param name="serviceInterfaceType">服务接口类型</param>
        /// <param name="apiControllerType">控制器类型</param>
        /// <param name="interceptorType">拦截器类型</param>
        /// <param name="filters">过滤器列表</param>
        /// <param name="isApiExplorerEnabled">动态接口是否被探测</param>
        public DynamicApiControllerInfo(
            string serviceName,
            Type serviceInterfaceType,
            Type apiControllerType,
            Type interceptorType,
            IFilter[] filters = null,
            bool? isApiExplorerEnabled = null)
        {
            ServiceName = serviceName;
            ServiceInterfaceType = serviceInterfaceType;
            ApiControllerType = apiControllerType;
            InterceptorType = interceptorType;
            IsApiExplorerEnabled = isApiExplorerEnabled;
            Filters = filters ?? new IFilter[] { };

            Actions = new Dictionary<string, DynamicApiActionInfo>(StringComparer.InvariantCultureIgnoreCase);
        }
    }
}
