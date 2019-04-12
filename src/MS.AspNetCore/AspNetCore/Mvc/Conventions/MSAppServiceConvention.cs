using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MS.Application.Services;
using MS.AspNetCore.Configuration;
using MS.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MS.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.Extensions.DependencyInjection;
using Castle.Windsor.MsDependencyInjection;

namespace MS.AspNetCore.Mvc.Conventions
{
    /// <summary>
    /// 自定义ApplicationModel;对服务类进行路由，Filter等应用
    /// </summary>
    public class MSAppServiceConvention : IApplicationModelConvention
    {
        private readonly Lazy<MSAspNetCoreConfiguration> _configuration;

        public MSAppServiceConvention(IServiceCollection serviceCollection)
        {
            _configuration = new Lazy<MSAspNetCoreConfiguration>(() =>
            {
                return serviceCollection
                    .GetSingletonService<MSBootStrapper>()
                    .IocManager
                    .Resolve<MSAspNetCoreConfiguration>();
            }, true);
        }


        public void Apply(ApplicationModel application)
        {
            foreach(var controller in application.Controllers)
            {
                var type = controller.ControllerType.AsType();
                var configuration = GetControllerSettingOrNull(type);

                if (typeof(IApplicationService).GetTypeInfo().IsAssignableFrom(type))
                {
                    controller.ControllerName = controller.ControllerName.RemovePostFix(ApplicationService.CommonPostfixes);
                    configuration?.ControllerModelConfigurer(controller);

                    ConfigureArea(controller, configuration);
                    ConfigureAppService(controller, configuration);
                }
                else
                {
                    //var remoteServiceAtt = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(type.GetTypeInfo());
                    //if (remoteServiceAtt != null )
                    //{
                    //    ConfigureAppService(controller, configuration);
                    //}
                }
            }
        }

        

        /// <summary>
        /// 配置区域
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="configuration">Controller对应程序集的配置信息</param>
        private void ConfigureArea(ControllerModel controller,[CanBeNull]MSControllerAssemblySetting configuration)
        {
            if (null == configuration)
                return;

            if (controller.RouteValues.ContainsKey("area"))
                return;

            controller.RouteValues["area"] = configuration.ModuleName;
        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="configuration"></param>
        private void ConfigureAppService(ControllerModel controller,[CanBeNull]MSControllerAssemblySetting configuration)
        {
            ConfigureApiExplorer(controller);
            ConfigureSelector(controller, configuration);
            ConfigureParameters(controller);
        }

        private void ConfigureParameters(ControllerModel controller)
        {
            foreach(var action in controller.Actions)
            {
                foreach(var parm in action.Parameters)
                {
                    if(parm.BindingInfo != null)
                    {
                        continue;
                    }
                    if (!TypeHelper.IsPrimitiveExtendedIncludingNullable(parm.ParameterInfo.ParameterType))
                    {
                        if (CanUseFormBodyBinding(action, parm))
                        {
                            parm.BindingInfo = BindingInfo.GetBindingInfo(new[] { new FromBodyAttribute() });
                        }
                    }
                }
            }
        }

        private bool CanUseFormBodyBinding(ActionModel action, ParameterModel parameter)
        {
            if (_configuration.Value.FormBodyBindingIgnoredTypes.Any(t => t.IsAssignableFrom(parameter.ParameterInfo.ParameterType)))
            {
                return false;
            }

            foreach (var selector in action.Selectors)
            {
                if (selector.ActionConstraints == null)
                {
                    continue;
                }

                foreach (var actionConstraint in selector.ActionConstraints)
                {
                    var httpMethodActionConstraint = actionConstraint as HttpMethodActionConstraint;
                    if (httpMethodActionConstraint == null)
                    {
                        continue;
                    }

                    if (httpMethodActionConstraint.HttpMethods.All(hm => hm.IsIn("GET", "DELETE", "TRACE", "HEAD")))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 配置远程服务的ApiExplorer
        /// </summary>
        /// <param name="controller"></param>
        private void ConfigureApiExplorer(ControllerModel controller)
        {
            // 如果这里赋值GroupName时，Swagger不会显示当前Controller信息
            if (string.IsNullOrEmpty(controller.ApiExplorer.GroupName))
            {
                controller.ApiExplorer.GroupName = controller.ControllerName;
            }

            if (!controller.ApiExplorer.IsVisible.HasValue)
            {
                controller.ApiExplorer.IsVisible = true;
                // 暂不处理RemoteService
                //var controllerType = controller.ControllerType.AsType();
                //var remoteAttr = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(controllerType.GetTypeInfo());
                //if(null != remoteAttr)
                //{
                //    controller.ApiExplorer.IsVisible = true;
                //}
                //else
                //{
                //    controller.ApiExplorer.IsVisible = true;
                //}
            }

            foreach(var action in controller.Actions)
            {
                ConfigureApiExplorer(action);
            }
        }

        private void ConfigureApiExplorer(ActionModel action)
        {
            if(!action.ApiExplorer.IsVisible.HasValue)
            {
                action.ApiExplorer.IsVisible = true;

                //var remoteServiceAttr = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(action.ActionMethod);

                //if(remoteServiceAttr != null)
                //{
                //    action.ApiExplorer.IsVisible = true;
                //}
            }
        }

        private void ConfigureSelector(ControllerModel controller,[CanBeNull]MSControllerAssemblySetting configuration)
        {
            RemoveEmptySelectors(controller.Selectors);
            if(controller.Selectors.Any(selector => selector.AttributeRouteModel != null))
            {
                return;
            }

            var moduleName = GetModuleNameOrDefault(controller.ControllerType.AsType());

            foreach (var action in controller.Actions)
            {
                ConfigureSelector(moduleName, controller.ControllerName, action, configuration);
            }
        }

        private void ConfigureSelector(string moduleName,string controllerName,ActionModel action,[CanBeNull]MSControllerAssemblySetting configuration)
        {
            RemoveEmptySelectors(action.Selectors);

            //var remoteServiceAtt = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(action.ActionMethod);
            //if (remoteServiceAtt != null)
            //{
            //    return;
            //}
            // 可以增加装载过滤器
            // action.Filters.Add()

            if (!action.Selectors.Any())
            {
                AddMSServiceSelector(moduleName, controllerName, action, configuration);
            }
            else
            {
                NormalizeSelectorRoutes(moduleName, controllerName, action);
            }
        }

        private void AddMSServiceSelector(string moduleName,string controllerName,ActionModel action,[CanBeNull]MSControllerAssemblySetting configuration)
        {
            var msServiceSelectorModel = new SelectorModel {
                AttributeRouteModel = CreateMSServiceAttributeRouteModel(moduleName, controllerName, action)
            };

            var verb = configuration?.UseConventionalHttpVerbs == true
                ? GetConventionalVerbForMethodName(action.ActionName) : "POST";

            msServiceSelectorModel.ActionConstraints.Add(new HttpMethodActionConstraint(new[] { verb }));

            action.Selectors.Add(msServiceSelectorModel);
        }
        private static string GetConventionalVerbForMethodName(string methodName)
        {
            if (methodName.StartsWith("Get", StringComparison.OrdinalIgnoreCase))
            {
                return "GET";
            }

            if (methodName.StartsWith("Put", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Update", StringComparison.OrdinalIgnoreCase))
            {
                return "PUT";
            }

            if (methodName.StartsWith("Delete", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Remove", StringComparison.OrdinalIgnoreCase))
            {
                return "DELETE";
            }

            if (methodName.StartsWith("Patch", StringComparison.OrdinalIgnoreCase))
            {
                return "PATCH";
            }

            if (methodName.StartsWith("Post", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Create", StringComparison.OrdinalIgnoreCase) ||
                methodName.StartsWith("Insert", StringComparison.OrdinalIgnoreCase))
            {
                return "POST";
            }

            //Default
            return "POST";
        }

        private static void NormalizeSelectorRoutes(string moduleName,string controllerName,ActionModel action)
        {
            foreach(var selector in action.Selectors)
            {
                if(selector.AttributeRouteModel == null)
                {
                    selector.AttributeRouteModel = CreateMSServiceAttributeRouteModel(
                        moduleName,
                        controllerName,
                        action
                        );
                }
            }
        }

        private string GetModuleNameOrDefault(Type controllerType)
        {
            return GetControllerSettingOrNull(controllerType)?.ModuleName ?? MSControllerAssemblySetting.DefaultServiceModuleName;
        }

        [CanBeNull]
        private MSControllerAssemblySetting GetControllerSettingOrNull(Type controllerType)
        {
            var settings = _configuration.Value.ControllerAssemblySettings.GetSettings(controllerType);

            return settings.FirstOrDefault(setting => setting.TypePredicate(controllerType));
        }

        /// <summary>
        /// 定义服务路由模型
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="controllerName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private static AttributeRouteModel CreateMSServiceAttributeRouteModel(string moduleName,string controllerName,ActionModel action)
        {
            return new AttributeRouteModel(new RouteAttribute(
                $"api/services/{moduleName}/{controllerName}/{action.ActionName}"
                ));
        }

        private static void RemoveEmptySelectors(IList<SelectorModel> selectors)
        {
            selectors.Where(IsEmptySelector)
                .ToList()
                .ForEach(s => selectors.Remove(s));
        }

        private static bool IsEmptySelector(SelectorModel selector)
        {
            return selector.AttributeRouteModel == null &&
                selector.ActionConstraints.IsNullOrEmpty();
        }
    }
}
