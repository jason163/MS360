using MS.WebApi.Configuration;
using MS.WebApi.Controllers.Dynamic.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;

namespace MS.WebApi.Controllers.Dynamic.Selectors
{
    /// <summary>
    /// 继承ApiControllerActionSelector满足动态ApiController的Action选择
    /// </summary>
    public class MSApiControllerActionSelector : ApiControllerActionSelector
    {
        private readonly IMSWebApiConfiguration _configuration;

        public MSApiControllerActionSelector(IMSWebApiConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 此方法被系统调用，选择给定Controller的Action方法
        /// </summary>
        /// <param name="controllerContext">Controller上下文</param>
        /// <returns></returns>
        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            object controllerInfoObj;
            if(!controllerContext.ControllerDescriptor.Properties.TryGetValue("__MSDynamicApiControllerInfo",out controllerInfoObj))
            {
                return base.SelectAction(controllerContext);
            }
            var controllerInfo = controllerInfoObj as DynamicApiControllerInfo;
            if(null == controllerInfo)
            {
                throw new MSException("__MSDynamicApiControllerInfo in ControllerDescriptor.Properties is not a " + typeof(DynamicApiControllerInfo).FullName + " class.");
            }
            var hasActionName = (bool)controllerContext.ControllerDescriptor.Properties["__MSDynamicApiHasActionName"];
            if (!hasActionName)
            {
                return GetActionDescriptorByCurrentHttpVerb(controllerContext, controllerInfo);
            }
            //从路由中获取action名称
            var serviceNameWithAction = controllerContext.RouteData.Values["serviceNameWithAction"] as string;
            if(null ==serviceNameWithAction)
            {
                return base.SelectAction(controllerContext);
            }
            var actionName = DynamicApiServiceNameHelper.GetActionNameInServiceNameWithAction(serviceNameWithAction);

            return GetActionDescriptorByActionName(controllerContext, controllerInfo, actionName);


        }

        private HttpActionDescriptor GetActionDescriptorByCurrentHttpVerb(HttpControllerContext controllerContext, DynamicApiControllerInfo controllerInfo)
        {
            //Check if there is only one action with the current http verb
            var actionsByVerb = controllerInfo.Actions.Values
                .Where(action => action.Verb == controllerContext.Request.Method.ToHttpVerb())
                .ToArray();

            if (actionsByVerb.Length == 0)
            {
                throw new HttpException(
                    (int)HttpStatusCode.NotFound,
                    "There is no action" +
                    " defined for api controller " + controllerInfo.ServiceName +
                    " with an http verb: " + controllerContext.Request.Method
                );
            }

            if (actionsByVerb.Length > 1)
            {
                throw new HttpException(
                    (int)HttpStatusCode.InternalServerError,
                    "There are more than one action" +
                    " defined for api controller " + controllerInfo.ServiceName +
                    " with an http verb: " + controllerContext.Request.Method
                );
            }

            //Return the single action by the current http verb
            return new DynamicHttpActionDescriptor(_configuration, controllerContext.ControllerDescriptor, actionsByVerb[0]);
        }

        private HttpActionDescriptor GetActionDescriptorByActionName(HttpControllerContext controllerContext,DynamicApiControllerInfo controllerInfo,string actionName)
        {
            DynamicApiActionInfo actionInfo;
            if(!controllerInfo.Actions.TryGetValue(actionName,out actionInfo))
            {
                throw new MSException("There is no action " + actionName + " defined for api controller " + controllerInfo.ServiceName);
            }
            if(actionInfo.Verb != controllerContext.Request.Method.ToHttpVerb())
            {
                throw new HttpException(
                    (int)HttpStatusCode.BadRequest +
                    " There is an action " + actionName+
                    " defined for api controller " + controllerInfo.ServiceName +
                    " but with a different HTTP verb.Request verb is " + controllerContext.Request.Method +
                    " It should be " + actionInfo.Verb
                    );
            }

            return new DynamicHttpActionDescriptor(_configuration, controllerContext.ControllerDescriptor, actionInfo);
        }
    }
}
