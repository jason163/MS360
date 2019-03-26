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
        /// Controller 类型
        /// </summary>
        public Type ApiControllerType { get; private set; }

        /// <summary>
        /// 接口类型
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
        /// <param name="serviceName">Name of the service</param>
        /// <param name="serviceInterfaceType">Service interface type</param>
        /// <param name="apiControllerType">Api Controller type</param>
        /// <param name="interceptorType">Interceptor type</param>
        /// <param name="filters">Filters</param>
        /// <param name="isApiExplorerEnabled">Is API explorer enabled</param>
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
