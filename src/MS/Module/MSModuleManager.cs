using Castle.Core.Logging;
using MS.Dependency;
using MS.Exception;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace MS.Module
{
    /// <summary>
    /// MS Module 管理类
    /// </summary>
    public class MSModuleManager : IMSModuleManager
    {
        /// <summary>
        /// 开始模块
        /// </summary>
        public MSModuleInfo StartupModule { get; private set; }

        /// <summary>
        /// Castle日志接口
        /// </summary>
        public ILogger Logger { get; set; }
        /// <summary>
        /// 模块集合
        /// </summary>
        private MSModuleCollection _modules;

        /// <summary>
        /// Ioc管理接口
        /// </summary>
        private readonly IIocManager _iocManager;

        public IReadOnlyList<MSModuleInfo> Modules => _modules.ToImmutableList();

        public MSModuleManager(IIocManager iocManager)
        {
            _iocManager = iocManager;

            Logger = NullLogger.Instance;
        }

        public void Initialize(Type startupModule)
        {
            _modules = new MSModuleCollection(startupModule);
            LoadAllModules();
        }

        public void StartModules()
        {
            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.ForEach(module => module.Instance.PreInitialize());
            sortedModules.ForEach(module => module.Instance.Initialize());
            sortedModules.ForEach(module => module.Instance.PostInitialize());
        }

        public void ShutdownModules()
        {
            Logger.Debug("Shutting down has been started");

            var sortedModules = _modules.GetSortedModuleListByDependency();
            sortedModules.Reverse();
            sortedModules.ForEach(sm => sm.Instance.Shutdown());

            Logger.Debug("Shutting down completed.");
        }

        private void LoadAllModules()
        {
            Logger.Debug("Loading Abp modules...");

            List<Type> plugInModuleTypes;
            var moduleTypes = FindAllModuleTypes(out plugInModuleTypes).Distinct().ToList();

            Logger.Debug("Found " + moduleTypes.Count + " ABP modules in total.");

            RegisterModules(moduleTypes);
            CreateModules(moduleTypes);

            _modules.EnsureKernelModuleToBeFirst();
            _modules.EnsureStartupModuleToBeLast();

            SetDependencies();

            Logger.DebugFormat("{0} modules loaded.", _modules.Count);
        }

        private List<Type> FindAllModuleTypes(out List<Type> plugInModuleTypes)
        {
            plugInModuleTypes = new List<Type>();

            var modules = MSModule.FindDependedModuleTypesRecursivelyIncludingGivenModule(_modules.StartupModuleType);

            // Plugins
            //foreach (var plugInModuleType in _abpPlugInManager.PlugInSources.GetAllModules())
            //{
            //    if (modules.AddIfNotContains(plugInModuleType))
            //    {
            //        plugInModuleTypes.Add(plugInModuleType);
            //    }
            //}

            return modules;
        }

        private void CreateModules(ICollection<Type> moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                var moduleObject = _iocManager.Resolve(moduleType) as MSModule;
                if (moduleObject == null)
                {
                    throw new MSInitException("This type is not an MS module: " + moduleType.AssemblyQualifiedName);
                }

                moduleObject.IocManager = _iocManager;
                //moduleObject.Configuration = _iocManager.Resolve<IAbpStartupConfiguration>();

                var moduleInfo = new MSModuleInfo(moduleType, moduleObject, false);

                _modules.Add(moduleInfo);

                if (moduleType == _modules.StartupModuleType)
                {
                    StartupModule = moduleInfo;
                }

                Logger.DebugFormat("Loaded module: " + moduleType.AssemblyQualifiedName);
            }
        }

        private void RegisterModules(ICollection<Type> moduleTypes)
        {
            foreach (var moduleType in moduleTypes)
            {
                _iocManager.RegisterIfNot(moduleType);
            }
        }
        private void SetDependencies()
        {
            foreach (var moduleInfo in _modules)
            {
                moduleInfo.Dependencies.Clear();

                //Set dependencies for defined DependsOnAttribute attribute(s).
                foreach (var dependedModuleType in MSModule.FindDependedModuleTypes(moduleInfo.Type))
                {
                    var dependedModuleInfo = _modules.FirstOrDefault(m => m.Type == dependedModuleType);
                    if (dependedModuleInfo == null)
                    {
                        throw new MSInitException("Could not find a depended module " + dependedModuleType.AssemblyQualifiedName + " for " + moduleInfo.Type.AssemblyQualifiedName);
                    }

                    if ((moduleInfo.Dependencies.FirstOrDefault(dm => dm.Type == dependedModuleType) == null))
                    {
                        moduleInfo.Dependencies.Add(dependedModuleInfo);
                    }
                }
            }
        }
    }
}
