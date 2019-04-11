using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS.AspNetCore.Configuration
{
    public class MSControllerAssemblySetting
    {
        /// <summary>
        /// "app".
        /// </summary>
        public const string DefaultServiceModuleName = "app";

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; }

        /// <summary>
        /// 模块对应程序集
        /// </summary>
        public Assembly Assembly { get; }

        public bool UseConventionalHttpVerbs { get; }

        /// <summary>
        /// 类型推断
        /// </summary>
        public Func<Type,bool> TypePredicate { get; set; }

        /// <summary>
        /// ControllerModel 配置器
        /// </summary>
        public Action<ControllerModel> ControllerModelConfigurer { get; set; }

        public MSControllerAssemblySetting(string moduleName,Assembly assembly,bool useConventionalHttpVerbs)
        {
            ModuleName = moduleName;
            Assembly = assembly;
            UseConventionalHttpVerbs = useConventionalHttpVerbs;

            TypePredicate = type => true;
            ControllerModelConfigurer = controller => { };
        }
    }
}
