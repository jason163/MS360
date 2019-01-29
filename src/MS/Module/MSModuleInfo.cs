using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MS.Module
{
    /// <summary>
    /// MS模块信息
    /// </summary>
    public class MSModuleInfo
    {
        /// <summary>
        /// 包含模块的程序集
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// 模块类型
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// 模块实例
        /// </summary>
        public MSModule Instance { get; }

        /// <summary>
        /// Is this module loaded as a plugin.
        /// </summary>
        public bool IsLoadedAsPlugIn { get; }

        /// <summary>
        /// 模块所有依赖模块
        /// </summary>
        public List<MSModuleInfo> Dependencies { get; }

        /// <summary>
        /// Creates a new AbpModuleInfo object.
        /// </summary>
        public MSModuleInfo([NotNull] Type type, [NotNull] MSModule instance, bool isLoadedAsPlugIn)
        {
            Type = type;
            Instance = instance;
            IsLoadedAsPlugIn = isLoadedAsPlugIn;
            Assembly = Type.GetTypeInfo().Assembly;

            Dependencies = new List<MSModuleInfo>();
        }

        public override string ToString()
        {
            return Type.AssemblyQualifiedName ??
                   Type.FullName;
        }
    }
}
