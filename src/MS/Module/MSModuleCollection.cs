using MS.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Module
{
    public class MSModuleCollection : List<MSModuleInfo>
    {
        public Type StartupModuleType { get; }

        public MSModuleCollection(Type startupModuleType)
        {
            StartupModuleType = startupModuleType;
        }

        /// <summary>
        /// 获取模块实例
        /// </summary>
        /// <typeparam name="TModule">Module type</typeparam>
        /// <returns>Reference to the module instance</returns>
        public TModule GetModule<TModule>() where TModule : MSModule
        {
            var module = this.FirstOrDefault(m => m.Type == typeof(TModule));
            if (module == null)
            {
                throw new MSException("Can not find module for " + typeof(TModule).FullName);
            }

            return (TModule)module.Instance;
        }

        public List<MSModuleInfo> GetSortedModuleListByDependency()
        {
            var sortedModules = this.SortByDependencies(x => x.Dependencies);
            EnsureKernelModuleToBeFirst(sortedModules);
            EnsureStartupModuleToBeLast(sortedModules, StartupModuleType);
            return sortedModules;
        }

        public void EnsureKernelModuleToBeFirst()
        {
            EnsureKernelModuleToBeFirst(this);
        }
        public void EnsureStartupModuleToBeLast()
        {
            EnsureStartupModuleToBeLast(this, StartupModuleType);
        }

        /// <summary>
        /// 确保核心模块排第一
        /// </summary>
        /// <param name="modules"></param>
        private static void EnsureKernelModuleToBeFirst(List<MSModuleInfo> modules)
        {
            var kernelModuleIndex = modules.FindIndex(m => m.Type == typeof(MSKernelModule));
            if (kernelModuleIndex <= 0)
            {
                //It's already the first!
                return;
            }

            var kernelModule = modules[kernelModuleIndex];
            modules.RemoveAt(kernelModuleIndex);
            modules.Insert(0, kernelModule);
        }

        /// <summary>
        /// 确保启动模块最后即启动模块的依赖模块在此模块前
        /// </summary>
        /// <param name="modules"></param>
        /// <param name="startupModuleType"></param>
        private static void EnsureStartupModuleToBeLast(List<MSModuleInfo> modules, Type startupModuleType)
        {
            var startupModuleIndex = modules.FindIndex(m => m.Type == startupModuleType);
            if (startupModuleIndex >= modules.Count - 1)
            {
                //It's already the last!
                return;
            }

            var startupModule = modules[startupModuleIndex];
            modules.RemoveAt(startupModuleIndex);
            modules.Add(startupModule);
        }
    }
}
