using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Module
{
    /// <summary>
    /// 定义MS模块间的依赖
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute: Attribute
    {
        /// <summary>
        /// 所有依赖模块类
        /// </summary>
        public Type[] DependedModuleTypes { get; private set; }

        /// <summary>
        /// MS模块间的依赖
        /// </summary>
        /// <param name="dependedModuleTypes">依赖模块类</param>
        public DependsOnAttribute(params Type[] dependedModuleTypes)
        {
            DependedModuleTypes = dependedModuleTypes;
        }
    }
}
