using MS.Dependency;
using MS.WebApi.Configuration;
using MS.WebApi.Controllers.Dynamic;
using MS.WebApi.Controllers.Dynamic.Selectors;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace MS.WebApi.Controllers.ApiExplorer
{
    public class MSApiExplorer : System.Web.Http.Description.ApiExplorer,IApiExplorer,ISingletonDependency
    {
        private readonly Lazy<Collection<ApiDescription>> _apiDescriptions;
        private readonly IMSWebApiConfiguration _webApiConfiguration;
        private readonly DynamicApiControllerManager _dynamicApiControllerManager;


        public MSApiExplorer(IMSWebApiConfiguration webApiConfiguration,
            DynamicApiControllerManager dynamicApiControllerManager) : base(webApiConfiguration.HttpConfiguration)
        {
            _apiDescriptions = new Lazy<Collection<ApiDescription>>(InitializeApiDescriptions);
            _webApiConfiguration = webApiConfiguration;
            _dynamicApiControllerManager = dynamicApiControllerManager;
        }

        public new Collection<ApiDescription> ApiDescriptions
        {
            get
            {
                return _apiDescriptions.Value;
            }
        }

        /// <summary>
        /// 初始化动态API 和 非动态API 描述
        /// </summary>
        /// <returns></returns>
        private Collection<ApiDescription> InitializeApiDescriptions()
        {
            var apiDescriptions = new Collection<ApiDescription>();

            foreach(var item in base.ApiDescriptions)
            {
                apiDescriptions.Add(item);
            }
            // 所有动态Controller
            var dynamicApiControllerInfos = _dynamicApiControllerManager.GetAll();

            foreach(var dynamicApiControllerInfo in dynamicApiControllerInfos)
            {
                foreach(var dynamicApiActionInfo in dynamicApiControllerInfo.Actions.Values)
                {
                    var apiDescription = new ApiDescription();

                    var controllerDescriptor = new DynamicHttpControllerDescriptor(_webApiConfiguration.HttpConfiguration, dynamicApiControllerInfo);
                    controllerDescriptor.ControllerName = controllerDescriptor.ControllerName.Replace("/", "_");

                    var actionDescriptor = new DynamicHttpActionDescriptor(_webApiConfiguration, controllerDescriptor, dynamicApiActionInfo);

                    apiDescription.ActionDescriptor = actionDescriptor;
                    apiDescription.HttpMethod = actionDescriptor.SupportedHttpMethods[0];

                    var actionValueBinder = _webApiConfiguration.HttpConfiguration.Services.GetActionValueBinder();
                    var actionBinding = actionValueBinder.GetBinding(actionDescriptor);

                    apiDescription.ParameterDescriptions.Clear();
                    foreach(var apiParameterDescription in CreateParameterDescription(actionBinding, actionDescriptor))
                    {
                        apiDescription.ParameterDescriptions.Add(apiParameterDescription);
                    }

                    SetResponseDescription(apiDescription, actionDescriptor);

                    apiDescription.RelativePath = "api/services/" + dynamicApiControllerInfo.ServiceName + "/" + dynamicApiActionInfo.ActionName;

                    apiDescriptions.Add(apiDescription);

                }
            }

            return apiDescriptions;

        }

        /// <summary>
        /// 参数描述列表
        /// </summary>
        /// <param name="actionBinding"></param>
        /// <param name="actionDescriptor"></param>
        /// <returns></returns>
        private IList<ApiParameterDescription> CreateParameterDescription(HttpActionBinding actionBinding,HttpActionDescriptor actionDescriptor)
        {
            IList<ApiParameterDescription> parameterDescriptions = new List<ApiParameterDescription>();
            // try get parameter binding information if available
            // 首先判断，如果可用获取参数绑定信息
            if (null != actionBinding)
            {
                HttpParameterBinding[] parameterBindings = actionBinding.ParameterBindings;
                if(null != parameterBindings)
                {
                    foreach(var parameter in parameterBindings)
                    {
                        parameterDescriptions.Add(CreateParameterDescriptionFromBinding(parameter));
                    }
                }
            }
            else
            {
                Collection<HttpParameterDescriptor> parameters = actionDescriptor.GetParameters();
                if(null != parameters)
                {
                    foreach(HttpParameterDescriptor parameterDescriptor in parameters)
                    {
                        parameterDescriptions.Add(CreateParameterDescriptionFormDescriptor(parameterDescriptor));
                    }
                }
            }

            return parameterDescriptions;
        }

        /// <summary>
        /// 创建<see cref="ApiParameterDescription"/> 实例
        /// </summary>
        /// <param name="parameterBinding"></param>
        /// <returns></returns>
        private ApiParameterDescription CreateParameterDescriptionFromBinding(HttpParameterBinding parameterBinding)
        {
            ApiParameterDescription parameterDescription = CreateParameterDescriptionFormDescriptor(parameterBinding.Descriptor);
            if (parameterBinding.WillReadBody)
            {
                parameterDescription.Source = ApiParameterSource.FromBody;
            }
            else
            {
                parameterDescription.Source = ApiParameterSource.FromUri;
            }

            return parameterDescription;
        }

        /// <summary>
        /// 根据描述器创建<see cref="ApiParameterDescription"/> 实例
        /// </summary>
        /// <param name="parameterDescriptor">参数描述器</param>
        /// <returns></returns>
        private ApiParameterDescription CreateParameterDescriptionFormDescriptor(HttpParameterDescriptor parameterDescriptor)
        {
            return new ApiParameterDescription
            {
                ParameterDescriptor = parameterDescriptor,
                Name = parameterDescriptor.Prefix??parameterDescriptor.ParameterName,
                Documentation = GetApiParameterDocumentation(parameterDescriptor),
                Source = ApiParameterSource.Unknown
            };
        }

        /// <summary>
        /// 基于<see cref="HttpParameterDescriptor"/> 返回Api 参数文档
        /// </summary>
        /// <param name="parameterDescriptor">参数描述器</param>
        /// <returns></returns>
        private string GetApiParameterDocumentation(HttpParameterDescriptor parameterDescriptor)
        {
            IDocumentationProvider documentationProvider = DocumentationProvider ?? parameterDescriptor.Configuration.Services.GetDocumentationProvider();
            if(null != documentationProvider)
            {
                return documentationProvider.GetDocumentation(parameterDescriptor);
            }

            return null;
        }

        private void SetResponseDescription(ApiDescription apiDescription,DynamicHttpActionDescriptor actionDescriptor)
        {
            var responseDescription = CreateResponseDescription(actionDescriptor);
            var prop = typeof(ApiDescription).GetProperties().Single(p => p.Name == "ResponseDescription");
            prop.SetValue(apiDescription, responseDescription);
        }

        private ResponseDescription CreateResponseDescription(HttpActionDescriptor actionDescriptor)
        {
            Collection<ResponseTypeAttribute> responseTypeAttributes = actionDescriptor.GetCustomAttributes<ResponseTypeAttribute>();
            Type responseType = responseTypeAttributes.Select(attribute => attribute.ResponseType).FirstOrDefault();

            return new ResponseDescription {
                DeclaredType = actionDescriptor.ReturnType,
                ResponseType = responseType,
                Documentation = GetApiResponseDocumentation(actionDescriptor)
            };
        }

        private string GetApiResponseDocumentation(HttpActionDescriptor actionDescriptor)
        {
            IDocumentationProvider documentationProvider = DocumentationProvider ?? actionDescriptor.Configuration.Services.GetDocumentationProvider();
            if(null != documentationProvider)
            {
                return documentationProvider.GetResponseDocumentation(actionDescriptor);
            }

            return null;
        }

    }
}
