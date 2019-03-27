using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using MS.Extension;
using MS.WebApi.Controllers.Dynamic.Builders;

namespace MS.WebApi.Controllers.Dynamic.Selectors
{
    /// <summary>
    /// 继承默认Controller选择器使拥有动态Api Controller 特性;
    /// 判断请求Controller是否是动态Api Controller,如果是就返回<see cref="HttpControllerDispatcher">给Asp.Net
    /// </summary>
    public class MSHttpControllerSelector : DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration _configuration;
        private readonly DynamicApiControllerManager _dynamicApiControllerManager;

        public MSHttpControllerSelector(HttpConfiguration configuration, DynamicApiControllerManager dynamicApiControllerManager)
            : base(configuration)
        {
            _configuration = configuration;
            _dynamicApiControllerManager = dynamicApiControllerManager;
        }

        /// <summary>
        /// 该方法将被系统调用，根据请求选择合适的Controller
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            if (null == request)
                return base.SelectController(null);

            var routeData = request.GetRouteData();
            if(null == routeData)
            {
                return base.SelectController(request);
            }
            string serviceNameWithAction;
            if(!routeData.Values.TryGetValue("serviceNameWithAction",out serviceNameWithAction))
            {
                return base.SelectController(request);
            }

            if (Convert.ToString(serviceNameWithAction).EndsWith("/"))
            {
                serviceNameWithAction = serviceNameWithAction.Substring(0, serviceNameWithAction.Length - 1);
                routeData.Values["serviceNameWithAction"] = serviceNameWithAction;
            }
            var hasActionName = false;
            var controllerInfo = _dynamicApiControllerManager.FindOrNull(serviceNameWithAction);
            if(null == controllerInfo)
            {
                if (!DynamicApiServiceNameHelper.IsValidServiceNameWithAction(serviceNameWithAction))
                {
                    return base.SelectController(request);
                }
                var serviceName = DynamicApiServiceNameHelper.GetServiceNameInServiceNameWithAction(serviceNameWithAction);
                controllerInfo = _dynamicApiControllerManager.FindOrNull(serviceName);
                if(null == controllerInfo)
                {
                    return base.SelectController(request);
                }
                hasActionName = true;
            }
            // 创建并返回Controller描述器
            var controllerDescriptor = new DynamicHttpControllerDescriptor(_configuration, controllerInfo);
            controllerDescriptor.Properties["__MSDynamicApiControllerInfo"] = controllerInfo;
            controllerDescriptor.Properties["__MSDynamicApiHasActionName"] = hasActionName;

            return controllerDescriptor;
        }
    }
}
