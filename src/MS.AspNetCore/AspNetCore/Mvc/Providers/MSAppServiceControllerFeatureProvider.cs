using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MS.Application.Services;
using MS.Dependency;
using System.Reflection;
using MS.Reflection;
using MS.AspNetCore.Configuration;
using System.Linq;

namespace MS.AspNetCore.Mvc.Providers
{
    /// <summary>
    /// 把服务类提供为Controller
    /// 继承<see cref="ControllerFactoryProvider"/>会从ApplicationPart发现Controller, 使 <see cref="ApplicationService"/> 成为Controller
    /// 只要继承<see cref="IApplicationService"/>接口就会自动成为Controller
    /// </summary>
    public class MSAppServiceControllerFeatureProvider : ControllerFeatureProvider
    {
        private readonly IIocResolver _iocResolver;
        public MSAppServiceControllerFeatureProvider(IIocResolver iocResolver)
        {
            _iocResolver = iocResolver;
        }

        protected override bool IsController(TypeInfo typeInfo)
        {
            var type = typeInfo.AsType();

            if (!typeof(IApplicationService).IsAssignableFrom(type)
                || !typeInfo.IsPublic || typeInfo.IsAbstract || typeInfo.IsGenericType)
            {
                return false;
            }

            //var remoteServiceAttr = ReflectionHelper.GetSingleAttributeOrDefault<RemoteServiceAttribute>(typeInfo);
            //if(null != remoteServiceAttr)
            //{
            //    return false;
            //}

            var settings = _iocResolver.Resolve<MSAspNetCoreConfiguration>().ControllerAssemblySettings.GetSettings(type);

            return settings.Any(setting => setting.TypePredicate(type));
        }
    }
}
