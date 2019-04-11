using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Routing;

namespace MS.AspNetCore.Configuration
{
    /// <summary>
    /// AspNetCore配置信息
    /// </summary>
    public class MSAspNetCoreConfiguration : IMSAspNetCoreConfiguration
    {
        /// <summary>
        /// Set Ajax Response 
        /// </summary>
        public bool SetNoCacheForAjaxResponses { get; set; }

        /// <summary>
        /// 路由配置信息
        /// </summary>
        public List<Action<IRouteBuilder>> RouteConfiguration { get; }

        /// <summary>
        /// Controller程序集设置列表
        /// </summary>
        public ControllerAssemblySettingList ControllerAssemblySettings { get; }

        /// <summary>
        /// 表单绑定忽略类型列表
        /// </summary>
        public List<Type> FormBodyBindingIgnoredTypes { get; }

        public MSAspNetCoreConfiguration()
        {
            SetNoCacheForAjaxResponses = true;
            RouteConfiguration = new List<Action<IRouteBuilder>>();
            FormBodyBindingIgnoredTypes = new List<Type>();
            ControllerAssemblySettings = new ControllerAssemblySettingList();
        }

        /// <summary>
        /// 扫描程序集来创建Controller
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="moduleName"></param>
        /// <param name="useConventionalHttpVerbs"></param>
        /// <returns></returns>
        public MSControllerAssemblySettingBuilder CreateControllersForAppServices(Assembly assembly
            , string moduleName = MSControllerAssemblySetting.DefaultServiceModuleName, 
            bool useConventionalHttpVerbs = true)
        {
            var setting = new MSControllerAssemblySetting(moduleName, assembly, useConventionalHttpVerbs);
            ControllerAssemblySettings.Add(setting);

            return new MSControllerAssemblySettingBuilder(setting);
        }
    }
}
