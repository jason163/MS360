using Castle.Core.Logging;
using MS.Configuration.Startup;
using MS.Dependency;
using MS.Exception;
using MS.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MS.Module
{
    /// <summary>
    /// 所有的模块定义都必须实现此类
    /// 模块定义类实现一些公共方法如：启动、停止，也定义了依赖模块
    /// </summary>
    public abstract class MSModule
    {
        /// <summary>
        /// IOC manager 引用
        /// </summary>
        protected internal IIocManager IocManager { get; internal set; }

        /// <summary>
        /// MS 框架配置引用
        /// </summary>
        protected internal IMSStartupConfiguration Configuration { get; internal set; }

        /// <summary>
        /// Castle 日志引用
        /// </summary>
        public ILogger Logger { get; set; }

        protected MSModule()
        {
            Logger = NullLogger.Instance;
        }

        /// <summary>
        /// 运用启动时执行的第一个事件.
        /// 依赖注入之前的一些初始化工作.
        /// </summary>
        public virtual void PreInitialize()
        {

        }

        /// <summary>
        /// 模块的依赖注册.
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// 应用启动后最后调用.
        /// </summary>
        public virtual void PostInitialize()
        {

        }

        /// <summary>
        /// 应用停止时调用.
        /// </summary>
        public virtual void Shutdown()
        {

        }

        /// <summary>
        /// 判断给定的类型是否为模块类型
        /// </summary>
        /// <param name="type">Type to check</param>
        public static bool IsMSModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(MSModule).IsAssignableFrom(type);
        }

        /// <summary>
        /// 找到模块所有依赖模块
        /// </summary>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            if (!IsMSModule(moduleType))
            {
                throw new MSInitException("This type is not an MS module: " + moduleType.AssemblyQualifiedName);
            }

            var list = new List<Type>();

            if (moduleType.GetTypeInfo().IsDefined(typeof(DependsOnAttribute), true))
            {
                var dependsOnAttributes = moduleType.GetTypeInfo().GetCustomAttributes(typeof(DependsOnAttribute), true).Cast<DependsOnAttribute>();
                foreach (var dependsOnAttribute in dependsOnAttributes)
                {
                    foreach (var dependedModuleType in dependsOnAttribute.DependedModuleTypes)
                    {
                        list.Add(dependedModuleType);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 递归查找模块依赖项
        /// </summary>
        /// <param name="modules"></param>
        /// <param name="module"></param>
        private static void AddModuleAndDependenciesRecursively(List<Type> modules, Type module)
        {
            if (!IsMSModule(module))
            {
                throw new MSInitException("This type is not an MS module: " + module.AssemblyQualifiedName);
            }

            if (modules.Contains(module))
            {
                return;
            }

            modules.Add(module);

            var dependedModules = FindDependedModuleTypes(module);
            foreach (var dependedModule in dependedModules)
            {
                AddModuleAndDependenciesRecursively(modules, dependedModule);
            }
        }

        /// <summary>
        /// 递归查找模块依赖项
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        public static List<Type> FindDependedModuleTypesRecursivelyIncludingGivenModule(Type moduleType)
        {
            var list = new List<Type>();
            AddModuleAndDependenciesRecursively(list, moduleType);

            list.AddIfNotContains(typeof(MSKernelModule));
            return list;
        }
    }
}
