using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Routing;

namespace MS.AspNetCore.Configuration
{
    public class MSAspNetCoreConfiguration : IMSAspNetCoreConfiguration
    {

        public bool SetNoCacheForAjaxResponses { get; set; }

        public List<Action<IRouteBuilder>> RouteConfiguration { get; }

        public ControllerAssemblySettingList ControllerAssemblySettings { get; }

        public List<Type> FormBodyBindingIgnoredTypes { get; }

        public MSAspNetCoreConfiguration()
        {
            SetNoCacheForAjaxResponses = true;
            RouteConfiguration = new List<Action<IRouteBuilder>>();
            FormBodyBindingIgnoredTypes = new List<Type>();
        }

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
