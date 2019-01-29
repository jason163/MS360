using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Dependency
{
    /// <summary>
    /// 使用依赖注入系统中类型的生命周期类型
    /// </summary>
    public enum DependencyLifeStyle
    {
        /// <summary>
        /// 单例
        /// </summary>
        Singleton,

        /// <summary>
        /// 瞬态及每次使用都重新创建
        /// </summary>
        Transient
    }
}
